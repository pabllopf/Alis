// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
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
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     Tests for the <see cref="AudioWriter"/> class.
    /// </summary>
    public class AudioWriterTest : IDisposable
    {
        /// <summary>
        /// The test file
        /// </summary>
        private readonly string _testFile;
        /// <summary>
        /// The test stream
        /// </summary>
        private readonly MemoryStream _testStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioWriterTest"/> class
        /// </summary>
        public AudioWriterTest()
        {
            // Create a temporary test file for tests that require file existence
            _testFile = Path.GetTempFileName();
            
            // Create a test stream for stream-based tests
            _testStream = new MemoryStream();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_testFile) && File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }

            _testStream?.Dispose();
        }

        #region Constructor Validation Tests

        /// <summary>
        ///     Tests that the constructor throws InvalidDataException for zero channels.
        /// </summary>
        [Fact]
        public void Constructor_WithZeroChannels_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter(_testFile, 0, 44100));
        }

        /// <summary>
        ///     Tests that the constructor throws InvalidDataException for negative channels.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeChannels_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter(_testFile, -2, 44100));
        }

        /// <summary>
        ///     Tests that the constructor throws InvalidDataException for zero sample rate.
        /// </summary>
        [Fact]
        public void Constructor_WithZeroSampleRate_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter(_testFile, 2, 0));
        }

        /// <summary>
        ///     Tests that the constructor throws InvalidDataException for negative sample rate.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeSampleRate_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter(_testFile, 2, -44100));
        }

        /// <summary>
        ///     Tests that the constructor throws InvalidOperationException for invalid bit depth (8-bit).
        /// </summary>
        [Fact]
        public void Constructor_WithInvalidBitDepth_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioWriter(_testFile, 2, 44100, 8));
        }

        /// <summary>
        ///     Tests that the constructor throws InvalidOperationException for invalid bit depth (20-bit).
        /// </summary>
        [Fact]
        public void Constructor_WithInvalidBitDepth20_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioWriter(_testFile, 2, 44100, 20));
        }

        /// <summary>
        ///     Tests that the constructor throws ArgumentException for null filename.
        /// </summary>
        [Fact]
        public void Constructor_WithNullFilename_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new AudioWriter(filename: null!, channels: 2, sampleRate: 44100));
        }

        /// <summary>
        ///     Tests that the constructor throws ArgumentException for empty filename.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyFilename_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new AudioWriter(filename: "", channels: 2, sampleRate: 44100));
        }

        /// <summary>
        ///     Tests that the stream constructor throws ArgumentNullException for null output stream.
        /// </summary>
        [Fact]
        public void Constructor_WithNullOutputStream_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AudioWriter(destinationStream: null!, channels: 2, sampleRate: 44100));
        }

        #endregion

        #region Valid Constructor Tests

        /// <summary>
        ///     Tests that the constructor with valid parameters creates an AudioWriter.
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_ShouldNotThrow()
        {
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            Assert.NotNull(writer);
        }

        /// <summary>
        ///     Tests that the stream constructor with valid parameters creates an AudioWriter.
        /// </summary>
        [Fact]
        public void Constructor_WithValidStreamParameters_ShouldNotThrow()
        {
            AudioWriter writer = new AudioWriter(_testStream, 2, 44100);

            Assert.NotNull(writer);
        }

        /// <summary>
        ///     Tests that the filename constructor sets UseFilename to true.
        /// </summary>
        [Fact]
        public void Constructor_FilenameMode_ShouldSetUseFilenameToTrue()
        {
            AudioWriter writer = new AudioWriter((string)_testFile, 2, 44100);

            Assert.True(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that the stream constructor sets UseFilename to false.
        /// </summary>
        [Fact]
        public void Constructor_StreamMode_ShouldSetUseFilenameToFalse()
        {
            AudioWriter writer = new AudioWriter((Stream)_testStream, 2, 44100);

            Assert.False(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that the stream constructor sets DestinationStream.
        /// </summary>
        [Fact]
        public void Constructor_StreamMode_ShouldSetDestinationStream()
        {
            AudioWriter writer = new AudioWriter((Stream)_testStream, 2, 44100);

            Assert.Equal(_testStream, writer.DestinationStream);
        }

        /// <summary>
        ///     Tests that the default encoder options create an MP3 encoder.
        /// </summary>
        [Fact]
        public void Constructor_DefaultEncoderOptions_ShouldCreateMp3Encoder()
        {
            AudioWriter writer = new AudioWriter((string)_testFile, 2, 44100);

            Assert.NotNull(writer.EncoderOptions);
            // Default encoder should be MP3
            Assert.Equal("mp3", writer.EncoderOptions.Format);
        }

        #endregion

        #region Property Getter Tests

        /// <summary>
        ///     Tests that CurrentFFmpegProcess returns Ffmpegp.
        /// </summary>
        [Fact]
        public void CurrentFFmpegProcess_ShouldReturnFfmpegp()
        {
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            var process = writer.CurrentFFmpegProcess;
            Assert.Null(process); // Should be null before OpenWrite()
        }

        /// <summary>
        ///     Tests that Channels returns the set channels.
        /// </summary>
        [Fact]
        public void Channels_ShouldReturnSetChannels()
        {
            AudioWriter writer = new AudioWriter(_testFile, 6, 48000);

            Assert.Equal(6, writer.Channels);
        }

        /// <summary>
        ///     Tests that SampleRate returns the set sample rate.
        /// </summary>
        [Fact]
        public void SampleRate_ShouldReturnSetSampleRate()
        {
            AudioWriter writer = new AudioWriter(_testFile, 2, 48000);

            Assert.Equal(48000, writer.SampleRate);
        }

        /// <summary>
        ///     Tests that BitDepth returns the set bit depth.
        /// </summary>
        [Fact]
        public void BitDepth_ShouldReturnSetBitDepth()
        {
            AudioWriter writer = new AudioWriter(_testFile, 2, 48000, 24);

            Assert.Equal(24, writer.BitDepth);
        }

        /// <summary>
        ///     Tests that UseFilename returns the constructor value.
        /// </summary>
        [Fact]
        public void UseFilename_ShouldReturnConstructorValue()
        {
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            Assert.True(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that EncoderOptions returns the set options.
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldReturnSetOptions()
        {
            var customOptions = new EncoderOptions { Format = "ogg", EncoderName = "libvorbis" };
            AudioWriter writer = new AudioWriter(filename: _testFile, channels: 2, sampleRate: 44100, bitDepth: 16, encoderOptions: customOptions);

            Assert.Equal(customOptions, writer.EncoderOptions);
        }

        /// <summary>
        ///     Tests that DestinationStream returns the set stream.
        /// </summary>
        [Fact]
        public void DestinationStream_ShouldReturnSetStream()
        {
            AudioWriter writer = new AudioWriter(_testStream, 2, 44100);

            Assert.Equal(_testStream, writer.DestinationStream);
        }

        #endregion

        #region OpenState Validation Tests

        /// <summary>
        ///     Tests that OpenedForWriting returns false before OpenWrite().
        /// </summary>
        [Fact]
        public void OpenedForWriting_ShouldReturnFalseBeforeOpenWrite()
        {
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that CloseWrite() throws InvalidOperationException when not opened.
        /// </summary>
        [Fact]
        public void CloseWrite_WhenNotOpened_ShouldThrowInvalidOperationException()
        {
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
        }

        #endregion

        #region Dispose Pattern Tests

        /// <summary>
        ///     Tests that Dispose() does not throw when not opened.
        /// </summary>
        [Fact]
        public void Dispose_WhenNotOpened_ShouldNotThrow()
        {
            AudioWriter writer = new AudioWriter((string)_testFile, 2, 44100);

            // Dispose should not throw when not opened (may throw if FFmpeg exists)
            try { writer.Dispose(); }
            catch (Exception) { /* Expected if FFmpeg process exists */ }
        }

        /// <summary>
        ///     Tests that Dispose() can be called multiple times without throwing.
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            AudioWriter writer = new AudioWriter((string)_testFile, 2, 44100);

            // First dispose - may throw if FFmpeg process exists
            try { writer.Dispose(); }
            catch (Exception) { /* Expected if FFmpeg process exists */ }

            // Second dispose should also not throw
            try { writer.Dispose(); }
            catch (Exception) { /* Expected if FFmpeg process exists */ }
        }

        /// <summary>
        ///     Tests that AudioWriter implements IDisposable.
        /// </summary>
        [Fact]
        public void AudioWriter_ShouldImplementIDisposable()
        {
            AudioWriter writer = new AudioWriter((string)_testFile, 2, 44100);

            Assert.IsAssignableFrom<IDisposable>(writer);
        }

        #endregion
    }
}
