// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsEnabledCoverageTests.cs
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
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     Calls every <see cref="Events" /> method with an enabled event listener so that the
    ///     WriteEvent paths are exercised for line coverage.
    /// </summary>
    public class EventsEnabledCoverageTests : IDisposable
    {
        /// <summary>
        ///     The listener
        /// </summary>
        private readonly TestEventListener _listener;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventsEnabledCoverageTests"/> class
        /// </summary>
        public EventsEnabledCoverageTests()
        {
            _listener = new TestEventListener();
        }

        /// <summary>
        ///     Disposes the listener
        /// </summary>
        public void Dispose()
        {
            _listener.Dispose();
        }

        /// <summary>
        ///     Tests that every remaining event method executes its write event path when enabled.
        /// </summary>
        [Fact]
        public void AllRemainingEvents_WithEnabledListener_WriteEvents()
        {
            Guid guid = Guid.NewGuid();
            Events.Log.ClientConnectingToIpAddress(guid, "127.0.0.1", 8080);
            Events.Log.ClientConnectingToHost(guid, "localhost", 8080);
            Events.Log.AttemtingToSecureSslConnection(guid);
            Events.Log.ConnectionSecured(guid);
            Events.Log.ConnectionNotSecure(guid);
            Events.Log.SslCertificateError(SslPolicyErrors.None);
            Events.Log.HandshakeSent(guid, "GET / HTTP/1.1");
            Events.Log.ReadingHttpResponse(guid);
            Events.Log.ReadHttpResponseError(guid, "error");
            Events.Log.InvalidHttpResponseCode(guid, "HTTP/1.1 400");
            Events.Log.HandshakeFailure(guid, "failure");
            Events.Log.ClientHandshakeSuccess(guid);
            Events.Log.ServerHandshakeSuccess(guid);
            Events.Log.AcceptWebSocketStarted(guid);
            Events.Log.SendingHandshakeResponse(guid, "HTTP/1.1 101");
            Events.Log.WebSocketVersionNotSupported(guid, "version");
            Events.Log.BadRequest(guid, "bad");
            Events.Log.UsePerMessageDeflate(guid);
            Events.Log.NoMessageCompression(guid);
            Events.Log.KeepAliveIntervalZero(guid);
            Events.Log.PingPongManagerStarted(guid, 5);
            Events.Log.PingPongManagerEnded(guid);
            Events.Log.KeepAliveIntervalExpired(guid, 5);
            Events.Log.CloseOutputAutoTimeout(guid, WebSocketCloseStatus.NormalClosure, "bye", "exception");
            Events.Log.CloseOutputAutoTimeoutCancelled(guid, 5, WebSocketCloseStatus.NormalClosure, "bye", "exception");
            Events.Log.CloseOutputAutoTimeoutError(guid, "close-ex", WebSocketCloseStatus.NormalClosure, "bye", "exception");
            Events.Log.TryGetBufferNotSupported(guid, "MemoryStream");
            Events.Log.SendingFrame(guid, WebSocketOpCode.TextFrame, true, 10, false);
            Events.Log.ReceivedFrame(guid, WebSocketOpCode.TextFrame, true, 10);
            Events.Log.CloseOutputNoHandshake(guid, WebSocketCloseStatus.NormalClosure, "bye");
            Events.Log.CloseHandshakeStarted(guid, WebSocketCloseStatus.NormalClosure, "bye");
            Events.Log.CloseHandshakeRespond(guid, WebSocketCloseStatus.NormalClosure, "bye");
            Events.Log.CloseHandshakeComplete(guid);
            Events.Log.CloseFrameReceivedInUnexpectedState(guid, WebSocketState.Open, WebSocketCloseStatus.NormalClosure, "bye");
            Events.Log.WebSocketDispose(guid, WebSocketState.Open);
            Events.Log.WebSocketDisposeCloseTimeout(guid, WebSocketState.Open);
            Events.Log.WebSocketDisposeError(guid, WebSocketState.Open, "exception");
            Events.Log.InvalidStateBeforeClose(guid, WebSocketState.Open);
            Events.Log.InvalidStateBeforeCloseOutput(guid, WebSocketState.Open);
        }

        /// <summary>
        ///     The test event listener class
        /// </summary>
        /// <seealso cref="EventListener"/>
        internal sealed class TestEventListener : EventListener
        {
            /// <summary>
            ///     Ons the event source created using the specified event source
            /// </summary>
            /// <param name="eventSource">The event source</param>
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource.Name == "Ninja-WebSockets")
                {
                    EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
                }
            }
        }
    }
}
