using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class WindowsPlayerLogicTests
    {
        [Fact]
        public void Constructor_ShouldInitializeWithPlayingAndPausedFalse()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            player.Dispose();
            player.Dispose();
        }

        [Fact]
        public void Dispose_AfterUsingStatement_ShouldWork()
        {
            using (WindowsPlayer player = new WindowsPlayer())
            {
                Assert.NotNull(player);
            }
        }

        [Fact]
        public void Playing_Property_ShouldReturnCorrectInitialValue()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.False(player.Playing);
        }

        [Fact]
        public void Paused_Property_ShouldReturnCorrectInitialValue()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.False(player.Paused);
        }

        [Fact]
        public void WindowsPlayer_ShouldImplementIPlayer()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        [Fact]
        public void WindowsPlayer_ShouldImplementIDisposable()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.IsAssignableFrom<IDisposable>(player);
        }

        [Fact]
        public void PlaybackFinished_Event_ShouldBeSubscribable()
        {
            WindowsPlayer player = new WindowsPlayer();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;
            Assert.NotNull(player);
        }

        [Fact]
        public void PlaybackFinished_Event_CanBeUnsubscribed()
        {
            WindowsPlayer player = new WindowsPlayer();
            EventHandler handler = (sender, e) => { };
            player.PlaybackFinished += handler;
            player.PlaybackFinished -= handler;
        }

        [Fact]
        public void Play_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            string nonExistent = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.wav");
            FileNotFoundException ex = Assert.ThrowsAsync<FileNotFoundException>(() => player.Play(nonExistent)).Result;
            Assert.Contains("not found", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void PlayLoop_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            string nonExistent = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.wav");
            FileNotFoundException ex = Assert.ThrowsAsync<FileNotFoundException>(() => player.PlayLoop(nonExistent, false)).Result;
            Assert.Contains("not found", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task Pause_WhenNotPlaying_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Pause();
            Assert.False(player.Paused);
        }

        [Fact]
        public async Task Resume_WhenNotPlaying_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Resume();
            Assert.False(player.Paused);
        }

        [Fact]
        public async Task Stop_WhenNotPlaying_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Stop();
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        [Fact]
        public async Task Stop_AfterDispose_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Stop();
            Assert.False(player.Playing);
        }

        [Fact]
        public async Task Pause_AfterDispose_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Pause();
            Assert.False(player.Paused);
        }

        [Fact]
        public async Task Resume_AfterDispose_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Resume();
            Assert.False(player.Playing);
        }

        [Fact]
        public void PlaybackFinished_FileName_ShouldBeInternal()
        {
            FieldInfo field = typeof(WindowsPlayer).GetField("_fileName", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);
        }
    }
}
