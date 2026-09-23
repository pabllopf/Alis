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
        ///     Tests that CreateGameContext propagates the initialization failure on
        ///     desktop because the WebAssembly platform cannot be initialized
        /// </summary>
        [Fact]
        public void CreateGameContext_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyPlatformIntegration.CreateGameContext("TestGame"));
        }

        /// <summary>
        ///     Tests that CreateGameContext with a custom size propagates the
        ///     initialization failure on desktop
        /// </summary>
        [Fact]
        public void CreateGameContext_CustomSize_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
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
        ///     Tests that CreateOptimizedPlatform with the Game2D profile propagates
        ///     the initialization failure on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Game2D_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game2D));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the Game3D profile propagates
        ///     the initialization failure on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Game3D_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Game3D));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the LowEnd profile propagates
        ///     the initialization failure on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_LowEnd_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.LowEnd));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the HighEnd profile propagates
        ///     the initialization failure on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_HighEnd_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.HighEnd));
        }

        /// <summary>
        ///     Tests that CreateOptimizedPlatform with the Mobile profile propagates
        ///     the initialization failure on desktop because the platform cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void CreateOptimizedPlatform_Mobile_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyPlatformIntegration.CreateOptimizedPlatform(OptimizationProfile.Mobile));
        }

        // =====================================================================
        // MultiplatformGameEngine (blocked by WebAssemblyGameContext)
        // =====================================================================

        /// <summary>
        ///     Tests that the MultiplatformGameEngine constructor propagates the
        ///     initialization failure on desktop because the WebAssemblyGameContext
        ///     it creates cannot be initialized
        /// </summary>
        [Fact]
        public void MultiplatformGameEngine_Constructor_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
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
        ///     Tests that IsFullscreen propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void DisplayManager_IsFullscreen_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => DisplayManager.IsFullscreen());
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
        ///     Tests that IsOnline propagates the native failure on desktop because
        ///     the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_IsOnline_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.IsOnline());
        }

        /// <summary>
        ///     Tests that GetLanguage propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_GetLanguage_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.GetLanguage());
        }

        /// <summary>
        ///     Tests that GetDevicePixelRatio propagates the native failure on
        ///     desktop because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_GetDevicePixelRatio_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.GetDevicePixelRatio());
        }

        /// <summary>
        ///     Tests that GetBatteryLevel propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_GetBatteryLevel_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.GetBatteryLevel());
        }

        /// <summary>
        ///     Tests that IsCharging propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_IsCharging_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.IsCharging());
        }

        /// <summary>
        ///     Tests that GetScreenOrientation propagates the native failure on
        ///     desktop because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_GetScreenOrientation_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.GetScreenOrientation());
        }

        /// <summary>
        ///     Tests that GetSystemTimeMs propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_GetSystemTimeMs_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.GetSystemTimeMs());
        }

        /// <summary>
        ///     Tests that LogToConsole propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_LogToConsole_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.LogToConsole("test message"));
        }

        /// <summary>
        ///     Tests that WarnToConsole propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_WarnToConsole_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.WarnToConsole("test warning"));
        }

        /// <summary>
        ///     Tests that ErrorToConsole propagates the native failure on desktop
        ///     because the Emscripten wrapper no longer swallows it
        /// </summary>
        [Fact]
        public void SystemInfo_ErrorToConsole_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => SystemInfo.ErrorToConsole("test error"));
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        /// <summary>
        ///     Tests that RunMinimalGame propagates the initialization failure on
        ///     desktop because the WebAssemblyGameContext it creates cannot be
        ///     initialized
        /// </summary>
        [Fact]
        public void QuickStart_RunMinimalGame_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() =>
                QuickStart.RunMinimalGame((int width, int height) => { }));
        }

        /// <summary>
        ///     Tests that LogPlatformInfo propagates the native failure on desktop
        ///     because the Emscripten wrappers it reaches no longer swallow it
        /// </summary>
        [Fact]
        public void QuickStart_LogPlatformInfo_PropagatesOnDesktop()
        {
            Assert.ThrowsAny<Exception>(() => QuickStart.LogPlatformInfo());
        }
    }
}
