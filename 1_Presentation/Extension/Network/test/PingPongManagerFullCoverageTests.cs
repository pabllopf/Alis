// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PingPongManagerFullCoverageTests.cs
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
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The ping pong manager full coverage tests class
    /// </summary>
    public class PingPongManagerFullCoverageTests
    {
        /// <summary>
        ///     Tests that handle expired keep alive interval closes the socket
        /// </summary>
        [Fact]
        public async Task HandleExpiredKeepAliveInterval_ClosesSocket()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(5), cts.Token);

            Exception ex = await Record.ExceptionAsync(() => manager.HandleExpiredKeepAliveInterval());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that ping sent ticks exist returns false when no ping was sent
        /// </summary>
        [Fact]
        public void PingSentTicksExist_WithoutPing_ReturnsFalse()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(5), cts.Token);

            Assert.False(manager.PingSentTicksExist());
        }

        /// <summary>
        ///     Tests that send ping records the ping sent ticks
        /// </summary>
        [Fact]
        public async Task SendPing_RecordsPingSentTicks()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(5), cts.Token);

            await manager.SendPing();

            Assert.True(manager.PingSentTicksExist());
        }

        /// <summary>
        ///     Tests that ping loop with pending expired ping handles the expired keep alive
        /// </summary>
        [Fact]
        public async Task PingLoop_WithExpiredPing_HandlesKeepAlive()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromMilliseconds(1), cts.Token);

            await manager.SendPing();

            Exception ex = await Record.ExceptionAsync(() => manager.PingLoop());

            Assert.Null(ex);
        }
    }
}
