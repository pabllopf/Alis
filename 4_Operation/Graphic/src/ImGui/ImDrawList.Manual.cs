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
        /// <param name="textBegin">The text begin</param>
        public void AddText(Vector2 pos, uint col, string textBegin)
        {
            int textBeginByteCount = Encoding.UTF8.GetByteCount(textBegin);
            byte* nativeTextBegin = stackalloc byte[textBeginByteCount + 1];
            fixed (char* textBeginPtr = textBegin)
            {
                int nativeTextBeginOffset = Encoding.UTF8.GetBytes(textBeginPtr, textBegin.Length, nativeTextBegin, textBeginByteCount);
                nativeTextBegin[nativeTextBeginOffset] = 0;
            }

            byte* nativeTextEnd = null;
            ImGuiNative.ImDrawList_AddText_Vec2(NativePtr, pos, col, nativeTextBegin, nativeTextEnd);
        }

        /// <summary>
        ///     Adds the text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        public void AddText(ImFontPtr font, float fontSize, Vector2 pos, uint col, string textBegin)
        {
            ImFont* nativeFont = font.NativePtr;
            int textBeginByteCount = Encoding.UTF8.GetByteCount(textBegin);
            byte* nativeTextBegin = stackalloc byte[textBeginByteCount + 1];
            fixed (char* textBeginPtr = textBegin)
            {
                int nativeTextBeginOffset = Encoding.UTF8.GetBytes(textBeginPtr, textBegin.Length, nativeTextBegin, textBeginByteCount);
                nativeTextBegin[nativeTextBeginOffset] = 0;
            }

            byte* nativeTextEnd = null;
            float wrapWidth = 0.0f;
            Vector4* cpuFineClipRect = null;
            ImGuiNative.ImDrawList_AddText_FontPtr(NativePtr, nativeFont, fontSize, pos, col, nativeTextBegin, nativeTextEnd, wrapWidth, cpuFineClipRect);
        }
    }
}