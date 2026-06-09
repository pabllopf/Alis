// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SessionStateTest.cs
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
    ///     Tests for SessionState enumeration
    /// </summary>
    public class SessionStateTest
    {
        /// <summary>
        /// Tests that waiting returns correct value
        /// </summary>
        [Fact]
        public void Waiting_ReturnsCorrectValue()
        {
            // Arrange
            SessionState expectedState = SessionState.Waiting;

            // Act
            SessionState actualState = (SessionState)0;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that in progress returns correct value
        /// </summary>
        [Fact]
        public void InProgress_ReturnsCorrectValue()
        {
            // Arrange
            SessionState expectedState = SessionState.InProgress;

            // Act
            SessionState actualState = (SessionState)1;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that finished returns correct value
        /// </summary>
        [Fact]
        public void Finished_ReturnsCorrectValue()
        {
            // Arrange
            SessionState expectedState = SessionState.Finished;

            // Act
            SessionState actualState = (SessionState)2;

            // Assert
            Assert.Equal(expectedState, actualState);
        }

        /// <summary>
        /// Tests that closed returns correct value
        /// </summary>
        [Fact]
        public void Closed_ReturnsCorrectValue()
        {
            // Arrange
            SessionState expectedState = SessionState.Closed;

            // Act
            SessionState actualState = (SessionState)3;

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
            int expectedCount = 4;

            // Act
            Array values = Enum.GetValues(typeof(SessionState));
            int actualCount = values.Length;

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
