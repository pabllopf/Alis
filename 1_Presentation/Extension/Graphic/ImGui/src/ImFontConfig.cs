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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font config
    /// </summary>
    public unsafe struct ImFontConfig
    {
        /// <summary>
        ///     The font data
        /// </summary>
        public void* FontData;
        
        /// <summary>
        ///     The font data size
        /// </summary>
        public int FontDataSize;
        
        /// <summary>
        ///     The font data owned by atlas
        /// </summary>
        public byte FontDataOwnedByAtlas;
        
        /// <summary>
        ///     The font no
        /// </summary>
        public int FontNo;
        
        /// <summary>
        ///     The size pixels
        /// </summary>
        public float SizePixels;
        
        /// <summary>
        ///     The oversample
        /// </summary>
        public int OversampleH;
        
        /// <summary>
        ///     The oversample
        /// </summary>
        public int OversampleV;
        
        /// <summary>
        ///     The pixel snap
        /// </summary>
        public byte SnapH;
        
        /// <summary>
        ///     The glyph extra spacing
        /// </summary>
        public Vector2 GlyphExtraSpacing;
        
        /// <summary>
        ///     The glyph offset
        /// </summary>
        public Vector2 GlyphOffset;
        
        /// <summary>
        ///     The glyph ranges
        /// </summary>
        public ushort* GlyphRanges;
        
        /// <summary>
        ///     The glyph min advance
        /// </summary>
        public float GlyphMinAdvanceX;
        
        /// <summary>
        ///     The glyph max advance
        /// </summary>
        public float GlyphMaxAdvanceX;
        
        /// <summary>
        ///     The merge mode
        /// </summary>
        public byte MergeMode;
        
        /// <summary>
        ///     The font builder flags
        /// </summary>
        public uint FontBuilderFlags;
        
        /// <summary>
        ///     The rasterizer multiply
        /// </summary>
        public float RasterizerMultiply;
        
        /// <summary>
        ///     The ellipsis char
        /// </summary>
        public ushort EllipsisChar;
        
        /// <summary>
        ///     The name
        /// </summary>
        public fixed byte Name[40];
        
        /// <summary>
        ///     The dst font
        /// </summary>
        public IntPtr DstFont;
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontConfig_destroy(this);
        }
    }
}