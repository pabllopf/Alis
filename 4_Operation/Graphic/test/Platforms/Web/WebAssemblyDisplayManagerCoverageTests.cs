// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManagerCoverageTests.cs
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
    ///     The web assembly display manager coverage tests class
    /// </summary>
    public class WebAssemblyDisplayManagerCoverageTests
    {
        /// <summary>
        ///     Tests that constructor with null platform throws
        /// </summary>
        [Fact]
        public void Constructor_WithNullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyDisplayManager(null));
        }

        /// <summary>
        ///     Tests that constructor initializes from platform defaults
        /// </summary>
        [Fact]
        public void Constructor_InitializesFromPlatformDefaults()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(800, manager.GetWidth());
            Assert.Equal(600, manager.GetHeight());
            Assert.Equal(ScreenOrientation.Landscape, manager.GetOrientation());
        }

        /// <summary>
        ///     Tests that constructor detects portrait orientation
        /// </summary>
        [Fact]
        public void Constructor_DetectsPortraitOrientation()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnWindowResize(600, 800);

            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(ScreenOrientation.Portrait, manager.GetOrientation());
        }

        /// <summary>
        ///     Tests that constructor detects square orientation
        /// </summary>
        [Fact]
        public void Constructor_DetectsSquareOrientation()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            platform.OnWindowResize(500, 500);

            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            Assert.Equal(ScreenOrientation.Square, manager.GetOrientation());
        }

        /// <summary>
        ///     Tests that initialize supported modes populates standard modes
        /// </summary>
        [Fact]
        public void InitializeSupportedModes_PopulatesStandardModes()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            DisplayMode[] modes = manager.GetSupportedModes();

            Assert.Equal(9, modes.Length);
            Assert.Equal(640, modes[0].Width);
            Assert.Equal(480, modes[0].Height);
            Assert.True(modes[8].IsFullscreenOnly);
            Assert.Equal(1920, modes[8].Width);
            Assert.Equal(1080, modes[8].Height);
        }

        /// <summary>
        ///     Tests that get width returns current width
        /// </summary>
        [Fact]
        public void GetWidth_ReturnsCurrentWidth()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(800, manager.GetWidth());
        }

        /// <summary>
        ///     Tests that get height returns current height
        /// </summary>
        [Fact]
        public void GetHeight_ReturnsCurrentHeight()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(600, manager.GetHeight());
        }

        /// <summary>
        ///     Tests that get aspect ratio returns width divided by height
        /// </summary>
        [Fact]
        public void GetAspectRatio_ReturnsWidthDividedByHeight()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(800.0f / 600.0f, manager.GetAspectRatio(), 3);
        }

        /// <summary>
        ///     Tests that get orientation returns current orientation
        /// </summary>
        [Fact]
        public void GetOrientation_ReturnsCurrentOrientation()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(ScreenOrientation.Landscape, manager.GetOrientation());
        }

        /// <summary>
        ///     Tests that get device pixel ratio propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void GetDevicePixelRatio_PropagatesOnNonBrowser()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.GetDevicePixelRatio());
        }

        /// <summary>
        ///     Tests that set resolution routes the native failure to false on non browser
        /// </summary>
        [Fact]
        public void SetResolution_RoutesNativeFailureToFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayEventArgs captured = null;
            manager.OnDisplayResized += (sender, args) => captured = args;

            bool result = manager.SetResolution(1024, 768);

            Assert.False(result);
            Assert.Equal(800, manager.GetWidth());
            Assert.Equal(600, manager.GetHeight());
            Assert.Null(captured);
        }

        /// <summary>
        ///     Tests that set resolution with orientation change routes the native failure to false
        /// </summary>
        [Fact]
        public void SetResolution_WithOrientationChange_RoutesNativeFailureToFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            OrientationEventArgs captured = null;
            manager.OnOrientationChanged += (sender, args) => captured = args;

            bool result = manager.SetResolution(500, 500);

            Assert.False(result);
            Assert.Null(captured);
        }

        /// <summary>
        ///     Tests that toggle fullscreen propagates the native failure when not fullscreen
        /// </summary>
        [Fact]
        public void ToggleFullscreen_WhenNotFullscreen_Propagates()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.ThrowsAny<Exception>(() => manager.ToggleFullscreen());
        }

        /// <summary>
        ///     Tests that toggle fullscreen propagates the native failure when fullscreen
        /// </summary>
        [Fact]
        public void ToggleFullscreen_WhenFullscreen_Propagates()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            SetFullscreen(manager, true);

            Assert.ThrowsAny<Exception>(() => manager.ToggleFullscreen());
        }

        /// <summary>
        ///     Tests that enter fullscreen propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void EnterFullscreen_PropagatesOnNonBrowser()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.ThrowsAny<Exception>(() => manager.EnterFullscreen());
        }

        /// <summary>
        ///     Tests that exit fullscreen propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void ExitFullscreen_PropagatesOnNonBrowser()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.ThrowsAny<Exception>(() => manager.ExitFullscreen());
        }

        /// <summary>
        ///     Tests that is fullscreen propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void IsFullscreen_PropagatesOnNonBrowser()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.IsFullscreen());
        }

        /// <summary>
        ///     Tests that find display mode existing mode returns the mode
        /// </summary>
        [Fact]
        public void FindDisplayMode_ExistingMode_ReturnsTheMode()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            DisplayMode mode = manager.FindDisplayMode(1024, 768);

            Assert.NotNull(mode);
            Assert.Equal(1024, mode.Width);
            Assert.Equal(768, mode.Height);
            Assert.Equal(60, mode.RefreshRate);
        }

        /// <summary>
        ///     Tests that find display mode missing mode returns null
        /// </summary>
        [Fact]
        public void FindDisplayMode_MissingMode_ReturnsNull()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Null(manager.FindDisplayMode(9999, 9999));
        }

        /// <summary>
        ///     Tests that set display quality changes quality
        /// </summary>
        [Fact]
        public void SetDisplayQuality_ChangesQuality()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            manager.SetDisplayQuality(DisplayQuality.Ultra);

            Assert.Equal(DisplayQuality.Ultra, manager.GetDisplayQuality());
        }

        /// <summary>
        ///     Tests that get display quality defaults to high
        /// </summary>
        [Fact]
        public void GetDisplayQuality_DefaultsToHigh()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(DisplayQuality.High, manager.GetDisplayQuality());
        }

        /// <summary>
        ///     Tests that get rendering scale returns correct scale
        /// </summary>
        /// <param name="quality">The quality</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [InlineData(DisplayQuality.VeryLow, 0.5f)]
        [InlineData(DisplayQuality.Low, 0.75f)]
        [InlineData(DisplayQuality.Medium, 0.875f)]
        [InlineData(DisplayQuality.High, 1.0f)]
        [InlineData(DisplayQuality.VeryHigh, 1.25f)]
        [InlineData(DisplayQuality.Ultra, 1.5f)]
        public void GetRenderingScale_ReturnsCorrectScale(DisplayQuality quality, float expected)
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality(quality);

            Assert.Equal(expected, manager.GetRenderingScale());
        }

        /// <summary>
        ///     Tests that get rendering scale unknown quality returns one
        /// </summary>
        [Fact]
        public void GetRenderingScale_UnknownQuality_ReturnsOne()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality((DisplayQuality)99);

            Assert.Equal(1.0f, manager.GetRenderingScale());
        }

        /// <summary>
        ///     Tests that get system language propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void GetSystemLanguage_PropagatesOnNonBrowser()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.GetSystemLanguage());
        }

        /// <summary>
        ///     Tests that is online propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void IsOnline_PropagatesOnNonBrowser()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.IsOnline());
        }

        /// <summary>
        ///     Tests that get battery level propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void GetBatteryLevel_PropagatesOnNonBrowser()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.GetBatteryLevel());
        }

        /// <summary>
        ///     Tests that is charging propagates the native failure on non browser
        /// </summary>
        [Fact]
        public void IsCharging_PropagatesOnNonBrowser()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.IsCharging());
        }

        /// <summary>
        ///     Tests that save screenshot returns true
        /// </summary>
        [Fact]
        public void SaveScreenshot_ReturnsTrue()
        {
            Assert.True(WebAssemblyDisplayManager.SaveScreenshot("screenshot.png"));
        }

        /// <summary>
        ///     Tests that update with no changes fires no events then propagates the
        ///     native fullscreen failure
        /// </summary>
        [Fact]
        public void Update_WithNoChanges_DoesNotFireEventsAndPropagates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            int resizeCount = 0;
            int orientationCount = 0;
            manager.OnDisplayResized += (sender, args) => resizeCount++;
            manager.OnOrientationChanged += (sender, args) => orientationCount++;

            Assert.ThrowsAny<Exception>(() => manager.Update());

            Assert.Equal(0, resizeCount);
            Assert.Equal(0, orientationCount);
        }

        /// <summary>
        ///     Tests that update with size change fires resize event then propagates
        /// </summary>
        [Fact]
        public void Update_WithSizeChange_FiresResizeEventThenPropagates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayEventArgs captured = null;
            manager.OnDisplayResized += (sender, args) => captured = args;
            platform.OnWindowResize(1000, 800);

            Assert.ThrowsAny<Exception>(() => manager.Update());

            Assert.NotNull(captured);
            Assert.Equal(1000, captured.Width);
            Assert.Equal(800, captured.Height);
            Assert.Equal(1000, manager.GetWidth());
            Assert.Equal(800, manager.GetHeight());
        }

        /// <summary>
        ///     Tests that update with orientation change fires orientation event then propagates
        /// </summary>
        [Fact]
        public void Update_WithOrientationChange_FiresOrientationEventThenPropagates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            OrientationEventArgs captured = null;
            manager.OnOrientationChanged += (sender, args) => captured = args;
            platform.OnWindowResize(500, 500);

            Assert.ThrowsAny<Exception>(() => manager.Update());

            Assert.NotNull(captured);
            Assert.Equal(ScreenOrientation.Square, captured.Orientation);
        }

        /// <summary>
        ///     Tests that display mode properties round trip
        /// </summary>
        [Fact]
        public void DisplayMode_Properties_RoundTrip()
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
        ///     Tests that display mode to string returns expected format
        /// </summary>
        [Fact]
        public void DisplayMode_ToString_ReturnsExpectedFormat()
        {
            DisplayMode mode = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };

            Assert.Equal("1920x1080@60Hz", mode.ToString());
        }

        /// <summary>
        ///     Tests that display event args properties round trip
        /// </summary>
        [Fact]
        public void DisplayEventArgs_Properties_RoundTrip()
        {
            DisplayEventArgs args = new DisplayEventArgs { Width = 1024, Height = 768 };

            Assert.Equal(1024, args.Width);
            Assert.Equal(768, args.Height);
        }

        /// <summary>
        ///     Tests that orientation event args properties round trip
        /// </summary>
        [Fact]
        public void OrientationEventArgs_Properties_RoundTrip()
        {
            OrientationEventArgs args = new OrientationEventArgs { Orientation = ScreenOrientation.Portrait };

            Assert.Equal(ScreenOrientation.Portrait, args.Orientation);
        }

        /// <summary>
        ///     Tests that fullscreen event args properties round trip
        /// </summary>
        [Fact]
        public void FullscreenEventArgs_Properties_RoundTrip()
        {
            FullscreenEventArgs args = new FullscreenEventArgs { IsFullscreen = true };

            Assert.True(args.IsFullscreen);
        }

        /// <summary>
        ///     Sets the fullscreen using the specified manager
        /// </summary>
        /// <param name="manager">The manager</param>
        /// <param name="value">The value</param>
        private static void SetFullscreen(WebAssemblyDisplayManager manager, bool value)
        {
            FieldInfo field = typeof(WebAssemblyDisplayManager).GetField("_isFullscreen", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(manager, value);
        }
    }
}
