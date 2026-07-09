// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterValidationTests.cs
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
using Alis.Extension.Media.FFmpeg.Encoding;
using Xunit;

namespace Alis.Test.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     Unit tests for <see cref="AudioWriter" /> covering constructor validation,
    ///     property accessors, and safety-guard paths of <c>OpenWrite</c>, <c>CloseWrite</c>,
    ///     and <c>Dispose</c>.  These tests do NOT require FFmpeg to be installed —
    ///     they only exercise the validation and error-handling branches.
    /// </summary>
    public class AudioWriterValidationTests
    {
        #region Filename Constructor — Validation

        /// <summary>
        ///     Verifies that the filename constructor throws when channels is zero.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WhenChannelsIsZero_ThrowsInvalidDataException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                "output.mp3",
                channels: 0,
                sampleRate: 44100));

            // Assert
            Assert.IsAssignableFrom<InvalidDataException>(exception);
        }

        /// <summary>
        ///     Verifies that the filename constructor throws when channels is negative.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WhenChannelsIsNegative_ThrowsInvalidDataException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                "output.mp3",
                channels: -1,
                sampleRate: 44100));

            // Assert
            Assert.IsAssignableFrom<InvalidDataException>(exception);
        }

        /// <summary>
        ///     Verifies that the filename constructor throws when sample rate is zero.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WhenSampleRateIsZero_ThrowsInvalidDataException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                "output.mp3",
                channels: 2,
                sampleRate: 0));

            // Assert
            Assert.IsAssignableFrom<InvalidDataException>(exception);
        }

        /// <summary>
        ///     Verifies that the filename constructor throws when sample rate is negative.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WhenSampleRateIsNegative_ThrowsInvalidDataException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                "output.mp3",
                channels: 2,
                sampleRate: -44100));

            // Assert
            Assert.IsAssignableFrom<InvalidDataException>(exception);
        }

        /// <summary>
        ///     Verifies that the filename constructor throws when bit depth is not 16, 24, or 32.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WhenBitDepthIsInvalid_ThrowsInvalidOperationException()
        {
            // Act — 8-bit depth
            var exception8Bit = Record.Exception(() => new AudioWriter(
                "output.mp3",
                channels: 2,
                sampleRate: 44100,
                bitDepth: 8));

            // Act — 20-bit depth
            var exception20Bit = Record.Exception(() => new AudioWriter(
                "output.mp3",
                channels: 2,
                sampleRate: 44100,
                bitDepth: 20));

            // Act — 80-bit depth
            var exception80Bit = Record.Exception(() => new AudioWriter(
                "output.mp3",
                channels: 2,
                sampleRate: 44100,
                bitDepth: 80));

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception8Bit);
            Assert.IsAssignableFrom<InvalidOperationException>(exception20Bit);
            Assert.IsAssignableFrom<InvalidOperationException>(exception80Bit);
        }

        /// <summary>
        ///     Verifies that the filename constructor throws when filename is null or empty.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WhenFilenameIsNullOrEmpty_ThrowsArgumentException()
        {
            // Act — null filename
            var exceptionNull = Record.Exception(() => new AudioWriter(
                (string) null,
                channels: 2,
                sampleRate: 44100));

            // Act — empty filename
            var exceptionEmpty = Record.Exception(() => new AudioWriter(
                "",
                channels: 2,
                sampleRate: 44100));

            // Assert
            Assert.IsAssignableFrom<ArgumentException>(exceptionNull);
            Assert.IsAssignableFrom<ArgumentException>(exceptionEmpty);
        }

        /// <summary>
        ///     Verifies that the filename constructor accepts valid 16, 24, and 32 bit depths.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WithValidBitDepths_Succeeds()
        {
            // Act — 16-bit (default)
            var writer16 = new AudioWriter("output.mp3", 2, 44100);

            // Act — 24-bit
            var writer24 = new AudioWriter("output.wav", 1, 22050, 24);

            // Act — 32-bit
            var writer32 = new AudioWriter("output.raw", 4, 96000, 32);

            // Assert
            Assert.NotNull(writer16);
            Assert.NotNull(writer24);
            Assert.NotNull(writer32);

            // Verify 16-bit writer
            Assert.True(writer16.UseFilename);
            Assert.Equal("output.mp3", writer16.Filename);
            Assert.Equal(2, writer16.Channels);
            Assert.Equal(44100, writer16.SampleRate);
            Assert.Equal(16, writer16.BitDepth);

            // Verify 24-bit writer
            Assert.True(writer24.UseFilename);
            Assert.Equal("output.wav", writer24.Filename);
            Assert.Equal(1, writer24.Channels);
            Assert.Equal(22050, writer24.SampleRate);
            Assert.Equal(24, writer24.BitDepth);

            // Verify 32-bit writer
            Assert.True(writer32.UseFilename);
            Assert.Equal("output.raw", writer32.Filename);
            Assert.Equal(4, writer32.Channels);
            Assert.Equal(96000, writer32.SampleRate);
            Assert.Equal(32, writer32.BitDepth);

            // Cleanup
            writer16.Dispose();
            writer24.Dispose();
            writer32.Dispose();
        }

        /// <summary>
        ///     Verifies that the filename constructor accepts a custom FFmpeg executable path.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WithCustomFfmpegPath_SetsFfmpegExecutable()
        {
            // Act
            var writer = new AudioWriter(
                "output.mp3", 2, 44100, 16, null,
                ffmpegExecutable: "/usr/local/bin/ffmpeg-custom");

            // Assert — CurrentFFmpegProcess is null because we haven't started it.
            Assert.Null(writer.CurrentFFmpegProcess);
            Assert.True(writer.UseFilename);

            // Cleanup
            writer.Dispose();
        }

        /// <summary>
        ///     Verifies that the filename constructor creates default EncoderOptions when none provided.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WithNullEncoderOptions_CreatesDefaultEncoderOptions()
        {
            // Act
            var writer = new AudioWriter("output.mp3", 2, 44100);

            // Assert — default encoder options are created via Mp3Encoder
            Assert.NotNull(writer.EncoderOptions);

            // Cleanup
            writer.Dispose();
        }

        /// <summary>
        ///     Verifies that the filename constructor accepts custom EncoderOptions.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WithCustomEncoderOptions_UsesProvidedOptions()
        {
            // Arrange
            var customOptions = new EncoderOptions
            {
                Format = "flac",
                EncoderName = "flac",
                EncoderArguments = "-compression_level 6"
            };

            // Act
            var writer = new AudioWriter(
                "output.flac", 2, 48000, 24,
                encoderOptions: customOptions);

            // Assert
            Assert.Equal("flac", writer.EncoderOptions.Format);
            Assert.Equal("flac", writer.EncoderOptions.EncoderName);
            Assert.Equal("-compression_level 6", writer.EncoderOptions.EncoderArguments);

            // Cleanup
            writer.Dispose();
        }

        #endregion

        #region Stream Constructor — Validation

        /// <summary>
        ///     Verifies that the stream constructor throws when the destination stream is null.
        /// </summary>
        [Fact]
        public void StreamConstructor_WhenStreamIsNull_ThrowsArgumentNullException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                (Stream) null,
                channels: 2,
                sampleRate: 44100));

            // Assert
            Assert.IsAssignableFrom<ArgumentNullException>(exception);
        }

        /// <summary>
        ///     Verifies that the stream constructor throws when channels is zero.
        /// </summary>
        [Fact]
        public void StreamConstructor_WhenChannelsIsZero_ThrowsInvalidDataException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                new MemoryStream(),
                channels: 0,
                sampleRate: 44100));

            // Assert
            Assert.IsAssignableFrom<InvalidDataException>(exception);
        }

        /// <summary>
        ///     Verifies that the stream constructor throws when sample rate is zero.
        /// </summary>
        [Fact]
        public void StreamConstructor_WhenSampleRateIsZero_ThrowsInvalidDataException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                new MemoryStream(),
                channels: 2,
                sampleRate: 0));

            // Assert
            Assert.IsAssignableFrom<InvalidDataException>(exception);
        }

        /// <summary>
        ///     Verifies that the stream constructor throws when bit depth is invalid.
        /// </summary>
        [Fact]
        public void StreamConstructor_WhenBitDepthIsInvalid_ThrowsInvalidOperationException()
        {
            // Act
            var exception = Record.Exception(() => new AudioWriter(
                new MemoryStream(),
                channels: 2,
                sampleRate: 44100,
                bitDepth: 8));

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception);
        }

        /// <summary>
        ///     Verifies that the stream constructor accepts valid parameters and sets UseFilename to false.
        /// </summary>
        [Fact]
        public void StreamConstructor_WithValidParameters_SetsUseFilenameFalse()
        {
            // Act
            var writer = new AudioWriter(
                new MemoryStream(), 2, 44100, 16);

            // Assert
            Assert.False(writer.UseFilename);
            Assert.NotNull(writer.DestinationStream);
            Assert.Equal(2, writer.Channels);
            Assert.Equal(44100, writer.SampleRate);
            Assert.Equal(16, writer.BitDepth);
            Assert.Null(writer.CurrentFFmpegProcess);

            // Cleanup
            writer.Dispose();
        }

        /// <summary>
        ///     Verifies that the stream constructor accepts custom EncoderOptions.
        /// </summary>
        [Fact]
        public void StreamConstructor_WithCustomEncoderOptions_UsesProvidedOptions()
        {
            // Arrange
            var customOptions = new EncoderOptions
            {
                Format = "ogg",
                EncoderName = "libvorbis",
                EncoderArguments = "-q 5"
            };

            // Act
            var writer = new AudioWriter(
                new MemoryStream(), 1, 22050, 24,
                encoderOptions: customOptions);

            // Assert
            Assert.Equal("ogg", writer.EncoderOptions.Format);
            Assert.Equal("libvorbis", writer.EncoderOptions.EncoderName);
            Assert.Equal("-q 5", writer.EncoderOptions.EncoderArguments);

            // Cleanup
            writer.Dispose();
        }

        #endregion

        #region Property Accessors

        /// <summary>
        ///     Verifies that all read-only properties return the values set by the constructor.
        /// </summary>
        [Fact]
        public void PropertyAccessors_AllPropertiesReturnConstructorValues()
        {
            // Arrange
            var customOptions = new EncoderOptions
            {
                Format = "mp3",
                EncoderName = "libmp3lame",
                EncoderArguments = "-b:a 192k"
            };

            // Act — filename constructor
            var fileWriter = new AudioWriter(
                "output.mp3", 2, 48000, 24, customOptions);

            // Act — stream constructor
            var streamWriter = new AudioWriter(
                new MemoryStream(), 1, 96000, 32, customOptions);

            // Assert — file writer properties
            Assert.Equal("output.mp3", fileWriter.Filename);
            Assert.True(fileWriter.UseFilename);
            Assert.Equal(2, fileWriter.Channels);
            Assert.Equal(48000, fileWriter.SampleRate);
            Assert.Equal(24, fileWriter.BitDepth);
            Assert.Equal("mp3", fileWriter.EncoderOptions.Format);
            Assert.Equal("libmp3lame", fileWriter.EncoderOptions.EncoderName);
            Assert.Equal("-b:a 192k", fileWriter.EncoderOptions.EncoderArguments);

            // Assert — stream writer properties
            Assert.False(streamWriter.UseFilename);
            Assert.Equal(1, streamWriter.Channels);
            Assert.Equal(96000, streamWriter.SampleRate);
            Assert.Equal(32, streamWriter.BitDepth);

            // Assert — common properties (null when not started)
            Assert.Null(fileWriter.CurrentFFmpegProcess);
            Assert.Null(streamWriter.CurrentFFmpegProcess);
            Assert.Null(fileWriter.InputDataStream);
            Assert.Null(streamWriter.InputDataStream);
            Assert.Null(fileWriter.OutputDataStream);
            Assert.Null(streamWriter.OutputDataStream);
            Assert.False(fileWriter.OpenedForWriting);
            Assert.False(streamWriter.OpenedForWriting);

            // Cleanup
            fileWriter.Dispose();
            streamWriter.Dispose();
        }

        /// <summary>
        ///     Verifies that the DestinationStream property returns the provided stream for stream-based writers.
        /// </summary>
        [Fact]
        public void StreamConstructor_DestinationStreamProperty_ReturnsProvidedStream()
        {
            // Arrange
            var expectedStream = new MemoryStream();

            // Act
            var writer = new AudioWriter(
                expectedStream, 2, 44100);

            // Assert
            Assert.Same(expectedStream, writer.DestinationStream);

            // Cleanup
            writer.Dispose();
        }

        #endregion

        #region OpenWrite — Safety Guards

        /// <summary>
        ///     Verifies that the OpenedForWriting property defaults to false for both constructors.
        /// </summary>
        [Fact]
        public void OpenedForWriting_DefaultValue_IsFalse()
        {
            // Arrange
            var fileWriter = new AudioWriter("output.mp3", 2, 44100);
            var streamWriter = new AudioWriter(new MemoryStream(), 2, 44100);

            // Assert
            Assert.False(fileWriter.OpenedForWriting);
            Assert.False(streamWriter.OpenedForWriting);

            // Cleanup
            fileWriter.Dispose();
            streamWriter.Dispose();
        }

        /// <summary>
        ///     Verifies that calling OpenWrite when not properly configured (e.g., missing filename)
        ///     would fail — but we verify the property state instead since we can't call OpenWrite
        ///     without FFmpeg.
        /// </summary>
        [Fact]
        public void OpenWrite_WhenNotOpenedForWriting_PropertStateIsFalse()
        {
            // Arrange
            var writer = new AudioWriter("output.mp3", 2, 44100);

            // Assert
            Assert.False(writer.OpenedForWriting);
            Assert.Null(writer.InputDataStream);
            Assert.Null(writer.OutputDataStream);

            // Cleanup
            writer.Dispose();
        }

        #endregion

        #region CloseWrite — Safety Guards

        /// <summary>
        ///     Verifies that calling <see cref="AudioWriter.CloseWrite" /> when not opened
        ///     for writing throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void CloseWrite_WhenNotOpenedForWriting_ThrowsInvalidOperationException()
        {
            // Arrange
            var writer = new AudioWriter("output.mp3", 2, 44100);

            // Act
            var exception = Record.Exception(() => writer.CloseWrite());

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception);

            // Cleanup
            writer.Dispose();
        }

        /// <summary>
        ///     Verifies that CloseWrite throws for stream-based writers too when not opened.
        /// </summary>
        [Fact]
        public void CloseWrite_StreamBased_WhenNotOpenedForWriting_ThrowsInvalidOperationException()
        {
            // Arrange
            var writer = new AudioWriter(new MemoryStream(), 2, 44100);

            // Act
            var exception = Record.Exception(() => writer.CloseWrite());

            // Assert
            Assert.IsAssignableFrom<InvalidOperationException>(exception);

            // Cleanup
            writer.Dispose();
        }

        #endregion

        #region Dispose — Safety

        /// <summary>
        ///     Verifies that <see cref="AudioWriter.Dispose" /> can be called without throwing
        ///     on a writer that was never opened or started.
        /// </summary>
        [Fact]
        public void Dispose_WhenNeverOpened_NoException()
        {
            // Arrange
            var writer = new AudioWriter("output.mp3", 2, 44100);

            // Act — Dispose should not throw
            var exception = Record.Exception(() => writer.Dispose());

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that the stream-based writer's Dispose does not throw.
        /// </summary>
        [Fact]
        public void Dispose_StreamBased_NoException()
        {
            // Arrange
            var writer = new AudioWriter(new MemoryStream(), 2, 44100);

            // Act
            var exception = Record.Exception(() => writer.Dispose());

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that calling Dispose multiple times is safe.
        /// </summary>
        [Fact]
        public void Dispose_CalledMultipleTimes_NoException()
        {
            // Arrange
            var writer = new AudioWriter("output.mp3", 2, 44100);

            // Act — multiple disposals
            writer.Dispose();
            var exception1 = Record.Exception(() => writer.Dispose());
            var exception2 = Record.Exception(() => writer.Dispose());

            // Assert
            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        /// <summary>
        ///     Verifies that a stream-based writer's Dispose does not throw on multiple calls.
        /// </summary>
        [Fact]
        public void Dispose_StreamBased_MultipleCalls_NoException()
        {
            // Arrange
            var writer = new AudioWriter(new MemoryStream(), 2, 44100);

            // Act — multiple disposals
            writer.Dispose();
            var exception1 = Record.Exception(() => writer.Dispose());
            var exception2 = Record.Exception(() => writer.Dispose());

            // Assert
            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        #endregion
    }
}
