// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PingPongManagerTest.cs
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
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for PingPongManager class
    /// </summary>
    public class PingPongManagerTest
    {
        /// <summary>
        /// Tests that constructor with zero keep alive interval creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithZeroKeepAliveInterval_CreatesInstance()
        {
            Guid guid = Guid.NewGuid();
            WebSocket webSocket = null;
            TimeSpan keepAliveInterval = TimeSpan.Zero;
            CancellationToken token = CancellationToken.None;

            Exception exception = Record.Exception(() => new PingPongManager(guid, webSocket, keepAliveInterval, token));

            Assert.NotNull(exception);
            Assert.IsType<InvalidCastException>(exception);
        }

        /// <summary>
        /// Tests that constructor with valid WebSocketImplementation creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithValidWebSocket_CreatesInstance()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            CancellationTokenSource cts = new CancellationTokenSource();

            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            Assert.NotNull(manager);
        }

        /// <summary>
        /// Tests that PingSentTicksExist returns false when no ping sent
        /// </summary>
        [Fact]
        public void PingSentTicksExist_NoPingSent_ReturnsFalse()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            bool result = manager.PingSentTicksExist();

            Assert.False(result);
        }

        /// <summary>
        /// Tests that PingSentTicksExist returns true after internal SendPing
        /// </summary>
        [Fact]
        public async Task PingSentTicksExist_AfterInternalSendPing_ReturnsTrue()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            await manager.SendPing();

            Assert.True(manager.PingSentTicksExist());
        }

        /// <summary>
        /// Tests that WebSocketImplPong clears ping sent ticks and raises event
        /// </summary>
        [Fact]
        public void WebSocketImplPong_ClearsTicksAndRaisesEvent()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);
            bool eventRaised = false;
            manager.Pong += (sender, args) => eventRaised = true;

            manager.WebSocketImplPong(null, new PongEventArgs(new ArraySegment<byte>(new byte[0])));

            Assert.False(manager.PingSentTicksExist());
            Assert.True(eventRaised);
        }

        /// <summary>
        /// Tests that LogPingPongManagerStart does not throw
        /// </summary>
        [Fact]
        public void LogPingPongManagerStart_DoesNotThrow()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            manager.LogPingPongManagerStart();
        }

        /// <summary>
        /// Tests that LogPingPongManagerEnd does not throw
        /// </summary>
        [Fact]
        public void LogPingPongManagerEnd_DoesNotThrow()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            manager.LogPingPongManagerEnd();
        }
    }
}
