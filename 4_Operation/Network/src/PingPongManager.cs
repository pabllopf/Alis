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

using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Time;
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
        internal readonly CancellationToken CancellationToken;

        /// <summary>
        ///     The guid
        /// </summary>
        internal readonly Guid Guid;

        /// <summary>
        ///     The keep alive interval
        /// </summary>
        internal readonly TimeSpan KeepAliveInterval;

        /// <summary>
        ///     The stopwatch
        /// </summary>
        internal readonly Clock Stopwatch;

        /// <summary>
        ///     The web socket
        /// </summary>
        internal readonly WebSocketImplementation WebSocketInternal;

        /// <summary>
        ///     The ping sent ticks
        /// </summary>
        internal long PingSentTicks;

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
            WebSocketInternal = webSocketImpl ?? throw new InvalidCastException(
                "Cannot cast WebSocket to an instance of WebSocketImplementation. Please use the web socket factories to create a web socket");
            Guid = guid;
            KeepAliveInterval = keepAliveInterval;
            CancellationToken = cancellationToken;
            webSocketImpl.Pong += WebSocketImplPong;
            Stopwatch = Clock.StartNew();

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
            await WebSocketInternal.SendPingAsync(payload, cancellation);
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
        internal async Task PingForever()
        {
            LogPingPongManagerStart();

            try
            {
                await PingLoop();
            }
            catch (OperationCanceledException)
            {
                // normal, do nothing
            }

            LogPingPongManagerEnd();
        }

        /// <summary>
        ///     Pings the loop
        /// </summary>
        internal async Task PingLoop()
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                await Task.Delay(KeepAliveInterval, CancellationToken);

                if (WebSocketInternal.State != WebSocketState.Open)
                {
                    break;
                }

                if (PingSentTicksExist())
                {
                    await HandleExpiredKeepAliveInterval();
                    break;
                }

                if (!CancellationToken.IsCancellationRequested)
                {
                    await SendPing();
                }
            }
        }

        /// <summary>
        ///     Logs the ping pong manager start
        /// </summary>
        internal void LogPingPongManagerStart()
        {
            Events.Log.PingPongManagerStarted(Guid, (int) KeepAliveInterval.TotalSeconds);
        }

        /// <summary>
        ///     Logs the ping pong manager end
        /// </summary>
        internal void LogPingPongManagerEnd()
        {
            Events.Log.PingPongManagerEnded(Guid);
        }

        /// <summary>
        ///     Describes whether this instance ping sent ticks exist
        /// </summary>
        /// <returns>The bool</returns>
        internal bool PingSentTicksExist() => PingSentTicks != 0;

        /// <summary>
        ///     Handles the expired keep alive interval
        /// </summary>
        internal async Task HandleExpiredKeepAliveInterval()
        {
            Events.Log.KeepAliveIntervalExpired(Guid, (int) KeepAliveInterval.TotalSeconds);
            await WebSocketInternal.CloseAsync(WebSocketCloseStatus.NormalClosure,
                $"No Pong message received in response to a Ping after KeepAliveInterval {KeepAliveInterval}",
                CancellationToken);
        }

        /// <summary>
        ///     Sends the ping
        /// </summary>
        internal async Task SendPing()
        {
            PingSentTicks = Stopwatch.Elapsed.Ticks;
            ArraySegment<byte> buffer = new ArraySegment<byte>(BitConverter.GetBytes(PingSentTicks));
            await SendPing(buffer, CancellationToken);
        }

        /// <summary>
        ///     Webs the socket impl pong using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        internal void WebSocketImplPong(object sender, PongEventArgs e)
        {
            PingSentTicks = 0;
            OnPong(e);
        }
    }
}