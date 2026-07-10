// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketImplementationRemainingCoverageTests.cs
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
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     Coverage tests for WebSocketImplementation targeting uncovered branches.
    /// </summary>
    public class WebSocketImplementationRemainingCoverageTests
    {
        /// <summary>
        ///     Creates a WebSocketImplementation with default parameters.
        /// </summary>
        private static WebSocketImplementation CreateWs(
            Func<MemoryStream> recycledFactory = null,
            Stream stream = null,
            bool includeException = false,
            TimeSpan? keepAlive = null)
        {
            return new WebSocketImplementation(
                Guid.NewGuid(),
                recycledFactory ?? (() => new MemoryStream()),
                stream ?? new MemoryStream(),
                keepAlive ?? TimeSpan.FromSeconds(30),
                null,
                includeException,
                true,
                null);
        }

        /// <summary>
        ///     Tests that GetBuffer returns correct buffer when TryGetBuffer succeeds.
        /// </summary>
        [Fact]
        public void GetBuffer_TryGetBufferSucceeds_ReturnsBuffer()
        {
            byte[] arr = new byte[100];
            using var ms = new MemoryStream(arr, 0, arr.Length, true, true);
            byte[] data = Encoding.UTF8.GetBytes("Hello");
            ms.Write(data, 0, data.Length);

            var ws = CreateWs();
            ArraySegment<byte> result = ws.GetBuffer(ms);

            Assert.Equal(data.Length, result.Count);
        }

        /// <summary>
        ///     Tests that GetBuffer uses ToArray fallback when TryGetBuffer fails.
        /// </summary>
        [Fact]
        public void GetBuffer_TryGetBufferFails_UsesToArray()
        {
            using var ms = new MemoryStream();
            byte[] data = Encoding.UTF8.GetBytes("HelloWorld");
            ms.Write(data, 0, data.Length);

            var ws = CreateWs();
            ArraySegment<byte> result = ws.GetBuffer(ms);

            Assert.Equal(data.Length, result.Count);
        }

        /// <summary>
        ///     Tests that HandlePing returns null when buffer has null array.
        /// </summary>
        [Fact]
        public async Task HandlePing_NullArray_ReturnsNull()
        {
            var ws = CreateWs();
            byte[] payload = Encoding.UTF8.GetBytes("ping");
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.Ping, payload.Length, new ArraySegment<byte>(payload));
            using var cts = new CancellationTokenSource();

            WebSocketReceiveResult result = await ws.HandlePing(frame, default, cts);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that HandlePong returns null when buffer has null array.
        /// </summary>
        [Fact]
        public void HandlePong_NullArray_ReturnsNull()
        {
            var ws = CreateWs();
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.Pong, 0, default);

            WebSocketReceiveResult result = ws.HandlePong(frame, default);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that CloseAsync does not send close when state is not Open.
        /// </summary>
        [Fact]
        public async Task CloseAsync_StateNotOpen_LogsOnly()
        {
            var ws = CreateWs();
            ws.Abort();

            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "test", CancellationToken.None);

            Assert.Equal(WebSocketState.Aborted, ws.State);
        }

        /// <summary>
        ///     Tests that CloseOutputAsync does not send close when state is not Open.
        /// </summary>
        [Fact]
        public async Task CloseOutputAsync_StateNotOpen_LogsOnly()
        {
            var ws = CreateWs();
            ws.Abort();

            await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "test", CancellationToken.None);

            Assert.Equal(WebSocketState.Aborted, ws.State);
        }

        /// <summary>
        ///     Tests that CloseOutputAutoTimeoutAsync handles normal path without throwing.
        /// </summary>
        [Fact]
        public async Task CloseOutputAutoTimeoutAsync_NormalPath_DoesNotThrow()
        {
            var ws = CreateWs();
            Exception ex = new Exception("test");

            await ws.CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError, "error", ex);

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     Tests that CloseOutputAutoTimeoutAsync appends exception when IncludeExceptionInCloseResponse is true.
        /// </summary>
        [Fact]
        public async Task CloseOutputAutoTimeoutAsync_WithIncludeException_DoesNotThrow()
        {
            var ws = CreateWs(includeException: true);
            Exception ex = new Exception("test");

            await ws.CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError, "error", ex);

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     Tests that GetOppCode throws for unknown message type.
        /// </summary>
        [Fact]
        public void GetOppCode_InvalidMessageType_ThrowsNotSupportedException()
        {
            var ws = CreateWs();
            WebSocketMessageType invalid = (WebSocketMessageType)255;

            Assert.Throws<NotSupportedException>(() => ws.GetOppCode(invalid));
        }

        /// <summary>
        ///     Tests that RespondToCloseFrame does not send close when state is unexpected.
        /// </summary>
        [Fact]
        public async Task RespondToCloseFrame_UnexpectedState_DoesNotSendClose()
        {
            var ws = CreateWs();
            ws.Abort();
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.ConnectionClose, 0,
                WebSocketCloseStatus.NormalClosure, "Normal", new ArraySegment<byte>(new byte[0]));

            WebSocketReceiveResult result = await ws.RespondToCloseFrame(frame, new ArraySegment<byte>(new byte[0]), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(WebSocketState.Aborted, ws.State);
        }

        /// <summary>
        ///     Tests that ReadWebSocketFrame reads from cursor when continuation is pending.
        /// </summary>
        [Fact]
        public async Task ReadWebSocketFrame_WithCursorContinuation_ReadsFromCursor()
        {
            var ws = CreateWs();
            byte[] data = Encoding.UTF8.GetBytes("HelloWorld");
            ws.Stream.Write(data, 0, data.Length);
            ws.Stream.Position = 0;
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, data.Length, new ArraySegment<byte>(new byte[0]));
            ws.ReadCursor = new WebSocketReadCursor(frame, 0, data.Length);

            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            WebSocketFrame result = await ws.ReadWebSocketFrame(buffer, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(WebSocketOpCode.TextFrame, result.OpCode);
        }

        /// <summary>
        ///     Tests that ReadWebSocketFrame catch block handles exceptions and closes.
        /// </summary>
        [Fact]
        public async Task ReadWebSocketFrame_CatchBlock_Throws()
        {
            var ws = CreateWs(includeException: true);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);

            await Assert.ThrowsAsync<EndOfStreamException>(() =>
                ws.ReadWebSocketFrame(buffer, CancellationToken.None));

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     Tests that SendPongFrame exception triggers CloseOutputAutoTimeout.
        /// </summary>
        [Fact]
        public async Task SendPongFrame_Exception_CallsCloseOutputAutoTimeout()
        {
            var ws = CreateWs(stream: new ThrowingWriteStream());
            byte[] data = new byte[10];
            ArraySegment<byte> payload = new ArraySegment<byte>(data);

            await Assert.ThrowsAsync<IOException>(() =>
                ws.SendPongFrame(payload, CancellationToken.None));

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     Tests that Dispose catches exception from stream close.
        /// </summary>
        [Fact]
        public void Dispose_StreamCloseThrows_Caught()
        {
            var ws = CreateWs(stream: new ThrowingOnDisposeStream());

            ws.Dispose();

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     A MemoryStream that throws on WriteAsync for testing error paths.
        /// </summary>
        private sealed class ThrowingWriteStream : MemoryStream
        {
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                throw new IOException("Simulated write error");
            }
        }

        /// <summary>
        ///     A MemoryStream that throws on Dispose for testing error handling.
        /// </summary>
        private sealed class ThrowingOnDisposeStream : MemoryStream
        {
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    throw new InvalidOperationException("Simulated close error");
                }
            }
        }
    }
}
