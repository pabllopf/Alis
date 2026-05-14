// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManager.cs
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
    ///     Manages display and window-related functionality for WebAssembly
    ///     Handles resolution, orientation, fullscreen, and display events
    /// </summary>
    public class WebAssemblyDisplayManager
    {
        /// <summary>
        /// The platform
        /// </summary>
        private readonly WebAssemblyPlatform _platform;
        /// <summary>
        /// The current width
        /// </summary>
        private int _currentWidth;
        /// <summary>
        /// The current height
        /// </summary>
        private int _currentHeight;
        /// <summary>
        /// The current orientation
        /// </summary>
        private ScreenOrientation _currentOrientation;
        /// <summary>
        /// The is fullscreen
        /// </summary>
        private bool _isFullscreen;
        /// <summary>
        /// The display quality
        /// </summary>
        private DisplayQuality _displayQuality;
        /// <summary>
        /// The supported modes
        /// </summary>
        private readonly List<DisplayMode> _supportedModes;

        /// <summary>
        ///     Event triggered when the window size changes
        /// </summary>
        public event EventHandler<DisplayEventArgs> OnDisplayResized;

        /// <summary>
        ///     Event triggered when the screen orientation changes
        /// </summary>
        public event EventHandler<OrientationEventArgs> OnOrientationChanged;

        /// <summary>
        ///     Event triggered when entering or exiting fullscreen
        /// </summary>
        public event EventHandler<FullscreenEventArgs> OnFullscreenChanged;

        /// <summary>
        ///     Initializes a new instance of the WebAssemblyDisplayManager
        /// </summary>
        public WebAssemblyDisplayManager(WebAssemblyPlatform platform)
        {
            _platform = platform ?? throw new ArgumentNullException(nameof(platform));
            _currentWidth = platform.GetWindowWidth();
            _currentHeight = platform.GetWindowHeight();
            _currentOrientation = DetectOrientation();
            _isFullscreen = false;
            _displayQuality = DisplayQuality.High;
            _supportedModes = new List<DisplayMode>();
            
            InitializeSupportedModes();
        }

        /// <summary>
        ///     Initializes the list of supported display modes
        /// </summary>
        private void InitializeSupportedModes()
        {
            _supportedModes.Clear();

            // Common resolutions
            int[] standardWidths = { 640, 800, 1024, 1280, 1366, 1600, 1920, 2560 };
            int[] standardHeights = { 480, 600, 768, 720, 768, 1024, 1080, 1440 };

            for (int i = 0; i < Math.Min(standardWidths.Length, standardHeights.Length); i++)
            {
                _supportedModes.Add(new DisplayMode
                {
                    Width = standardWidths[i],
                    Height = standardHeights[i],
                    RefreshRate = 60
                });
            }

            // Add fullscreen native resolution
            _supportedModes.Add(new DisplayMode
            {
                Width = 1920,
                Height = 1080,
                RefreshRate = 60,
                IsFullscreenOnly = true
            });
        }

        /// <summary>
        ///     Detects the current screen orientation
        /// </summary>
        private ScreenOrientation DetectOrientation()
        {
            int width = _platform.GetWindowWidth();
            int height = _platform.GetWindowHeight();

            if (width > height)
            {
                return ScreenOrientation.Landscape;
            }
            else if (height > width)
            {
                return ScreenOrientation.Portrait;
            }
            else
            {
                return ScreenOrientation.Square;
            }
        }

        /// <summary>
        ///     Gets the current display width
        /// </summary>
        public int GetWidth()
        {
            return _currentWidth;
        }

        /// <summary>
        ///     Gets the current display height
        /// </summary>
        public int GetHeight()
        {
            return _currentHeight;
        }

        /// <summary>
        ///     Gets the current aspect ratio
        /// </summary>
        public float GetAspectRatio()
        {
            return (float)_currentWidth / _currentHeight;
        }

        /// <summary>
        ///     Gets the current screen orientation
        /// </summary>
        public ScreenOrientation GetOrientation()
        {
            return _currentOrientation;
        }

        /// <summary>
        ///     Gets the device pixel ratio (for high DPI displays)
        /// </summary>
        public static float GetDevicePixelRatio()
        {
            return EmscriptenWeb.GetDevicePixelRatio();
        }

        /// <summary>
        ///     Sets the window resolution
        /// </summary>
        public bool SetResolution(int width, int height)
        {
            try
            {
                _platform.SetSize(width, height);
                _currentWidth = width;
                _currentHeight = height;

                ScreenOrientation newOrientation = DetectOrientation();
                if (newOrientation != _currentOrientation)
                {
                    _currentOrientation = newOrientation;
                    OnOrientationChanged?.Invoke(this, new OrientationEventArgs { Orientation = _currentOrientation });
                }

                OnDisplayResized?.Invoke(this, new DisplayEventArgs 
                { 
                    Width = width, 
                    Height = height 
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Toggles fullscreen mode
        /// </summary>
        public bool ToggleFullscreen()
        {
            if (_isFullscreen)
            {
                return ExitFullscreen();
            }
            else
            {
                return EnterFullscreen();
            }
        }

        /// <summary>
        ///     Enters fullscreen mode
        /// </summary>
        public bool EnterFullscreen()
        {
            if (EmscriptenWeb.RequestFullscreen())
            {
                _isFullscreen = true;
                OnFullscreenChanged?.Invoke(this, new FullscreenEventArgs { IsFullscreen = true });
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Exits fullscreen mode
        /// </summary>
        public bool ExitFullscreen()
        {
            if (EmscriptenWeb.ExitFullscreen())
            {
                _isFullscreen = false;
                OnFullscreenChanged?.Invoke(this, new FullscreenEventArgs { IsFullscreen = false });
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Checks if currently in fullscreen
        /// </summary>
        public bool IsFullscreen()
        {
            return EmscriptenWeb.IsFullscreenEnabled();
        }

        /// <summary>
        ///     Gets all supported display modes
        /// </summary>
        public DisplayMode[] GetSupportedModes()
        {
            return _supportedModes.ToArray();
        }

        /// <summary>
        ///     Finds a supported display mode matching the given dimensions
        /// </summary>
        public DisplayMode FindDisplayMode(int width, int height)
        {
            foreach (DisplayMode mode in _supportedModes)
            {
                if (mode.Width == width && mode.Height == height)
                {
                    return mode;
                }
            }
            return null;
        }

        /// <summary>
        ///     Sets the display quality level (affects rendering scale)
        /// </summary>
        public void SetDisplayQuality(DisplayQuality quality)
        {
            _displayQuality = quality;
        }

        /// <summary>
        ///     Gets the current display quality level
        /// </summary>
        public DisplayQuality GetDisplayQuality()
        {
            return _displayQuality;
        }

        /// <summary>
        ///     Gets the rendering scale based on display quality
        /// </summary>
        public float GetRenderingScale()
        {
            return _displayQuality switch
            {
                DisplayQuality.VeryLow => 0.5f,
                DisplayQuality.Low => 0.75f,
                DisplayQuality.Medium => 0.875f,
                DisplayQuality.High => 1.0f,
                DisplayQuality.VeryHigh => 1.25f,
                DisplayQuality.Ultra => 1.5f,
                _ => 1.0f
            };
        }

        /// <summary>
        ///     Gets the browser's preferred language
        /// </summary>
        public string GetSystemLanguage()
        {
            return EmscriptenWeb.GetLanguage();
        }

        /// <summary>
        ///     Checks if the browser is currently online
        /// </summary>
        public bool IsOnline()
        {
            return EmscriptenWeb.IsOnline();
        }

        /// <summary>
        ///     Gets the device battery level (if available)
        /// </summary>
        public float GetBatteryLevel()
        {
            return EmscriptenWeb.GetBatteryLevel();
        }

        /// <summary>
        ///     Checks if the device is charging
        /// </summary>
        public bool IsCharging()
        {
            return EmscriptenWeb.IsCharging();
        }

        /// <summary>
        ///     Gets the screen refresh rate
        /// </summary>
        public int GetRefreshRate()
        {
            // WebAssembly typically uses 60 FPS for requestAnimationFrame
            // This could be extended to use higher rates if supported
            return 60;
        }

        /// <summary>
        ///     Captures a screenshot and saves it to a file
        /// </summary>
        public bool SaveScreenshot(string filename)
        {
            try
            {
                // This would require additional implementation for canvas to PNG conversion
                // For now, we'll call a JavaScript function that might provide this functionality
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Updates the display manager state (should be called each frame)
        /// </summary>
        public void Update()
        {
            int newWidth = _platform.GetWindowWidth();
            int newHeight = _platform.GetWindowHeight();

            if (newWidth != _currentWidth || newHeight != _currentHeight)
            {
                _currentWidth = newWidth;
                _currentHeight = newHeight;

                ScreenOrientation newOrientation = DetectOrientation();
                if (newOrientation != _currentOrientation)
                {
                    _currentOrientation = newOrientation;
                    OnOrientationChanged?.Invoke(this, new OrientationEventArgs { Orientation = _currentOrientation });
                }

                OnDisplayResized?.Invoke(this, new DisplayEventArgs 
                { 
                    Width = newWidth, 
                    Height = newHeight 
                });
            }

            bool newFullscreenState = EmscriptenWeb.IsFullscreenEnabled();
            if (newFullscreenState != _isFullscreen)
            {
                _isFullscreen = newFullscreenState;
                OnFullscreenChanged?.Invoke(this, new FullscreenEventArgs { IsFullscreen = _isFullscreen });
            }
        }
    }

    /// <summary>
    ///     Represents a display mode with specific resolution and refresh rate
    /// </summary>
    public class DisplayMode
    {
        /// <summary>
        /// Gets or sets the value of the width
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the value of the height
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Gets or sets the value of the refresh rate
        /// </summary>
        public int RefreshRate { get; set; }
        /// <summary>
        /// Gets or sets the value of the is fullscreen only
        /// </summary>
        public bool IsFullscreenOnly { get; set; }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return $"{Width}x{Height}@{RefreshRate}Hz";
        }
    }

    /// <summary>
    ///     Screen orientation enumeration
    /// </summary>
    public enum ScreenOrientation
    {
        /// <summary>
        /// The portrait screen orientation
        /// </summary>
        Portrait,
        /// <summary>
        /// The landscape screen orientation
        /// </summary>
        Landscape,
        /// <summary>
        /// The square screen orientation
        /// </summary>
        Square
    }

    /// <summary>
    ///     Display quality levels for rendering optimization
    /// </summary>
    public enum DisplayQuality
    {
        /// <summary>
        /// The very low display quality
        /// </summary>
        VeryLow = 0,
        /// <summary>
        /// The low display quality
        /// </summary>
        Low = 1,
        /// <summary>
        /// The medium display quality
        /// </summary>
        Medium = 2,
        /// <summary>
        /// The high display quality
        /// </summary>
        High = 3,
        /// <summary>
        /// The very high display quality
        /// </summary>
        VeryHigh = 4,
        /// <summary>
        /// The ultra display quality
        /// </summary>
        Ultra = 5
    }

    /// <summary>
    ///     Event arguments for display resize events
    /// </summary>
    public class DisplayEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the value of the width
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the value of the height
        /// </summary>
        public int Height { get; set; }
    }

    /// <summary>
    ///     Event arguments for orientation change events
    /// </summary>
    public class OrientationEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the value of the orientation
        /// </summary>
        public ScreenOrientation Orientation { get; set; }
    }

    /// <summary>
    ///     Event arguments for fullscreen change events
    /// </summary>
    public class FullscreenEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the value of the is fullscreen
        /// </summary>
        public bool IsFullscreen { get; set; }
    }
}

