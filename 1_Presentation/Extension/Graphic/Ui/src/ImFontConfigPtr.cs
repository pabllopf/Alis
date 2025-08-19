// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontConfigPtr.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font config ptr
    /// </summary>
    public readonly struct ImFontConfigPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontConfigPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontConfigPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontConfigPtr" /> class
        /// </summary>
        /// <param name="fontConfig">The font config</param>
        public ImFontConfigPtr(ImFontConfig fontConfig)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            Marshal.StructureToPtr(fontConfig, NativePtr, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImFontConfigPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfigPtr(IntPtr nativePtr) => new ImFontConfigPtr(nativePtr);

        /// <summary>
        ///     Gets or sets the value of the font data
        /// </summary>
        public IntPtr FontData => Marshal.PtrToStructure<ImFontConfig>(NativePtr).FontData;

        /// <summary>
        ///     Gets the value of the font data size
        /// </summary>
        public int FontDataSize => Marshal.PtrToStructure<ImFontConfig>(NativePtr).FontDataSize;

        /// <summary>
        ///     Gets the value of the font data owned by atlas
        /// </summary>
        public bool FontDataOwnedByAtlas => Marshal.PtrToStructure<ImFontConfig>(NativePtr).FontDataOwnedByAtlas != 0;

        /// <summary>
        ///     Gets the value of the font no
        /// </summary>
        public int FontNo => Marshal.PtrToStructure<ImFontConfig>(NativePtr).FontNo;

        /// <summary>
        ///     Gets the value of the size pixels
        /// </summary>
        public float SizePixels => Marshal.PtrToStructure<ImFontConfig>(NativePtr).SizePixels;

        /// <summary>
        ///     Gets the value of the oversample h
        /// </summary>
        public int OversampleH => Marshal.PtrToStructure<ImFontConfig>(NativePtr).OversampleH;

        /// <summary>
        ///     Gets the value of the oversample v
        /// </summary>
        public int OversampleV => Marshal.PtrToStructure<ImFontConfig>(NativePtr).OversampleV;

        /// <summary>
        ///     Gets the value of the pixel snap h
        /// </summary>
        public bool SnapH
        {
            get => Marshal.PtrToStructure<ImFontConfig>(NativePtr).SnapH != 0;
            set
            {
                ImFontConfig config = Marshal.PtrToStructure<ImFontConfig>(NativePtr);
                config.SnapH = (byte) (value ? 1 : 0);
                Marshal.StructureToPtr(config, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the glyph extra spacing
        /// </summary>
        public Vector2F GlyphExtraSpacing => Marshal.PtrToStructure<ImFontConfig>(NativePtr).GlyphExtraSpacing;

        /// <summary>
        ///     Gets the value of the glyph offset
        /// </summary>
        public Vector2F GlyphOffset => Marshal.PtrToStructure<ImFontConfig>(NativePtr).GlyphOffset;

        /// <summary>
        ///     Gets or sets the value of the glyph ranges
        /// </summary>
        public IntPtr GlyphRanges
        {
            get => Marshal.PtrToStructure<ImFontConfig>(NativePtr).GlyphRanges;
            set
            {
                ImFontConfig config = Marshal.PtrToStructure<ImFontConfig>(NativePtr);
                config.GlyphRanges = value;
                Marshal.StructureToPtr(config, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the glyph min advance x
        /// </summary>
        public float GlyphMinAdvanceX
        {
            get => Marshal.PtrToStructure<ImFontConfig>(NativePtr).GlyphMinAdvanceX;
            set
            {
                ImFontConfig config = Marshal.PtrToStructure<ImFontConfig>(NativePtr);
                config.GlyphMinAdvanceX = value;
                Marshal.StructureToPtr(config, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the glyph max advance x
        /// </summary>
        public float GlyphMaxAdvanceX => Marshal.PtrToStructure<ImFontConfig>(NativePtr).GlyphMaxAdvanceX;

        /// <summary>
        ///     Gets the value of the merge mode
        /// </summary>
        public bool MergeMode
        {
            get => Marshal.PtrToStructure<ImFontConfig>(NativePtr).MergeMode != 0;
            set
            {
                ImFontConfig config = Marshal.PtrToStructure<ImFontConfig>(NativePtr);
                config.MergeMode = (byte) (value ? 1 : 0);
                Marshal.StructureToPtr(config, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the font builder flags
        /// </summary>
        public uint FontBuilderFlags => Marshal.PtrToStructure<ImFontConfig>(NativePtr).FontBuilderFlags;

        /// <summary>
        ///     Gets the value of the rasterizer multiply
        /// </summary>
        public float RasterizerMultiply => Marshal.PtrToStructure<ImFontConfig>(NativePtr).RasterizerMultiply;

        /// <summary>
        ///     Gets the value of the ellipsis char
        /// </summary>
        public ushort EllipsisChar => Marshal.PtrToStructure<ImFontConfig>(NativePtr).EllipsisChar;

        /// <summary>
        ///     Gets the value of the dst font
        /// </summary>
        public ImFontPtr DstFont => Marshal.PtrToStructure<ImFontConfig>(NativePtr).DstFont;
    }
}