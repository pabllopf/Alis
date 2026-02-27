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
using System.Runtime.InteropServices;
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
    }
}