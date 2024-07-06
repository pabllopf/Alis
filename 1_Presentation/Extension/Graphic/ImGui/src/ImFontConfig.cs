// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontConfig.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font config
    /// </summary>
    public struct ImFontConfig
    {
        /// <summary>
        ///     The font data
        /// </summary>
        public IntPtr FontData { get; set; }

        /// <summary>
        ///     The font data size
        /// </summary>
        public int FontDataSize { get; set; }

        /// <summary>
        ///     The font data owned by atlas
        /// </summary>
        public byte FontDataOwnedByAtlas { get; set; }

        /// <summary>
        ///     The font no
        /// </summary>
        public int FontNo { get; set; }

        /// <summary>
        ///     The size pixels
        /// </summary>
        public float SizePixels { get; set; }

        /// <summary>
        ///     The oversample
        /// </summary>
        public int OversampleH { get; set; }

        /// <summary>
        ///     The oversample
        /// </summary>
        public int OversampleV { get; set; }

        /// <summary>
        ///     The pixel snap
        /// </summary>
        public byte SnapH { get; set; }

        /// <summary>
        ///     The glyph extra spacing
        /// </summary>
        public Vector2 GlyphExtraSpacing { get; set; }

        /// <summary>
        ///     The glyph offset
        /// </summary>
        public Vector2 GlyphOffset { get; set; }

        /// <summary>
        ///     The glyph ranges
        /// </summary>
        public IntPtr GlyphRanges { get; set; }

        /// <summary>
        ///     The glyph min advance
        /// </summary>
        public float GlyphMinAdvanceX { get; set; }

        /// <summary>
        ///     The glyph max advance
        /// </summary>
        public float GlyphMaxAdvanceX { get; set; }

        /// <summary>
        ///     The merge mode
        /// </summary>
        public byte MergeMode { get; set; }

        /// <summary>
        ///     The font builder flags
        /// </summary>
        public uint FontBuilderFlags { get; set; }

        /// <summary>
        ///     The rasterizer multiply
        /// </summary>
        public float RasterizerMultiply { get; set; }

        /// <summary>
        ///     The ellipsis char
        /// </summary>
        public ushort EllipsisChar { get; set; }

        /// <summary>
        ///     The name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public byte[] Name;

        /// <summary>
        ///     The dst font
        /// </summary>
        public IntPtr DstFont { get; set; }
    }
}