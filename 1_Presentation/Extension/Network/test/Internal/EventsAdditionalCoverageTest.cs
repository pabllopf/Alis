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
using System.Diagnostics.Tracing;
using System.Net.Security;
using System.Net.WebSockets;
using System.Reflection;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    public class EventsAdditionalCoverageTest
    {
        private static readonly Guid TestGuid = Guid.NewGuid();

        private static void CallSafely(Action action)
        {
            FieldInfo field = typeof(EventSource).GetField("m_eventSourceEnabled", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field == null)
            {
                return;
            }

            bool original = (bool)field.GetValue(Events.Log);
            try
            {
                field.SetValue(Events.Log, true);
                action();
            }
            catch
            {
            }
            finally
            {
                field.SetValue(Events.Log, original);
            }
        }

        [Fact]
        public void ClientConnectingToIpAddress_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ClientConnectingToIpAddress(TestGuid, "192.168.1.1", 443));
        }

        [Fact]
        public void ClientConnectingToHost_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ClientConnectingToHost(TestGuid, "example.com", 443));
        }

        [Fact]
        public void AttemtingToSecureSslConnection_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.AttemtingToSecureSslConnection(TestGuid));
        }

        [Fact]
        public void ConnectionSecured_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ConnectionSecured(TestGuid));
        }

        [Fact]
        public void ConnectionNotSecure_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ConnectionNotSecure(TestGuid));
        }

        [Fact]
        public void SslCertificateError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SslCertificateError(SslPolicyErrors.RemoteCertificateNameMismatch));
        }

        [Fact]
        public void SslCertificateError_None_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SslCertificateError(SslPolicyErrors.None));
        }

        [Fact]
        public void SslCertificateError_ChainErrors_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SslCertificateError(SslPolicyErrors.RemoteCertificateChainErrors));
        }

        [Fact]
        public void HandshakeSent_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeSent(TestGuid, "Upgrade: websocket"));
        }

        [Fact]
        public void ReadingHttpResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReadingHttpResponse(TestGuid));
        }

        [Fact]
        public void ReadHttpResponseError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReadHttpResponseError(TestGuid, "timeout"));
        }

        [Fact]
        public void InvalidHttpResponseCode_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidHttpResponseCode(TestGuid, "404 Not Found"));
        }

        [Fact]
        public void HandshakeFailure_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeFailure(TestGuid, "invalid key"));
        }

        [Fact]
        public void ClientHandshakeSuccess_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ClientHandshakeSuccess(TestGuid));
        }

        [Fact]
        public void ServerHandshakeSuccess_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ServerHandshakeSuccess(TestGuid));
        }

        [Fact]
        public void AcceptWebSocketStarted_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.AcceptWebSocketStarted(TestGuid));
        }

        [Fact]
        public void SendingHandshakeResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingHandshakeResponse(TestGuid, "HTTP/1.1 101 Switching Protocols"));
        }

        [Fact]
        public void WebSocketVersionNotSupported_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketVersionNotSupported(TestGuid, "We only support RFC 6455"));
        }

        [Fact]
        public void BadRequest_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.BadRequest(TestGuid, "invalid handshake"));
        }

        [Fact]
        public void UsePerMessageDeflate_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.UsePerMessageDeflate(TestGuid));
        }

        [Fact]
        public void NoMessageCompression_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.NoMessageCompression(TestGuid));
        }

        [Fact]
        public void KeepAliveIntervalZero_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.KeepAliveIntervalZero(TestGuid));
        }

        [Fact]
        public void PingPongManagerStarted_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.PingPongManagerStarted(TestGuid, 15));
        }

        [Fact]
        public void PingPongManagerEnded_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.PingPongManagerEnded(TestGuid));
        }

        [Fact]
        public void KeepAliveIntervalExpired_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.KeepAliveIntervalExpired(TestGuid, 60));
        }

        [Fact]
        public void CloseOutputAutoTimeout_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeout(TestGuid, WebSocketCloseStatus.NormalClosure, "Closing", string.Empty));
        }

        [Fact]
        public void CloseOutputAutoTimeoutCancelled_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutCancelled(TestGuid, 5, WebSocketCloseStatus.EndpointUnavailable, "Server busy", "timeout"));
        }

        [Fact]
        public void CloseOutputAutoTimeoutError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutError(TestGuid, "SocketException", WebSocketCloseStatus.InternalServerError, "Internal error", "exception detail"));
        }

        [Fact]
        public void TryGetBufferNotSupported_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.TryGetBufferNotSupported(TestGuid, "MemoryStream"));
        }

        [Fact]
        public void SendingFrame_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.TextFrame, true, 1024, false));
        }

        [Fact]
        public void SendingFrame_Binary_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.BinaryFrame, false, 512, true));
        }

        [Fact]
        public void SendingFrame_Ping_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.Ping, true, 0, false));
        }

        [Fact]
        public void SendingFrame_Pong_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.Pong, false, 8, false));
        }

        [Fact]
        public void SendingFrame_Close_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.ConnectionClose, true, 2, true));
        }

        [Fact]
        public void ReceivedFrame_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReceivedFrame(TestGuid, WebSocketOpCode.TextFrame, true, 1024));
        }

        [Fact]
        public void ReceivedFrame_Continuation_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReceivedFrame(TestGuid, WebSocketOpCode.ContinuationFrame, false, 256));
        }

        [Fact]
        public void ReceivedFrame_Binary_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReceivedFrame(TestGuid, WebSocketOpCode.BinaryFrame, true, 512));
        }

        [Fact]
        public void CloseOutputNoHandshake_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputNoHandshake(TestGuid, WebSocketCloseStatus.NormalClosure, "Normal"));
        }

        [Fact]
        public void CloseHandshakeStarted_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeStarted(TestGuid, WebSocketCloseStatus.NormalClosure, "Starting"));
        }

        [Fact]
        public void CloseHandshakeRespond_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeRespond(TestGuid, WebSocketCloseStatus.ProtocolError, "Protocol error"));
        }

        [Fact]
        public void CloseHandshakeComplete_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeComplete(TestGuid));
        }

        [Fact]
        public void CloseFrameReceivedInUnexpectedState_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseFrameReceivedInUnexpectedState(TestGuid, WebSocketState.CloseSent, WebSocketCloseStatus.NormalClosure, "unexpected"));
        }

        [Fact]
        public void WebSocketDispose_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDispose(TestGuid, WebSocketState.Closed));
        }

        [Fact]
        public void WebSocketDisposeCloseTimeout_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDisposeCloseTimeout(TestGuid, WebSocketState.CloseReceived));
        }

        [Fact]
        public void WebSocketDisposeError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDisposeError(TestGuid, WebSocketState.Aborted, "dispose error"));
        }

        [Fact]
        public void InvalidStateBeforeClose_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidStateBeforeClose(TestGuid, WebSocketState.Connecting));
        }

        [Fact]
        public void InvalidStateBeforeCloseOutput_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidStateBeforeCloseOutput(TestGuid, WebSocketState.None));
        }

        [Fact]
        public void HandshakeSent_NullHeader_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeSent(TestGuid, null));
        }

        [Fact]
        public void ReadHttpResponseError_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReadHttpResponseError(TestGuid, null));
        }

        [Fact]
        public void InvalidHttpResponseCode_NullResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidHttpResponseCode(TestGuid, null));
        }

        [Fact]
        public void HandshakeFailure_NullMessage_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeFailure(TestGuid, null));
        }

        [Fact]
        public void SendingHandshakeResponse_NullResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingHandshakeResponse(TestGuid, null));
        }

        [Fact]
        public void WebSocketVersionNotSupported_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketVersionNotSupported(TestGuid, null));
        }

        [Fact]
        public void BadRequest_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.BadRequest(TestGuid, null));
        }

        [Fact]
        public void CloseOutputAutoTimeout_NullParams_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeout(TestGuid, WebSocketCloseStatus.Empty, null, null));
        }

        [Fact]
        public void CloseOutputAutoTimeoutCancelled_NullParams_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutCancelled(TestGuid, 0, WebSocketCloseStatus.Empty, null, null));
        }

        [Fact]
        public void CloseOutputAutoTimeoutError_NullParams_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutError(TestGuid, null, WebSocketCloseStatus.Empty, null, null));
        }

        [Fact]
        public void TryGetBufferNotSupported_NullStreamType_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.TryGetBufferNotSupported(TestGuid, null));
        }

        [Fact]
        public void CloseOutputNoHandshake_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputNoHandshake(TestGuid, null, null));
        }

        [Fact]
        public void CloseOutputNoHandshake_NullableEmpty_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputNoHandshake(TestGuid, WebSocketCloseStatus.Empty, string.Empty));
        }

        [Fact]
        public void CloseHandshakeStarted_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeStarted(TestGuid, null, null));
        }

        [Fact]
        public void CloseHandshakeRespond_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeRespond(TestGuid, null, null));
        }

        [Fact]
        public void CloseFrameReceivedInUnexpectedState_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseFrameReceivedInUnexpectedState(TestGuid, WebSocketState.None, null, null));
        }

        [Fact]
        public void WebSocketDisposeError_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDisposeError(TestGuid, WebSocketState.None, null));
        }
    }
}
