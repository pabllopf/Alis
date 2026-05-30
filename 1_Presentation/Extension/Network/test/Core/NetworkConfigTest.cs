// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkConfigTest.cs
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
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     Tests for NetworkConfig class
    /// </summary>
    public class NetworkConfigTest
    {
        /// <summary>
        ///     Tests that default constructor sets expected default values
        /// </summary>
        [Fact]
        public void Constructor_DefaultValues_AreCorrect()
        {
            NetworkConfig config = new NetworkConfig();

            Assert.Equal(32, config.MaxPlayers);
            Assert.Equal(60, config.TickRate);
            Assert.True(config.ServerAuthoritative);
            Assert.Equal(TimeSpan.FromSeconds(30), config.ConnectionTimeout);
            Assert.Equal(TimeSpan.FromSeconds(5), config.HeartbeatInterval);
            Assert.True(config.EnableClientPrediction);
            Assert.True(config.EnableLagCompensation);
            Assert.Equal(1024 * 64, config.MaxMessageSize);
        }

        /// <summary>
        ///     Tests that TickInterval is computed correctly from TickRate
        /// </summary>
        [Fact]
        public void TickInterval_ComputedFromTickRate_ReturnsCorrectValue()
        {
            NetworkConfig config = new NetworkConfig {TickRate = 60};

            Assert.Equal(TimeSpan.FromSeconds(1.0 / 60), config.TickInterval);
        }

        /// <summary>
        ///     Tests that TickInterval updates when TickRate changes
        /// </summary>
        [Fact]
        public void TickInterval_WhenTickRateChanges_UpdatesAccordingly()
        {
            NetworkConfig config = new NetworkConfig {TickRate = 30};

            Assert.Equal(TimeSpan.FromSeconds(1.0 / 30), config.TickInterval);

            config.TickRate = 120;
            Assert.Equal(TimeSpan.FromSeconds(1.0 / 120), config.TickInterval);
        }

        /// <summary>
        ///     Tests that MaxPlayers can be set to custom value
        /// </summary>
        [Fact]
        public void MaxPlayers_SetToCustomValue_ReturnsCorrectValue()
        {
            NetworkConfig config = new NetworkConfig {MaxPlayers = 64};

            Assert.Equal(64, config.MaxPlayers);
        }

        /// <summary>
        ///     Tests that ServerAuthoritative can be disabled
        /// </summary>
        [Fact]
        public void ServerAuthoritative_Disabled_ReturnsFalse()
        {
            NetworkConfig config = new NetworkConfig {ServerAuthoritative = false};

            Assert.False(config.ServerAuthoritative);
        }

        /// <summary>
        ///     Tests that ConnectionTimeout can be customized
        /// </summary>
        [Fact]
        public void ConnectionTimeout_SetToCustomValue_ReturnsCorrectValue()
        {
            NetworkConfig config = new NetworkConfig {ConnectionTimeout = TimeSpan.FromSeconds(60)};

            Assert.Equal(TimeSpan.FromSeconds(60), config.ConnectionTimeout);
        }

        /// <summary>
        ///     Tests that HeartbeatInterval can be customized
        /// </summary>
        [Fact]
        public void HeartbeatInterval_SetToCustomValue_ReturnsCorrectValue()
        {
            NetworkConfig config = new NetworkConfig {HeartbeatInterval = TimeSpan.FromSeconds(10)};

            Assert.Equal(TimeSpan.FromSeconds(10), config.HeartbeatInterval);
        }

        /// <summary>
        ///     Tests that EnableClientPrediction can be disabled
        /// </summary>
        [Fact]
        public void EnableClientPrediction_Disabled_ReturnsFalse()
        {
            NetworkConfig config = new NetworkConfig {EnableClientPrediction = false};

            Assert.False(config.EnableClientPrediction);
        }

        /// <summary>
        ///     Tests that EnableLagCompensation can be disabled
        /// </summary>
        [Fact]
        public void EnableLagCompensation_Disabled_ReturnsFalse()
        {
            NetworkConfig config = new NetworkConfig {EnableLagCompensation = false};

            Assert.False(config.EnableLagCompensation);
        }

        /// <summary>
        ///     Tests that MaxMessageSize can be customized
        /// </summary>
        [Fact]
        public void MaxMessageSize_SetToCustomValue_ReturnsCorrectValue()
        {
            NetworkConfig config = new NetworkConfig {MaxMessageSize = 1024 * 128};

            Assert.Equal(1024 * 128, config.MaxMessageSize);
        }
    }
}
