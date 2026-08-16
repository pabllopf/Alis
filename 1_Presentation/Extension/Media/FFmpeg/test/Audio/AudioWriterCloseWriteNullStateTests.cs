// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterCloseWriteNullStateTests.cs
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

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Tests covering the null-state branches of <see cref="AudioWriter.CloseWrite()" />.
    /// </summary>
    public class AudioWriterCloseWriteNullStateTests
    {
        /// <summary>
        ///     An <see cref="AudioWriter" /> subclass exposing the protected state for testing.
        /// </summary>
        internal class TestableAudioWriter : AudioWriter
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TestableAudioWriter" /> class
            /// </summary>
            /// <param name="filename">The filename</param>
            /// <param name="channels">The channels</param>
            /// <param name="sampleRate">The sample rate</param>
            /// <param name="bitDepth">The bit depth</param>
            /// <param name="encoderOptions">The encoder options</param>
            /// <param name="ffmpegExecutable">The ffmpeg executable</param>
            public TestableAudioWriter(string filename, int channels, int sampleRate, int bitDepth = 16,
                EncoderOptions encoderOptions = null, string ffmpegExecutable = "ffmpeg")
                : base(filename, channels, sampleRate, bitDepth, encoderOptions, ffmpegExecutable)
            {
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="TestableAudioWriter" /> class
            /// </summary>
            /// <param name="destinationStream">The destination stream</param>
            /// <param name="channels">The channels</param>
            /// <param name="sampleRate">The sample rate</param>
            /// <param name="bitDepth">The bit depth</param>
            /// <param name="encoderOptions">The encoder options</param>
            /// <param name="ffmpegExecutable">The ffmpeg executable</param>
            public TestableAudioWriter(Stream destinationStream, int channels, int sampleRate, int bitDepth = 16,
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

        /// <summary>
        ///     Tests that CloseWrite with a forced opened state and null streams and process completes
        ///     and resets the opened state.
        /// </summary>
        [Fact]
        public void CloseWrite_WhenOpenedWithoutProcessOrStreams_ResetsOpenedState()
        {
            TestableAudioWriter writer = new TestableAudioWriter("output.mp3", 2, 44100);
            writer.ForceOpenedForWriting(true);
            Assert.True(writer.OpenedForWriting);

            Exception exception = Record.Exception(() => writer.CloseWrite());

            Assert.Null(exception);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that CloseWrite in stream mode with a null output data stream completes and
        ///     resets the opened state.
        /// </summary>
        [Fact]
        public void CloseWrite_StreamMode_WhenOutputDataStreamNull_ResetsOpenedState()
        {
            using MemoryStream destination = new MemoryStream();
            TestableAudioWriter writer = new TestableAudioWriter(destination, 2, 44100);
            writer.ForceOpenedForWriting(true);
            Assert.True(writer.OpenedForWriting);

            Exception exception = Record.Exception(() => writer.CloseWrite());

            Assert.Null(exception);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that Dispose with a forced opened state and null streams and process completes,
        ///     closes the write and resets the opened state.
        /// </summary>
        [Fact]
        public void Dispose_WhenOpenedWithoutProcessOrStreams_ClosesWriteAndResetsState()
        {
            TestableAudioWriter writer = new TestableAudioWriter("output.mp3", 2, 44100);
            writer.ForceOpenedForWriting(true);

            Exception exception = Record.Exception(() => writer.Dispose());

            Assert.Null(exception);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that CloseWrite can be invoked again after a forced state reset without throwing.
        /// </summary>
        [Fact]
        public void CloseWrite_AfterForcedStateReset_ThrowsWhenNotOpened()
        {
            TestableAudioWriter writer = new TestableAudioWriter("output.mp3", 2, 44100);
            writer.ForceOpenedForWriting(true);

            writer.CloseWrite();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
            Assert.Contains("not opened for writing", exception.Message);
        }
    }
}
