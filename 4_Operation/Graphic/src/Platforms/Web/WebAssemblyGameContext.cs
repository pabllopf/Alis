// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameContext.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Complete WebAssembly game context providing unified access to all platform features
    ///     This is the main entry point for game development on WebAssembly
    /// </summary>
    public class WebAssemblyGameContext : IDisposable
    {
        private readonly WebAssemblyPlatform _platform;
        private readonly WebAssemblyInputManager _inputManager;
        private readonly WebAssemblyInputContext _inputContext;
        private readonly WebAssemblyDisplayManager _displayManager;
        private readonly WebAssemblyConfiguration _configuration;
        private bool _isRunning;
        private bool _disposed;

        /// <summary>
        ///     Gets the underlying platform instance
        /// </summary>
        public WebAssemblyPlatform Platform => _platform;

        /// <summary>
        ///     Gets the input manager for handling keyboard, mouse, and gamepad input
        /// </summary>
        public WebAssemblyInputManager InputManager => _inputManager;

        /// <summary>
        ///     Gets the input context for advanced input handling
        /// </summary>
        public WebAssemblyInputContext InputContext => _inputContext;

        /// <summary>
        ///     Gets the display manager for handling window and screen configuration
        /// </summary>
        public WebAssemblyDisplayManager DisplayManager => _displayManager;

        /// <summary>
        ///     Gets the platform configuration
        /// </summary>
        public WebAssemblyConfiguration Configuration => _configuration;

        /// <summary>
        ///     Gets whether the game context is currently running
        /// </summary>
        public bool IsRunning => _isRunning;

        /// <summary>
        ///     Event triggered when the game is about to update
        /// </summary>
        public event EventHandler OnUpdate;

        /// <summary>
        ///     Event triggered when the game has a frame available
        /// </summary>
        public event EventHandler OnFrame;

        /// <summary>
        ///     Event triggered when the game is shutting down
        /// </summary>
        public event EventHandler OnShutdown;

        /// <summary>
        ///     Initializes a new instance of WebAssemblyGameContext with configuration
        /// </summary>
        public WebAssemblyGameContext(WebAssemblyConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            // Create and initialize platform
            _platform = WebAssemblyPlatformFactory.Create(configuration);
            _inputManager = new WebAssemblyInputManager(_platform);
            _inputContext = new WebAssemblyInputContext(_platform);
            _displayManager = new WebAssemblyDisplayManager(_platform);

            _isRunning = false;
            _disposed = false;
        }

        /// <summary>
        ///     Initializes a new instance with default configuration
        /// </summary>
        public WebAssemblyGameContext() : this(new WebAssemblyConfiguration())
        {
        }

        /// <summary>
        ///     Initializes the game context with window dimensions and title
        /// </summary>
        public static WebAssemblyGameContext Create(int width, int height, string title)
        {
            var config = new WebAssemblyConfiguration
            {
                WindowWidth = width,
                WindowHeight = height,
                WindowTitle = title
            };

            return new WebAssemblyGameContext(config);
        }

        /// <summary>
        ///     Initializes the game context using a configuration builder
        /// </summary>
        public static WebAssemblyGameContext Create(Action<WebAssemblyConfigurationBuilder> configure)
        {
            var builder = new WebAssemblyConfigurationBuilder();
            configure(builder);
            return new WebAssemblyGameContext(builder.Build());
        }

        /// <summary>
        ///     Shows the game window
        /// </summary>
        public void Show()
        {
            _platform.ShowWindow();
        }

        /// <summary>
        ///     Hides the game window
        /// </summary>
        public void Hide()
        {
            _platform.HideWindow();
        }

        /// <summary>
        ///     Enters the game loop
        /// </summary>
        public void Run(Action<WebAssemblyGameContext> updateCallback)
        {
            if (updateCallback == null)
                throw new ArgumentNullException(nameof(updateCallback));

            if (_isRunning)
                throw new InvalidOperationException("Game context is already running");

            _isRunning = true;
            _platform.ShowWindow();

            try
            {
                RunGameLoop(updateCallback);
            }
            finally
            {
                _isRunning = false;
                OnShutdown?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     The main game loop
        /// </summary>
        private void RunGameLoop(Action<WebAssemblyGameContext> updateCallback)
        {
            while (_platform.PollEvents() && _isRunning)
            {
                // Update systems
                _inputContext.Update();
                _displayManager.Update();

                // Invoke custom update callback
                try
                {
                    updateCallback?.Invoke(this);
                    OnUpdate?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    ConsoleLog($"Error in update callback: {ex.Message}");
                }

                // Prepare for rendering
                _platform.MakeContextCurrent();
                
                OnFrame?.Invoke(this, EventArgs.Empty);

                // Swap buffers for next frame
                _platform.SwapBuffers();
            }
        }

        /// <summary>
        ///     Registers an action (key binding) for the game
        /// </summary>
        public void RegisterAction(string actionName, ConsoleKey key)
        {
            _inputManager.RegisterKeyBinding(actionName, key);
        }

        /// <summary>
        ///     Registers multiple keys for a single action
        /// </summary>
        public void RegisterAction(string actionName, params ConsoleKey[] keys)
        {
            _inputManager.RegisterKeyBinding(actionName, keys);
        }

        /// <summary>
        ///     Checks if an action is currently active
        /// </summary>
        public bool IsActionActive(string actionName)
        {
            return _inputManager.IsActionActive(actionName);
        }

        /// <summary>
        ///     Checks if an action was just pressed this frame
        /// </summary>
        public bool IsActionJustPressed(string actionName)
        {
            return _inputManager.IsActionJustPressed(actionName);
        }

        /// <summary>
        ///     Gets the current width of the game window
        /// </summary>
        public int GetWidth()
        {
            return _platform.GetWindowWidth();
        }

        /// <summary>
        ///     Gets the current height of the game window
        /// </summary>
        public int GetHeight()
        {
            return _platform.GetWindowHeight();
        }

        /// <summary>
        ///     Gets the current aspect ratio
        /// </summary>
        public float GetAspectRatio()
        {
            return (float)GetWidth() / GetHeight();
        }

        /// <summary>
        ///     Sets the window size
        /// </summary>
        public void SetSize(int width, int height)
        {
            _platform.SetSize(width, height);
        }

        /// <summary>
        ///     Sets the window title
        /// </summary>
        public void SetTitle(string title)
        {
            _platform.SetTitle(title);
        }

        /// <summary>
        ///     Gets the mouse position in the window
        /// </summary>
        public void GetMousePosition(out int x, out int y)
        {
            _inputManager.GetMousePosition(out x, out y);
        }

        /// <summary>
        ///     Checks if a mouse button is currently pressed
        /// </summary>
        public bool IsMouseButtonDown(int button)
        {
            return _inputManager.IsMouseButtonDown(button);
        }

        /// <summary>
        ///     Gets the mouse wheel delta
        /// </summary>
        public float GetMouseWheelDelta()
        {
            return _inputManager.GetMouseWheelDelta();
        }

        /// <summary>
        ///     Checks if a keyboard key is currently pressed
        /// </summary>
        public bool IsKeyDown(ConsoleKey key)
        {
            return _platform.IsKeyDown(key);
        }

        /// <summary>
        ///     Gets the last key that was pressed
        /// </summary>
        public bool TryGetKeyPressed(out ConsoleKey key)
        {
            return _platform.TryGetLastKeyPressed(out key);
        }

        /// <summary>
        ///     Gets input characters/text
        /// </summary>
        public bool TryGetInputText(out string text)
        {
            return _platform.TryGetLastInputCharacters(out text);
        }

        /// <summary>
        ///     Gets all connected gamepad indices
        /// </summary>
        public int[] GetConnectedGamepadIndices()
        {
            return _inputManager.GetConnectedGamepadIndices();
        }

        /// <summary>
        ///     Gets the state of a gamepad
        /// </summary>
        public bool TryGetGamepadState(int gamepadIndex, out GamepadInputState state)
        {
            return _inputManager.TryGetGamepadState(gamepadIndex, out state);
        }

        /// <summary>
        ///     Vibrates a gamepad
        /// </summary>
        public bool VibrateGamepad(int gamepadIndex, float leftMotor = 1.0f, float rightMotor = 1.0f, float duration = 0.1f)
        {
            return _inputManager.VibrateGamepad(gamepadIndex, leftMotor, rightMotor, duration);
        }

        /// <summary>
        ///     Toggles fullscreen mode
        /// </summary>
        public bool ToggleFullscreen()
        {
            return _displayManager.ToggleFullscreen();
        }

        /// <summary>
        ///     Enters fullscreen mode
        /// </summary>
        public bool EnterFullscreen()
        {
            return _displayManager.EnterFullscreen();
        }

        /// <summary>
        ///     Exits fullscreen mode
        /// </summary>
        public bool ExitFullscreen()
        {
            return _displayManager.ExitFullscreen();
        }

        /// <summary>
        ///     Checks if currently in fullscreen
        /// </summary>
        public bool IsFullscreen()
        {
            return _displayManager.IsFullscreen();
        }

        /// <summary>
        ///     Locks the pointer for FPS games
        /// </summary>
        public bool LockPointer()
        {
            return _inputContext.LockPointer();
        }

        /// <summary>
        ///     Unlocks the pointer
        /// </summary>
        public bool UnlockPointer()
        {
            return _inputContext.UnlockPointer();
        }

        /// <summary>
        ///     Checks if the pointer is locked
        /// </summary>
        public bool IsPointerLocked()
        {
            return _inputContext.IsPointerLocked();
        }

        /// <summary>
        ///     Stops the game loop and shuts down the context
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
        }

        /// <summary>
        ///     Logs a message to the browser console
        /// </summary>
        public static void ConsoleLog(string message)
        {
            EmscriptenWeb.ConsoleLog(message);
        }

        /// <summary>
        ///     Logs a warning to the browser console
        /// </summary>
        public static void ConsoleWarn(string message)
        {
            EmscriptenWeb.ConsoleWarn(message);
        }

        /// <summary>
        ///     Logs an error to the browser console
        /// </summary>
        public static void ConsoleError(string message)
        {
            EmscriptenWeb.ConsoleError(message);
        }

        /// <summary>
        ///     Shows an alert dialog
        /// </summary>
        public static void ShowAlert(string message)
        {
            EmscriptenWeb.ShowAlert(message);
        }

        /// <summary>
        ///     Shows a confirmation dialog
        /// </summary>
        public static bool ShowConfirm(string message)
        {
            return EmscriptenWeb.ShowConfirm(message);
        }

        /// <summary>
        ///     Gets the device language
        /// </summary>
        public string GetDeviceLanguage()
        {
            return _displayManager.GetSystemLanguage();
        }

        /// <summary>
        ///     Gets the device battery level
        /// </summary>
        public float GetBatteryLevel()
        {
            return _displayManager.GetBatteryLevel();
        }

        /// <summary>
        ///     Checks if the device is charging
        /// </summary>
        public bool IsCharging()
        {
            return _displayManager.IsCharging();
        }

        /// <summary>
        ///     Checks if the browser is online
        /// </summary>
        public bool IsOnline()
        {
            return _displayManager.IsOnline();
        }

        /// <summary>
        ///     Gets the screen refresh rate
        /// </summary>
        public int GetRefreshRate()
        {
            return _displayManager.GetRefreshRate();
        }

        /// <summary>
        ///     Disposes the game context
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _isRunning = false;
            _platform?.Cleanup();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    ///     Predefined game configurations for different scenarios
    /// </summary>
    public static class GameContextPresets
    {
        /// <summary>
        ///     Configuration for a 2D game
        /// </summary>
        public static WebAssemblyConfiguration Game2D()
        {
            return new WebAssemblyConfiguration
            {
                WindowWidth = 1280,
                WindowHeight = 720,
                WindowTitle = "2D Game",
                VSync = true,
                TargetFrameRate = 60,
                MultisamplingEnabled = true,
                MultisampleCount = 4,
                DisplayQuality = DisplayQuality.High,
                GamepadInputEnabled = true,
                KeyboardInputEnabled = true,
                MouseInputEnabled = true
            };
        }

        /// <summary>
        ///     Configuration for a 3D game
        /// </summary>
        public static WebAssemblyConfiguration Game3D()
        {
            return new WebAssemblyConfiguration
            {
                WindowWidth = 1920,
                WindowHeight = 1080,
                WindowTitle = "3D Game",
                VSync = true,
                TargetFrameRate = 60,
                MultisamplingEnabled = true,
                MultisampleCount = 8,
                DisplayQuality = DisplayQuality.VeryHigh,
                GamepadInputEnabled = true,
                KeyboardInputEnabled = true,
                MouseInputEnabled = true
            };
        }

        /// <summary>
        ///     Configuration for a puzzle game
        /// </summary>
        public static WebAssemblyConfiguration PuzzleGame()
        {
            return new WebAssemblyConfiguration
            {
                WindowWidth = 800,
                WindowHeight = 600,
                WindowTitle = "Puzzle Game",
                VSync = false,
                TargetFrameRate = 30,
                MultisamplingEnabled = false,
                DisplayQuality = DisplayQuality.Medium,
                GamepadInputEnabled = false,
                KeyboardInputEnabled = true,
                MouseInputEnabled = true
            };
        }

        /// <summary>
        ///     Configuration for a mobile game
        /// </summary>
        public static WebAssemblyConfiguration MobileGame()
        {
            return new WebAssemblyConfiguration
            {
                WindowWidth = 720,
                WindowHeight = 1280,
                WindowTitle = "Mobile Game",
                VSync = true,
                TargetFrameRate = 60,
                MultisamplingEnabled = false,
                DisplayQuality = DisplayQuality.Medium,
                GamepadInputEnabled = true,
                KeyboardInputEnabled = true,
                MouseInputEnabled = true,
                TouchInputEnabled = true
            };
        }
    }
}

