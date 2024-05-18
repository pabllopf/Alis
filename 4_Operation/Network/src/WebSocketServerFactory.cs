// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketServerFactory.cs
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;
using Alis.Core.Network.Internal;

namespace Alis.Core.Network
{
    /// <summary>
    ///     Web socket server factory used to open web socket server connections
    /// </summary>
    public class WebSocketServerFactory : IWebSocketServerFactory
    {
        /// <summary>
        ///     The buffer factory
        /// </summary>
        internal readonly Func<MemoryStream> _bufferFactory;
        
        /// <summary>
        ///     The buffer pool
        /// </summary>
        internal readonly IBufferPool _bufferPool;
        
        /// <summary>
        ///     Initialises a new instance of the WebSocketServerFactory class without caring about internal buffers
        /// </summary>
        public WebSocketServerFactory()
        {
            _bufferPool = new BufferPool();
            _bufferFactory = _bufferPool.GetBuffer;
        }
        
        /// <summary>
        ///     Reads a http header information from a stream and decodes the parts relating to the WebSocket protocot upgrade
        /// </summary>
        /// <param name="stream">The network stream</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>Http data read from the stream</returns>
        public async Task<WebSocketHttpContext> ReadHttpHeaderFromStreamAsync(Stream stream,
            CancellationToken token = default(CancellationToken))
        {
            string header = await HttpHelper.ReadHttpHeaderAsync(stream, token);
            string path = HttpHelper.GetPathFromHeader(header);
            bool isWebSocketRequest = HttpHelper.IsWebSocketUpgradeRequest(header);
            IList<string> subProtocols = HttpHelper.GetSubProtocols(header);
            return new WebSocketHttpContext(isWebSocketRequest, subProtocols, header, path, stream);
        }
        
        /// <summary>
        ///     Accept web socket with default options
        ///     Call ReadHttpHeaderFromStreamAsync first to get WebSocketHttpContext
        /// </summary>
        /// <param name="context">The http context used to initiate this web socket request</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket</returns>
        public async Task<WebSocket> AcceptWebSocketAsync(WebSocketHttpContext context,
            CancellationToken token = default(CancellationToken))
            => await AcceptWebSocketAsync(context, new WebSocketServerOptions(), token);
        
        /// <summary>
        ///     Accept web socket with options specified
        ///     Call ReadHttpHeaderFromStreamAsync first to get WebSocketHttpContext
        /// </summary>
        /// <param name="context">The http context used to initiate this web socket request</param>
        /// <param name="options">The web socket options</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket</returns>
        [ExcludeFromCodeCoverage]
        public async Task<WebSocket> AcceptWebSocketAsync(WebSocketHttpContext context, WebSocketServerOptions options,
            CancellationToken token = default(CancellationToken))
        {
            Guid guid = Guid.NewGuid();
            Events.Log.AcceptWebSocketStarted(guid);
            await PerformHandshakeAsync(guid, context.HttpHeader, options.SubProtocol, context.Stream, token);
            Events.Log.ServerHandshakeSuccess(guid);
            return new WebSocketImplementation(guid, _bufferFactory, context.Stream, options.KeepAliveInterval,
                null, options.IncludeExceptionInCloseResponse, false, options.SubProtocol);
        }
        
        /// <summary>
        ///     Checks the web socket version using the specified http header
        /// </summary>
        /// <param name="httpHeader">The http header</param>
        /// <exception cref="WebSocketVersionNotSupportedException"></exception>
        /// <exception cref="WebSocketVersionNotSupportedException">Cannot find "Sec-WebSocket-Version" in http header</exception>
        internal static void CheckWebSocketVersion(string httpHeader)
        {
            var webSocketVersion = ExtractWebSocketVersion(httpHeader);
            ValidateWebSocketVersion(webSocketVersion);
        }
        
