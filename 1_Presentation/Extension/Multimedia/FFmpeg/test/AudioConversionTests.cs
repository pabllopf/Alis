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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using Alis.Extension.Multimedia.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Multimedia.FFmpeg.Test
{
    /// <summary>
    ///     The audio conversion tests class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class AudioConversionTests 
    {
        /// <summary>
        ///     Tests that f fmpeg wrapper progress test
        /// </summary>
        [Fact]
        public async Task FFmpegWrapperProgressTest()
        {
            string path = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets"), Res.Audio_Ogg);
            string opath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "out_test.mp3");

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
    }
}