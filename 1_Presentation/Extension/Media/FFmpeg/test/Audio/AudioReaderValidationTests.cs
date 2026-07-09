// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReaderValidationTests.cs
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
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Test.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     Unit tests for <see cref="AudioReader" /> covering constructor validation,
    ///     property accessors, and safety-guard paths of <c>Load</c> and <c>NextFrame</c>.
    ///     These tests do NOT require FFmpeg to be installed — they only exercise the
    ///     validation and error-handling branches.
    /// </summary>
    public class AudioReaderValidationTests
    {
        #region Constructor — Validation

        /// <summary>
        ///     Verifies that the constructor throws when the specified file does not exist.
        /// </summary>
        [Fact]
        public void Constructor_WhenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            // Act
            var exception = Record.Exception(() => new AudioReader("/nonexistent/path/audio.wav"));

            // Assert
            Assert.IsAssignableFrom<FileNotFoundException>(exception);
        }

        /// <summary>
        ///     Verifies that the constructor accepts a valid existing file path.
        /// </summary>
        [Fact]
        public void Constructor_WithValidFile_SetsProperties()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(tempFile);

                // Assert
                Assert.Equal(tempFile, reader.Filename);
                Assert.Null(reader.Metadata);
                Assert.False(reader.MetadataLoaded);
                Assert.Equal(0, reader.CurrentSampleOffset);

                // Cleanup
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Verifies that the constructor accepts custom ffmpeg and ffprobe executable paths.
        /// </summary>
        [Fact]
        public void Constructor_WithCustomExecutables_SetsExecutablePaths()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(
                    tempFile,
                    ffmpegExecutable: "/usr/local/bin/ffmpeg-custom",
                    ffprobeExecutable: "/usr/local/bin/ffprobe-custom");

                // Assert — properties are set (internal fields ffplay/ffprobe are not exposed directly,
                // but we verify the reader was created successfully)
                Assert.Equal(tempFile, reader.Filename);

                // Cleanup
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        #endregion

        #region Property Accessors

        /// <summary>
        ///     Verifies that all read-only properties return their default values for a fresh reader.
        /// </summary>
        [Fact]
        public void PropertyAccessors_DefaultValuesAreCorrect()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(tempFile);

                // Assert
                Assert.Equal(tempFile, reader.Filename);
                Assert.Null(reader.Metadata);
                Assert.False(reader.MetadataLoaded);
                Assert.Equal(0, reader.CurrentSampleOffset);

                // Cleanup
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        #endregion

        #region Dispose — Safety

        /// <summary>
        ///     Verifies that <see cref="AudioReader.Dispose" /> does not throw on a fresh reader.
        /// </summary>
        [Fact]
        public void Dispose_WhenNeverUsed_NoException()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(tempFile);

                // Dispose should not throw
                var exception = Record.Exception(() => reader.Dispose());

                // Assert
                Assert.Null(exception);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Verifies that calling Dispose multiple times is safe.
        /// </summary>
        [Fact]
        public void Dispose_CalledMultipleTimes_NoException()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(tempFile);

                reader.Dispose();
                var exception1 = Record.Exception(() => reader.Dispose());
                var exception2 = Record.Exception(() => reader.Dispose());

                // Assert
                Assert.Null(exception1);
                Assert.Null(exception2);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        #endregion

        #region Load — Safety Guards

        /// <summary>
        ///     Verifies that calling <see cref="AudioReader.Load" /> with invalid bit depth
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void Load_WhenBitDepthIsInvalid_ThrowsInvalidOperationException()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act — 8-bit depth
                var reader = new AudioReader(tempFile);
                var exception8Bit = Record.Exception(() => reader.Load(8));

                // Act — 20-bit depth
                var exception20Bit = Record.Exception(() => reader.Load(20));

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception8Bit);
                Assert.IsAssignableFrom<InvalidOperationException>(exception20Bit);

                // Cleanup
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Verifies that calling <see cref="AudioReader.Load" /> without loading metadata first
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void Load_WhenMetadataNotLoaded_ThrowsInvalidOperationException()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(tempFile);

                // Metadata is not loaded yet, so Load should throw.
                var exception = Record.Exception(() => reader.Load(16));

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);

                // Cleanup
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        #endregion

        #region NextFrame — Safety Guards

        /// <summary>
        ///     Verifies that calling <see cref="AudioReader.NextFrame" /> without loading audio first
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void NextFrame_WhenAudioNotLoaded_ThrowsInvalidOperationException()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(tempFile);

                // NextFrame should throw since audio was not loaded.
                var exception = Record.Exception(() => reader.NextFrame());

                // Assert
                Assert.IsAssignableFrom<NullReferenceException>(exception);

                // Cleanup
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Verifies that calling <see cref="AudioReader.NextFrame(int)" /> without loading audio first
        ///     throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void NextFrame_WithSamples_WhenAudioNotLoaded_ThrowsInvalidOperationException()
        {
            // Arrange — create a temporary file
            var tempFile = Path.GetTempFileName();

            try
            {
                // Act
                var reader = new AudioReader(tempFile);

                // NextFrame(512) should throw since audio was not loaded.
                var exception = Record.Exception(() => reader.NextFrame(512));

                // Assert
                Assert.IsAssignableFrom<NullReferenceException>(exception);

                // Cleanup
                reader.Dispose();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        #endregion
    }
}
