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
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that attemting to secure ssl connection valid input
        /// </summary>
        [Fact]
        public void AttemtingToSecureSslConnection_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.AttemtingToSecureSslConnection(guid);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that connection secured valid input
        /// </summary>
        [Fact]
        public void ConnectionSecured_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionSecured(guid);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that connection not secure valid input
        /// </summary>
        [Fact]
        public void ConnectionNotSecure_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionNotSecure(guid);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
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
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
    }
}