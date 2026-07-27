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
        ///     Tests that HandleWebSocketOpCodes dispatches Ping correctly.
        /// </summary>
        [Fact]
        public async Task HandleWebSocketOpCodes_Ping_ReturnsNull()
        {
            var ws = CreateWs();
            byte[] data = Encoding.UTF8.GetBytes("ping");
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.Ping, data.Length, new ArraySegment<byte>(data));
            using var cts = new CancellationTokenSource();
            ArraySegment<byte> buffer = new ArraySegment<byte>(data);

            WebSocketReceiveResult result = await ws.HandleWebSocketOpCodes(frame, buffer, cts, true);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that HandleWebSocketOpCodes dispatches Pong correctly.
        /// </summary>
        [Fact]
        public void HandleWebSocketOpCodes_Pong_ReturnsNull()
        {
            var ws = CreateWs();
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.Pong, 0, default);
            using var cts = new CancellationTokenSource();

            WebSocketReceiveResult result = ws.HandleWebSocketOpCodes(frame, default, cts, true).Result;

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that HandleWebSocketOpCodes dispatches TextFrame correctly.
        /// </summary>
        [Fact]
        public void HandleWebSocketOpCodes_TextFrame_ReturnsResult()
        {
            var ws = CreateWs();
            byte[] data = Encoding.UTF8.GetBytes("Hello");
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, data.Length, new ArraySegment<byte>(data));
            using var cts = new CancellationTokenSource();

            WebSocketReceiveResult result = ws.HandleWebSocketOpCodes(frame, default, cts, true).Result;

            Assert.Equal(WebSocketMessageType.Text, result.MessageType);
        }

        /// <summary>
        ///     Tests that HandleWebSocketOpCodes dispatches BinaryFrame correctly.
        /// </summary>
        [Fact]
        public void HandleWebSocketOpCodes_BinaryFrame_ReturnsResult()
        {
            var ws = CreateWs();
            byte[] data = Encoding.UTF8.GetBytes("Hello");
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, data.Length, new ArraySegment<byte>(data));
            using var cts = new CancellationTokenSource();

            WebSocketReceiveResult result = ws.HandleWebSocketOpCodes(frame, default, cts, true).Result;

            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
        }

        /// <summary>
        ///     Tests that HandleWebSocketOpCodes dispatches ContinuationFrame correctly.
        /// </summary>
        [Fact]
        public void HandleWebSocketOpCodes_ContinuationFrame_ReturnsResult()
        {
            var ws = CreateWs();
            byte[] data = Encoding.UTF8.GetBytes("Hello");
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.ContinuationFrame, data.Length, new ArraySegment<byte>(data));
            using var cts = new CancellationTokenSource();

            WebSocketReceiveResult result = ws.HandleWebSocketOpCodes(frame, default, cts, true).Result;

            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
        }

        /// <summary>
        ///     Tests that HandleWebSocketOpCodes dispatches default for unknown opcode.
        /// </summary>
        [Fact]
        public async Task HandleWebSocketOpCodes_UnknownOpCode_ThrowsNotSupportedException()
        {
            var ws = CreateWs();
            WebSocketFrame frame = new WebSocketFrame(true, (WebSocketOpCode)255, 0, new ArraySegment<byte>(new byte[0]));
            using var cts = new CancellationTokenSource();

            await Assert.ThrowsAsync<NotSupportedException>(() =>
                ws.HandleWebSocketOpCodes(frame, default, cts, true));
        }

        /// <summary>
        ///     Tests that HandleBinaryFrame with non-final frame sets continuation type to Binary.
        /// </summary>
        [Fact]
        public void HandleBinaryFrame_NotFinalFrame_SetsContinuationType()
        {
            var ws = CreateWs();
            byte[] data = Encoding.UTF8.GetBytes("Hello");
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.BinaryFrame, data.Length, new ArraySegment<byte>(data));

            WebSocketReceiveResult result = ws.HandleBinaryFrame(frame, false);

            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
            Assert.False(result.EndOfMessage);
        }

        /// <summary>
        ///     Tests that HandlePong with non-null array and event handler invokes the event.
        /// </summary>
        [Fact]
        public void HandlePong_WithEventHandler_InvokesEvent()
        {
            var ws = CreateWs();
            byte[] data = Encoding.UTF8.GetBytes("pong");
            ArraySegment<byte> buffer = new ArraySegment<byte>(data);
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.Pong, data.Length, buffer);
            bool eventRaised = false;
            ws.Pong += (_, _) => eventRaised = true;

            WebSocketReceiveResult result = ws.HandlePong(frame, buffer);

            Assert.True(eventRaised);
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that Dispose catches OperationCanceledException from CloseOutputAsync.
        /// </summary>
        [Fact]
        public void Dispose_CloseOutputThrowsOperationCanceled_Caught()
        {
            var ws = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new OperationCanceledMemoryStream(),
                TimeSpan.FromSeconds(30),
                null,
                false,
                true,
                null);

            ws.Dispose();

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     Tests that CloseOutputAutoTimeoutAsync catches OperationCanceledException.
        /// </summary>
        [Fact]
        public async Task CloseOutputAutoTimeoutAsync_OperationCanceled_Caught()
        {
            var ws = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new OperationCanceledMemoryStream(),
                TimeSpan.FromSeconds(30),
                null,
                true,
                true,
                null);

            await ws.CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError, "error",
                new Exception("test"));

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     Tests that CloseOutputAutoTimeoutAsync catches generic Exception from CloseOutputAsync.
        /// </summary>
        [Fact]
        public async Task CloseOutputAutoTimeoutAsync_GenericException_Caught()
        {
            var ws = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new ThrowingWriteStream(),
                TimeSpan.FromSeconds(30),
                null,
                true,
                true,
                null);

            await ws.CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError, "error",
                new Exception("test"));

            Assert.Equal(WebSocketState.Closed, ws.State);
        }

        /// <summary>
        ///     Tests that ReceiveAsync succeeds when a valid frame is available.
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_ValidFrame_ReturnsResult()
        {
            WebSocketImplementation ws = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.FromSeconds(30),
                null,
                false,
                false,
                null);

            byte[] payload = Encoding.UTF8.GetBytes("Hello");
            MemoryStream frameStream = new MemoryStream();
            WebSocketFrameWriter.Write(WebSocketOpCode.TextFrame, new ArraySegment<byte>(payload), frameStream, true, false);
            byte[] frameData = frameStream.ToArray();
            ws.Stream.Write(frameData, 0, frameData.Length);
            ws.Stream.Position = 0;

            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            WebSocketReceiveResult result = await ws.ReceiveAsync(buffer, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(WebSocketMessageType.Text, result.MessageType);
        }

        /// <summary>
        ///     Tests that ReceiveAsync handles non-final frame correctly (short-circuit IsFinBitSet check).
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_NonFinalFrame_ReturnsResult()
        {
            WebSocketImplementation ws = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.FromSeconds(30),
                null,
                false,
                false,
                null);

            byte[] payload = Encoding.UTF8.GetBytes("Hello");
            MemoryStream frameStream = new MemoryStream();
            WebSocketFrameWriter.Write(WebSocketOpCode.TextFrame, new ArraySegment<byte>(payload), frameStream, false, false);
            byte[] frameData = frameStream.ToArray();
            ws.Stream.Write(frameData, 0, frameData.Length);
            ws.Stream.Position = 0;

            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            WebSocketReceiveResult result = await ws.ReceiveAsync(buffer, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(WebSocketMessageType.Text, result.MessageType);
            Assert.False(result.EndOfMessage);
        }

        /// <summary>
        ///     Tests that ReceiveAsync with disconnected InternalReadCts throws.
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_InternalReadCtsCancelled_Throws()
        {
            WebSocketImplementation ws = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.FromSeconds(30),
                null,
                false,
                false,
                null);

            ws.InternalReadCts.Cancel();
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);

            await Assert.ThrowsAsync<TaskCanceledException>(() =>
                ws.ReceiveAsync(buffer, CancellationToken.None));
        }

        /// <summary>
        ///     Tests OnPong with null handler (covers the null branch of ?. operator).
        /// </summary>
        [Fact]
        public void OnPong_NullHandler_DoesNotThrow()
        {
            var ws = CreateWs();
            ws.OnPong(new PongEventArgs(new ArraySegment<byte>(new byte[0])));
        }

        /// <summary>
        ///     A MemoryStream that throws OperationCanceledException on write for testing cancellation paths.
        /// </summary>
        internal sealed class OperationCanceledMemoryStream : MemoryStream
        {
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                throw new OperationCanceledException();
            }
        }

        /// <summary>
        ///     A MemoryStream that throws on WriteAsync for testing error paths.
        /// </summary>
        internal sealed class ThrowingWriteStream : MemoryStream
        {
            /// <summary>
            /// Writes the buffer
            /// </summary>
            /// <param name="buffer">The buffer</param>
            /// <param name="offset">The offset</param>
            /// <param name="count">The count</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <exception cref="IOException">Simulated write error</exception>
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                throw new IOException("Simulated write error");
            }
        }

        /// <summary>
        ///     A MemoryStream that throws on Dispose for testing error handling.
        /// </summary>
        internal sealed class ThrowingOnDisposeStream : MemoryStream
        {
            /// <summary>
            /// Disposes the disposing
            /// </summary>
            /// <param name="disposing">The disposing</param>
            /// <exception cref="InvalidOperationException">Simulated close error</exception>
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
