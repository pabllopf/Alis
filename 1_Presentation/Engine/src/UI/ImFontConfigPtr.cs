// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ImFontConfigPtr.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.App.Engine.UI.Utils;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im font config ptr
    /// </summary>
    public unsafe struct ImFontConfigPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImFontConfig* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontConfigPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontConfigPtr(ImFontConfig* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontConfigPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontConfigPtr(IntPtr nativePtr) => NativePtr = (ImFontConfig*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfigPtr(ImFontConfig* nativePtr) => new ImFontConfigPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfig*(ImFontConfigPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfigPtr(IntPtr nativePtr) => new ImFontConfigPtr(nativePtr);

        /// <summary>
        ///     Gets or sets the value of the font data
        /// </summary>
        public IntPtr FontData
        {
            get => (IntPtr) NativePtr->FontData;
            set => NativePtr->FontData = (void*) value;
        }

        /// <summary>
        ///     Gets the value of the font data size
        /// </summary>
        public ref int FontDataSize => ref Unsafe.AsRef<int>(&NativePtr->FontDataSize);

        /// <summary>
        ///     Gets the value of the font data owned by atlas
        /// </summary>
        public ref bool FontDataOwnedByAtlas => ref Unsafe.AsRef<bool>(&NativePtr->FontDataOwnedByAtlas);

        /// <summary>
        ///     Gets the value of the font no
        /// </summary>
        public ref int FontNo => ref Unsafe.AsRef<int>(&NativePtr->FontNo);

        /// <summary>
        ///     Gets the value of the size pixels
        /// </summary>
        public ref float SizePixels => ref Unsafe.AsRef<float>(&NativePtr->SizePixels);

        /// <summary>
        ///     Gets the value of the oversample h
        /// </summary>
        public ref int OversampleH => ref Unsafe.AsRef<int>(&NativePtr->OversampleH);

        /// <summary>
        ///     Gets the value of the oversample v
        /// </summary>
        public ref int OversampleV => ref Unsafe.AsRef<int>(&NativePtr->OversampleV);

        /// <summary>
        ///     Gets the value of the pixel snap h
        /// </summary>
        public ref bool SnapH => ref Unsafe.AsRef<bool>(&NativePtr->SnapH);

        /// <summary>
        ///     Gets the value of the glyph extra spacing
        /// </summary>
        public ref Vector2 GlyphExtraSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphExtraSpacing);

        /// <summary>
        ///     Gets the value of the glyph offset
        /// </summary>
        public ref Vector2 GlyphOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphOffset);

        /// <summary>
        ///     Gets or sets the value of the glyph ranges
        /// </summary>
        public IntPtr GlyphRanges
        {
            get => (IntPtr) NativePtr->GlyphRanges;
            set => NativePtr->GlyphRanges = (ushort*) value;
        }

        /// <summary>
        ///     Gets the value of the glyph min advance x
        /// </summary>
        public ref float GlyphMinAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphMinAdvanceX);

        /// <summary>
        ///     Gets the value of the glyph max advance x
        /// </summary>
        public ref float GlyphMaxAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphMaxAdvanceX);

        /// <summary>
        ///     Gets the value of the merge mode
        /// </summary>
        public ref bool MergeMode => ref Unsafe.AsRef<bool>(&NativePtr->MergeMode);

        /// <summary>
        ///     Gets the value of the font builder flags
        /// </summary>
        public ref uint FontBuilderFlags => ref Unsafe.AsRef<uint>(&NativePtr->FontBuilderFlags);

        /// <summary>
        ///     Gets the value of the rasterizer multiply
        /// </summary>
        public ref float RasterizerMultiply => ref Unsafe.AsRef<float>(&NativePtr->RasterizerMultiply);

        /// <summary>
        ///     Gets the value of the ellipsis char
        /// </summary>
        public ref ushort EllipsisChar => ref Unsafe.AsRef<ushort>(&NativePtr->EllipsisChar);

        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public RangeAccessor<byte> Name => new RangeAccessor<byte>(NativePtr->Name, 40);

        /// <summary>
        ///     Gets the value of the dst font
        /// </summary>
        public ImFontPtr DstFont => new ImFontPtr(NativePtr->DstFont);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontConfig_destroy(NativePtr);
        }
    }
}