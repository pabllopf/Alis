// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebServer.cs
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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory.Exceptions;

namespace Alis.Core.Network.Sample.Server
{
    /// <summary>
    ///     The web server class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class WebServer : IDisposable
    {
        // const int BUFFER_SIZE = 1 * 1024 * 1024 * 1024; // 1GB
        /// <summary>
        ///     The buffer size
        /// </summary>
        private const int BufferSize = 4 * 1024 * 1024; // 4MB

        /// <summary>
        ///     The supported sub protocols
        /// </summary>
        private readonly HashSet<string> _supportedSubProtocols;

        /// <summary>
        ///     The web socket server factory
        /// </summary>
        private readonly IWebSocketServerFactory _webSocketServerFactory;

        /// <summary>
        ///     The is disposed
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        ///     The listener
        /// </summary>
        private TcpListener _listener;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebServer" /> class
        /// </summary>
        /// <param name="webSocketServerFactory">The web socket server factory</param>
        /// <param name="supportedSubProtocols">The supported sub protocols</param>
        public WebServer(IWebSocketServerFactory webSocketServerFactory, IList<string> supportedSubProtocols = null)
        {
            _webSocketServerFactory = webSocketServerFactory;
            _supportedSubProtocols = new HashSet<string>(supportedSubProtocols ?? new string[0]);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;

                // safely attempt to shut down the listener
                try
                {
                    if (_listener != null)
                    {
                        if (_listener.Server != null)
                        {
                            _listener.Server.Close();
                        }

                        _listener.Stop();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.ToString());
                }

                Debug.Print("Web Server disposed");
            }
        }

        /// <summary>
        ///     Processes the tcp client using the specified tcp client
        /// </summary>
        /// <param name="tcpClient">The tcp client</param>
        private void ProcessTcpClient(TcpClient tcpClient)
        {
            Task.Run(() => ProcessTcpClientAsync(tcpClient));
        }

        /// <summary>
        ///     Gets the sub protocol using the specified requested sub protocols
        /// </summary>
        /// <param name="requestedSubProtocols">The requested sub protocols</param>
        /// <returns>The string</returns>
        private string GetSubProtocol(IList<string> requestedSubProtocols)
        {
            foreach (string subProtocol in requestedSubProtocols)
            {
                // match the first sub protocol that we support (the client should pass the most preferable sub protocols first)
                if (_supportedSubProtocols.Contains(subProtocol))
                {
                    Debug.Print($"Http header has requested sub protocol {subProtocol} which is supported");

                    return subProtocol;
                }
            }

            if (requestedSubProtocols.Count > 0)
            {
                Debug.Print(
                    $"Http header has requested the following sub protocols: {string.Join(", ", requestedSubProtocols)}. There are no supported protocols configured that match.");
            }

            return null;
        }

        /// <summary>
        ///     Processes the tcp client using the specified tcp client
        /// </summary>
        /// <param name="tcpClient">The tcp client</param>
        private async Task ProcessTcpClientAsync(TcpClient tcpClient)
        {
            using CancellationTokenSource source = new CancellationTokenSource();
            try
            {
                if (_isDisposed)
                {
                    return;
                }

                // this worker thread stays alive until either of the following happens:
                // Client sends a close conection request OR
                // An unhandled exception is thrown OR
                // The server is disposed
                Debug.Print("Server: Connection opened. Reading Http header from stream");

                // get a secure or insecure stream
                Stream stream = tcpClient.GetStream();
                WebSocketHttpContext context = await _webSocketServerFactory.ReadHttpHeaderFromStreamAsync(stream);
                if (context.IsWebSocketRequest)
                {
                    string subProtocol = GetSubProtocol(context.WebSocketRequestedProtocols);
                    WebSocketServerOptions options =
                        new WebSocketServerOptions(TimeSpan.FromSeconds(30),
                            subProtocol);
                    Debug.Print(
                        "Http header has requested an upgrade to Web Socket protocol. Negotiating Web Socket handshake");

                    WebSocket webSocket = await _webSocketServerFactory.AcceptWebSocketAsync(context, options);

                    Debug.Print("Web Socket handshake response sent. Stream ready.");
                    await RespondToWebSocketRequestAsync(webSocket, source.Token);
                }
                else
                {
                    Debug.Print("Http header contains no web socket upgrade request. Ignoring");
                }

                Debug.Print("Server: Connection closed");
            }
            catch (ObjectDisposedException)
            {
                // do nothing. This will be thrown if the Listener has been stopped
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
            finally
            {
                try
                {
                    tcpClient.Client.Close();
                    tcpClient.Close();
                    source.Cancel();
                }
                catch (Exception ex)
                {
                    Debug.Print($"Failed to close TCP connection: {ex}");
                }
            }
        }

        /// <summary>
        ///     Responds the to web socket request using the specified web socket
        /// </summary>
        /// <param name="webSocket">The web socket</param>
        /// <param name="token">The token</param>
        public async Task RespondToWebSocketRequestAsync(WebSocket webSocket, CancellationToken token)
        {
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[BufferSize]);

            while (true)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, token);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    Debug.Print(
                        $"Client initiated close. Status: {result.CloseStatus} Description: {result.CloseStatusDescription}");
                    break;
                }

                if (result.Count > BufferSize)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.MessageTooBig,
                        $"Web socket frame cannot exceed buffer size of {BufferSize:#,##0} bytes. Send multiple frames instead.",
                        token);
                    break;
                }

                // just echo the message back to the client
                ArraySegment<byte> toSend = new ArraySegment<byte>(buffer.Array, buffer.Offset, result.Count);
                await webSocket.SendAsync(toSend, WebSocketMessageType.Binary, true, token);
            }
        }

        /// <summary>
        ///     Listens the port
        /// </summary>
        /// <param name="port">The port</param>
        /// <param name="ctsToken"></param>
        /// <exception cref="Exception"></exception>
        public async Task Listen(int port, CancellationToken ctsToken)
        {
            try
            {
                IPAddress localAddress = IPAddress.Any;
                _listener = new TcpListener(localAddress, port);
                _listener.Start();
                Debug.Print($"Server started listening on port {port}");
                while (!ctsToken.IsCancellationRequested)
                {
                    TcpClient tcpClient = await _listener.AcceptTcpClientAsync();
                    ProcessTcpClient(tcpClient);
                }
            }
            catch (SocketException ex)
            {
                throw new GeneralAlisException(ex.Message);
            }
        }
    }
}