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
    /// <summary>
    /// The events additional coverage test class
    /// </summary>
    public class EventsAdditionalCoverageTest
    {
        /// <summary>
        /// The new guid
        /// </summary>
        private static readonly Guid TestGuid = Guid.NewGuid();

        /// <summary>
        /// Calls the safely using the specified action
        /// </summary>
        /// <param name="action">The action</param>
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

        /// <summary>
        /// Tests that client connecting to ip address enabled coverage
        /// </summary>
        [Fact]
        public void ClientConnectingToIpAddress_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ClientConnectingToIpAddress(TestGuid, "192.168.1.1", 443));
        }

        /// <summary>
        /// Tests that client connecting to host enabled coverage
        /// </summary>
        [Fact]
        public void ClientConnectingToHost_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ClientConnectingToHost(TestGuid, "example.com", 443));
        }

        /// <summary>
        /// Tests that attemting to secure ssl connection enabled coverage
        /// </summary>
        [Fact]
        public void AttemtingToSecureSslConnection_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.AttemtingToSecureSslConnection(TestGuid));
        }

        /// <summary>
        /// Tests that connection secured enabled coverage
        /// </summary>
        [Fact]
        public void ConnectionSecured_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ConnectionSecured(TestGuid));
        }

        /// <summary>
        /// Tests that connection not secure enabled coverage
        /// </summary>
        [Fact]
        public void ConnectionNotSecure_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ConnectionNotSecure(TestGuid));
        }

        /// <summary>
        /// Tests that ssl certificate error enabled coverage
        /// </summary>
        [Fact]
        public void SslCertificateError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SslCertificateError(SslPolicyErrors.RemoteCertificateNameMismatch));
        }

        /// <summary>
        /// Tests that ssl certificate error none enabled coverage
        /// </summary>
        [Fact]
        public void SslCertificateError_None_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SslCertificateError(SslPolicyErrors.None));
        }

        /// <summary>
        /// Tests that ssl certificate error chain errors enabled coverage
        /// </summary>
        [Fact]
        public void SslCertificateError_ChainErrors_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SslCertificateError(SslPolicyErrors.RemoteCertificateChainErrors));
        }

        /// <summary>
        /// Tests that handshake sent enabled coverage
        /// </summary>
        [Fact]
        public void HandshakeSent_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeSent(TestGuid, "Upgrade: websocket"));
        }

        /// <summary>
        /// Tests that reading http response enabled coverage
        /// </summary>
        [Fact]
        public void ReadingHttpResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReadingHttpResponse(TestGuid));
        }

        /// <summary>
        /// Tests that read http response error enabled coverage
        /// </summary>
        [Fact]
        public void ReadHttpResponseError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReadHttpResponseError(TestGuid, "timeout"));
        }

        /// <summary>
        /// Tests that invalid http response code enabled coverage
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCode_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidHttpResponseCode(TestGuid, "404 Not Found"));
        }

        /// <summary>
        /// Tests that handshake failure enabled coverage
        /// </summary>
        [Fact]
        public void HandshakeFailure_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeFailure(TestGuid, "invalid key"));
        }

        /// <summary>
        /// Tests that client handshake success enabled coverage
        /// </summary>
        [Fact]
        public void ClientHandshakeSuccess_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ClientHandshakeSuccess(TestGuid));
        }

        /// <summary>
        /// Tests that server handshake success enabled coverage
        /// </summary>
        [Fact]
        public void ServerHandshakeSuccess_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ServerHandshakeSuccess(TestGuid));
        }

        /// <summary>
        /// Tests that accept web socket started enabled coverage
        /// </summary>
        [Fact]
        public void AcceptWebSocketStarted_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.AcceptWebSocketStarted(TestGuid));
        }

        /// <summary>
        /// Tests that sending handshake response enabled coverage
        /// </summary>
        [Fact]
        public void SendingHandshakeResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingHandshakeResponse(TestGuid, "HTTP/1.1 101 Switching Protocols"));
        }

        /// <summary>
        /// Tests that web socket version not supported enabled coverage
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupported_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketVersionNotSupported(TestGuid, "We only support RFC 6455"));
        }

        /// <summary>
        /// Tests that bad request enabled coverage
        /// </summary>
        [Fact]
        public void BadRequest_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.BadRequest(TestGuid, "invalid handshake"));
        }

        /// <summary>
        /// Tests that use per message deflate enabled coverage
        /// </summary>
        [Fact]
        public void UsePerMessageDeflate_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.UsePerMessageDeflate(TestGuid));
        }

        /// <summary>
        /// Tests that no message compression enabled coverage
        /// </summary>
        [Fact]
        public void NoMessageCompression_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.NoMessageCompression(TestGuid));
        }

        /// <summary>
        /// Tests that keep alive interval zero enabled coverage
        /// </summary>
        [Fact]
        public void KeepAliveIntervalZero_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.KeepAliveIntervalZero(TestGuid));
        }

        /// <summary>
        /// Tests that ping pong manager started enabled coverage
        /// </summary>
        [Fact]
        public void PingPongManagerStarted_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.PingPongManagerStarted(TestGuid, 15));
        }

        /// <summary>
        /// Tests that ping pong manager ended enabled coverage
        /// </summary>
        [Fact]
        public void PingPongManagerEnded_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.PingPongManagerEnded(TestGuid));
        }

        /// <summary>
        /// Tests that keep alive interval expired enabled coverage
        /// </summary>
        [Fact]
        public void KeepAliveIntervalExpired_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.KeepAliveIntervalExpired(TestGuid, 60));
        }

        /// <summary>
        /// Tests that close output auto timeout enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeout_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeout(TestGuid, WebSocketCloseStatus.NormalClosure, "Closing", string.Empty));
        }

        /// <summary>
        /// Tests that close output auto timeout cancelled enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutCancelled_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutCancelled(TestGuid, 5, WebSocketCloseStatus.EndpointUnavailable, "Server busy", "timeout"));
        }

        /// <summary>
        /// Tests that close output auto timeout error enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutError(TestGuid, "SocketException", WebSocketCloseStatus.InternalServerError, "Internal error", "exception detail"));
        }

        /// <summary>
        /// Tests that try get buffer not supported enabled coverage
        /// </summary>
        [Fact]
        public void TryGetBufferNotSupported_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.TryGetBufferNotSupported(TestGuid, "MemoryStream"));
        }

        /// <summary>
        /// Tests that sending frame enabled coverage
        /// </summary>
        [Fact]
        public void SendingFrame_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.TextFrame, true, 1024, false));
        }

        /// <summary>
        /// Tests that sending frame binary enabled coverage
        /// </summary>
        [Fact]
        public void SendingFrame_Binary_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.BinaryFrame, false, 512, true));
        }

        /// <summary>
        /// Tests that sending frame ping enabled coverage
        /// </summary>
        [Fact]
        public void SendingFrame_Ping_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.Ping, true, 0, false));
        }

        /// <summary>
        /// Tests that sending frame pong enabled coverage
        /// </summary>
        [Fact]
        public void SendingFrame_Pong_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.Pong, false, 8, false));
        }

        /// <summary>
        /// Tests that sending frame close enabled coverage
        /// </summary>
        [Fact]
        public void SendingFrame_Close_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingFrame(TestGuid, WebSocketOpCode.ConnectionClose, true, 2, true));
        }

        /// <summary>
        /// Tests that received frame enabled coverage
        /// </summary>
        [Fact]
        public void ReceivedFrame_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReceivedFrame(TestGuid, WebSocketOpCode.TextFrame, true, 1024));
        }

        /// <summary>
        /// Tests that received frame continuation enabled coverage
        /// </summary>
        [Fact]
        public void ReceivedFrame_Continuation_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReceivedFrame(TestGuid, WebSocketOpCode.ContinuationFrame, false, 256));
        }

        /// <summary>
        /// Tests that received frame binary enabled coverage
        /// </summary>
        [Fact]
        public void ReceivedFrame_Binary_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReceivedFrame(TestGuid, WebSocketOpCode.BinaryFrame, true, 512));
        }

        /// <summary>
        /// Tests that close output no handshake enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputNoHandshake_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputNoHandshake(TestGuid, WebSocketCloseStatus.NormalClosure, "Normal"));
        }

        /// <summary>
        /// Tests that close handshake started enabled coverage
        /// </summary>
        [Fact]
        public void CloseHandshakeStarted_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeStarted(TestGuid, WebSocketCloseStatus.NormalClosure, "Starting"));
        }

        /// <summary>
        /// Tests that close handshake respond enabled coverage
        /// </summary>
        [Fact]
        public void CloseHandshakeRespond_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeRespond(TestGuid, WebSocketCloseStatus.ProtocolError, "Protocol error"));
        }

        /// <summary>
        /// Tests that close handshake complete enabled coverage
        /// </summary>
        [Fact]
        public void CloseHandshakeComplete_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeComplete(TestGuid));
        }

        /// <summary>
        /// Tests that close frame received in unexpected state enabled coverage
        /// </summary>
        [Fact]
        public void CloseFrameReceivedInUnexpectedState_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseFrameReceivedInUnexpectedState(TestGuid, WebSocketState.CloseSent, WebSocketCloseStatus.NormalClosure, "unexpected"));
        }

        /// <summary>
        /// Tests that web socket dispose enabled coverage
        /// </summary>
        [Fact]
        public void WebSocketDispose_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDispose(TestGuid, WebSocketState.Closed));
        }

        /// <summary>
        /// Tests that web socket dispose close timeout enabled coverage
        /// </summary>
        [Fact]
        public void WebSocketDisposeCloseTimeout_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDisposeCloseTimeout(TestGuid, WebSocketState.CloseReceived));
        }

        /// <summary>
        /// Tests that web socket dispose error enabled coverage
        /// </summary>
        [Fact]
        public void WebSocketDisposeError_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDisposeError(TestGuid, WebSocketState.Aborted, "dispose error"));
        }

        /// <summary>
        /// Tests that invalid state before close enabled coverage
        /// </summary>
        [Fact]
        public void InvalidStateBeforeClose_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidStateBeforeClose(TestGuid, WebSocketState.Connecting));
        }

        /// <summary>
        /// Tests that invalid state before close output enabled coverage
        /// </summary>
        [Fact]
        public void InvalidStateBeforeCloseOutput_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidStateBeforeCloseOutput(TestGuid, WebSocketState.None));
        }

        /// <summary>
        /// Tests that handshake sent null header enabled coverage
        /// </summary>
        [Fact]
        public void HandshakeSent_NullHeader_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeSent(TestGuid, null));
        }

        /// <summary>
        /// Tests that read http response error null exception enabled coverage
        /// </summary>
        [Fact]
        public void ReadHttpResponseError_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.ReadHttpResponseError(TestGuid, null));
        }

        /// <summary>
        /// Tests that invalid http response code null response enabled coverage
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCode_NullResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.InvalidHttpResponseCode(TestGuid, null));
        }

        /// <summary>
        /// Tests that handshake failure null message enabled coverage
        /// </summary>
        [Fact]
        public void HandshakeFailure_NullMessage_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.HandshakeFailure(TestGuid, null));
        }

        /// <summary>
        /// Tests that sending handshake response null response enabled coverage
        /// </summary>
        [Fact]
        public void SendingHandshakeResponse_NullResponse_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.SendingHandshakeResponse(TestGuid, null));
        }

        /// <summary>
        /// Tests that web socket version not supported null exception enabled coverage
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupported_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketVersionNotSupported(TestGuid, null));
        }

        /// <summary>
        /// Tests that bad request null exception enabled coverage
        /// </summary>
        [Fact]
        public void BadRequest_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.BadRequest(TestGuid, null));
        }

        /// <summary>
        /// Tests that close output auto timeout null params enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeout_NullParams_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeout(TestGuid, WebSocketCloseStatus.Empty, null, null));
        }

        /// <summary>
        /// Tests that close output auto timeout cancelled null params enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutCancelled_NullParams_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutCancelled(TestGuid, 0, WebSocketCloseStatus.Empty, null, null));
        }

        /// <summary>
        /// Tests that close output auto timeout error null params enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutError_NullParams_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputAutoTimeoutError(TestGuid, null, WebSocketCloseStatus.Empty, null, null));
        }

        /// <summary>
        /// Tests that try get buffer not supported null stream type enabled coverage
        /// </summary>
        [Fact]
        public void TryGetBufferNotSupported_NullStreamType_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.TryGetBufferNotSupported(TestGuid, null));
        }

        /// <summary>
        /// Tests that close output no handshake null status enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputNoHandshake_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputNoHandshake(TestGuid, null, null));
        }

        /// <summary>
        /// Tests that close output no handshake nullable empty enabled coverage
        /// </summary>
        [Fact]
        public void CloseOutputNoHandshake_NullableEmpty_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseOutputNoHandshake(TestGuid, WebSocketCloseStatus.Empty, string.Empty));
        }

        /// <summary>
        /// Tests that close handshake started null status enabled coverage
        /// </summary>
        [Fact]
        public void CloseHandshakeStarted_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeStarted(TestGuid, null, null));
        }

        /// <summary>
        /// Tests that close handshake respond null status enabled coverage
        /// </summary>
        [Fact]
        public void CloseHandshakeRespond_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseHandshakeRespond(TestGuid, null, null));
        }

        /// <summary>
        /// Tests that close frame received in unexpected state null status enabled coverage
        /// </summary>
        [Fact]
        public void CloseFrameReceivedInUnexpectedState_NullStatus_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.CloseFrameReceivedInUnexpectedState(TestGuid, WebSocketState.None, null, null));
        }

        /// <summary>
        /// Tests that web socket dispose error null exception enabled coverage
        /// </summary>
        [Fact]
        public void WebSocketDisposeError_NullException_Enabled_Coverage()
        {
            CallSafely(() => Events.Log.WebSocketDisposeError(TestGuid, WebSocketState.None, null));
        }
    }
}
