// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaWriterTest.cs
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
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The media writer test class
    /// </summary>
    /// <seealso cref="MediaWriter{TFrame}" />
    public class MediaWriterTest
    {
        /// <summary>
        /// The test frame class
        /// </summary>
        /// <seealso cref="IMediaFrame"/>
        private sealed class TestFrame : IMediaFrame
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestFrame"/> class
            /// </summary>
            /// <param name="rawData">The raw data</param>
            public TestFrame(byte[] rawData) => RawData = rawData;

            /// <summary>
            /// Gets the value of the raw data
            /// </summary>
            public byte[] RawData { get; }

            /// <summary>
            /// Loads the stream
            /// </summary>
            /// <param name="stream">The stream</param>
            /// <returns>The bool</returns>
            public bool Load(Stream stream) => true;
        }

        /// <summary>
        /// The test writer class
        /// </summary>
        /// <seealso cref="MediaWriter{TestFrame}"/>
        private sealed class TestWriter : MediaWriter<TestFrame>
        {
            /// <summary>
            /// Sets the opened using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetOpened(bool value) => OpenedForWriting = value;

            /// <summary>
            /// Sets the stream using the specified stream
            /// </summary>
            /// <param name="stream">The stream</param>
            public void SetStream(Stream stream) => InputDataStream = stream;
        }

        /// <summary>
        /// Tests that media writer write frame should throw when not opened
        /// </summary>
        [Fact]
        public void MediaWriter_WriteFrame_ShouldThrowWhenNotOpened()
        {
            TestWriter writer = new TestWriter();

            Assert.Throws<InvalidOperationException>(() => writer.WriteFrame(new TestFrame(new byte[1])));
        }

        /// <summary>
        /// Tests that media writer write frame should write to input stream
        /// </summary>
        [Fact]
        public void MediaWriter_WriteFrame_ShouldWriteToInputStream()
        {
            byte[] payload = {1, 2, 3, 4};
            MemoryStream stream = new MemoryStream();
            TestWriter writer = new TestWriter();
            writer.SetStream(stream);
            writer.SetOpened(true);

            writer.WriteFrame(new TestFrame(payload));

            Assert.Equal(payload, stream.ToArray());
        }
    }
}
