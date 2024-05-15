// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IBufferPoolTest.cs
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
    /// The buffer pool test class
    /// </summary>
    public class IBufferPoolTest
    {
        /// <summary>
        /// Tests that get buffer should return memory stream
        /// </summary>
        [Fact]
        public void GetBuffer_ShouldReturnMemoryStream()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            Assert.IsType<PublicBufferMemoryStream>(buffer);
        }
        
        /// <summary>
        /// Tests that get buffer should return different instances
        /// </summary>
        [Fact]
        public void GetBuffer_ShouldReturnDifferentInstances()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer1 = bufferPool.GetBuffer();
            MemoryStream buffer2 = bufferPool.GetBuffer();
            Assert.NotSame(buffer1, buffer2);
        }
        
        /// <summary>
        /// Tests that get buffer should return pooled memory stream
        /// </summary>
        [Fact]
        public void GetBuffer_ShouldReturnPooledMemoryStream()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer1 = bufferPool.GetBuffer();
            buffer1.Dispose();
            MemoryStream buffer2 = bufferPool.GetBuffer();
            Assert.Equal(buffer1.Length, buffer2.Length);
        }
    }
}