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
            
            await Assert.ThrowsAsync<EndOfStreamException>(() =>  WebSocketFrameReader.ReadAsync(stream, buffer, cancellationToken));
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
    }
}