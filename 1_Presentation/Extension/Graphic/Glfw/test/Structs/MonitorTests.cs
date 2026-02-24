// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonitorTests.cs
// 
//  Author:GitHub Copilot
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
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Tests for Monitor structure
    /// </summary>
    public class MonitorTests
    {
        /// <summary>
        /// Tests that monitor none is default value
        /// </summary>
        [Fact]
        public void Monitor_None_IsDefaultValue()
        {
            // Arrange & Act
            Monitor none = Monitor.None;

            // Assert
            Assert.Equal(default(Monitor), none);
        }

        /// <summary>
        /// Tests that monitor equals with same monitor returns true
        /// </summary>
        [Fact]
        public void Monitor_Equals_WithSameMonitor_ReturnsTrue()
        {
            // Arrange
            Monitor monitor1 = Monitor.None;
            Monitor monitor2 = Monitor.None;

            // Act
            bool result = monitor1.Equals(monitor2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that monitor equals with object returns correct result
        /// </summary>
        [Fact]
        public void Monitor_Equals_WithObject_ReturnsCorrectResult()
        {
            // Arrange
            Monitor monitor = Monitor.None;
            object obj = Monitor.None;

            // Act
            bool result = monitor.Equals(obj);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that monitor equals with non monitor object returns false
        /// </summary>
        [Fact]
        public void Monitor_Equals_WithNonMonitorObject_ReturnsFalse()
        {
            // Arrange
            Monitor monitor = Monitor.None;
            object obj = new object();

            // Act
            bool result = monitor.Equals(obj);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that monitor get hash code returns same for equal monitors
        /// </summary>
        [Fact]
        public void Monitor_GetHashCode_ReturnsSameForEqualMonitors()
        {
            // Arrange
            Monitor monitor1 = Monitor.None;
            Monitor monitor2 = Monitor.None;

            // Act
            int hash1 = monitor1.GetHashCode();
            int hash2 = monitor2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        /// Tests that monitor equality operator with same monitors returns true
        /// </summary>
        [Fact]
        public void Monitor_EqualityOperator_WithSameMonitors_ReturnsTrue()
        {
            // Arrange
            Monitor monitor1 = Monitor.None;
            Monitor monitor2 = Monitor.None;

            // Act
            bool result = monitor1 == monitor2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that monitor inequality operator with same monitors returns false
        /// </summary>
        [Fact]
        public void Monitor_InequalityOperator_WithSameMonitors_ReturnsFalse()
        {
            // Arrange
            Monitor monitor1 = Monitor.None;
            Monitor monitor2 = Monitor.None;

            // Act
            bool result = monitor1 != monitor2;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tests that monitor equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Monitor_Equals_WithIEquatableInterface_Works()
        {
            // Arrange
            Monitor monitor1 = Monitor.None;
            IEquatable<Monitor> monitor2 = Monitor.None;

            // Act
            bool result = monitor1.Equals(monitor2);

            // Assert
            Assert.True(result);
        }
    }
}

