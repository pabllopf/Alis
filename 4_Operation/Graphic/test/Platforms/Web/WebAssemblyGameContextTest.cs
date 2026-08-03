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
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyGameContext covering constructors, static methods, Create factory, and instance methods.
    /// </summary>
    public class WebAssemblyGameContextTest
    {
        /// <summary>
        /// Tests that constructor null config throws argument null exception
        /// </summary>
        [WebOnly]
        public void Constructor_NullConfig_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyGameContext(null));
        }

        /// <summary>
        /// Tests that constructor with config throws on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void Constructor_WithConfig_ThrowsOnNonWebAssembly()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => new WebAssemblyGameContext(new WebAssemblyConfiguration()));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        /// <summary>
        /// Tests that default constructor throws on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void DefaultConstructor_ThrowsOnNonWebAssembly()
        {
            Assert.Throws<InvalidOperationException>(() => new WebAssemblyGameContext());
        }

        /// <summary>
        /// Tests that create with width height title throws on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void Create_WithWidthHeightTitle_ThrowsOnNonWebAssembly()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => WebAssemblyGameContext.Create(800, 600, "Test"));
            Assert.Equal("Failed to initialize WebAssembly platform", ex.Message);
        }

        /// <summary>
        /// Tests that create with null configure throws null reference exception
        /// </summary>
        [WebOnlyAttribute]
        public void Create_WithNullConfigure_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => WebAssemblyGameContext.Create((Action<WebAssemblyConfigurationBuilder>)null));
        }

        /// <summary>
        /// Tests that create with configure throws on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void Create_WithConfigure_ThrowsOnNonWebAssembly()
        {
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameContext.Create(b => b.WithTitle("Test")));
        }

        /// <summary>
        /// Tests that console log does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleLog_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleLog("test log");
            WebAssemblyGameContext.ConsoleLog(null);
            WebAssemblyGameContext.ConsoleLog(string.Empty);
        }

        /// <summary>
        /// Tests that console warn does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleWarn_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleWarn("test warn");
            WebAssemblyGameContext.ConsoleWarn(null);
        }

        /// <summary>
        /// Tests that console error does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleError_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleError("test error");
            WebAssemblyGameContext.ConsoleError(null);
        }

        /// <summary>
        /// Tests that show alert does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ShowAlert_DoesNotThrow()
        {
            WebAssemblyGameContext.ShowAlert("test alert");
            WebAssemblyGameContext.ShowAlert(null);
        }

        /// <summary>
        /// Tests that show confirm returns false on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void ShowConfirm_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
            Assert.False(WebAssemblyGameContext.ShowConfirm(null));
        }

        /// <summary>
        /// Tests that is fullscreen returns false on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void IsFullscreen_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.IsFullscreen());
        }

        /// <summary>
        /// Tests that lock pointer unlock pointer is pointer locked return false on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void LockPointer_UnlockPointer_IsPointerLocked_ReturnFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.LockPointer());
            Assert.False(WebAssemblyGameContext.UnlockPointer());
            Assert.False(WebAssemblyGameContext.IsPointerLocked());
        }

        /// <summary>
        /// Tests that get device language returns non null
        /// </summary>
        [WebOnlyAttribute]
        public void GetDeviceLanguage_ReturnsNonNull()
        {
            string lang = WebAssemblyGameContext.GetDeviceLanguage();
            Assert.NotNull(lang);
        }

        /// <summary>
        /// Tests that get battery level returns default
        /// </summary>
        [WebOnlyAttribute]
        public void GetBatteryLevel_ReturnsDefault()
        {
            float level = WebAssemblyGameContext.GetBatteryLevel();
            Assert.True(level >= -1.0f);
        }

        /// <summary>
        /// Tests that is charging returns false
        /// </summary>
        [WebOnlyAttribute]
        public void IsCharging_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsCharging());
        }

        /// <summary>
        /// Tests that is online returns false
        /// </summary>
        [WebOnlyAttribute]
        public void IsOnline_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsOnline());
        }

        /// <summary>
        /// Tests that get refresh rate returns sixty
        /// </summary>
        [WebOnlyAttribute]
        public void GetRefreshRate_ReturnsSixty()
        {
            Assert.Equal(60, WebAssemblyGameContext.GetRefreshRate());
        }

        /// <summary>
        /// Tests that vibrate gamepad returns false on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void VibrateGamepad_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
            Assert.False(WebAssemblyGameContext.VibrateGamepad(1, 0.5f, 0.5f, 0.2f));
        }

        /// <summary>
        /// Tests that console log warn error static methods do not throw with various inputs
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleLog_Warn_Error_StaticMethods_DoNotThrow_WithVariousInputs()
        {
            WebAssemblyGameContext.ConsoleLog(string.Empty);
            WebAssemblyGameContext.ConsoleWarn(string.Empty);
            WebAssemblyGameContext.ConsoleError(string.Empty);
            WebAssemblyGameContext.ConsoleLog("message with spaces and special chars: !@#$%");
            WebAssemblyGameContext.ConsoleWarn("message with spaces and special chars: !@#$%");
            WebAssemblyGameContext.ConsoleError("message with spaces and special chars: !@#$%");
        }

        /// <summary>
        /// Tests that show alert show confirm do not throw with various inputs
        /// </summary>
        [WebOnlyAttribute]
        public void ShowAlert_ShowConfirm_DoNotThrow_WithVariousInputs()
        {
            WebAssemblyGameContext.ShowAlert(string.Empty);
            Assert.False(WebAssemblyGameContext.ShowConfirm(string.Empty));
            WebAssemblyGameContext.ShowAlert("alert with special chars: !@#$%");
            Assert.False(WebAssemblyGameContext.ShowConfirm("confirm with special chars: !@#$%"));
        }
    }
}
