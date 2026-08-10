// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsRemainingCoverageTests.cs
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
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The events remaining coverage tests class
    /// </summary>
    public class EventsRemainingCoverageTests : IDisposable
    {
        /// <summary>
        ///     The listener
        /// </summary>
        private readonly TestEventListener _listener = new TestEventListener();

        /// <summary>
        ///     The events
        /// </summary>
        private readonly Events _events = Events.Log;

        /// <summary>
        ///     Tests that client connecting to ip address writes event
        /// </summary>
        [Fact]
        public void ClientConnectingToIpAddress_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ClientConnectingToIpAddress(Guid.NewGuid(), "127.0.0.1", 80);

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that client connecting to host writes event
        /// </summary>
        [Fact]
        public void ClientConnectingToHost_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ClientConnectingToHost(Guid.NewGuid(), "example.com", 443);

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that attempting to secure ssl connection writes event
        /// </summary>
        [Fact]
        public void AttemtingToSecureSslConnection_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.AttemtingToSecureSslConnection(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that connection secured writes event
        /// </summary>
        [Fact]
        public void ConnectionSecured_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ConnectionSecured(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that connection not secure writes event
        /// </summary>
        [Fact]
        public void ConnectionNotSecure_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ConnectionNotSecure(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that ssl certificate error writes event
        /// </summary>
        [Fact]
        public void SslCertificateError_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.SslCertificateError(SslPolicyErrors.RemoteCertificateChainErrors);

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that handshake sent writes event
        /// </summary>
        [Fact]
        public void HandshakeSent_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.HandshakeSent(Guid.NewGuid(), "GET / HTTP/1.1");

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that reading http response writes event
        /// </summary>
        [Fact]
        public void ReadingHttpResponse_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ReadingHttpResponse(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that read http response error writes event
        /// </summary>
        [Fact]
        public void ReadHttpResponseError_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ReadHttpResponseError(Guid.NewGuid(), "error");

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that invalid http response code writes event
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCode_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.InvalidHttpResponseCode(Guid.NewGuid(), "400");

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that handshake failure writes event
        /// </summary>
        [Fact]
        public void HandshakeFailure_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.HandshakeFailure(Guid.NewGuid(), "failed");

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that client handshake success writes event
        /// </summary>
        [Fact]
        public void ClientHandshakeSuccess_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ClientHandshakeSuccess(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that server handshake success writes event
        /// </summary>
        [Fact]
        public void ServerHandshakeSuccess_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.ServerHandshakeSuccess(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that accept web socket started writes event
        /// </summary>
        [Fact]
        public void AcceptWebSocketStarted_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.AcceptWebSocketStarted(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that sending handshake response writes event
        /// </summary>
        [Fact]
        public void SendingHandshakeResponse_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.SendingHandshakeResponse(Guid.NewGuid(), "101");

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that web socket version not supported writes event
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupported_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.WebSocketVersionNotSupported(Guid.NewGuid(), "13");

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that bad request writes event
        /// </summary>
        [Fact]
        public void BadRequest_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.BadRequest(Guid.NewGuid(), "bad");

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Tests that use per message deflate writes event
        /// </summary>
        [Fact]
        public void UsePerMessageDeflate_WritesEvent()
        {
            _listener.EnableEvents(_events, EventLevel.Informational);
            _events.UsePerMessageDeflate(Guid.NewGuid());

            Assert.True(_listener.EventCount > 0);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose() => _listener.Dispose();

        /// <summary>
        ///     The test event listener class
        /// </summary>
        /// <seealso cref="EventListener"/>
        private sealed class TestEventListener : EventListener
        {
            /// <summary>
            ///     Gets the value of the event count
            /// </summary>
            public int EventCount { get; private set; }

            /// <summary>
            ///     Ons the event written using the specified event data
            /// </summary>
            /// <param name="eventData">The event data</param>
            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                EventCount++;
            }
        }
    }
}
