// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManagerRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for WebAssemblyDisplayManager
    ///     covering SetResolution, Update, ToggleFullscreen, and GetRenderingScale default.
    /// </summary>
    public class WebAssemblyDisplayManagerRemainingCoverageTests
    {
        // =====================================================================
        // SetResolution Tests
        // =====================================================================

        [Fact]
        public void SetResolution_ReturnsTrueAndUpdatesDimensions()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            bool result = manager.SetResolution(1280, 720);

            Assert.True(result);
            Assert.Equal(1280, manager.GetWidth());
            Assert.Equal(720, manager.GetHeight());
        }

        [Fact]
        public void SetResolution_FiresDisplayResizedEvent()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            int firedWidth = 0;
            int firedHeight = 0;
            manager.OnDisplayResized += (sender, args) =>
            {
                firedWidth = args.Width;
                firedHeight = args.Height;
            };

            manager.SetResolution(1280, 720);

            Assert.Equal(1280, firedWidth);
            Assert.Equal(720, firedHeight);
        }

        [Fact]
        public void SetResolution_FiresOrientationChangedWhenOrientationChanges()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            ScreenOrientation? firedOrientation = null;
            manager.OnOrientationChanged += (sender, args) =>
            {
                firedOrientation = args.Orientation;
            };

            manager.SetResolution(600, 800);

            Assert.Equal(ScreenOrientation.Portrait, firedOrientation);
        }

        [Fact]
        public void SetResolution_DoesNotFireOrientationChangedWhenOrientationUnchanged()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            bool eventFired = false;
            manager.OnOrientationChanged += (sender, args) =>
            {
                eventFired = true;
            };

            manager.SetResolution(1280, 720);

            Assert.False(eventFired);
        }

        [Fact]
        public void SetResolution_UpdatesOrientation()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            manager.SetResolution(600, 800);

            Assert.Equal(ScreenOrientation.Portrait, manager.GetOrientation());
        }

        [Fact]
        public void SetResolution_SameDimensions_StillFiresDisplayResized()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            int fireCount = 0;
            manager.OnDisplayResized += (sender, args) => fireCount++;

            manager.SetResolution(800, 600);

            Assert.Equal(1, fireCount);
        }

        [Fact]
        public void SetResolution_FromLandscapeToSquare_FiresOrientationChanged()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            ScreenOrientation? firedOrientation = null;
            manager.OnOrientationChanged += (sender, args) =>
            {
                firedOrientation = args.Orientation;
            };

            manager.SetResolution(500, 500);

            Assert.Equal(ScreenOrientation.Square, firedOrientation);
        }

        // =====================================================================
        // Update Tests
        // =====================================================================

        [Fact]
        public void Update_DetectsDimensionChange()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnWindowResize", 1024, 768);
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            InvokePrivate(platform, "OnWindowResize", 1280, 720);

            manager.Update();

            Assert.Equal(1280, manager.GetWidth());
            Assert.Equal(720, manager.GetHeight());
        }

        [Fact]
        public void Update_FiresDisplayResizedWhenDimensionsChange()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            int firedWidth = 0;
            int firedHeight = 0;
            manager.OnDisplayResized += (sender, args) =>
            {
                firedWidth = args.Width;
                firedHeight = args.Height;
            };

            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            manager.Update();

            Assert.Equal(1920, firedWidth);
            Assert.Equal(1080, firedHeight);
        }

        [Fact]
        public void Update_FiresOrientationChangedWhenOrientationChanges()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            ScreenOrientation? firedOrientation = null;
            manager.OnOrientationChanged += (sender, args) =>
            {
                firedOrientation = args.Orientation;
            };

            InvokePrivate(platform, "OnWindowResize", 600, 800);
            manager.Update();

            Assert.Equal(ScreenOrientation.Portrait, firedOrientation);
        }

        [Fact]
        public void Update_DoesNotFireEventsWhenNoChanges()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            bool displayResizedFired = false;
            bool orientationChangedFired = false;
            bool fullscreenChangedFired = false;

            manager.OnDisplayResized += (sender, args) => displayResizedFired = true;
            manager.OnOrientationChanged += (sender, args) => orientationChangedFired = true;
            manager.OnFullscreenChanged += (sender, args) => fullscreenChangedFired = true;

            manager.Update();

            Assert.False(displayResizedFired);
            Assert.False(orientationChangedFired);
            Assert.False(fullscreenChangedFired);
        }

        [Fact]
        public void Update_FiresDisplayResizedOnlyWhenDimensionsChange()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            int fireCount = 0;
            manager.OnDisplayResized += (sender, args) => fireCount++;

            manager.Update();
            Assert.Equal(0, fireCount);

            InvokePrivate(platform, "OnWindowResize", 1024, 768);
            manager.Update();
            Assert.Equal(1, fireCount);

            manager.Update();
            Assert.Equal(1, fireCount);

            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            manager.Update();
            Assert.Equal(2, fireCount);
        }

        [Fact]
        public void Update_DetectsFullscreenStateChangeWhenInternalStateDiffers()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            FieldInfo isFullscreenField = typeof(WebAssemblyDisplayManager)
                .GetField("_isFullscreen", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(isFullscreenField);
            isFullscreenField.SetValue(manager, true);

            bool eventFired = false;
            bool? eventIsFullscreen = null;
            manager.OnFullscreenChanged += (sender, args) =>
            {
                eventFired = true;
                eventIsFullscreen = args.IsFullscreen;
            };

            manager.Update();

            Assert.True(eventFired);
            Assert.False(eventIsFullscreen);
        }

        [Fact]
        public void Update_DoesNotFireFullscreenChangedWhenStateMatches()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            bool eventFired = false;
            manager.OnFullscreenChanged += (sender, args) => eventFired = true;

            manager.Update();

            Assert.False(eventFired);
        }

        // =====================================================================
        // ToggleFullscreen Tests
        // =====================================================================

        [Fact]
        public void ToggleFullscreen_WhenAlreadyFullscreen_EntersExitFullscreenPath()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            FieldInfo isFullscreenField = typeof(WebAssemblyDisplayManager)
                .GetField("_isFullscreen", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(isFullscreenField);
            isFullscreenField.SetValue(manager, true);

            bool result = manager.ToggleFullscreen();

            Assert.False(result);
            bool isFullscreen = (bool)isFullscreenField.GetValue(manager);
            Assert.True(isFullscreen);
        }

        // =====================================================================
        // GetRenderingScale Tests
        // =====================================================================

        [Fact]
        public void GetRenderingScale_UnknownValue_ReturnsDefault()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            manager.SetDisplayQuality((DisplayQuality)99);

            float scale = manager.GetRenderingScale();

            Assert.Equal(1.0f, scale);
        }

        // =====================================================================
        // Event Subscription Edge Cases
        // =====================================================================

        [Fact]
        public void OnDisplayResized_SubscribeAndUnsubscribe_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            int fireCount = 0;
            EventHandler<DisplayEventArgs> handler = (sender, args) => fireCount++;

            manager.OnDisplayResized += handler;
            manager.SetResolution(100, 100);
            Assert.Equal(1, fireCount);

            manager.OnDisplayResized -= handler;
            manager.SetResolution(200, 200);
            Assert.Equal(1, fireCount);
        }

        [Fact]
        public void OnOrientationChanged_SubscribeAndUnsubscribe_Works()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            int fireCount = 0;
            EventHandler<OrientationEventArgs> handler = (sender, args) => fireCount++;

            manager.OnOrientationChanged += handler;
            manager.SetResolution(600, 800);
            Assert.Equal(1, fireCount);

            manager.OnOrientationChanged -= handler;
            manager.SetResolution(800, 600);
            Assert.Equal(1, fireCount);
        }

        [Fact]
        public void OnFullscreenChanged_Subscribe_DoesNotFireOnFailedEnter()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            bool eventFired = false;
            manager.OnFullscreenChanged += (sender, args) => eventFired = true;

            manager.EnterFullscreen();

            Assert.False(eventFired);
        }

        // =====================================================================
        // Aspect Ratio After State Changes
        // =====================================================================

        [Fact]
        public void GetAspectRatio_AfterSetResolution_Updates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            manager.SetResolution(1920, 1080);

            Assert.Equal(1920.0f / 1080.0f, manager.GetAspectRatio(), 3);
        }

        [Fact]
        public void GetAspectRatio_AfterUpdate_Updates()
        {
            WebAssemblyPlatform platform = new WebAssemblyPlatform();
            WebAssemblyDisplayManager manager = new WebAssemblyDisplayManager(platform);

            InvokePrivate(platform, "OnWindowResize", 1920, 1080);
            manager.Update();

            Assert.Equal(1920.0f / 1080.0f, manager.GetAspectRatio(), 3);
        }

        // =====================================================================

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
