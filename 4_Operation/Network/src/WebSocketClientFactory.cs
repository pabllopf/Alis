// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientFactory.cs
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
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;
using Alis.Core.Network.Internal;

namespace Alis.Core.Network
{
    /// <summary>
    ///     Web socket client factory used to open web socket client connections
    /// </summary>
    public class WebSocketClientFactory : IWebSocketClientFactory, IDisposable
    {
        /// <summary>
        ///     The buffer factory
        /// </summary>
        internal readonly Func<MemoryStream> BufferFactory;

        /// <summary>
        ///     The buffer pool
        /// </summary>
        internal readonly IBufferPool BufferPool;

        /// <summary>
        ///     The tcp client
        /// </summary>
        internal TcpClient TcpClient;

        /// <summary>
        ///     Initialises a new instance of the WebSocketClientFactory class without caring about internal buffers
        /// </summary>
        public WebSocketClientFactory()
        {
            BufferPool = new BufferPool();
            BufferFactory = BufferPool.GetBuffer;
        }

        /// <summary>
        ///     Initialises a new instance of the WebSocketClientFactory class with control over internal buffer creation
        /// </summary>
        /// <param name="bufferFactory">
        ///     Used to get a memory stream. Feel free to implement your own buffer pool. MemoryStreams
        ///     will be disposed when no longer needed and can be returned to the pool.
        /// </param>
        public WebSocketClientFactory(Func<MemoryStream> bufferFactory) => BufferFactory = bufferFactory;

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            TcpClient?.Dispose();
        }

        /// <summary>
        ///     Connect with default options
        /// </summary>
        /// <param name="uri">The WebSocket uri to connect to (e.g. ws://example.com or wss://example.com for SSL)</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket instance</returns>
        public async Task<WebSocket> ConnectAsync(Uri uri, CancellationToken token = default(CancellationToken)) => await ConnectAsync(uri, new WebSocketClientOptions(), token);

        /// <summary>
        ///     Connect with options specified
        /// </summary>
        /// <param name="uri">The WebSocket uri to connect to (e.g. ws://example.com or wss://example.com for SSL)</param>
        /// <param name="options">The WebSocket client options</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket instance</returns>
        public async Task<WebSocket> ConnectAsync(Uri uri, WebSocketClientOptions options,
            CancellationToken token = default(CancellationToken))
        {
            Guid guid = Guid.NewGuid();
            string host = uri.Host;
            int port = uri.Port;
            string uriScheme = uri.Scheme.ToLower();
            bool useSsl = uriScheme == "wss" || uriScheme == "https";
            Stream stream = await GetStream(guid, useSsl, options.NoDelay, host, port, token);
            return await PerformHandshake(guid, uri, stream, options, token);
        }

        /// <summary>
        ///     Connect with a stream that has already been opened and HTTP websocket upgrade request sent
        ///     This function will check the handshake response from the server and proceed if successful
        ///     Use this function if you have specific requirements to open a conenction like using special http headers and
        ///     cookies
        ///     You will have to build your own HTTP websocket upgrade request
        ///     You may not even choose to use TCP/IP and this function will allow you to do that
        /// </summary>
        /// <param name="responseStream">The full duplex response stream from the server</param>
        /// <param name="secWebSocketKey">The secWebSocketKey you used in the handshake request</param>
        /// <param name="options">The WebSocket client options</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns></returns>
        public async Task<WebSocket> ConnectAsync(Stream responseStream, string secWebSocketKey,
            WebSocketClientOptions options, CancellationToken token = default(CancellationToken))
        {
            Guid guid = Guid.NewGuid();
            return await ConnectAsync(guid, responseStream, secWebSocketKey, options.KeepAliveInterval,
                options.SecWebSocketExtensions, options.IncludeExceptionInCloseResponse, token);
        }

        /// <summary>
        ///     Connects the guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="responseStream">The response stream</param>
        /// <param name="secWebSocketKey">The sec web socket key</param>
        /// <param name="keepAliveInterval">The keep alive interval</param>
        /// <param name="secWebSocketExtensions">The sec web socket extensions</param>
        /// <param name="includeExceptionInCloseResponse">The include exception in close response</param>
        /// <param name="token">The token</param>
        /// <exception cref="WebSocketHandshakeFailedException">Handshake unexpected failure </exception>
        /// <returns>A task containing the web socket</returns>
        internal async Task<WebSocket> ConnectAsync(Guid guid, Stream responseStream, string secWebSocketKey,
            TimeSpan keepAliveInterval, string secWebSocketExtensions, bool includeExceptionInCloseResponse,
            CancellationToken token)
        {
            Events.Log.ReadingHttpResponse(guid);
            string response = string.Empty;

            try
            {
                response = await HttpHelper.ReadHttpHeaderAsync(responseStream, token);
            }
            catch (Exception ex)
            {
                Events.Log.ReadHttpResponseError(guid, ex.ToString());
                throw new WebSocketHandshakeFailedException("Handshake unexpected failure", ex);
            }

            ThrowIfInvalidResponseCode(response);
            ThrowIfInvalidAcceptString(guid, response, secWebSocketKey);
            string subProtocol = GetSubProtocolFromHeader(response);
            return new WebSocketImplementation(guid, BufferFactory, responseStream, keepAliveInterval,
                secWebSocketExtensions, includeExceptionInCloseResponse, true, subProtocol);
        }

