// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PingPongManager.cs
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
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Internal;

namespace Alis.Core.Network
{
    /// <summary>
    ///     Ping Pong Manager used to facilitate ping pong WebSocket messages
    /// </summary>
    public class PingPongManager : IPingPongManager
    {
        /// <summary>
        ///     The cancellation token
        /// </summary>
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        ///     The guid
        /// </summary>
        private readonly Guid _guid;

        /// <summary>
        ///     The keep alive interval
        /// </summary>
        private readonly TimeSpan _keepAliveInterval;

        /// <summary>
        ///     The stopwatch
        /// </summary>
        private readonly Stopwatch _stopwatch;

        /// <summary>
        ///     The web socket
        /// </summary>
        private readonly WebSocketImplementation _webSocket;

        /// <summary>
        ///     The ping sent ticks
        /// </summary>
        private long _pingSentTicks;

        /// <summary>
        ///     Initialises a new instance of the PingPongManager to facilitate ping pong WebSocket messages.
        ///     If you are manually creating an instance of this class then it is advisable to set keepAliveInterval to
        ///     TimeSpan.Zero when you create the WebSocket instance (using a factory) otherwise you may be automatically
        ///     be sending duplicate Ping messages (see keepAliveInterval below)
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="webSocket">The web socket used to listen to ping messages and send pong messages</param>
        /// <param name="keepAliveInterval">
        ///     The time between automatically sending ping messages.
        ///     Set this to TimeSpan.Zero if you with to manually control sending ping messages.
        /// </param>
        /// <param name="cancellationToken">
        ///     The token used to cancel a pending ping send AND the automatic sending of ping messages
        ///     if keepAliveInterval is positive
        /// </param>
        public PingPongManager(Guid guid, WebSocket webSocket, TimeSpan keepAliveInterval,
            CancellationToken cancellationToken)
        {
            WebSocketImplementation webSocketImpl = webSocket as WebSocketImplementation;
            _webSocket = webSocketImpl ?? throw new InvalidCastException(
                "Cannot cast WebSocket to an instance of WebSocketImplementation. Please use the web socket factories to create a web socket");
            _guid = guid;
            _keepAliveInterval = keepAliveInterval;
            _cancellationToken = cancellationToken;
            webSocketImpl.Pong += WebSocketImpl_Pong;
            _stopwatch = Stopwatch.StartNew();

            if (keepAliveInterval == TimeSpan.Zero)
            {
                Task.FromResult(0);
            }
            else
            {
                Task.Run(PingForever, cancellationToken);
            }
        }

        /// <summary>
        ///     Raised when a Pong frame is received
        /// </summary>
        public event EventHandler<PongEventArgs> Pong;

        /// <summary>
        ///     Sends a ping frame
        /// </summary>
        /// <param name="payload">The payload (must be 125 bytes of less)</param>
        /// <param name="cancellation">The cancellation token</param>
        public async Task SendPing(ArraySegment<byte> payload, CancellationToken cancellation)
        {
            await _webSocket.SendPingAsync(payload, cancellation);
        }

        /// <summary>
        ///     Ons the pong using the specified e
        /// </summary>
        /// <param name="e">The </param>
        protected virtual void OnPong(PongEventArgs e)
        {
            Pong?.Invoke(this, e);
        }

        /// <summary>
        ///     Pings the forever
        /// </summary>
        private async Task PingForever()
        {
            Events.Log.PingPongManagerStarted(_guid, (int) _keepAliveInterval.TotalSeconds);

            try
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(_keepAliveInterval, _cancellationToken);

                    if (_webSocket.State != WebSocketState.Open)
                    {
                        break;
                    }

                    if (_pingSentTicks != 0)
                    {
                        Events.Log.KeepAliveIntervalExpired(_guid, (int) _keepAliveInterval.TotalSeconds);
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                            $"No Pong message received in response to a Ping after KeepAliveInterval {_keepAliveInterval}",
                            _cancellationToken);
                        break;
                    }

                    if (!_cancellationToken.IsCancellationRequested)
                    {
                        _pingSentTicks = _stopwatch.Elapsed.Ticks;
                        ArraySegment<byte> buffer = new ArraySegment<byte>(BitConverter.GetBytes(_pingSentTicks));
                        await SendPing(buffer, _cancellationToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // normal, do nothing
            }

            Events.Log.PingPongManagerEnded(_guid);
        }

        /// <summary>
        ///     Webs the socket impl pong using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void WebSocketImpl_Pong(object sender, PongEventArgs e)
        {
            _pingSentTicks = 0;
            OnPong(e);
        }
    }
}