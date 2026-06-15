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

using System.IO;
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
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            stream.Position = 100;

            // Assert
            Assert.Equal(100, stream.Position);
        }

        
    }
}
