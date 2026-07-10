using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    public class MediaStreamRemainingCoverageTests
    {
        [Fact]
        public void AvgFrameRateNumber_Default_ShouldBeZero()
        {
            MediaStream stream = new MediaStream();
            Assert.Equal(0.0, stream.AvgFrameRateNumber);
        }

        [Fact]
        public void AvgFrameRateNumber_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { AvgFrameRateNumber = 29.97 };
            Assert.Equal(29.97, stream.AvgFrameRateNumber);
        }

        [Fact]
        public void IsAvc_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { IsAvc = "true" };
            Assert.Equal("true", stream.IsAvc);
        }

        [Fact]
        public void Profile_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { Profile = "High" };
            Assert.Equal("High", stream.Profile);
        }

        [Fact]
        public void CodecLongName_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { CodecLongName = "H.264 / AVC" };
            Assert.Equal("H.264 / AVC", stream.CodecLongName);
        }

        [Fact]
        public void PixFmt_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { PixFmt = "yuv420p" };
            Assert.Equal("yuv420p", stream.PixFmt);
        }

        [Fact]
        public void Level_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { Level = 51 };
            Assert.Equal(51, stream.Level);
        }
    }
}
