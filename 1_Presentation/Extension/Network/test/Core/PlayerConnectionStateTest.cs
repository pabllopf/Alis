// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerConnectionStateTest.cs
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
    ///     Tests for PlayerConnectionState enumeration
    /// </summary>
    public class PlayerConnectionStateTest
    {
        [Fact]
        public void Connected_ReturnsCorrectValue()
        {
            // Arrange
            PlayerConnectionState expectedState = PlayerConnectionState.Connected;

            // Act
            PlayerConnectionState actualState = (PlayerConnectionState)0;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void Idle_ReturnsCorrectValue()
        {
            // Arrange
            PlayerConnectionState expectedState = PlayerConnectionState.Idle;

            // Act
            PlayerConnectionState actualState = (PlayerConnectionState)1;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void Disconnected_ReturnsCorrectValue()
        {
            // Arrange
            PlayerConnectionState expectedState = PlayerConnectionState.Disconnected;

            // Act
            PlayerConnectionState actualState = (PlayerConnectionState)2;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void Timeout_ReturnsCorrectValue()
        {
            // Arrange
            PlayerConnectionState expectedState = PlayerConnectionState.Timeout;

            // Act
            PlayerConnectionState actualState = (PlayerConnectionState)3;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void AllValuesAreDefined()
        {
            // Arrange
            int expectedCount = 4;

            // Act
            Array values = Enum.GetValues(typeof(PlayerConnectionState));
            int actualCount = values.Length;

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
