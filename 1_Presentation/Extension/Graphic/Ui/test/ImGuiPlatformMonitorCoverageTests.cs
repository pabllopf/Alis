// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformMonitorCoverageTests.cs
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
    ///     The im gui platform monitor coverage tests class
    /// </summary>
    public class ImGuiPlatformMonitorCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have zero values
        /// </summary>
        [Fact]
        public void ImGuiPlatformMonitor_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiPlatformMonitor monitor = default(ImGuiPlatformMonitor);

            Assert.Equal(0f, monitor.MainPos.X, 5);
            Assert.Equal(0f, monitor.MainPos.Y, 5);
            Assert.Equal(0f, monitor.MainSize.X, 5);
            Assert.Equal(0f, monitor.MainSize.Y, 5);
            Assert.Equal(0f, monitor.WorkPos.X, 5);
            Assert.Equal(0f, monitor.WorkPos.Y, 5);
            Assert.Equal(0f, monitor.WorkSize.X, 5);
            Assert.Equal(0f, monitor.WorkSize.Y, 5);
            Assert.Equal(0f, monitor.DpiScale, 5);
        }

        /// <summary>
        ///     Tests that vector properties round trip correctly
        /// </summary>
        [Fact]
        public void ImGuiPlatformMonitor_VectorProperties_RoundTripCorrectly()
        {
            ImGuiPlatformMonitor monitor = default(ImGuiPlatformMonitor);

            monitor.MainPos = new Vector2F(1f, 2f);
            monitor.MainSize = new Vector2F(3f, 4f);
            monitor.WorkPos = new Vector2F(5f, 6f);
            monitor.WorkSize = new Vector2F(7f, 8f);
            monitor.DpiScale = 9f;

            Assert.Equal(1f, monitor.MainPos.X, 5);
            Assert.Equal(2f, monitor.MainPos.Y, 5);
            Assert.Equal(3f, monitor.MainSize.X, 5);
            Assert.Equal(4f, monitor.MainSize.Y, 5);
            Assert.Equal(5f, monitor.WorkPos.X, 5);
            Assert.Equal(6f, monitor.WorkPos.Y, 5);
            Assert.Equal(7f, monitor.WorkSize.X, 5);
            Assert.Equal(8f, monitor.WorkSize.Y, 5);
            Assert.Equal(9f, monitor.DpiScale, 5);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiPlatformMonitor_IsValueType_CopyIsIndependent()
        {
            ImGuiPlatformMonitor original = new ImGuiPlatformMonitor { DpiScale = 2f };
            ImGuiPlatformMonitor copy = original;

            copy.DpiScale = 3f;

            Assert.Equal(2f, original.DpiScale, 5);
            Assert.Equal(3f, copy.DpiScale, 5);
        }
    }
}