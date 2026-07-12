using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video.Models
{
    /// <summary>
    /// The video metadata remaining coverage tests class
    /// </summary>
    public class VideoMetadataRemainingCoverageTests
    {
        /// <summary>
        /// Tests that get first video stream when video stream exists returns stream
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_WhenVideoStreamExists_ReturnsStream()
        {
            var videoStream = new MediaStream { CodecType = "video" };
            var metadata = new VideoMetadata
            {
                Streams = new[] { videoStream }
            };

            var result = metadata.GetFirstVideoStream();

            Assert.NotNull(result);
            Assert.True(result.IsVideo);
        }

        /// <summary>
        /// Tests that get first video stream when no video stream returns null
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_WhenNoVideoStream_ReturnsNull()
        {
            var audioStream = new MediaStream { CodecType = "audio" };
            var metadata = new VideoMetadata
            {
                Streams = new[] { audioStream }
            };

            var result = metadata.GetFirstVideoStream();

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that get first audio stream when audio stream exists returns stream
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_WhenAudioStreamExists_ReturnsStream()
        {
            var audioStream = new MediaStream { CodecType = "audio" };
            var metadata = new VideoMetadata
            {
                Streams = new[] { audioStream }
            };

            var result = metadata.GetFirstAudioStream();

            Assert.NotNull(result);
            Assert.True(result.IsAudio);
        }

        /// <summary>
        /// Tests that get first audio stream when no audio stream returns null
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_WhenNoAudioStream_ReturnsNull()
        {
            var videoStream = new MediaStream { CodecType = "video" };
            var metadata = new VideoMetadata
            {
                Streams = new[] { videoStream }
            };

            var result = metadata.GetFirstAudioStream();

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that get first video stream with multiple streams returns first video
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_WithMultipleStreams_ReturnsFirstVideo()
        {
            var audioStream = new MediaStream { CodecType = "audio" };
            var videoStream1 = new MediaStream { CodecType = "video", Index = 1 };
            var videoStream2 = new MediaStream { CodecType = "video", Index = 2 };
            var metadata = new VideoMetadata
            {
                Streams = new[] { audioStream, videoStream1, videoStream2 }
            };

            var result = metadata.GetFirstVideoStream();

            Assert.NotNull(result);
            Assert.Equal(1, result.Index);
        }

        /// <summary>
        /// Tests that get first audio stream with multiple streams returns first audio
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_WithMultipleStreams_ReturnsFirstAudio()
        {
            var videoStream = new MediaStream { CodecType = "video" };
            var audioStream1 = new MediaStream { CodecType = "audio", Index = 1 };
            var audioStream2 = new MediaStream { CodecType = "audio", Index = 2 };
            var metadata = new VideoMetadata
            {
                Streams = new[] { videoStream, audioStream1, audioStream2 }
            };

            var result = metadata.GetFirstAudioStream();

            Assert.NotNull(result);
            Assert.Equal(1, result.Index);
        }
    }
}
