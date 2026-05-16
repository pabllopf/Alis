// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformIntegration.cs
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
using System.Collections.Generic;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     WebAssembly Platform Integration Guide and Factory
    ///     
    ///     INTEGRATION INSTRUCTIONS FOR LINUX AND WEB PLATFORMS
    ///     ======================================================
    ///     
    ///     This controller provides complete WebAssembly support for game development.
    ///     It implements all methods from INativePlatform and adds extensive input handling
    ///     for keyboards, gamepads (Xbox, PlayStation, etc.), mice, and touch input.
    ///     
    ///     KEY FEATURES:
    ///     - Full INativePlatform implementation for WebAssembly
    ///     - EGL context management for OpenGL rendering
    ///     - Comprehensive keyboard input with key binding system
    ///     - Gamepad support (Xbox controllers, PlayStation controllers, etc.)
    ///     - Mouse and wheel input handling
    ///     - Touch input support
    ///     - Display management (resolution, fullscreen, orientation)
    ///     - Pointer locking for FPS games
    ///     - Device capabilities detection
    ///     - Browser API integration
    ///     - Cross-platform Linux support through Emscripten
    ///     
    ///     FOR LINUX SUPPORT:
    ///     - Compile with: emcripten or wasm target
    ///     - Use HTML5 Canvas for rendering
    ///     - All input handling works on Linux browsers through standard web APIs
    ///     - Network access available through WebSockets and Fetch API
    ///     - File access through IndexedDB or File API
    ///     
    ///     USAGE EXAMPLE:
    ///     
    ///         // Create game context with configuration
    ///         var gameContext = WebAssemblyGameContext.Create(1280, 720, "My Game");
    ///         
    ///         // Register input actions
    ///         gameContext.RegisterAction("Move_Up", ConsoleKey.W);
    ///         gameContext.RegisterAction("Jump", ConsoleKey.Spacebar);
    ///         
    ///         // Run game loop
    ///         gameContext.Run((context) =>
    ///         {
    ///             // Handle input
    ///             if (context.IsActionActive("Move_Up"))
    ///             {
    ///                 // Move player up
    ///             }
    ///             
    ///             // Handle gamepad
    ///             int[] gamepads = context.GetConnectedGamepadIndices();
    ///             foreach (int id in gamepads)
    ///             {
    ///                 if (context.TryGetGamepadState(id, out var state))
    ///                 {
    ///                     // Use gamepad input
    ///                 }
    ///             }
    ///             
    ///             // Rendering
    ///             context.Platform.MakeContextCurrent();
    ///             // Render scene here
    ///             context.Platform.SwapBuffers();
    ///         });
    /// </summary>
    public class WebAssemblyPlatformIntegration
    {
        /// <summary>
        /// The web assembly platform
        /// </summary>
        private static readonly Dictionary<string, Type> _registeredPlatforms = new Dictionary<string, Type>
        {
            { "WebAssembly", typeof(WebAssemblyPlatform) },
            { "Web", typeof(WebAssemblyPlatform) },
            { "Emscripten", typeof(WebAssemblyPlatform) },
            { "WASM", typeof(WebAssemblyPlatform) }
        };

        /// <summary>
        ///     Gets or creates a platform instance for the specified platform name
        /// </summary>
        public static INativePlatform GetPlatform(string platformName)
        {
            if (!_registeredPlatforms.TryGetValue(platformName, out Type platformType))
            {
                throw new PlatformNotSupportedException($"Platform '{platformName}' is not supported");
            }

            return (INativePlatform)Activator.CreateInstance(platformType);
        }

        /// <summary>
        ///     Creates a complete game context for WebAssembly with all features enabled
        /// </summary>
        public static WebAssemblyGameContext CreateGameContext(string title, int width = 1280, int height = 720)
        {
            return WebAssemblyGameContext.Create(width, height, title);
        }

        /// <summary>
        ///     Creates a platform optimized for specific use case
        /// </summary>
        public static WebAssemblyPlatform CreateOptimizedPlatform(OptimizationProfile profile)
        {
            return profile switch
            {
                OptimizationProfile.Game2D => WebAssemblyPlatformFactory.CreateForGameDevelopment(1280, 720),
                OptimizationProfile.Game3D => WebAssemblyPlatformFactory.CreateForHighEndDevice(1920, 1080),
                OptimizationProfile.LowEnd => WebAssemblyPlatformFactory.CreateForLowEndDevice(800, 600),
                OptimizationProfile.HighEnd => WebAssemblyPlatformFactory.CreateForHighEndDevice(1920, 1080),
                OptimizationProfile.Mobile => WebAssemblyPlatformFactory.Create(c => c
                    .WithSize(720, 1280)
                    .WithTouchInput(true)
                    .WithGamepadInput(true)
                    .WithDisplayQuality(DisplayQuality.Medium)),
                _ => WebAssemblyPlatformFactory.CreateDefault()
            };
        }

        /// <summary>
        ///     Registers a custom platform implementation
        /// </summary>
        public static void RegisterPlatform(string name, Type platformType)
        {
            if (!typeof(INativePlatform).IsAssignableFrom(platformType))
            {
                throw new ArgumentException($"Type {platformType.Name} must implement INativePlatform", nameof(platformType));
            }

            _registeredPlatforms[name] = platformType;
        }

        /// <summary>
        ///     Gets all supported platform names
        /// </summary>
        public static string[] GetSupportedPlatforms()
        {
            return new List<string>(_registeredPlatforms.Keys).ToArray();
        }
    }

    /// <summary>
    ///     Optimization profile enumeration for selecting preset configurations
    /// </summary>
    public enum OptimizationProfile
    {
        /// <summary>
        ///     Default profile with balanced settings
        /// </summary>
        Default,

        /// <summary>
        ///     Optimized for 2D games
        /// </summary>
        Game2D,

        /// <summary>
        ///     Optimized for 3D games with high graphics quality
        /// </summary>
        Game3D,

        /// <summary>
        ///     Optimized for low-end devices
        /// </summary>
        LowEnd,

        /// <summary>
        ///     Optimized for high-end devices with maximum quality
        /// </summary>
        HighEnd,

        /// <summary>
        ///     Optimized for mobile devices with touch input
        /// </summary>
        Mobile,

        /// <summary>
        ///     Optimized for web browsers
        /// </summary>
        Web
    }

    /// <summary>
    ///     Multiplatform game engine wrapper simplifying cross-platform development
    /// </summary>
    public class MultiplatformGameEngine : IDisposable
    {
        /// <summary>
        /// The game context
        /// </summary>
        private readonly WebAssemblyGameContext _gameContext;
        /// <summary>
        /// The input manager
        /// </summary>
        private readonly InputManager _inputManager;
        /// <summary>
        /// The display manager
        /// </summary>
        private readonly DisplayManager _displayManager;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the game context
        /// </summary>
        public WebAssemblyGameContext GameContext => _gameContext;
        /// <summary>
        /// Gets the value of the input
        /// </summary>
        public InputManager Input => _inputManager;
        /// <summary>
        /// Gets the value of the display
        /// </summary>
        public DisplayManager Display => _displayManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplatformGameEngine"/> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        public MultiplatformGameEngine(int width, int height, string title)
        {
            _gameContext = WebAssemblyGameContext.Create(width, height, title);
            _inputManager = new InputManager(_gameContext);
            _displayManager = new DisplayManager(_gameContext);
            _disposed = false;
        }

        /// <summary>
        /// Runs the update callback
        /// </summary>
        /// <param name="updateCallback">The update callback</param>
        public void Run(Action<MultiplatformGameEngine> updateCallback)
        {
            _gameContext.Run((context) => updateCallback?.Invoke(this));
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _gameContext?.Dispose();
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }

    /// <summary>
    ///     Wrapper for simplified input management
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// The game context
        /// </summary>
        private readonly WebAssemblyGameContext _gameContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputManager"/> class
        /// </summary>
        /// <param name="gameContext">The game context</param>
        public InputManager(WebAssemblyGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        /// <summary>
        /// Gets the movement input using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The bool</returns>
        public bool GetMovementInput(out float x, out float y)
        {
            x = 0;
            y = 0;

            if (_gameContext.IsKeyDown(ConsoleKey.W))
                y += 1;
            if (_gameContext.IsKeyDown(ConsoleKey.S))
                y -= 1;
            if (_gameContext.IsKeyDown(ConsoleKey.A))
                x -= 1;
            if (_gameContext.IsKeyDown(ConsoleKey.D))
                x += 1;

            if (_gameContext.TryGetGamepadState(0, out var state))
            {
                x += state.CurrentState.LeftStickX;
                y += state.CurrentState.LeftStickY;
            }

            float mag = (float)Math.Sqrt(x * x + y * y);
            if (mag > 1)
            {
                x /= mag;
                y /= mag;
            }

            return mag > 0;
        }

        /// <summary>
        /// Ises the jump pressed
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsJumpPressed()
        {
            bool keyboard = _gameContext.IsKeyDown(ConsoleKey.Spacebar);
            bool gamepad = _gameContext.TryGetGamepadState(0, out var state) && state.CurrentState.ButtonA;
            return keyboard || gamepad;
        }

        /// <summary>
        /// Ises the attack pressed
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsAttackPressed()
        {
            bool keyboard = _gameContext.IsKeyDown(ConsoleKey.E);
            bool gamepad = _gameContext.TryGetGamepadState(0, out var state) && state.CurrentState.ButtonX;
            return keyboard || gamepad;
        }

        /// <summary>
        /// Gets the camera input using the specified pitch
        /// </summary>
        /// <param name="pitch">The pitch</param>
        /// <param name="yaw">The yaw</param>
        public void GetCameraInput(out float pitch, out float yaw)
        {
            pitch = 0;
            yaw = 0;

            _gameContext.GetMousePosition(out int mx, out int my);
            // Use mouse position for camera control

            if (_gameContext.TryGetGamepadState(0, out var state))
            {
                pitch += state.CurrentState.RightStickY * 90; // Convert to degrees
                yaw += state.CurrentState.RightStickX * 90;
            }
        }
    }

    /// <summary>
    ///     Wrapper for simplified display management
    /// </summary>
    public class DisplayManager
    {
        /// <summary>
        /// The game context
        /// </summary>
        private readonly WebAssemblyGameContext _gameContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayManager"/> class
        /// </summary>
        /// <param name="gameContext">The game context</param>
        public DisplayManager(WebAssemblyGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        /// <summary>
        /// Gets the width
        /// </summary>
        /// <returns>The int</returns>
        public int GetWidth() => _gameContext.GetWidth();
        /// <summary>
        /// Gets the height
        /// </summary>
        /// <returns>The int</returns>
        public int GetHeight() => _gameContext.GetHeight();
        /// <summary>
        /// Gets the aspect ratio
        /// </summary>
        /// <returns>The float</returns>
        public float GetAspectRatio() => _gameContext.GetAspectRatio();
        /// <summary>
        /// Ises the fullscreen
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsFullscreen() => _gameContext.IsFullscreen();

        /// <summary>
        /// Sets the fullscreen using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        public void SetFullscreen(bool enabled)
        {
            if (enabled)
                _gameContext.EnterFullscreen();
            else
                _gameContext.ExitFullscreen();
        }

        /// <summary>
        /// Toggles the fullscreen
        /// </summary>
        public void ToggleFullscreen() => _gameContext.ToggleFullscreen();
        /// <summary>
        /// Sets the size using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void SetSize(int width, int height) => _gameContext.SetSize(width, height);
        /// <summary>
        /// Sets the title using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        public void SetTitle(string title) => _gameContext.SetTitle(title);
    }

    /// <summary>
    ///     Provides system information and device capabilities
    /// </summary>
    public static class SystemInfo
    {
        /// <summary>
        /// Gets the platform name
        /// </summary>
        /// <returns>The string</returns>
        public static string GetPlatformName() => "WebAssembly";

        /// <summary>
        /// Ises the online
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsOnline() => EmscriptenWeb.IsOnline();

        /// <summary>
        /// Gets the language
        /// </summary>
        /// <returns>The string</returns>
        public static string GetLanguage() => EmscriptenWeb.GetLanguage();

        /// <summary>
        /// Gets the device pixel ratio
        /// </summary>
        /// <returns>The float</returns>
        public static float GetDevicePixelRatio() => EmscriptenWeb.GetDevicePixelRatio();

        /// <summary>
        /// Gets the battery level
        /// </summary>
        /// <returns>The float</returns>
        public static float GetBatteryLevel() => EmscriptenWeb.GetBatteryLevel();

        /// <summary>
        /// Ises the charging
        /// </summary>
        /// <returns>The bool</returns>
        public static bool IsCharging() => EmscriptenWeb.IsCharging();

        /// <summary>
        /// Gets the screen orientation
        /// </summary>
        /// <returns>The int</returns>
        public static int GetScreenOrientation() => EmscriptenWeb.GetOrientation();

        /// <summary>
        /// Gets the system time ms
        /// </summary>
        /// <returns>The double</returns>
        public static double GetSystemTimeMs() => EmscriptenWeb.GetSystemTimeMs();

        /// <summary>
        /// Logs the to console using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public static void LogToConsole(string message) => EmscriptenWeb.ConsoleLog(message);

        /// <summary>
        /// Warns the to console using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public static void WarnToConsole(string message) => EmscriptenWeb.ConsoleWarn(message);

        /// <summary>
        /// Errors the to console using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public static void ErrorToConsole(string message) => EmscriptenWeb.ConsoleError(message);
    }

    /// <summary>
    ///     Quick reference for common game development tasks
    /// </summary>
    public static class QuickStart
    {
        /// <summary>
        ///     Creates and runs a minimal game
        /// </summary>
        public static void RunMinimalGame(Action<int, int> onRender)
        {
            using (var game = WebAssemblyGameContext.Create(1280, 720, "Game"))
            {
                game.Run((context) =>
                {
                    int width = context.GetWidth();
                    int height = context.GetHeight();

                    context.Platform.MakeContextCurrent();
                    onRender(width, height);
                    context.Platform.SwapBuffers();
                });
            }
        }

        /// <summary>
        ///     Logs platform information for debugging
        /// </summary>
        public static void LogPlatformInfo()
        {
            WebAssemblyGameContext.ConsoleLog($"Platform: {SystemInfo.GetPlatformName()}");
            WebAssemblyGameContext.ConsoleLog($"Language: {SystemInfo.GetLanguage()}");
            WebAssemblyGameContext.ConsoleLog($"Online: {SystemInfo.IsOnline()}");
            WebAssemblyGameContext.ConsoleLog($"DPI: {SystemInfo.GetDevicePixelRatio()}");
            WebAssemblyGameContext.ConsoleLog($"Battery: {SystemInfo.GetBatteryLevel():P}");
        }
    }
}

