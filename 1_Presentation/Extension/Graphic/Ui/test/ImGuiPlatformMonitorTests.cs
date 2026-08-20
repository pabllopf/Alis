// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformMonitorTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform monitor tests class
    /// </summary>
    public class ImGuiPlatformMonitorTests
    {
        /// <summary>
        ///     Tests that main pos set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void MainPos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor();
            Vector2F expected = new Vector2F(100.0f, 200.0f);
            monitor.MainPos = expected;
            Assert.Equal(expected, monitor.MainPos);
        }

        /// <summary>
        ///     Tests that main size set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void MainSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor();
            Vector2F expected = new Vector2F(1920.0f, 1080.0f);
            monitor.MainSize = expected;
            Assert.Equal(expected, monitor.MainSize);
        }

        /// <summary>
        ///     Tests that work pos set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void WorkPos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor();
            Vector2F expected = new Vector2F(10.0f, 20.0f);
            monitor.WorkPos = expected;
            Assert.Equal(expected, monitor.WorkPos);
        }

        /// <summary>
        ///     Tests that work size set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void WorkSize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor();
            Vector2F expected = new Vector2F(1900.0f, 1040.0f);
            monitor.WorkSize = expected;
            Assert.Equal(expected, monitor.WorkSize);
        }

        /// <summary>
        ///     Tests that dpi scale set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void DpiScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor();
            const float expected = 1.5f;
            monitor.DpiScale = expected;
            Assert.Equal(expected, monitor.DpiScale);
        }

        /// <summary>
        ///     Tests that main pos default is zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void MainPos_Default_IsZero()
        {
            ImGuiPlatformMonitor monitor = default;
            Assert.Equal(default(Vector2F), monitor.MainPos);
        }

        /// <summary>
        ///     Tests that dpi scale default is zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DpiScale_Default_IsZero()
        {
            ImGuiPlatformMonitor monitor = default;
            Assert.Equal(0.0f, monitor.DpiScale, 5);
        }
    }
}
