// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsTest.cs
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
    ///     The events test class
    /// </summary>
    public class EventsTest
    {
        /// <summary>
        ///     Tests that client connecting to ip address valid input
        /// </summary>
        [Fact]
        public void ClientConnectingToIpAddress_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string ipAddress = "127.0.0.1";
            int port = 8080;

            Events.Log.ClientConnectingToIpAddress(guid, ipAddress, port);
        }

        /// <summary>
        ///     Tests that client connecting to host valid input
        /// </summary>
        [Fact]
        public void ClientConnectingToHost_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string host = "localhost";
            int port = 8080;

            Events.Log.ClientConnectingToHost(guid, host, port);
        }

        /// <summary>
        ///     Tests that attemting to secure ssl connection valid input
        /// </summary>
        [Fact]
        public void AttemtingToSecureSslConnection_ValidInput()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.AttemtingToSecureSslConnection(guid);
        }

        /// <summary>
        ///     Tests that connection secured valid input
        /// </summary>
        [Fact]
        public void ConnectionSecured_ValidInput()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.ConnectionSecured(guid);
        }

        /// <summary>
        ///     Tests that connection not secure valid input
        /// </summary>
        [Fact]
        public void ConnectionNotSecure_ValidInput()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.ConnectionNotSecure(guid);
        }

        /// <summary>
        ///     Tests that close handshake complete valid input
        /// </summary>
        [Fact]
        public void CloseHandshakeComplete_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.CloseHandshakeComplete(guid);
        }

        /// <summary>
        ///     Tests that close frame received in unexpected state valid input
        /// </summary>
        [Fact]
        public void CloseFrameReceivedInUnexpectedState_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            WebSocketState webSocketState = WebSocketState.Open;
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";

            events.CloseFrameReceivedInUnexpectedState(guid, webSocketState, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that web socket dispose valid input
        /// </summary>
        [Fact]
        public void WebSocketDispose_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            WebSocketState webSocketState = WebSocketState.Open;

            events.WebSocketDispose(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that web socket dispose close timeout valid input
        /// </summary>
        [Fact]
        public void WebSocketDisposeCloseTimeout_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            WebSocketState webSocketState = WebSocketState.Open;

            events.WebSocketDisposeCloseTimeout(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that web socket dispose error valid input
        /// </summary>
        [Fact]
        public void WebSocketDisposeError_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            WebSocketState webSocketState = WebSocketState.Open;
            string exception = "Test exception";

            events.WebSocketDisposeError(guid, webSocketState, exception);
        }

        /// <summary>
        ///     Tests that invalid state before close valid input
        /// </summary>
        [Fact]
        public void InvalidStateBeforeClose_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            WebSocketState webSocketState = WebSocketState.Open;

            events.InvalidStateBeforeClose(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that invalid state before close output valid input
        /// </summary>
        [Fact]
        public void InvalidStateBeforeCloseOutput_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            WebSocketState webSocketState = WebSocketState.Open;

            events.InvalidStateBeforeCloseOutput(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that try get buffer not supported valid input
        /// </summary>
        [Fact]
        public void TryGetBufferNotSupported_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string streamType = "TestStreamType";
            Events events = Events.Log;

            events.TryGetBufferNotSupported(guid, streamType);
        }

        /// <summary>
        ///     Tests that sending frame valid input
        /// </summary>
        [Fact]
        public void SendingFrame_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            bool isFinBitSet = true;
            int numBytes = 1024;
            bool isPayloadCompressed = true;
            Events events = Events.Log;

            events.SendingFrame(guid, webSocketOpCode, isFinBitSet, numBytes, isPayloadCompressed);
        }

        /// <summary>
        ///     Tests that received frame valid input
        /// </summary>
        [Fact]
        public void ReceivedFrame_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            bool isFinBitSet = true;
            int numBytes = 1024;
            Events events = Events.Log;

            events.ReceivedFrame(guid, webSocketOpCode, isFinBitSet, numBytes);
        }

        /// <summary>
        ///     Tests that close output no handshake valid input
        /// </summary>
        [Fact]
        public void CloseOutputNoHandshake_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";
            Events events = Events.Log;

            events.CloseOutputNoHandshake(guid, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that close handshake started valid input
        /// </summary>
        [Fact]
        public void CloseHandshakeStarted_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";
            Events events = Events.Log;

            events.CloseHandshakeStarted(guid, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that close handshake respond valid input
        /// </summary>
        [Fact]
        public void CloseHandshakeRespond_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";
            Events events = Events.Log;

            events.CloseHandshakeRespond(guid, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that keep alive interval zero valid input
        /// </summary>
        [Fact]
        public void KeepAliveIntervalZero_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.KeepAliveIntervalZero(guid);
        }

        /// <summary>
        ///     Tests that ping pong manager started valid input
        /// </summary>
        [Fact]
        public void PingPongManagerStarted_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 30;
            Events events = Events.Log;

            events.PingPongManagerStarted(guid, keepAliveIntervalSeconds);
        }

        /// <summary>
        ///     Tests that ping pong manager ended valid input
        /// </summary>
        [Fact]
        public void PingPongManagerEnded_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.PingPongManagerEnded(guid);
        }

        /// <summary>
        ///     Tests that keep alive interval expired valid input
        /// </summary>
        [Fact]
        public void KeepAliveIntervalExpired_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 30;
            Events events = Events.Log;

            events.KeepAliveIntervalExpired(guid, keepAliveIntervalSeconds);
        }

        /// <summary>
        ///     Tests that close output auto timeout valid input
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeout_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";
            string exception = "Test exception";
            Events events = Events.Log;

            events.CloseOutputAutoTimeout(guid, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that close output auto timeout cancelled valid input
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutCancelled_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            int timeoutSeconds = 30;
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";
            string exception = "Test exception";
            Events events = Events.Log;

            events.CloseOutputAutoTimeoutCancelled(guid, timeoutSeconds, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that close output auto timeout error valid input
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutError_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string closeException = "Test close exception";
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";
            string exception = "Test exception";
            Events events = Events.Log;

            events.CloseOutputAutoTimeoutError(guid, closeException, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that server handshake success valid input
        /// </summary>
        [Fact]
        public void ServerHandshakeSuccess_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.ServerHandshakeSuccess(guid);
        }

        /// <summary>
        ///     Tests that accept web socket started valid input
        /// </summary>
        [Fact]
        public void AcceptWebSocketStarted_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.AcceptWebSocketStarted(guid);
        }

        /// <summary>
        ///     Tests that sending handshake response valid input
        /// </summary>
        [Fact]
        public void SendingHandshakeResponse_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string response = "Test response";
            Events events = Events.Log;

            events.SendingHandshakeResponse(guid, response);
        }

        /// <summary>
        ///     Tests that web socket version not supported valid input
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupported_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";
            Events events = Events.Log;

            events.WebSocketVersionNotSupported(guid, exception);
        }

        /// <summary>
        ///     Tests that bad request valid input
        /// </summary>
        [Fact]
        public void BadRequest_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";
            Events events = Events.Log;

            events.BadRequest(guid, exception);
        }

        /// <summary>
        ///     Tests that use per message deflate valid input
        /// </summary>
        [Fact]
        public void UsePerMessageDeflate_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.UsePerMessageDeflate(guid);
        }

        /// <summary>
        ///     Tests that no message compression valid input
        /// </summary>
        [Fact]
        public void NoMessageCompression_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.NoMessageCompression(guid);
        }

        /// <summary>
        ///     Tests that ssl certificate error valid input
        /// </summary>
        [Fact]
        public void SslCertificateError_ValidInput()
        {
            SslPolicyErrors sslPolicyErrors = SslPolicyErrors.RemoteCertificateChainErrors;
            Events events = Events.Log;

            events.SslCertificateError(sslPolicyErrors);
        }

        /// <summary>
        ///     Tests that handshake sent valid input
        /// </summary>
        [Fact]
        public void HandshakeSent_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string httpHeader = "Test header";
            Events events = Events.Log;

            events.HandshakeSent(guid, httpHeader);
        }

        /// <summary>
        ///     Tests that reading http response valid input
        /// </summary>
        [Fact]
        public void ReadingHttpResponse_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.ReadingHttpResponse(guid);
        }

        /// <summary>
        ///     Tests that read http response error valid input
        /// </summary>
        [Fact]
        public void ReadHttpResponseError_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";
            Events events = Events.Log;

            events.ReadHttpResponseError(guid, exception);
        }

        /// <summary>
        ///     Tests that invalid http response code valid input
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCode_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string response = "Test response";
            Events events = Events.Log;

            events.InvalidHttpResponseCode(guid, response);
        }

        /// <summary>
        ///     Tests that handshake failure valid input
        /// </summary>
        [Fact]
        public void HandshakeFailure_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string message = "Test message";
            Events events = Events.Log;

            events.HandshakeFailure(guid, message);
        }

        /// <summary>
        ///     Tests that client handshake success valid input
        /// </summary>
        [Fact]
        public void ClientHandshakeSuccess_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;

            events.ClientHandshakeSuccess(guid);
        }

        /// <summary>
        ///     Tests that client connecting to ip address test
        /// </summary>
        [Fact]
        public void ClientConnectingToIpAddress_Test()
        {
            Guid guid = Guid.NewGuid();
            string ipAddress = "127.0.0.1";
            int port = 8080;

            Events.Log.ClientConnectingToIpAddress(guid, ipAddress, port);
        }

        /// <summary>
        ///     Tests that web socket dispose error test
        /// </summary>
        [Fact]
        public void WebSocketDisposeError_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            string exception = "Test exception";

            Events.Log.WebSocketDisposeError(guid, webSocketState, exception);
        }

        /// <summary>
        ///     Tests that invalid state before close test
        /// </summary>
        [Fact]
        public void InvalidStateBeforeClose_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;

            Events.Log.InvalidStateBeforeClose(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that invalid state before close output test
        /// </summary>
        [Fact]
        public void InvalidStateBeforeCloseOutput_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;

            Events.Log.InvalidStateBeforeCloseOutput(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that ping pong manager started test
        /// </summary>
        [Fact]
        public void PingPongManagerStarted_Test()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;

            Events.Log.PingPongManagerStarted(guid, keepAliveIntervalSeconds);
        }

        /// <summary>
        ///     Tests that ping pong manager ended test
        /// </summary>
        [Fact]
        public void PingPongManagerEnded_Test()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.PingPongManagerEnded(guid);
        }

        /// <summary>
        ///     Tests that keep alive interval expired test
        /// </summary>
        [Fact]
        public void KeepAliveIntervalExpired_Test()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;

            Events.Log.KeepAliveIntervalExpired(guid, keepAliveIntervalSeconds);
        }

        /// <summary>
        ///     Tests that close output auto timeout test
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeout_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.EndpointUnavailable;
            string statusDescription = "Test description";
            string exception = "Test exception";

            Events.Log.CloseOutputAutoTimeout(guid, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that close output auto timeout cancelled test
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutCancelled_Test()
        {
            Guid guid = Guid.NewGuid();
            int timeoutSeconds = 10;
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.EndpointUnavailable;
            string statusDescription = "Test description";
            string exception = "Test exception";

            Events.Log.CloseOutputAutoTimeoutCancelled(guid, timeoutSeconds, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that close output auto timeout error test
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutError_Test()
        {
            Guid guid = Guid.NewGuid();
            string closeException = "Test close exception";
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.EndpointUnavailable;
            string statusDescription = "Test description";
            string exception = "Test exception";

            Events.Log.CloseOutputAutoTimeoutError(guid, closeException, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that test client connecting to ip address
        /// </summary>
        [Fact]
        public void Test_ClientConnectingToIpAddress()
        {
            Guid guid = Guid.NewGuid();
            string ipAddress = "127.0.0.1";
            int port = 8080;

            Events.Log.ClientConnectingToIpAddress(guid, ipAddress, port);
        }

        /// <summary>
        ///     Tests that test client connecting to host
        /// </summary>
        [Fact]
        public void Test_ClientConnectingToHost()
        {
            Guid guid = Guid.NewGuid();
            string host = "localhost";
            int port = 8080;

            Events.Log.ClientConnectingToHost(guid, host, port);
        }

        /// <summary>
        ///     Tests that test attemting to secure ssl connection
        /// </summary>
        [Fact]
        public void Test_AttemtingToSecureSslConnection()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.AttemtingToSecureSslConnection(guid);
        }

        /// <summary>
        ///     Tests that test connection secured
        /// </summary>
        [Fact]
        public void Test_ConnectionSecured()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.ConnectionSecured(guid);
        }

        /// <summary>
        ///     Tests that test connection not secure
        /// </summary>
        [Fact]
        public void Test_ConnectionNotSecure()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.ConnectionNotSecure(guid);
        }

        /// <summary>
        ///     Tests that test ssl certificate error
        /// </summary>
        [Fact]
        public void Test_SslCertificateError()
        {
            SslPolicyErrors sslPolicyErrors = SslPolicyErrors.RemoteCertificateChainErrors;

            Events.Log.SslCertificateError(sslPolicyErrors);
        }

        /// <summary>
        ///     Tests that test handshake sent
        /// </summary>
        [Fact]
        public void Test_HandshakeSent()
        {
            Guid guid = Guid.NewGuid();
            string httpHeader = "Test header";

            Events.Log.HandshakeSent(guid, httpHeader);
        }

        /// <summary>
        ///     Tests that test reading http response
        /// </summary>
        [Fact]
        public void Test_ReadingHttpResponse()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.ReadingHttpResponse(guid);
        }

        /// <summary>
        ///     Tests that test read http response error
        /// </summary>
        [Fact]
        public void Test_ReadHttpResponseError()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";

            Events.Log.ReadHttpResponseError(guid, exception);
        }

        /// <summary>
        ///     Tests that test invalid http response code
        /// </summary>
        [Fact]
        public void Test_InvalidHttpResponseCode()
        {
            Guid guid = Guid.NewGuid();
            string response = "Test response";

            Events.Log.InvalidHttpResponseCode(guid, response);
        }

        /// <summary>
        ///     Tests that test handshake failure
        /// </summary>
        [Fact]
        public void Test_HandshakeFailure()
        {
            Guid guid = Guid.NewGuid();
            string message = "Test message";

            Events.Log.HandshakeFailure(guid, message);
        }

        /// <summary>
        ///     Tests that test client handshake success
        /// </summary>
        [Fact]
        public void Test_ClientHandshakeSuccess()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.ClientHandshakeSuccess(guid);
        }

        /// <summary>
        ///     Tests that test server handshake success
        /// </summary>
        [Fact]
        public void Test_ServerHandshakeSuccess()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.ServerHandshakeSuccess(guid);
        }

        /// <summary>
        ///     Tests that test accept web socket started
        /// </summary>
        [Fact]
        public void Test_AcceptWebSocketStarted()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.AcceptWebSocketStarted(guid);
        }

        /// <summary>
        ///     Tests that test sending handshake response
        /// </summary>
        [Fact]
        public void Test_SendingHandshakeResponse()
        {
            Guid guid = Guid.NewGuid();
            string response = "Test response";

            Events.Log.SendingHandshakeResponse(guid, response);
        }

        /// <summary>
        ///     Tests that test web socket version not supported
        /// </summary>
        [Fact]
        public void Test_WebSocketVersionNotSupported()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";

            Events.Log.WebSocketVersionNotSupported(guid, exception);
        }

        /// <summary>
        ///     Tests that test bad request
        /// </summary>
        [Fact]
        public void Test_BadRequest()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";

            Events.Log.BadRequest(guid, exception);
        }

        /// <summary>
        ///     Tests that test use per message deflate
        /// </summary>
        [Fact]
        public void Test_UsePerMessageDeflate()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.UsePerMessageDeflate(guid);
        }

        /// <summary>
        ///     Tests that test no message compression
        /// </summary>
        [Fact]
        public void Test_NoMessageCompression()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.NoMessageCompression(guid);
        }

        /// <summary>
        ///     Tests that test keep alive interval zero
        /// </summary>
        [Fact]
        public void Test_KeepAliveIntervalZero()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.KeepAliveIntervalZero(guid);
        }

        /// <summary>
        ///     Tests that test ping pong manager started
        /// </summary>
        [Fact]
        public void Test_PingPongManagerStarted()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;

            Events.Log.PingPongManagerStarted(guid, keepAliveIntervalSeconds);
        }

        /// <summary>
        ///     Tests that test ping pong manager ended
        /// </summary>
        [Fact]
        public void Test_PingPongManagerEnded()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.PingPongManagerEnded(guid);
        }

        /// <summary>
        ///     Tests that test keep alive interval expired
        /// </summary>
        [Fact]
        public void Test_KeepAliveIntervalExpired()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;

            Events.Log.KeepAliveIntervalExpired(guid, keepAliveIntervalSeconds);
        }

        /// <summary>
        ///     Tests that test close output auto timeout
        /// </summary>
        [Fact]
        public void Test_CloseOutputAutoTimeout()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.EndpointUnavailable;
            string statusDescription = "Test description";
            string exception = "Test exception";

            Events.Log.CloseOutputAutoTimeout(guid, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that test close output auto timeout cancelled
        /// </summary>
        [Fact]
        public void Test_CloseOutputAutoTimeoutCancelled()
        {
            Guid guid = Guid.NewGuid();
            int timeoutSeconds = 10;
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.EndpointUnavailable;
            string statusDescription = "Test description";
            string exception = "Test exception";

            Events.Log.CloseOutputAutoTimeoutCancelled(guid, timeoutSeconds, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that test close output auto timeout error
        /// </summary>
        [Fact]
        public void Test_CloseOutputAutoTimeoutError()
        {
            Guid guid = Guid.NewGuid();
            string closeException = "Test close exception";
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.EndpointUnavailable;
            string statusDescription = "Test description";
            string exception = "Test exception";

            Events.Log.CloseOutputAutoTimeoutError(guid, closeException, closeStatus, statusDescription, exception);
        }

        /// <summary>
        ///     Tests that test try get buffer not supported
        /// </summary>
        [Fact]
        public void Test_TryGetBufferNotSupported()
        {
            Guid guid = Guid.NewGuid();
            string streamType = "TestStreamType";

            Events.Log.TryGetBufferNotSupported(guid, streamType);
        }

        /// <summary>
        ///     Tests that test sending frame
        /// </summary>
        [Fact]
        public void Test_SendingFrame()
        {
            Guid guid = Guid.NewGuid();
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            bool isFinBitSet = true;
            int numBytes = 1024;
            bool isPayloadCompressed = true;

            Events.Log.SendingFrame(guid, webSocketOpCode, isFinBitSet, numBytes, isPayloadCompressed);
        }

        /// <summary>
        ///     Tests that test received frame
        /// </summary>
        [Fact]
        public void Test_ReceivedFrame()
        {
            Guid guid = Guid.NewGuid();
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            bool isFinBitSet = true;
            int numBytes = 1024;

            Events.Log.ReceivedFrame(guid, webSocketOpCode, isFinBitSet, numBytes);
        }

        /// <summary>
        ///     Tests that test close output no handshake
        /// </summary>
        [Fact]
        public void Test_CloseOutputNoHandshake()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";

            Events.Log.CloseOutputNoHandshake(guid, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that test close handshake started
        /// </summary>
        [Fact]
        public void Test_CloseHandshakeStarted()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";

            Events.Log.CloseHandshakeStarted(guid, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that test close handshake respond
        /// </summary>
        [Fact]
        public void Test_CloseHandshakeRespond()
        {
            Guid guid = Guid.NewGuid();
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";

            Events.Log.CloseHandshakeRespond(guid, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that test close handshake complete
        /// </summary>
        [Fact]
        public void Test_CloseHandshakeComplete()
        {
            Guid guid = Guid.NewGuid();

            Events.Log.CloseHandshakeComplete(guid);
        }

        /// <summary>
        ///     Tests that test close frame received in unexpected state
        /// </summary>
        [Fact]
        public void Test_CloseFrameReceivedInUnexpectedState()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            WebSocketCloseStatus? closeStatus = WebSocketCloseStatus.NormalClosure;
            string statusDescription = "Test close";

            Events.Log.CloseFrameReceivedInUnexpectedState(guid, webSocketState, closeStatus, statusDescription);
        }

        /// <summary>
        ///     Tests that test web socket dispose
        /// </summary>
        [Fact]
        public void Test_WebSocketDispose()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;

            Events.Log.WebSocketDispose(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that test web socket dispose close timeout
        /// </summary>
        [Fact]
        public void Test_WebSocketDisposeCloseTimeout()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;

            Events.Log.WebSocketDisposeCloseTimeout(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that test web socket dispose error
        /// </summary>
        [Fact]
        public void Test_WebSocketDisposeError()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            string exception = "Test exception";

            Events.Log.WebSocketDisposeError(guid, webSocketState, exception);
        }

        /// <summary>
        ///     Tests that test invalid state before close
        /// </summary>
        [Fact]
        public void Test_InvalidStateBeforeClose()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;

            Events.Log.InvalidStateBeforeClose(guid, webSocketState);
        }

        /// <summary>
        ///     Tests that test invalid state before close output
        /// </summary>
        [Fact]
        public void Test_InvalidStateBeforeCloseOutput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;

            Events.Log.InvalidStateBeforeCloseOutput(guid, webSocketState);
        }
        /// <summary>
        /// The test event listener class
        /// </summary>
        /// <seealso cref="EventListener"/>
        internal sealed class TestEventListener : EventListener
        {
            /// <summary>
            /// Ons the event source created using the specified event source
            /// </summary>
            /// <param name="eventSource">The event source</param>
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource.Name == "Ninja-WebSockets")
                {
                    EnableEvents(eventSource, EventLevel.Verbose);
                }
            }
        }

        /// <summary>
        /// Tests that client connecting to ip address event enabled writes event
        /// </summary>
        [Fact]
        public void ClientConnectingToIpAddress_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ClientConnectingToIpAddress(Guid.NewGuid(), "127.0.0.1", 8080);
        }

        /// <summary>
        /// Tests that client connecting to host event enabled writes event
        /// </summary>
        [Fact]
        public void ClientConnectingToHost_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ClientConnectingToHost(Guid.NewGuid(), "localhost", 8080);
        }

        /// <summary>
        /// Tests that attemting to secure ssl connection event enabled writes event
        /// </summary>
        [Fact]
        public void AttemtingToSecureSslConnection_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.AttemtingToSecureSslConnection(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that connection secured event enabled writes event
        /// </summary>
        [Fact]
        public void ConnectionSecured_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ConnectionSecured(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that connection not secure event enabled writes event
        /// </summary>
        [Fact]
        public void ConnectionNotSecure_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ConnectionNotSecure(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that ssl certificate error event enabled writes event
        /// </summary>
        [Fact]
        public void SslCertificateError_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.SslCertificateError(SslPolicyErrors.RemoteCertificateChainErrors);
        }

        /// <summary>
        /// Tests that handshake sent event enabled writes event
        /// </summary>
        [Fact]
        public void HandshakeSent_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.HandshakeSent(Guid.NewGuid(), "header");
        }

        /// <summary>
        /// Tests that reading http response event enabled writes event
        /// </summary>
        [Fact]
        public void ReadingHttpResponse_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ReadingHttpResponse(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that read http response error event enabled writes event
        /// </summary>
        [Fact]
        public void ReadHttpResponseError_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ReadHttpResponseError(Guid.NewGuid(), "error");
        }

        /// <summary>
        /// Tests that invalid http response code event enabled writes event
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCode_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.InvalidHttpResponseCode(Guid.NewGuid(), "response");
        }

        /// <summary>
        /// Tests that handshake failure event enabled writes event
        /// </summary>
        [Fact]
        public void HandshakeFailure_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.HandshakeFailure(Guid.NewGuid(), "message");
        }

        /// <summary>
        /// Tests that client handshake success event enabled writes event
        /// </summary>
        [Fact]
        public void ClientHandshakeSuccess_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ClientHandshakeSuccess(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that server handshake success event enabled writes event
        /// </summary>
        [Fact]
        public void ServerHandshakeSuccess_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ServerHandshakeSuccess(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that accept web socket started event enabled writes event
        /// </summary>
        [Fact]
        public void AcceptWebSocketStarted_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.AcceptWebSocketStarted(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that sending handshake response event enabled writes event
        /// </summary>
        [Fact]
        public void SendingHandshakeResponse_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.SendingHandshakeResponse(Guid.NewGuid(), "response");
        }

        /// <summary>
        /// Tests that web socket version not supported event enabled writes event
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupported_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.WebSocketVersionNotSupported(Guid.NewGuid(), "exception");
        }

        /// <summary>
        /// Tests that bad request event enabled writes event
        /// </summary>
        [Fact]
        public void BadRequest_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.BadRequest(Guid.NewGuid(), "exception");
        }

        /// <summary>
        /// Tests that use per message deflate event enabled writes event
        /// </summary>
        [Fact]
        public void UsePerMessageDeflate_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.UsePerMessageDeflate(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that no message compression event enabled writes event
        /// </summary>
        [Fact]
        public void NoMessageCompression_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.NoMessageCompression(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that keep alive interval zero event enabled writes event
        /// </summary>
        [Fact]
        public void KeepAliveIntervalZero_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.KeepAliveIntervalZero(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that ping pong manager started event enabled writes event
        /// </summary>
        [Fact]
        public void PingPongManagerStarted_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.PingPongManagerStarted(Guid.NewGuid(), 30);
        }

        /// <summary>
        /// Tests that ping pong manager ended event enabled writes event
        /// </summary>
        [Fact]
        public void PingPongManagerEnded_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.PingPongManagerEnded(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that keep alive interval expired event enabled writes event
        /// </summary>
        [Fact]
        public void KeepAliveIntervalExpired_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.KeepAliveIntervalExpired(Guid.NewGuid(), 30);
        }

        /// <summary>
        /// Tests that close output auto timeout event enabled writes event
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeout_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputAutoTimeout(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, "desc", "ex");
        }

        /// <summary>
        /// Tests that close output auto timeout cancelled event enabled writes event
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutCancelled_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputAutoTimeoutCancelled(Guid.NewGuid(), 30, WebSocketCloseStatus.NormalClosure, "desc", "ex");
        }

        /// <summary>
        /// Tests that close output auto timeout error event enabled writes event
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutError_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputAutoTimeoutError(Guid.NewGuid(), "closeEx", WebSocketCloseStatus.NormalClosure, "desc", "ex");
        }

        /// <summary>
        /// Tests that try get buffer not supported event enabled writes event
        /// </summary>
        [Fact]
        public void TryGetBufferNotSupported_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.TryGetBufferNotSupported(Guid.NewGuid(), "MemoryStream");
        }

        /// <summary>
        /// Tests that sending frame event enabled writes event
        /// </summary>
        [Fact]
        public void SendingFrame_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.SendingFrame(Guid.NewGuid(), WebSocketOpCode.TextFrame, true, 1024, true);
        }

        /// <summary>
        /// Tests that received frame event enabled writes event
        /// </summary>
        [Fact]
        public void ReceivedFrame_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ReceivedFrame(Guid.NewGuid(), WebSocketOpCode.TextFrame, true, 1024);
        }

        /// <summary>
        /// Tests that close output no handshake event enabled writes event
        /// </summary>
        [Fact]
        public void CloseOutputNoHandshake_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputNoHandshake(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, "desc");
        }

        /// <summary>
        /// Tests that close handshake started event enabled writes event
        /// </summary>
        [Fact]
        public void CloseHandshakeStarted_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseHandshakeStarted(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, "desc");
        }

        /// <summary>
        /// Tests that close handshake respond event enabled writes event
        /// </summary>
        [Fact]
        public void CloseHandshakeRespond_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseHandshakeRespond(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, "desc");
        }

        /// <summary>
        /// Tests that close handshake complete event enabled writes event
        /// </summary>
        [Fact]
        public void CloseHandshakeComplete_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseHandshakeComplete(Guid.NewGuid());
        }

        /// <summary>
        /// Tests that close frame received in unexpected state event enabled writes event
        /// </summary>
        [Fact]
        public void CloseFrameReceivedInUnexpectedState_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseFrameReceivedInUnexpectedState(Guid.NewGuid(), WebSocketState.Open, WebSocketCloseStatus.NormalClosure, "desc");
        }

        /// <summary>
        /// Tests that web socket dispose event enabled writes event
        /// </summary>
        [Fact]
        public void WebSocketDispose_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.WebSocketDispose(Guid.NewGuid(), WebSocketState.Open);
        }

        /// <summary>
        /// Tests that web socket dispose close timeout event enabled writes event
        /// </summary>
        [Fact]
        public void WebSocketDisposeCloseTimeout_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.WebSocketDisposeCloseTimeout(Guid.NewGuid(), WebSocketState.Open);
        }

        /// <summary>
        /// Tests that web socket dispose error event enabled writes event
        /// </summary>
        [Fact]
        public void WebSocketDisposeError_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.WebSocketDisposeError(Guid.NewGuid(), WebSocketState.Open, "error");
        }

        /// <summary>
        /// Tests that invalid state before close event enabled writes event
        /// </summary>
        [Fact]
        public void InvalidStateBeforeClose_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.InvalidStateBeforeClose(Guid.NewGuid(), WebSocketState.Open);
        }

        /// <summary>
        /// Tests that invalid state before close output event enabled writes event
        /// </summary>
        [Fact]
        public void InvalidStateBeforeCloseOutput_EventEnabled_WritesEvent()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.InvalidStateBeforeCloseOutput(Guid.NewGuid(), WebSocketState.Open);
        }

        /// <summary>
        /// Tests that handshake sent null http header uses empty string
        /// </summary>
        [Fact]
        public void HandshakeSent_NullHttpHeader_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.HandshakeSent(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that read http response error null exception uses empty string
        /// </summary>
        [Fact]
        public void ReadHttpResponseError_NullException_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.ReadHttpResponseError(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that invalid http response code null response uses empty string
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCode_NullResponse_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.InvalidHttpResponseCode(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that handshake failure null message uses empty string
        /// </summary>
        [Fact]
        public void HandshakeFailure_NullMessage_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.HandshakeFailure(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that sending handshake response null response uses empty string
        /// </summary>
        [Fact]
        public void SendingHandshakeResponse_NullResponse_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.SendingHandshakeResponse(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that web socket version not supported null exception uses empty string
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupported_NullException_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.WebSocketVersionNotSupported(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that bad request null exception uses empty string
        /// </summary>
        [Fact]
        public void BadRequest_NullException_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.BadRequest(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that try get buffer not supported null stream type uses empty string
        /// </summary>
        [Fact]
        public void TryGetBufferNotSupported_NullStreamType_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.TryGetBufferNotSupported(Guid.NewGuid(), null);
        }

        /// <summary>
        /// Tests that close output auto timeout null descriptions uses empty string
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeout_NullDescriptions_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputAutoTimeout(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, null, null);
        }

        /// <summary>
        /// Tests that close output auto timeout cancelled null descriptions uses empty string
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutCancelled_NullDescriptions_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputAutoTimeoutCancelled(Guid.NewGuid(), 30, WebSocketCloseStatus.NormalClosure, null, null);
        }

        /// <summary>
        /// Tests that close output auto timeout error null descriptions uses empty string
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutError_NullDescriptions_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputAutoTimeoutError(Guid.NewGuid(), null, WebSocketCloseStatus.NormalClosure, null, null);
        }

        /// <summary>
        /// Tests that close output no handshake null status description uses empty string
        /// </summary>
        [Fact]
        public void CloseOutputNoHandshake_NullStatusDescription_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseOutputNoHandshake(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, null);
        }

        /// <summary>
        /// Tests that close handshake started null status description uses empty string
        /// </summary>
        [Fact]
        public void CloseHandshakeStarted_NullStatusDescription_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseHandshakeStarted(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, null);
        }

        /// <summary>
        /// Tests that close handshake respond null status description uses empty string
        /// </summary>
        [Fact]
        public void CloseHandshakeRespond_NullStatusDescription_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseHandshakeRespond(Guid.NewGuid(), WebSocketCloseStatus.NormalClosure, null);
        }

        /// <summary>
        /// Tests that close frame received in unexpected state null status description uses empty string
        /// </summary>
        [Fact]
        public void CloseFrameReceivedInUnexpectedState_NullStatusDescription_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.CloseFrameReceivedInUnexpectedState(Guid.NewGuid(), WebSocketState.Open, WebSocketCloseStatus.NormalClosure, null);
        }

        /// <summary>
        /// Tests that web socket dispose error null exception uses empty string
        /// </summary>
        [Fact]
        public void WebSocketDisposeError_NullException_UsesEmptyString()
        {
            using TestEventListener listener = new TestEventListener();
            Events.Log.WebSocketDisposeError(Guid.NewGuid(), WebSocketState.Open, null);
        }
    }
}