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
using Alis.Extension.Network.Exceptions;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The web socket implementation test class
    /// </summary>
    public class WebSocketImplementationTest
    {
        /// <summary>
        ///     Tests that send async valid input
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

        }

        /// <summary>
        ///     Tests that receive async valid input
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
        ///     Tests that close async valid input
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
        ///     Tests that send async valid input 7
        /// </summary>
        [Fact]
        public async Task SendAsync_ValidInput_7()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));

            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);

        }

        /// <summary>
        ///     Tests that receive async valid input 6
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_ValidInput_6()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);

            EndOfStreamException result = await Assert.ThrowsAsync<EndOfStreamException>(() => webSocket.ReceiveAsync(buffer, CancellationToken.None));

        }

        /// <summary>
        ///     Tests that close async valid input v 5
        /// </summary>
        [Fact]
        public async Task CloseAsync_ValidInput_v5()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);

            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }

        /// <summary>
        ///     Tests that abort valid input
        /// </summary>
        [Fact]
        public void Abort_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            webSocket.Abort();

            Assert.Equal(WebSocketState.Aborted, webSocket.State);
        }

        /// <summary>
        ///     Tests that close output async valid input
        /// </summary>
        [Fact]
        public async Task CloseOutputAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);

            Assert.Equal(WebSocketState.Closed, webSocket.State);
        }

        /// <summary>
        ///     Tests that sub protocol test
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
        ///     Tests that keep alive interval test
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
        ///     Tests that pong test
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
        ///     Tests that close status test
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
        ///     Tests that close status description test
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
        ///     Tests that handle binary frame test
        /// </summary>
        [Fact]
        public void HandleBinaryFrame_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);

            WebSocketReceiveResult result = webSocket.HandleBinaryFrame(frame, true);

            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
            Assert.True(result.EndOfMessage);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        ///     Tests that handle pong test
        /// </summary>
        [Fact]
        public void HandlePong_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);

            WebSocketReceiveResult result = webSocket.HandlePong(frame, buffer);

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that HandleContinuationFrame returns correct result
        /// </summary>
        [Fact]
        public void HandleContinuationFrame_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);

            WebSocketReceiveResult result = webSocket.HandleContinuationFrame(frame, true);

            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
            Assert.True(result.EndOfMessage);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        /// Tests that HandleTextFrame returns correct result
        /// </summary>
        [Fact]
        public void HandleTextFrame_ReturnsCorrectResult()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 5, new ArraySegment<byte>(Encoding.UTF8.GetBytes("Hello")));

            WebSocketReceiveResult result = webSocket.HandleTextFrame(frame, true);

            Assert.Equal(WebSocketMessageType.Text, result.MessageType);
            Assert.True(result.EndOfMessage);
        }

        /// <summary>
        /// Tests that HandleTextFrame sets continuation type when not final frame
        /// </summary>
        [Fact]
        public void HandleTextFrame_NotFinalFrame_SetsContinuationType()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), null, false, true, null);
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.TextFrame, 5, new ArraySegment<byte>(Encoding.UTF8.GetBytes("Hello")));

            WebSocketReceiveResult result = webSocket.HandleTextFrame(frame, false);

            Assert.Equal(WebSocketMessageType.Text, result.MessageType);
        }

        /// <summary>
        /// Tests that HandlePing returns null and sends pong
        /// </summary>
        [Fact]
        public async Task HandlePing_ReturnsNull()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), null, false, true, null);
            byte[] data = Encoding.UTF8.GetBytes("ping");
            ArraySegment<byte> buffer = new ArraySegment<byte>(data);
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.Ping, data.Length, buffer);

            using CancellationTokenSource cts = new CancellationTokenSource();
            WebSocketReceiveResult result = await webSocket.HandlePing(frame, buffer, cts);

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that HandleDefault throws NotSupportedException for unknown opcode
        /// </summary>
        [Fact]
        public async Task HandleDefault_UnknownOpCode_ThrowsNotSupportedException()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), null, false, true, null);
            WebSocketFrame frame = new WebSocketFrame(true, (WebSocketOpCode)255, 0, new ArraySegment<byte>(new byte[0]));

            await Assert.ThrowsAsync<NotSupportedException>(() => webSocket.HandleDefault(frame));
        }

        /// <summary>
        /// Tests that RespondToCloseFrame handles CloseSent state
        /// </summary>
        [Fact]
        public async Task RespondToCloseFrame_CloseSentState_TransitionsToClosed()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), null, false, true, null);
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.ConnectionClose, 0,
                WebSocketCloseStatus.NormalClosure, "Normal", new ArraySegment<byte>(new byte[0]));

            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test", CancellationToken.None);
            WebSocketReceiveResult result = await webSocket.RespondToCloseFrame(frame, new ArraySegment<byte>(new byte[0]), CancellationToken.None);

            Assert.Equal(WebSocketState.Closed, webSocket.State);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, result.CloseStatus);
        }

        /// <summary>
        /// Tests that RespondToCloseFrame handles Open state by sending close response
        /// </summary>
        [Fact]
        public async Task RespondToCloseFrame_OpenState_SendsCloseResponse()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), null, false, true, null);
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.ConnectionClose, 0,
                WebSocketCloseStatus.NormalClosure, "Normal", new ArraySegment<byte>(new byte[0]));

            WebSocketReceiveResult result = await webSocket.RespondToCloseFrame(frame, new ArraySegment<byte>(new byte[0]), CancellationToken.None);

            Assert.Equal(WebSocketState.CloseReceived, webSocket.State);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, result.CloseStatus);
        }

        /// <summary>
        /// Tests that BuildClosePayload returns payload with status only when description is null
        /// </summary>
        [Fact]
        public void BuildClosePayload_NullDescription_ReturnsStatusOnly()
        {
            ArraySegment<byte> result = WebSocketImplementation.BuildClosePayload(WebSocketCloseStatus.NormalClosure, null);

            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Tests that BuildClosePayload returns payload with status and description
        /// </summary>
        [Fact]
        public void BuildClosePayload_WithDescription_ReturnsStatusAndDescription()
        {
            ArraySegment<byte> result = WebSocketImplementation.BuildClosePayload(WebSocketCloseStatus.NormalClosure, "Closing normally");

            Assert.True(result.Count > 2);
        }

        /// <summary>
        /// Tests that ValidatePayloadSize throws for oversized payload
        /// </summary>
        [Fact]
        public void ValidatePayloadSize_Oversized_ThrowsInvalidOperationException()
        {
            byte[] largeData = new byte[126];
            ArraySegment<byte> payload = new ArraySegment<byte>(largeData);

            Assert.Throws<InvalidOperationException>(() => WebSocketImplementation.ValidatePayloadSize(payload));
        }

        /// <summary>
        /// Tests that ValidatePayloadSize does not throw for valid payload
        /// </summary>
        [Fact]
        public void ValidatePayloadSize_ValidSize_DoesNotThrow()
        {
            byte[] data = new byte[100];
            ArraySegment<byte> payload = new ArraySegment<byte>(data);

            WebSocketImplementation.ValidatePayloadSize(payload);
        }

        /// <summary>
        /// Tests that Constructor with negative keepAlive throws
        /// </summary>
        [Fact]
        public void Constructor_NegativeKeepAlive_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
                new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                    TimeSpan.FromTicks(-1), null, false, true, null));
        }

        /// <summary>
        /// Tests that Constructor with zero keepAlive interval does not throw
        /// </summary>
        [Fact]
        public void Constructor_ZeroKeepAlive_DoesNotThrow()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.Zero, null, false, true, null);

            Assert.NotNull(webSocket);
        }

        /// <summary>
        /// Tests that GetOppCode returns ContinuationFrame when IsContinuationFrame is true
        /// </summary>
        [Fact]
        public void GetOppCode_ContinuationFrame_ReturnsContinuationOpCode()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);

            webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("test")), WebSocketMessageType.Text, false, CancellationToken.None).Wait();
            WebSocketOpCode result = webSocket.GetOppCode(WebSocketMessageType.Text);

            Assert.Equal(WebSocketOpCode.ContinuationFrame, result);
        }

        /// <summary>
        /// Tests that GetOppCode returns BinaryFrame for binary message type
        /// </summary>
        [Fact]
        public void GetOppCode_Binary_ReturnsBinaryFrame()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);

            WebSocketOpCode result = webSocket.GetOppCode(WebSocketMessageType.Binary);

            Assert.Equal(WebSocketOpCode.BinaryFrame, result);
        }

        /// <summary>
        /// Tests that GetOppCode returns TextFrame for text message type
        /// </summary>
        [Fact]
        public void GetOppCode_Text_ReturnsTextFrame()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);

            WebSocketOpCode result = webSocket.GetOppCode(WebSocketMessageType.Text);

            Assert.Equal(WebSocketOpCode.TextFrame, result);
        }

        /// <summary>
        /// Tests that GetOppCode throws for Close message type
        /// </summary>
        [Fact]
        public void GetOppCode_Close_ThrowsNotSupportedException()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);

            Assert.Throws<NotSupportedException>(() => webSocket.GetOppCode(WebSocketMessageType.Close));
        }

        /// <summary>
        /// Tests that SendPingAsync with oversized payload throws
        /// </summary>
        [Fact]
        public async Task SendPingAsync_OversizedPayload_ThrowsInvalidOperationException()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            byte[] largeData = new byte[126];
            ArraySegment<byte> payload = new ArraySegment<byte>(largeData);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                webSocket.SendPingAsync(payload, CancellationToken.None));
        }

        /// <summary>
        /// Tests that SendPingAsync does not throw when state is not Open
        /// </summary>
        [Fact]
        public async Task SendPingAsync_NotOpen_DoesNotThrow()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            webSocket.Abort();
            byte[] data = new byte[10];
            ArraySegment<byte> payload = new ArraySegment<byte>(data);

            await webSocket.SendPingAsync(payload, CancellationToken.None);
        }

        /// <summary>
        /// Tests that SendPongAsync with oversized payload does not throw (validated by ValidatePayloadSize)
        /// </summary>
        [Fact]
        public async Task SendPongAsync_OversizedPayload_ThrowsInvalidOperationException()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            byte[] largeData = new byte[126];
            ArraySegment<byte> payload = new ArraySegment<byte>(largeData);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                webSocket.SendPongAsync(payload, CancellationToken.None));
        }

        /// <summary>
        /// Tests that SendPongAsync does not throw when state is not Open
        /// </summary>
        [Fact]
        public async Task SendPongAsync_NotOpen_DoesNotThrow()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            webSocket.Abort();
            byte[] data = new byte[10];
            ArraySegment<byte> payload = new ArraySegment<byte>(data);

            await webSocket.SendPongAsync(payload, CancellationToken.None);
        }

        /// <summary>
        /// Tests that OnPong invokes the Pong event
        /// </summary>
        [Fact]
        public void OnPong_InvokesPongEvent()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            bool eventRaised = false;
            webSocket.Pong += (sender, args) => eventRaised = true;

            webSocket.OnPong(new PongEventArgs(new ArraySegment<byte>(new byte[0])));

            Assert.True(eventRaised);
        }

        /// <summary>
        /// Tests that HandleExceptions calls CloseOutputAutoTimeoutAsync when state is Open and rethrows
        /// </summary>
        [Fact]
        public async Task HandleExceptions_OpenState_CallsCloseAndRethrows()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                webSocket.HandleExceptions(new InvalidOperationException("test")));
        }

        /// <summary>
        /// Tests that HandleExceptions rethrows without close when state is not Open
        /// </summary>
        [Fact]
        public async Task HandleExceptions_NotOpen_Rethrows()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            webSocket.Abort();

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                webSocket.HandleExceptions(new InvalidOperationException("test")));
        }

        /// <summary>
        /// Tests that Dispose does not throw for open state
        /// </summary>
        [Fact]
        public void Dispose_OpenState_DoesNotThrow()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);

            webSocket.Dispose();
        }

        /// <summary>
        /// Tests that Dispose does not throw for closed state
        /// </summary>
        [Fact]
        public void Dispose_ClosedState_DoesNotThrow()
        {
            WebSocketImplementation webSocket = new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            webSocket.Abort();

            webSocket.Dispose();
        }
    }
}