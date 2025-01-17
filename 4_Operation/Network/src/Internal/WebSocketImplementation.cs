// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketImplementation.cs
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
using System.IO.Compression;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Network.Internal
{
    /// <summary>
    ///     Main implementation of the WebSocket abstract class
    /// </summary>
    internal sealed class WebSocketImplementation : WebSocket
    {
        /// <summary>
        ///     The max ping pong payload len
        /// </summary>
        internal const int PingPongPayloadLen = 125;

        /// <summary>
        ///     The guid
        /// </summary>
        internal readonly Guid Guid;

        /// <summary>
        ///     The include exception in close response
        /// </summary>
        internal readonly bool IncludeExceptionInCloseResponse;

        /// <summary>
        ///     The internal read cts
        /// </summary>
        internal readonly CancellationTokenSource InternalReadCts = new CancellationTokenSource();

        /// <summary>
        ///     The is client
        /// </summary>
        internal readonly bool IsClient;

        /// <summary>
        ///     The recycled stream factory
        /// </summary>
        internal readonly Func<MemoryStream> RecycledStreamFactory;

        /// <summary>
        ///     The semaphore slim
        /// </summary>
        internal readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1);

        /// <summary>
        ///     The stream
        /// </summary>
        internal readonly Stream Stream;

        /// <summary>
        ///     The use per message deflate
        /// </summary>
        internal readonly bool UsePerMessageDeflate;

        /// <summary>
        ///     The close status
        /// </summary>
        internal WebSocketCloseStatus? CloseStatusInternal;

        /// <summary>
        ///     The close status description
        /// </summary>
        internal string CloseStatusDescriptionInternal;

        /// <summary>
        ///     The binary
        /// </summary>
        internal WebSocketMessageType ContinuationFrameMessageType = WebSocketMessageType.Binary;

        /// <summary>
        ///     The is continuation frame
        /// </summary>
        internal bool IsContinuationFrame;

        /// <summary>
        ///     The read cursor
        /// </summary>
        internal WebSocketReadCursor ReadCursor;

        /// <summary>
        ///     The state
        /// </summary>
        internal WebSocketState StateInternal;

        /// <summary>
        ///     The try get buffer failure logged
        /// </summary>
        internal bool TryGetBufferFailureLogged;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketImplementation" /> class
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="recycledStreamFactory">The recycled stream factory</param>
        /// <param name="stream">The stream</param>
        /// <param name="keepAliveInterval">The keep alive interval</param>
        /// <param name="secWebSocketExtensions">The sec web socket extensions</param>
        /// <param name="includeExceptionInCloseResponse">The include exception in close response</param>
        /// <param name="isClient">The is client</param>
        /// <param name="subProtocol">The sub protocol</param>
        /// <exception cref="InvalidOperationException">KeepAliveInterval must be Zero or positive</exception>
        internal WebSocketImplementation(Guid guid, Func<MemoryStream> recycledStreamFactory, Stream stream,
            TimeSpan keepAliveInterval, string secWebSocketExtensions, bool includeExceptionInCloseResponse,
            bool isClient, string subProtocol)
        {
            Guid = guid;
            RecycledStreamFactory = recycledStreamFactory;
            Stream = stream;
            IsClient = isClient;
            SubProtocol = subProtocol;
            StateInternal = WebSocketState.Open;
            ReadCursor = new WebSocketReadCursor(null, 0, 0);

            if (secWebSocketExtensions?.IndexOf("permessage-deflate") >= 0)
            {
                UsePerMessageDeflate = true;
                Events.Log.UsePerMessageDeflate(guid);
            }
            else
            {
                Events.Log.NoMessageCompression(guid);
            }

            KeepAliveInterval = keepAliveInterval;
            IncludeExceptionInCloseResponse = includeExceptionInCloseResponse;
            if (keepAliveInterval.Ticks < 0)
            {
                throw new InvalidOperationException("KeepAliveInterval must be Zero or positive");
            }


            if (keepAliveInterval == TimeSpan.Zero)
            {
                Events.Log.KeepAliveIntervalZero(guid);
            }
        }

        /// <summary>
        ///     Gets the value of the close status
        /// </summary>
        public override WebSocketCloseStatus? CloseStatus => CloseStatusInternal;

        /// <summary>
        ///     Gets the value of the close status description
        /// </summary>
        public override string CloseStatusDescription => CloseStatusDescriptionInternal;

        /// <summary>
        ///     Gets the value of the state
        /// </summary>
        public override WebSocketState State => StateInternal;

        /// <summary>
        ///     Gets the value of the sub protocol
        /// </summary>
        public override string SubProtocol { get; }

        /// <summary>
        ///     Gets the value of the keep alive interval
        /// </summary>
        public TimeSpan KeepAliveInterval { get; }

        public event EventHandler<PongEventArgs> Pong;

        /// <summary>
        ///     Receives the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the web socket receive result</returns>
        public override async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            try
            {
                // allow this operation to be cancelled from inside OR outside this instance
                using CancellationTokenSource linkedCts =
                    CancellationTokenSource.CreateLinkedTokenSource(InternalReadCts.Token, cancellationToken);
                WebSocketFrame frame = await ReadWebSocketFrame(buffer, linkedCts.Token);

                bool endOfMessage = frame.IsFinBitSet && (ReadCursor.NumBytesLeftToRead == 0);
                return await HandleWebSocketOpCodes(frame, buffer, linkedCts, endOfMessage);
            }
            catch (Exception catchAll)
            {
                return await HandleExceptions(catchAll);
            }
        }

        /// <summary>
        ///     Reads the web socket frame using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the web socket frame</returns>
        internal async Task<WebSocketFrame> ReadWebSocketFrame(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            try
            {
                if (ReadCursor.NumBytesLeftToRead > 0)
                {
                    ReadCursor = await WebSocketFrameReader.ReadFromCursorAsync(Stream, buffer, ReadCursor, cancellationToken);
                    return ReadCursor.WebSocketFrame;
                }

                ReadCursor = await WebSocketFrameReader.ReadAsync(Stream, buffer, cancellationToken);
                WebSocketFrame frame = ReadCursor.WebSocketFrame;
                Events.Log.ReceivedFrame(Guid, frame.OpCode, frame.IsFinBitSet, frame.Count);
                return frame;
            }
            catch (Exception ex)
            {
                await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError, "Error reading WebSocket frame", ex);
                throw;
            }
        }

        /// <summary>
        ///     Handles the web socket op codes using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="linkedCts">The linked cts</param>
        /// <param name="endOfMessage">The end of message</param>
        /// <returns>A task containing the web socket receive result</returns>
        internal async Task<WebSocketReceiveResult> HandleWebSocketOpCodes(WebSocketFrame frame, ArraySegment<byte> buffer, CancellationTokenSource linkedCts, bool endOfMessage)
        {
            switch (frame.OpCode)
            {
                case WebSocketOpCode.ConnectionClose:
                    return await HandleConnectionClose(frame, buffer, linkedCts.Token);
                case WebSocketOpCode.Ping:
                    return await HandlePing(frame, buffer, linkedCts);
                case WebSocketOpCode.Pong:
                    return HandlePong(frame, buffer);
                case WebSocketOpCode.TextFrame:
                    return HandleTextFrame(frame, endOfMessage);
                case WebSocketOpCode.BinaryFrame:
                    return HandleBinaryFrame(frame, endOfMessage);
                case WebSocketOpCode.ContinuationFrame:
                    return HandleContinuationFrame(frame, endOfMessage);
                default:
                    return await HandleDefault(frame);
            }
        }

        /// <summary>
        ///     Handles the connection close using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="token">The token</param>
        /// <returns>A task containing the web socket receive result</returns>
        internal async Task<WebSocketReceiveResult> HandleConnectionClose(WebSocketFrame frame, ArraySegment<byte> buffer, CancellationToken token) => await RespondToCloseFrame(frame, buffer, token);

        /// <summary>
        ///     Handles the ping using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="linkedCts">The linked cts</param>
        /// <returns>A task containing the web socket receive result</returns>
        internal async Task<WebSocketReceiveResult> HandlePing(WebSocketFrame frame, ArraySegment<byte> buffer, CancellationTokenSource linkedCts)
        {
            if (buffer.Array != null)
            {
                ArraySegment<byte> pingPayload = new ArraySegment<byte>(buffer.Array, buffer.Offset, ReadCursor.NumBytesRead);
                await SendPongAsync(pingPayload, linkedCts.Token);
            }

            return null;
        }

        /// <summary>
        ///     Handles the pong using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="buffer">The buffer</param>
        /// <returns>The web socket receive result</returns>
        internal WebSocketReceiveResult HandlePong(WebSocketFrame frame, ArraySegment<byte> buffer)
        {
            if (buffer.Array != null)
            {
                ArraySegment<byte> pongBuffer = new ArraySegment<byte>(buffer.Array, ReadCursor.NumBytesRead, buffer.Offset);
                Pong?.Invoke(this, new PongEventArgs(pongBuffer));
            }

            return null;
        }

        /// <summary>
        ///     Handles the text frame using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="endOfMessage">The end of message</param>
        /// <returns>The web socket receive result</returns>
        internal WebSocketReceiveResult HandleTextFrame(WebSocketFrame frame, bool endOfMessage)
        {
            if (!frame.IsFinBitSet)
            {
                ContinuationFrameMessageType = WebSocketMessageType.Text;
            }

            return new WebSocketReceiveResult(ReadCursor.NumBytesRead, WebSocketMessageType.Text, endOfMessage);
        }

        /// <summary>
        ///     Handles the binary frame using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="endOfMessage">The end of message</param>
        /// <returns>The web socket receive result</returns>
        internal WebSocketReceiveResult HandleBinaryFrame(WebSocketFrame frame, bool endOfMessage)
        {
            if (!frame.IsFinBitSet)
            {
                ContinuationFrameMessageType = WebSocketMessageType.Binary;
            }

            return new WebSocketReceiveResult(ReadCursor.NumBytesRead, WebSocketMessageType.Binary, endOfMessage);
        }

        /// <summary>
        ///     Handles the continuation frame using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="endOfMessage">The end of message</param>
        /// <returns>The web socket receive result</returns>
        internal WebSocketReceiveResult HandleContinuationFrame(WebSocketFrame frame, bool endOfMessage) => new WebSocketReceiveResult(ReadCursor.NumBytesRead, ContinuationFrameMessageType, endOfMessage);

        /// <summary>
        ///     Handles the default using the specified frame
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <returns>A task containing the web socket receive result</returns>
        internal async Task<WebSocketReceiveResult> HandleDefault(WebSocketFrame frame)
        {
            Exception ex = new NotSupportedException($"Unknown WebSocket opcode {frame.OpCode}");
            await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.ProtocolError, ex.Message, ex);
            throw ex;
        }

        /// <summary>
        ///     Handles the exceptions using the specified catch all
        /// </summary>
        /// <param name="catchAll">The catch all</param>
        /// <returns>A task containing the web socket receive result</returns>
        internal async Task<WebSocketReceiveResult> HandleExceptions(Exception catchAll)
        {
            if (StateInternal == WebSocketState.Open)
            {
                await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError, "Unexpected error reading from WebSocket", catchAll);
            }

            throw catchAll;
        }

        /// <summary>
        ///     Send data to the web socket
        /// </summary>
        /// <param name="buffer">the buffer containing data to send</param>
        /// <param name="messageType">The message type. Can be Text or Binary</param>
        /// <param name="endOfMessage">
        ///     True if this message is a standalone message (this is the norm)
        ///     If it is a multi-part message then false (and true for the last message)
        /// </param>
        /// <param name="cancellationToken">the cancellation token</param>
        public override async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType,
            bool endOfMessage, CancellationToken cancellationToken)
        {
            using MemoryStream stream = RecycledStreamFactory();
            WebSocketOpCode opCode = GetOppCode(messageType);

            if (UsePerMessageDeflate)
            {
                using MemoryStream temp = new MemoryStream();
                DeflateStream deflateStream = new DeflateStream(temp, CompressionMode.Compress);
                if (buffer.Array != null)
                {
                    await deflateStream.WriteAsync(buffer.Array, buffer.Offset, buffer.Count);
                }

                await deflateStream.FlushAsync();
                ArraySegment<byte> compressedBuffer = new ArraySegment<byte>(temp.ToArray());
                WebSocketFrameWriter.Write(opCode, compressedBuffer, stream, endOfMessage, IsClient);
                Events.Log.SendingFrame(Guid, opCode, endOfMessage, compressedBuffer.Count, true);
            }
            else
            {
                WebSocketFrameWriter.Write(opCode, buffer, stream, endOfMessage, IsClient);
                Events.Log.SendingFrame(Guid, opCode, endOfMessage, buffer.Count, false);
            }

            await WriteStreamToNetwork(stream, cancellationToken);
            IsContinuationFrame = !endOfMessage;
        }

        /// <summary>
        ///     Sends the ping using the specified payload
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="InvalidOperationException">
        ///     Cannot send Ping: Max ping message size {PingPongPayloadLen} exceeded:
        ///     {payload.Count}
        /// </exception>
        public async Task SendPingAsync(ArraySegment<byte> payload, CancellationToken cancellationToken)
        {
            if (payload.Count > PingPongPayloadLen)
            {
                throw new InvalidOperationException(
                    $"Cannot send Ping: Max ping message size {PingPongPayloadLen} exceeded: {payload.Count}");
            }

            if (StateInternal == WebSocketState.Open)
            {
                using MemoryStream stream = RecycledStreamFactory();
                WebSocketFrameWriter.Write(WebSocketOpCode.Ping, payload, stream, true, IsClient);
                Events.Log.SendingFrame(Guid, WebSocketOpCode.Ping, true, payload.Count, false);
                await WriteStreamToNetwork(stream, cancellationToken);
            }
        }

        /// <summary>
        ///     Aborts the WebSocket without sending a Close frame
        /// </summary>
        public override void Abort()
        {
            StateInternal = WebSocketState.Aborted;
            InternalReadCts.Cancel();
        }

        /// <summary>
        ///     Closes the close status
        /// </summary>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public override async Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription,
            CancellationToken cancellationToken)
        {
            if (StateInternal == WebSocketState.Open)
            {
                using MemoryStream stream = RecycledStreamFactory();
                ArraySegment<byte> buffer = BuildClosePayload(closeStatus, statusDescription);
                WebSocketFrameWriter.Write(WebSocketOpCode.ConnectionClose, buffer, stream, true, IsClient);
                Events.Log.CloseHandshakeStarted(Guid, closeStatus, statusDescription);
                Events.Log.SendingFrame(Guid, WebSocketOpCode.ConnectionClose, true, buffer.Count, true);
                await WriteStreamToNetwork(stream, cancellationToken);
                StateInternal = WebSocketState.CloseSent;
            }
            else
            {
                Events.Log.InvalidStateBeforeClose(Guid, StateInternal);
            }
        }


        /// <summary>
        ///     Closes the output using the specified close status
        /// </summary>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public override async Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription,
            CancellationToken cancellationToken)
        {
            if (StateInternal == WebSocketState.Open)
            {
                StateInternal = WebSocketState.Closed; // set this before we write to the network because the write may fail

                using MemoryStream stream = RecycledStreamFactory();
                ArraySegment<byte> buffer = BuildClosePayload(closeStatus, statusDescription);
                WebSocketFrameWriter.Write(WebSocketOpCode.ConnectionClose, buffer, stream, true, IsClient);
                Events.Log.CloseOutputNoHandshake(Guid, closeStatus, statusDescription);
                Events.Log.SendingFrame(Guid, WebSocketOpCode.ConnectionClose, true, buffer.Count, true);
                await WriteStreamToNetwork(stream, cancellationToken);
            }
            else
            {
                Events.Log.InvalidStateBeforeCloseOutput(Guid, StateInternal);
            }

            // cancel pending reads
            InternalReadCts.Cancel();
        }

        /// <summary>
        ///     Dispose will send a close frame if the connection is still open
        /// </summary>
        public override void Dispose()
        {
            Events.Log.WebSocketDispose(Guid, StateInternal);

            try
            {
                if (StateInternal == WebSocketState.Open)
                {
                    using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                    try
                    {
                        CloseOutputAsync(WebSocketCloseStatus.EndpointUnavailable, "Service is Disposed", cts.Token)
                            .Wait();
                    }
                    catch (OperationCanceledException)
                    {
                        // log don't throw
                        Events.Log.WebSocketDisposeCloseTimeout(Guid, StateInternal);
                    }
                }

                // cancel pending reads - usually does nothing
                InternalReadCts.Cancel();
                Stream.Close();
                InternalReadCts.Dispose();
            }
            catch (Exception ex)
            {
                // log dont throw
                Events.Log.WebSocketDisposeError(Guid, StateInternal, ex.ToString());
            }
        }

        /// <summary>
        ///     Called when a Pong frame is received
        /// </summary>
        /// <param name="e"></param>
        internal void OnPong(PongEventArgs e)
        {
            Pong?.Invoke(this, e);
        }

        /// <summary>
        ///     As per the spec, write the close status followed by the close reason
        /// </summary>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">Optional extra close details</param>
        /// <returns>The payload to sent in the close frame</returns>
        internal ArraySegment<byte> BuildClosePayload(WebSocketCloseStatus closeStatus, string statusDescription)
        {
            byte[] statusBuffer = BitConverter.GetBytes((ushort) closeStatus);
            Array.Reverse(statusBuffer); // network byte order (big endian)

            if (statusDescription == null)
            {
                return new ArraySegment<byte>(statusBuffer);
            }

            byte[] descBuffer = Encoding.UTF8.GetBytes(statusDescription);
            byte[] payload = new byte[statusBuffer.Length + descBuffer.Length];
            Buffer.BlockCopy(statusBuffer, 0, payload, 0, statusBuffer.Length);
            Buffer.BlockCopy(descBuffer, 0, payload, statusBuffer.Length, descBuffer.Length);
            return new ArraySegment<byte>(payload);
        }

        /// <summary>
        ///     Sends the pong using the specified payload
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <param name="cancellationToken">The cancellation token</param>
        internal async Task SendPongAsync(ArraySegment<byte> payload, CancellationToken cancellationToken)
        {
            ValidatePayloadSize(payload);

            if (StateInternal == WebSocketState.Open)
            {
                await SendPongFrame(payload, cancellationToken);
            }
        }

        /// <summary>
        ///     Validates the payload size using the specified payload
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <exception cref="InvalidOperationException">Max ping message size {PingPongPayloadLen} exceeded: {payload.Count}</exception>
        internal void ValidatePayloadSize(ArraySegment<byte> payload)
        {
            if (payload.Count > PingPongPayloadLen)
            {
                throw new InvalidOperationException($"Max ping message size {PingPongPayloadLen} exceeded: {payload.Count}");
            }
        }

        /// <summary>
        ///     Sends the pong frame using the specified payload
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <param name="cancellationToken">The cancellation token</param>
        internal async Task SendPongFrame(ArraySegment<byte> payload, CancellationToken cancellationToken)
        {
            try
            {
                using MemoryStream stream = RecycledStreamFactory();
                WebSocketFrameWriter.Write(WebSocketOpCode.Pong, payload, stream, true, IsClient);
                Events.Log.SendingFrame(Guid, WebSocketOpCode.Pong, true, payload.Count, false);
                await WriteStreamToNetwork(stream, cancellationToken);
            }
            catch (Exception ex)
            {
                await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.EndpointUnavailable, "Unable to send Pong response", ex);
                throw;
            }
        }

        /// <summary>
        ///     Called when a Close frame is received
        ///     Send a response close frame if applicable
        /// </summary>
        internal async Task<WebSocketReceiveResult> RespondToCloseFrame(WebSocketFrame frame, ArraySegment<byte> buffer,
            CancellationToken token)
        {
            CloseStatusInternal = frame.CloseStatus;
            CloseStatusDescriptionInternal = frame.CloseStatusDescription;

            if (StateInternal == WebSocketState.CloseSent)
            {
                // this is a response to close handshake initiated by this instance
                StateInternal = WebSocketState.Closed;
                Events.Log.CloseHandshakeComplete(Guid);
            }
            else if (StateInternal == WebSocketState.Open)
            {
                // do not echo the close payload back to the client, there is no requirement for it in the spec. 
                // However, the same CloseStatus as recieved should be sent back.
                ArraySegment<byte> closePayload = new ArraySegment<byte>(new byte[0], 0, 0);
                StateInternal = WebSocketState.CloseReceived;
                Events.Log.CloseHandshakeRespond(Guid, frame.CloseStatus, frame.CloseStatusDescription);

                using MemoryStream stream = RecycledStreamFactory();
                WebSocketFrameWriter.Write(WebSocketOpCode.ConnectionClose, closePayload, stream, true, IsClient);
                Events.Log.SendingFrame(Guid, WebSocketOpCode.ConnectionClose, true, closePayload.Count, false);
                await WriteStreamToNetwork(stream, token);
            }
            else
            {
                Events.Log.CloseFrameReceivedInUnexpectedState(Guid, StateInternal, frame.CloseStatus,
                    frame.CloseStatusDescription);
            }

            return new WebSocketReceiveResult(frame.Count, WebSocketMessageType.Close, frame.IsFinBitSet,
                frame.CloseStatus, frame.CloseStatusDescription);
        }

        /// <summary>
        ///     Note that the way in which the stream buffer is accessed can lead to significant performance problems
        ///     You want to avoid a call to stream.ToArray to avoid extra memory allocation
        ///     MemoryStream can be configured to have its internal buffer accessible.
        /// </summary>
        internal ArraySegment<byte> GetBuffer(MemoryStream stream)
        {
            // Avoid calling ToArray on the MemoryStream because it allocates a new byte array on tha heap
            // We avaoid this by attempting to access the internal memory stream buffer
            // This works with supported streams like the recyclable memory stream and writable memory streams
            if (!stream.TryGetBuffer(out ArraySegment<byte> buffer))
            {
                if (!TryGetBufferFailureLogged)
                {
                    Events.Log.TryGetBufferNotSupported(Guid, stream?.GetType()?.ToString());
                    TryGetBufferFailureLogged = true;
                }

                // internal buffer not suppoted, fall back to ToArray()
                byte[] array = stream.ToArray();
                buffer = new ArraySegment<byte>(array, 0, array.Length);
            }

            return new ArraySegment<byte>(buffer.Array, buffer.Offset, (int) stream.Position);
        }

        /// <summary>
        ///     Puts data on the wire
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="cancellationToken"></param>
        internal async Task WriteStreamToNetwork(MemoryStream stream, CancellationToken cancellationToken)
        {
            ArraySegment<byte> buffer = GetBuffer(stream);
            await Semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await Stream.WriteAsync(buffer.Array, buffer.Offset, buffer.Count, cancellationToken)
                    .ConfigureAwait(false);
            }
            finally
            {
                Semaphore.Release();
            }
        }

        /// <summary>
        ///     Turns a spec websocket frame opcode into a WebSocketMessageType
        /// </summary>
        internal WebSocketOpCode GetOppCode(WebSocketMessageType messageType)
        {
            if (IsContinuationFrame)
            {
                return WebSocketOpCode.ContinuationFrame;
            }

            switch (messageType)
            {
                case WebSocketMessageType.Binary:
                    return WebSocketOpCode.BinaryFrame;
                case WebSocketMessageType.Text:
                    return WebSocketOpCode.TextFrame;
                case WebSocketMessageType.Close:
                    throw new NotSupportedException(
                        "Cannot use Send function to send a close frame. Use Close function.");
                default:
                    throw new NotSupportedException($"MessageType {messageType} not supported");
            }
        }


        /// <summary>
        ///     Automatic WebSocket close in response to some invalid data from the remote websocket host
        /// </summary>
        /// <param name="closeStatus">The close status to use</param>
        /// <param name="statusDescription">A description of why we are closing</param>
        /// <param name="ex">The exception (for logging)</param>
        internal async Task CloseOutputAutoTimeoutAsync(WebSocketCloseStatus closeStatus, string statusDescription,
            Exception ex)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(5);
            Events.Log.CloseOutputAutoTimeout(Guid, closeStatus, statusDescription, ex.ToString());

            try
            {
                // we may not want to send sensitive information to the client / server
                if (IncludeExceptionInCloseResponse)
                {
                    statusDescription = statusDescription + "\r\n\r\n" + ex;
                }

                using CancellationTokenSource autoCancel = new CancellationTokenSource(timeSpan);
                await CloseOutputAsync(closeStatus, statusDescription, autoCancel.Token);
            }
            catch (OperationCanceledException)
            {
                // do not throw an exception because that will mask the original exception
                Events.Log.CloseOutputAutoTimeoutCancelled(Guid, (int) timeSpan.TotalSeconds, closeStatus,
                    statusDescription, ex.ToString());
            }
            catch (Exception closeException)
            {
                // do not throw an exception because that will mask the original exception
                Events.Log.CloseOutputAutoTimeoutError(Guid, closeException.ToString(), closeStatus, statusDescription,
                    ex.ToString());
            }
        }
    }
}