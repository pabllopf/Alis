// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFont.cs
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

using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font
    /// </summary>
    public struct ImFont
    {
        /// <summary>
        ///     The index advance
        /// </summary>
        public ImVector IndexAdvanceX;
        
        /// <summary>
        ///     The fallback advance
        /// </summary>
        public float FallbackAdvanceX;
        
        /// <summary>
        ///     The font size
        /// </summary>
        public float FontSize;
        
        /// <summary>
        ///     The index lookup
        /// </summary>
        public ImVector IndexLookup;
        
        /// <summary>
        ///     The glyphs
        /// </summary>
        public ImVector Glyphs;
        
        /// <summary>
        ///     The fallback glyph
        /// </summary>
        public ImFontGlyph FallbackGlyph;
        
        /// <summary>
        ///     The container atlas
        /// </summary>
        public ImFontAtlas ContainerAtlas;
        
        /// <summary>
        ///     The config data
        /// </summary>
        public ImFontConfig ConfigData;
        
        /// <summary>
        ///     The config data count
        /// </summary>
        public short ConfigDataCount;
        
        /// <summary>
        ///     The fallback char
        /// </summary>
        public ushort FallbackChar;
        
        /// <summary>
        ///     The ellipsis char
        /// </summary>
        public ushort EllipsisChar;
        
        /// <summary>
        ///     The dot char
        /// </summary>
        public ushort DotChar;
        
        /// <summary>
        ///     The dirty lookup tables
        /// </summary>
        public byte DirtyLookupTables;
        
        /// <summary>
        ///     The scale
        /// </summary>
        public float Scale;
        
        /// <summary>
        ///     The ascent
        /// </summary>
        public float Ascent;
        
        /// <summary>
        ///     The descent
        /// </summary>
        public float Descent;
        
        /// <summary>
        ///     The metrics total surface
        /// </summary>
        public int MetricsTotalSurface;

        /// <summary>
        ///     The used 4k pages map
        /// </summary>
        public byte[] Used4KPagesMap;
        
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
        public void AddGlyph(ImFontConfig srcCfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advanceX)
        {
            ImGuiNative.ImFont_AddGlyph(ref this, srcCfg, c, x0, y0, x1, y1, u0, v0, u1, v1, advanceX);
        }
        
        /// <summary>
        ///     Adds the remap char using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        public void AddRemapChar(ushort dst, ushort src)
        {
            byte overwriteDst = 1;
            ImGuiNative.ImFont_AddRemapChar(ref this, dst, src, overwriteDst);
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
            ImGuiNative.ImFont_AddRemapChar(ref this, dst, src, nativeOverwriteDst);
        }
        
        /// <summary>
        ///     Builds the lookup table
        /// </summary>
        public void BuildLookupTable()
        {
            ImGuiNative.ImFont_BuildLookupTable(ref this);
        }
        
        /// <summary>
        ///     Clears the output data
        /// </summary>
        public void ClearOutputData()
        {
            ImGuiNative.ImFont_ClearOutputData(ref this);
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFont_destroy(ref this);
        }
        
        /// <summary>
        ///     Finds the glyph using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyph FindGlyph(ushort c) => ImGuiNative.ImFont_FindGlyph(ref this, c);
        
        /// <summary>
        ///     Finds the glyph no fallback using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyph FindGlyphNoFallback(ushort c) => ImGuiNative.ImFont_FindGlyphNoFallback(ref this, c);
        
        /// <summary>
        ///     Gets the char advance using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The ret</returns>
        public float GetCharAdvance(ushort c)
        {
            float ret = ImGuiNative.ImFont_GetCharAdvance(ref this, c);
            return ret;
        }
        
        /// <summary>
        ///     Gets the debug name
        /// </summary>
        /// <returns>The string</returns>
        public string GetDebugName()
        {
            return Encoding.UTF8.GetString( ImGuiNative.ImFont_GetDebugName(ref this));
        }
        
        /// <summary>
        ///     Grows the index using the specified new size
        /// </summary>
        /// <param name="newSize">The new size</param>
        public void GrowIndex(int newSize)
        {
            ImGuiNative.ImFont_GrowIndex(ref this, newSize);
        }
        
        /// <summary>
        ///     Describes whether this instance is loaded
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsLoaded()
        {
            byte ret = ImGuiNative.ImFont_IsLoaded(ref this);
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
        public void RenderChar(ImDrawList drawList, float size, Vector2 pos, uint col, ushort c)
        {
            ImGuiNative.ImFont_RenderChar(ref this, drawList, size, pos, col, c);
        }
        
        /// <summary>
        ///     Sets the glyph visible using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="visible">The visible</param>
        public void SetGlyphVisible(ushort c, bool visible)
        {
            byte nativeVisible = visible ? (byte) 1 : (byte) 0;
            ImGuiNative.ImFont_SetGlyphVisible(ref this, c, nativeVisible);
        }
    }
}