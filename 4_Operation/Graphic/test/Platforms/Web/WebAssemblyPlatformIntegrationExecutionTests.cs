// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformIntegrationExecutionTests.cs
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
using Alis.Core.Graphic.Platforms;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Execution tests for the WebAssemblyPlatformIntegration file that run
    ///     on desktop (no WebAssembly runtime required). WebAssemblyPlatform is
    ///     constructible on desktop because it initializes pure managed state,
    ///     while every member that requires a WebAssemblyGameContext is blocked
    ///     because the game context constructor always throws
    ///     InvalidOperationException on desktop.
    /// </summary>
    public class WebAssemblyPlatformIntegrationExecutionTests
    {
        // =====================================================================
        // WebAssemblyPlatformIntegration (static)
        // =====================================================================

        /// <summary>
        ///     Tests that GetPlatform returns a WebAssemblyPlatform instance for
        ///     every registered name
        /// </summary>
        [Theory]
        [InlineData("WebAssembly")]
        [InlineData("Web")]
        [InlineData("Emscripten")]
        [InlineData("WASM")]
        public void GetPlatform_RegisteredName_ReturnsInstance(string name)
        {
            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform(name);

            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        /// <summary>
        ///     Tests that GetPlatform throws PlatformNotSupportedException for an
        ///     unknown platform name
        /// </summary>
        [Fact]
        public void GetPlatform_UnknownName_ThrowsPlatformNotSupportedException()
        {
            Assert.Throws<PlatformNotSupportedException>(() =>
                WebAssemblyPlatformIntegration.GetPlatform("UnknownPlatform"));
        }

        /// <summary>
        ///     Tests that GetSupportedPlatforms returns every registered name
        /// </summary>
        [Fact]
        public void GetSupportedPlatforms_ReturnsAllRegisteredNames()
        {
            string[] platforms = WebAssemblyPlatformIntegration.GetSupportedPlatforms();

            Assert.Contains("WebAssembly", platforms);
            Assert.Contains("Web", platforms);
            Assert.Contains("Emscripten", platforms);
            Assert.Contains("WASM", platforms);
        }

        /// <summary>
        ///     Tests that RegisterPlatform throws ArgumentException for a type
        ///     that does not implement INativePlatform
        /// </summary>
        [Fact]
        public void RegisterPlatform_InvalidType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                WebAssemblyPlatformIntegration.RegisterPlatform("Custom", typeof(string)));
        }

        /// <summary>
        ///     Tests that RegisterPlatform stores a valid platform type that can
        ///     later be retrieved by GetPlatform
        /// </summary>
        [Fact]
        public void RegisterPlatform_ValidType_CanBeRetrieved()
        {
            WebAssemblyPlatformIntegration.RegisterPlatform("CustomExecution", typeof(WebAssemblyPlatform));

            INativePlatform platform = WebAssemblyPlatformIntegration.GetPlatform("CustomExecution");

            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        /// <summary>
        ///     Tests that CreateGameContext throws InvalidOperationException on
        ///     desktop because the WebAssembly platform cannot be initialized
        /// </summary>
        [Fact]
        public void CreateGameContext_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateGameContext("TestGame"));
        }

        /// <summary>
        ///     Tests that CreateGameContext with a custom size throws
        ///     InvalidOperationException on desktop
        /// </summary>
        [Fact]
        public void CreateGameContext_CustomSize_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateGameContext("TestGame", 800, 600));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the Default profile returns
        ///     a constructible WebAssemblyPlatform instance
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Default_ReturnsInstance()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Default);

            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the Web profile returns a
        ///     constructible WebAssemblyPlatform instance
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Web_ReturnsInstance()
        {
            WebAssemblyPlatform platform = WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Web);

            Assert.NotNull(platform);
            Assert.IsType<WebAssemblyPlatform>(platform);
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the Game2D profile throws
        ///     InvalidOperationException on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Game2D_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the Game3D profile throws
        ///     InvalidOperationException on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Game3D_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game3D));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the LowEnd profile throws
        ///     InvalidOperationException on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_LowEnd_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.LowEnd));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the HighEnd profile throws
        ///     InvalidOperationException on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_HighEnd_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the Mobile profile throws
        ///     InvalidOperationException on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Mobile_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));
        }

        // =====================================================================
        // MultiplatformGameEngine (blocked by WebAssemblyGameContext)
        // =====================================================================

        /// <summary>
        ///     Tests that the MultiplatformGameEngine constructor throws
        ///     InvalidOperationException on desktop because the
        ///     WebAssemblyGameContext it creates cannot be initialized
        /// </summary>
        [Fact]
        public void MultiplatformGameEngine_Constructor_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                new MultiplatformGameEngine(800, 600, "TestGame"));
        }

        // =====================================================================
        // InputManager (instance members require WebAssemblyGameContext)
        // =====================================================================

        /// <summary>
        ///     Tests that the InputManager constructor accepts a null context and
        ///     stores it
        /// </summary>
        [Fact]
        public void InputManager_Constructor_NullContext_IsConstructible()
        {
            InputManager manager = new InputManager(null);

            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that GetMovementInput throws NullReferenceException when the
        ///     game context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void InputManager_GetMovementInput_NullContext_ThrowsNullReferenceException()
        {
            InputManager manager = new InputManager(null);

            Assert.Throws<NullReferenceException>(() => manager.GetMovementInput(out float x, out float y));
        }

        /// <summary>
        ///     Tests that IsJumpPressed throws NullReferenceException when the
        ///     game context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void InputManager_IsJumpPressed_NullContext_ThrowsNullReferenceException()
        {
            InputManager manager = new InputManager(null);

            Assert.Throws<NullReferenceException>(() => manager.IsJumpPressed());
        }

        /// <summary>
        ///     Tests that IsAttackPressed throws NullReferenceException when the
        ///     game context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void InputManager_IsAttackPressed_NullContext_ThrowsNullReferenceException()
        {
            InputManager manager = new InputManager(null);

            Assert.Throws<NullReferenceException>(() => manager.IsAttackPressed());
        }

        /// <summary>
        ///     Tests that GetCameraInput throws NullReferenceException when the
        ///     game context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void InputManager_GetCameraInput_NullContext_ThrowsNullReferenceException()
        {
            InputManager manager = new InputManager(null);

            Assert.Throws<NullReferenceException>(() => manager.GetCameraInput(out float pitch, out float yaw));
        }

        // =====================================================================
        // DisplayManager (instance members require WebAssemblyGameContext)
        // =====================================================================

        /// <summary>
        ///     Tests that the DisplayManager constructor accepts a null context
        ///     and stores it
        /// </summary>
        [Fact]
        public void DisplayManager_Constructor_NullContext_IsConstructible()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.NotNull(manager);
        }

        /// <summary>
        ///     Tests that GetWidth throws NullReferenceException when the game
        ///     context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_GetWidth_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.GetWidth());
        }

        /// <summary>
        ///     Tests that GetHeight throws NullReferenceException when the game
        ///     context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_GetHeight_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.GetHeight());
        }

        /// <summary>
        ///     Tests that GetAspectRatio throws NullReferenceException when the
        ///     game context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_GetAspectRatio_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.GetAspectRatio());
        }

        /// <summary>
        ///     Tests that IsFullscreen returns false on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void DisplayManager_IsFullscreen_ReturnsFalseOnDesktop()
        {
            Assert.False(DisplayManager.IsFullscreen());
        }

        /// <summary>
        ///     Tests that SetFullscreen with true throws NullReferenceException
        ///     when the game context is null because WebAssemblyGameContext cannot
        ///     be constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_SetFullscreen_True_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.SetFullscreen(true));
        }

        /// <summary>
        ///     Tests that SetFullscreen with false throws NullReferenceException
        ///     when the game context is null because WebAssemblyGameContext cannot
        ///     be constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_SetFullscreen_False_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.SetFullscreen(false));
        }

        /// <summary>
        ///     Tests that ToggleFullscreen throws NullReferenceException when the
        ///     game context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_ToggleFullscreen_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.ToggleFullscreen());
        }

        /// <summary>
        ///     Tests that SetSize throws NullReferenceException when the game
        ///     context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_SetSize_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.SetSize(800, 600));
        }

        /// <summary>
        ///     Tests that SetTitle throws NullReferenceException when the game
        ///     context is null because WebAssemblyGameContext cannot be
        ///     constructed on desktop
        /// </summary>
        [Fact]
        public void DisplayManager_SetTitle_NullContext_ThrowsNullReferenceException()
        {
            DisplayManager manager = new DisplayManager(null);

            Assert.Throws<NullReferenceException>(() => manager.SetTitle("TestGame"));
        }

        // =====================================================================
        // SystemInfo
        // =====================================================================

        /// <summary>
        ///     Tests that the PlatformName constant equals WebAssembly
        /// </summary>
        [Fact]
        public void SystemInfo_PlatformName_EqualsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.PlatformName);
        }

        /// <summary>
        ///     Tests that IsOnline returns false on desktop because the Emscripten
        ///     wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_IsOnline_ReturnsFalseOnDesktop()
        {
            Assert.False(SystemInfo.IsOnline());
        }

        /// <summary>
        ///     Tests that GetLanguage returns the default english fallback on
        ///     desktop because the Emscripten wrapper swallows the
        ///     DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_GetLanguage_ReturnsEnglishFallbackOnDesktop()
        {
            string language = SystemInfo.GetLanguage();

            Assert.Equal("en", language);
        }

        /// <summary>
        ///     Tests that GetDevicePixelRatio returns one on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_GetDevicePixelRatio_ReturnsOneOnDesktop()
        {
            float ratio = SystemInfo.GetDevicePixelRatio();

            Assert.Equal(1.0f, ratio, 5);
        }

        /// <summary>
        ///     Tests that GetBatteryLevel returns minus one on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_GetBatteryLevel_ReturnsMinusOneOnDesktop()
        {
            float level = SystemInfo.GetBatteryLevel();

            Assert.Equal(-1.0f, level, 5);
        }

        /// <summary>
        ///     Tests that IsCharging returns false on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_IsCharging_ReturnsFalseOnDesktop()
        {
            Assert.False(SystemInfo.IsCharging());
        }

        /// <summary>
        ///     Tests that GetScreenOrientation returns the landscape fallback on
        ///     desktop because the Emscripten wrapper swallows the
        ///     DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_GetScreenOrientation_ReturnsLandscapeFallbackOnDesktop()
        {
            int orientation = SystemInfo.GetScreenOrientation();

            Assert.Equal(1, orientation);
        }

        /// <summary>
        ///     Tests that GetSystemTimeMs returns zero on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_GetSystemTimeMs_ReturnsZeroOnDesktop()
        {
            double time = SystemInfo.GetSystemTimeMs();

            Assert.Equal(0.0, time, 5);
        }

        /// <summary>
        ///     Tests that LogToConsole does not throw on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_LogToConsole_DoesNotThrowOnDesktop()
        {
            SystemInfo.LogToConsole("test message");
        }

        /// <summary>
        ///     Tests that WarnToConsole does not throw on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_WarnToConsole_DoesNotThrowOnDesktop()
        {
            SystemInfo.WarnToConsole("test warning");
        }

        /// <summary>
        ///     Tests that ErrorToConsole does not throw on desktop because the
        ///     Emscripten wrapper swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void SystemInfo_ErrorToConsole_DoesNotThrowOnDesktop()
        {
            SystemInfo.ErrorToConsole("test error");
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        /// <summary>
        ///     Tests that RunMinimalGame throws InvalidOperationException on
        ///     desktop because the WebAssemblyGameContext it creates cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void QuickStart_RunMinimalGame_ThrowsInvalidOperationExceptionOnDesktop()
        {
            Assert.Throws<InvalidOperationException>(() =>
                QuickStart.RunMinimalGame((int width, int height) => { }));
        }

        /// <summary>
        ///     Tests that LogPlatformInfo does not throw on desktop because every
        ///     Emscripten wrapper it reaches swallows the DllNotFoundException
        /// </summary>
        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrowOnDesktop()
        {
            QuickStart.LogPlatformInfo();
        }
    }
}
