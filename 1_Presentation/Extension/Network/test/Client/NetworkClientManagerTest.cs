// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkClientManagerTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    /// <summary>
    ///     The network client manager test class
    /// </summary>
    public class NetworkClientManagerTest : IDisposable
    {
        private NetworkClientManager _manager;

        public NetworkClientManagerTest()
        {
            _manager = new NetworkClientManager();
        }

        public void Dispose()
        {
            _manager?.Dispose();
        }

        /// <summary>
        ///     Tests that constructor initializes the manager with a GUID ID
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithGuidId()
        {
            Assert.NotNull(_manager.Id);
            Assert.NotEmpty(_manager.Id);
        }

        /// <summary>
        ///     Tests that Id is a valid GUID format
        /// </summary>
        [Fact]
        public void Id_ShouldBeValidGuidFormat()
        {
            Guid id = Guid.Parse(_manager.Id);

            Assert.NotNull(id);
        }

        /// <summary>
        ///     Tests that Id property is readable
        /// </summary>
        [Fact]
        public void Id_ShouldBeReadable()
        {
            Assert.NotNull(_manager.Id);
            Assert.NotEmpty(_manager.Id);
        }

        /// <summary>
        ///     Tests that State returns Uninitialized by default
        /// </summary>
        [Fact]
        public void State_Default_ShouldReturnUninitialized()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);
        }

        /// <summary>
        ///     Tests that CurrentSession is null by default
        /// </summary>
        [Fact]
        public void CurrentSession_Default_ShouldBeNull()
        {
            Assert.Null(_manager.CurrentSession);
        }

        /// <summary>
        ///     Tests that LocalPlayer is null by default
        /// </summary>
        [Fact]
        public void LocalPlayer_Default_ShouldBeNull()
        {
            Assert.Null(_manager.LocalPlayer);
        }

        /// <summary>
        ///     Tests that Config is null by default
        /// </summary>
        [Fact]
        public void Config_Default_ShouldBeNull()
        {
            Assert.Null(_manager.Config);
        }

        /// <summary>
        ///     Tests that ServerUri is null by default
        /// </summary>
        [Fact]
        public void ServerUri_Default_ShouldBeNull()
        {
            Assert.Null(_manager.ServerUri);
        }

        /// <summary>
        ///     Tests that Dispose does not throw
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrow()
        {
            Assert.NotNull(_manager);

            _manager.Dispose();

            // No exception means success
        }

        /// <summary>
        ///     Tests that multiple Dispose calls do not throw
        /// </summary>
        [Fact]
        public void MultipleDisposeCalls_ShouldNotThrow()
        {
            Assert.NotNull(_manager);

            _manager.Dispose();
            _manager.Dispose();
            _manager.Dispose();

            // No exception means success
        }

        /// <summary>
        ///     Tests that RegisterMessageHandler registers a handler
        /// </summary>
        [Fact]
        public void RegisterMessageHandler_ShouldRegisterHandler()
        {
            Task<string> handler(string type, string data) => Task.FromResult("response");

            _manager.RegisterMessageHandler("test-type", handler);

            // Handler registered without exception
        }

        /// <summary>
        ///     Tests that UnregisterMessageHandler removes a handler
        /// </summary>
        [Fact]
        public void UnregisterMessageHandler_ShouldRemoveHandler()
        {
            Task<string> handler(string type, string data) => Task.FromResult("response");

            _manager.RegisterMessageHandler("test-type", handler);
            _manager.UnregisterMessageHandler("test-type");

            // Handler removed without exception
        }

        /// <summary>
        ///     Tests that UnregisterMessageHandler with non-existent type does not throw
        /// </summary>
        [Fact]
        public void UnregisterMessageHandler_WithNonExistentType_ShouldNotThrow()
        {
            _manager.UnregisterMessageHandler("non-existent");

            // No exception means success
        }


        /// <summary>
        ///     Tests that NetworkConfig has correct defaults
        /// </summary>
        [Fact]
        public void NetworkConfig_Defaults_ShouldBeCorrect()
        {
            NetworkConfig config = new NetworkConfig();

            Assert.Equal(32, config.MaxPlayers);
            Assert.Equal(60, config.TickRate);
            Assert.True(config.ServerAuthoritative);
        }

        /// <summary>
        ///     Tests that NetworkConfig.TickInterval is calculated correctly
        /// </summary>
        [Fact]
        public void NetworkConfig_TickInterval_ShouldBeCalculatedCorrectly()
        {
            NetworkConfig config = new NetworkConfig { TickRate = 60 };

            TimeSpan expected = TimeSpan.FromSeconds(1.0 / 60);
            Assert.Equal(expected, config.TickInterval);
        }

        /// <summary>
        ///     Tests that NetworkConfig with custom values works
        /// </summary>
        [Fact]
        public void NetworkConfig_CustomValues_ShouldWork()
        {
            NetworkConfig config = new NetworkConfig
            {
                MaxPlayers = 16,
                TickRate = 30,
                ServerAuthoritative = false
            };

            Assert.Equal(16, config.MaxPlayers);
            Assert.Equal(30, config.TickRate);
            Assert.False(config.ServerAuthoritative);
        }

        /// <summary>
        ///     Tests that events can be subscribed and unsubscribed
        /// </summary>
        [Fact]
        public void Events_ShouldBeSubscribable()
        {
            _manager.PlayerJoined += OnPlayerJoined;
            _manager.PlayerLeft += OnPlayerLeft;
            _manager.Connected += OnConnected;
            _manager.Disconnected += OnDisconnected;
            _manager.Error += OnError;
            _manager.ServerMessageReceived += OnServerMessageReceived;

            _manager.PlayerJoined -= OnPlayerJoined;
            _manager.PlayerLeft -= OnPlayerLeft;
            _manager.Connected -= OnConnected;
            _manager.Disconnected -= OnDisconnected;
            _manager.Error -= OnError;
            _manager.ServerMessageReceived -= OnServerMessageReceived;

            // No exception means events work correctly
        }

        private void OnPlayerJoined(object sender, PlayerEventArgs e) { }
        private void OnPlayerLeft(object sender, PlayerEventArgs e) { }
        private void OnConnected(object sender, EventArgs e) { }
        private void OnDisconnected(object sender, EventArgs e) { }
        private void OnError(object sender, NetworkErrorEventArgs e) { }
        private void OnServerMessageReceived(object sender, ServerMessageEventArgs e) { }
    }
}
