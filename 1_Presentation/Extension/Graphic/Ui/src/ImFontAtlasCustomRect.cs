// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasCustomRect.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font atlas custom rect
    /// </summary>
    public struct ImFontAtlasCustomRect
    {
        /// <summary>
        ///     The width
        /// </summary>
        public ushort Width { get; set; }

        /// <summary>
        ///     The height
        /// </summary>
        public ushort Height { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public ushort X { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public ushort Y { get; set; }

        /// <summary>
        ///     The glyph id
        /// </summary>
        public uint GlyphId { get; set; }

        /// <summary>
        ///     The glyph advance
        /// </summary>
        public float GlyphAdvanceX { get; set; }

        /// <summary>
        ///     The glyph offset
        /// </summary>
        public Vector2F GlyphOffset { get; set; }

        /// <summary>
        ///     The font
        /// </summary>
        public IntPtr Font { get; set; }
    }
}