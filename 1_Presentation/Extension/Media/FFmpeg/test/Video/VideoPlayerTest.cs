

using System;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video player test class
    /// </summary>
    /// <seealso cref="VideoPlayer" />
    public class VideoPlayerTest
    {
        /// <summary>
        ///     Tests that video player constructor should create instance
        /// </summary>
        [Fact]
        public void VideoPlayer_Constructor_ShouldCreateInstance()
        {
            VideoPlayer player = new VideoPlayer();

            Assert.NotNull(player);
        }


        /// <summary>
        ///     Tests that video player should be disposable
        /// </summary>
        [Fact]
        public void VideoPlayer_ShouldBeDisposable()
        {
            VideoPlayer player = new VideoPlayer();

            Assert.IsAssignableFrom<IDisposable>(player);
        }


        /// <summary>
        ///     Tests that video player should be disposable multiple times
        /// </summary>
        [Fact]
        public void VideoPlayer_ShouldBeDisposableMultipleTimes()
        {
            VideoPlayer player = new VideoPlayer();

            player.Dispose();
            player.Dispose();
            player.Dispose();
        }
    }
}