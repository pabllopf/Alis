// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManagerCoverageFinalTests.cs
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

using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    /// The web assembly display manager coverage final tests class
    /// </summary>
    public class WebAssemblyDisplayManagerCoverageFinalTests
    {
        // =====================================================================
        // GetRenderingScale - Explicit per-quality tests to ensure
        // each switch arm (lines 298-303) is exercised independently.
        // =====================================================================

        /// <summary>
        /// Tests that get rendering scale very low returns half
        /// </summary>
        [Fact]
        public void GetRenderingScale_VeryLow_ReturnsHalf()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(DisplayQuality.VeryLow);
            Assert.Equal(0.5f, manager.GetRenderingScale());
        }

        /// <summary>
        /// Tests that get rendering scale low returns point 75
        /// </summary>
        [Fact]
        public void GetRenderingScale_Low_ReturnsPoint75()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(DisplayQuality.Low);
            Assert.Equal(0.75f, manager.GetRenderingScale());
        }

        /// <summary>
        /// Tests that get rendering scale medium returns point 875
        /// </summary>
        [Fact]
        public void GetRenderingScale_Medium_ReturnsPoint875()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(DisplayQuality.Medium);
            Assert.Equal(0.875f, manager.GetRenderingScale());
        }

        /// <summary>
        /// Tests that get rendering scale high returns one
        /// </summary>
        [Fact]
        public void GetRenderingScale_High_ReturnsOne()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(1.0f, manager.GetRenderingScale());
        }

        /// <summary>
        /// Tests that get rendering scale very high returns one point 25
        /// </summary>
        [Fact]
        public void GetRenderingScale_VeryHigh_ReturnsOnePoint25()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(DisplayQuality.VeryHigh);
            Assert.Equal(1.25f, manager.GetRenderingScale());
        }

        /// <summary>
        /// Tests that get rendering scale ultra returns one point 5
        /// </summary>
        [Fact]
        public void GetRenderingScale_Ultra_ReturnsOnePoint5()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(DisplayQuality.Ultra);
            Assert.Equal(1.5f, manager.GetRenderingScale());
        }

        // =====================================================================
        // SetResolution - Try-catch coverage documentation
        // Lines 204-206 (catch { return false; }) are BLOCKED_BY_PRODUCTION_CODE.
        // EmscriptenWeb.SetCanvasSize swallows all exceptions so
        // WebAssemblyPlatform.SetSize never throws. No test can reach the catch
        // block without modifying production code.
        // =====================================================================

        // =====================================================================
        // EnterFullscreen / ExitFullscreen success paths
        // Lines 231-234, 245-248 are BLOCKED_BY_PRODUCTION_CODE.
        // EmscriptenWeb.RequestFullscreen/ExitFullscreen call native JS which
        // throws on non-browser; the catch in EmscriptenWeb returns false.
        // The success body lines can never be reached in a test environment.
        // =====================================================================

        // =====================================================================
        // SaveScreenshot catch block
        // Lines 342-344 are BLOCKED_BY_PRODUCTION_CODE.
        // The try-body only contains "return true;" which cannot throw.
        // =====================================================================
    }
}
