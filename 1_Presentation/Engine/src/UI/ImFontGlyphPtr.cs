// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphPtr.cs
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
using Alis.Core.Graphic.UI.Utils;

namespace Alis.Core.Graphic.UI
{
    /// <summary>
    ///     The im font glyph ptr
    /// </summary>
    public unsafe struct ImFontGlyphPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImFontGlyph* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontGlyphPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphPtr(ImFontGlyph* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontGlyphPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphPtr(IntPtr nativePtr) => NativePtr = (ImFontGlyph*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontGlyphPtr(ImFontGlyph* nativePtr) => new ImFontGlyphPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontGlyph*(ImFontGlyphPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontGlyphPtr(IntPtr nativePtr) => new ImFontGlyphPtr(nativePtr);


        /// <summary>
        ///     Gets the value of the colored
        /// </summary>
        public ref uint Colored => ref Unsafe.AsRef<uint>(&NativePtr->Colored);

        /// <summary>
        ///     Gets the value of the visible
        /// </summary>
        public ref uint Visible => ref Unsafe.AsRef<uint>(&NativePtr->Visible);

        /// <summary>
        ///     Gets the value of the codepoint
        /// </summary>
        public ref uint Codepoint => ref Unsafe.AsRef<uint>(&NativePtr->Codepoint);

        /// <summary>
        ///     Gets the value of the advance x
        /// </summary>
        public ref float AdvanceX => ref Unsafe.AsRef<float>(&NativePtr->AdvanceX);

        /// <summary>
        ///     Gets the value of the x 0
        /// </summary>
        public ref float X0 => ref Unsafe.AsRef<float>(&NativePtr->X0);

        /// <summary>
        ///     Gets the value of the y 0
        /// </summary>
        public ref float Y0 => ref Unsafe.AsRef<float>(&NativePtr->Y0);

        /// <summary>
        ///     Gets the value of the x 1
        /// </summary>
        public ref float X1 => ref Unsafe.AsRef<float>(&NativePtr->X1);

        /// <summary>
        ///     Gets the value of the y 1
        /// </summary>
        public ref float Y1 => ref Unsafe.AsRef<float>(&NativePtr->Y1);

        /// <summary>
        ///     Gets the value of the u 0
        /// </summary>
        public ref float U0 => ref Unsafe.AsRef<float>(&NativePtr->U0);

        /// <summary>
        ///     Gets the value of the v 0
        /// </summary>
        public ref float V0 => ref Unsafe.AsRef<float>(&NativePtr->V0);

        /// <summary>
        ///     Gets the value of the u 1
        /// </summary>
        public ref float U1 => ref Unsafe.AsRef<float>(&NativePtr->U1);

        /// <summary>
        ///     Gets the value of the v 1
        /// </summary>
        public ref float V1 => ref Unsafe.AsRef<float>(&NativePtr->V1);
    }
}