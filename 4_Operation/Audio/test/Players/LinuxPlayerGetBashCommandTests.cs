// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxPlayerGetBashCommandTests.cs
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
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Tests for LinuxPlayer.GetBashCommand method covering all file extension branches.
    /// </summary>
    public class LinuxPlayerGetBashCommandTests
    {
        /// <summary>
        /// Gets the bash command with wav extension should return mpg 123
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with ogg extension should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithOggExtension_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/file.ogg");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        /// Gets the bash command with flac extension should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithFlacExtension_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/file.flac");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        /// Gets the bash command with mp 3 extension should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithMp3Extension_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/file.mp3");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        /// Gets the bash command with null file name should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithNullFileName_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act & Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => player.GetBashCommand(null));
            Assert.Equal("fileName", exception.ParamName);
        }

        /// <summary>
        /// Gets the bash command with empty file name should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithEmptyFileName_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        /// Gets the bash command with no extension should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithNoExtension_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("file");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        /// <summary>
        /// Gets the bash command with spaces in path should return aplay
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithSpacesInPath_ShouldReturnAplay()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/my file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with uppercase wav extension should return mpg 123
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithUppercaseWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/file.WAV");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with mixed case wav extension should return mpg 123
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithMixedCaseWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/file.WaV");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with long path should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithLongPath_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();
            string longPath = "/very/long/path/to/a/file/that/has/many/directories/file.wav";

            // Act
            string command = player.GetBashCommand(longPath);

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with relative path should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithRelativePath_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("./relative/path/file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with home directory path should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithHomeDirectoryPath_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("~/music/file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with special characters in path should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithSpecialCharactersInPath_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("/path/to/file-with_special.chars.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        /// <summary>
        /// Gets the bash command with multiple dots in filename should return correct command
        /// </summary>
        [LinuxOnly]
        public void GetBashCommand_WithMultipleDotsInFilename_ShouldReturnCorrectCommand()
        {
            // Arrange
            LinuxPlayer player = new LinuxPlayer();

            // Act
            string command = player.GetBashCommand("file.name.with.dots.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }
    }
}
