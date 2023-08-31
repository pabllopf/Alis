// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasCustomRectPtr.cs
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
using Alis.Core.Graphic.UI.Utils;

namespace Alis.Core.Graphic.UI
{
    /// <summary>
    ///     The im font atlas custom rect ptr
    /// </summary>
    public unsafe struct ImFontAtlasCustomRectPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImFontAtlasCustomRect* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasCustomRectPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasCustomRectPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasCustomRectPtr(IntPtr nativePtr) => NativePtr = (ImFontAtlasCustomRect*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr) => new ImFontAtlasCustomRectPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasCustomRect*(ImFontAtlasCustomRectPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasCustomRectPtr(IntPtr nativePtr) => new ImFontAtlasCustomRectPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the width
        /// </summary>
        public ref ushort Width => ref Unsafe.AsRef<ushort>(&NativePtr->Width);

        /// <summary>
        ///     Gets the value of the height
        /// </summary>
        public ref ushort Height => ref Unsafe.AsRef<ushort>(&NativePtr->Height);

        /// <summary>
        ///     Gets the value of the x
        /// </summary>
        public ref ushort X => ref Unsafe.AsRef<ushort>(&NativePtr->X);

        /// <summary>
        ///     Gets the value of the y
        /// </summary>
        public ref ushort Y => ref Unsafe.AsRef<ushort>(&NativePtr->Y);

        /// <summary>
        ///     Gets the value of the glyph id
        /// </summary>
        public ref uint GlyphId => ref Unsafe.AsRef<uint>(&NativePtr->GlyphId);

        /// <summary>
        ///     Gets the value of the glyph advance x
        /// </summary>
        public ref float GlyphAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphAdvanceX);

        /// <summary>
        ///     Gets the value of the glyph offset
        /// </summary>
        public ref Vector2 GlyphOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphOffset);

        /// <summary>
        ///     Gets the value of the font
        /// </summary>
        public ImFontPtr Font => new ImFontPtr(NativePtr->Font);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontAtlasCustomRect_destroy(NativePtr);
        }

        /// <summary>
        ///     Describes whether this instance is packed
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsPacked()
        {
            byte ret = ImGuiNative.ImFontAtlasCustomRect_IsPacked(NativePtr);
            return ret != 0;
        }
    }
}