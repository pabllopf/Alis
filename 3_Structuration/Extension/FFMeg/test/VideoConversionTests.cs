// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoConversionTests.cs
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
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Extension.FFMeg.Encoding.Builders;
using Alis.Core.Extension.FFMeg.Test.Assets;
using Alis.Core.Extension.FFMeg.Video;
using Xunit;

namespace Alis.Core.Extension.FFMeg.Test
{
    /// <summary>
    ///     The video conversion tests class
    /// </summary>
    public class VideoConversionTests
    {
        /// <summary>
        ///     Tests that conversion test 1
        /// </summary>
        [Fact]
        public async Task ConversionTest1()
        {
            string path = Res.GetPath(Res.Video_Mp4);
            string opath = "out-test-v-1.mp4";

            try
            {
                using VideoReader reader = new VideoReader(path);
                await reader.LoadMetadataAsync();

                using (VideoWriter writer = new VideoWriter(opath,
                           reader.Metadata.Width,
                           reader.Metadata.Height,
                           reader.Metadata.AvgFramerate,
                           new H264Encoder().Create()))
                {
                    writer.OpenWrite();

                    reader.Load();

                    await reader.CopyToAsync(writer);
                }

                using VideoReader video = new VideoReader(opath);
                await video.LoadMetadataAsync();

                Assert.True(video.Metadata.Codec == "h264");
                Assert.True(video.Metadata.AvgFramerate == reader.Metadata.AvgFramerate);
                Assert.True(Math.Abs(video.Metadata.Duration - reader.Metadata.Duration) < 0.01);
                Assert.True(video.Metadata.Width == reader.Metadata.Width);
                Assert.True(video.Metadata.Height == reader.Metadata.Height);
                Assert.True(video.Metadata.BitDepth == reader.Metadata.BitDepth);
                Assert.True(video.Metadata.Streams.Length == 1); // only video
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }

        /// <summary>
        ///     Tests that conversion stream test
        /// </summary>
        [Fact]
        public async Task ConversionStreamTest()
        {
            string path = Res.GetPath(Res.Video_Mp4);
            string opath = "out-test-v-2.mp4";

            try
            {
                using VideoReader reader = new VideoReader(path);
                await reader.LoadMetadataAsync();

                H264Encoder encoder = new H264Encoder
                {
                    Format = "flv"
                };

                using (FileStream filestream = File.Create(opath))
                {
                    using (VideoWriter writer = new VideoWriter(filestream,
                               reader.Metadata.Width,
                               reader.Metadata.Height,
                               reader.Metadata.AvgFramerate,
                               encoder.Create()))
                    {
                        writer.OpenWrite();

                        reader.Load();

                        await reader.CopyToAsync(writer);
                    }
                }

                using VideoReader video = new VideoReader(opath);
                await video.LoadMetadataAsync();

                Assert.True(video.Metadata.Codec == "h264");
                Assert.True(video.Metadata.AvgFramerate == reader.Metadata.AvgFramerate);
                Assert.True(Math.Abs(video.Metadata.Duration - reader.Metadata.Duration) < 0.2);
                Assert.True(video.Metadata.Width == reader.Metadata.Width);
                Assert.True(video.Metadata.Height == reader.Metadata.Height);
                Assert.True(video.Metadata.BitDepth == reader.Metadata.BitDepth);
                Assert.True(video.Metadata.Streams.Length == 1); // only video
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }

        /// <summary>
        ///     Tests that conversion test 2
        /// </summary>
        [Fact]
        public async Task ConversionTest2()
        {
            string path = Res.GetPath(Res.Video_Mp4);
            string opath = "out-test-v-2.webm";

            try
            {
                VP9Encoder encoder = new VP9Encoder();
                encoder.RowBasedMultithreading = true;
                encoder.SetCQP();

                using VideoReader reader = new VideoReader(path);

                reader.LoadMetadata();
                reader.Load();

                using (VideoWriter writer = new VideoWriter(opath,
                           reader.Metadata.Width,
                           reader.Metadata.Height,
                           reader.Metadata.AvgFramerate,
                           encoder.Create()))
                {
                    writer.OpenWrite(true);
                    reader.CopyTo(writer);
                }


                using VideoReader video = new VideoReader(opath);
                await video.LoadMetadataAsync();

                Assert.True(video.Metadata.Codec == "vp9");
                Assert.True(video.Metadata.AvgFramerate == reader.Metadata.AvgFramerate);
                Assert.True(Math.Abs(video.Metadata.Duration - reader.Metadata.Duration) < 0.01);
                Assert.True(video.Metadata.Width == reader.Metadata.Width);
                Assert.True(video.Metadata.Height == reader.Metadata.Height);
                Assert.True(video.Metadata.Streams.Length == 1); // only video
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }
    }
}