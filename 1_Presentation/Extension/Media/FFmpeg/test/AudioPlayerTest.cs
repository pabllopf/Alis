// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerTest.cs
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
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Audio.Test
{
    /// <summary>
    ///     The audio player test class
    /// </summary>
    public class AudioPlayerTest
    {
        /// <summary>
        ///     Tests that the default constructor initializes ffplay with the default executable name
        /// </summary>
        [Fact]
        public void AudioPlayer_DefaultConstructor_ShouldSetDefaultFfplay()
        {
            // Arrange & Act
            using AudioPlayer player = new();

            // Assert - no exception means default initialization succeeded
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that the constructor accepts a custom ffplay executable path
        /// </summary>
        [Fact]
        public void AudioPlayer_CustomFfplay_ShouldAcceptCustomPath()
        {
            // Arrange & Act
            using AudioPlayer player = new(null, "custom_ffplay");

            // Assert - no exception means initialization succeeded
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that the constructor accepts an input filename
        /// </summary>
        [Fact]
        public void AudioPlayer_WithFilename_ShouldAcceptInputPath()
        {
            // Arrange & Act
            using AudioPlayer player = new("/path/to/audio.wav");

            // Assert - no exception means initialization succeeded
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that the constructor accepts both filename and custom ffplay path
        /// </summary>
        [Fact]
        public void AudioPlayer_FullConstructor_ShouldAcceptAllParameters()
        {
            // Arrange & Act
            using AudioPlayer player = new("/path/to/audio.wav", "custom_ffplay");

            // Assert - no exception means initialization succeeded
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that Dispose does not throw when called on a fresh instance
        /// </summary>
        [Fact]
        public void AudioPlayer_Dispose_ShouldNotThrowOnFreshInstance()
        {
            // Arrange
            AudioPlayer player = new("/path/to/audio.wav");

            // Act
            bool threw = false;
            try
            {
                player.Dispose();
            }
            catch
            {
                threw = true;
            }

            // Assert
            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times without throwing
        /// </summary>
        [Fact]
        public void AudioPlayer_MultipleDispose_ShouldNotThrow()
        {
            // Arrange
            AudioPlayer player = new("/path/to/audio.wav");

            // Act
            bool threw = false;
            try
            {
                player.Dispose();
                player.Dispose();
                player.Dispose();
            }
            catch
            {
                threw = true;
            }

            // Assert
            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that Dispose on default-constructed player does not throw
        /// </summary>
        [Fact]
        public void AudioPlayer_DisposeDefaultConstructed_ShouldNotThrow()
        {
            // Arrange
            AudioPlayer player = new();

            // Act
            bool threw = false;
            try
            {
                player.Dispose();
            }
            catch
            {
                threw = true;
            }

            // Assert
            Assert.False(threw);
        }

        /// <summary>
        ///     Tests that Play throws when no filename is specified
        /// </summary>
        [Fact]
        public void AudioPlayer_PlayWithoutFilename_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => player.Play());
        }

        /// <summary>
        ///     Tests that Play throws with empty string filename
        /// </summary>
        [Fact]
        public void AudioPlayer_PlayWithEmptyFilename_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new(string.Empty);

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => player.Play());

            // Assert
            Assert.Contains("filename", exception.Message.ToLowerInvariant());
        }

        /// <summary>
        ///     Tests that Play with null filename throws
        /// </summary>
        [Fact]
        public void AudioPlayer_PlayWithNullFilename_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new(null);

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => player.Play());

            // Assert
            Assert.Contains("filename", exception.Message.ToLowerInvariant());
        }

        /// <summary>
        ///     Tests that OpenWrite throws for invalid bit depth 8
        /// </summary>
        [Fact]
        public void AudioPlayer_OpenWriteWithBitDepth8_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new("/path/to/audio.wav");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(44100, 2, 8));

            // Assert
            Assert.Contains("bit depth", exception.Message);
        }

        /// <summary>
        ///     Tests that OpenWrite throws for invalid bit depth 64
        /// </summary>
        [Fact]
        public void AudioPlayer_OpenWriteWithBitDepth64_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new("/path/to/audio.wav");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(44100, 2, 64));

            // Assert
            Assert.Contains("bit depth", exception.Message);
        }

        /// <summary>
        ///     Tests that OpenWrite throws for invalid bit depth 0
        /// </summary>
        [Fact]
        public void AudioPlayer_OpenWriteWithBitDepthZero_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new("/path/to/audio.wav");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(44100, 2, 0));

            // Assert
            Assert.Contains("bit depth", exception.Message);
        }

        /// <summary>
        ///     Tests that OpenWrite throws for negative bit depth
        /// </summary>
        [Fact]
        public void AudioPlayer_OpenWriteWithNegativeBitDepth_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new("/path/to/audio.wav");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(44100, 2, -16));

            // Assert
            Assert.Contains("bit depth", exception.Message);
        }

        /// <summary>
        ///     Tests that CloseWrite throws when not opened for writing
        /// </summary>
        [Fact]
        public void AudioPlayer_CloseWriteNotOpened_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new("/path/to/audio.wav");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.CloseWrite());

            // Assert
            Assert.Contains("not opened", exception.Message);
        }

        /// <summary>
        ///     Tests that PlayInBackground throws when no filename is specified
        /// </summary>
        [Fact]
        public void AudioPlayer_PlayInBackgroundWithoutFilename_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new();

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.PlayInBackground());

            // Assert
            Assert.Contains("filename", exception.Message.ToLowerInvariant());
        }

        /// <summary>
        ///     Tests that Play with extra parameters still validates filename first
        /// </summary>
        [Fact]
        public void AudioPlayer_PlayWithExtraParamsNoFilename_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new();

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.Play("-probesize 32"));

            // Assert
            Assert.Contains("filename", exception.Message.ToLowerInvariant());
        }

        /// <summary>
        ///     Tests that PlayInBackground with extra parameters still validates filename first
        /// </summary>
        [Fact]
        public void AudioPlayer_PlayInBackgroundWithExtraParamsNoFilename_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new();

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.PlayInBackground("-probesize 32"));

            // Assert
            Assert.Contains("filename", exception.Message.ToLowerInvariant());
        }

        /// <summary>
        ///     Tests that OpenWrite throws for bit depth 17 (not in allowed set)
        /// </summary>
        [Fact]
        public void AudioPlayer_OpenWriteWithBitDepth17_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new("/path/to/audio.wav");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(44100, 2, 17));

            // Assert
            Assert.Contains("bit depth", exception.Message);
        }

        /// <summary>
        ///     Tests that OpenWrite throws for bit depth 48 (not in allowed set)
        /// </summary>
        [Fact]
        public void AudioPlayer_OpenWriteWithBitDepth48_ShouldThrowInvalidOperationException()
        {
            // Arrange
            using AudioPlayer player = new("/path/to/audio.wav");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(44100, 2, 48));

            // Assert
            Assert.Contains("bit depth", exception.Message);
        }
    }
}
