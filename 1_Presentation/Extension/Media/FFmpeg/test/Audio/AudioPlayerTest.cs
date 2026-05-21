

using System;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     The audio player test class
    /// </summary>
    /// <seealso cref="AudioPlayer" />
    public class AudioPlayerTest
    {
        /// <summary>
        ///     Tests that audio player constructor should create instance
        /// </summary>
        [Fact]
        public void AudioPlayer_Constructor_ShouldCreateInstance()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that audio player should be disposable
        /// </summary>
        [Fact]
        public void AudioPlayer_ShouldBeDisposable()
        {
            AudioPlayer player = new AudioPlayer();

            Assert.IsAssignableFrom<IDisposable>(player);
        }

        /// <summary>
        ///     Tests that audio player should be disposabl multiple times
        /// </summary>
        [Fact]
        public void AudioPlayer_ShouldBeDisposableMultipleTimes()
        {
            AudioPlayer player = new AudioPlayer();

            player.Dispose();
            player.Dispose();
            player.Dispose();
        }
    }
}