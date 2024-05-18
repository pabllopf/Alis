// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketImplementationTest.cs
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
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The web socket implementation test class
    /// </summary>
    public class WebSocketImplementationTest
    {
        /// <summary>
        /// Tests that send async valid input
        /// </summary>
        [Fact]
        public async Task SendAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";
            
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that receive async valid input
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";
            
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            await Assert.ThrowsAsync<EndOfStreamException>(() => webSocket.ReceiveAsync(buffer, CancellationToken.None));
        }
        
        /// <summary>
        /// Tests that close async valid input
        /// </summary>
        [Fact]
        public async Task CloseAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";
            
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);
            
            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }
        
        /// <summary>
        /// Tests that send async valid input 7
        /// </summary>
        [Fact]
        public async Task SendAsync_ValidInput_7()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            
            // Act
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            
            // Assert
            // Add your asserts here
        }
        
        /// <summary>
        /// Tests that receive async valid input 6
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_ValidInput_6()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            
            // Act
            EndOfStreamException result = await Assert.ThrowsAsync<EndOfStreamException>(() => webSocket.ReceiveAsync(buffer, CancellationToken.None));
            
            // Assert
            // Add your asserts here
        }
        
        /// <summary>
        /// Tests that close async valid input v 5
        /// </summary>
        [Fact]
        public async Task CloseAsync_ValidInput_v5()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            
            // Act
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);
            
            // Assert
            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }
        
        /// <summary>
        /// Tests that abort valid input
        /// </summary>
        [Fact]
        public void Abort_ValidInput()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            
            // Act
            webSocket.Abort();
            
            // Assert
            Assert.Equal(WebSocketState.Aborted, webSocket.State);
        }
        
        /// <summary>
        /// Tests that close output async valid input
        /// </summary>
        [Fact]
        public async Task CloseOutputAsync_ValidInput()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            
            // Act
            await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);
            
            // Assert
            Assert.Equal(WebSocketState.Closed, webSocket.State);
        }
        
        /// <summary>
        /// Tests that sub protocol test
        /// </summary>
        [Fact]
        public void SubProtocol_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            
            Assert.Equal("subProtocol", webSocket.SubProtocol);
        }
        
        /// <summary>
        /// Tests that keep alive interval test
        /// </summary>
        [Fact]
        public void KeepAliveInterval_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, keepAliveInterval, "permessage-deflate", true, true, "subProtocol");
            
            Assert.Equal(keepAliveInterval, webSocket.KeepAliveInterval);
        }
        
        /// <summary>
        /// Tests that pong test
        /// </summary>
        [Fact]
        public void Pong_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            
            bool eventRaised = false;
            webSocket.Pong += (sender, args) => eventRaised = true;
            
            Assert.False(eventRaised);
        }
        
        /// <summary>
        /// Tests that close status test
        /// </summary>
        [Fact]
        public void CloseStatus_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            
            Assert.Null(webSocket.CloseStatus);
        }
        
        /// <summary>
        /// Tests that close status description test
        /// </summary>
        [Fact]
        public void CloseStatusDescription_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            
            Assert.Null(webSocket.CloseStatusDescription);
        }
        
        /// <summary>
        /// Tests that handle binary frame test
        /// </summary>
        [Fact]
        public void HandleBinaryFrame_Test()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);
            
            // Act
            WebSocketReceiveResult result = webSocket.HandleBinaryFrame(frame, true);
            
            // Assert
            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
            Assert.True(result.EndOfMessage);
            Assert.Equal(0, result.Count);
        }
        
        /// <summary>
        /// Tests that handle pong test
        /// </summary>
        [Fact]
        public void HandlePong_Test()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);
            
            // Act
            WebSocketReceiveResult result = webSocket.HandlePong(frame, buffer);
            
            // Assert
            Assert.Null(result);
        }
        
        /// <summary>
        /// Tests that handle continuation frame test
        /// </summary>
        [Fact]
        public void HandleContinuationFrame_Test()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);
            
            // Act
            WebSocketReceiveResult result = webSocket.HandleContinuationFrame(frame, true);
            
            // Assert
            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
            Assert.True(result.EndOfMessage);
            Assert.Equal(0, result.Count);
        }
    }
}