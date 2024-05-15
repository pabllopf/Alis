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
    }
}