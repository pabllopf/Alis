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
        [Fact]
        public void MaxPlayers_DefaultValueIs32()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            int result = config.MaxPlayers;

            // Assert
            Assert.Equal(32, result);
        }

        [Fact]
        public void MaxPlayers_SetValue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.MaxPlayers = 64;

            // Assert
            Assert.Equal(64, config.MaxPlayers);
        }

        [Fact]
        public void TickRate_DefaultValueIs60()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            int result = config.TickRate;

            // Assert
            Assert.Equal(60, result);
        }

        [Fact]
        public void TickRate_SetValue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.TickRate = 30;

            // Assert
            Assert.Equal(30, config.TickRate);
        }

        [Fact]
        public void TickInterval_CalculatedCorrectly()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            TimeSpan result = config.TickInterval;

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(1.0 / 60), result);
        }

        [Fact]
        public void TickInterval_ChangesWithTickRate()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();
            config.TickRate = 30;

            // Act
            TimeSpan result = config.TickInterval;

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(1.0 / 30), result);
        }

        [Fact]
        public void ServerAuthoritative_DefaultValueIsTrue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            bool result = config.ServerAuthoritative;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ServerAuthoritative_SetValueToFalse()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.ServerAuthoritative = false;

            // Assert
            Assert.False(config.ServerAuthoritative);
        }

        [Fact]
        public void ConnectionTimeout_DefaultValueIs30Seconds()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            TimeSpan result = config.ConnectionTimeout;

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(30), result);
        }

        [Fact]
        public void ConnectionTimeout_SetValue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.ConnectionTimeout = TimeSpan.FromSeconds(60);

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(60), config.ConnectionTimeout);
        }

        [Fact]
        public void HeartbeatInterval_DefaultValueIs5Seconds()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            TimeSpan result = config.HeartbeatInterval;

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(5), result);
        }

        [Fact]
        public void HeartbeatInterval_SetValue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.HeartbeatInterval = TimeSpan.FromSeconds(10);

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(10), config.HeartbeatInterval);
        }

        [Fact]
        public void EnableClientPrediction_DefaultValueIsTrue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            bool result = config.EnableClientPrediction;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EnableClientPrediction_SetValueToFalse()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.EnableClientPrediction = false;

            // Assert
            Assert.False(config.EnableClientPrediction);
        }

        [Fact]
        public void EnableLagCompensation_DefaultValueIsTrue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            bool result = config.EnableLagCompensation;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EnableLagCompensation_SetValueToFalse()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.EnableLagCompensation = false;

            // Assert
            Assert.False(config.EnableLagCompensation);
        }

        [Fact]
        public void MaxMessageSize_DefaultValueIs64KB()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            int result = config.MaxMessageSize;

            // Assert
            Assert.Equal(1024 * 64, result);
        }

        [Fact]
        public void MaxMessageSize_SetValue()
        {
            // Arrange
            NetworkConfig config = new NetworkConfig();

            // Act
            config.MaxMessageSize = 1024 * 128;

            // Assert
            Assert.Equal(1024 * 128, config.MaxMessageSize);
        }

        [Fact]
        public void CreateNewInstance_InitializesAllProperties()
        {
            // Arrange
            // Act
            NetworkConfig config = new NetworkConfig();

            // Assert
            Assert.NotNull(config);
            Assert.Equal(32, config.MaxPlayers);
            Assert.Equal(60, config.TickRate);
            Assert.True(config.ServerAuthoritative);
            Assert.Equal(TimeSpan.FromSeconds(30), config.ConnectionTimeout);
            Assert.Equal(TimeSpan.FromSeconds(5), config.HeartbeatInterval);
            Assert.True(config.EnableClientPrediction);
            Assert.True(config.EnableLagCompensation);
            Assert.Equal(1024 * 64, config.MaxMessageSize);
        }
    }
}
