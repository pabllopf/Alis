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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui
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
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImFontConfigPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfigPtr(IntPtr nativePtr) => new ImFontConfigPtr(nativePtr);
        
        public IntPtr FontData
        {
            get => Marshal.ReadIntPtr(NativePtr);
            set => Marshal.WriteIntPtr(NativePtr, value);
        }
        
        /// <summary>
        ///     Gets the value of the font data size
        /// </summary>
        public int FontDataSize => Marshal.ReadInt32(NativePtr, IntPtr.Size);
        
        /// <summary>
        ///     Gets the value of the font data owned by atlas
        /// </summary>
        public bool FontDataOwnedByAtlas => Convert.ToBoolean(Marshal.ReadByte(NativePtr, IntPtr.Size + sizeof(int)));
        
        /// <summary>
        ///     Gets the value of the font no
        /// </summary>
        public int FontNo => Marshal.ReadInt32(NativePtr, IntPtr.Size + sizeof(int) + sizeof(byte)); 
        
        /// <summary>
        ///     Gets the value of the size pixels
        /// </summary>
        public float SizePixels => Marshal.PtrToStructure<float>(NativePtr + IntPtr.Size + sizeof(int) + sizeof(byte) + sizeof(int));
        
        /// <summary>
        ///     Gets the value of the oversample h
        /// </summary>
        public int OversampleH => Marshal.ReadInt32(NativePtr + IntPtr.Size + sizeof(int) + sizeof(byte) + sizeof(int) + sizeof(float)); 
        
        /// <summary>
        ///     Gets the value of the oversample v
        /// </summary>
        public int OversampleV => Marshal.ReadInt32(NativePtr + IntPtr.Size + sizeof(int) + sizeof(byte) + sizeof(int) + sizeof(float) + sizeof(int));
        
        /// <summary>
        ///     Gets the value of the pixel snap h
        /// </summary>
        public bool SnapH => Convert.ToBoolean(Marshal.ReadByte(NativePtr + IntPtr.Size + sizeof(int) + sizeof(byte) + sizeof(int) + sizeof(float) + sizeof(int) + sizeof(int)));
        
        /// <summary>
        ///     Gets the value of the glyph extra spacing
        /// </summary>
        public Vector2 GlyphExtraSpacing => Marshal.PtrToStructure<Vector2>(NativePtr + IntPtr.Size + sizeof(int) + sizeof(byte) + sizeof(int) + sizeof(float) + sizeof(int) + sizeof(int) + sizeof(byte));
        
        /// <summary>
        ///     Gets the value of the glyph offset
        /// </summary>
        public Vector2 GlyphOffset => Marshal.PtrToStructure<Vector2>(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>());
        
        /// <summary>
        ///     Gets or sets the value of the glyph ranges
        /// </summary>
        public IntPtr GlyphRanges
        {
            get => Marshal.ReadIntPtr(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>());
            set => Marshal.WriteIntPtr(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>(), value);
        }
        
        /// <summary>
        ///     Gets the value of the glyph min advance x
        /// </summary>
        public float GlyphMinAdvanceX => Marshal.PtrToStructure<float>(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size);
        
        /// <summary>
        ///     Gets the value of the glyph max advance x
        /// </summary>
        public float GlyphMaxAdvanceX => Marshal.PtrToStructure<float>(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size + sizeof(float));
        
        /// <summary>
        ///     Gets the value of the merge mode
        /// </summary>
        public bool MergeMode => Convert.ToBoolean(Marshal.ReadByte(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size + sizeof(float) + sizeof(float)));
        
        /// <summary>
        ///     Gets the value of the font builder flags
        /// </summary>
        public uint FontBuilderFlags => (uint)Marshal.ReadInt32(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size + sizeof(float) + sizeof(float) + sizeof(byte));
        
        /// <summary>
        ///     Gets the value of the rasterizer multiply
        /// </summary>
        public float RasterizerMultiply => Marshal.PtrToStructure<float>(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(uint));
        
        /// <summary>
        ///     Gets the value of the ellipsis char
        /// </summary>
        public ushort EllipsisChar => (ushort)Marshal.ReadInt16(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(uint) + sizeof(float));
        
        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public RangeAccessor<byte> Name => new RangeAccessor<byte>(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(uint) + sizeof(float) + sizeof(ushort), 40);
        
        /// <summary>
        ///     Gets the value of the dst font
        /// </summary>
        public ImFontPtr DstFont => new ImFontPtr(Marshal.ReadIntPtr(NativePtr + IntPtr.Size + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<int>() + Marshal.SizeOf<float>() + Marshal.SizeOf<int>() + Marshal.SizeOf<int>() + Marshal.SizeOf<byte>() + Marshal.SizeOf<Vector2>() + Marshal.SizeOf<Vector2>() + IntPtr.Size + sizeof(float) + sizeof(float) + sizeof(byte) + sizeof(uint) + sizeof(float) + sizeof(ushort) + 40));
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontConfig_destroy((IntPtr)NativePtr);
        }
    }
}