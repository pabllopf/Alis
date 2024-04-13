// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioConversionTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Alis.Extension.Encode.FFMeg.Audio;
using Alis.Extension.Encode.FFMeg.Encoding.Builders;
using Alis.Extension.Encode.FFMeg.Test.Assets;
using Xunit;

namespace Alis.Extension.Encode.FFMeg.Test
{
    /// <summary>
    ///     The audio conversion tests class
    /// </summary>
    public class AudioConversionTests
    {
        /// <summary>
        ///     Tests that f fmpeg wrapper progress test
        /// </summary>
        [Fact]
        public async Task FFmpegWrapperProgressTest()
        {
            string path = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Assets"), Res.Audio_Ogg);
            string opath = Path.Combine(Environment.CurrentDirectory, "out_test.mp3");
            
            try
            {
                if (File.Exists(opath))
                {
                    File.Delete(opath);
                }
                
                AudioReader audio = new AudioReader(path);
                
                await audio.LoadMetadataAsync();
                double dur = audio.Metadata.Duration;
                audio.Dispose();
                
                Assert.True(Math.Abs(dur - 1.515102) < 0.01);
                
                Process p = FfMpegWrapper.ExecuteCommand("ffmpeg", $"-i {path} {opath}", true);
                FfMpegWrapper.RegisterProgressTracker(p, dur);
                
                p.WaitForExit();
                
                await Task.Delay(300);
                
                audio = new AudioReader(opath);
                
                await audio.LoadMetadataAsync();
                
                Assert.True(audio.Metadata.Channels == 2);
                Assert.True(audio.Metadata.Streams.Length == 1);
                Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.2);
                
                audio.Dispose();
            }
            finally
            {
                if (File.Exists(opath))
                {
                    File.Delete(opath);
                }
            }
        }
        
        /// <summary>
        ///     Tests that conversion test
        /// </summary>
        [Fact]
        public async Task ConversionTest()
        {
            string path = Res.GetPath(Res.Audio_Ogg);
            string opath = "out-test-2.mp3";
            
            try
            {
                using AudioReader reader = new AudioReader(path);
                await reader.LoadMetadataAsync();
                
                using (AudioWriter writer = new AudioWriter(opath,
                           reader.Metadata.Channels,
                           reader.Metadata.SampleRate, 16,
                           new MP3Encoder().Create()))
                {
                    writer.OpenWrite();
                    
                    reader.Load();
                    
                    await reader.CopyToAsync(writer);
                }
                
                using AudioReader audio = new AudioReader(opath);
                await audio.LoadMetadataAsync();
                
                Assert.True(audio.Metadata.Format.FormatName == "mp3");
                Assert.True(audio.Metadata.Channels == 2);
                Assert.True(audio.Metadata.Streams.Length == 1);
                Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.2);
            }
            finally
            {
                if (File.Exists(opath))
                {
                    File.Delete(opath);
                }
            }
        }
        
        /// <summary>
        ///     Tests that conversion stream test
        /// </summary>
        [Fact]
        public void ConversionStreamTest()
        {
            string path = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Assets"), Res.Audio_Mp3);
            string opath = Path.Combine(Environment.CurrentDirectory, "outTestV2.aac");
            
            try
            {
                using AudioReader reader = new AudioReader(path);
                reader.LoadMetadata();
                
                AACEncoder encoder = new AACEncoder
                {
                    Format = "flv"
                };
                
                using (FileStream filestream = File.Create(opath))
                {
                    using (AudioWriter writer = new AudioWriter(filestream,
                               reader.Metadata.Channels,
                               reader.Metadata.SampleRate, 16,
                               encoder.Create()))
                    {
                        writer.OpenWrite();
                        
                        reader.Load();
                        
                        reader.CopyTo(writer);
                    }
                }
                
                using AudioReader audio = new AudioReader(opath);
                audio.LoadMetadata();
                
                Assert.True(audio.Metadata.Format.FormatName == "flv");
                Assert.True(audio.Metadata.Channels == 2);
                Assert.True(audio.Metadata.Streams.Length == 1);
                //Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.2);
            }
            finally
            {
                if (File.Exists(opath))
                {
                    File.Delete(opath);
                }
            }
        }
    }
}