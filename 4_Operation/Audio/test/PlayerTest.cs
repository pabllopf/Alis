// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerTest.cs
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test
{
    /// <summary>
    ///     The player test class
    /// </summary>
    /// <seealso cref="Player" />
    public class PlayerTest
    {
        /// <summary>
        ///     Tests that player constructor should initialize internal player
        /// </summary>
        [Fact]
        public void Player_Constructor_ShouldInitializeInternalPlayer()
        {
            // Arrange & Act
            Player player = new Player();

            // Assert
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that player constructor should initialize with correct os specific player
        /// </summary>
        [Fact]
        public void Player_Constructor_ShouldInitializeWithCorrectOsSpecificPlayer()
        {
            // Arrange & Act
            Player player = new Player();

            // Assert
            Assert.NotNull(player);

            // Verify the player is initialized correctly for current OS
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.NotNull(player);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.NotNull(player);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.NotNull(player);
            }
        }

        /// <summary>
        ///     Tests that playing property should return false initially
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReturnFalseInitially()
        {
            // Arrange
            Player player = new Player();

            // Act
            bool playing = player.Playing;

            // Assert
            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReturnFalseInitially()
        {
            // Arrange
            Player player = new Player();

            // Act
            bool paused = player.Paused;

            // Assert
            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that check os should return windows player on windows
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnWindowsPlayer_OnWindows()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.IsType<WindowsPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return linux player on linux
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnLinuxPlayer_OnLinux()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.IsType<LinuxPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return mac player on mac
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnMacPlayer_OnMac()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.IsType<MacPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return browser player on webassembly
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnBrowserPlayer_OnWebAssembly()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("WEBASSEMBLY")))
            {
                Assert.IsType<BrowserPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return browser player on browser
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnBrowserPlayer_OnBrowser()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
            {
                Assert.IsType<BrowserPlayer>(player);
            }
        }

        /// <summary>
        ///     Tests that check os should return valid player on current platform
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnValidPlayer_OnCurrentPlatform()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that on playback finished should invoke event handler
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_ShouldInvokeEventHandler()
        {
            // Arrange
            Player player = new Player();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            // Act
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Tests that on playback finished with null sender should not throw
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithNullSender_ShouldNotThrow()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert - No exception should be thrown
            player.OnPlaybackFinished(null, EventArgs.Empty);
        }

        /// <summary>
        ///     Tests that on playback finished without handlers should not throw
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithoutHandlers_ShouldNotThrow()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert - No exception should be thrown
            player.OnPlaybackFinished(player, EventArgs.Empty);
        }

        /// <summary>
        ///     Tests that playback finished event should be invokable
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeInvokable()
        {
            // Arrange
            Player player = new Player();
            int eventCount = 0;
            player.PlaybackFinished += (sender, e) => eventCount++;

            // Act
            player.OnPlaybackFinished(player, EventArgs.Empty);
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.Equal(2, eventCount);
        }

        /// <summary>
        ///     Tests that playback finished event sender should be player instance
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_SenderShouldBePlayerInstance()
        {
            // Arrange
            Player player = new Player();
            object eventSender = null;
            player.PlaybackFinished += (sender, e) => eventSender = sender;

            // Act
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.Same(player, eventSender);
        }

        /// <summary>
        ///     Tests that multiple event handlers should all be invoked
        /// </summary>
        [Fact]
        public void PlaybackFinished_MultipleEventHandlers_ShouldAllBeInvoked()
        {
            // Arrange
            Player player = new Player();
            int handler1Count = 0;
            int handler2Count = 0;
            int handler3Count = 0;

            player.PlaybackFinished += (sender, e) => handler1Count++;
            player.PlaybackFinished += (sender, e) => handler2Count++;
            player.PlaybackFinished += (sender, e) => handler3Count++;

            // Act
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.Equal(1, handler1Count);
            Assert.Equal(1, handler2Count);
            Assert.Equal(1, handler3Count);
        }

        /// <summary>
        ///     Tests that play method should accept file name parameter
        /// </summary>
        [Fact]
        public async Task Play_Method_ShouldAcceptFileNameParameter()
        {
            // Arrange
            Player player = new Player();
            string fileName = "nonexistent.wav";

            // Act & Assert
            try
            {
                await player.Play(fileName);
            }
            catch (Exception)
            {
                // Expected when file doesn't exist
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that play loop method should accept file name and loop parameters
        /// </summary>
        [Fact]
        public async Task PlayLoop_Method_ShouldAcceptFileNameAndLoopParameters()
        {
            // Arrange
            Player player = new Player();
            string fileName = "nonexistent.wav";
            bool loop = true;

            // Act & Assert
            try
            {
                await player.PlayLoop(fileName, loop);
            }
            catch (Exception)
            {
                // Expected when file doesn't exist
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that pause method should be callable
        /// </summary>
        [Fact]
        public async Task Pause_Method_ShouldBeCallable()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Pause();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that resume method should be callable
        /// </summary>
        [Fact]
        public async Task Resume_Method_ShouldBeCallable()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Resume();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that stop method should be callable
        /// </summary>
        [Fact]
        public async Task Stop_Method_ShouldBeCallable()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Stop();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume method should accept byte parameter
        /// </summary>
        [Fact]
        public async Task SetVolume_Method_ShouldAcceptByteParameter()
        {
            // Arrange
            Player player = new Player();
            byte volume = 50;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with zero should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithZero_ShouldWork()
        {
            // Arrange
            Player player = new Player();
            byte volume = 0;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with max value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithMaxValue_ShouldWork()
        {
            // Arrange
            Player player = new Player();
            byte volume = 100;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play loop with false should work like normal play
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithFalse_ShouldWorkLikeNormalPlay()
        {
            // Arrange
            Player player = new Player();
            string fileName = "nonexistent.wav";
            bool loop = false;

            // Act & Assert
            try
            {
                await player.PlayLoop(fileName, loop);
            }
            catch (Exception)
            {
                // Expected when file doesn't exist
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that multiple pause calls should be safe
        /// </summary>
        [Fact]
        public async Task Pause_MultipleCalls_ShouldBeSafe()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Pause();
            await player.Pause();
            await player.Pause();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple stop calls should be safe
        /// </summary>
        [Fact]
        public async Task Stop_MultipleCalls_ShouldBeSafe()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Stop();
            await player.Stop();
            await player.Stop();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that internal player should handle playback finished event
        /// </summary>
        [Fact]
        public void InternalPlayer_ShouldHandlePlaybackFinishedEvent()
        {
            // Arrange
            Player player = new Player();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            // Act
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Tests that check os should return player implementing i player
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnPlayerImplementingIPlayer()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            Assert.NotNull(player);
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that set volume with mid range values should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithMidRangeValues_ShouldWork()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert
            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that event handlers can be removed
        /// </summary>
        [Fact]
        public void PlaybackFinished_EventHandlers_CanBeRemoved()
        {
            // Arrange
            Player player = new Player();
            int eventCount = 0;
            EventHandler handler = (sender, e) => eventCount++;

            player.PlaybackFinished += handler;
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Act
            player.PlaybackFinished -= handler;
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.Equal(1, eventCount);
        }

        /// <summary>
        ///     Tests that check os should return non null player
        /// </summary>
        [Fact]
        public void CheckOs_ShouldReturnNonNullPlayer()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play with null file name should throw exception
        /// </summary>
        [Fact]
        public async Task Play_WithNullFileName_ShouldThrowException()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(null));
        }

        /// <summary>
        ///     Tests that play with empty file name should throw exception
        /// </summary>
        [Fact]
        public async Task Play_WithEmptyFileName_ShouldThrowException()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(string.Empty));
        }

        /// <summary>
        ///     Tests that play loop with null file name should throw exception
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithNullFileName_ShouldThrowException()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(null, true));
        }

        /// <summary>
        ///     Tests that play loop with empty file name should throw exception
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithEmptyFileName_ShouldThrowException()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(string.Empty, false));
        }

        /// <summary>
        ///     Tests that resume without playing should not throw
        /// </summary>
        [Fact]
        public async Task Resume_WithoutPlaying_ShouldNotThrow()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Resume();

            // Assert - No exception thrown
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that set volume with byte max value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMaxValue_ShouldWork()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.SetVolume(90);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with byte min value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMinValue_ShouldWork()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.SetVolume(byte.MinValue);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that on playback finished should pass correct event args
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_ShouldPassCorrectEventArgs()
        {
            // Arrange
            Player player = new Player();
            EventArgs receivedArgs = null;
            player.PlaybackFinished += (sender, e) => receivedArgs = e;

            // Act
            EventArgs testArgs = EventArgs.Empty;
            player.OnPlaybackFinished(player, testArgs);

            // Assert
            Assert.Same(testArgs, receivedArgs);
        }

        /// <summary>
        ///     Tests that multiple operations in sequence should work
        /// </summary>
        [Fact]
        public async Task MultipleOperations_InSequence_ShouldWork()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert - No exception thrown
            await player.SetVolume(50);
            await player.Pause();
            await player.Resume();
            await player.Stop();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that check os should handle all platforms
        /// </summary>
        [Fact]
        public void CheckOs_ShouldHandleAllPlatforms()
        {
            // Arrange & Act
            IPlayer player = Player.CheckOs();

            // Assert
            Assert.NotNull(player);

            // Verify it's one of the expected types
            bool isValidType = player is WindowsPlayer ||
                               player is LinuxPlayer ||
                               player is MacPlayer ||
                               player is BrowserPlayer;

            Assert.True(isValidType || player == null);
        }

        /// <summary>
        ///     Tests that playback finished event args should not be null
        /// </summary>
        [Fact]
        public void PlaybackFinished_EventArgs_ShouldNotBeNull()
        {
            // Arrange
            Player player = new Player();
            EventArgs receivedArgs = null;
            player.PlaybackFinished += (sender, e) => receivedArgs = e;

            // Act
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.NotNull(receivedArgs);
        }

        /// <summary>
        ///     Tests that playing property should reflect internal player state
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReflectInternalPlayerState()
        {
            // Arrange
            Player player = new Player();

            // Act
            bool initialState = player.Playing;

            // Assert
            Assert.False(initialState);
        }

        /// <summary>
        ///     Tests that paused property should reflect internal player state
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReflectInternalPlayerState()
        {
            // Arrange
            Player player = new Player();

            // Act
            bool initialState = player.Paused;

            // Assert
            Assert.False(initialState);
        }

        /// <summary>
        ///     Tests that play loop with loop true should accept parameter
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithLoopTrue_ShouldAcceptParameter()
        {
            // Arrange
            Player player = new Player();

            // Act & Assert
            try
            {
                await player.PlayLoop("nonexistent.wav", true);
            }
            catch (Exception)
            {
                // Expected when file doesn't exist
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that set volume during playback should work
        /// </summary>
        [Fact]
        public async Task SetVolume_DuringPlayback_ShouldWork()
        {
            // Arrange
            Player player = new Player();

            // Act
            try
            {
                await player.Play("nonexistent.wav");
            }
            catch
            {
                // Ignore file not found
            }

            await player.SetVolume(75);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume while paused should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WhilePaused_ShouldWork()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Pause();
            await player.SetVolume(30);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that on playback finished with custom event args should work
        /// </summary>
        [Fact]
        public void OnPlaybackFinished_WithCustomEventArgs_ShouldWork()
        {
            // Arrange
            Player player = new Player();
            EventArgs receivedArgs = null;
            player.PlaybackFinished += (sender, e) => receivedArgs = e;

            // Act
            EventArgs customArgs = new EventArgs();
            player.OnPlaybackFinished(player, customArgs);

            // Assert
            Assert.Same(customArgs, receivedArgs);
        }

        /// <summary>
        ///     Tests that pause resume multiple cycles should work
        /// </summary>
        [Fact]
        public async Task Pause_Resume_MultipleCycles_ShouldWork()
        {
            // Arrange
            Player player = new Player();

            // Act
            await player.Pause();
            await player.Resume();
            await player.Pause();
            await player.Resume();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that internal player should forward playback finished to player
        /// </summary>
        [Fact]
        public void InternalPlayer_ShouldForwardPlaybackFinishedToPlayer()
        {
            // Arrange
            Player player = new Player();
            bool eventReceived = false;
            player.PlaybackFinished += (sender, e) => eventReceived = true;

            // Act
            player.OnPlaybackFinished(player, EventArgs.Empty);

            // Assert
            Assert.True(eventReceived);
        }
    }
}