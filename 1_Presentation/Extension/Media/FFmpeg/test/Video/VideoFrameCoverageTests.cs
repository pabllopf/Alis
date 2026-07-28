// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFrameCoverageTests.cs
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
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The video frame coverage tests class
    /// </summary>
    public class VideoFrameCoverageTests
    {
        /// <summary>
        /// Tests that constructor valid dimensions creates frame
        /// </summary>
        [Fact]
        public void Constructor_ValidDimensions_CreatesFrame()
        {
            VideoFrame frame = new VideoFrame(10, 10);

            Assert.Equal(10, frame.Width);
            Assert.Equal(10, frame.Height);
            Assert.Equal(300, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that constructor zero width throws invalid data exception
        /// </summary>
        [Fact]
        public void Constructor_ZeroWidth_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new VideoFrame(0, 10));
        }

        /// <summary>
        /// Tests that constructor zero height throws invalid data exception
        /// </summary>
        [Fact]
        public void Constructor_ZeroHeight_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new VideoFrame(10, 0));
        }

        /// <summary>
        /// Tests that constructor negative width throws invalid data exception
        /// </summary>
        [Fact]
        public void Constructor_NegativeWidth_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new VideoFrame(-1, 10));
        }

        /// <summary>
        /// Tests that constructor negative height throws invalid data exception
        /// </summary>
        [Fact]
        public void Constructor_NegativeHeight_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new VideoFrame(10, -1));
        }

        /// <summary>
        /// Tests that constructor both zero throws invalid data exception
        /// </summary>
        [Fact]
        public void Constructor_BothZero_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new VideoFrame(0, 0));
        }

        /// <summary>
        /// Tests that constructor width and height properties return correct values
        /// </summary>
        [Fact]
        public void Constructor_WidthAndHeightProperties_ReturnCorrectValues()
        {
            VideoFrame frame = new VideoFrame(640, 480);

            Assert.Equal(640, frame.Width);
            Assert.Equal(480, frame.Height);
        }

        /// <summary>
        /// Tests that constructor raw data length is width times height times 3
        /// </summary>
        [Fact]
        public void Constructor_RawDataLength_IsWidthTimesHeightTimes3()
        {
            VideoFrame frame = new VideoFrame(5, 5);

            Assert.Equal(75, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that constructor all pixels start zero
        /// </summary>
        [Fact]
        public void Constructor_AllPixelsStartZero()
        {
            VideoFrame frame = new VideoFrame(4, 4);
            byte[] data = frame.RawData;

            foreach (byte b in data)
            {
                Assert.Equal(0, b);
            }
        }

        /// <summary>
        /// Tests that dispose sets frame buffer to null
        /// </summary>
        [Fact]
        public void Dispose_SetsFrameBufferToNull()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] rawData = frame.RawData;

            frame.Dispose();

            Assert.NotNull(rawData);
        }

        /// <summary>
        /// Tests that dispose multiple times does not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleTimes_DoesNotThrow()
        {
            VideoFrame frame = new VideoFrame(10, 10);

            frame.Dispose();
            frame.Dispose();
            frame.Dispose();
        }

        /// <summary>
        /// Tests that load full data returns true
        /// </summary>
        [Fact]
        public void Load_FullData_ReturnsTrue()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)i;
            }

            bool result = frame.Load(new MemoryStream(data));

            Assert.True(result);
            Assert.Equal(12, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that load full data stores correct bytes
        /// </summary>
        [Fact]
        public void Load_FullData_StoresCorrectBytes()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)i;
            }

            frame.Load(new MemoryStream(data));

            for (int i = 0; i < 12; i++)
            {
                Assert.Equal((byte)i, frame.RawData[i]);
            }
        }

        /// <summary>
        /// Tests that load empty stream returns false
        /// </summary>
        [Fact]
        public void Load_EmptyStream_ReturnsFalse()
        {
            VideoFrame frame = new VideoFrame(10, 10);

            bool result = frame.Load(new MemoryStream());

            Assert.False(result);
        }

        /// <summary>
        /// Tests that load empty stream does not change raw data length
        /// </summary>
        [Fact]
        public void Load_EmptyStream_DoesNotChangeRawDataLength()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            int originalLength = frame.RawData.Length;

            frame.Load(new MemoryStream());

            Assert.Equal(originalLength, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that load partial data returns true
        /// </summary>
        [Fact]
        public void Load_PartialData_ReturnsTrue()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[100];

            bool result = frame.Load(new MemoryStream(data));

            Assert.True(result);
        }

        /// <summary>
        /// Tests that load partial data resizes raw data
        /// </summary>
        [Fact]
        public void Load_PartialData_ResizesRawData()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[100];

            frame.Load(new MemoryStream(data));

            Assert.Equal(100, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that load partial data exactly half resizes correctly
        /// </summary>
        [Fact]
        public void Load_PartialDataExactlyHalf_ResizesCorrectly()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[150];

            bool result = frame.Load(new MemoryStream(data));

            Assert.True(result);
            Assert.Equal(150, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that load exact full data does not reallocate
        /// </summary>
        [Fact]
        public void Load_ExactFullData_DoesNotReallocate()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            byte[] originalBuffer = frame.RawData;

            frame.Load(new MemoryStream(data));

            Assert.Equal(300, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that load then dispose then load again works
        /// </summary>
        [Fact]
        public void Load_ThenDispose_ThenLoadAgain_Works()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            frame.Load(new MemoryStream(new byte[300]));
            frame.Dispose();

            VideoFrame frame2 = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            for (int i = 0; i < 300; i++)
            {
                data[i] = (byte)(i % 256);
            }

            bool result = frame2.Load(new MemoryStream(data));

            Assert.True(result);
            Assert.Equal(data[0], frame2.RawData[0]);
            Assert.Equal(data[299], frame2.RawData[299]);
        }

        /// <summary>
        /// Tests that load stream read returns zero at start returns false
        /// </summary>
        [Fact]
        public void Load_StreamReadReturnsZeroAtStart_ReturnsFalse()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            ZeroLengthStream zeroStream = new ZeroLengthStream();

            bool result = frame.Load(zeroStream);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that raw data after construction is not null
        /// </summary>
        [Fact]
        public void RawData_AfterConstruction_IsNotNull()
        {
            VideoFrame frame = new VideoFrame(1, 1);

            Assert.NotNull(frame.RawData);
        }

        /// <summary>
        /// Tests that raw data after load reflects loaded data
        /// </summary>
        [Fact]
        public void RawData_AfterLoad_ReflectsLoadedData()
        {
            VideoFrame frame = new VideoFrame(1, 1);
            byte[] data = new byte[] { 10, 20, 30 };

            frame.Load(new MemoryStream(data));

            Assert.Equal(10, frame.RawData[0]);
            Assert.Equal(20, frame.RawData[1]);
            Assert.Equal(30, frame.RawData[2]);
        }

        /// <summary>
        /// Tests that get pixels origin returns first three bytes
        /// </summary>
        [Fact]
        public void GetPixels_Origin_ReturnsFirstThreeBytes()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < 12; i++)
            {
                data[i] = (byte)i;
            }
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(0, 0);

            Assert.Equal(3, pixels.Length);
            Assert.Equal(0, pixels[0]);
            Assert.Equal(1, pixels[1]);
            Assert.Equal(2, pixels[2]);
        }

        /// <summary>
        /// Tests that get pixels mid frame returns correct bytes
        /// </summary>
        [Fact]
        public void GetPixels_MidFrame_ReturnsCorrectBytes()
        {
            VideoFrame frame = new VideoFrame(4, 4);
            byte[] data = new byte[48];
            for (int i = 0; i < 48; i++)
            {
                data[i] = (byte)i;
            }
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(2, 2);

            int expectedIndex = (2 + 2 * 4) * 3;
            Assert.Equal(data[expectedIndex], pixels[0]);
            Assert.Equal(data[expectedIndex + 1], pixels[1]);
            Assert.Equal(data[expectedIndex + 2], pixels[2]);
        }

        /// <summary>
        /// Tests that get pixels last pixel returns correct bytes
        /// </summary>
        [Fact]
        public void GetPixels_LastPixel_ReturnsCorrectBytes()
        {
            VideoFrame frame = new VideoFrame(3, 3);
            byte[] data = new byte[27];
            for (int i = 0; i < 27; i++)
            {
                data[i] = (byte)i;
            }
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(2, 2);

            int expectedIndex = (2 + 2 * 3) * 3;
            Assert.Equal(data[expectedIndex], pixels[0]);
            Assert.Equal(data[expectedIndex + 1], pixels[1]);
            Assert.Equal(data[expectedIndex + 2], pixels[2]);
        }

        /// <summary>
        /// Tests that get pixels with length returns correct count
        /// </summary>
        [Fact]
        public void GetPixels_WithLength_ReturnsCorrectCount()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(0, 0, 5);

            Assert.Equal(15, pixels.Length);
        }

        /// <summary>
        /// Tests that get pixels with length returns correct bytes
        /// </summary>
        [Fact]
        public void GetPixels_WithLength_ReturnsCorrectBytes()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < 12; i++)
            {
                data[i] = (byte)i;
            }
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(0, 0, 2);

            Assert.Equal(6, pixels.Length);
            Assert.Equal(0, pixels[0]);
            Assert.Equal(5, pixels[5]);
        }

        /// <summary>
        /// Tests that get pixels out of bounds throws
        /// </summary>
        [Fact]
        public void GetPixels_OutOfBounds_Throws()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            frame.Load(new MemoryStream(data));

            Assert.Throws<ArgumentException>(() => frame.GetPixels(10, 10));
        }

        /// <summary>
        /// Tests that load chunked read accumulates correctly
        /// </summary>
        [Fact]
        public void Load_ChunkedRead_AccumulatesCorrectly()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < 12; i++)
            {
                data[i] = (byte)i;
            }

            using (ChunkStream chunked = new ChunkStream(data, 3))
            {
                bool result = frame.Load(chunked);

                Assert.True(result);
                for (int i = 0; i < 12; i++)
                {
                    Assert.Equal((byte)i, frame.RawData[i]);
                }
            }
        }

        /// <summary>
        /// Tests that load tiny chunks accumulates correctly
        /// </summary>
        [Fact]
        public void Load_TinyChunks_AccumulatesCorrectly()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < 12; i++)
            {
                data[i] = (byte)i;
            }

            using (ChunkStream chunked = new ChunkStream(data, 1))
            {
                bool result = frame.Load(chunked);

                Assert.True(result);
                for (int i = 0; i < 12; i++)
                {
                    Assert.Equal((byte)i, frame.RawData[i]);
                }
            }
        }

        /// <summary>
        /// Tests that implements i media frame
        /// </summary>
        [Fact]
        public void Implements_IMediaFrame()
        {
            VideoFrame frame = new VideoFrame(1, 1);

            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        /// Tests that implements i disposable
        /// </summary>
        [Fact]
        public void Implements_IDisposable()
        {
            VideoFrame frame = new VideoFrame(1, 1);

            Assert.IsAssignableFrom<IDisposable>(frame);
        }
    }

    /// <summary>
    /// The chunk stream class
    /// </summary>
    /// <seealso cref="Stream"/>
    internal class ChunkStream : Stream
    {
        /// <summary>
        /// The buffer
        /// </summary>
        private readonly byte[] _buffer;
        /// <summary>
        /// The chunk size
        /// </summary>
        private readonly int _chunkSize;
        /// <summary>
        /// The position
        /// </summary>
        private int _position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkStream"/> class
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="chunkSize">The chunk size</param>
        public ChunkStream(byte[] buffer, int chunkSize)
        {
            _buffer = buffer;
            _chunkSize = chunkSize;
            _position = 0;
        }

        /// <summary>
        /// Gets the value of the can read
        /// </summary>
        public override bool CanRead => true;
        /// <summary>
        /// Gets the value of the can seek
        /// </summary>
        public override bool CanSeek => false;
        /// <summary>
        /// Gets the value of the can write
        /// </summary>
        public override bool CanWrite => false;
        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public override long Length => _buffer.Length;
        /// <summary>
        /// Gets or sets the value of the position
        /// </summary>
        public override long Position
        {
            get => _position;
            set => throw new NotSupportedException();
        }

        /// <summary>
        /// Flushes this instance
        /// </summary>
        public override void Flush() { }
        /// <summary>
        /// Seeks the offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="origin">The origin</param>
        /// <returns>The long</returns>
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        /// <summary>
        /// Sets the length using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public override void SetLength(long value) => throw new NotSupportedException();
        /// <summary>
        /// Writes the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        /// <summary>
        /// Reads the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        /// <returns>The bytes to read</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_position >= _buffer.Length)
            {
                return 0;
            }

            int bytesToRead = Math.Min(_chunkSize, _buffer.Length - _position);
            bytesToRead = Math.Min(bytesToRead, count);

            Array.Copy(_buffer, _position, buffer, offset, bytesToRead);
            _position += bytesToRead;

            return bytesToRead;
        }
    }

    /// <summary>
    /// The zero length stream class
    /// </summary>
    /// <seealso cref="Stream"/>
    internal class ZeroLengthStream : Stream
    {
        /// <summary>
        /// Gets the value of the can read
        /// </summary>
        public override bool CanRead => true;
        /// <summary>
        /// Gets the value of the can seek
        /// </summary>
        public override bool CanSeek => false;
        /// <summary>
        /// Gets the value of the can write
        /// </summary>
        public override bool CanWrite => false;
        /// <summary>
        /// Gets the value of the length
        /// </summary>
        public override long Length => 0;
        /// <summary>
        /// Gets or sets the value of the position
        /// </summary>
        public override long Position
        {
            get => 0;
            set => throw new NotSupportedException();
        }

        /// <summary>
        /// Flushes this instance
        /// </summary>
        public override void Flush() { }
        /// <summary>
        /// Seeks the offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="origin">The origin</param>
        /// <returns>The long</returns>
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        /// <summary>
        /// Sets the length using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public override void SetLength(long value) => throw new NotSupportedException();
        /// <summary>
        /// Writes the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        /// <summary>
        /// Reads the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public override int Read(byte[] buffer, int offset, int count) => 0;
    }
}
