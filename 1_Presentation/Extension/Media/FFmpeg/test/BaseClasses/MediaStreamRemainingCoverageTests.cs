using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    /// The media stream remaining coverage tests class
    /// </summary>
    public class MediaStreamRemainingCoverageTests
    {
        /// <summary>
        /// Tests that avg frame rate number default should be zero
        /// </summary>
        [Fact]
        public void AvgFrameRateNumber_Default_ShouldBeZero()
        {
            MediaStream stream = new MediaStream();
            Assert.Equal(0.0, stream.AvgFrameRateNumber);
        }

        /// <summary>
        /// Tests that avg frame rate number should be settable
        /// </summary>
        [Fact]
        public void AvgFrameRateNumber_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { AvgFrameRateNumber = 29.97 };
            Assert.Equal(29.97, stream.AvgFrameRateNumber);
        }

        /// <summary>
        /// Tests that is avc should be settable
        /// </summary>
        [Fact]
        public void IsAvc_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { IsAvc = "true" };
            Assert.Equal("true", stream.IsAvc);
        }

        /// <summary>
        /// Tests that profile should be settable
        /// </summary>
        [Fact]
        public void Profile_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { Profile = "High" };
            Assert.Equal("High", stream.Profile);
        }

        /// <summary>
        /// Tests that codec long name should be settable
        /// </summary>
        [Fact]
        public void CodecLongName_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { CodecLongName = "H.264 / AVC" };
            Assert.Equal("H.264 / AVC", stream.CodecLongName);
        }

        /// <summary>
        /// Tests that pix fmt should be settable
        /// </summary>
        [Fact]
        public void PixFmt_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { PixFmt = "yuv420p" };
            Assert.Equal("yuv420p", stream.PixFmt);
        }

        /// <summary>
        /// Tests that level should be settable
        /// </summary>
        [Fact]
        public void Level_ShouldBeSettable()
        {
            MediaStream stream = new MediaStream { Level = 51 };
            Assert.Equal(51, stream.Level);
        }
    }
}
