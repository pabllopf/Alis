// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaReaderCoverageGapTests.cs
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
using System.Text;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The media reader coverage gap tests class
    /// </summary>
    public class MediaReaderCoverageGapTests
    {
        /// <summary>
        ///     The test frame class
        /// </summary>
        /// <seealso cref="IMediaFrame" />
        internal sealed class TestFrame : IMediaFrame
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TestFrame" /> class
            /// </summary>
            /// <param name="rawData">The raw data</param>
            public TestFrame(byte[] rawData) => RawData = rawData;

            /// <summary>
            ///     Gets the value of the raw data
            /// </summary>
            public byte[] RawData { get; }

            /// <summary>
            ///     Loads the stream
            /// </summary>
            /// <param name="stream">The stream</param>
            /// <returns>The bool</returns>
            public bool Load(Stream stream) => true;
        }

        /// <summary>
        ///     The test writer class
        /// </summary>
        /// <seealso cref="MediaWriter{TestFrame}" />
        internal sealed class TestWriter : MediaWriter<TestFrame>
        {
            /// <summary>
            ///     Sets the opened using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetOpened(bool value) => OpenedForWriting = value;

            /// <summary>
            ///     Sets the stream using the specified stream
            /// </summary>
            /// <param name="stream">The stream</param>
            public void SetStream(Stream stream) => InputDataStream = stream;
        }

        /// <summary>
        ///     The test reader class
        /// </summary>
        /// <seealso cref="MediaReader{TestFrame, TestWriter}" />
        internal sealed class TestReader : MediaReader<TestFrame, TestWriter>
        {
            /// <summary>
            ///     Sets the stream using the specified stream
            /// </summary>
            /// <param name="stream">The stream</param>
            public void SetStream(Stream stream) => DataStream = stream;

            /// <summary>
            ///     Sets the opened using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetOpened(bool value) => OpenedForReading = value;

            /// <summary>
            ///     Nexts the frame
            /// </summary>
            /// <returns>The test frame</returns>
            public override TestFrame NextFrame() => null;

            /// <summary>
            ///     Nexts the frame using the specified frame
            /// </summary>
            /// <param name="frame">The frame</param>
            /// <returns>The test frame</returns>
            public override TestFrame NextFrame(TestFrame frame) => null;
        }

        /// <summary>
        ///     Tests that copy to should throw when data stream is null
        /// </summary>
        [Fact]
        public void CopyTo_NullDataStream_ThrowsInvalidOperationException()
        {
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            writer.SetOpened(true);
            writer.SetStream(new MemoryStream());

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(writer));

            Assert.Contains("Reader is not opened for reading", exception.Message);
        }

        /// <summary>
        ///     Tests that copy to should throw when writer is not opened for writing
        /// </summary>
        [Fact]
        public void CopyTo_WriterNotOpened_ThrowsInvalidOperationException()
        {
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            reader.SetStream(new MemoryStream(System.Text.Encoding.UTF8.GetBytes("payload")));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(writer));

            Assert.Contains("Writer is not opened for writing", exception.Message);
        }

        /// <summary>
        ///     Tests that copy to should copy the data stream into the writer stream
        /// </summary>
        [Fact]
        public void CopyTo_OpenedReaderAndWriter_CopiesPayload()
        {
            byte[] payload = System.Text.Encoding.UTF8.GetBytes("copy-payload");
            MemoryStream source = new MemoryStream(payload);
            MemoryStream destination = new MemoryStream();
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            reader.SetStream(source);
            reader.SetOpened(true);
            writer.SetStream(destination);
            writer.SetOpened(true);

            reader.CopyTo(writer);

            Assert.Equal(payload, destination.ToArray());
        }

        /// <summary>
        ///     Tests that copy to async should throw when data stream is null
        /// </summary>
        [Fact]
        public async Task CopyToAsync_NullDataStream_ThrowsInvalidOperationException()
        {
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            writer.SetOpened(true);
            writer.SetStream(new MemoryStream());

            InvalidOperationException exception = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.CopyToAsync(writer));

            Assert.Contains("Reader is not opened for reading", exception.Message);
        }

        /// <summary>
        ///     Tests that copy to async should throw when writer is not opened for writing
        /// </summary>
        [Fact]
        public async Task CopyToAsync_WriterNotOpened_ThrowsInvalidOperationException()
        {
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            reader.SetStream(new MemoryStream(System.Text.Encoding.UTF8.GetBytes("payload")));

            InvalidOperationException exception = await Assert.ThrowsAsync<InvalidOperationException>(() => reader.CopyToAsync(writer));

            Assert.Contains("Writer is not opened for writing", exception.Message);
        }

        /// <summary>
        ///     Tests that copy to async should copy the data stream into the writer stream
        /// </summary>
        [Fact]
        public async Task CopyToAsync_OpenedReaderAndWriter_CopiesPayload()
        {
            byte[] payload = System.Text.Encoding.UTF8.GetBytes("copy-async-payload");
            MemoryStream source = new MemoryStream(payload);
            MemoryStream destination = new MemoryStream();
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            reader.SetStream(source);
            reader.SetOpened(true);
            writer.SetStream(destination);
            writer.SetOpened(true);

            await reader.CopyToAsync(writer);

            Assert.Equal(payload, destination.ToArray());
        }
    }
}
