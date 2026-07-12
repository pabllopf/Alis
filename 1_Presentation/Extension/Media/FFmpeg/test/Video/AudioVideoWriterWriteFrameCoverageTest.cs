// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterWriteFrameCoverageTest.cs
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
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     Tests covering the remaining uncovered execution paths in
    ///     <see cref="AudioVideoWriter" />: <c>WriteFrame(AudioFrame)</c> happy path,
    ///     <c>CloseWrite</c> with opened state, and <c>Dispose</c> triggering <c>CloseWrite</c>.
    /// </summary>
    public class AudioVideoWriterWriteFrameCoverageTest
    {
        #region WriteFrame(AudioFrame) Happy Path

        /// <summary>
        ///     Verifies that <see cref="AudioVideoWriter.WriteFrame(AudioFrame)" /> writes
        ///     frame raw data to <see cref="AudioVideoWriter.InputDataStreamAudio" /> when the
        ///     writer is opened. Uses a connected socket pair to create a real
        ///     <see cref="NetworkStream" />, then sets it via reflection to simulate the
        ///     state that <see cref="AudioVideoWriter.OpenWrite" /> normally establishes.
        /// </summary>
        [Fact]
        public void WriteFrame_Audio_WhenOpened_WritesRawDataToInputDataStreamAudio()
        {
            // Arrange
            using MemoryStream destStream = new();
            AudioVideoWriter writer = new(destStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            using Socket listenSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            listenSocket.Listen(1);

            using Socket clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, ((IPEndPoint)listenSocket.LocalEndPoint).Port));
            using Socket acceptedSocket = listenSocket.Accept();

            using NetworkStream audioStream = new NetworkStream(acceptedSocket);

            try
            {
                FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                openedField.SetValue(writer, true);

                FieldInfo inputAudioField = typeof(AudioVideoWriter).GetField("<InputDataStreamAudio>k__BackingField",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                inputAudioField.SetValue(writer, audioStream);

                AudioFrame frame = new(2, 1024, 16);
                byte[] expectedData = frame.RawData;

                // Act
                writer.WriteFrame(frame);

                // Assert — verify data arrived on the receiving end
                byte[] buffer = new byte[expectedData.Length];
                int read = clientSocket.Receive(buffer);
                Assert.Equal(expectedData.Length, read);
                Assert.Equal(expectedData, buffer);
            }
            finally
            {
                FieldInfo resetField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                resetField.SetValue(writer, false);
                writer.Dispose();
            }
        }

        #endregion

        #region CloseWrite With Opened State

        /// <summary>
        ///     Verifies that <see cref="AudioVideoWriter.CloseWrite" /> enters the try block
        ///     when <c>OpenedForWriting</c> is <c>true</c>, executes null-conditional disposes
        ///     on streams and sockets, and handles null <c>Ffmpegp</c> gracefully. The
        ///     finally block still sets <c>OpenedForWriting = false</c>.
        /// </summary>
        [Fact]
        public void CloseWrite_WhenOpenedWithNullFfmpegp_CompletesGracefullyAndResetsFlag()
        {
            // Arrange
            using MemoryStream destStream = new();
            AudioVideoWriter writer = new(destStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            // Ffmpegp is null by default; CloseWrite now handles this gracefully
            // Act
            Exception exception = Record.Exception(() => writer.CloseWrite());

            // Assert — no exception thrown, and finally block still runs
            Assert.Null(exception);
            Assert.False(writer.OpenedForWriting);
        }

        #endregion

        #region Dispose Triggering CloseWrite

        /// <summary>
        ///     Verifies that <see cref="AudioVideoWriter.Dispose" /> enters the
        ///     <c>OpenedForWriting</c> branch when the writer is opened, which calls
        ///     <see cref="AudioVideoWriter.CloseWrite" />. CloseWrite handles null
        ///     <c>Ffmpegp</c> gracefully and resets <c>OpenedForWriting</c>.
        /// </summary>
        [Fact]
        public void Dispose_WhenOpenedForWriting_CallsCloseWrite()
        {
            // Arrange
            using MemoryStream destStream = new();
            AudioVideoWriter writer = new(destStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            // Act — Dispose calls Dispose(true) which checks OpenedForWriting, calls CloseWrite
            Exception exception = Record.Exception(() => writer.Dispose());

            // Assert — CloseWrite handles null Ffmpegp gracefully, OpenedForWriting is reset
            Assert.Null(exception);
            Assert.False(writer.OpenedForWriting);
        }

        #endregion
    }
}
