// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtr.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font ptr
    /// </summary>
    public readonly struct ImFontPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontPtr(IntPtr nativePtr) => NativePtr = nativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImFontPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontPtr(IntPtr nativePtr) => new ImFontPtr(nativePtr);
        
        /// <summary>
        ///     Gets the value of the index advance x
        /// </summary>
        public ImVectorG<float> IndexAdvanceX => Marshal.PtrToStructure<ImVectorG<float>>(NativePtr);
        
        /// <summary>
        ///     Gets the value of the fallback advance x
        /// </summary>
        public float FallbackAdvanceX => Marshal.PtrToStructure<float>(NativePtr + 16);
        
        /// <summary>
        ///     Gets the value of the font size
        /// </summary>
        public  float FontSize => Marshal.PtrToStructure<float>(NativePtr + 20);
        
        /// <summary>
        ///     Gets the value of the index lookup
        /// </summary>
        public ImVectorG<ushort> IndexLookup => Marshal.PtrToStructure<ImVectorG<ushort>>(NativePtr + 24);
        
        /// <summary>
        ///     Gets the value of the container atlas
        /// </summary>
        public ImFontAtlasPtr ContainerAtlas => Marshal.PtrToStructure<ImFontAtlasPtr>(NativePtr + 40);
        
        /// <summary>
        ///     Gets the value of the config data
        /// </summary>
        public ImFontConfigPtr ConfigData => Marshal.PtrToStructure<ImFontConfigPtr>(NativePtr + 48);
        
        /// <summary>
        ///     Gets the value of the config data count
        /// </summary>
        public  short ConfigDataCount => Marshal.PtrToStructure<short>(NativePtr + 56);
        
        /// <summary>
        ///     Gets the value of the fallback char
        /// </summary>
        public ushort FallbackChar => Marshal.PtrToStructure<ushort>(NativePtr + 58);
        
        /// <summary>
        ///     Gets the value of the ellipsis char
        /// </summary>
        public ushort EllipsisChar => Marshal.PtrToStructure<ushort>(NativePtr + 60);
        
        /// <summary>
        ///     Gets the value of the dot char
        /// </summary>
        public ushort DotChar => Marshal.PtrToStructure<ushort>(NativePtr + 62);
        
        /// <summary>
        ///     Gets the value of the dirty lookup tables
        /// </summary>
        public  bool DirtyLookupTables => Marshal.PtrToStructure<byte>(NativePtr + 64) != 0;
        
        /// <summary>
        ///     Gets the value of the scale
        /// </summary>
        public float Scale => Marshal.PtrToStructure<float>(NativePtr + 68);
        
        /// <summary>
        ///     Gets the value of the ascent
        /// </summary>
        public float Ascent => Marshal.PtrToStructure<float>(NativePtr + 72);
        
        /// <summary>
        ///     Gets the value of the descent
        /// </summary>
        public  float Descent => Marshal.PtrToStructure<float>(NativePtr + 76);
        
        /// <summary>
        ///     Gets the value of the metrics total surface
        /// </summary>
        public int MetricsTotalSurface => Marshal.PtrToStructure<int>(NativePtr + 80);
        
        /// <summary>
        ///     Gets the value of the used 4k pages map
        /// </summary>
        public RangeAccessor<byte> Used4KPagesMap => new RangeAccessor<byte>(NativePtr + 84, 2);
        
        /// <summary>
        ///     Adds the glyph using the specified src cfg
        /// </summary>
        /// <param name="srcCfg">The src cfg</param>
        /// <param name="c">The </param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="u0">The </param>
        /// <param name="v0">The </param>
        /// <param name="u1">The </param>
        /// <param name="v1">The </param>
        /// <param name="advanceX">The advance</param>
        public void AddGlyph(ImFontConfigPtr srcCfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advanceX)
        {
   
            ImGuiNative.ImFont_AddGlyph((IntPtr)NativePtr, srcCfg.NativePtr, c, x0, y0, x1, y1, u0, v0, u1, v1, advanceX);
        }
        
        /// <summary>
        ///     Adds the remap char using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        public void AddRemapChar(ushort dst, ushort src)
        {
            byte overwriteDst = 1;
            ImGuiNative.ImFont_AddRemapChar((IntPtr)NativePtr, dst, src, overwriteDst);
        }
        
        /// <summary>
        ///     Adds the remap char using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="overwriteDst">The overwrite dst</param>
        public void AddRemapChar(ushort dst, ushort src, bool overwriteDst)
        {
            byte nativeOverwriteDst = overwriteDst ? (byte) 1 : (byte) 0;
            ImGuiNative.ImFont_AddRemapChar((IntPtr)NativePtr, dst, src, nativeOverwriteDst);
        }
        
        /// <summary>
        ///     Builds the lookup table
        /// </summary>
        public void BuildLookupTable()
        {
            ImGuiNative.ImFont_BuildLookupTable((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Clears the output data
        /// </summary>
        public void ClearOutputData()
        {
            ImGuiNative.ImFont_ClearOutputData((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFont_destroy((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Finds the glyph using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyph FindGlyph(ushort c) => ImGuiNative.ImFont_FindGlyph((IntPtr)NativePtr, c);
        
        /// <summary>
        ///     Finds the glyph no fallback using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyph FindGlyphNoFallback(ushort c) => ImGuiNative.ImFont_FindGlyphNoFallback((IntPtr)NativePtr, c);
        
        /// <summary>
        ///     Gets the char advance using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The ret</returns>
        public float GetCharAdvance(ushort c)
        {
            float ret = ImGuiNative.ImFont_GetCharAdvance((IntPtr)NativePtr, c);
            return ret;
        }
        
        /// <summary>
        ///     Gets the debug name
        /// </summary>
        /// <returns>The string</returns>
        public string GetDebugName()
        {
            return Encoding.UTF8.GetString(ImGuiNative.ImFont_GetDebugName((IntPtr) NativePtr));
        }
        
        /// <summary>
        ///     Grows the index using the specified new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        public void GrowIndex(int newSize)
        {
            ImGuiNative.ImFont_GrowIndex((IntPtr)NativePtr, newSize);
        }
        
        /// <summary>
        ///     Describes whether this instance is loaded
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsLoaded()
        {
            byte ret = ImGuiNative.ImFont_IsLoaded((IntPtr)NativePtr);
            return ret != 0;
        }
        
        /// <summary>
        ///     Renders the char using the specified draw list
        /// </summary>
        /// <param name="drawList">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="c">The </param>
        public unsafe void RenderChar(ImDrawListPtr drawList, float size, Vector2 pos, uint col, ushort c)
        {
            ImGuiNative.ImFont_RenderChar((IntPtr)NativePtr, (IntPtr)drawList.NativePtr, size, pos, col, c);
        }
        
        /// <summary>
        ///     Sets the glyph visible using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="visible">The visible</param>
        public void SetGlyphVisible(ushort c, bool visible)
        {
            byte nativeVisible = visible ? (byte) 1 : (byte) 0;
            ImGuiNative.ImFont_SetGlyphVisible((IntPtr)NativePtr, c, nativeVisible);
        }
    }
}