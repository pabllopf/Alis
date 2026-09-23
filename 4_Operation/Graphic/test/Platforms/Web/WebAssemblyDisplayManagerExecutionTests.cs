// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManagerExecutionTests.cs
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
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Execution tests for WebAssemblyDisplayManager that run on desktop.
    ///     The constructor is reachable on desktop because WebAssemblyPlatform
    ///     initializes pure managed state and every EmscriptenWeb wrapper
    ///     swallows the DllNotFoundException and returns fallback values.
    /// </summary>
    public class WebAssemblyDisplayManagerExecutionTests
    {
        /// <summary>
        ///     Tests that the constructor throws an argument null exception
        ///     when the platform is null
        /// </summary>
        [Fact]
        public void Constructor_NullPlatform_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyDisplayManager(null));
        }

        /// <summary>
        ///     Tests that the constructor initializes the defaults from the platform
        /// </summary>
        [Fact]
        public void Constructor_InitializesDefaultsFromPlatform()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(800, manager.GetWidth());
            Assert.Equal(600, manager.GetHeight());
            Assert.Equal(ScreenOrientation.Landscape, manager.GetOrientation());
            Assert.Equal(DisplayQuality.High, manager.GetDisplayQuality());
        }

        /// <summary>
        ///     Tests that the constructor detects a portrait orientation from a resized platform
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
        ///     Tests that the constructor detects a square orientation from a resized platform
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
        ///     Tests that the constructor initializes the nine supported display modes
        /// </summary>
        [Fact]
        public void Constructor_InitializesSupportedDisplayModes()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            DisplayMode[] modes = manager.GetSupportedModes();

            Assert.Equal(9, modes.Length);
            Assert.Equal(640, modes[0].Width);
            Assert.Equal(480, modes[0].Height);
            Assert.Equal(60, modes[0].RefreshRate);
            Assert.False(modes[0].IsFullscreenOnly);
            Assert.Equal(1920, modes[8].Width);
            Assert.Equal(1080, modes[8].Height);
            Assert.True(modes[8].IsFullscreenOnly);
        }

        /// <summary>
        ///     Tests that the constructor adds a mode for every standard resolution
        /// </summary>
        [Fact]
        public void Constructor_AddsModeForEveryStandardResolution()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            DisplayMode[] modes = manager.GetSupportedModes();

            Assert.Equal(800, modes[1].Width);
            Assert.Equal(600, modes[1].Height);
            Assert.Equal(1024, modes[2].Width);
            Assert.Equal(768, modes[2].Height);
            Assert.Equal(1280, modes[3].Width);
            Assert.Equal(720, modes[3].Height);
            Assert.Equal(2560, modes[7].Width);
            Assert.Equal(1440, modes[7].Height);
        }

        /// <summary>
        ///     Tests that get width returns the initial platform width
        /// </summary>
        [Fact]
        public void GetWidth_ReturnsInitialPlatformWidth()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(800, manager.GetWidth());
        }

        /// <summary>
        ///     Tests that get height returns the initial platform height
        /// </summary>
        [Fact]
        public void GetHeight_ReturnsInitialPlatformHeight()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(600, manager.GetHeight());
        }

        /// <summary>
        ///     Tests that get aspect ratio returns the width divided by the height
        /// </summary>
        [Fact]
        public void GetAspectRatio_ReturnsWidthDividedByHeight()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            float aspect = manager.GetAspectRatio();

            Assert.Equal(800.0f / 600.0f, aspect, 3);
        }

        /// <summary>
        ///     Tests that get orientation returns the detected orientation
        /// </summary>
        [Fact]
        public void GetOrientation_ReturnsDetectedOrientation()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Equal(ScreenOrientation.Landscape, manager.GetOrientation());
        }

        /// <summary>
        ///     Tests that get device pixel ratio propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void GetDevicePixelRatio_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.GetDevicePixelRatio());
        }

        /// <summary>
        ///     Tests that is fullscreen propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void IsFullscreen_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.IsFullscreen());
        }

        /// <summary>
        ///     Tests that find display mode returns the matching mode
        /// </summary>
        [Fact]
        public void FindDisplayMode_MatchingDimensions_ReturnsMode()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            DisplayMode mode = manager.FindDisplayMode(1920, 1080);

            Assert.NotNull(mode);
            Assert.Equal(1920, mode.Width);
            Assert.Equal(1080, mode.Height);
            Assert.Equal(60, mode.RefreshRate);
        }

        /// <summary>
        ///     Tests that find display mode returns a null mode for unknown dimensions
        /// </summary>
        [Fact]
        public void FindDisplayMode_UnknownDimensions_ReturnsNull()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            DisplayMode mode = manager.FindDisplayMode(9999, 9999);

            Assert.Null(mode);
        }

        /// <summary>
        ///     Tests that find display mode returns a null mode for negative dimensions
        /// </summary>
        [Fact]
        public void FindDisplayMode_NegativeDimensions_ReturnsNull()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.Null(manager.FindDisplayMode(-1, -1));
        }

        /// <summary>
        ///     Tests that set display quality updates the stored quality
        /// </summary>
        [Fact]
        public void SetDisplayQuality_UpdatesQuality()
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
        ///     Tests that get rendering scale for very low quality returns half
        /// </summary>
        [Fact]
        public void GetRenderingScale_VeryLow_ReturnsHalf()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality(DisplayQuality.VeryLow);

            Assert.Equal(0.5f, manager.GetRenderingScale(), 5);
        }

        /// <summary>
        ///     Tests that get rendering scale for low quality returns point 75
        /// </summary>
        [Fact]
        public void GetRenderingScale_Low_ReturnsPoint75()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality(DisplayQuality.Low);

            Assert.Equal(0.75f, manager.GetRenderingScale(), 5);
        }

        /// <summary>
        ///     Tests that get rendering scale for medium quality returns point 875
        /// </summary>
        [Fact]
        public void GetRenderingScale_Medium_ReturnsPoint875()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality(DisplayQuality.Medium);

            Assert.Equal(0.875f, manager.GetRenderingScale(), 5);
        }

        /// <summary>
        ///     Tests that get rendering scale for high quality returns one
        /// </summary>
        [Fact]
        public void GetRenderingScale_High_ReturnsOne()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality(DisplayQuality.High);

            Assert.Equal(1.0f, manager.GetRenderingScale(), 5);
        }

        /// <summary>
        ///     Tests that get rendering scale for very high quality returns one point 25
        /// </summary>
        [Fact]
        public void GetRenderingScale_VeryHigh_ReturnsOnePoint25()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality(DisplayQuality.VeryHigh);

            Assert.Equal(1.25f, manager.GetRenderingScale(), 5);
        }

        /// <summary>
        ///     Tests that get rendering scale for ultra quality returns one point 5
        /// </summary>
        [Fact]
        public void GetRenderingScale_Ultra_ReturnsOnePoint5()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality(DisplayQuality.Ultra);

            Assert.Equal(1.5f, manager.GetRenderingScale(), 5);
        }

        /// <summary>
        ///     Tests that get rendering scale for an unknown quality returns one
        /// </summary>
        [Fact]
        public void GetRenderingScale_UnknownQuality_ReturnsOne()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            manager.SetDisplayQuality((DisplayQuality)99);

            Assert.Equal(1.0f, manager.GetRenderingScale(), 5);
        }

        /// <summary>
        ///     Tests that set resolution routes the native failure to false and keeps
        ///     the stored dimensions on desktop
        /// </summary>
        [Fact]
        public void SetResolution_RoutesNativeFailureToFalse()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            bool result = manager.SetResolution(1024, 768);

            Assert.False(result);
            Assert.Equal(800, manager.GetWidth());
            Assert.Equal(600, manager.GetHeight());
        }

        /// <summary>
        ///     Tests that set resolution routes the native failure to false and does
        ///     not fire the display resized event
        /// </summary>
        [Fact]
        public void SetResolution_DoesNotFireDisplayResizedEventOnNativeFailure()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayEventArgs captured = null;
            manager.OnDisplayResized += (sender, args) => captured = args;

            bool result = manager.SetResolution(1280, 720);

            Assert.False(result);
            Assert.Null(captured);
        }

        /// <summary>
        ///     Tests that set resolution routes the native failure to false and does
        ///     not fire the orientation changed event
        /// </summary>
        [Fact]
        public void SetResolution_DoesNotFireOrientationChangedEventOnNativeFailure()
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
        ///     Tests that set resolution without orientation change does not fire the
        ///     orientation changed event when the native call fails
        /// </summary>
        [Fact]
        public void SetResolution_DoesNotFireOrientationChangedEventWithoutOrientationChange()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            int orientationCount = 0;
            manager.OnOrientationChanged += (sender, args) => orientationCount++;

            bool result = manager.SetResolution(1024, 768);

            Assert.False(result);
            Assert.Equal(0, orientationCount);
        }

        /// <summary>
        ///     Tests that enter fullscreen propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void EnterFullscreen_PropagatesOnDesktop()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.ThrowsAny<Exception>(() => manager.EnterFullscreen());
        }

        /// <summary>
        ///     Tests that exit fullscreen propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void ExitFullscreen_PropagatesOnDesktop()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.ThrowsAny<Exception>(() => manager.ExitFullscreen());
        }

        /// <summary>
        ///     Tests that toggle fullscreen propagates the native failure when not fullscreen
        /// </summary>
        [Fact]
        public void ToggleFullscreen_NotFullscreen_Propagates()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());

            Assert.ThrowsAny<Exception>(() => manager.ToggleFullscreen());
        }

        /// <summary>
        ///     Tests that get system language propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void GetSystemLanguage_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.GetSystemLanguage());
        }

        /// <summary>
        ///     Tests that is online propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void IsOnline_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.IsOnline());
        }

        /// <summary>
        ///     Tests that get battery level propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void GetBatteryLevel_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.GetBatteryLevel());
        }

        /// <summary>
        ///     Tests that is charging propagates the native failure on desktop
        /// </summary>
        [Fact]
        public void IsCharging_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => WebAssemblyDisplayManager.IsCharging());
        }

        /// <summary>
        ///     Tests that the refresh rate constant equals sixty
        /// </summary>
        [Fact]
        public void RefreshRate_Constant_EqualsSixty()
        {
            Assert.Equal(60, WebAssemblyDisplayManager.RefreshRate);
        }

        /// <summary>
        ///     Tests that save screenshot returns true on desktop
        /// </summary>
        [Fact]
        public void SaveScreenshot_ReturnsTrue()
        {
            bool result = WebAssemblyDisplayManager.SaveScreenshot("screenshot.png");

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that update without changes fires no events then propagates the
        ///     native fullscreen failure
        /// </summary>
        [Fact]
        public void Update_NoChanges_FiresNoEventsThenPropagates()
        {
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(new WebAssemblyPlatform());
            int resizeCount = 0;
            int orientationCount = 0;
            int fullscreenCount = 0;
            manager.OnDisplayResized += (sender, args) => resizeCount++;
            manager.OnOrientationChanged += (sender, args) => orientationCount++;
            manager.OnFullscreenChanged += (sender, args) => fullscreenCount++;

            Assert.ThrowsAny<Exception>(() => manager.Update());

            Assert.Equal(0, resizeCount);
            Assert.Equal(0, orientationCount);
            Assert.Equal(0, fullscreenCount);
        }

        /// <summary>
        ///     Tests that update with a size change fires the display resized event
        ///     then propagates the native fullscreen failure
        /// </summary>
        [Fact]
        public void Update_SizeChange_FiresDisplayResizedEventThenPropagates()
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
        ///     Tests that update with a size change fires the orientation changed
        ///     event when the orientation changes then propagates
        /// </summary>
        [Fact]
        public void Update_SizeChange_FiresOrientationChangedEventThenPropagates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            OrientationEventArgs captured = null;
            manager.OnOrientationChanged += (sender, args) => captured = args;
            platform.OnWindowResize(500, 500);

            Assert.ThrowsAny<Exception>(() => manager.Update());

            Assert.NotNull(captured);
            Assert.Equal(ScreenOrientation.Square, captured.Orientation);
            Assert.Equal(ScreenOrientation.Square, manager.GetOrientation());
        }

        /// <summary>
        ///     Tests that display mode to string returns the expected format
        /// </summary>
        [Fact]
        public void DisplayMode_ToString_ReturnsExpectedFormat()
        {
            DisplayMode mode = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };

            Assert.Equal("1920x1080@60Hz", mode.ToString());
        }

        /// <summary>
        ///     Tests that display mode properties round trip
        /// </summary>
        [Fact]
        public void DisplayMode_Properties_RoundTrip()
        {
            DisplayMode mode = new DisplayMode
            {
                Width = 2560,
                Height = 1440,
                RefreshRate = 144,
                IsFullscreenOnly = true
            };

            Assert.Equal(2560, mode.Width);
            Assert.Equal(1440, mode.Height);
            Assert.Equal(144, mode.RefreshRate);
            Assert.True(mode.IsFullscreenOnly);
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
        ///     Tests that screen orientation enum exposes the expected values
        /// </summary>
        [Fact]
        public void ScreenOrientation_Enum_ExposesExpectedValues()
        {
            Assert.Equal(0, (int)ScreenOrientation.Portrait);
            Assert.Equal(1, (int)ScreenOrientation.Landscape);
            Assert.Equal(2, (int)ScreenOrientation.Square);
        }

        /// <summary>
        ///     Tests that display quality enum exposes the expected values
        /// </summary>
        [Fact]
        public void DisplayQuality_Enum_ExposesExpectedValues()
        {
            Assert.Equal(0, (int)DisplayQuality.VeryLow);
            Assert.Equal(1, (int)DisplayQuality.Low);
            Assert.Equal(2, (int)DisplayQuality.Medium);
            Assert.Equal(3, (int)DisplayQuality.High);
            Assert.Equal(4, (int)DisplayQuality.VeryHigh);
            Assert.Equal(5, (int)DisplayQuality.Ultra);
        }
    }
}
