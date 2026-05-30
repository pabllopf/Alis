// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkPlayerTest.cs
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
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     Tests for NetworkPlayer class
    /// </summary>
    public class NetworkPlayerTest
    {
        /// <summary>
        ///     Tests that default constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_DefaultValues_InitializesCorrectly()
        {
            NetworkPlayer player = new NetworkPlayer();

            Assert.Null(player.PlayerId);
            Assert.Null(player.PlayerName);
            Assert.False(player.IsHost);
            Assert.Equal(PlayerConnectionState.Disconnected, player.ConnectionState);
            Assert.Equal(0, player.JoinedAt);
            Assert.Equal(0, player.LastActivityAt);
            Assert.Equal(0, player.Latency);
            Assert.NotNull(player.CustomData);
            Assert.Empty(player.CustomData);
        }

        /// <summary>
        ///     Tests that PlayerId can be set and retrieved
        /// </summary>
        [Fact]
        public void PlayerId_SetAndGet_ReturnsCorrectValue()
        {
            NetworkPlayer player = new NetworkPlayer {PlayerId = "player-123"};

            Assert.Equal("player-123", player.PlayerId);
        }

        /// <summary>
        ///     Tests that PlayerName can be set and retrieved
        /// </summary>
        [Fact]
        public void PlayerName_SetAndGet_ReturnsCorrectValue()
        {
            NetworkPlayer player = new NetworkPlayer {PlayerName = "TestPlayer"};

            Assert.Equal("TestPlayer", player.PlayerName);
        }

        /// <summary>
        ///     Tests that IsHost can be set to true
        /// </summary>
        [Fact]
        public void IsHost_SetToTrue_ReturnsTrue()
        {
            NetworkPlayer player = new NetworkPlayer {IsHost = true};

            Assert.True(player.IsHost);
        }

        /// <summary>
        ///     Tests that ConnectionState can be set to different states
        /// </summary>
        [Theory]
        [InlineData(PlayerConnectionState.Connected)]
        [InlineData(PlayerConnectionState.Disconnected)]
        [InlineData(PlayerConnectionState.Connecting)]
        public void ConnectionState_SetToDifferentStates_ReturnsCorrectValue(PlayerConnectionState state)
        {
            NetworkPlayer player = new NetworkPlayer {ConnectionState = state};

            Assert.Equal(state, player.ConnectionState);
        }

        /// <summary>
        ///     Tests that JoinedAt timestamp is stored correctly
        /// </summary>
        [Fact]
        public void JoinedAt_SetToTimestamp_ReturnsCorrectValue()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            NetworkPlayer player = new NetworkPlayer {JoinedAt = timestamp};

            Assert.Equal(timestamp, player.JoinedAt);
        }

        /// <summary>
        ///     Tests that LastActivityAt timestamp is stored correctly
        /// </summary>
        [Fact]
        public void LastActivityAt_SetToTimestamp_ReturnsCorrectValue()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            NetworkPlayer player = new NetworkPlayer {LastActivityAt = timestamp};

            Assert.Equal(timestamp, player.LastActivityAt);
        }

        /// <summary>
        ///     Tests that Latency can be set to custom value
        /// </summary>
        [Fact]
        public void Latency_SetToCustomValue_ReturnsCorrectValue()
        {
            NetworkPlayer player = new NetworkPlayer {Latency = 150};

            Assert.Equal(150, player.Latency);
        }

        /// <summary>
        ///     Tests that CustomData dictionary can store multiple entries
        /// </summary>
        [Fact]
        public void CustomData_AddMultipleEntries_AllStored()
        {
            NetworkPlayer player = new NetworkPlayer();
            player.CustomData["score"] = "100";
            player.CustomData["level"] = "5";
            player.CustomData["team"] = "red";

            Assert.Equal(3, player.CustomData.Count);
            Assert.Equal("100", player.CustomData["score"]);
            Assert.Equal("5", player.CustomData["level"]);
            Assert.Equal("red", player.CustomData["team"]);
        }

        /// <summary>
        ///     Tests that JoinedDateTime converts unix timestamp correctly
        /// </summary>
        [Fact]
        public void JoinedDateTime_ConvertsUnixTimestamp_ReturnsCorrectDateTime()
        {
            long unixTimestamp = 1609459200; // 2021-01-01 00:00:00 UTC
            NetworkPlayer player = new NetworkPlayer {JoinedAt = unixTimestamp};

            DateTime expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
            Assert.Equal(expected, player.JoinedDateTime);
        }

        /// <summary>
        ///     Tests that JoinedDateTime handles zero timestamp
        /// </summary>
        [Fact]
        public void JoinedDateTime_ZeroTimestamp_ReturnsUnixEpoch()
        {
            NetworkPlayer player = new NetworkPlayer {JoinedAt = 0};

            DateTime expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            Assert.Equal(expected, player.JoinedDateTime);
        }

        /// <summary>
        ///     Tests that multiple players can have different data
        /// </summary>
        [Fact]
        public void MultiplePlayers_HaveDifferentData()
        {
            NetworkPlayer player1 = new NetworkPlayer {PlayerId = "p1", PlayerName = "Alice", IsHost = true};
            NetworkPlayer player2 = new NetworkPlayer {PlayerId = "p2", PlayerName = "Bob", IsHost = false};

            Assert.NotEqual(player1.PlayerId, player2.PlayerId);
            Assert.NotEqual(player1.PlayerName, player2.PlayerName);
            Assert.NotEqual(player1.IsHost, player2.IsHost);
        }
    }
}
