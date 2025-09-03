// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformMonitorTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform monitor test class
    /// </summary>
    public class ImGuiPlatformMonitorTest
    {
        /// <summary>
        ///     Tests that main pos should be initialized correctly
        /// </summary>
        [Fact]
        public void MainPos_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {MainPos = new Vector2F(1, 2)};

            // Act
            Vector2F result = monitor.MainPos;

            // Assert
            Assert.Equal(new Vector2F(1, 2), result);
        }

        /// <summary>
        ///     Tests that main size should be initialized correctly
        /// </summary>
        [Fact]
        public void MainSize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {MainSize = new Vector2F(3, 4)};

            // Act
            Vector2F result = monitor.MainSize;

            // Assert
            Assert.Equal(new Vector2F(3, 4), result);
        }

        /// <summary>
        ///     Tests that work pos should be initialized correctly
        /// </summary>
        [Fact]
        public void WorkPos_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {WorkPos = new Vector2F(5, 6)};

            // Act
            Vector2F result = monitor.WorkPos;

            // Assert
            Assert.Equal(new Vector2F(5, 6), result);
        }

        /// <summary>
        ///     Tests that work size should be initialized correctly
        /// </summary>
        [Fact]
        public void WorkSize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {WorkSize = new Vector2F(7, 8)};

            // Act
            Vector2F result = monitor.WorkSize;

            // Assert
            Assert.Equal(new Vector2F(7, 8), result);
        }

        /// <summary>
        ///     Tests that dpi scale should be initialized correctly
        /// </summary>
        [Fact]
        public void DpiScale_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {DpiScale = 1.5f};

            // Act
            float result = monitor.DpiScale;

            // Assert
            Assert.Equal(1.5f, result);
        }
    }
}