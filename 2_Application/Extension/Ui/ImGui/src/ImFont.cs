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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font
    /// </summary>
    public unsafe struct ImFont
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
        public ImFontGlyph* FallbackGlyph;

        /// <summary>
        ///     The container atlas
        /// </summary>
        public ImFontAtlas* ContainerAtlas;

        /// <summary>
        ///     The config data
        /// </summary>
        public ImFontConfig* ConfigData;

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
        public fixed byte Used4KPagesMap[2];
    }
}