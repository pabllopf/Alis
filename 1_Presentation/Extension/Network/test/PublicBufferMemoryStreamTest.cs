// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PublicBufferMemoryStreamTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for PublicBufferMemoryStream class
    /// </summary>
    public class PublicBufferMemoryStreamTest
    {
        /// <summary>
        /// Tests that constructor creates instance with buffer
        /// </summary>
        [Fact]
        public void Constructor_CreatesInstanceWithBuffer()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();

            // Act
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Assert
            Assert.NotNull(stream);
            Assert.IsType<PublicBufferMemoryStream>(stream);
        }

        /// <summary>
        /// Tests that can read returns true
        /// </summary>
        [Fact]
        public void CanRead_ReturnsTrue()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            bool result = stream.CanRead;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that can seek returns true
        /// </summary>
        [Fact]
        public void CanSeek_ReturnsTrue()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            bool result = stream.CanSeek;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that can write returns true
        /// </summary>
        [Fact]
        public void CanWrite_ReturnsTrue()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            bool result = stream.CanWrite;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that capacity returns correct value
        /// </summary>
        [Fact]
        public void Capacity_ReturnsCorrectValue()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            int result = stream.Capacity;

            // Assert
            Assert.Equal(1024, result);
        }

        /// <summary>
        /// Tests that position starts at zero
        /// </summary>
        [Fact]
        public void Position_StartsAtZero()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            long result = stream.Position;

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        /// Tests that write byte writes byte
        /// </summary>
        [Fact]
        public void WriteByte_WritesByte()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            stream.WriteByte(42);

            // Assert
            Assert.Equal(1, stream.Position);
        }

        /// <summary>
        /// Tests that write writes bytes
        /// </summary>
        [Fact]
        public void Write_WritesBytes()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);
            byte[] data = new byte[] { 1, 2, 3, 4, 5 };

            // Act
            stream.Write(data, 0, data.Length);

            // Assert
            Assert.Equal(5, stream.Position);
        }

        /// <summary>
        /// Tests that read reads bytes
        /// </summary>
        [Fact]
        public void Read_ReadsBytes()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);
            byte[] data = new byte[] { 1, 2, 3, 4, 5 };
            stream.Write(data, 0, data.Length);

            // Act
            byte[] readBuffer = new byte[3];
            int bytesRead = stream.Read(readBuffer, 0, 3);

            // Assert
            Assert.Equal(3, bytesRead);
        }

        /// <summary>
        /// Tests that get buffer returns original buffer
        /// </summary>
        [Fact]
        public void GetBuffer_ReturnsOriginalBuffer()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            byte[] result = stream.GetBuffer();

            // Assert
            Assert.Same(buffer, result);
        }



        /// <summary>
        /// Tests that seek seeks to position
        /// </summary>
        [Fact]
        public void Seek_SeeksToPosition()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            stream.Seek(100, SeekOrigin.Begin);

            // Assert
            Assert.Equal(100, stream.Position);
        }


        /// <summary>
        /// Tests that close returns buffer to pool
        /// </summary>
        [Fact]
        public void Close_ReturnsBufferToPool()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            stream.WriteByte(42);
            stream.Close();

            // Assert
            // Buffer returned to pool without exception
        }

        /// <summary>
        /// Tests that flush flushes stream
        /// </summary>
        [Fact]
        public void Flush_FlushesStream()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            stream.Flush();

            // Assert
            // No exception thrown
        }

        /// <summary>
        /// Tests that copy to async copies to stream
        /// </summary>
        [Fact]
        public void CopyToAsync_CopiesToStream()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);
            byte[] data = new byte[] { 1, 2, 3, 4, 5 };
            stream.Write(data, 0, data.Length);

            // Act
            MemoryStream targetStream = new MemoryStream();
            stream.CopyToAsync(targetStream);

            // Assert
            Assert.NotNull(targetStream);
        }

        /// <summary>
        /// Tests that write async writes bytes
        /// </summary>
        [Fact]
        public void WriteAsync_WritesBytesAsync()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);
            byte[] data = new byte[] { 1, 2, 3 };

            // Act
            stream.WriteAsync(data, 0, data.Length);

            // Assert
            Assert.Equal(3, stream.Position);
        }

        /// <summary>
        /// Tests that create new instance initializes correctly
        /// </summary>
        [Fact]
        public void CreateNewInstance_InitializesCorrectly()
        {
            // Arrange
            // Act
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[1024], new BufferPool());

            // Assert
            Assert.NotNull(stream);
            Assert.NotNull(stream.GetBuffer());
            Assert.Equal(1024, stream.Capacity);
        }
        

        /// <summary>
        /// Tests that position can be set
        /// </summary>
        [Fact]
        public void Position_CanBeSet()
        {
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            stream.Position = 100;

            Assert.Equal(100, stream.Position);
        }

        /// <summary>
        /// Tests that Write triggers buffer enlargement when writing beyond capacity
        /// </summary>
        [Fact]
        public void Write_EnlargesBufferWhenExceedingCapacity()
        {
            byte[] buffer = new byte[16];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);
            byte[] data = new byte[32];

            stream.Write(data, 0, 32);

            Assert.Equal(32, stream.Position);
            Assert.True(stream.Capacity >= 32);
        }

        /// <summary>
        /// Tests that WriteByte triggers buffer enlargement when writing beyond capacity
        /// </summary>
        [Fact]
        public void WriteByte_EnlargesBufferWhenExceedingCapacity()
        {
            byte[] buffer = new byte[4];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            for (int i = 0; i < 10; i++)
            {
                stream.WriteByte((byte)i);
            }

            Assert.Equal(10, stream.Position);
            Assert.True(stream.Capacity >= 10);
        }

        /// <summary>
        /// Tests that Write within capacity does not enlarge buffer
        /// </summary>
        [Fact]
        public void Write_WithinCapacity_DoesNotEnlarge()
        {
            byte[] buffer = new byte[64];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);
            byte[] data = new byte[32];

            stream.Write(data, 0, 32);

            Assert.Equal(32, stream.Position);
            Assert.Equal(64, stream.Capacity);
        }

        /// <summary>
        /// Tests that IsNewBufferRequired returns false when count fits in remaining space
        /// </summary>
        [Fact]
        public void IsNewBufferRequired_False_WhenEnoughSpace()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            bool result = stream.IsNewBufferRequired(32);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that IsNewBufferRequired returns true when count exceeds remaining space
        /// </summary>
        [Fact]
        public void IsNewBufferRequired_True_WhenNotEnoughSpace()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            bool result = stream.IsNewBufferRequired(128);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that CalculateInitialNewSize returns double the buffer length
        /// </summary>
        [Fact]
        public void CalculateInitialNewSize_ReturnsDoubleBufferLength()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[100], new BufferPool());

            long result = stream.CalculateInitialNewSize();

            Assert.Equal(200, result);
        }

        /// <summary>
        /// Tests that CalculateRequiredSize returns expected value
        /// </summary>
        [Fact]
        public void CalculateRequiredSize_ReturnsExpectedValue()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[100], new BufferPool());

            long result = stream.CalculateRequiredSize(50, 10);

            Assert.Equal(140, result);
        }

        /// <summary>
        /// Tests that ValidateRequiredSize does not throw for valid size
        /// </summary>
        [Fact]
        public void ValidateRequiredSize_ValidSize_DoesNotThrow()
        {
            PublicBufferMemoryStream.ValidateRequiredSize(1024);
        }

        /// <summary>
        /// Tests that ValidateRequiredSize throws WebSocketBufferOverflowException for size exceeding int.MaxValue
        /// </summary>
        [Fact]
        public void ValidateRequiredSize_OverflowSize_ThrowsWebSocketBufferOverflowException()
        {
            Assert.Throws<WebSocketBufferOverflowException>(() =>
                PublicBufferMemoryStream.ValidateRequiredSize((long)int.MaxValue + 1));
        }

        /// <summary>
        /// Tests that IsNewSizeLessThanRequiredSize returns true when required is larger
        /// </summary>
        [Fact]
        public void IsNewSizeLessThanRequiredSize_RequiredLarger_ReturnsTrue()
        {
            bool result = PublicBufferMemoryStream.IsNewSizeLessThanRequiredSize(100, 200);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that IsNewSizeLessThanRequiredSize returns false when new size is large enough
        /// </summary>
        [Fact]
        public void IsNewSizeLessThanRequiredSize_NewSizeSufficient_ReturnsFalse()
        {
            bool result = PublicBufferMemoryStream.IsNewSizeLessThanRequiredSize(300, 200);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that ComputeCandidateSize rounds up to power of 2
        /// </summary>
        [Fact]
        public void ComputeCandidateSize_RoundsUpToPowerOf2()
        {
            long result = PublicBufferMemoryStream.ComputeCandidateSize(150);

            Assert.Equal(256, result);
        }

        /// <summary>
        /// Tests that ComputeCandidateSize returns requiredSize when candidate exceeds int.MaxValue
        /// </summary>
        [Fact]
        public void ComputeCandidateSize_ExceedsMaxInt_ReturnsRequiredSize()
        {
            long result = PublicBufferMemoryStream.ComputeCandidateSize((long)int.MaxValue + 1);

            Assert.Equal((long)int.MaxValue + 1, result);
        }

        /// <summary>
        /// Tests that CanTimeout returns expected value
        /// </summary>
        [Fact]
        public void CanTimeout_ReturnsExpectedValue()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            bool result = stream.CanTimeout;

            Assert.False(result);
        }

        /// <summary>
        /// Tests that reading ReadTimeout throws InvalidOperationException
        /// </summary>
        [Fact]
        public void ReadTimeout_Get_ThrowsInvalidOperationException()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            Assert.Throws<InvalidOperationException>(() => stream.ReadTimeout);
        }

        /// <summary>
        /// Tests that setting ReadTimeout throws InvalidOperationException
        /// </summary>
        [Fact]
        public void ReadTimeout_Set_ThrowsInvalidOperationException()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            Assert.Throws<InvalidOperationException>(() => stream.ReadTimeout = 5000);
        }

        /// <summary>
        /// Tests that reading WriteTimeout throws InvalidOperationException
        /// </summary>
        [Fact]
        public void WriteTimeout_Get_ThrowsInvalidOperationException()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            Assert.Throws<InvalidOperationException>(() => stream.WriteTimeout);
        }

        /// <summary>
        /// Tests that setting WriteTimeout throws InvalidOperationException
        /// </summary>
        [Fact]
        public void WriteTimeout_Set_ThrowsInvalidOperationException()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            Assert.Throws<InvalidOperationException>(() => stream.WriteTimeout = 3000);
        }

        /// <summary>
        /// Tests that FlushAsync does not throw
        /// </summary>
        [Fact]
        public async Task FlushAsync_DoesNotThrow()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());

            await stream.FlushAsync(CancellationToken.None);
        }

        /// <summary>
        /// Tests that ReadAsync reads bytes asynchronously
        /// </summary>
        [Fact]
        public async Task ReadAsync_ReadsBytes()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());
            byte[] data = { 1, 2, 3, 4, 5 };
            stream.Write(data, 0, 5);

            byte[] readBuffer = new byte[3];
            int bytesRead = await stream.ReadAsync(readBuffer, 0, 3);

            Assert.Equal(3, bytesRead);
        }

        /// <summary>
        /// Tests that ReadByte reads a single byte
        /// </summary>
        [Fact]
        public void ReadByte_ReadsSingleByte()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());
            stream.WriteByte(42);

            stream.Position = 0;
            int result = stream.ReadByte();

            Assert.Equal(42, result);
        }

        /// <summary>
        /// Tests that SetLength enlarges buffer if required
        /// </summary>
        [Fact]
        public void SetLength_EnlargesBufferIfRequired()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[16], new BufferPool());

            stream.SetLength(100);

            Assert.True(stream.Capacity >= 100);
        }

        /// <summary>
        /// Tests that ToArray returns array with stream content (underlying buffer length)
        /// </summary>
        [Fact]
        public void ToArray_ReturnsBufferContent()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());
            byte[] data = { 1, 2, 3 };
            stream.Write(data, 0, 3);

            byte[] result = stream.ToArray();

            Assert.Equal(64, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        /// <summary>
        /// Tests that WriteTo writes content to another stream
        /// </summary>
        [Fact]
        public void WriteTo_WritesToTargetStream()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());
            byte[] data = { 1, 2, 3 };
            stream.Write(data, 0, 3);

            using MemoryStream target = new MemoryStream();
            stream.WriteTo(target);

            Assert.True(target.Length > 0);
        }

        /// <summary>
        /// Tests that CopyToAsync with buffer size copies to target stream
        /// </summary>
        [Fact]
        public async Task CopyToAsync_WithBufferSize_CopiesToStream()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[1024], new BufferPool());
            byte[] data = new byte[100];
            stream.Write(data, 0, 100);

            using MemoryStream target = new MemoryStream();
            await stream.CopyToAsync(target, 4096, CancellationToken.None);

            Assert.True(target.Length > 0);
        }

        /// <summary>
        /// Tests that BeginRead and EndRead work correctly
        /// </summary>
        [Fact]
        public void BeginRead_EndRead_ReadsCorrectly()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());
            byte[] data = { 1, 2, 3, 4, 5 };
            stream.Write(data, 0, 5);

            byte[] readBuffer = new byte[3];
            IAsyncResult asyncResult = stream.BeginRead(readBuffer, 0, 3, null, null);
            int bytesRead = stream.EndRead(asyncResult);

            Assert.Equal(3, bytesRead);
        }

        /// <summary>
        /// Tests that BeginWrite and EndWrite work correctly
        /// </summary>
        [Fact]
        public void BeginWrite_EndWrite_WritesCorrectly()
        {
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(new byte[64], new BufferPool());
            byte[] data = { 1, 2, 3 };

            IAsyncResult asyncResult = stream.BeginWrite(data, 0, 3, null, null);
            stream.EndWrite(asyncResult);

            Assert.Equal(3, stream.Position);
        }
    }
}
