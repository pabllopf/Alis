// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonitorAdditionalRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     The monitor additional remaining coverage tests class
    /// </summary>
    public class MonitorAdditionalRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that none has zero handle
        /// </summary>
        [Fact]
        public void None_HasZeroHandle()
        {
            Assert.Equal(((IntPtr) IntPtr.Zero).ToString(), Monitor.None.ToString());
        }

        /// <summary>
        ///     Tests that equals with same monitor returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameMonitor_ReturnsTrue()
        {
            Monitor monitor = new Monitor();

            Assert.True(monitor.Equals(monitor));
        }

        /// <summary>
        ///     Tests that equals with boxed monitor returns true
        /// </summary>
        [Fact]
        public void Equals_WithBoxedMonitor_ReturnsTrue()
        {
            Monitor monitor = new Monitor();
            object boxed = monitor;

            Assert.True(monitor.Equals(boxed));
        }

        /// <summary>
        ///     Tests that equals with non monitor object returns false
        /// </summary>
        [Fact]
        public void Equals_WithNonMonitorObject_ReturnsFalse()
        {
            Monitor monitor = new Monitor();

            Assert.False(monitor.Equals("not a monitor"));
            Assert.False(monitor.Equals(null));
        }

        /// <summary>
        ///     Tests that get hash code matches handle hash code
        /// </summary>
        [Fact]
        public void GetHashCode_MatchesHandleHashCode()
        {
            Monitor monitor = new Monitor();

            Assert.Equal(IntPtr.Zero.GetHashCode(), monitor.GetHashCode());
        }

        /// <summary>
        ///     Tests that equality operator returns true for equal monitors
        /// </summary>
        [Fact]
        public void EqualityOperator_WithEqualMonitors_ReturnsTrue()
        {
            Monitor left = new Monitor();
            Monitor right = new Monitor();

            Assert.True(left == right);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different monitors
        /// </summary>
        [Fact]
        public void InequalityOperator_WithDifferentMonitors_ReturnsTrue()
        {
            Monitor left = new Monitor();
            Monitor right = new Monitor();

            Assert.False(left != right);
        }
    }
}
