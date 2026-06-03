// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkTransportStateTest.cs
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
    ///     Tests for NetworkTransportState enumeration
    /// </summary>
    public class NetworkTransportStateTest
    {
        [Fact]
        public void Disconnected_ReturnsCorrectValue()
        {
            // Arrange
            NetworkTransportState expectedState = NetworkTransportState.Disconnected;

            // Act
            NetworkTransportState actualState = (NetworkTransportState)0;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void Connecting_ReturnsCorrectValue()
        {
            // Arrange
            NetworkTransportState expectedState = NetworkTransportState.Connecting;

            // Act
            NetworkTransportState actualState = (NetworkTransportState)1;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void Connected_ReturnsCorrectValue()
        {
            // Arrange
            NetworkTransportState expectedState = NetworkTransportState.Connected;

            // Act
            NetworkTransportState actualState = (NetworkTransportState)2;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void Disconnecting_ReturnsCorrectValue()
        {
            // Arrange
            NetworkTransportState expectedState = NetworkTransportState.Disconnecting;

            // Act
            NetworkTransportState actualState = (NetworkTransportState)3;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void AllValuesAreDefined()
        {
            // Arrange
            int expectedCount = 4;

            // Act
            Array values = Enum.GetValues(typeof(NetworkTransportState));
            int actualCount = values.Length;

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
