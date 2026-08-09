// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayerTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Tests for WindowsPlayer internal methods and uncovered code paths.
    /// </summary>
    public class WindowsPlayerTests
    {
        /// <summary>
        ///     Tests that constructor initializes Playing and Paused to false.
        /// </summary>
        [Fact]
        public void Constructor_PlayingAndPaused_False()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that WindowsPlayer implements IPlayer.
        /// </summary>
        [Fact]
        public void WindowsPlayer_Implements_IPlayer()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that WindowsPlayer implements IDisposable.
        /// </summary>
        [Fact]
        public void WindowsPlayer_Implements_IDisposable()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.IsAssignableFrom<IDisposable>(player);
        }

        /// <summary>
        ///     Tests that Dispose does not throw.
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
        }

        /// <summary>
        ///     Tests that multiple Dispose calls do not throw.
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
        ///     Tests that Dispose via using statement works.
        /// </summary>
        [Fact]
        public void Dispose_ViaUsing_ShouldNotThrow()
        {
            using (WindowsPlayer player = new WindowsPlayer())
            {
                Assert.NotNull(player);
            }
        }

        /// <summary>
        ///     Tests that PlaybackFinished event can be subscribed and unsubscribed.
        /// </summary>
        [Fact]
        public void PlaybackFinished_CanSubscribeAndUnsubscribe()
        {
            WindowsPlayer player = new WindowsPlayer();
            EventHandler handler = (sender, e) => { };
            player.PlaybackFinished += handler;
            player.PlaybackFinished -= handler;
        }

        /// <summary>
        ///     Sets up a timer on the player via reflection for HandlePlaybackFinished tests.
        /// </summary>
        private static void SetupTimer(WindowsPlayer player)
        {
            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer", BindingFlags.NonPublic | BindingFlags.Instance);
            timerField.SetValue(player, new System.Timers.Timer(100) { AutoReset = false });
        }

        /// <summary>
        ///     Tests that HandlePlaybackFinished sets Playing to false.
        /// </summary>
        [Fact]
        public void HandlePlaybackFinished_SetsPlayingFalse()
        {
            WindowsPlayer player = new WindowsPlayer();
            SetupTimer(player);
            player.HandlePlaybackFinished(null, null);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that HandlePlaybackFinished invokes PlaybackFinished event.
        /// </summary>
        [Fact]
        public void HandlePlaybackFinished_InvokesEvent()
        {
            WindowsPlayer player = new WindowsPlayer();
            SetupTimer(player);
            bool invoked = false;
            player.PlaybackFinished += (sender, e) => invoked = true;
            player.HandlePlaybackFinished(null, null);
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that HandlePlaybackFinished passes sender and args.
        /// </summary>
        [Fact]
        public void HandlePlaybackFinished_PassesSenderAndArgs()
        {
            WindowsPlayer player = new WindowsPlayer();
            SetupTimer(player);
            object capturedSender = null;
            object capturedArgs = null;
            player.PlaybackFinished += (sender, e) => { capturedSender = sender; capturedArgs = e; };
            player.HandlePlaybackFinished(player, null);
            Assert.Same(player, capturedSender);
            Assert.Null(capturedArgs);
        }

        /// <summary>
        ///     Tests that HandlePlaybackFinished passes null ElapsedEventArgs.
        /// </summary>
        [Fact]
        public void HandlePlaybackFinished_PassesEventArgs()
        {
            WindowsPlayer player = new WindowsPlayer();
            SetupTimer(player);
            EventArgs capturedArgs = new EventArgs();
            player.PlaybackFinished += (sender, e) => capturedArgs = e;
            player.HandlePlaybackFinished(null, null);
            Assert.Null(capturedArgs);
        }

        /// <summary>
        ///     Tests that ExecuteMsiCommand is accessible and throws DllNotFoundException on non-Windows.
        /// </summary>
        [Fact]
        public void ExecuteMsiCommand_OnNonWindows_ThrowsDllNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.Throws<DllNotFoundException>(() => player.ExecuteMsiCommand("Status test.wav Length"));
        }

        /// <summary>
        ///     Tests that ExecuteMsiCommand throws with empty command.
        /// </summary>
        [Fact]
        public void ExecuteMsiCommand_WithEmptyCommand_Throws()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.Throws<DllNotFoundException>(() => player.ExecuteMsiCommand(string.Empty));
        }

        /// <summary>
        ///     Tests that Play with non-existent file throws FileNotFoundException.
        /// </summary>
        [Fact]
        public async Task Play_NonExistentFile_ThrowsFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            string nonExistent = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.wav");
            FileNotFoundException ex = await Assert.ThrowsAsync<FileNotFoundException>(() => player.Play(nonExistent));
            Assert.Contains("not found", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that PlayLoop with non-existent file throws FileNotFoundException.
        /// </summary>
        [Fact]
        public async Task PlayLoop_NonExistentFile_ThrowsFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            string nonExistent = Path.Combine(Path.GetTempPath(), $"nonexistent_{Guid.NewGuid()}.wav");
            FileNotFoundException ex = await Assert.ThrowsAsync<FileNotFoundException>(() => player.PlayLoop(nonExistent, false));
            Assert.Contains("not found", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that Play with null file name throws FileNotFoundException.
        /// </summary>
        [Fact]
        public async Task Play_NullFileName_ThrowsFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            await Assert.ThrowsAsync<FileNotFoundException>(() => player.Play(null));
        }

        /// <summary>
        ///     Tests that PlayLoop with null file name throws FileNotFoundException.
        /// </summary>
        [Fact]
        public async Task PlayLoop_NullFileName_ThrowsFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            await Assert.ThrowsAsync<FileNotFoundException>(() => player.PlayLoop(null, false));
        }

        /// <summary>
        ///     Tests that Pause when not playing does not change state.
        /// </summary>
        [Fact]
        public async Task Pause_WhenNotPlaying_StateUnchanged()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Pause();
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that Resume when not paused does not change state.
        /// </summary>
        [Fact]
        public async Task Resume_WhenNotPaused_StateUnchanged()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Resume();
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that Stop when not playing does not change state.
        /// </summary>
        [Fact]
        public async Task Stop_WhenNotPlaying_StateUnchanged()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.Stop();
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that SetVolume on non-Windows throws DllNotFoundException.
        /// </summary>
        [Fact]
        public async Task SetVolume_OnNonWindows_ThrowsDllNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            await Assert.ThrowsAsync<DllNotFoundException>(() => player.SetVolume(50));
        }

        /// <summary>
        ///     Tests that Pause after Dispose does not throw.
        /// </summary>
        [Fact]
        public async Task Pause_AfterDispose_DoesNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Pause();
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that Resume after Dispose does not throw.
        /// </summary>
        [Fact]
        public async Task Resume_AfterDispose_DoesNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Resume();
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that Stop after Dispose does not throw.
        /// </summary>
        [Fact]
        public async Task Stop_AfterDispose_DoesNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();
            await player.Stop();
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that PlaybackFinished event can have multiple handlers.
        /// </summary>
        [Fact]
        public void PlaybackFinished_MultipleHandlers()
        {
            WindowsPlayer player = new WindowsPlayer();
            SetupTimer(player);
            int count = 0;
            player.PlaybackFinished += (sender, e) => count++;
            player.PlaybackFinished += (sender, e) => count++;
            player.HandlePlaybackFinished(null, null);
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that SetVolume on Windows works (Windows only).
        /// </summary>
        [WindowsOnly]
        public async Task SetVolume_OnWindows_ShouldNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.SetVolume(50);
            await player.SetVolume(0);
            await player.SetVolume(100);
        }

        /// <summary>
        ///     Tests that SetVolume with edge values on Windows works (Windows only).
        /// </summary>
        [WindowsOnly]
        public async Task SetVolume_EdgeValues_OnWindows()
        {
            WindowsPlayer player = new WindowsPlayer();
            await player.SetVolume(byte.MinValue);
            await player.SetVolume(byte.MaxValue);
        }

        /// <summary>
        ///     Tests that Play on Windows with existing file starts playback (Windows only).
        /// </summary>
        [WindowsOnly]
        public async Task Play_OnWindows_WithExistingFile_StartsPlayback()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "dummy");
                WindowsPlayer player = new WindowsPlayer();
                await player.Play(tempFile);
                Assert.True(player.Playing);
                Assert.False(player.Paused);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that PlayLoop on Windows with existing file starts playback (Windows only).
        /// </summary>
        [WindowsOnly]
        public async Task PlayLoop_OnWindows_WithExistingFile_StartsPlayback()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "dummy");
                WindowsPlayer player = new WindowsPlayer();
                await player.PlayLoop(tempFile, false);
                Assert.True(player.Playing);
                Assert.False(player.Paused);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }
    }
}