        /// <summary>
        /// Extracts the web socket version using the specified http header
        /// </summary>
        /// <param name="httpHeader">The http header</param>
        /// <exception cref="WebSocketVersionNotSupportedException">Cannot find "Sec-WebSocket-Version" in http header</exception>
        /// <returns>The int</returns>
        internal static int ExtractWebSocketVersion(string httpHeader)
        {
            Regex webSocketVersionRegex = new Regex("Sec-WebSocket-Version: (.*)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            Match match = webSocketVersionRegex.Match(httpHeader);
            
            if (!match.Success)
            {
                throw new WebSocketVersionNotSupportedException("Cannot find \"Sec-WebSocket-Version\" in http header");
            }
            
            return Convert.ToInt32(match.Groups[1].Value.Trim());
        }
        
        /// <summary>
        /// Validates the web socket version using the specified sec web socket version
        /// </summary>
        /// <param name="secWebSocketVersion">The sec web socket version</param>
        /// <exception cref="WebSocketVersionNotSupportedException"></exception>
        internal static void ValidateWebSocketVersion(int secWebSocketVersion)
        {
            const int webSocketVersion = 13;
            
            if (secWebSocketVersion < webSocketVersion)
            {
                throw new WebSocketVersionNotSupportedException(string.Format(
                    "WebSocket Version {0} not suported. Must be {1} or above", secWebSocketVersion,
                    webSocketVersion));
            }
        }
        
        /// <summary>
        ///     Performs the handshake using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="httpHeader">The http header</param>
        /// <param name="subProtocol">The sub protocol</param>
        /// <param name="stream">The stream</param>
        /// <param name="token">The token</param>
        /// <exception cref="SecWebSocketKeyMissingException">Unable to read "Sec-WebSocket-Key" from http header</exception>
        [ExcludeFromCodeCoverage]
        internal static async Task PerformHandshakeAsync(Guid guid, string httpHeader, string subProtocol, Stream stream,
            CancellationToken token)
        {
            try
            {
                await PerformHandshakeWithValidations(guid, httpHeader, subProtocol, stream, token);
            }
            catch (WebSocketVersionNotSupportedException ex)
            {
                await HandleWebSocketVersionNotSupported(guid, ex, stream, token);
                throw;
            }
            catch (Exception ex)
            {
                await HandleBadRequest(guid, ex, stream, token);
                throw;
            }
        }
        
        /// <summary>
        /// Performs the handshake with validations using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="httpHeader">The http header</param>
        /// <param name="subProtocol">The sub protocol</param>
        /// <param name="stream">The stream</param>
        /// <param name="token">The token</param>
        internal static async Task PerformHandshakeWithValidations(Guid guid, string httpHeader, string subProtocol, Stream stream,
            CancellationToken token)
        {
            string secWebSocketKey = ExtractWebSocketKey(httpHeader);
            CheckWebSocketVersion(httpHeader);
            string response = BuildHandshakeResponse(secWebSocketKey, subProtocol);
            await SendHandshakeResponse(guid, response, stream, token);
        }
        
        /// <summary>
        /// Extracts the web socket key using the specified http header
        /// </summary>
        /// <param name="httpHeader">The http header</param>
        /// <exception cref="SecWebSocketKeyMissingException">Unable to read "Sec-WebSocket-Key" from http header</exception>
        /// <returns>The string</returns>
        internal static string ExtractWebSocketKey(string httpHeader)
        {
            Regex webSocketKeyRegex = new Regex("Sec-WebSocket-Key: (.*)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            Match match = webSocketKeyRegex.Match(httpHeader);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }
            else
            {
                throw new SecWebSocketKeyMissingException("Unable to read \"Sec-WebSocket-Key\" from http header");
            }
        }
        
        /// <summary>
        /// Builds the handshake response using the specified sec web socket key
        /// </summary>
        /// <param name="secWebSocketKey">The sec web socket key</param>
        /// <param name="subProtocol">The sub protocol</param>
        /// <returns>The string</returns>
        internal static string BuildHandshakeResponse(string secWebSocketKey, string subProtocol)
        {
            string setWebSocketAccept = HttpHelper.ComputeSocketAcceptString(secWebSocketKey);
            return "HTTP/1.1 101 Switching Protocols\r\n"
                   + "Connection: Upgrade\r\n"
                   + "Upgrade: websocket\r\n"
                   + (subProtocol != null ? $"Sec-WebSocket-Protocol: {subProtocol}\r\n" : "")
                   + $"Sec-WebSocket-Accept: {setWebSocketAccept}";
        }
        
        /// <summary>
        /// Sends the handshake response using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="response">The response</param>
        /// <param name="stream">The stream</param>
        /// <param name="token">The token</param>
        internal static async Task SendHandshakeResponse(Guid guid, string response, Stream stream, CancellationToken token)
        {
            Events.Log.SendingHandshakeResponse(guid, response);
            await HttpHelper.WriteHttpHeaderAsync(response, stream, token);
        }
        
        /// <summary>
        /// Handles the web socket version not supported using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="ex">The ex</param>
        /// <param name="stream">The stream</param>
        /// <param name="token">The token</param>
        internal static async Task HandleWebSocketVersionNotSupported(Guid guid, WebSocketVersionNotSupportedException ex, Stream stream, CancellationToken token)
        {
            Events.Log.WebSocketVersionNotSupported(guid, ex.ToString());
            string response = "HTTP/1.1 426 Upgrade Required\r\nSec-WebSocket-Version: 13" + ex.Message;
            await HttpHelper.WriteHttpHeaderAsync(response, stream, token);
        }
        
        /// <summary>
        /// Handles the bad request using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="ex">The ex</param>
        /// <param name="stream">The stream</param>
        /// <param name="token">The token</param>
        internal static async Task HandleBadRequest(Guid guid, Exception ex, Stream stream, CancellationToken token)
        {
            Events.Log.BadRequest(guid, ex.ToString());
            await HttpHelper.WriteHttpHeaderAsync("HTTP/1.1 400 Bad Request", stream, token);
        }
    }
}