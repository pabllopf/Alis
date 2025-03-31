// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Font.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;

namespace Alis.Benchmark.CustomEcs.EcsOld.System.Manager.Fonts
{
    /// <summary>
    ///     The font class
    /// </summary>
    public class Font
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Font" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="size">The size</param>
        /// <param name="color">The color</param>
        /// <param name="backgroundColor">The background color</param>
        /// <param name="texture">The texture</param>
        /// <param name="surface">The surface</param>
        /// <param name="characterRects">The character rects</param>
        public Font(string name, int size, Color color, Color backgroundColor, IntPtr texture, IntPtr surface, Dictionary<char, RectangleI> characterRects)
        {
            Name = name;
            Size = size;
            Color = color;
            BackgroundColor = backgroundColor;
            Texture = texture;
            Surface = surface;
            CharacterRects = characterRects;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Font" /> class
        /// </summary>
        /// <param name="fontName">The font name</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="texture">The texture</param>
        /// <param name="surface">The surface</param>
        /// <param name="characterRects">The character rects</param>
        public Font(string fontName, int fontSize, IntPtr texture, IntPtr surface, Dictionary<char, RectangleI> characterRects)
        {
            Name = fontName;
            Size = fontSize;
            Texture = texture;
            Surface = surface;
            CharacterRects = characterRects;
        }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        ///     Gets or sets the value of the background color
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        ///     Gets the value of the texture
        /// </summary>
        public IntPtr Texture { get; }

        /// <summary>
        ///     Gets the value of the surface
        /// </summary>
        public IntPtr Surface { get; }

        /// <summary>
        ///     Gets the value of the character rects
        /// </summary>
        public Dictionary<char, RectangleI> CharacterRects { get; }
    }
}