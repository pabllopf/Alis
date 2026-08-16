// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsEnabledListenerTest.cs
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
using System.Diagnostics.Tracing;
using System.Net.Security;
using System.Net.WebSockets;
using System.Threading;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The events enabled listener test class
    /// </summary>
    public class EventsEnabledListenerTest
    {
        /// <summary>
        ///     The test guid
        /// </summary>
        private static readonly Guid TestGuid = Guid.NewGuid();

        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class TestEventListener : EventListener
        {
            /// <summary>
            ///     The event count
            /// </summary>
            public int EventCount;

            /// <summary>
            ///     The captured event ids
            /// </summary>
            public System.Collections.Generic.List<int> EventIds = new System.Collections.Generic.List<int>();

            /// <summary>
            ///     Handles the event written using the specified event data
            /// </summary>
            /// <param name="eventData">The event data</param>
            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                Interlocked.Increment(ref EventCount);
                lock (EventIds)
                {
                    EventIds.Add(eventData.EventId);
                }
            }
        }

        /// <summary>
        ///     Enables the events using the specified listener
        /// </summary>
        /// <param name="listener">The listener</param>
        /// <returns>The events log</returns>
        private static Events EnableEvents(TestEventListener listener)
        {
            Events log = Events.Log;
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);
            return log;
        }

        /// <summary>
        ///     Tests that all event methods write events when the event source is enabled
        /// </summary>
        [Fact]
        public void AllEventMethods_WhenEnabled_WriteEvents()
        {
            using TestEventListener listener = new TestEventListener();
            Events log = EnableEvents(listener);

            log.ClientConnectingToIpAddress(TestGuid, "192.168.1.1", 443);
            log.ClientConnectingToHost(TestGuid, "example.com", 443);
            log.AttemtingToSecureSslConnection(TestGuid);
            log.ConnectionSecured(TestGuid);
            log.ConnectionNotSecure(TestGuid);
            log.SslCertificateError(SslPolicyErrors.RemoteCertificateNotAvailable);
            log.HandshakeSent(TestGuid, "GET / HTTP/1.1");
            log.ReadingHttpResponse(TestGuid);
            log.ReadHttpResponseError(TestGuid, "connection reset");
            log.InvalidHttpResponseCode(TestGuid, "400 Bad Request");
            log.HandshakeFailure(TestGuid, "handshake failed");
            log.ClientHandshakeSuccess(TestGuid);
            log.ServerHandshakeSuccess(TestGuid);
            log.AcceptWebSocketStarted(TestGuid);
            log.SendingHandshakeResponse(TestGuid, "HTTP/1.1 101");
            log.WebSocketVersionNotSupported(TestGuid, "unsupported version");
            log.BadRequest(TestGuid, "malformed request");
            log.UsePerMessageDeflate(TestGuid);
            log.NoMessageCompression(TestGuid);
            log.KeepAliveIntervalZero(TestGuid);
            log.PingPongManagerStarted(TestGuid, 30);
            log.PingPongManagerEnded(TestGuid);
            log.KeepAliveIntervalExpired(TestGuid, 30);
            log.CloseOutputAutoTimeout(TestGuid, WebSocketCloseStatus.EndpointUnavailable, "shutdown", "timeout");
            log.CloseOutputAutoTimeoutCancelled(TestGuid, 5, WebSocketCloseStatus.EndpointUnavailable, "shutdown", "cancelled");
            log.CloseOutputAutoTimeoutError(TestGuid, "write failed", WebSocketCloseStatus.InternalServerError, "shutdown", "error");
            log.TryGetBufferNotSupported(TestGuid, "MemoryStream");
            log.SendingFrame(TestGuid, WebSocketOpCode.TextFrame, true, 16, false);
            log.ReceivedFrame(TestGuid, WebSocketOpCode.TextFrame, true, 16);
            log.CloseOutputNoHandshake(TestGuid, WebSocketCloseStatus.NormalClosure, "bye");
            log.CloseHandshakeStarted(TestGuid, WebSocketCloseStatus.NormalClosure, "bye");
            log.CloseHandshakeRespond(TestGuid, WebSocketCloseStatus.NormalClosure, "bye");
            log.CloseHandshakeComplete(TestGuid);
            log.CloseFrameReceivedInUnexpectedState(TestGuid, WebSocketState.CloseReceived, WebSocketCloseStatus.NormalClosure, "bye");
            log.WebSocketDispose(TestGuid, WebSocketState.Closed);
            log.WebSocketDisposeCloseTimeout(TestGuid, WebSocketState.Open);
            log.WebSocketDisposeError(TestGuid, WebSocketState.Aborted, "dispose failed");
            log.InvalidStateBeforeClose(TestGuid, WebSocketState.Open);
            log.InvalidStateBeforeCloseOutput(TestGuid, WebSocketState.Open);

            Assert.Equal(39, listener.EventCount);
            Assert.Equal(39, listener.EventIds.Count);
        }

        /// <summary>
        ///     Tests that the first event method writes an event when enabled
        /// </summary>
        [Fact]
        public void ClientConnectingToIpAddress_WhenEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events log = EnableEvents(listener);

            log.ClientConnectingToIpAddress(TestGuid, "10.0.0.5", 8080);

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     Tests that the received frame event writes an event when verbose is enabled
        /// </summary>
        [Fact]
        public void ReceivedFrame_WhenVerboseEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events log = EnableEvents(listener);

            log.ReceivedFrame(TestGuid, WebSocketOpCode.BinaryFrame, false, 32);

            Assert.Equal(1, listener.EventCount);
        }
    }
}