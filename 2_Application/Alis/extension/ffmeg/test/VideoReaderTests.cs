using System;
using System.Threading.Tasks;
using Alis.Extension.FFMeg.Test.Resources;
using Alis.Extension.FFMeg.Video;
using Xunit;

namespace Alis.Extension.FFMeg.Test
{
    /// <summary>
    /// The video reader tests class
    /// </summary>
    public class VideoReaderTests
    {
        /// <summary>
        /// Tests that load metadata mp 4
        /// </summary>
        [Fact]
        public async Task LoadMetadataMp4()  
        {
            VideoReader video = new VideoReader(Res.GetPath(Res.Video_Mp4));

            await video.LoadMetadataAsync();

            Assert.True(video.Metadata.Codec == "h264");
            Assert.True(video.Metadata.AvgFramerate == 30);
            Assert.True(video.Metadata.AvgFramerateText == "30/1");
            Assert.True(Math.Abs(video.Metadata.Duration - 5.533333) < 0.01);
            Assert.True(video.Metadata.Width == 560);
            Assert.True(video.Metadata.Height == 320);
            Assert.True(video.Metadata.BitDepth == 8);
            Assert.True(video.Metadata.BitRate == 465641);
            Assert.True(video.Metadata.PixelFormat == "yuv420p");
            Assert.True(video.Metadata.Streams.Length == 2);
        }

        /// <summary>
        /// Tests that load metadata webm
        /// </summary>
        [Fact]
        public async Task LoadMetadataWebm()
        {
            VideoReader video = new VideoReader(Res.GetPath(Res.Video_Webm));

            await video.LoadMetadataAsync();

            Assert.True(video.Metadata.Codec == "vp8");
            Assert.True(video.Metadata.AvgFramerate == 30);
            Assert.True(video.Metadata.AvgFramerateText == "30/1");
            Assert.True(Math.Abs(video.Metadata.Duration - 5.568) < 0.01); 
            Assert.True(video.Metadata.Width == 560);
            Assert.True(video.Metadata.Height == 320);
            Assert.True(video.Metadata.PixelFormat == "yuv420p");
            Assert.True(video.Metadata.Streams.Length == 2);  
        }

        /// <summary>
        /// Tests that load metadata flv
        /// </summary>
        [Fact]
        public async Task LoadMetadataFlv()
        {
            VideoReader video = new VideoReader(Res.GetPath(Res.Video_Flv));

            await video.LoadMetadataAsync();

            Assert.True(video.Metadata.Codec == "flv1");
            Assert.True(video.Metadata.AvgFramerate == 25);
            Assert.True(video.Metadata.AvgFramerateText == "25/1");
            Assert.True(Math.Abs(video.Metadata.Duration - 5.56) < 0.01);
            Assert.True(video.Metadata.Width == 320); 
            Assert.True(video.Metadata.Height == 240); 
            Assert.True(video.Metadata.BitRate == 800000);
            Assert.True(video.Metadata.PixelFormat == "yuv420p");
            Assert.True(video.Metadata.Streams.Length == 2); 
        }

        /// <summary>
        /// Tests that load at offset 1
        /// </summary>
        [Fact]
        public async Task LoadAtOffset1()
        {
            using VideoReader video = new VideoReader(Res.GetPath(Res.Video_Flv));
            int second = 3;

            await video.LoadMetadataAsync();

            double at_frame = (second * video.Metadata.PredictedFrameCount) / video.Metadata.Duration;
            int frames_left = (int)Math.Round(video.Metadata.PredictedFrameCount - at_frame);

            video.Load(second);

            int count = 1;
            VideoFrame frame = video.NextFrame();
            while (true)
            {
                frame = video.NextFrame(frame);
                if (frame == null) break;
                count++;
            }

            Assert.True(frames_left == count);
        }

        /// <summary>
        /// Tests that load at offset 2
        /// </summary>
        [Fact]
        public async Task LoadAtOffset2()
        {
            using VideoReader video = new VideoReader(Res.GetPath(Res.Video_Mp4));
            int second = 4;

            await video.LoadMetadataAsync();

            double at_frame = (second * video.Metadata.PredictedFrameCount) / video.Metadata.Duration;
            int frames_left = (int)Math.Round(video.Metadata.PredictedFrameCount - at_frame);

            video.Load(second);

            int count = 1;
            VideoFrame frame = video.NextFrame();
            while (true)
            {
                frame = video.NextFrame(frame);
                if (frame == null) break;
                count++;
            }

            Assert.True(frames_left == count);
        }
    }
}
