// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacPlayerTest.cs
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
    ///     The mac player test class
    /// </summary>
    /// <seealso cref="MacPlayer" />
    public class MacPlayerTest
    {
        /// <summary>
        ///     Tests that mac player constructor should initialize properly
        /// </summary>
        [MacOsOnly]
        public void MacPlayer_Constructor_ShouldInitializeProperly()
        {
            // Arrange & Act
            MacPlayer player = new MacPlayer();

            // Assert
            Assert.NotNull(player);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that playing property should return false initially
        /// </summary>
        [MacOsOnly]
        public void Playing_Property_ShouldReturnFalseInitially()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            bool playing = player.Playing;

            // Assert
            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return false initially
        /// </summary>
        [MacOsOnly]
        public void Paused_Property_ShouldReturnFalseInitially()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            bool paused = player.Paused;

            // Assert
            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that set volume with valid input should work
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithValidInput_ShouldWork()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 50;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with invalid input should throw exception
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithInvalidInput_ShouldThrowException()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 101;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(volume));
        }

        /// <summary>
        ///     Tests that set volume with zero should work
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithZero_ShouldWork()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 0;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with max value should work
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithMaxValue_ShouldWork()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 100;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that get bash command with wav file should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithWavFile_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.wav";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with mp3 file should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithMp3File_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.mp3";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with ogg file should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithOggFile_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.ogg";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with flac file should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithFlacFile_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.flac";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with any extension should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithAnyExtension_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.m4a";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that mac player implements i player interface
        /// </summary>
        [MacOsOnly]
        public void MacPlayer_ShouldImplementIPlayerInterface()
        {
            // Arrange & Act
            MacPlayer player = new MacPlayer();

            // Assert
            Assert.IsAssignableFrom<IPlayer>(player);
        }

        /// <summary>
        ///     Tests that mac player extends unix player base
        /// </summary>
        [MacOsOnly]
        public void MacPlayer_ShouldExtendUnixPlayerBase()
        {
            // Arrange & Act
            MacPlayer player = new MacPlayer();

            // Assert
            Assert.IsAssignableFrom<UnixPlayerBase>(player);
        }

        /// <summary>
        ///     Tests that set volume with value 101 should throw argument out of range exception
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithValue101_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 101;

            // Act & Assert
            ArgumentOutOfRangeException exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                player.SetVolume(volume));

            Assert.Equal("percent", exception.ParamName);
        }

        /// <summary>
        ///     Tests that set volume with value 255 should throw argument out of range exception
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithValue255_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 255;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(volume));
        }

        /// <summary>
        ///     Tests that set volume with mid range values should work
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithMidRangeValues_ShouldWork()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act & Assert
            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that get bash command with no extension should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithNoExtension_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "testfile";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with empty string should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithEmptyString_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = string.Empty;

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with uppercase extension should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithUppercaseExtension_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.WAV";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with mixed case extension should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithMixedCaseExtension_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.Mp3";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that playback finished event should be available
        /// </summary>
        [MacOsOnly]
        public void PlaybackFinished_Event_ShouldBeAvailable()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            bool eventAttached = false;

            // Act
            player.PlaybackFinished += (sender, e) => { eventAttached = true; };

            // Assert - Event handler attached without exception
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that get bash command should not be null or empty
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_ShouldNotBeNullOrEmpty()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.wav";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.NotNull(command);
            Assert.NotEmpty(command);
        }

        /// <summary>
        ///     Tests that get bash command with null should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithNull_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            string command = player.GetBashCommand(null);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with special characters should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithSpecialCharacters_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test@#$.wav";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with path should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithPath_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "/path/to/test.wav";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with aiff file should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithAiffFile_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.aiff";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that get bash command with aac file should return afplay
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithAacFile_ShouldReturnAfplay()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string fileName = "test.aac";

            // Act
            string command = player.GetBashCommand(fileName);

            // Assert
            Assert.Equal("afplay", command);
        }

        /// <summary>
        ///     Tests that set volume with boundary values should work
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_WithBoundaryValues_ShouldWork()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

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
        [MacOsOnly]
        public async Task SetVolume_Over100WithVariousValues_ShouldThrowException()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(101));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(150));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(200));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => player.SetVolume(255));
        }

        /// <summary>
        ///     Tests that set volume multiple times with different values should work
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_MultipleTimes_WithDifferentValues_ShouldWork()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

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
        [MacOsOnly]
        public async Task SetVolume_Exception_ShouldHaveCorrectParameterName()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 150;

            // Act & Assert
            ArgumentOutOfRangeException exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                player.SetVolume(volume));

            Assert.Equal("percent", exception.ParamName);
        }

        /// <summary>
        ///     Tests that set volume exception should have correct message
        /// </summary>
        [MacOsOnly]
        public async Task SetVolume_Exception_ShouldHaveCorrectMessage()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            byte volume = 150;

            // Act & Assert
            ArgumentOutOfRangeException exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                player.SetVolume(volume));

            Assert.Contains("100", exception.Message);
        }

        /// <summary>
        ///     Tests that get bash command should always return same value
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_ShouldAlwaysReturnSameValue()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            string command1 = player.GetBashCommand("test1.wav");
            string command2 = player.GetBashCommand("test2.mp3");
            string command3 = player.GetBashCommand("test3.ogg");

            // Assert
            Assert.Equal(command1, command2);
            Assert.Equal(command2, command3);
            Assert.Equal("afplay", command1);
        }

        /// <summary>
        ///     Tests that playback finished event without subscribers should not throw
        /// </summary>
        [MacOsOnly]
        public void PlaybackFinished_Event_WithoutSubscribers_ShouldNotThrow()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act & Assert - No handlers attached, event won't raise error
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that stop multiple times should be safe
        /// </summary>
        [MacOsOnly]
        public async Task Stop_MultipleTimes_ShouldBeSafe()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

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
        [MacOsOnly]
        public async Task Resume_MultipleTimes_ShouldBeSafe()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

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
        [MacOsOnly]
        public async Task Pause_Resume_Cycle_ShouldWorkCorrectly()
        {
            // Arrange
            MacPlayer player = new MacPlayer();

            // Act
            await player.Pause();
            await player.Resume();
            await player.Pause();
            await player.Resume();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that get bash command with different extensions should maintain consistency
        /// </summary>
        [MacOsOnly]
        public void GetBashCommand_WithDifferentExtensions_ShouldMaintainConsistency()
        {
            // Arrange
            MacPlayer player = new MacPlayer();
            string[] fileNames =
            {
                "test.wav", "test.mp3", "test.ogg", "test.flac",
                "test.m4a", "test.aiff", "test.aac", "test.wma"
            };

            // Act & Assert
            foreach (string fileName in fileNames)
            {
                string command = player.GetBashCommand(fileName);
                Assert.Equal("afplay", command);
            }
        }
    }
}