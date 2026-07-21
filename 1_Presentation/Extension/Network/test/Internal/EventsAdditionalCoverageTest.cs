// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsAdditionalCoverageTest.cs
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
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    public class EventsAdditionalCoverageTest
    {
        private static readonly Guid TestGuid = Guid.NewGuid();

        [Fact]
        public void ClientConnectingToIpAddress_DoesNotThrow()
        {
            Events.Log.ClientConnectingToIpAddress(TestGuid, "127.0.0.1", 8080);
        }

        [Fact]
        public void ClientConnectingToHost_DoesNotThrow()
        {
            Events.Log.ClientConnectingToHost(TestGuid, "localhost", 8080);
        }

        [Fact]
        public void AttemtingToSecureSslConnection_DoesNotThrow()
        {
            Events.Log.AttemtingToSecureSslConnection(TestGuid);
        }

        [Fact]
        public void ConnectionSecured_DoesNotThrow()
        {
            Events.Log.ConnectionSecured(TestGuid);
        }

        [Fact]
        public void ConnectionNotSecure_DoesNotThrow()
        {
            Events.Log.ConnectionNotSecure(TestGuid);
        }

        [Fact]
        public void SslCertificateError_DoesNotThrow()
        {
            Events.Log.SslCertificateError(new System.Net.Security.SslPolicyErrors());
        }

        [Fact]
        public void HandshakeSent_DoesNotThrow()
        {
            Events.Log.HandshakeSent(TestGuid, "key");
        }

        [Fact]
        public void ReadingHttpResponse_DoesNotThrow()
        {
            Events.Log.ReadingHttpResponse(TestGuid);
        }

        [Fact]
        public void ReadHttpResponseError_DoesNotThrow()
        {
            Events.Log.ReadHttpResponseError(TestGuid, "error");
        }

        [Fact]
        public void InvalidHttpResponseCode_DoesNotThrow()
        {
            Events.Log.InvalidHttpResponseCode(TestGuid, "500");
        }

        [Fact]
        public void HandshakeFailure_DoesNotThrow()
        {
            Events.Log.HandshakeFailure(TestGuid, "reason");
        }

        [Fact]
        public void ClientHandshakeSuccess_DoesNotThrow()
        {
            Events.Log.ClientHandshakeSuccess(TestGuid);
        }

        [Fact]
        public void ServerHandshakeSuccess_DoesNotThrow()
        {
            Events.Log.ServerHandshakeSuccess(TestGuid);
        }

        [Fact]
        public void AcceptWebSocketStarted_DoesNotThrow()
        {
            Events.Log.AcceptWebSocketStarted(TestGuid);
        }

        [Fact]
        public void SendingHandshakeResponse_DoesNotThrow()
        {
            Events.Log.SendingHandshakeResponse(TestGuid, "response");
        }

        [Fact]
        public void WebSocketVersionNotSupported_DoesNotThrow()
        {
            Events.Log.WebSocketVersionNotSupported(TestGuid, "version");
        }

        [Fact]
        public void BadRequest_DoesNotThrow()
        {
            Events.Log.BadRequest(TestGuid, "reason");
        }

        [Fact]
        public void UsePerMessageDeflate_DoesNotThrow()
        {
            Events.Log.UsePerMessageDeflate(TestGuid);
        }

        [Fact]
        public void NoMessageCompression_DoesNotThrow()
        {
            Events.Log.NoMessageCompression(TestGuid);
        }

        [Fact]
        public void KeepAliveIntervalZero_DoesNotThrow()
        {
            Events.Log.KeepAliveIntervalZero(TestGuid);
        }

        [Fact]
        public void PingPongManagerStarted_DoesNotThrow()
        {
            Events.Log.PingPongManagerStarted(TestGuid, 30);
        }

        [Fact]
        public void PingPongManagerEnded_DoesNotThrow()
        {
            Events.Log.PingPongManagerEnded(TestGuid);
        }

        [Fact]
        public void KeepAliveIntervalExpired_DoesNotThrow()
        {
            Events.Log.KeepAliveIntervalExpired(TestGuid, 5);
        }

        [Fact]
        public void CloseOutputAutoTimeout_DoesNotThrow()
        {
            Events.Log.CloseOutputAutoTimeout(TestGuid, System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "closing", "desc");
        }

        [Fact]
        public void CloseOutputAutoTimeoutCancelled_DoesNotThrow()
        {
            Events.Log.CloseOutputAutoTimeoutCancelled(TestGuid, 1000, System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "closing", "desc");
        }

        [Fact]
        public void CloseOutputAutoTimeoutError_DoesNotThrow()
        {
            Events.Log.CloseOutputAutoTimeoutError(TestGuid, "error", System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "closing", "desc");
        }

        [Fact]
        public void TryGetBufferNotSupported_DoesNotThrow()
        {
            Events.Log.TryGetBufferNotSupported(TestGuid, "MemoryStream");
        }

        [Fact]
        public void SendingFrame_DoesNotThrow()
        {
            Events.Log.SendingFrame(TestGuid, WebSocketOpCode.TextFrame, true, 100, false);
        }

        [Fact]
        public void ReceivedFrame_DoesNotThrow()
        {
            Events.Log.ReceivedFrame(TestGuid, WebSocketOpCode.TextFrame, true, 100);
        }

        [Fact]
        public void CloseOutputNoHandshake_DoesNotThrow()
        {
            Events.Log.CloseOutputNoHandshake(TestGuid, System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "reason");
        }

        [Fact]
        public void CloseHandshakeStarted_DoesNotThrow()
        {
            Events.Log.CloseHandshakeStarted(TestGuid, System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "reason");
        }

        [Fact]
        public void CloseHandshakeRespond_DoesNotThrow()
        {
            Events.Log.CloseHandshakeRespond(TestGuid, System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "reason");
        }

        [Fact]
        public void CloseHandshakeComplete_DoesNotThrow()
        {
            Events.Log.CloseHandshakeComplete(TestGuid);
        }

        [Fact]
        public void CloseFrameReceivedInUnexpectedState_DoesNotThrow()
        {
            Events.Log.CloseFrameReceivedInUnexpectedState(TestGuid, System.Net.WebSockets.WebSocketState.Open, System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "reason");
        }

        [Fact]
        public void WebSocketDispose_DoesNotThrow()
        {
            Events.Log.WebSocketDispose(TestGuid, System.Net.WebSockets.WebSocketState.Open);
        }

        [Fact]
        public void WebSocketDisposeCloseTimeout_DoesNotThrow()
        {
            Events.Log.WebSocketDisposeCloseTimeout(TestGuid, System.Net.WebSockets.WebSocketState.Open);
        }

        [Fact]
        public void WebSocketDisposeError_DoesNotThrow()
        {
            Events.Log.WebSocketDisposeError(TestGuid, System.Net.WebSockets.WebSocketState.Open, "error");
        }

        [Fact]
        public void InvalidStateBeforeClose_DoesNotThrow()
        {
            Events.Log.InvalidStateBeforeClose(TestGuid, System.Net.WebSockets.WebSocketState.Open);
        }

        [Fact]
        public void InvalidStateBeforeCloseOutput_DoesNotThrow()
        {
            Events.Log.InvalidStateBeforeCloseOutput(TestGuid, System.Net.WebSockets.WebSocketState.Open);
        }
    }
}
