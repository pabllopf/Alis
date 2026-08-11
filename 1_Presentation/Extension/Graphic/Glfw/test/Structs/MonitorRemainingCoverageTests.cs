// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonitorRemainingCoverageTests.cs
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
using System.Drawing;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    /// The monitor remaining coverage tests class
    /// </summary>
    public class MonitorRemainingCoverageTests
    {
        /// <summary>
        /// Gets the bootstrapped primary monitor
        /// </summary>
        private static Monitor PrimaryMonitor
        {
            get
            {
                GlfwTestBootstrap.EnsureReady();
                return GlfwTestBootstrap.PrimaryMonitor;
            }
        }

        /// <summary>
        /// Tests that to string returns handle string
        /// </summary>
        [Fact]
        public void ToString_ReturnsHandleString()
        {
            Monitor monitor = Monitor.None;
            string result = monitor.ToString();
            Assert.Equal(IntPtr.Zero.ToString(), result);
        }

        /// <summary>
        /// Tests that work area returns a non empty rectangle
        /// </summary>
        [Fact]
        public void WorkArea_ReturnsNonEmptyRectangle()
        {
            Monitor monitor = PrimaryMonitor;

            Rectangle area = monitor.WorkArea;

            Assert.True(area.Width > 0);
            Assert.True(area.Height > 0);
        }

        /// <summary>
        /// Tests that content scale returns positive values
        /// </summary>
        [Fact]
        public void ContentScale_ReturnsPositiveValues()
        {
            Monitor monitor = PrimaryMonitor;

            PointF scale = monitor.ContentScale;

            Assert.True(scale.X > 0.0f);
            Assert.True(scale.Y > 0.0f);
        }

        /// <summary>
        /// Tests that user pointer round trips a value
        /// </summary>
        [Fact]
        public void UserPointer_RoundTripsValue()
        {
            Monitor monitor = PrimaryMonitor;
            IntPtr expected = new IntPtr(999);

            monitor.UserPointer = expected;
            IntPtr actual = monitor.UserPointer;

            Assert.Equal(expected, actual);
        }
    }
}
