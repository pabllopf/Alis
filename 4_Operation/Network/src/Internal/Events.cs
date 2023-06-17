// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Events.cs
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

namespace Alis.Core.Network.Internal
{
    /// <summary>
    ///     Use the Guid to locate this EventSource in PerfView using the Additional Providers box (without wildcard
    ///     characters)
    /// </summary>
    [EventSource(Name = "Ninja-WebSockets", Guid = "7DE1A071-4F85-4DBD-8FB1-EE8D3845E087")]
    internal sealed class Events : EventSource
    {
        /// <summary>
        ///     The events
        /// </summary>
        public static readonly Events Log = new Events();

        /// <summary>
        ///     Clients the connecting to ip address using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="ipAddress">The ip address</param>
        /// <param name="port">The port</param>
        [Event(1, Level = EventLevel.Informational)]
        public void ClientConnectingToIpAddress(Guid guid, string ipAddress, int port)
        {
            if (IsEnabled())
            {
                WriteEvent(1, guid, ipAddress, port);
            }
        }

        /// <summary>
        ///     Clients the connecting to host using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        [Event(2, Level = EventLevel.Informational)]
        public void ClientConnectingToHost(Guid guid, string host, int port)
        {
            if (IsEnabled())
            {
                WriteEvent(2, guid, host, port);
            }
        }

        /// <summary>
        ///     Attemtings the to secure ssl connection using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(3, Level = EventLevel.Informational)]
        public void AttemtingToSecureSslConnection(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(3, guid);
            }
        }

