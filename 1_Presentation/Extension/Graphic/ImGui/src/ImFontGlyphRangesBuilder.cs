// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRangesBuilder.cs
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
using System.Text;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font glyph ranges builder
    /// </summary>
    public struct ImFontGlyphRangesBuilder
    {
        /// <summary>
        ///     The used chars
        /// </summary>
        public ImVector UsedChars;
        
        
        /// <summary>
        ///     Adds the char using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddChar(ushort c)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_AddChar(ref this, c);
        }
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_Clear(ref this);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_destroy(ref this);
        }

        /// <summary>
        ///     Describes whether this instance get bit
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The bool</returns>
        public bool GetBit(uint n)
        {
            byte ret = ImGuiNative.ImFontGlyphRangesBuilder_GetBit(ref this, n);
            return ret != 0;
        }

        /// <summary>
        ///     Sets the bit using the specified n
        /// </summary>
        /// <param name="n">The </param>
        public void SetBit(uint n)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_SetBit(ref this, n);
        }
    }
}