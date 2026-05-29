// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxPlayerGetBashCommandTests.cs
// 
//  Copyright (c) 2021 GNU General Public License v3.0
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
        [LinuxOnly]
        public void GetBashCommand_WithWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithOggExtension_ShouldReturnAplay()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/file.ogg");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithFlacExtension_ShouldReturnAplay()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/file.flac");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithMp3Extension_ShouldReturnAplay()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/file.mp3");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithNullFileName_ShouldReturnAplay()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => player.GetBashCommand(null));
            Assert.Equal("fileName", exception.ParamName);
        }

        [LinuxOnly]
        public void GetBashCommand_WithEmptyFileName_ShouldReturnAplay()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithNoExtension_ShouldReturnAplay()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("file");

            // Assert
            Assert.Equal("aplay -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithSpacesInPath_ShouldReturnAplay()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/my file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithUppercaseWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/file.WAV");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithMixedCaseWavExtension_ShouldReturnMpg123()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/file.WaV");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithLongPath_ShouldReturnCorrectCommand()
        {
            // Arrange
            var player = new LinuxPlayer();
            string longPath = "/very/long/path/to/a/file/that/has/many/directories/file.wav";

            // Act
            var command = player.GetBashCommand(longPath);

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithRelativePath_ShouldReturnCorrectCommand()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("./relative/path/file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithHomeDirectoryPath_ShouldReturnCorrectCommand()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("~/music/file.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithSpecialCharactersInPath_ShouldReturnCorrectCommand()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("/path/to/file-with_special.chars.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }

        [LinuxOnly]
        public void GetBashCommand_WithMultipleDotsInFilename_ShouldReturnCorrectCommand()
        {
            // Arrange
            var player = new LinuxPlayer();

            // Act
            var command = player.GetBashCommand("file.name.with.dots.wav");

            // Assert
            Assert.Equal("mpg123 -q", command);
        }
    }
}