        /// <summary>
        ///     Connections the secured using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(4, Level = EventLevel.Informational)]
        public void ConnectionSecured(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(4, guid);
            }
        }

        /// <summary>
        ///     Connections the not secure using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(5, Level = EventLevel.Informational)]
        public void ConnectionNotSecure(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(5, guid);
            }
        }

        /// <summary>
        ///     Ssls the certificate error using the specified ssl policy errors
        /// </summary>
        /// <param name="sslPolicyErrors">The ssl policy errors</param>
        [Event(6, Level = EventLevel.Error)]
        public void SslCertificateError(SslPolicyErrors sslPolicyErrors)
        {
            if (IsEnabled())
            {
                WriteEvent(6, sslPolicyErrors);
            }
        }

        /// <summary>
        ///     Handshakes the sent using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="httpHeader">The http header</param>
        [Event(7, Level = EventLevel.Informational)]
        public void HandshakeSent(Guid guid, string httpHeader)
        {
            if (IsEnabled())
            {
                WriteEvent(7, guid, httpHeader ?? string.Empty);
            }
        }

        /// <summary>
        ///     Readings the http response using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(8, Level = EventLevel.Informational)]
        public void ReadingHttpResponse(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(8, guid);
            }
        }

        /// <summary>
        ///     Reads the http response error using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="exception">The exception</param>
        [Event(9, Level = EventLevel.Error)]
        public void ReadHttpResponseError(Guid guid, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(9, guid, exception ?? string.Empty);
            }
        }

        /// <summary>
        ///     Invalids the http response code using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="response">The response</param>
        [Event(10, Level = EventLevel.Warning)]
        public void InvalidHttpResponseCode(Guid guid, string response)
        {
            if (IsEnabled())
            {
                WriteEvent(10, guid, response ?? string.Empty);
            }
        }

        /// <summary>
        ///     Handshakes the failure using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="message">The message</param>
        [Event(11, Level = EventLevel.Error)]
        public void HandshakeFailure(Guid guid, string message)
        {
            if (IsEnabled())
            {
                WriteEvent(11, guid, message ?? string.Empty);
            }
        }

        /// <summary>
        ///     Clients the handshake success using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(12, Level = EventLevel.Informational)]
        public void ClientHandshakeSuccess(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(12, guid);
            }
        }

        /// <summary>
        ///     Servers the handshake success using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(13, Level = EventLevel.Informational)]
        public void ServerHandshakeSuccess(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(13, guid);
            }
        }

        /// <summary>
        ///     Accepts the web socket started using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(14, Level = EventLevel.Informational)]
        public void AcceptWebSocketStarted(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(14, guid);
            }
        }

        /// <summary>
        ///     Sendings the handshake response using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="response">The response</param>
        [Event(15, Level = EventLevel.Informational)]
        public void SendingHandshakeResponse(Guid guid, string response)
        {
            if (IsEnabled())
            {
                WriteEvent(15, guid, response ?? string.Empty);
            }
        }

        /// <summary>
        ///     Webs the socket version not supported using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="exception">The exception</param>
        [Event(16, Level = EventLevel.Error)]
        public void WebSocketVersionNotSupported(Guid guid, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(16, guid, exception ?? string.Empty);
            }
        }

        /// <summary>
        ///     Bads the request using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="exception">The exception</param>
        [Event(17, Level = EventLevel.Error)]
        public void BadRequest(Guid guid, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(17, guid, exception ?? string.Empty);
            }
        }

        /// <summary>
        ///     Uses the per message deflate using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(18, Level = EventLevel.Informational)]
        public void UsePerMessageDeflate(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(18, guid);
            }
        }

        /// <summary>
        ///     Noes the message compression using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(19, Level = EventLevel.Informational)]
        public void NoMessageCompression(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(19, guid);
            }
        }

        /// <summary>
        ///     Keeps the alive interval zero using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(20, Level = EventLevel.Informational)]
        public void KeepAliveIntervalZero(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(20, guid);
            }
        }

        /// <summary>
        ///     Pings the pong manager started using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="keepAliveIntervalSeconds">The keep alive interval seconds</param>
        [Event(21, Level = EventLevel.Informational)]
        public void PingPongManagerStarted(Guid guid, int keepAliveIntervalSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(21, guid, keepAliveIntervalSeconds);
            }
        }

        /// <summary>
        ///     Pings the pong manager ended using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(22, Level = EventLevel.Informational)]
        public void PingPongManagerEnded(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(22, guid);
            }
        }

        /// <summary>
        ///     Keeps the alive interval expired using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="keepAliveIntervalSeconds">The keep alive interval seconds</param>
        [Event(23, Level = EventLevel.Warning)]
        public void KeepAliveIntervalExpired(Guid guid, int keepAliveIntervalSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(23, guid, keepAliveIntervalSeconds);
            }
        }

        /// <summary>
        ///     Closes the output auto timeout using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        /// <param name="exception">The exception</param>
        [Event(24, Level = EventLevel.Warning)]
        public void CloseOutputAutoTimeout(Guid guid, WebSocketCloseStatus closeStatus, string statusDescription,
            string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(24, guid, closeStatus, statusDescription ?? string.Empty, exception ?? string.Empty);
            }
        }

        /// <summary>
        ///     Closes the output auto timeout cancelled using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="timeoutSeconds">The timeout seconds</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        /// <param name="exception">The exception</param>
        [Event(25, Level = EventLevel.Error)]
        public void CloseOutputAutoTimeoutCancelled(Guid guid, int timeoutSeconds, WebSocketCloseStatus closeStatus,
            string statusDescription, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(25, guid, timeoutSeconds, closeStatus, statusDescription ?? string.Empty,
                    exception ?? string.Empty);
            }
        }

        /// <summary>
        ///     Closes the output auto timeout error using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="closeException">The close exception</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        /// <param name="exception">The exception</param>
        [Event(26, Level = EventLevel.Error)]
        public void CloseOutputAutoTimeoutError(Guid guid, string closeException, WebSocketCloseStatus closeStatus,
            string statusDescription, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(26, guid, closeException ?? string.Empty, closeStatus, statusDescription ?? string.Empty,
                    exception ?? string.Empty);
            }
        }

        /// <summary>
        ///     Tries the get buffer not supported using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="streamType">The stream type</param>
        [Event(27, Level = EventLevel.Warning)]
        public void TryGetBufferNotSupported(Guid guid, string streamType)
        {
            if (IsEnabled())
            {
                WriteEvent(27, guid, streamType ?? string.Empty);
            }
        }

        /// <summary>
        ///     Sendings the frame using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketOpCode">The web socket op code</param>
        /// <param name="isFinBitSet">The is fin bit set</param>
        /// <param name="numBytes">The num bytes</param>
        /// <param name="isPayloadCompressed">The is payload compressed</param>
        [Event(28, Level = EventLevel.Verbose)]
        public void SendingFrame(Guid guid, WebSocketOpCode webSocketOpCode, bool isFinBitSet, int numBytes,
            bool isPayloadCompressed)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                WriteEvent(28, guid, webSocketOpCode, isFinBitSet, numBytes, isPayloadCompressed);
            }
        }

        /// <summary>
        ///     Receiveds the frame using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketOpCode">The web socket op code</param>
        /// <param name="isFinBitSet">The is fin bit set</param>
        /// <param name="numBytes">The num bytes</param>
        [Event(29, Level = EventLevel.Verbose)]
        public void ReceivedFrame(Guid guid, WebSocketOpCode webSocketOpCode, bool isFinBitSet, int numBytes)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                WriteEvent(29, guid, webSocketOpCode, isFinBitSet, numBytes);
            }
        }

        /// <summary>
        ///     Closes the output no handshake using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        [Event(30, Level = EventLevel.Informational)]
        public void CloseOutputNoHandshake(Guid guid, WebSocketCloseStatus? closeStatus, string statusDescription)
        {
            if (IsEnabled())
            {
                string closeStatusDesc = $"{closeStatus}";
                WriteEvent(30, guid, closeStatusDesc, statusDescription ?? string.Empty);
            }
        }

        /// <summary>
        ///     Closes the handshake started using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        [Event(31, Level = EventLevel.Informational)]
        public void CloseHandshakeStarted(Guid guid, WebSocketCloseStatus? closeStatus, string statusDescription)
        {
            if (IsEnabled())
            {
                string closeStatusDesc = $"{closeStatus}";
                WriteEvent(31, guid, closeStatusDesc, statusDescription ?? string.Empty);
            }
        }

        /// <summary>
        ///     Closes the handshake respond using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        [Event(32, Level = EventLevel.Informational)]
        public void CloseHandshakeRespond(Guid guid, WebSocketCloseStatus? closeStatus, string statusDescription)
        {
            if (IsEnabled())
            {
                string closeStatusDesc = $"{closeStatus}";
                WriteEvent(32, guid, closeStatusDesc, statusDescription ?? string.Empty);
            }
        }

        /// <summary>
        ///     Closes the handshake complete using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        [Event(33, Level = EventLevel.Informational)]
        public void CloseHandshakeComplete(Guid guid)
        {
            if (IsEnabled())
            {
                WriteEvent(33, guid);
            }
        }

        /// <summary>
        ///     Closes the frame received in unexpected state using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketState">The web socket state</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="statusDescription">The status description</param>
        [Event(34, Level = EventLevel.Warning)]
        public void CloseFrameReceivedInUnexpectedState(Guid guid, WebSocketState webSocketState,
            WebSocketCloseStatus? closeStatus, string statusDescription)
        {
            if (IsEnabled())
            {
                string closeStatusDesc = $"{closeStatus}";
                WriteEvent(34, guid, webSocketState, closeStatusDesc, statusDescription ?? string.Empty);
            }
        }

        /// <summary>
        ///     Webs the socket dispose using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketState">The web socket state</param>
        [Event(35, Level = EventLevel.Informational)]
        public void WebSocketDispose(Guid guid, WebSocketState webSocketState)
        {
            if (IsEnabled())
            {
                WriteEvent(35, guid, webSocketState);
            }
        }

        /// <summary>
        ///     Webs the socket dispose close timeout using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketState">The web socket state</param>
        [Event(36, Level = EventLevel.Warning)]
        public void WebSocketDisposeCloseTimeout(Guid guid, WebSocketState webSocketState)
        {
            if (IsEnabled())
            {
                WriteEvent(36, guid, webSocketState);
            }
        }

        /// <summary>
        ///     Webs the socket dispose error using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketState">The web socket state</param>
        /// <param name="exception">The exception</param>
        [Event(37, Level = EventLevel.Error)]
        public void WebSocketDisposeError(Guid guid, WebSocketState webSocketState, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(37, guid, webSocketState, exception ?? string.Empty);
            }
        }

        /// <summary>
        ///     Invalids the state before close using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketState">The web socket state</param>
        [Event(38, Level = EventLevel.Warning)]
        public void InvalidStateBeforeClose(Guid guid, WebSocketState webSocketState)
        {
            if (IsEnabled())
            {
                WriteEvent(38, guid, webSocketState);
            }
        }

        /// <summary>
        ///     Invalids the state before close output using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="webSocketState">The web socket state</param>
        [Event(39, Level = EventLevel.Warning)]
        public void InvalidStateBeforeCloseOutput(Guid guid, WebSocketState webSocketState)
        {
            if (IsEnabled())
            {
                WriteEvent(39, guid, webSocketState);
            }
        }
    }
}