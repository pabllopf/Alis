// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawList.Manual.cs
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

using System.Numerics;
using System.Text;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im draw list ptr
    /// </summary>
    public unsafe partial struct ImDrawListPtr
    {
        /// <summary>
        ///     Adds the text using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="text_begin">The text begin</param>
        public void AddText(Vector2 pos, uint col, string text_begin)
        {
            int text_begin_byteCount = Encoding.UTF8.GetByteCount(text_begin);
            byte* native_text_begin = stackalloc byte[text_begin_byteCount + 1];
            fixed (char* text_begin_ptr = text_begin)
            {
                int native_text_begin_offset = Encoding.UTF8.GetBytes(text_begin_ptr, text_begin.Length, native_text_begin, text_begin_byteCount);
                native_text_begin[native_text_begin_offset] = 0;
            }

            byte* native_text_end = null;
            ImGuiNative.ImDrawList_AddText_Vec2(NativePtr, pos, col, native_text_begin, native_text_end);
        }

        /// <summary>
        ///     Adds the text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="font_size">The font size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="text_begin">The text begin</param>
        public void AddText(ImFontPtr font, float font_size, Vector2 pos, uint col, string text_begin)
        {
            ImFont* native_font = font.NativePtr;
            int text_begin_byteCount = Encoding.UTF8.GetByteCount(text_begin);
            byte* native_text_begin = stackalloc byte[text_begin_byteCount + 1];
            fixed (char* text_begin_ptr = text_begin)
            {
                int native_text_begin_offset = Encoding.UTF8.GetBytes(text_begin_ptr, text_begin.Length, native_text_begin, text_begin_byteCount);
                native_text_begin[native_text_begin_offset] = 0;
            }

            byte* native_text_end = null;
            float wrap_width = 0.0f;
            Vector4* cpu_fine_clip_rect = null;
            ImGuiNative.ImDrawList_AddText_FontPtr(NativePtr, native_font, font_size, pos, col, native_text_begin, native_text_end, wrap_width, cpu_fine_clip_rect);
        }
    }
}