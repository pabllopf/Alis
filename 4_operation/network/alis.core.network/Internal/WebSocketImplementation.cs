// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WebSocketImplementation.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.IO.Compression;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#if RELEASESIGNED
[assembly: InternalsVisibleTo("Ninja.WebSockets.UnitTests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100b1707056f4761b7846ed503642fcde97fc350c939f78026211304a56ba51e094c9cefde77fadce5b83c0a621c17f032c37c520b6d9ab2da8291a21472175d9caad55bf67bab4bffb46a96f864ea441cf695edc854296e02a44062245a4e09ccd9a77ef6146ecf941ce1d9da078add54bc2d4008decdac2fa2b388e17794ee6a6")]
#else
[assembly: InternalsVisibleTo("Ninja.WebSockets.UnitTests")]
#endif

namespace Alis.Core.Network.Internal
{
    /// <summary>
    ///     Main implementation of the WebSocket abstract class
    /// </summary>
    internal class WebSocketImplementation : WebSocket
    {
        /// <summary>
        ///     The max ping pong payload len
        /// </summary>
        private const int MAX_PING_PONG_PAYLOAD_LEN = 125;

        /// <summary>
        ///     The guid
        /// </summary>
        private readonly Guid _guid;

        /// <summary>
        ///     The include exception in close response
        /// </summary>
        private readonly bool _includeExceptionInCloseResponse;

        /// <summary>
        ///     The internal read cts
        /// </summary>
        private readonly CancellationTokenSource _internalReadCts;

        /// <summary>
        ///     The is client
        /// </summary>
        private readonly bool _isClient;

        /// <summary>
        ///     The ping pong manager
        /// </summary>
        private readonly IPingPongManager _pingPongManager;

        /// <summary>
        ///     The recycled stream factory
        /// </summary>
        private readonly Func<MemoryStream> _recycledStreamFactory;

        /// <summary>
        ///     The semaphore slim
        /// </summary>
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        /// <summary>
        ///     The stream
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        ///     The use per message deflate
        /// </summary>
        private readonly bool _usePerMessageDeflate;

        /// <summary>
        ///     The close status
        /// </summary>
        private WebSocketCloseStatus? _closeStatus;

        /// <summary>
        ///     The close status description
        /// </summary>
        private string _closeStatusDescription;

        /// <summary>
        ///     The binary
        /// </summary>
        private WebSocketMessageType _continuationFrameMessageType = WebSocketMessageType.Binary;

        /// <summary>
        ///     The is continuation frame
        /// </summary>
        private bool _isContinuationFrame;

        /// <summary>
        ///     The read cursor
        /// </summary>
        private WebSocketReadCursor _readCursor;

        /// <summary>
        ///     The state
        /// </summary>
        private WebSocketState _state;

        /// <summary>
        ///     The try get buffer failure logged
        /// </summary>
        private bool _tryGetBufferFailureLogged;

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
            _guid = guid;
            _recycledStreamFactory = recycledStreamFactory;
            _stream = stream;
            _isClient = isClient;
            SubProtocol = subProtocol;
            _internalReadCts = new CancellationTokenSource();
            _state = WebSocketState.Open;
            _readCursor = new WebSocketReadCursor(null, 0, 0);

            if (secWebSocketExtensions?.IndexOf("permessage-deflate") >= 0)
            {
                _usePerMessageDeflate = true;
                Events.Log.UsePerMessageDeflate(guid);
            }
            else
            {
                Events.Log.NoMessageCompression(guid);
            }

            KeepAliveInterval = keepAliveInterval;
            _includeExceptionInCloseResponse = includeExceptionInCloseResponse;
            if (keepAliveInterval.Ticks < 0)
            {
                throw new InvalidOperationException("KeepAliveInterval must be Zero or positive");
            }

            if (keepAliveInterval == TimeSpan.Zero)
            {
                Events.Log.KeepAliveIntervalZero(guid);
            }
            else
            {
                _pingPongManager = new PingPongManager(guid, this, keepAliveInterval, _internalReadCts.Token);
            }
        }

        /// <summary>
        ///     Gets the value of the close status
        /// </summary>
        public override WebSocketCloseStatus? CloseStatus => _closeStatus;

