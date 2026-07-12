// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFrameRemainingCoverageTests.cs
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
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The video frame remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoFrameRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The temp file
        /// </summary>
        internal readonly string _tempFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoFrameRemainingCoverageTests"/> class
        /// </summary>
        public VideoFrameRemainingCoverageTests()
        {
            _tempFile = Path.GetTempFileName();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (File.Exists(_tempFile))
            {
                File.Delete(_tempFile);
            }
        }

        /// <summary>
        /// Tests that dispose with disposing false should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingFalse_ShouldNotThrow()
        {
            VideoFrame frame = new VideoFrame(10, 10);

            MethodInfo disposeMethod = typeof(VideoFrame).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Exception exception = Record.Exception(() =>
                disposeMethod.Invoke(frame, new object[] { false }));

            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that dispose with disposing false should not clear frame buffer
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingFalse_ShouldNotClearFrameBuffer()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] rawData = frame.RawData;

            MethodInfo disposeMethod = typeof(VideoFrame).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);
            disposeMethod.Invoke(frame, new object[] { false });

            Assert.NotNull(frame.RawData);
            Assert.Same(rawData, frame.RawData);
        }

        /// <summary>
        /// Tests that save should complete without exception
        /// </summary>
        [RequireFfmpegFact]
        public void Save_ShouldCompleteWithoutException()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)i;
            }
            frame.Load(new MemoryStream(data));

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");

            try
            {
                Exception exception = Record.Exception(() =>
                    frame.Save(outputPath));

                Assert.Null(exception);
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
            }
        }

        /// <summary>
        /// Tests that save with existing output file should delete and complete
        /// </summary>
        [RequireFfmpegFact]
        public void Save_WithExistingOutputFile_ShouldDeleteAndComplete()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            frame.Load(new MemoryStream(data));

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");
            File.WriteAllText(outputPath, "dummy");

            try
            {
                Exception exception = Record.Exception(() =>
                    frame.Save(outputPath));

                Assert.Null(exception);
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
            }
        }

        /// <summary>
        /// Tests that save with custom encoder should complete without exception
        /// </summary>
        [RequireFfmpegFact]
        public void Save_WithCustomEncoder_ShouldCompleteWithoutException()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            frame.Load(new MemoryStream(data));

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".bmp");

            try
            {
                Exception exception = Record.Exception(() =>
                    frame.Save(outputPath, encoder: "bmp"));

                Assert.Null(exception);
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
            }
        }

        /// <summary>
        /// Tests that save with extra parameters should complete without exception
        /// </summary>
        [RequireFfmpegFact]
        public void Save_WithExtraParameters_ShouldCompleteWithoutException()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            frame.Load(new MemoryStream(data));

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");

            try
            {
                Exception exception = Record.Exception(() =>
                    frame.Save(outputPath, extraParameters: "-q:v 2"));

                Assert.Null(exception);
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
            }
        }
        
        /// <summary>
        /// Tests that save with non existent ffmpeg should throw win 32 exception
        /// </summary>
        [RequireFfmpegFact]
        public void Save_WithNonExistentFfmpeg_ShouldThrowWin32Exception()
        {
            VideoFrame frame = new VideoFrame(2, 2);
            byte[] data = new byte[12];
            frame.Load(new MemoryStream(data));

            string outputPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".png");

            try
            {
                Assert.Throws<Win32Exception>(() =>
                    frame.Save(outputPath, ffmpegExecutable: "ffmpeg-nonexistent-xyz"));
            }
            finally
            {
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
            }
        }

        /// <summary>
        /// Tests that get pixels with specific coordinates should return correct bytes
        /// </summary>
        [RequireFfmpegFact]
        public void GetPixels_WithSpecificCoordinates_ShouldReturnCorrectBytes()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(i % 256);
            }
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(5, 5);

            int index = (5 + 5 * 10) * 3;
            Assert.Equal(3, pixels.Length);
            Assert.Equal(data[index], pixels[0]);
            Assert.Equal(data[index + 1], pixels[1]);
            Assert.Equal(data[index + 2], pixels[2]);
        }

        /// <summary>
        /// Tests that get pixels with last pixel should return correct bytes
        /// </summary>
        [RequireFfmpegFact]
        public void GetPixels_WithLastPixel_ShouldReturnCorrectBytes()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(i % 256);
            }
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(9, 9);

            int index = (9 + 9 * 10) * 3;
            Assert.Equal(3, pixels.Length);
            Assert.Equal(data[index], pixels[0]);
            Assert.Equal(data[index + 1], pixels[1]);
            Assert.Equal(data[index + 2], pixels[2]);
        }

        /// <summary>
        /// Tests that get pixels with multiple pixels should return correct count
        /// </summary>
        [RequireFfmpegFact]
        public void GetPixels_WithMultiplePixels_ShouldReturnCorrectCount()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(i % 256);
            }
            frame.Load(new MemoryStream(data));

            byte[] pixels = frame.GetPixels(0, 0, 10);

            Assert.Equal(30, pixels.Length);
        }

        /// <summary>
        /// Tests that load with chunked stream should accumulate data
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithChunkedStream_ShouldAccumulateData()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)i;
            }

            using (ChunkedMemoryStream chunked = new ChunkedMemoryStream(data, 50))
            {
                bool result = frame.Load(chunked);

                Assert.True(result);
                Assert.Equal(300, frame.RawData.Length);
                for (int i = 0; i < data.Length; i++)
                {
                    Assert.Equal(data[i], frame.RawData[i]);
                }
            }
        }

        /// <summary>
        /// Tests that load with small chunks should accumulate correctly
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithSmallChunks_ShouldAccumulateCorrectly()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[300];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(i % 256);
            }

            using (ChunkedMemoryStream chunked = new ChunkedMemoryStream(data, 7))
            {
                bool result = frame.Load(chunked);

                Assert.True(result);
                Assert.Equal(300, frame.RawData.Length);
                Assert.Equal(data[0], frame.RawData[0]);
                Assert.Equal(data[299], frame.RawData[299]);
            }
        }

        /// <summary>
        /// Tests that load partial data in chunks should resize raw data
        /// </summary>
        [RequireFfmpegFact]
        public void Load_PartialDataInChunks_ShouldResizeRawData()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[150];

            using (ChunkedMemoryStream chunked = new ChunkedMemoryStream(data, 30))
            {
                bool result = frame.Load(chunked);

                Assert.True(result);
                Assert.Equal(150, frame.RawData.Length);
            }
        }

        /// <summary>
        /// Tests that raw data after dispose should still be accessible
        /// </summary>
        [RequireFfmpegFact]
        public void RawData_AfterDispose_ShouldStillBeAccessible()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] rawData = frame.RawData;

            frame.Dispose();

            Assert.NotNull(rawData);
            Assert.Equal(300, rawData.Length);
        }

        /// <summary>
        /// Tests that constructor with maximum dimensions should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithMaximumDimensions_ShouldNotThrow()
        {
            VideoFrame frame = new VideoFrame(3840, 2160);

            Assert.Equal(3840, frame.Width);
            Assert.Equal(2160, frame.Height);
            Assert.Equal(3840 * 2160 * 3, frame.RawData.Length);
        }

        /// <summary>
        /// Tests that load with partial data exactly half should resize correctly
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithPartialDataExactlyHalf_ShouldResizeCorrectly()
        {
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] data = new byte[150];

            using (MemoryStream stream = new MemoryStream(data))
            {
                bool result = frame.Load(stream);

                Assert.True(result);
                Assert.Equal(150, frame.RawData.Length);
            }
        }
    }

    /// <summary>
    /// The chunked memory stream class
    /// </summary>
    /// <seealso cref="Stream"/>
    internal class ChunkedMemoryStream : Stream
    {
        /// <summary>
        /// The buffer
        /// </summary>
        internal readonly byte[] _buffer;
        /// <summary>
        /// The chunk size
        /// </summary>
        internal readonly int _chunkSize;
        /// <summary>
        /// The position
        /// </summary>
        private int _position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkedMemoryStream"/> class
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="chunkSize">The chunk size</param>
        public ChunkedMemoryStream(byte[] buffer, int chunkSize)
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
}
