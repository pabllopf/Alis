using Xunit;
using System;
using CryMediaAPI.Video;
using CryMediaAPI.Resources;
using System.Threading.Tasks;

namespace CryMediaAPI.Tests
{
    public class VideoReaderTests
    {
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
