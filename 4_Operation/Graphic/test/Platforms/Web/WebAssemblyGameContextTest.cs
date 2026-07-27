// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameContextTest.cs
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
    ///     Tests for WebAssemblyGameContext covering constructors, static methods, Create factory, and instance methods.
    /// </summary>
    public class WebAssemblyGameContextTest
    {
        [Fact]
        public void Constructor_NullConfig_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyGameContext(null));
        }

        [Fact]
        public void Constructor_WithConfig_ThrowsOnNonWebAssembly()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new WebAssemblyGameContext(new WebAssemblyConfiguration()));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        [Fact]
        public void DefaultConstructor_ThrowsOnNonWebAssembly()
        {
            Assert.Throws<InvalidOperationException>(() => new WebAssemblyGameContext());
        }

        [Fact]
        public void Create_WithWidthHeightTitle_ThrowsOnNonWebAssembly()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => WebAssemblyGameContext.Create(800, 600, "Test"));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        [Fact]
        public void Create_WithNullConfigure_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => WebAssemblyGameContext.Create((Action<WebAssemblyConfigurationBuilder>)null));
        }

        [Fact]
        public void Create_WithConfigure_ThrowsOnNonWebAssembly()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameContext.Create(b => b.WithTitle("Test")));
        }

        [Fact]
        public void ConsoleLog_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleLog("test log");
            WebAssemblyGameContext.ConsoleLog(null);
            WebAssemblyGameContext.ConsoleLog(string.Empty);
        }

        [Fact]
        public void ConsoleWarn_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleWarn("test warn");
            WebAssemblyGameContext.ConsoleWarn(null);
        }

        [Fact]
        public void ConsoleError_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleError("test error");
            WebAssemblyGameContext.ConsoleError(null);
        }

        [Fact]
        public void ShowAlert_DoesNotThrow()
        {
            WebAssemblyGameContext.ShowAlert("test alert");
            WebAssemblyGameContext.ShowAlert(null);
        }

        [Fact]
        public void ShowConfirm_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
            Assert.False(WebAssemblyGameContext.ShowConfirm(null));
        }

        [Fact]
        public void IsFullscreen_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.IsFullscreen());
        }

        [Fact]
        public void LockPointer_UnlockPointer_IsPointerLocked_ReturnFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.LockPointer());
            Assert.False(WebAssemblyGameContext.UnlockPointer());
            Assert.False(WebAssemblyGameContext.IsPointerLocked());
        }

        [Fact]
        public void GetDeviceLanguage_ReturnsNonNull()
        {
            string lang = WebAssemblyGameContext.GetDeviceLanguage();
            Assert.NotNull(lang);
        }

        [Fact]
        public void GetBatteryLevel_ReturnsDefault()
        {
            float level = WebAssemblyGameContext.GetBatteryLevel();
            Assert.True(level >= -1.0f);
        }

        [Fact]
        public void IsCharging_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsCharging());
        }

        [Fact]
        public void IsOnline_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsOnline());
        }

        [Fact]
        public void GetRefreshRate_ReturnsSixty()
        {
            Assert.Equal(60, WebAssemblyGameContext.GetRefreshRate());
        }

        [Fact]
        public void VibrateGamepad_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
            Assert.False(WebAssemblyGameContext.VibrateGamepad(1, 0.5f, 0.5f, 0.2f));
        }

        [Fact]
        public void ConsoleLog_Warn_Error_StaticMethods_DoNotThrow_WithVariousInputs()
        {
            WebAssemblyGameContext.ConsoleLog(string.Empty);
            WebAssemblyGameContext.ConsoleWarn(string.Empty);
            WebAssemblyGameContext.ConsoleError(string.Empty);
            WebAssemblyGameContext.ConsoleLog("message with spaces and special chars: !@#$%");
            WebAssemblyGameContext.ConsoleWarn("message with spaces and special chars: !@#$%");
            WebAssemblyGameContext.ConsoleError("message with spaces and special chars: !@#$%");
        }

        [Fact]
        public void ShowAlert_ShowConfirm_DoNotThrow_WithVariousInputs()
        {
            WebAssemblyGameContext.ShowAlert(string.Empty);
            Assert.False(WebAssemblyGameContext.ShowConfirm(string.Empty));
            WebAssemblyGameContext.ShowAlert("alert with special chars: !@#$%");
            Assert.False(WebAssemblyGameContext.ShowConfirm("confirm with special chars: !@#$%"));
        }
    }
}