        /// <summary>
        ///     Gets the value of the close status description
        /// </summary>
        public override string CloseStatusDescription => _closeStatusDescription;

        /// <summary>
        ///     Gets the value of the state
        /// </summary>
        public override WebSocketState State => _state;

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
        ///     Receive web socket result
        /// </summary>
        /// <param name="buffer">The buffer to copy data into</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The web socket result details</returns>
        public override async Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            try
            {
                // we may receive control frames so reading needs to happen in an infinite loop
                while (true)
                {
                    // allow this operation to be cancelled from iniside OR outside this instance
                    using (CancellationTokenSource linkedCts =
                           CancellationTokenSource.CreateLinkedTokenSource(_internalReadCts.Token, cancellationToken))
                    {
                        WebSocketFrame frame;

                        try
                        {
                            if (_readCursor.NumBytesLeftToRead > 0)
                            {
                                // If the buffer used to read the frame was too small to fit the whole frame then we need to "remember" this frame
                                // and return what we have. Subsequent calls to the read function will simply continue reading off the stream without 
                                // decoding the first few bytes as a websocket header.
                                _readCursor =
                                    await WebSocketFrameReader.ReadFromCursorAsync(_stream, buffer, _readCursor,
                                        linkedCts.Token);
                                frame = _readCursor.WebSocketFrame;
                            }
                            else
                            {
                                _readCursor = await WebSocketFrameReader.ReadAsync(_stream, buffer, linkedCts.Token);
                                frame = _readCursor.WebSocketFrame;
                                Events.Log.ReceivedFrame(_guid, frame.OpCode, frame.IsFinBitSet, frame.Count);
                            }
                        }
                        catch (InternalBufferOverflowException ex)
                        {
                            await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.MessageTooBig,
                                "Frame too large to fit in buffer. Use message fragmentation", ex);
                            throw;
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.ProtocolError,
                                "Payload length out of range", ex);
                            throw;
                        }
                        catch (EndOfStreamException ex)
                        {
                            await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InvalidPayloadData,
                                "Unexpected end of stream encountered", ex);
                            throw;
                        }
                        catch (OperationCanceledException ex)
                        {
                            await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.EndpointUnavailable,
                                "Operation cancelled", ex);
                            throw;
                        }
                        catch (Exception ex)
                        {
                            await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError,
                                "Error reading WebSocket frame", ex);
                            throw;
                        }

                        bool endOfMessage = frame.IsFinBitSet && _readCursor.NumBytesLeftToRead == 0;
                        switch (frame.OpCode)
                        {
                            case WebSocketOpCode.ConnectionClose:
                                return await RespondToCloseFrame(frame, buffer, linkedCts.Token);
                            case WebSocketOpCode.Ping:
                                ArraySegment<byte> pingPayload = new ArraySegment<byte>(buffer.Array, buffer.Offset,
                                    _readCursor.NumBytesRead);
                                await SendPongAsync(pingPayload, linkedCts.Token);
                                break;
                            case WebSocketOpCode.Pong:
                                ArraySegment<byte> pongBuffer = new ArraySegment<byte>(buffer.Array,
                                    _readCursor.NumBytesRead, buffer.Offset);
                                Pong?.Invoke(this, new PongEventArgs(pongBuffer));
                                break;
                            case WebSocketOpCode.TextFrame:
                                if (!frame.IsFinBitSet)
                                {
                                    // continuation frames will follow, record the message type Text
                                    _continuationFrameMessageType = WebSocketMessageType.Text;
                                }

                                return new WebSocketReceiveResult(_readCursor.NumBytesRead, WebSocketMessageType.Text,
                                    endOfMessage);
                            case WebSocketOpCode.BinaryFrame:
                                if (!frame.IsFinBitSet)
                                {
                                    // continuation frames will follow, record the message type Binary
                                    _continuationFrameMessageType = WebSocketMessageType.Binary;
                                }

                                return new WebSocketReceiveResult(_readCursor.NumBytesRead, WebSocketMessageType.Binary,
                                    endOfMessage);
                            case WebSocketOpCode.ContinuationFrame:
                                return new WebSocketReceiveResult(_readCursor.NumBytesRead,
                                    _continuationFrameMessageType, endOfMessage);
                            default:
                                Exception ex = new NotSupportedException($"Unknown WebSocket opcode {frame.OpCode}");
                                await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.ProtocolError, ex.Message, ex);
                                throw ex;
                        }
                    }
                }
            }
            catch (Exception catchAll)
            {
                // Most exceptions will be caught closer to their source to send an appropriate close message (and set the WebSocketState)
                // However, if an unhandled exception is encountered and a close message not sent then send one here
                if (_state == WebSocketState.Open)
                {
                    await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.InternalServerError,
                        "Unexpected error reading from WebSocket", catchAll);
                }

                throw;
            }
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
            using (MemoryStream stream = _recycledStreamFactory())
            {
                WebSocketOpCode opCode = GetOppCode(messageType);

                if (_usePerMessageDeflate)
                {
                    // NOTE: Compression is currently work in progress and should NOT be used in this library.
                    // The code below is very inefficient for small messages. Ideally we would like to have some sort of moving window
                    // of data to get the best compression. And we don't want to create new buffers which is bad for GC.
                    using (MemoryStream temp = new MemoryStream())
                    {
                        DeflateStream deflateStream = new DeflateStream(temp, CompressionMode.Compress);
                        deflateStream.Write(buffer.Array, buffer.Offset, buffer.Count);
                        deflateStream.Flush();
                        ArraySegment<byte> compressedBuffer = new ArraySegment<byte>(temp.ToArray());
                        WebSocketFrameWriter.Write(opCode, compressedBuffer, stream, endOfMessage, _isClient);
                        Events.Log.SendingFrame(_guid, opCode, endOfMessage, compressedBuffer.Count, true);
                    }
                }
                else
                {
                    WebSocketFrameWriter.Write(opCode, buffer, stream, endOfMessage, _isClient);
                    Events.Log.SendingFrame(_guid, opCode, endOfMessage, buffer.Count, false);
                }

                await WriteStreamToNetwork(stream, cancellationToken);
                _isContinuationFrame = !endOfMessage; // TODO: is this correct??
            }
        }

        /// <summary>
        ///     Call this automatically from server side each keepAliveInterval period
        ///     NOTE: ping payload must be 125 bytes or less
        /// </summary>
        public async Task SendPingAsync(ArraySegment<byte> payload, CancellationToken cancellationToken)
        {
            if (payload.Count > MAX_PING_PONG_PAYLOAD_LEN)
            {
                throw new InvalidOperationException(
                    $"Cannot send Ping: Max ping message size {MAX_PING_PONG_PAYLOAD_LEN} exceeded: {payload.Count}");
            }

            if (_state == WebSocketState.Open)
            {
                using (MemoryStream stream = _recycledStreamFactory())
                {
                    WebSocketFrameWriter.Write(WebSocketOpCode.Ping, payload, stream, true, _isClient);
                    Events.Log.SendingFrame(_guid, WebSocketOpCode.Ping, true, payload.Count, false);
                    await WriteStreamToNetwork(stream, cancellationToken);
                }
            }
        }

        /// <summary>
        ///     Aborts the WebSocket without sending a Close frame
        /// </summary>
        public override void Abort()
        {
            _state = WebSocketState.Aborted;
            _internalReadCts.Cancel();
        }

        /// <summary>
        ///     Polite close (use the close handshake)
        /// </summary>
        public override async Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription,
            CancellationToken cancellationToken)
        {
            if (_state == WebSocketState.Open)
            {
                using (MemoryStream stream = _recycledStreamFactory())
                {
                    ArraySegment<byte> buffer = BuildClosePayload(closeStatus, statusDescription);
                    WebSocketFrameWriter.Write(WebSocketOpCode.ConnectionClose, buffer, stream, true, _isClient);
                    Events.Log.CloseHandshakeStarted(_guid, closeStatus, statusDescription);
                    Events.Log.SendingFrame(_guid, WebSocketOpCode.ConnectionClose, true, buffer.Count, true);
                    await WriteStreamToNetwork(stream, cancellationToken);
                    _state = WebSocketState.CloseSent;
                }
            }
            else
            {
                Events.Log.InvalidStateBeforeClose(_guid, _state);
            }
        }

        /// <summary>
        ///     Fire and forget close
        /// </summary>
        public override async Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription,
            CancellationToken cancellationToken)
        {
            if (_state == WebSocketState.Open)
            {
                _state = WebSocketState.Closed; // set this before we write to the network because the write may fail

                using (MemoryStream stream = _recycledStreamFactory())
                {
                    ArraySegment<byte> buffer = BuildClosePayload(closeStatus, statusDescription);
                    WebSocketFrameWriter.Write(WebSocketOpCode.ConnectionClose, buffer, stream, true, _isClient);
                    Events.Log.CloseOutputNoHandshake(_guid, closeStatus, statusDescription);
                    Events.Log.SendingFrame(_guid, WebSocketOpCode.ConnectionClose, true, buffer.Count, true);
                    await WriteStreamToNetwork(stream, cancellationToken);
                }
            }
            else
            {
                Events.Log.InvalidStateBeforeCloseOutput(_guid, _state);
            }

            // cancel pending reads
            _internalReadCts.Cancel();
        }

        /// <summary>
        ///     Dispose will send a close frame if the connection is still open
        /// </summary>
        public override void Dispose()
        {
            Events.Log.WebSocketDispose(_guid, _state);

            try
            {
                if (_state == WebSocketState.Open)
                {
                    CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                    try
                    {
                        CloseOutputAsync(WebSocketCloseStatus.EndpointUnavailable, "Service is Disposed", cts.Token)
                            .Wait();
                    }
                    catch (OperationCanceledException)
                    {
                        // log don't throw
                        Events.Log.WebSocketDisposeCloseTimeout(_guid, _state);
                    }
                }

                // cancel pending reads - usually does nothing
                _internalReadCts.Cancel();
                _stream.Close();
            }
            catch (Exception ex)
            {
                // log dont throw
                Events.Log.WebSocketDisposeError(_guid, _state, ex.ToString());
            }
        }

        /// <summary>
        ///     Called when a Pong frame is received
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPong(PongEventArgs e)
        {
            Pong?.Invoke(this, e);
        }

        /// <summary>
        ///     As per the spec, write the close status followed by the close reason
        /// </summary>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">Optional extra close details</param>
        /// <returns>The payload to sent in the close frame</returns>
        private ArraySegment<byte> BuildClosePayload(WebSocketCloseStatus closeStatus, string statusDescription)
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

        /// NOTE: pong payload must be 125 bytes or less
        /// Pong should contain the same payload as the ping
        private async Task SendPongAsync(ArraySegment<byte> payload, CancellationToken cancellationToken)
        {
            // as per websocket spec
            if (payload.Count > MAX_PING_PONG_PAYLOAD_LEN)
            {
                Exception ex =
                    new InvalidOperationException(
                        $"Max ping message size {MAX_PING_PONG_PAYLOAD_LEN} exceeded: {payload.Count}");
                await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.ProtocolError, ex.Message, ex);
                throw ex;
            }

            try
            {
                if (_state == WebSocketState.Open)
                {
                    using (MemoryStream stream = _recycledStreamFactory())
                    {
                        WebSocketFrameWriter.Write(WebSocketOpCode.Pong, payload, stream, true, _isClient);
                        Events.Log.SendingFrame(_guid, WebSocketOpCode.Pong, true, payload.Count, false);
                        await WriteStreamToNetwork(stream, cancellationToken);
                    }
                }
            }
            catch (Exception ex)
            {
                await CloseOutputAutoTimeoutAsync(WebSocketCloseStatus.EndpointUnavailable,
                    "Unable to send Pong response", ex);
                throw;
            }
        }

        /// <summary>
        ///     Called when a Close frame is received
        ///     Send a response close frame if applicable
        /// </summary>
        private async Task<WebSocketReceiveResult> RespondToCloseFrame(WebSocketFrame frame, ArraySegment<byte> buffer,
            CancellationToken token)
        {
            _closeStatus = frame.CloseStatus;
            _closeStatusDescription = frame.CloseStatusDescription;

            if (_state == WebSocketState.CloseSent)
            {
                // this is a response to close handshake initiated by this instance
                _state = WebSocketState.Closed;
                Events.Log.CloseHandshakeComplete(_guid);
            }
            else if (_state == WebSocketState.Open)
            {
                // do not echo the close payload back to the client, there is no requirement for it in the spec. 
                // However, the same CloseStatus as recieved should be sent back.
                ArraySegment<byte> closePayload = new ArraySegment<byte>(new byte[0], 0, 0);
                _state = WebSocketState.CloseReceived;
                Events.Log.CloseHandshakeRespond(_guid, frame.CloseStatus, frame.CloseStatusDescription);

                using (MemoryStream stream = _recycledStreamFactory())
                {
                    WebSocketFrameWriter.Write(WebSocketOpCode.ConnectionClose, closePayload, stream, true, _isClient);
                    Events.Log.SendingFrame(_guid, WebSocketOpCode.ConnectionClose, true, closePayload.Count, false);
                    await WriteStreamToNetwork(stream, token);
                }
            }
            else
            {
                Events.Log.CloseFrameReceivedInUnexpectedState(_guid, _state, frame.CloseStatus,
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
        private ArraySegment<byte> GetBuffer(MemoryStream stream)
        {
#if NET45
            // NET45 does not have a TryGetBuffer function on Stream
            if (_tryGetBufferFailureLogged)
            {
                return new ArraySegment<byte>(stream.ToArray(), 0, (int)stream.Position);
            }

            // note that a MemoryStream will throw an UnuthorizedAccessException if the internal buffer is not public. Set publiclyVisible = true
            try
            {
                return new ArraySegment<byte>(stream.GetBuffer(), 0, (int)stream.Position);
            }
            catch (UnauthorizedAccessException)
            {
                Events.Log.TryGetBufferNotSupported(_guid, stream?.GetType()?.ToString());
                _tryGetBufferFailureLogged = true;
                return new ArraySegment<byte>(stream.ToArray(), 0, (int)stream.Position);
            }
#else
            // Avoid calling ToArray on the MemoryStream because it allocates a new byte array on tha heap
            // We avaoid this by attempting to access the internal memory stream buffer
            // This works with supported streams like the recyclable memory stream and writable memory streams
            if (!stream.TryGetBuffer(out ArraySegment<byte> buffer))
            {
                if (!_tryGetBufferFailureLogged)
                {
                    Events.Log.TryGetBufferNotSupported(_guid, stream?.GetType()?.ToString());
                    _tryGetBufferFailureLogged = true;
                }

                // internal buffer not suppoted, fall back to ToArray()
                byte[] array = stream.ToArray();
                buffer = new ArraySegment<byte>(array, 0, array.Length);
            }

            return new ArraySegment<byte>(buffer.Array, buffer.Offset, (int) stream.Position);
#endif
        }

        /// <summary>
        ///     Puts data on the wire
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        private async Task WriteStreamToNetwork(MemoryStream stream, CancellationToken cancellationToken)
        {
            ArraySegment<byte> buffer = GetBuffer(stream);
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _stream.WriteAsync(buffer.Array, buffer.Offset, buffer.Count, cancellationToken)
                    .ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Turns a spec websocket frame opcode into a WebSocketMessageType
        /// </summary>
        private WebSocketOpCode GetOppCode(WebSocketMessageType messageType)
        {
            if (_isContinuationFrame)
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
        private async Task CloseOutputAutoTimeoutAsync(WebSocketCloseStatus closeStatus, string statusDescription,
            Exception ex)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(5);
            Events.Log.CloseOutputAutoTimeout(_guid, closeStatus, statusDescription, ex.ToString());

            try
            {
                // we may not want to send sensitive information to the client / server
                if (_includeExceptionInCloseResponse)
                {
                    statusDescription = statusDescription + "\r\n\r\n" + ex;
                }

                CancellationTokenSource autoCancel = new CancellationTokenSource(timeSpan);
                await CloseOutputAsync(closeStatus, statusDescription, autoCancel.Token);
            }
            catch (OperationCanceledException)
            {
                // do not throw an exception because that will mask the original exception
                Events.Log.CloseOutputAutoTimeoutCancelled(_guid, (int) timeSpan.TotalSeconds, closeStatus,
                    statusDescription, ex.ToString());
            }
            catch (Exception closeException)
            {
                // do not throw an exception because that will mask the original exception
                Events.Log.CloseOutputAutoTimeoutError(_guid, closeException.ToString(), closeStatus, statusDescription,
                    ex.ToString());
            }
        }
    }
}