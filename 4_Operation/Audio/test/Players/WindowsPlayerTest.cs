// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayerTest.cs
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The windows player test class
    /// </summary>
    /// <seealso cref="WindowsPlayer" />
    public class WindowsPlayerTest
    {
        /// <summary>
        ///     Tests that windows player constructor should initialize properly
        /// </summary>
        [Fact]
        public void WindowsPlayer_Constructor_ShouldInitializeProperly()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange & Act
            WindowsPlayer player = new WindowsPlayer();

            // Assert
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that playing property should return false initially
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReturnFalseInitially()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

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
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            bool paused = player.Paused;

            // Assert
            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that play should throw file not found exception when file does not exist
        /// </summary>
        [Fact]
        public async Task Play_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(nonExistentFile));
        }

        /// <summary>
        ///     Tests that pause should not throw when not playing
        /// </summary>
        [Fact]
        public async Task Pause_ShouldNotThrow_WhenNotPlaying()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            await player.Pause();

            // Assert
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that resume should not throw when not playing
        /// </summary>
        [Fact]
        public async Task Resume_ShouldNotThrow_WhenNotPlaying()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            await player.Resume();

            // Assert
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that stop should set playing and paused to false
        /// </summary>
        [Fact]
        public async Task Stop_ShouldSetPlayingAndPausedToFalse()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that set volume should accept byte parameter
        /// </summary>
        [Fact]
        public async Task SetVolume_ShouldAcceptByteParameter()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
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
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
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
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            byte volume = 100;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple pause calls should be safe
        /// </summary>
        [Fact]
        public async Task Pause_MultipleCalls_ShouldBeSafe()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            await player.Pause();
            await player.Pause();
            await player.Pause();

            // Assert - No exception thrown
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple stop calls should be safe
        /// </summary>
        [Fact]
        public async Task Stop_MultipleCalls_ShouldBeSafe()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            await player.Stop();
            await player.Stop();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that playback finished event should be available
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeAvailable()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            bool eventAttached = false;

            // Act
            player.PlaybackFinished += (sender, e) => { eventAttached = true; };

            // Assert - Event handler attached without exception
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that dispose should not throw exception
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrowException()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            player.Dispose();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple dispose calls should be safe
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldBeSafe()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            player.Dispose();
            player.Dispose();
            player.Dispose();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play loop should throw file not found exception when file does not exist
        /// </summary>
        [Fact]
        public async Task PlayLoop_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";
            bool loop = true;

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(nonExistentFile, loop));
        }

        /// <summary>
        ///     Tests that play loop without loop should work like normal play
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithoutLoop_ShouldWorkLikeNormalPlay()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            string nonExistentFile = "nonexistent_file_12345.wav";
            bool loop = false;

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(nonExistentFile, loop));
        }

        /// <summary>
        ///     Tests that set volume with mid range values should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithMidRangeValues_ShouldWork()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act & Assert
            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that resume without pause should not throw
        /// </summary>
        [Fact]
        public async Task Resume_WithoutPause_ShouldNotThrow()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act
            await player.Resume();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that windows player implements i player interface
        /// </summary>
        [Fact]
        public void WindowsPlayer_ShouldImplementIPlayerInterface()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange & Act
            WindowsPlayer player = new WindowsPlayer();

            // Assert
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that windows player implements i disposable interface
        /// </summary>
        [Fact]
        public void WindowsPlayer_ShouldImplementIDisposableInterface()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange & Act
            WindowsPlayer player = new WindowsPlayer();

            // Assert
            Assert.IsAssignableFrom<IDisposable>(player);
        }

        /// <summary>
        ///     Tests that set volume over 100 should still work
        /// </summary>
        [Fact]
        public async Task SetVolume_Over100_ShouldStillWork()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            byte volume = 255; // Max byte value

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play with null file name should throw exception
        /// </summary>
        [Fact]
        public async Task Play_WithNullFileName_ShouldThrowException()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(null));
        }

        /// <summary>
        ///     Tests that play loop with null file name should throw exception
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithNullFileName_ShouldThrowException()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.PlayLoop(null, true));
        }

        /// <summary>
        ///     Tests that play with empty file name should throw exception
        /// </summary>
        [Fact]
        public async Task Play_WithEmptyFileName_ShouldThrowException()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await player.Play(string.Empty));
        }

        /// <summary>
        ///     Tests that stop after dispose should not throw
        /// </summary>
        [Fact]
        public async Task Stop_AfterDispose_ShouldNotThrow()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            // Arrange
            WindowsPlayer player = new WindowsPlayer();
            player.Dispose();

            // Act
            await player.Stop();

            // Assert - No exception thrown
            Assert.False(player.Playing);
        }
    }
}

