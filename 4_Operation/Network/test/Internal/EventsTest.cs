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
using System.Net.Security;
using System.Net.WebSockets;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The events test class
    /// </summary>
    public class EventsTest
    {
        /// <summary>
        /// Tests that client connecting to ip address valid input
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
        /// Tests that client connecting to host valid input
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
        /// Tests that attemting to secure ssl connection valid input
        /// </summary>
        [Fact]
        public void AttemtingToSecureSslConnection_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.AttemtingToSecureSslConnection(guid);
            
        }
        
        /// <summary>
        /// Tests that connection secured valid input
        /// </summary>
        [Fact]
        public void ConnectionSecured_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionSecured(guid);
            
        }
        
        /// <summary>
        /// Tests that connection not secure valid input
        /// </summary>
        [Fact]
        public void ConnectionNotSecure_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionNotSecure(guid);
            
        }
        
        /// <summary>
        /// Tests that close handshake complete valid input
        /// </summary>
        [Fact]
        public void CloseHandshakeComplete_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.CloseHandshakeComplete(guid);
            
            
        }
        
        /// <summary>
        /// Tests that close frame received in unexpected state valid input
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
        /// Tests that web socket dispose valid input
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
        /// Tests that web socket dispose close timeout valid input
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
        /// Tests that web socket dispose error valid input
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
        /// Tests that invalid state before close valid input
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
        /// Tests that invalid state before close output valid input
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
        /// Tests that try get buffer not supported valid input
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
        /// Tests that sending frame valid input
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
        /// Tests that received frame valid input
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
        /// Tests that close output no handshake valid input
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
        /// Tests that close handshake started valid input
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
        /// Tests that close handshake respond valid input
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
        /// Tests that keep alive interval zero valid input
        /// </summary>
        [Fact]
        public void KeepAliveIntervalZero_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.KeepAliveIntervalZero(guid);
            
            
        }
        
        /// <summary>
        /// Tests that ping pong manager started valid input
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
        /// Tests that ping pong manager ended valid input
        /// </summary>
        [Fact]
        public void PingPongManagerEnded_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.PingPongManagerEnded(guid);
            
            
        }
        
        /// <summary>
        /// Tests that keep alive interval expired valid input
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
        /// Tests that close output auto timeout valid input
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
        /// Tests that close output auto timeout cancelled valid input
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
        /// Tests that close output auto timeout error valid input
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
        /// Tests that server handshake success valid input
        /// </summary>
        [Fact]
        public void ServerHandshakeSuccess_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.ServerHandshakeSuccess(guid);
            
            
        }
        
        /// <summary>
        /// Tests that accept web socket started valid input
        /// </summary>
        [Fact]
        public void AcceptWebSocketStarted_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.AcceptWebSocketStarted(guid);
            
            
        }
        
        /// <summary>
        /// Tests that sending handshake response valid input
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
        /// Tests that web socket version not supported valid input
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
        /// Tests that bad request valid input
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
        /// Tests that use per message deflate valid input
        /// </summary>
        [Fact]
        public void UsePerMessageDeflate_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.UsePerMessageDeflate(guid);
            
            
        }
        
        /// <summary>
        /// Tests that no message compression valid input
        /// </summary>
        [Fact]
        public void NoMessageCompression_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.NoMessageCompression(guid);
            
            
        }
        
        /// <summary>
        /// Tests that ssl certificate error valid input
        /// </summary>
        [Fact]
        public void SslCertificateError_ValidInput()
        {
            SslPolicyErrors sslPolicyErrors = SslPolicyErrors.RemoteCertificateChainErrors;
            Events events = Events.Log;
            
            events.SslCertificateError(sslPolicyErrors);
            
            
        }
        
        /// <summary>
        /// Tests that handshake sent valid input
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
        /// Tests that reading http response valid input
        /// </summary>
        [Fact]
        public void ReadingHttpResponse_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.ReadingHttpResponse(guid);
            
            
        }
        
        /// <summary>
        /// Tests that read http response error valid input
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
        /// Tests that invalid http response code valid input
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
        /// Tests that handshake failure valid input
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
        /// Tests that client handshake success valid input
        /// </summary>
        [Fact]
        public void ClientHandshakeSuccess_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Events events = Events.Log;
            
            events.ClientHandshakeSuccess(guid);
            
            
        }
        
        /// <summary>
        /// Tests that client connecting to ip address test
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
        /// Tests that web socket dispose error test
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
        /// Tests that invalid state before close test
        /// </summary>
        [Fact]
        public void InvalidStateBeforeClose_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            
            Events.Log.InvalidStateBeforeClose(guid, webSocketState);
        }
        
        /// <summary>
        /// Tests that invalid state before close output test
        /// </summary>
        [Fact]
        public void InvalidStateBeforeCloseOutput_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            
            Events.Log.InvalidStateBeforeCloseOutput(guid, webSocketState);
        }
        
        /// <summary>
        /// Tests that ping pong manager started test
        /// </summary>
        [Fact]
        public void PingPongManagerStarted_Test()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;
            
            Events.Log.PingPongManagerStarted(guid, keepAliveIntervalSeconds);
        }
        
        /// <summary>
        /// Tests that ping pong manager ended test
        /// </summary>
        [Fact]
        public void PingPongManagerEnded_Test()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.PingPongManagerEnded(guid);
        }
        
        /// <summary>
        /// Tests that keep alive interval expired test
        /// </summary>
        [Fact]
        public void KeepAliveIntervalExpired_Test()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;
            
            Events.Log.KeepAliveIntervalExpired(guid, keepAliveIntervalSeconds);
        }
        
        /// <summary>
        /// Tests that close output auto timeout test
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
        /// Tests that close output auto timeout cancelled test
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
        /// Tests that close output auto timeout error test
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
        /// Tests that test client connecting to ip address
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
        /// Tests that test client connecting to host
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
        /// Tests that test attemting to secure ssl connection
        /// </summary>
        [Fact]
        public void Test_AttemtingToSecureSslConnection()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.AttemtingToSecureSslConnection(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test connection secured
        /// </summary>
        [Fact]
        public void Test_ConnectionSecured()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionSecured(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test connection not secure
        /// </summary>
        [Fact]
        public void Test_ConnectionNotSecure()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionNotSecure(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test ssl certificate error
        /// </summary>
        [Fact]
        public void Test_SslCertificateError()
        {
            SslPolicyErrors sslPolicyErrors = SslPolicyErrors.RemoteCertificateChainErrors;
            
            Events.Log.SslCertificateError(sslPolicyErrors);
            
            
        }
        
        /// <summary>
        /// Tests that test handshake sent
        /// </summary>
        [Fact]
        public void Test_HandshakeSent()
        {
            Guid guid = Guid.NewGuid();
            string httpHeader = "Test header";
            
            Events.Log.HandshakeSent(guid, httpHeader);
            
            
        }
        
        /// <summary>
        /// Tests that test reading http response
        /// </summary>
        [Fact]
        public void Test_ReadingHttpResponse()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ReadingHttpResponse(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test read http response error
        /// </summary>
        [Fact]
        public void Test_ReadHttpResponseError()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";
            
            Events.Log.ReadHttpResponseError(guid, exception);
            
            
        }
        
        /// <summary>
        /// Tests that test invalid http response code
        /// </summary>
        [Fact]
        public void Test_InvalidHttpResponseCode()
        {
            Guid guid = Guid.NewGuid();
            string response = "Test response";
            
            Events.Log.InvalidHttpResponseCode(guid, response);
            
            
        }
        
        /// <summary>
        /// Tests that test handshake failure
        /// </summary>
        [Fact]
        public void Test_HandshakeFailure()
        {
            Guid guid = Guid.NewGuid();
            string message = "Test message";
            
            Events.Log.HandshakeFailure(guid, message);
            
            
        }
        
        /// <summary>
        /// Tests that test client handshake success
        /// </summary>
        [Fact]
        public void Test_ClientHandshakeSuccess()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ClientHandshakeSuccess(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test server handshake success
        /// </summary>
        [Fact]
        public void Test_ServerHandshakeSuccess()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ServerHandshakeSuccess(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test accept web socket started
        /// </summary>
        [Fact]
        public void Test_AcceptWebSocketStarted()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.AcceptWebSocketStarted(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test sending handshake response
        /// </summary>
        [Fact]
        public void Test_SendingHandshakeResponse()
        {
            Guid guid = Guid.NewGuid();
            string response = "Test response";
            
            Events.Log.SendingHandshakeResponse(guid, response);
            
            
        }
        
        /// <summary>
        /// Tests that test web socket version not supported
        /// </summary>
        [Fact]
        public void Test_WebSocketVersionNotSupported()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";
            
            Events.Log.WebSocketVersionNotSupported(guid, exception);
            
            
        }
        
        /// <summary>
        /// Tests that test bad request
        /// </summary>
        [Fact]
        public void Test_BadRequest()
        {
            Guid guid = Guid.NewGuid();
            string exception = "Test exception";
            
            Events.Log.BadRequest(guid, exception);
            
            
        }
        
        /// <summary>
        /// Tests that test use per message deflate
        /// </summary>
        [Fact]
        public void Test_UsePerMessageDeflate()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.UsePerMessageDeflate(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test no message compression
        /// </summary>
        [Fact]
        public void Test_NoMessageCompression()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.NoMessageCompression(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test keep alive interval zero
        /// </summary>
        [Fact]
        public void Test_KeepAliveIntervalZero()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.KeepAliveIntervalZero(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test ping pong manager started
        /// </summary>
        [Fact]
        public void Test_PingPongManagerStarted()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;
            
            Events.Log.PingPongManagerStarted(guid, keepAliveIntervalSeconds);
            
            
        }
        
        /// <summary>
        /// Tests that test ping pong manager ended
        /// </summary>
        [Fact]
        public void Test_PingPongManagerEnded()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.PingPongManagerEnded(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test keep alive interval expired
        /// </summary>
        [Fact]
        public void Test_KeepAliveIntervalExpired()
        {
            Guid guid = Guid.NewGuid();
            int keepAliveIntervalSeconds = 10;
            
            Events.Log.KeepAliveIntervalExpired(guid, keepAliveIntervalSeconds);
            
            
        }
        
        /// <summary>
        /// Tests that test close output auto timeout
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
        /// Tests that test close output auto timeout cancelled
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
        /// Tests that test close output auto timeout error
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
        /// Tests that test try get buffer not supported
        /// </summary>
        [Fact]
        public void Test_TryGetBufferNotSupported()
        {
            Guid guid = Guid.NewGuid();
            string streamType = "TestStreamType";
            
            Events.Log.TryGetBufferNotSupported(guid, streamType);
            
            
        }
        
        /// <summary>
        /// Tests that test sending frame
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
        /// Tests that test received frame
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
        /// Tests that test close output no handshake
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
        /// Tests that test close handshake started
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
        /// Tests that test close handshake respond
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
        /// Tests that test close handshake complete
        /// </summary>
        [Fact]
        public void Test_CloseHandshakeComplete()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.CloseHandshakeComplete(guid);
            
            
        }
        
        /// <summary>
        /// Tests that test close frame received in unexpected state
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
        /// Tests that test web socket dispose
        /// </summary>
        [Fact]
        public void Test_WebSocketDispose()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            
            Events.Log.WebSocketDispose(guid, webSocketState);
            
            
        }
        
        /// <summary>
        /// Tests that test web socket dispose close timeout
        /// </summary>
        [Fact]
        public void Test_WebSocketDisposeCloseTimeout()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            
            Events.Log.WebSocketDisposeCloseTimeout(guid, webSocketState);
            
            
        }
        
        /// <summary>
        /// Tests that test web socket dispose error
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
        /// Tests that test invalid state before close
        /// </summary>
        [Fact]
        public void Test_InvalidStateBeforeClose()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            
            Events.Log.InvalidStateBeforeClose(guid, webSocketState);
            
            
        }
        
        /// <summary>
        /// Tests that test invalid state before close output
        /// </summary>
        [Fact]
        public void Test_InvalidStateBeforeCloseOutput()
        {
            Guid guid = Guid.NewGuid();
            WebSocketState webSocketState = WebSocketState.Open;
            
            Events.Log.InvalidStateBeforeCloseOutput(guid, webSocketState);
            
            
        }
    }
}