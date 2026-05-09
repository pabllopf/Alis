// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyConfiguration.cs
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
    ///     Configuration builder for WebAssembly platform
    ///     Provides a fluent interface to configure platform settings
    /// </summary>
    public class WebAssemblyConfigurationBuilder
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly WebAssemblyConfiguration _configuration;

        /// <summary>
        ///     Initializes a new instance of the WebAssemblyConfigurationBuilder
        /// </summary>
        public WebAssemblyConfigurationBuilder()
        {
            _configuration = new WebAssemblyConfiguration();
        }

        /// <summary>
        ///     Sets the window width and height
        /// </summary>
        public WebAssemblyConfigurationBuilder WithSize(int width, int height)
        {
            _configuration.WindowWidth = width;
            _configuration.WindowHeight = height;
            return this;
        }

        /// <summary>
        ///     Sets the window title
        /// </summary>
        public WebAssemblyConfigurationBuilder WithTitle(string title)
        {
            _configuration.WindowTitle = title;
            return this;
        }

        /// <summary>
        ///     Sets the window icon path
        /// </summary>
        public WebAssemblyConfigurationBuilder WithIconPath(string iconPath)
        {
            _configuration.IconPath = iconPath;
            return this;
        }

        /// <summary>
        ///     Enables or disables vertical sync
        /// </summary>
        public WebAssemblyConfigurationBuilder WithVSync(bool enabled)
        {
            _configuration.VSync = enabled;
            return this;
        }

        /// <summary>
        ///     Sets the target frame rate
        /// </summary>
        public WebAssemblyConfigurationBuilder WithTargetFrameRate(int fps)
        {
            if (fps <= 0)
                throw new ArgumentException("Frame rate must be positive", nameof(fps));
            _configuration.TargetFrameRate = fps;
            return this;
        }

        /// <summary>
        ///     Enables or disables multisampling anti-aliasing
        /// </summary>
        public WebAssemblyConfigurationBuilder WithMultisampling(bool enabled)
        {
            _configuration.MultisamplingEnabled = enabled;
            return this;
        }

        /// <summary>
        ///     Sets the multisample count (2, 4, 8, 16)
        /// </summary>
        public WebAssemblyConfigurationBuilder WithMultisampleCount(int count)
        {
            if (count != 2 && count != 4 && count != 8 && count != 16)
                throw new ArgumentException("Multisample count must be 2, 4, 8, or 16", nameof(count));
            _configuration.MultisampleCount = count;
            return this;
        }

        /// <summary>
        ///     Enables or disables fullscreen mode on startup
        /// </summary>
        public WebAssemblyConfigurationBuilder WithFullscreen(bool enabled)
        {
            _configuration.Fullscreen = enabled;
            return this;
        }

        /// <summary>
        ///     Enables or disables pointer lock on startup
        /// </summary>
        public WebAssemblyConfigurationBuilder WithPointerLock(bool enabled)
        {
            _configuration.PointerLock = enabled;
            return this;
        }

        /// <summary>
        ///     Sets the display quality level
        /// </summary>
        public WebAssemblyConfigurationBuilder WithDisplayQuality(DisplayQuality quality)
        {
            _configuration.DisplayQuality = quality;
            return this;
        }

        /// <summary>
        ///     Enables or disables gamepad input
        /// </summary>
        public WebAssemblyConfigurationBuilder WithGamepadInput(bool enabled)
        {
            _configuration.GamepadInputEnabled = enabled;
            return this;
        }

        /// <summary>
        ///     Enables or disables keyboard input
        /// </summary>
        public WebAssemblyConfigurationBuilder WithKeyboardInput(bool enabled)
        {
            _configuration.KeyboardInputEnabled = enabled;
            return this;
        }

        /// <summary>
        ///     Enables or disables mouse input
        /// </summary>
        public WebAssemblyConfigurationBuilder WithMouseInput(bool enabled)
        {
            _configuration.MouseInputEnabled = enabled;
            return this;
        }

        /// <summary>
        ///     Enables or disables touch input
        /// </summary>
        public WebAssemblyConfigurationBuilder WithTouchInput(bool enabled)
        {
            _configuration.TouchInputEnabled = enabled;
            return this;
        }

        /// <summary>
        ///     Sets the deadzone for gamepad analog sticks
        /// </summary>
        public WebAssemblyConfigurationBuilder WithGamepadDeadzone(float deadzone)
        {
            if (deadzone < 0 || deadzone > 1)
                throw new ArgumentException("Deadzone must be between 0 and 1", nameof(deadzone));
            _configuration.GamepadDeadzone = deadzone;
            return this;
        }

        /// <summary>
        ///     Sets the deadzone for gamepad triggers
        /// </summary>
        public WebAssemblyConfigurationBuilder WithTriggerDeadzone(float deadzone)
        {
            if (deadzone < 0 || deadzone > 1)
                throw new ArgumentException("Deadzone must be between 0 and 1", nameof(deadzone));
            _configuration.TriggerDeadzone = deadzone;
            return this;
        }

        /// <summary>
        ///     Enables or disables debug mode
        /// </summary>
        public WebAssemblyConfigurationBuilder WithDebugMode(bool enabled)
        {
            _configuration.DebugMode = enabled;
            return this;
        }

        /// <summary>
        ///     Builds and returns the configuration
        /// </summary>
        public WebAssemblyConfiguration Build()
        {
            return _configuration;
        }
    }

    /// <summary>
    ///     Configuration class for WebAssembly platform settings
    /// </summary>
    public class WebAssemblyConfiguration
    {
        /// <summary>
        ///     Gets or sets the window width (default: 800)
        /// </summary>
        public int WindowWidth { get; set; } = 800;

        /// <summary>
        ///     Gets or sets the window height (default: 600)
        /// </summary>
        public int WindowHeight { get; set; } = 600;

        /// <summary>
        ///     Gets or sets the window title
        /// </summary>
        public string WindowTitle { get; set; } = "WebAssembly Application";

        /// <summary>
        ///     Gets or sets the icon file path
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        ///     Gets or sets whether vertical sync is enabled (default: true)
        /// </summary>
        public bool VSync { get; set; } = true;

        /// <summary>
        ///     Gets or sets the target frame rate in FPS (default: 60)
        /// </summary>
        public int TargetFrameRate { get; set; } = 60;

        /// <summary>
        ///     Gets or sets whether multisampling is enabled (default: true)
        /// </summary>
        public bool MultisamplingEnabled { get; set; } = true;

        /// <summary>
        ///     Gets or sets the multisample count (default: 4)
        /// </summary>
        public int MultisampleCount { get; set; } = 4;

        /// <summary>
        ///     Gets or sets whether fullscreen is enabled on startup (default: false)
        /// </summary>
        public bool Fullscreen { get; set; } = false;

        /// <summary>
        ///     Gets or sets whether pointer lock is enabled on startup (default: false)
        /// </summary>
        public bool PointerLock { get; set; } = false;

        /// <summary>
        ///     Gets or sets the display quality level (default: High)
        /// </summary>
        public DisplayQuality DisplayQuality { get; set; } = DisplayQuality.High;

        /// <summary>
        ///     Gets or sets whether gamepad input is enabled (default: true)
        /// </summary>
        public bool GamepadInputEnabled { get; set; } = true;

        /// <summary>
        ///     Gets or sets whether keyboard input is enabled (default: true)
        /// </summary>
        public bool KeyboardInputEnabled { get; set; } = true;

        /// <summary>
        ///     Gets or sets whether mouse input is enabled (default: true)
        /// </summary>
        public bool MouseInputEnabled { get; set; } = true;

        /// <summary>
        ///     Gets or sets whether touch input is enabled (default: true)
        /// </summary>
        public bool TouchInputEnabled { get; set; } = true;

        /// <summary>
        ///     Gets or sets the deadzone for gamepad analog sticks (default: 0.15f)
        /// </summary>
        public float GamepadDeadzone { get; set; } = 0.15f;

        /// <summary>
        ///     Gets or sets the deadzone for gamepad triggers (default: 0.1f)
        /// </summary>
        public float TriggerDeadzone { get; set; } = 0.1f;

        /// <summary>
        ///     Gets or sets whether debug mode is enabled (default: false)
        /// </summary>
        public bool DebugMode { get; set; } = false;
    }

    /// <summary>
    ///     Factory for creating WebAssembly platform instances with configuration
    /// </summary>
    public static class WebAssemblyPlatformFactory
    {
        /// <summary>
        ///     Creates a new WebAssemblyPlatform instance with default configuration
        /// </summary>
        public static WebAssemblyPlatform CreateDefault()
        {
            return new WebAssemblyPlatform();
        }

        /// <summary>
        ///     Creates a new WebAssemblyPlatform instance with the specified configuration
        /// </summary>
        public static WebAssemblyPlatform Create(WebAssemblyConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            WebAssemblyPlatform platform = new WebAssemblyPlatform();

            string iconPath = configuration.IconPath;
            if (!platform.Initialize(configuration.WindowWidth, configuration.WindowHeight, 
                configuration.WindowTitle, iconPath))
            {
                throw new InvalidOperationException("Failed to initialize WebAssembly platform");
            }

            if (configuration.Fullscreen)
            {
                EmscriptenWeb.RequestFullscreen();
            }

            if (configuration.PointerLock)
            {
                EmscriptenWeb.LockPointer();
            }

            return platform;
        }

        /// <summary>
        ///     Creates a new WebAssemblyPlatform instance using a configuration builder
        /// </summary>
        public static WebAssemblyPlatform Create(Action<WebAssemblyConfigurationBuilder> configure)
        {
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            WebAssemblyConfigurationBuilder builder = new WebAssemblyConfigurationBuilder();
            configure(builder);
            WebAssemblyConfiguration configuration = builder.Build();

            return Create(configuration);
        }

        /// <summary>
        ///     Creates a platform optimized for game development
        /// </summary>
        public static WebAssemblyPlatform CreateForGameDevelopment(int width = 1280, int height = 720)
        {
            var config = new WebAssemblyConfiguration
            {
                WindowWidth = width,
                WindowHeight = height,
                WindowTitle = "Game",
                VSync = true,
                TargetFrameRate = 60,
                MultisamplingEnabled = true,
                MultisampleCount = 4,
                GamepadInputEnabled = true,
                KeyboardInputEnabled = true,
                MouseInputEnabled = true,
                TouchInputEnabled = true,
                GamepadDeadzone = 0.15f,
                TriggerDeadzone = 0.1f,
                DisplayQuality = DisplayQuality.High
            };

            return Create(config);
        }

        /// <summary>
        ///     Creates a platform optimized for low-end devices
        /// </summary>
        public static WebAssemblyPlatform CreateForLowEndDevice(int width = 800, int height = 600)
        {
            var config = new WebAssemblyConfiguration
            {
                WindowWidth = width,
                WindowHeight = height,
                WindowTitle = "Game",
                VSync = false,
                TargetFrameRate = 30,
                MultisamplingEnabled = false,
                GamepadInputEnabled = true,
                KeyboardInputEnabled = true,
                MouseInputEnabled = true,
                DisplayQuality = DisplayQuality.Low
            };

            return Create(config);
        }

        /// <summary>
        ///     Creates a platform optimized for high-end devices
        /// </summary>
        public static WebAssemblyPlatform CreateForHighEndDevice(int width = 1920, int height = 1080)
        {
            var config = new WebAssemblyConfiguration
            {
                WindowWidth = width,
                WindowHeight = height,
                WindowTitle = "Game",
                VSync = true,
                TargetFrameRate = 120,
                MultisamplingEnabled = true,
                MultisampleCount = 16,
                GamepadInputEnabled = true,
                KeyboardInputEnabled = true,
                MouseInputEnabled = true,
                TouchInputEnabled = true,
                DisplayQuality = DisplayQuality.Ultra
            };

            return Create(config);
        }
    }
}

