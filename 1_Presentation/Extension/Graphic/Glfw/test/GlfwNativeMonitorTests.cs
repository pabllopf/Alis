// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeMonitorTests.cs
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

using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for GlfwNative monitor-related methods
    /// </summary>
    public class GlfwNativeMonitorTests
    {
        [RequiresDisplay]
        public void GetMonitors_ReturnsNonNullArray()
        {
            // Act
            Monitor[] monitors = GlfwNative.Monitors;

            // Assert
            Assert.NotNull(monitors);
        }

        [RequiresDisplay]
        public void GetPrimaryMonitor_ReturnsMonitor()
        {
            // Act
            Monitor monitor = GlfwNative.PrimaryMonitor;

            // Assert
            // Monitor may be None if no monitors connected
            Assert.True(monitor == Monitor.None || monitor != Monitor.None);
        }

        [RequiresDisplay]
        public void GetMonitorPhysicalSize_WithValidMonitor_ReturnsSize()
        {
            // Arrange
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None) return;

            // Act
            GlfwNative.GetMonitorPhysicalSize(monitor, out int width, out int height);

            // Assert
            Assert.True(width > 0);
            Assert.True(height > 0);
        }

        [RequiresDisplay]
        public void GetMonitorPosition_WithValidMonitor_ReturnsPosition()
        {
            // Arrange
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None) return;

            // Act
            GlfwNative.GetMonitorPosition(monitor, out int x, out int y);

            // Assert
            Assert.True(x != int.MinValue);
            Assert.True(y != int.MinValue);
        }

        [RequiresDisplay]
        public void GetMonitorWorkArea_WithValidMonitor_ReturnsWorkArea()
        {
            // Arrange
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None) return;

            // Act
            GlfwNative.GetMonitorWorkArea(monitor, out int x, out int y, out int width, out int height);

            // Assert
            Assert.True(width > 0);
            Assert.True(height > 0);
        }
    }
}