        /// <summary>
        ///     Gets the sub protocol from header using the specified response
        /// </summary>
        /// <param name="response">The response</param>
        /// <returns>The string</returns>
        internal string GetSubProtocolFromHeader(string response)
        {
            // make sure we escape the accept string which could contain special regex characters
            string regexPattern = "Sec-WebSocket-Protocol: (.*)";
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            Match match = regex.Match(response);
            return match.Success ? match.Groups[1].Value.Trim() : null;
        }

        /// <summary>
        ///     Throws the if invalid accept string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="response">The response</param>
        /// <param name="secWebSocketKey">The sec web socket key</param>
        /// <exception cref="WebSocketHandshakeFailedException"></exception>
        internal void ThrowIfInvalidAcceptString(Guid guid, string response, string secWebSocketKey)
        {
            // make sure we escape the accept string which could contain special regex characters
            string regexPattern = "Sec-WebSocket-Accept: (.*)";
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            string actualAcceptString = regex.Match(response).Groups[1].Value.Trim();

            // check the accept string
            string expectedAcceptString = HttpHelper.ComputeSocketAcceptString(secWebSocketKey);
            if (expectedAcceptString != actualAcceptString)
            {
                string warning =
                    string.Format(
                        $"Handshake failed because the accept string from the server '{expectedAcceptString}' was not the expected string '{actualAcceptString}'");
                Events.Log.HandshakeFailure(guid, warning);
                throw new WebSocketHandshakeFailedException(warning);
            }

            Events.Log.ClientHandshakeSuccess(guid);
        }

