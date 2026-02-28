// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxPlayerTest.cs
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
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The linux player test class
    /// </summary>
    /// <seealso cref="LinuxPlayer" />
    public class LinuxPlayerTest
    {
        /// <summary>
        ///     Tests that linux player constructor should initialize properly
        /// </summary>
        [LinuxOnly]
        public void LinuxPlayer_Constructor_ShouldInitializeProperly()
        {
            // Arrange & Act
            LinuxPlayer player = new LinuxPlayer();

            // Assert
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that playing property should return false initially
        /// </summary>
        [LinuxOnly]
        public void Playing_Property_ShouldReturnFalseInitially()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            bool playing = player.Playing;

            // Assert
            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially
        /// </summary>
        [LinuxOnly]
        public void Paused_Property_ShouldReturnFalseInitially()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            bool paused = player.Paused;

            // Assert
            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that set volume with valid input should work
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithValidInput_ShouldWork()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 50;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with invalid input should throw exception
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithInvalidInput_ShouldThrowException()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 101;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(volume));
        }

        /// <summary>
        ///     Tests that set volume with zero should work
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithZero_ShouldWork()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 0;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with max value should work
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithMaxValue_ShouldWork()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 100;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that get bash command with wav file should return mpg123
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithWavFile_ShouldReturnMpg123()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test.wav";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with non wav file should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithNonWavFile_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test.mp3";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with uppercase wav extension should return mpg123
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithUppercaseWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test.WAV";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with mixed case wav extension should return mpg123
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithMixedCaseWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test.WaV";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with ogg file should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithOggFile_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test.ogg";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with flac file should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithFlacFile_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test.flac";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        ///     Tests that linux player implements i player interface
        /// </summary>
        [LinuxOnly]
        public void LinuxPlayer_ShouldImplementIPlayerInterface()
        {
            // Arrange & Act
            LinuxPlayer player = new LinuxPlayer();

            // Assert
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that linux player extends unix player base
        /// </summary>
        [LinuxOnly]
        public void LinuxPlayer_ShouldExtendUnixPlayerBase()
        {
            // Arrange & Act
            LinuxPlayer player = new LinuxPlayer();

            // Assert
            Assert.IsAssignableFrom<UnixPlayerBase>(player);
        }

        /// <summary>
        ///     Tests that set volume with value 101 should throw argument out of range exception
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithValue101_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 101;

            // Act & Assert
            ArgumentOutOfRangeException exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                player.SetVolume(volume));

            Assert.Equal("percent", exception.ParamName);
        }

        /// <summary>
        ///     Tests that set volume with value 255 should throw argument out of range exception
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithValue255_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 255;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(volume));
        }

        /// <summary>
        ///     Tests that set volume with mid range values should work
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithMidRangeValues_ShouldWork()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act & Assert
            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that get bash command with no extension should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithNoExtension_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "testfile";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with empty string should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithEmptyString_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = string.Empty;

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        ///     Tests that playback finished event should be available
        /// </summary>
        [LinuxOnly]
        public void PlaybackFinished_Event_ShouldBeAvailable()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            bool eventAttached = false;

            // Act
            player.PlaybackFinished += (sender, e) => { eventAttached = true; };

            // Assert - Event handler attached without exception
            Assert.NotNull(player);
        }
        
        /// <summary>
        ///     Tests that get bash command with special characters should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithSpecialCharacters_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test@#$.wav";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with path should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithPath_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "/path/to/test.wav";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        ///     Tests that get bash command with dot wav in middle should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithDotWavInMiddle_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "test.wav.mp3";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        ///     Tests that set volume with boundary values should work
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_WithBoundaryValues_ShouldWork()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act & Assert
            await player.SetVolume(0);
            await player.SetVolume(1);
            await player.SetVolume(99);
            await player.SetVolume(100);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume over 100 with various values should throw exception
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_Over100WithVariousValues_ShouldThrowException()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(101));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(150));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(200));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(255));
        }

        /// <summary>
        ///     Tests that set volume multiple times with different values should work
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_MultipleTimes_WithDifferentValues_ShouldWork()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.SetVolume(0);
            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);
            await player.SetVolume(100);
            await player.SetVolume(50);
            await player.SetVolume(0);

            // Assert
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume exception should have correct parameter name
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_Exception_ShouldHaveCorrectParameterName()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 150;

            // Act & Assert
            ArgumentOutOfRangeException exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                player.SetVolume(volume));

            Assert.Equal("percent", exception.ParamName);
        }

        /// <summary>
        ///     Tests that set volume exception should have correct message
        /// </summary>
        [LinuxOnly]
        public async Task SetVolume_Exception_ShouldHaveCorrectMessage()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            byte volume = 150;

            // Act & Assert
            ArgumentOutOfRangeException exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                player.SetVolume(volume));

            Assert.Contains("100", exception.Message);
        }

        /// <summary>
        ///     Tests that get bash command should be case insensitive for wav
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_ShouldBeCaseInsensitiveForWav()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command1 = player.GetBashCommand("test.wav");
            string command2 = player.GetBashCommand("test.WAV");
            string command3 = player.GetBashCommand("test.WaV");
            string command4 = player.GetBashCommand("test.wAv");

            // Assert
            Assert.Equal("mpg123 -q", command1);
            Assert.Equal("mpg123 -q", command2);
            Assert.Equal("mpg123 -q", command3);
            Assert.Equal("mpg123 -q", command4);
        }

        /// <summary>
        ///     Tests that playback finished event without subscribers should not throw
        /// </summary>
        [LinuxOnly]
        public void PlaybackFinished_Event_WithoutSubscribers_ShouldNotThrow()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act & Assert - No handlers attached, event won't raise error
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event can be subscribed multiple times
        /// </summary>
        [LinuxOnly]
        public void PlaybackFinished_Event_CanBeSubscribedMultipleTimes()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            int handler1Count = 0;
            int handler2Count = 0;

            // Act
            player.PlaybackFinished += (sender, e) => handler1Count++;
            player.PlaybackFinished += (sender, e) => handler2Count++;

            // Assert - Multiple handlers attached successfully
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event can be unsubscribed
        /// </summary>
        [LinuxOnly]
        public void PlaybackFinished_Event_CanBeUnsubscribed()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            EventHandler handler = (sender, e) => { };

            // Act
            player.PlaybackFinished += handler;
            player.PlaybackFinished -= handler;

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that stop multiple times should be safe
        /// </summary>
        [LinuxOnly]
        public async Task Stop_MultipleTimes_ShouldBeSafe()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Stop();
            await player.Stop();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that resume multiple times should be safe
        /// </summary>
        [LinuxOnly]
        public async Task Resume_MultipleTimes_ShouldBeSafe()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Resume();
            await player.Resume();
            await player.Resume();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that pause resume cycle should work correctly
        /// </summary>
        [LinuxOnly]
        public async Task Pause_Resume_Cycle_ShouldWorkCorrectly()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Pause();
            await player.Resume();
            await player.Pause();
            await player.Resume();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that get bash command with mp3 extension should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithMp3Extension_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string fileName = "audio.mp3";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        ///     Tests that pause stop sequence should reset state
        /// </summary>
        [LinuxOnly]
        public async Task Pause_Stop_Sequence_ShouldResetState()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Pause();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that resume stop sequence should reset state
        /// </summary>
        [LinuxOnly]
        public async Task Resume_Stop_Sequence_ShouldResetState()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            await player.Resume();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that get bash command should not be null
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_ShouldNotBeNull()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("test.wav");

            // Assert
            Assert.NotNull(command);
        }

        /// <summary>
        ///     Tests that get bash command should not be empty
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_ShouldNotBeEmpty()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("test.wav");

            // Assert
            Assert.NotEmpty(command);
        }
    }
}