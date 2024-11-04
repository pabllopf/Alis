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

namespace Alis.Core.Graphic.Fonts
{
    public class Font
    {
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
        
        public Font(string fontName, int fontSize, IntPtr texture, IntPtr surface, Dictionary<char, RectangleI> characterRects)
        {
            Name = fontName;
            Size = fontSize;
            Texture = texture;
            Surface = surface;
            CharacterRects = characterRects;
        }
        
        public string Name { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public Color BackgroundColor { get; set; }
        public IntPtr Texture { get; }
        public IntPtr Surface { get; }
        public Dictionary<char, RectangleI> CharacterRects { get; }
    }
}