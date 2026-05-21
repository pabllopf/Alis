

using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The i media frame test class
    /// </summary>
    /// <seealso cref="IMediaFrame" />
    public class IMediaFrameTest
    {
        /// <summary>
        ///     Tests that audio frame should implement i media frame
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldImplementIMediaFrame()
        {
            AudioFrame frame = new AudioFrame(2);

            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        ///     Tests that video frame should implement i media frame
        /// </summary>
        [Fact]
        public void VideoFrame_ShouldImplementIMediaFrame()
        {
            VideoFrame frame = new VideoFrame(1920, 1080);

            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        ///     Tests that i media frame raw data should not be null for audio frame
        /// </summary>
        [Fact]
        public void IMediaFrame_RawDataShouldNotBeNullForAudioFrame()
        {
            IMediaFrame frame = new AudioFrame(2);

            byte[] rawData = frame.RawData;

            Assert.NotNull(rawData);
        }

        /// <summary>
        ///     Tests that i media frame raw data should not be null for video frame
        /// </summary>
        [Fact]
        public void IMediaFrame_RawDataShouldNotBeNullForVideoFrame()
        {
            IMediaFrame frame = new VideoFrame(1920, 1080);

            byte[] rawData = frame.RawData;

            Assert.NotNull(rawData);
        }

        /// <summary>
        ///     Tests that i media frame load should work with empty stream for audio frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithEmptyStreamForAudioFrame()
        {
            IMediaFrame frame = new AudioFrame(2);
            MemoryStream emptyStream = new MemoryStream();

            bool result = frame.Load(emptyStream);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that i media frame load should work with empty stream for video frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithEmptyStreamForVideoFrame()
        {
            IMediaFrame frame = new VideoFrame(1920, 1080);
            MemoryStream emptyStream = new MemoryStream();

            bool result = frame.Load(emptyStream);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that i media frame load should work with data stream for audio frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithDataStreamForAudioFrame()
        {
            IMediaFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400];
            MemoryStream stream = new MemoryStream(testData);

            bool result = frame.Load(stream);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that i media frame load should work with data stream for video frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithDataStreamForVideoFrame()
        {
            IMediaFrame frame = new VideoFrame(10, 10);
            byte[] testData = new byte[300];
            MemoryStream stream = new MemoryStream(testData);

            bool result = frame.Load(stream);

            Assert.True(result);
        }
    }
}