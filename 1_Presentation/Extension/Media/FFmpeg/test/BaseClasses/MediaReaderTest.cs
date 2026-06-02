// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaReaderTest.cs
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
    ///     The media reader test class
    /// </summary>
    /// <seealso cref="MediaReader{TFrame,TWriter}" />
    public class MediaReaderTest
    {
        private sealed class TestFrame : IMediaFrame
        {
            public TestFrame(byte[] rawData)
            {
                RawData = rawData;
            }

            public byte[] RawData { get; }

            public bool Load(Stream stream) => true;
        }

        private sealed class TestWriter : MediaWriter<TestFrame>
        {
            public void SetOpened(bool value) => OpenedForWriting = value;

            public void SetStream(Stream stream) => InputDataStream = stream;
        }

        private sealed class TestReader : MediaReader<TestFrame, TestWriter>
        {
            public void SetStream(Stream stream) => DataStream = stream;

            public void SetOpened(bool value) => OpenedForReading = value;

            public override TestFrame NextFrame() => null;

            public override TestFrame NextFrame(TestFrame frame) => null;
        }

        [Fact]
        public void MediaReader_CopyTo_ShouldThrowWhenReaderNotOpened()
        {
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            writer.SetOpened(true);
            writer.SetStream(new MemoryStream());

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(writer));

            Assert.Contains("Reader is not opened for reading", ex.Message);
        }

        [Fact]
        public void MediaReader_CopyTo_ShouldThrowWhenWriterNotOpened()
        {
            TestReader reader = new TestReader();
            TestWriter writer = new TestWriter();
            reader.SetStream(new MemoryStream(Encoding.UTF8.GetBytes("data")));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.CopyTo(writer));

            Assert.Contains("Writer is not opened for writing", ex.Message);
        }
    }
}
