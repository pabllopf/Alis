// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkManagerStateTest.cs
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
    ///     Tests for NetworkManagerState enumeration
    /// </summary>
    public class NetworkManagerStateTest
    {
        /// <summary>
        /// Tests that uninitialized returns correct value
        /// </summary>
        [Fact]
        public void Uninitialized_ReturnsCorrectValue()
        {
            // Arrange
            NetworkManagerState expectedState = NetworkManagerState.Uninitialized;

            // Act
            NetworkManagerState actualState = (NetworkManagerState)0;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that idle returns correct value
        /// </summary>
        [Fact]
        public void Idle_ReturnsCorrectValue()
        {
            // Arrange
            NetworkManagerState expectedState = NetworkManagerState.Idle;

            // Act
            NetworkManagerState actualState = (NetworkManagerState)1;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that connecting returns correct value
        /// </summary>
        [Fact]
        public void Connecting_ReturnsCorrectValue()
        {
            // Arrange
            NetworkManagerState expectedState = NetworkManagerState.Connecting;

            // Act
            NetworkManagerState actualState = (NetworkManagerState)2;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that connected returns correct value
        /// </summary>
        [Fact]
        public void Connected_ReturnsCorrectValue()
        {
            // Arrange
            NetworkManagerState expectedState = NetworkManagerState.Connected;

            // Act
            NetworkManagerState actualState = (NetworkManagerState)3;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that disconnecting returns correct value
        /// </summary>
        [Fact]
        public void Disconnecting_ReturnsCorrectValue()
        {
            // Arrange
            NetworkManagerState expectedState = NetworkManagerState.Disconnecting;

            // Act
            NetworkManagerState actualState = (NetworkManagerState)4;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that disconnected returns correct value
        /// </summary>
        [Fact]
        public void Disconnected_ReturnsCorrectValue()
        {
            // Arrange
            NetworkManagerState expectedState = NetworkManagerState.Disconnected;

            // Act
            NetworkManagerState actualState = (NetworkManagerState)5;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that error returns correct value
        /// </summary>
        [Fact]
        public void Error_ReturnsCorrectValue()
        {
            // Arrange
            NetworkManagerState expectedState = NetworkManagerState.Error;

            // Act
            NetworkManagerState actualState = (NetworkManagerState)6;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that all values are defined
        /// </summary>
        [Fact]
        public void AllValuesAreDefined()
        {
            // Arrange
            int expectedCount = 7;

            // Act
            Array values = Enum.GetValues(typeof(NetworkManagerState));
            int actualCount = values.Length;

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
