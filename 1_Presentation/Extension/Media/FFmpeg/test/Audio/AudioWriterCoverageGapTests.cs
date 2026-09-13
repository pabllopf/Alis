// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterCoverageGapTests.cs
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
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Tests covering validation-ordering branches, reopen cycles and
    ///     disposal semantics of <see cref="AudioWriter" /> that are not exercised
    ///     by the other AudioWriter test suites.
    /// </summary>
    public class AudioWriterCoverageGapTests : IDisposable
    {
        /// <summary>
        /// The temp dir
        /// </summary>
        private readonly string _tempDir;
        /// <summary>
        /// The fake ffmpeg path
        /// </summary>
        private readonly string _fakeFfmpegPath;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioWriterCoverageGapTests"/> class
        /// </summary>
        public AudioWriterCoverageGapTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\nwhile [ \"$1\" ]; do shift; done\nexec cat > /dev/null 2>/dev/null");

            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfmpegPath}\"");
            chmod.WaitForExit();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Directory.Exists(_tempDir))
                {
                    try
                    {
                        Directory.Delete(_tempDir, recursive: true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        ///     Verifies that the stream constructor validates channels before
        ///     checking the null destination stream.
        /// </summary>
        [Fact]
        public void StreamConstructor_InvalidChannels_TakesPrecedenceOverNullStream()
        {
            InvalidDataException exception = Assert.Throws<InvalidDataException>(() =>
                new AudioWriter((Stream) null, 0, 44100));

            Assert.Contains("Channels/Sample rate", exception.Message);
        }

        /// <summary>
        ///     Verifies that the stream constructor validates bit depth after the
        ///     channel guard but before checking the null destination stream.
        /// </summary>
        [Fact]
        public void StreamConstructor_InvalidBitDepth_TakesPrecedenceOverNullStream()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                new AudioWriter((Stream) null, 2, 44100, 8));

            Assert.Throws<InvalidOperationException>(() =>
                new AudioWriter((Stream) null, 2, 44100, 64));

            Assert.Contains("bit depths", exception.Message);
        }

        /// <summary>
        ///     Verifies that the filename constructor accepts a whitespace filename
        ///     because only null or empty names are rejected.
        /// </summary>
        [Fact]
        public void FilenameConstructor_WhitespaceFilename_IsAccepted()
        {
            using AudioWriter writer = new AudioWriter(" ", 2, 44100);

            Assert.Equal(" ", writer.Filename);
            Assert.True(writer.UseFilename);
        }

        /// <summary>
        ///     Verifies that the stream constructor creates default MP3 encoder
        ///     options when no options are supplied.
        /// </summary>
        [Fact]
        public void StreamConstructor_NullEncoderOptions_CreatesMp3Default()
        {
            using MemoryStream destination = new MemoryStream();
            using AudioWriter writer = new AudioWriter(destination, 2, 44100);

            EncoderOptions options = writer.EncoderOptions;

            Assert.NotNull(options);
            Assert.Equal("mp3", options.Format);
            Assert.Equal("libmp3lame", options.EncoderName);
        }

        /// <summary>
        ///     Verifies that writing a frame in stream mode routes data through
        ///     the input data stream and completes a close cycle.
        /// </summary>
        [RequireFfmpegFact]
        public void WriteFrame_StreamMode_WithFakeFfmpeg_ShouldWriteAndClose()
        {
            using MemoryStream destination = new MemoryStream();
            using AudioWriter writer = new AudioWriter(destination, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            using AudioFrame frame = new AudioFrame(2, 1024, 16);

            Exception writeException = Record.Exception(() => writer.WriteFrame(frame));

            Assert.Null(writeException);
            Assert.True(writer.OpenedForWriting);

            writer.CloseWrite();
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Verifies that a second CloseWrite call after a real open/close
        ///     cycle throws because the writer is no longer opened.
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_SecondCallAfterRealOpenCycle_ThrowsInvalidOperationException()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new AudioWriter(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            writer.CloseWrite();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());

            Assert.Contains("not opened for writing", exception.Message);
        }

        /// <summary>
        ///     Verifies that a writer can be reopened after a completed
        ///     open/close cycle in filename mode.
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_AfterCompletedCycle_CanReopenFilenameMode()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new AudioWriter(testFile, 2, 44100, 16, null, _fakeFfmpegPath);

            writer.OpenWrite();
            writer.CloseWrite();
            Assert.False(writer.OpenedForWriting);

            Exception reopenException = Record.Exception(() => writer.OpenWrite());

            Assert.Null(reopenException);
            Assert.True(writer.OpenedForWriting);

            writer.CloseWrite();
        }

        /// <summary>
        ///     Verifies that filename-mode CloseWrite does not create or expose an
        ///     output data stream and resets the opened state.
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_FilenameMode_OutputDataStreamRemainsNull()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new AudioWriter(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();

            writer.CloseWrite();

            Assert.Null(writer.OutputDataStream);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Verifies that Dispose with a forced opened state on a stream writer
        ///     closes the write and disposes the destination stream.
        /// </summary>
        [Fact]
        public void Dispose_StreamWriter_ForcedOpen_DisposesDestinationStream()
        {
            MemoryStream destination = new MemoryStream();
            GapTestableAudioWriter writer = new GapTestableAudioWriter(destination, 2, 44100);
            writer.ForceOpenedForWriting(true);

            writer.Dispose();

            Assert.False(writer.OpenedForWriting);
            Assert.Throws<ObjectDisposedException>(() => destination.WriteByte(0));
        }

        /// <summary>
        ///     An <see cref="AudioWriter" /> subclass exposing the protected state for testing.
        /// </summary>
        internal class GapTestableAudioWriter : AudioWriter
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GapTestableAudioWriter"/> class
            /// </summary>
            /// <param name="destinationStream">The destination stream</param>
            /// <param name="channels">The channels</param>
            /// <param name="sampleRate">The sample rate</param>
            /// <param name="bitDepth">The bit depth</param>
            /// <param name="encoderOptions">The encoder options</param>
            /// <param name="ffmpegExecutable">The ffmpeg executable</param>
            public GapTestableAudioWriter(Stream destinationStream, int channels, int sampleRate, int bitDepth = 16,
                EncoderOptions encoderOptions = null, string ffmpegExecutable = "ffmpeg")
                : base(destinationStream, channels, sampleRate, bitDepth, encoderOptions, ffmpegExecutable)
            {
            }

            /// <summary>
            ///     Forces the opened for writing state to the given value.
            /// </summary>
            /// <param name="value">Whether the writer is opened for writing</param>
            public void ForceOpenedForWriting(bool value) => OpenedForWriting = value;
        }
    }
}
