using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
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
        [RequireFfmpegFact]
        public void GetFirstVideoStream_WhenVideoStreamExists_ReturnsStream()
        {
            MediaStream videoStream = new MediaStream { CodecType = "video" };
            VideoMetadata metadata = new VideoMetadata
            {
                Streams = new[] { videoStream }
            };

            MediaStream result = metadata.GetFirstVideoStream();

            Assert.NotNull(result);
            Assert.True(result.IsVideo);
        }

        /// <summary>
        /// Tests that get first video stream when no video stream returns null
        /// </summary>
        [RequireFfmpegFact]
        public void GetFirstVideoStream_WhenNoVideoStream_ReturnsNull()
        {
            MediaStream audioStream = new MediaStream { CodecType = "audio" };
            VideoMetadata metadata = new VideoMetadata
            {
                Streams = new[] { audioStream }
            };

            MediaStream result = metadata.GetFirstVideoStream();

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that get first audio stream when audio stream exists returns stream
        /// </summary>
        [RequireFfmpegFact]
        public void GetFirstAudioStream_WhenAudioStreamExists_ReturnsStream()
        {
            MediaStream audioStream = new MediaStream { CodecType = "audio" };
            VideoMetadata metadata = new VideoMetadata
            {
                Streams = new[] { audioStream }
            };

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.NotNull(result);
            Assert.True(result.IsAudio);
        }

        /// <summary>
        /// Tests that get first audio stream when no audio stream returns null
        /// </summary>
        [RequireFfmpegFact]
        public void GetFirstAudioStream_WhenNoAudioStream_ReturnsNull()
        {
            MediaStream videoStream = new MediaStream { CodecType = "video" };
            VideoMetadata metadata = new VideoMetadata
            {
                Streams = new[] { videoStream }
            };

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that get first video stream with multiple streams returns first video
        /// </summary>
        [RequireFfmpegFact]
        public void GetFirstVideoStream_WithMultipleStreams_ReturnsFirstVideo()
        {
            MediaStream audioStream = new MediaStream { CodecType = "audio" };
            MediaStream videoStream1 = new MediaStream { CodecType = "video", Index = 1 };
            MediaStream videoStream2 = new MediaStream { CodecType = "video", Index = 2 };
            VideoMetadata metadata = new VideoMetadata
            {
                Streams = new[] { audioStream, videoStream1, videoStream2 }
            };

            MediaStream result = metadata.GetFirstVideoStream();

            Assert.NotNull(result);
            Assert.Equal(1, result.Index);
        }

        /// <summary>
        /// Tests that get first audio stream with multiple streams returns first audio
        /// </summary>
        [RequireFfmpegFact]
        public void GetFirstAudioStream_WithMultipleStreams_ReturnsFirstAudio()
        {
            MediaStream videoStream = new MediaStream { CodecType = "video" };
            MediaStream audioStream1 = new MediaStream { CodecType = "audio", Index = 1 };
            MediaStream audioStream2 = new MediaStream { CodecType = "audio", Index = 2 };
            VideoMetadata metadata = new VideoMetadata
            {
                Streams = new[] { videoStream, audioStream1, audioStream2 }
            };

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.NotNull(result);
            Assert.Equal(1, result.Index);
        }
    }
}
