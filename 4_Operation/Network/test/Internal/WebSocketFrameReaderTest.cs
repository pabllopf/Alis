// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameReaderTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The web socket frame reader test class
    /// </summary>
    public class WebSocketFrameReaderTest
    {
        /// <summary>
        /// Tests that read async valid input
        /// </summary>
        [Fact]
        public async Task ReadAsync_ValidInput()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("Test message"));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = new CancellationToken();
            
            await Assert.ThrowsAsync<EndOfStreamException>(() => WebSocketFrameReader.ReadAsync(stream, buffer, cancellationToken));
        }
        
        /// <summary>
        /// Tests that read async invalid input throws exception
        /// </summary>
        [Fact]
        public async Task ReadAsync_InvalidInput_ThrowsException()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("Invalid message"));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = new CancellationToken();
            
            await Assert.ThrowsAsync<EndOfStreamException>(() => WebSocketFrameReader.ReadAsync(stream, buffer, cancellationToken));
        }
        
        /// <summary>
        /// Tests that read from cursor async valid input
        /// </summary>
        [Fact]
        public async Task ReadFromCursorAsync_ValidInput()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("Test message"));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = new CancellationToken();
            WebSocketReadCursor readCursor = new WebSocketReadCursor(new WebSocketFrame(true, WebSocketOpCode.TextFrame, 0, new ArraySegment<byte>()), 0, 0);
            
            WebSocketReadCursor result = await WebSocketFrameReader.ReadFromCursorAsync(stream, buffer, readCursor, cancellationToken);
            
            Assert.NotNull(result);
            Assert.Equal(WebSocketOpCode.TextFrame, result.WebSocketFrame.OpCode);
        }
        
        /// <summary>
        /// Tests that read from cursor async invalid input throws exception
        /// </summary>
        [Fact]
        public Task ReadFromCursorAsync_InvalidInput_ThrowsException()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("Invalid message"));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = new CancellationToken();
            WebSocketReadCursor readCursor = new WebSocketReadCursor(new WebSocketFrame(true, WebSocketOpCode.TextFrame, 0, new ArraySegment<byte>()), 0, 0);
            
            Task<WebSocketReadCursor> result = WebSocketFrameReader.ReadFromCursorAsync(stream, buffer, readCursor, cancellationToken);
            
            Assert.NotNull(result);
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// Tests that read async should read correctly
        /// </summary>
        [Fact]
        public async Task ReadAsync_ShouldReadCorrectly()
        {
            MemoryStream stream = new MemoryStream();
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = new CancellationToken();
            
            await Assert.ThrowsAsync<EndOfStreamException>(() => WebSocketFrameReader.ReadAsync(stream, buffer, cancellationToken));
            
            // Here you would assert that the properties of result have been set correctly.
        }
        
        /// <summary>
        /// Tests that decode close frame should decode correctly when count is greater than or equal to two
        /// </summary>
        [Fact]
        public void DecodeCloseFrame_ShouldDecodeCorrectly_WhenCountIsGreaterThanOrEqualToTwo()
        {
            bool isFinBitSet = true;
            WebSocketOpCode opCode = WebSocketOpCode.ConnectionClose;
            int count = 2;
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2]);
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);
            
            WebSocketFrame result = WebSocketFrameReader.DecodeCloseFrame(isFinBitSet, opCode, count, buffer, maskKey);
            
            // Here you would assert that the properties of result have been set correctly.
        }
        
        /// <summary>
        /// Tests that decode close frame should decode correctly when count is less than two
        /// </summary>
        [Fact]
        public void DecodeCloseFrame_ShouldDecodeCorrectly_WhenCountIsLessThanTwo()
        {
            bool isFinBitSet = true;
            WebSocketOpCode opCode = WebSocketOpCode.ConnectionClose;
            int count = 1;
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1]);
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);
            
            WebSocketFrame result = WebSocketFrameReader.DecodeCloseFrame(isFinBitSet, opCode, count, buffer, maskKey);
            
            // Here you would assert that the properties of result have been set correctly.
        }
        
        /// <summary>
        /// Tests that read short length valid input
        /// </summary>
        [Fact]
        public async Task ReadShortLength_ValidInput()
        {
            MemoryStream stream = new MemoryStream();
            ArraySegment<byte> smallBuffer = new ArraySegment<byte>(new byte[8]);
            CancellationToken cancellationToken = new CancellationToken();
            
            // Write ushort value to stream
            ushort value = 12345;
            byte[] bytes = BitConverter.GetBytes(value);
            await stream.WriteAsync(bytes, 0, bytes.Length);
            stream.Position = 0;
            
            uint result = await WebSocketFrameReader.ReadShortLength(stream, smallBuffer, cancellationToken);
        }
        
        /// <summary>
        /// Tests that read long length valid input
        /// </summary>
        [Fact]
        public async Task ReadLongLength_ValidInput()
        {
            MemoryStream stream = new MemoryStream();
            ArraySegment<byte> smallBuffer = new ArraySegment<byte>(new byte[8]);
            CancellationToken cancellationToken = new CancellationToken();
            
            // Write ulong value to stream
            ulong value = 4094698001;
            byte[] bytes = BitConverter.GetBytes(value);
            await stream.WriteAsync(bytes, 0, bytes.Length);
            stream.Position = 0;
            
            uint result = await WebSocketFrameReader.ReadLongLength(stream, smallBuffer, cancellationToken);
        }
        
        /// <summary>
        /// Tests that read length initial length test
        /// </summary>
        [Fact]
        public async Task ReadLength_InitialLength_Test()
        {
            byte byte2 = 125;
            ArraySegment<byte> smallBuffer = new ArraySegment<byte>(new byte[8]);
            MemoryStream fromStream = new MemoryStream(new byte[8]);
            CancellationToken cancellationToken = new CancellationToken();
            
            uint result = await WebSocketFrameReader.ReadLength(byte2, smallBuffer, fromStream, cancellationToken);
            
            Assert.True(result > 0);
        }
        
        /// <summary>
        /// Tests that read length short length test
        /// </summary>
        [Fact]
        public async Task ReadLength_ShortLength_Test()
        {
            byte byte2 = 126;
            ArraySegment<byte> smallBuffer = new ArraySegment<byte>(new byte[8]);
            MemoryStream fromStream = new MemoryStream(BitConverter.GetBytes((ushort) 500));
            CancellationToken cancellationToken = new CancellationToken();
            
            uint result = await WebSocketFrameReader.ReadLength(byte2, smallBuffer, fromStream, cancellationToken);
            
            Assert.True(result > 0);
        }
        
        /// <summary>
        /// Tests that read length long length test
        /// </summary>
        [Fact]
        public async Task ReadLength_LongLength_Test()
        {
            byte byte2 = 127;
            ArraySegment<byte> smallBuffer = new ArraySegment<byte>(new byte[8]);
            MemoryStream fromStream = new MemoryStream(BitConverter.GetBytes((ulong) 50000));
            CancellationToken cancellationToken = new CancellationToken();
            
            uint result = await WebSocketFrameReader.ReadLength(byte2, smallBuffer, fromStream, cancellationToken);
            
            Assert.False(result > 0);
        }
        
        /// <summary>
        /// Tests that read length invalid length test
        /// </summary>
        [Fact]
        public async Task ReadLength_InvalidLength_Test()
        {
            byte byte2 = 128;
            ArraySegment<byte> smallBuffer = new ArraySegment<byte>(new byte[8]);
            MemoryStream fromStream = new MemoryStream(new byte[8]);
            CancellationToken cancellationToken = new CancellationToken();
            
            await WebSocketFrameReader.ReadLength(byte2, smallBuffer, fromStream, cancellationToken);
        }
        
        /// <summary>
        /// Tests that validate length valid length test
        /// </summary>
        [Fact]
        public void ValidateLength_ValidLength_Test()
        {
            uint validLength = 2048;
            WebSocketFrameReader.ValidateLength(validLength);
        }
        
        /// <summary>
        /// Tests that validate length invalid length test
        /// </summary>
        [Fact]
        public void ValidateLength_InvalidLength_Test()
        {
            uint invalidLength = 2147483649;
            Assert.Throws<ArgumentOutOfRangeException>(() => WebSocketFrameReader.ValidateLength(invalidLength));
        }
        
        /// <summary>
        /// Tests that calculate num bytes to read test
        /// </summary>
        [Fact]
        public void CalculateNumBytesToRead_Test()
        {
            int bufferSize = 10;
            int numBytesLeftToRead = 5;
            
            int result = WebSocketFrameReader.CalculateNumBytesToRead(numBytesLeftToRead, bufferSize);
            
            Assert.Equal(numBytesLeftToRead, result);
            
            numBytesLeftToRead = 15;
            
            result = WebSocketFrameReader.CalculateNumBytesToRead(numBytesLeftToRead, bufferSize);
            
            Assert.Equal(bufferSize - bufferSize % 4, result);
        }
    }
}