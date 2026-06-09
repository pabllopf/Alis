// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManagerTest.cs
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
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyDisplayManager, DisplayMode, DisplayEventArgs,
    ///     OrientationEventArgs, and FullscreenEventArgs.
    /// </summary>
    public class WebAssemblyDisplayManagerTest
    {
        // =====================================================================

        /// <summary>
        /// Tests that display mode default values are zero
        /// </summary>
        [Fact]
        public void DisplayMode_DefaultValues_AreZero()
        {
            DisplayMode mode = new DisplayMode();
            Assert.Equal(0, mode.Width);
            Assert.Equal(0, mode.Height);
            Assert.Equal(0, mode.RefreshRate);
            Assert.False(mode.IsFullscreenOnly);
        }

        /// <summary>
        /// Tests that display mode set properties works
        /// </summary>
        [Fact]
        public void DisplayMode_SetProperties_Works()
        {
            DisplayMode mode = new DisplayMode
            {
                Width = 1920,
                Height = 1080,
                RefreshRate = 144,
                IsFullscreenOnly = true
            };
            Assert.Equal(1920, mode.Width);
            Assert.Equal(1080, mode.Height);
            Assert.Equal(144, mode.RefreshRate);
            Assert.True(mode.IsFullscreenOnly);
        }

        /// <summary>
        /// Tests that display mode to string returns expected format
        /// </summary>
        [Fact]
        public void DisplayMode_ToString_ReturnsExpectedFormat()
        {
            DisplayMode mode = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };
            Assert.Equal("1920x1080@60Hz", mode.ToString());
        }

        /// <summary>
        /// Tests that display mode to string with zero refresh rate
        /// </summary>
        [Fact]
        public void DisplayMode_ToString_WithZeroRefreshRate()
        {
            DisplayMode mode = new DisplayMode { Width = 800, Height = 600, RefreshRate = 0 };
            Assert.Equal("800x600@0Hz", mode.ToString());
        }

        /// <summary>
        /// Tests that display mode to string with different refresh rates
        /// </summary>
        [Fact]
        public void DisplayMode_ToString_WithDifferentRefreshRates()
        {
            DisplayMode mode60 = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };
            DisplayMode mode144 = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 144 };
            Assert.Equal("1920x1080@60Hz", mode60.ToString());
            Assert.Equal("1920x1080@144Hz", mode144.ToString());
        }

        /// <summary>
        /// Tests that display mode multiple modes different instances
        /// </summary>
        [Fact]
        public void DisplayMode_MultipleModes_DifferentInstances()
        {
            DisplayMode mode1 = new DisplayMode { Width = 800, Height = 600 };
            DisplayMode mode2 = new DisplayMode { Width = 1920, Height = 1080 };
            Assert.NotSame(mode1, mode2);
            Assert.NotEqual(mode1, mode2);
        }

        // =====================================================================

        /// <summary>
        /// Tests that display event args can set properties
        /// </summary>
        [Fact]
        public void DisplayEventArgs_CanSetProperties()
        {
            DisplayEventArgs args = new DisplayEventArgs { Width = 1024, Height = 768 };
            Assert.Equal(1024, args.Width);
            Assert.Equal(768, args.Height);
        }

        // =====================================================================

        /// <summary>
        /// Tests that orientation event args can set properties
        /// </summary>
        [Fact]
        public void OrientationEventArgs_CanSetProperties()
        {
            OrientationEventArgs args = new OrientationEventArgs { Orientation = ScreenOrientation.Landscape };
            Assert.Equal(ScreenOrientation.Landscape, args.Orientation);
        }

        // =====================================================================

        
        /// <summary>
        /// Fullscreens the event args can set is fullscreen using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        [InlineData(true)]
        [InlineData(false)]
        public void FullscreenEventArgs_CanSetIsFullscreen(bool value)
        {
            FullscreenEventArgs args = new FullscreenEventArgs { IsFullscreen = value };
            Assert.Equal(value, args.IsFullscreen);
        }

        // =====================================================================

        /// <summary>
        /// Tests that display manager get width returns platform width
        /// </summary>
        [Fact]
        public void DisplayManager_GetWidth_ReturnsPlatformWidth()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(800, manager.GetWidth());
        }

        /// <summary>
        /// Tests that display manager get height returns platform height
        /// </summary>
        [Fact]
        public void DisplayManager_GetHeight_ReturnsPlatformHeight()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(600, manager.GetHeight());
        }

        /// <summary>
        /// Tests that display manager get aspect ratio correct calculation
        /// </summary>
        [Fact]
        public void DisplayManager_GetAspectRatio_CorrectCalculation()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            float aspect = manager.GetAspectRatio();
            Assert.Equal(800.0f / 600.0f, aspect, 3);
        }

        /// <summary>
        /// Tests that display manager get aspect ratio widescreen
        /// </summary>
        [Fact]
        public void DisplayManager_GetAspectRatio_Widescreen()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            float aspect = manager.GetAspectRatio();
            Assert.Equal(1920.0f / 1080.0f, aspect, 3);
        }

        /// <summary>
        /// Tests that display manager get orientation landscape
        /// </summary>
        [Fact]
        public void DisplayManager_GetOrientation_Landscape()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(ScreenOrientation.Landscape, manager.GetOrientation());
        }

        /// <summary>
        /// Tests that display manager get orientation portrait
        /// </summary>
        [Fact]
        public void DisplayManager_GetOrientation_Portrait()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 600, 800);
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(ScreenOrientation.Portrait, manager.GetOrientation());
        }

        /// <summary>
        /// Tests that display manager get orientation square
        /// </summary>
        [Fact]
        public void DisplayManager_GetOrientation_Square()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 500, 500);
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(ScreenOrientation.Square, manager.GetOrientation());
        }

        /// <summary>
        /// Tests that display manager get device pixel ratio returns default on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_GetDevicePixelRatio_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            float ratio = WebAssemblyDisplayManager.GetDevicePixelRatio();
            Assert.Equal(1.0f, ratio);
        }

        /// <summary>
        /// Tests that display manager constructor null platform throws
        /// </summary>
        [Fact]
        public void DisplayManager_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyDisplayManager(null));
        }
        // =====================================================================

        /// <summary>
        /// Tests that display manager toggle fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_ToggleFullscreen_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.False(manager.ToggleFullscreen());
        }

        /// <summary>
        /// Tests that display manager enter fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_EnterFullscreen_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.False(manager.EnterFullscreen());
        }

        /// <summary>
        /// Tests that display manager exit fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_ExitFullscreen_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.False(manager.ExitFullscreen());
        }

        /// <summary>
        /// Tests that display manager is fullscreen returns false on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_IsFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyDisplayManager.IsFullscreen());
        }

        // =====================================================================

        /// <summary>
        /// Tests that display manager get supported modes returns modes
        /// </summary>
        [Fact]
        public void DisplayManager_GetSupportedModes_ReturnsModes()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode[] modes = manager.GetSupportedModes();
            Assert.NotNull(modes);
            Assert.NotEmpty(modes);
            Assert.Equal(9, modes.Length);
        }

        /// <summary>
        /// Tests that display manager get supported modes contains standard resolutions
        /// </summary>
        [Fact]
        public void DisplayManager_GetSupportedModes_ContainsStandardResolutions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode[] modes = manager.GetSupportedModes();
            Assert.Contains(modes, m => (m.Width == 640) && (m.Height == 480));
            Assert.Contains(modes, m => (m.Width == 800) && (m.Height == 600));
            Assert.Contains(modes, m => (m.Width == 1920) && (m.Height == 1080));
        }

        /// <summary>
        /// Tests that display manager get supported modes contains fullscreen mode
        /// </summary>
        [Fact]
        public void DisplayManager_GetSupportedModes_ContainsFullscreenMode()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode[] modes = manager.GetSupportedModes();
            Assert.Contains(modes, m => m.IsFullscreenOnly);
        }

        /// <summary>
        /// Tests that display manager find display mode existing mode returns mode
        /// </summary>
        [Fact]
        public void DisplayManager_FindDisplayMode_ExistingMode_ReturnsMode()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode mode = manager.FindDisplayMode(1920, 1080);
            Assert.NotNull(mode);
            Assert.Equal(1920, mode.Width);
            Assert.Equal(1080, mode.Height);
        }

        /// <summary>
        /// Tests that display manager find display mode non existing returns null
        /// </summary>
        [Fact]
        public void DisplayManager_FindDisplayMode_NonExisting_ReturnsNull()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode mode = manager.FindDisplayMode(9999, 9999);
            Assert.Null(mode);
        }

        /// <summary>
        /// Tests that display manager find display mode 640x 480 returns mode
        /// </summary>
        [Fact]
        public void DisplayManager_FindDisplayMode_640x480_ReturnsMode()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode mode = manager.FindDisplayMode(640, 480);
            Assert.NotNull(mode);
            Assert.Equal(640, mode.Width);
            Assert.Equal(480, mode.Height);
        }

        // =====================================================================

        
        /// <summary>
        /// Displays the manager get rendering scale correct value using the specified quality
        /// </summary>
        /// <param name="quality">The quality</param>
        /// <param name="expectedScale">The expected scale</param>
        [InlineData(DisplayQuality.VeryLow, 0.5f)]
        [InlineData(DisplayQuality.Low, 0.75f)]
        [InlineData(DisplayQuality.Medium, 0.875f)]
        [InlineData(DisplayQuality.High, 1.0f)]
        [InlineData(DisplayQuality.VeryHigh, 1.25f)]
        [InlineData(DisplayQuality.Ultra, 1.5f)]
        public void DisplayManager_GetRenderingScale_CorrectValue(DisplayQuality quality, float expectedScale)
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(quality);
            Assert.Equal(expectedScale, manager.GetRenderingScale());
        }

        /// <summary>
        /// Tests that display manager get display quality default is high
        /// </summary>
        [Fact]
        public void DisplayManager_GetDisplayQuality_DefaultIsHigh()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(DisplayQuality.High, manager.GetDisplayQuality());
        }

        /// <summary>
        /// Tests that display manager set display quality changes quality
        /// </summary>
        [Fact]
        public void DisplayManager_SetDisplayQuality_ChangesQuality()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(DisplayQuality.Ultra);
            Assert.Equal(DisplayQuality.Ultra, manager.GetDisplayQuality());
        }

        // =====================================================================

        /// <summary>
        /// Tests that display manager get system language returns default on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_GetSystemLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = WebAssemblyDisplayManager.GetSystemLanguage();
            Assert.Equal("en", lang);
        }

        /// <summary>
        /// Tests that display manager is online returns false on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_IsOnline_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyDisplayManager.IsOnline());
        }

        /// <summary>
        /// Tests that display manager get battery level returns default on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_GetBatteryLevel_ReturnsDefaultOnNonBrowser()
        {
            float level = WebAssemblyDisplayManager.GetBatteryLevel();
            Assert.Equal(-1.0f, level);
        }

        /// <summary>
        /// Tests that display manager is charging returns false on non browser
        /// </summary>
        [Fact]
        public void DisplayManager_IsCharging_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyDisplayManager.IsCharging());
        }

        /// <summary>
        /// Tests that display manager get refresh rate returns 60
        /// </summary>
        [Fact]
        public void DisplayManager_GetRefreshRate_Returns60()
        {
            Assert.Equal(60, WebAssemblyDisplayManager.RefreshRate);
        }

        /// <summary>
        /// Tests that display manager save screenshot returns true
        /// </summary>
        [Fact]
        public void DisplayManager_SaveScreenshot_ReturnsTrue()
        {
            bool result = WebAssemblyDisplayManager.SaveScreenshot("screenshot.png");
            Assert.True(result);
        }

        /// <summary>
        /// Invokes the private using the specified instance
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="methodName">The method name</param>
        /// <param name="arguments">The arguments</param>
        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
