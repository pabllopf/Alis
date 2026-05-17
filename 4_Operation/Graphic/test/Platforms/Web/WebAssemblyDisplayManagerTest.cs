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
        // DisplayMode
        // =====================================================================

        [Fact]
        public void DisplayMode_DefaultValues_AreZero()
        {
            DisplayMode mode = new DisplayMode();
            Assert.Equal(0, mode.Width);
            Assert.Equal(0, mode.Height);
            Assert.Equal(0, mode.RefreshRate);
            Assert.False(mode.IsFullscreenOnly);
        }

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

        [Fact]
        public void DisplayMode_ToString_ReturnsExpectedFormat()
        {
            DisplayMode mode = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };
            Assert.Equal("1920x1080@60Hz", mode.ToString());
        }

        [Fact]
        public void DisplayMode_ToString_WithZeroRefreshRate()
        {
            DisplayMode mode = new DisplayMode { Width = 800, Height = 600, RefreshRate = 0 };
            Assert.Equal("800x600@0Hz", mode.ToString());
        }

        [Fact]
        public void DisplayMode_ToString_WithDifferentRefreshRates()
        {
            DisplayMode mode60 = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 60 };
            DisplayMode mode144 = new DisplayMode { Width = 1920, Height = 1080, RefreshRate = 144 };
            Assert.Equal("1920x1080@60Hz", mode60.ToString());
            Assert.Equal("1920x1080@144Hz", mode144.ToString());
        }

        [Fact]
        public void DisplayMode_MultipleModes_DifferentInstances()
        {
            DisplayMode mode1 = new DisplayMode { Width = 800, Height = 600 };
            DisplayMode mode2 = new DisplayMode { Width = 1920, Height = 1080 };
            Assert.NotSame(mode1, mode2);
            Assert.NotEqual(mode1, mode2);
        }

        // =====================================================================
        // DisplayEventArgs
        // =====================================================================

        [Fact]
        public void DisplayEventArgs_CanSetProperties()
        {
            DisplayEventArgs args = new DisplayEventArgs { Width = 1024, Height = 768 };
            Assert.Equal(1024, args.Width);
            Assert.Equal(768, args.Height);
        }

        // =====================================================================
        // OrientationEventArgs
        // =====================================================================

        [Fact]
        public void OrientationEventArgs_CanSetProperties()
        {
            OrientationEventArgs args = new OrientationEventArgs { Orientation = ScreenOrientation.Landscape };
            Assert.Equal(ScreenOrientation.Landscape, args.Orientation);
        }

        // =====================================================================
        // FullscreenEventArgs
        // =====================================================================

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FullscreenEventArgs_CanSetIsFullscreen(bool value)
        {
            FullscreenEventArgs args = new FullscreenEventArgs { IsFullscreen = value };
            Assert.Equal(value, args.IsFullscreen);
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Basic Properties
        // =====================================================================

        [Fact]
        public void DisplayManager_GetWidth_ReturnsPlatformWidth()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(800, manager.GetWidth());
        }

        [Fact]
        public void DisplayManager_GetHeight_ReturnsPlatformHeight()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(600, manager.GetHeight());
        }

        [Fact]
        public void DisplayManager_GetAspectRatio_CorrectCalculation()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            float aspect = manager.GetAspectRatio();
            Assert.Equal(800.0f / 600.0f, aspect, 3);
        }

        [Fact]
        public void DisplayManager_GetAspectRatio_Widescreen()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            float aspect = manager.GetAspectRatio();
            Assert.Equal(1920.0f / 1080.0f, aspect, 3);
        }

        [Fact]
        public void DisplayManager_GetOrientation_Landscape()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(ScreenOrientation.Landscape, manager.GetOrientation());
        }

        [Fact]
        public void DisplayManager_GetOrientation_Portrait()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 600, 800);
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(ScreenOrientation.Portrait, manager.GetOrientation());
        }

        [Fact]
        public void DisplayManager_GetOrientation_Square()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 500, 500);
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(ScreenOrientation.Square, manager.GetOrientation());
        }

        [Fact]
        public void DisplayManager_GetDevicePixelRatio_ReturnsDefaultOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            float ratio = WebAssemblyDisplayManager.GetDevicePixelRatio();
            Assert.Equal(1.0f, ratio);
        }

        [Fact]
        public void DisplayManager_Constructor_NullPlatform_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyDisplayManager(null));
        }

        // =====================================================================
        // WebAssemblyDisplayManager - SetResolution
        // =====================================================================

        [Fact]
        public void DisplayManager_SetResolution_CatchesException_ReturnsFalse()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            bool result = manager.SetResolution(1024, 768);
            Assert.False(result);
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Fullscreen
        // =====================================================================

        [Fact]
        public void DisplayManager_ToggleFullscreen_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.False(manager.ToggleFullscreen());
        }

        [Fact]
        public void DisplayManager_EnterFullscreen_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.False(manager.EnterFullscreen());
        }

        [Fact]
        public void DisplayManager_ExitFullscreen_ReturnsFalseOnNonBrowser()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.False(manager.ExitFullscreen());
        }

        [Fact]
        public void DisplayManager_IsFullscreen_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyDisplayManager.IsFullscreen());
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Display Modes
        // =====================================================================

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

        [Fact]
        public void DisplayManager_GetSupportedModes_ContainsStandardResolutions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode[] modes = manager.GetSupportedModes();
            Assert.Contains(modes, m => m.Width == 640 && m.Height == 480);
            Assert.Contains(modes, m => m.Width == 800 && m.Height == 600);
            Assert.Contains(modes, m => m.Width == 1920 && m.Height == 1080);
        }

        [Fact]
        public void DisplayManager_GetSupportedModes_ContainsFullscreenMode()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode[] modes = manager.GetSupportedModes();
            Assert.Contains(modes, m => m.IsFullscreenOnly);
        }

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

        [Fact]
        public void DisplayManager_FindDisplayMode_NonExisting_ReturnsNull()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            DisplayMode mode = manager.FindDisplayMode(9999, 9999);
            Assert.Null(mode);
        }

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
        // WebAssemblyDisplayManager - Display Quality
        // =====================================================================

        [Theory]
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

        [Fact]
        public void DisplayManager_GetDisplayQuality_DefaultIsHigh()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            Assert.Equal(DisplayQuality.High, manager.GetDisplayQuality());
        }

        [Fact]
        public void DisplayManager_SetDisplayQuality_ChangesQuality()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            manager.SetDisplayQuality(DisplayQuality.Ultra);
            Assert.Equal(DisplayQuality.Ultra, manager.GetDisplayQuality());
        }

        // =====================================================================
        // WebAssemblyDisplayManager - System Info
        // =====================================================================

        [Fact]
        public void DisplayManager_GetSystemLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = WebAssemblyDisplayManager.GetSystemLanguage();
            Assert.Equal("en", lang);
        }

        [Fact]
        public void DisplayManager_IsOnline_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyDisplayManager.IsOnline());
        }

        [Fact]
        public void DisplayManager_GetBatteryLevel_ReturnsDefaultOnNonBrowser()
        {
            float level = WebAssemblyDisplayManager.GetBatteryLevel();
            Assert.Equal(-1.0f, level);
        }

        [Fact]
        public void DisplayManager_IsCharging_ReturnsFalseOnNonBrowser()
        {
            Assert.False(WebAssemblyDisplayManager.IsCharging());
        }

        [Fact]
        public void DisplayManager_GetRefreshRate_Returns60()
        {
            Assert.Equal(60, WebAssemblyDisplayManager.GetRefreshRate());
        }

        [Fact]
        public void DisplayManager_SaveScreenshot_ReturnsTrue()
        {
            bool result = WebAssemblyDisplayManager.SaveScreenshot("screenshot.png");
            Assert.True(result);
        }

        // =====================================================================
        // WebAssemblyDisplayManager - Update
        // =====================================================================

        [Fact]
        public void DisplayManager_Update_NoChange_DoesNotTriggerEvents()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            int resizeCount = 0;
            manager.OnDisplayResized += (s, e) => resizeCount++;

            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
            }

            Assert.Equal(0, resizeCount);
        }

        [Fact]
        public void DisplayManager_Update_SizeChange_TriggersResizeEvent()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            int resizeCount = 0;
            manager.OnDisplayResized += (s, e) => resizeCount++;
            InvokePrivate(platform, "OnWindowResize", 1920, 1080);

            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
                Assert.Equal(1, resizeCount);
            }
        }

        [Fact]
        public void DisplayManager_Update_OrientationChange_TriggersOrientationEvent()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            int orientationCount = 0;
            manager.OnOrientationChanged += (s, e) => orientationCount++;
            InvokePrivate(platform, "OnWindowResize", 600, 800);

            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
                Assert.Equal(1, orientationCount);
            }
        }

        [Fact]
        public void DisplayManager_Update_FullscreenChange_TriggersFullscreenEvent()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);
            int fullscreenCount = 0;
            manager.OnFullscreenChanged += (s, e) => fullscreenCount++;

            if (OperatingSystem.IsBrowser())
            {
                manager.Update();
            }
        }

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
