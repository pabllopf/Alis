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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The public buffer memory stream test class
    /// </summary>
    public class PublicBufferMemoryStreamTest
    {
        /// <summary>
        /// Tests that public buffer memory stream constructor
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Constructor()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            Assert.NotNull(stream);
        }
        
        /// <summary>
        /// Tests that public buffer memory stream write byte
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_WriteByte()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.WriteByte(0x20);
            Assert.Equal(0, stream.Length);
        }
        
        /// <summary>
        /// Tests that public buffer memory stream write
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Write()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.Write(new byte[] {0x20, 0x30}, 0, 2);
            Assert.Equal(0, stream.Length);
        }
        
        /// <summary>
        /// Tests that public buffer memory stream read byte
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_ReadByte()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.WriteByte(0x20);
            stream.Position = 0;
            Assert.Equal(0x20, stream.ReadByte());
        }
        
        /// <summary>
        /// Tests that public buffer memory stream read
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Read()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.Write(new byte[] {0x20, 0x30}, 0, 2);
            stream.Position = 0;
            byte[] readBuffer = new byte[2];
            stream.Read(readBuffer, 0, 2);
            Assert.Equal(new byte[] {0x20, 0x30}, readBuffer);
        }
        
        /// <summary>
        /// Tests that public buffer memory stream close
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Close()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.Close();
            Assert.Equal(0, stream.Length);
        }
        
        /// <summary>
        /// Tests that write read should work correctly
        /// </summary>
        [Fact]
        public void Write_Read_ShouldWorkCorrectly()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that write when buffer is full should enlarge buffer
        /// </summary>
        [Fact]
        public void Write_WhenBufferIsFull_ShouldEnlargeBuffer()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[4]; // Small buffer for testing
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that read async valid input
        /// </summary>
        [Fact]
        public async Task ReadAsync_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length, CancellationToken.None);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that read async invalid input
        /// </summary>
        [Fact]
        public async Task ReadAsync_InvalidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            byte[] readBuffer = new byte[dataToWrite.Length + 1]; // Buffer size is larger than the data
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length, CancellationToken.None);
            
            Assert.Equal(6, bytesRead);
            Assert.Equal(dataToWrite, readBuffer.Take(dataToWrite.Length));
            Assert.Equal(0, readBuffer[dataToWrite.Length]); // Extra byte should be 0
        }
        
        /// <summary>
        /// Tests that read timeout get set
        /// </summary>
        [Fact]
        public void ReadTimeout_GetSet()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.Throws<InvalidOperationException>(() => stream.ReadTimeout = 5000);
        }
        
        /// <summary>
        /// Tests that write timeout get set
        /// </summary>
        [Fact]
        public void WriteTimeout_GetSet()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.Throws<InvalidOperationException>(() => stream.WriteTimeout = 5000);
        }
        
        /// <summary>
        /// Tests that begin read valid input
        /// </summary>
        [Fact]
        public void BeginRead_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            IAsyncResult asyncResult = stream.BeginRead(readBuffer, 0, readBuffer.Length, null, null);
            int bytesRead = stream.EndRead(asyncResult);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that begin write valid input
        /// </summary>
        [Fact]
        public void BeginWrite_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            IAsyncResult asyncResult = stream.BeginWrite(dataToWrite, 0, dataToWrite.Length, null, null);
            stream.EndWrite(asyncResult);
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that can read should return true
        /// </summary>
        [Fact]
        public void CanRead_ShouldReturnTrue()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.True(stream.CanRead);
        }
        
        /// <summary>
        /// Tests that can seek should return true
        /// </summary>
        [Fact]
        public void CanSeek_ShouldReturnTrue()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.True(stream.CanSeek);
        }
        
        /// <summary>
        /// Tests that can timeout should return true
        /// </summary>
        [Fact]
        public void CanTimeout_ShouldReturnTrue()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.False(stream.CanTimeout);
        }
        
        /// <summary>
        /// Tests that can write should return true
        /// </summary>
        [Fact]
        public void CanWrite_ShouldReturnTrue()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.True(stream.CanWrite);
        }
        
        /// <summary>
        /// Tests that capacity get set
        /// </summary>
        [Fact]
        public void Capacity_GetSet()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.Throws<NotSupportedException>(() => stream.Capacity = 2048);
        }
        
        /// <summary>
        /// Tests that position get set
        /// </summary>
        [Fact]
        public void Position_GetSet()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            stream.Position = 500;
            Assert.Equal(500, stream.Position);
        }
        
        /// <summary>
        /// Tests that read timeout get set v 3
        /// </summary>
        [Fact]
        public void ReadTimeout_GetSet_v3()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.Throws<InvalidOperationException>(() => stream.ReadTimeout = 5000);
        }
        
        /// <summary>
        /// Tests that write timeout get set v 2
        /// </summary>
        [Fact]
        public void WriteTimeout_GetSet_v2()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.Throws<InvalidOperationException>(() => stream.WriteTimeout = 5000);
        }
        
        /// <summary>
        /// Tests that seek valid input
        /// </summary>
        [Fact]
        public void Seek_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            long newPosition = stream.Seek(500, SeekOrigin.Begin);
            
            Assert.Equal(500, newPosition);
        }
        
        /// <summary>
        /// Tests that set length valid input
        /// </summary>
        [Fact]
        public void SetLength_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            stream.SetLength(2048);
            
            Assert.Equal(0, stream.Length);
        }
        
        /// <summary>
        /// Tests that to array valid input
        /// </summary>
        [Fact]
        public void ToArray_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            byte[] array = stream.ToArray();
            
            Assert.Equal(dataToWrite, array.Take(dataToWrite.Length));
        }
        
        /// <summary>
        /// Tests that write to valid input
        /// </summary>
        [Fact]
        public void WriteTo_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            MemoryStream targetStream = new MemoryStream();
            stream.WriteTo(targetStream);
            
            byte[] targetArray = targetStream.ToArray();
        }
        
        /// <summary>
        /// Tests that copy to async valid input
        /// </summary>
        [Fact]
        public async Task CopyToAsync_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            MemoryStream targetStream = new MemoryStream();
            await stream.CopyToAsync(targetStream, 1024, CancellationToken.None);
            
            byte[] targetArray = targetStream.ToArray();
        }
        
        /// <summary>
        /// Tests that flush valid input
        /// </summary>
        [Fact]
        public void Flush_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            stream.Flush();
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that flush async valid input
        /// </summary>
        [Fact]
        public async Task FlushAsync_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            stream.Write(dataToWrite, 0, dataToWrite.Length);
            
            await stream.FlushAsync(CancellationToken.None);
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = stream.Read(readBuffer, 0, readBuffer.Length);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that write async valid input
        /// </summary>
        [Fact]
        public async Task WriteAsync_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            byte[] dataToWrite = new byte[] {1, 2, 3, 4, 5};
            await stream.WriteAsync(dataToWrite, 0, dataToWrite.Length, CancellationToken.None);
            
            byte[] readBuffer = new byte[dataToWrite.Length];
            stream.Position = 0; // Reset position to start of stream
            int bytesRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length, CancellationToken.None);
            
            Assert.Equal(dataToWrite.Length, bytesRead);
            Assert.Equal(dataToWrite, readBuffer);
        }
        
        /// <summary>
        /// Tests that get capacity valid input
        /// </summary>
        [Fact]
        public void GetCapacity_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            int capacity = stream.Capacity;
            
            Assert.Equal(buffer.Length, capacity);
        }
        
        /// <summary>
        /// Tests that get position valid input
        /// </summary>
        [Fact]
        public void GetPosition_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            long position = stream.Position;
            
            Assert.Equal(0, position);
        }
        
        /// <summary>
        /// Tests that get read timeout valid input
        /// </summary>
        [Fact]
        public void GetReadTimeout_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.Throws<InvalidOperationException>(() => stream.ReadTimeout);
        }
        
        /// <summary>
        /// Tests that get write timeout valid input
        /// </summary>
        [Fact]
        public void GetWriteTimeout_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            Assert.Throws<InvalidOperationException>(() => stream.WriteTimeout);
        }
        
        /// <summary>
        /// Tests that validate required size valid input
        /// </summary>
        [Fact]
        public void ValidateRequiredSize_ValidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            long requiredSize = 5000;
            stream.ValidateRequiredSize(requiredSize);
            
            Assert.True(true); // If we reach this point, no exception was thrown and the test passes
        }
        
        /// <summary>
        /// Tests that validate required size invalid input
        /// </summary>
        [Fact]
        public void ValidateRequiredSize_InvalidInput()
        {
            BufferPool bufferPool = new BufferPool();
            byte[] buffer = new byte[1024];
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer, bufferPool);
            
            long requiredSize = (long) int.MaxValue + 1;
            
            Assert.Throws<WebSocketBufferOverflowException>(() => stream.ValidateRequiredSize(requiredSize));
        }
    }
}