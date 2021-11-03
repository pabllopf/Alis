// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Windows.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region

using System;
using System.Numerics;
using System.Text.Json.Serialization;
using Alis.Core.Entities;

#endregion

namespace Alis.Core.Settings.Configurations
{
    /// <summary>
    ///     The window class
    /// </summary>
    public class Window
    {
        #region Reset()

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            Resolution = new Vector2(1024, 768);
            ScreenMode = ScreenMode.Default;
        }

        #endregion

        #region Fields

        /// <summary>
        ///     The resolution
        /// </summary>
        private Vector2 resolution = new(1024, 768);

        /// <summary>
        ///     The default
        /// </summary>
        private ScreenMode screenMode = ScreenMode.Default;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Window" /> class
        /// </summary>
        public Window()
        {
            OnChangeResolution += Window_OnChangeResolution;
            OnChangeScreenMode += Window_OnChangeScreenMode;

            Resolution = resolution;
            ScreenMode = screenMode;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Window" /> class
        /// </summary>
        /// <param name="resolution">The resolution</param>
        /// <param name="screenMode">The screen mode</param>
        [JsonConstructor]
        public Window(Vector2 resolution, ScreenMode screenMode)
        {
            OnChangeResolution += Window_OnChangeResolution;
            OnChangeScreenMode += Window_OnChangeScreenMode;

            Resolution = resolution;
            ScreenMode = screenMode;
        }

        #endregion

        #region Events

        public event EventHandler<Vector2> OnChangeResolution;

        public event EventHandler<ScreenMode> OnChangeScreenMode;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        [JsonPropertyName("_Resolution")]
        public Vector2 Resolution
        {
            get => resolution;
            set
            {
                resolution = value;
                OnChangeResolution?.Invoke(this, resolution);
            }
        }

        /// <summary>
        ///     Gets or sets the value of the screen mode
        /// </summary>
        [JsonPropertyName("_ScreenMode")]
        public ScreenMode ScreenMode
        {
            get => screenMode;
            set
            {
                screenMode = value;
                OnChangeScreenMode?.Invoke(this, screenMode);
            }
        }

        #endregion

        #region DefaultEvents

        /// <summary>
        ///     Windows the on change resolution using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void Window_OnChangeResolution(object? sender, Vector2 e)
        {
        }

        /// <summary>
        ///     Windows the on change screen mode using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void Window_OnChangeScreenMode(object? sender, ScreenMode e)
        {
        }

        #endregion
    }
}