        /// <summary>
        ///     Throws the if invalid response code using the specified response header
        /// </summary>
        /// <param name="responseHeader">The response header</param>
        /// <exception cref="InvalidHttpResponseCodeException"></exception>
        /// <exception cref="InvalidHttpResponseCodeException">null null </exception>
        internal void ThrowIfInvalidResponseCode(string responseHeader)
        {
            string responseCode = HttpHelper.ReadHttpResponseCode(responseHeader);
            if (responseCode == null)
            {
                throw new InvalidHttpResponseCodeException(null, null, responseHeader);
            }

            if (!responseCode.StartsWith("101 ", StringComparison.InvariantCultureIgnoreCase))
            {
                string[] lines = responseHeader.Split(new[] {"\r\n"}, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++)
                {
                    // if there is more to the message than just the header
                    if (string.IsNullOrWhiteSpace(lines[i]))
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int j = i + 1; j < lines.Length - 1; j++)
                        {
                            builder.AppendLine(lines[j]);
                        }

                        string responseDetails = builder.ToString();
                        throw new InvalidHttpResponseCodeException(responseCode, responseDetails, responseHeader);
                    }
                }
            }
        }

        /// <summary>
        ///     Override this if you need more fine grained control over the TLS handshake like setting the SslProtocol or adding a
        ///     client certificate
        /// </summary>
        internal virtual void TlsAuthenticateAsClient(SslStream sslStream, string host)
        {
            sslStream.AuthenticateAsClient(host, null, SslProtocols.Tls12, true);
        }

        /// <summary>
        ///     Override this if you need more control over how the stream used for the websocket is created. It does not event
        ///     need to be a TCP stream
        /// </summary>
        /// <param name="loggingGuid">For logging purposes only</param>
        /// <param name="isSecure">Make a secure connection</param>
        /// <param name="noDelay">
        ///     Set to true to send a message immediately with the least amount of latency (typical usage for
        ///     chat)
        /// </param>
        /// <param name="host">The destination host (can be an IP address)</param>
        /// <param name="port">The destination port</param>
        /// <param name="cancellationToken">Used to cancel the request</param>
        /// <returns>A connected and open stream</returns>
        internal virtual async Task<Stream> GetStream(Guid loggingGuid, bool isSecure, bool noDelay, string host,
            int port, CancellationToken cancellationToken)
        {
            TcpClient = new TcpClient();
            TcpClient.NoDelay = noDelay;
            IPAddress ipAddress;
            if (IPAddress.TryParse(host, out ipAddress))
            {
                Events.Log.ClientConnectingToIpAddress(loggingGuid, ipAddress.ToString(), port);
                await TcpClient.ConnectAsync(ipAddress, port);
            }
            else
            {
                Events.Log.ClientConnectingToHost(loggingGuid, host, port);
                await TcpClient.ConnectAsync(host, port);
            }

            cancellationToken.ThrowIfCancellationRequested();
            Stream stream = TcpClient.GetStream();

            if (isSecure)
            {
                SslStream sslStream = new SslStream(stream, false, ValidateServerCertificate, null);
                Events.Log.AttemtingToSecureSslConnection(loggingGuid);

                // This will throw an AuthenticationException if the certificate is not valid
                TlsAuthenticateAsClient(sslStream, host);
                Events.Log.ConnectionSecured(loggingGuid);
                return sslStream;
            }

            Events.Log.ConnectionNotSecure(loggingGuid);
            return stream;
        }

        /// <summary>
        ///     Invoked by the RemoteCertificateValidationDelegate
        ///     If you want to ignore certificate errors (for debugging) then return true
        /// </summary>
        internal static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            Events.Log.SslCertificateError(sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }

        /// <summary>
        ///     Gets the additional headers using the specified additional headers
        /// </summary>
        /// <param name="additionalHeaders">The additional headers</param>
        /// <returns>The string</returns>
        internal static string GetAdditionalHeaders(Dictionary<string, string> additionalHeaders)
        {
            if (additionalHeaders == null || additionalHeaders.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in additionalHeaders)
            {
                builder.Append($"{pair.Key}: {pair.Value}\r\n");
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Performs the handshake using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="uri">The uri</param>
        /// <param name="stream">The stream</param>
        /// <param name="options">The options</param>
        /// <param name="token">The token</param>
        /// <returns>A task containing the web socket</returns>
        internal async Task<WebSocket> PerformHandshake(Guid guid, Uri uri, Stream stream,
            WebSocketClientOptions options, CancellationToken token)
        {
            string secWebSocketKey = GenerateSecWebSocketKey();
            string additionalHeaders = GetAdditionalHeaders(options.AdditionalHttpHeaders);
            string handshakeHttpRequest = BuildHandshakeRequest(uri, secWebSocketKey, options.SecWebSocketProtocol, additionalHeaders);

            await SendHandshakeRequest(stream, handshakeHttpRequest, guid);
            return await ConnectAsync(stream, secWebSocketKey, options, token);
        }

        /// <summary>
        ///     Generates the sec web socket key
        /// </summary>
        /// <returns>The string</returns>
        internal string GenerateSecWebSocketKey()
        {
            RandomNumberGenerator rand = RandomNumberGenerator.Create();
            byte[] keyAsBytes = new byte[16];
            rand.GetBytes(keyAsBytes);
            return Convert.ToBase64String(keyAsBytes);
        }

        /// <summary>
        ///     Builds the handshake request using the specified uri
        /// </summary>
        /// <param name="uri">The uri</param>
        /// <param name="secWebSocketKey">The sec web socket key</param>
        /// <param name="secWebSocketProtocol">The sec web socket protocol</param>
        /// <param name="additionalHeaders">The additional headers</param>
        /// <returns>The string</returns>
        internal string BuildHandshakeRequest(Uri uri, string secWebSocketKey, string secWebSocketProtocol, string additionalHeaders) => $"GET {uri.PathAndQuery} HTTP/1.1\r\n" +
                                                                                                                                         $"Host: {uri.Host}:{uri.Port}\r\n" +
                                                                                                                                         "Upgrade: websocket\r\n" +
                                                                                                                                         "Connection: Upgrade\r\n" +
                                                                                                                                         $"Sec-WebSocket-Key: {secWebSocketKey}\r\n" +
                                                                                                                                         $"Origin: http://{uri.Host}:{uri.Port}\r\n" +
                                                                                                                                         $"Sec-WebSocket-Protocol: {secWebSocketProtocol}\r\n" +
                                                                                                                                         additionalHeaders +
                                                                                                                                         "Sec-WebSocket-Version: 13\r\n\r\n";

        /// <summary>
        ///     Sends the handshake request using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="handshakeHttpRequest">The handshake http request</param>
        /// <param name="guid">The guid</param>
        internal async Task SendHandshakeRequest(Stream stream, string handshakeHttpRequest, Guid guid)
        {
            byte[] httpRequest = Encoding.UTF8.GetBytes(handshakeHttpRequest);
            await stream.WriteAsync(httpRequest, 0, httpRequest.Length);
            Events.Log.HandshakeSent(guid, handshakeHttpRequest);
        }
    }
}