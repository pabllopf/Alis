using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The windows player logic tests class
    /// </summary>
    public class WindowsPlayerLogicTests
    {
        /// <summary>
        /// Tests that constructor should initialize with playing and paused false
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithPlayingAndPausedFalse()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that dispose multiple calls should not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            player.Dispose();
            player.Dispose();
        }

        /// <summary>
        /// Tests that dispose after using statement should work
        /// </summary>
        [Fact]
        public void Dispose_AfterUsingStatement_ShouldWork()
        {
            using (WindowsPlayer player = new WindowsPlayer())
            {
                Assert.NotNull(player);
            }
        }

        /// <summary>
        /// Tests that playing property should return correct initial value
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReturnCorrectInitialValue()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.False(player.Playing);
        }

        /// <summary>
        /// Tests that paused property should return correct initial value
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReturnCorrectInitialValue()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that windows player should implement i player
        /// </summary>
        [Fact]
        public void WindowsPlayer_ShouldImplementIPlayer()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        /// Tests that windows player should implement i disposable
        /// </summary>
        [Fact]
        public void WindowsPlayer_ShouldImplementIDisposable()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.IsAssignableFrom<IDisposable>(player);
        }

        /// <summary>
        /// Tests that playback finished event should be subscribable
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeSubscribable()
        {
            WindowsPlayer player = new WindowsPlayer();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that playback finished event can be unsubscribed
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_CanBeUnsubscribed()
        {
            WindowsPlayer player = new WindowsPlayer();
            EventHandler handler = (sender, e) => { };
            player.PlaybackFinished += handler;
            player.PlaybackFinished -= handler;
        }

        /// <summary>
        /// Tests that play with non existent file should throw file not found exception
        /// </summary>
        [Fact]
        public void Play_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            string nonExistent = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.wav");
            FileNotFoundException ex = Assert.ThrowsAsync<FileNotFoundException>(() => player.Play(nonExistent)).Result;
            Assert.Contains("not found", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that play loop with non existent file should throw file not found exception
        /// </summary>
        [Fact]
        public void PlayLoop_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            string nonExistent = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.wav");
            FileNotFoundException ex = Assert.ThrowsAsync<FileNotFoundException>(() => player.PlayLoop(nonExistent, false)).Result;
            Assert.Contains("not found", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that pause when not playing should not throw
        /// </summary>
        [Fact]
        public async Task Pause_WhenNotPlaying_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Pause();
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that resume when not playing should not throw
        /// </summary>
        [Fact]
        public async Task Resume_WhenNotPlaying_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Resume();
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that stop when not playing should not throw
        /// </summary>
        [Fact]
        public async Task Stop_WhenNotPlaying_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Stop();
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that stop after dispose should not throw
        /// </summary>
        [Fact]
        public async Task Stop_AfterDispose_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Stop();
            Assert.False(player.Playing);
        }

        /// <summary>
        /// Tests that pause after dispose should not throw
        /// </summary>
        [Fact]
        public async Task Pause_AfterDispose_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Pause();
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that resume after dispose should not throw
        /// </summary>
        [Fact]
        public async Task Resume_AfterDispose_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Resume();
            Assert.False(player.Playing);
        }

    }
}
