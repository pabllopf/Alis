using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Alis.Extension.FFMeg.Encoding.Builders;
using Alis.Extension.FFMeg.Test.Assets;
using Alis.Extension.FFMeg.Video;
using Xunit;

namespace Alis.Extension.FFMeg.Test
{
    /// <summary>
    /// The video conversion tests class
    /// </summary>
    public class VideoConversionTests
    {
        /// <summary>
        /// Tests that conversion test 1
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
                Assert.True(video.Metadata.Streams.Length == 1);  // only video
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }

        /// <summary>
        /// Tests that conversion stream test
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
                Assert.True(video.Metadata.Streams.Length == 1);  // only video
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }

        /// <summary>
        /// Tests that conversion test 2
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
                encoder.SetCQP(31);

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
                Assert.True(video.Metadata.Streams.Length == 1);  // only video
            }
            finally
            {
                if (File.Exists(opath)) File.Delete(opath);
            }
        }
    }
}
