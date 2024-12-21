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
        ///     Initializes a new instance of the <see cref="ImFontPtr" /> class
        /// </summary>
        /// <param name="font">The font</param>
        public ImFontPtr(ImFont font)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            Marshal.StructureToPtr(font, NativePtr, false);
        }

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
        public ImVectorG<float> IndexAdvanceX => new ImVectorG<float>(Marshal.PtrToStructure<ImFont>(NativePtr).IndexAdvanceX);

        /// <summary>
        ///     Gets the value of the fallback advance x
        /// </summary>
        public float FallbackAdvanceX => Marshal.PtrToStructure<ImFont>(NativePtr).FallbackAdvanceX;

        /// <summary>
        ///     Gets the value of the font size
        /// </summary>
        public float FontSize => Marshal.PtrToStructure<ImFont>(NativePtr).FontSize;

        /// <summary>
        ///     Gets the value of the index lookup
        /// </summary>
        public ImVectorG<ushort> IndexLookup => new ImVectorG<ushort>(Marshal.PtrToStructure<ImFont>(NativePtr).IndexLookup);

        /// <summary>
        ///     Gets the value of the container atlas
        /// </summary>
        public ImFontAtlasPtr ContainerAtlas => new ImFontAtlasPtr(Marshal.PtrToStructure<ImFont>(NativePtr).ContainerAtlas);

        /// <summary>
        ///     Gets the value of the config data
        /// </summary>
        public ImFontConfigPtr ConfigData
        {
            get => new ImFontConfigPtr(Marshal.PtrToStructure<ImFont>(NativePtr).ConfigData);
            set
            {
                ImFont temp = Marshal.PtrToStructure<ImFont>(NativePtr);
                temp.ConfigData = value;
                Marshal.StructureToPtr(temp, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the config data count
        /// </summary>
        public short ConfigDataCount => Marshal.PtrToStructure<ImFont>(NativePtr).ConfigDataCount;

        /// <summary>
        ///     Gets the value of the fallback char
        /// </summary>
        public ushort FallbackChar => Marshal.PtrToStructure<ImFont>(NativePtr).FallbackChar;

        /// <summary>
        ///     Gets the value of the ellipsis char
        /// </summary>
        public ushort EllipsisChar => Marshal.PtrToStructure<ImFont>(NativePtr).EllipsisChar;

        /// <summary>
        ///     Gets the value of the dot char
        /// </summary>
        public ushort DotChar => Marshal.PtrToStructure<ImFont>(NativePtr).DotChar;

        /// <summary>
        ///     Gets the value of the dirty lookup tables
        /// </summary>
        public bool DirtyLookupTables => Marshal.PtrToStructure<ImFont>(NativePtr).DirtyLookupTables != 0;

        /// <summary>
        ///     Gets the value of the scale
        /// </summary>
        public float Scale => Marshal.PtrToStructure<ImFont>(NativePtr).Scale;

        /// <summary>
        ///     Gets the value of the ascent
        /// </summary>
        public float Ascent => Marshal.PtrToStructure<ImFont>(NativePtr).Ascent;

        /// <summary>
        ///     Gets the value of the descent
        /// </summary>
        public float Descent => Marshal.PtrToStructure<ImFont>(NativePtr).Descent;

        /// <summary>
        ///     Gets the value of the metrics total surface
        /// </summary>
        public int MetricsTotalSurface => Marshal.PtrToStructure<ImFont>(NativePtr).MetricsTotalSurface;

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
            ImGuiNative.ImFont_AddGlyph(NativePtr, srcCfg.NativePtr, c, x0, y0, x1, y1, u0, v0, u1, v1, advanceX);
        }

        /// <summary>
        ///     Adds the remap char using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        public void AddRemapChar(ushort dst, ushort src)
        {
            byte overwriteDst = 1;
            ImGuiNative.ImFont_AddRemapChar(NativePtr, dst, src, overwriteDst);
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
            ImGuiNative.ImFont_AddRemapChar(NativePtr, dst, src, nativeOverwriteDst);
        }

        /// <summary>
        ///     Builds the lookup table
        /// </summary>
        public void BuildLookupTable()
        {
            ImGuiNative.ImFont_BuildLookupTable(NativePtr);
        }

        /// <summary>
        ///     Clears the output data
        /// </summary>
        public void ClearOutputData()
        {
            ImGuiNative.ImFont_ClearOutputData(NativePtr);
        }

        /// <summary>
        ///     Finds the glyph using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyph FindGlyph(ushort c) => ImGuiNative.ImFont_FindGlyph(NativePtr, c);

        /// <summary>
        ///     Finds the glyph no fallback using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyph FindGlyphNoFallback(ushort c) => ImGuiNative.ImFont_FindGlyphNoFallback(NativePtr, c);

        /// <summary>
        ///     Gets the char advance using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The ret</returns>
        public float GetCharAdvance(ushort c) => ImGuiNative.ImFont_GetCharAdvance(NativePtr, c);

        /// <summary>
        ///     Gets the debug name
        /// </summary>
        /// <returns>The string</returns>
        public string GetDebugName() => Encoding.UTF8.GetString(ImGuiNative.ImFont_GetDebugName(NativePtr));

        /// <summary>
        ///     Grows the index using the specified new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        public void GrowIndex(int newSize)
        {
            ImGuiNative.ImFont_GrowIndex(NativePtr, newSize);
        }

        /// <summary>
        ///     Describes whether this instance is loaded
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsLoaded() => ImGuiNative.ImFont_IsLoaded(NativePtr) != 0;

        /// <summary>
        ///     Renders the char using the specified draw list
        /// </summary>
        /// <param name="drawList">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="c">The </param>
        public void RenderChar(ImDrawListPtr drawList, float size, Vector2F pos, uint col, ushort c)
        {
            ImGuiNative.ImFont_RenderChar(NativePtr, drawList.NativePtr, size, pos, col, c);
        }

        /// <summary>
        ///     Sets the glyph visible using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="visible">The visible</param>
        public void SetGlyphVisible(ushort c, bool visible)
        {
            byte nativeVisible = visible ? (byte) 1 : (byte) 0;
            ImGuiNative.ImFont_SetGlyphVisible(NativePtr, c, nativeVisible);
        }
    }
}