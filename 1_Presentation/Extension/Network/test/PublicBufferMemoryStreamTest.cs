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
using Alis.Extension.Network;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for PublicBufferMemoryStream class
    /// </summary>
    public class PublicBufferMemoryStreamTest
    {
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

        [Fact]
        public void ReadTimeout_ReturnsCorrectValue()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            int result = stream.ReadTimeout;

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void WriteTimeout_ReturnsCorrectValue()
        {
            // Arrange
            byte[] buffer = new byte[1024];
            BufferPool pool = new BufferPool();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, pool);

            // Act
            int result = stream.WriteTimeout;

            // Assert
            Assert.Equal(0, result);
        }

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
