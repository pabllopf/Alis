// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRangesBuilderPtr.cs
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

namespace Alis.Extension.ImGui
{
    /// <summary>
    ///     The im font glyph ranges builder ptr
    /// </summary>
    public readonly unsafe struct ImFontGlyphRangesBuilderPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImFontGlyphRangesBuilder* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontGlyphRangesBuilderPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontGlyphRangesBuilderPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphRangesBuilderPtr(IntPtr nativePtr) => NativePtr = (ImFontGlyphRangesBuilder*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr) => new ImFontGlyphRangesBuilderPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontGlyphRangesBuilder*(ImFontGlyphRangesBuilderPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontGlyphRangesBuilderPtr(IntPtr nativePtr) => new ImFontGlyphRangesBuilderPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the used chars
        /// </summary>
        public ImVector<uint> UsedChars => new ImVector<uint>(NativePtr->UsedChars);

        /// <summary>
        ///     Adds the char using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddChar(ushort c)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_AddChar(NativePtr, c);
        }

        /// <summary>
        ///     Adds the ranges using the specified ranges
        /// </summary>
        /// <param name="ranges">The ranges</param>
        public void AddRanges(IntPtr ranges)
        {
            ushort* nativeRanges = (ushort*) ranges.ToPointer();
            ImGuiNative.ImFontGlyphRangesBuilder_AddRanges(NativePtr, nativeRanges);
        }

        /// <summary>
        ///     Adds the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        public void AddText(string text)
        {
            byte* nativeText;
            int textByteCount = 0;
            if (text != null)
            {
                textByteCount = Encoding.UTF8.GetByteCount(text);
                if (textByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeText = Util.Allocate(textByteCount + 1);
                }
                else
                {
                    byte* nativeTextStackBytes = stackalloc byte[textByteCount + 1];
                    nativeText = nativeTextStackBytes;
                }

                int nativeTextOffset = Util.GetUtf8(text, nativeText, textByteCount);
                nativeText[nativeTextOffset] = 0;
            }
            else
            {
                nativeText = null;
            }

            byte* nativeTextEnd = null;
            ImGuiNative.ImFontGlyphRangesBuilder_AddText(NativePtr, nativeText, nativeTextEnd);
            if (textByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeText);
            }
        }

        /// <summary>
        ///     Builds the ranges using the specified out ranges
        /// </summary>
        /// <param name="outRanges">The out ranges</param>
        public void BuildRanges(out ImVector outRanges)
        {
            fixed (ImVector* nativeOutRanges = &outRanges)
            {
                ImGuiNative.ImFontGlyphRangesBuilder_BuildRanges(NativePtr, nativeOutRanges);
            }
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_Clear(NativePtr);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_destroy(NativePtr);
        }

        /// <summary>
        ///     Describes whether this instance get bit
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The bool</returns>
        public bool GetBit(uint n)
        {
            byte ret = ImGuiNative.ImFontGlyphRangesBuilder_GetBit(NativePtr, n);
            return ret != 0;
        }

        /// <summary>
        ///     Sets the bit using the specified n
        /// </summary>
        /// <param name="n">The </param>
        public void SetBit(uint n)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_SetBit(NativePtr, n);
        }
    }
}