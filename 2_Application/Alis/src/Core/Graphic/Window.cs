// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Window.cs
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

using Alis.Builder.Core.Graphic;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic
{
    /// <summary>
    ///     The window class
    /// </summary>
    /// <seealso cref="IBuilder{WindowBuilder}" />
    public class Window :
        IWindow,
        IBuilder<WindowBuilder>
    {
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The window builder</returns>
        public WindowBuilder Builder() => new WindowBuilder();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class
        /// </summary>
        public Window()
        {
            Background = Color.Black;
            Resolution = new Vector2(640, 480);
            IsWindowResizable = true;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class
        /// </summary>
        /// <param name="background">The background</param>
        /// <param name="resolution">The resolution</param>
        /// <param name="isWindowResizable">The is window resizable</param>
        [JsonConstructor]
        public Window(Color background, Vector2 resolution, bool isWindowResizable)
        {
            Background = background;
            Resolution = resolution;
            IsWindowResizable = isWindowResizable;
        }
        
        /// <summary>
        ///     Gets or sets the value of the background
        /// </summary>
        [JsonPropertyName("_Background_")]
        public Color Background { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        [JsonPropertyName("_Resolution_")]
        public Vector2 Resolution { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the is window resizable
        /// </summary>
        [JsonPropertyName("_IsWindowResizable_")]
        public bool IsWindowResizable { get; set; }
    }
}