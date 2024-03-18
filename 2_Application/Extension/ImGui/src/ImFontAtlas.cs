// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlas.cs
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

namespace Alis.Extension.ImGui
{
    /// <summary>
    ///     The im font atlas
    /// </summary>
    public unsafe struct ImFontAtlas
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public ImFontAtlasFlags Flags;

        /// <summary>
        ///     The tex id
        /// </summary>
        public IntPtr TexId;

        /// <summary>
        ///     The tex desired width
        /// </summary>
        public int TexDesiredWidth;

        /// <summary>
        ///     The tex glyph padding
        /// </summary>
        public int TexGlyphPadding;

        /// <summary>
        ///     The locked
        /// </summary>
        public byte Locked;

        /// <summary>
        ///     The tex ready
        /// </summary>
        public byte TexReady;

        /// <summary>
        ///     The tex pixels use colors
        /// </summary>
        public byte TexPixelsUseColors;

        /// <summary>
        ///     The tex pixels alpha
        /// </summary>
        public byte* TexPixelsAlpha8;

        /// <summary>
        ///     The tex pixels rgba 32
        /// </summary>
        public uint* TexPixelsRgba32;

        /// <summary>
        ///     The tex width
        /// </summary>
        public int TexWidth;

        /// <summary>
        ///     The tex height
        /// </summary>
        public int TexHeight;

        /// <summary>
        ///     The tex uv scale
        /// </summary>
        public Vector2 TexUvScale;

        /// <summary>
        ///     The tex uv white pixel
        /// </summary>
        public Vector2 TexUvWhitePixel;

        /// <summary>
        ///     The fonts
        /// </summary>
        public ImVector Fonts;

        /// <summary>
        ///     The custom rects
        /// </summary>
        public ImVector CustomRects;

        /// <summary>
        ///     The config data
        /// </summary>
        public ImVector ConfigData;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines0;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines1;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines2;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines3;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines4;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines5;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines6;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines7;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines8;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines9;

        /// <summary>
        ///     The texuvlines 10
        /// </summary>
        public Vector4 TexUvLines10;

        /// <summary>
        ///     The texuvlines 11
        /// </summary>
        public Vector4 TexUvLines11;

        /// <summary>
        ///     The texuvlines 12
        /// </summary>
        public Vector4 TexUvLines12;

        /// <summary>
        ///     The texuvlines 13
        /// </summary>
        public Vector4 TexUvLines13;

        /// <summary>
        ///     The texuvlines 14
        /// </summary>
        public Vector4 TexUvLines14;

        /// <summary>
        ///     The texuvlines 15
        /// </summary>
        public Vector4 TexUvLines15;

        /// <summary>
        ///     The texuvlines 16
        /// </summary>
        public Vector4 TexUvLines16;

        /// <summary>
        ///     The texuvlines 17
        /// </summary>
        public Vector4 TexUvLines17;

        /// <summary>
        ///     The texuvlines 18
        /// </summary>
        public Vector4 TexUvLines18;

        /// <summary>
        ///     The texuvlines 19
        /// </summary>
        public Vector4 TexUvLines19;

        /// <summary>
        ///     The texuvlines 20
        /// </summary>
        public Vector4 TexUvLines20;

        /// <summary>
        ///     The texuvlines 21
        /// </summary>
        public Vector4 TexUvLines21;

        /// <summary>
        ///     The texuvlines 22
        /// </summary>
        public Vector4 TexUvLines22;

        /// <summary>
        ///     The texuvlines 23
        /// </summary>
        public Vector4 TexUvLines23;

        /// <summary>
        ///     The texuvlines 24
        /// </summary>
        public Vector4 TexUvLines24;

        /// <summary>
        ///     The texuvlines 25
        /// </summary>
        public Vector4 TexUvLines25;

        /// <summary>
        ///     The texuvlines 26
        /// </summary>
        public Vector4 TexUvLines26;

        /// <summary>
        ///     The texuvlines 27
        /// </summary>
        public Vector4 TexUvLines27;

        /// <summary>
        ///     The texuvlines 28
        /// </summary>
        public Vector4 TexUvLines28;

        /// <summary>
        ///     The texuvlines 29
        /// </summary>
        public Vector4 TexUvLines29;

        /// <summary>
        ///     The texuvlines 30
        /// </summary>
        public Vector4 TexUvLines30;

        /// <summary>
        ///     The texuvlines 31
        /// </summary>
        public Vector4 TexUvLines31;

        /// <summary>
        ///     The texuvlines 32
        /// </summary>
        public Vector4 TexUvLines32;

        /// <summary>
        ///     The texuvlines 33
        /// </summary>
        public Vector4 TexUvLines33;

        /// <summary>
        ///     The texuvlines 34
        /// </summary>
        public Vector4 TexUvLines34;

        /// <summary>
        ///     The texuvlines 35
        /// </summary>
        public Vector4 TexUvLines35;

        /// <summary>
        ///     The texuvlines 36
        /// </summary>
        public Vector4 TexUvLines36;

        /// <summary>
        ///     The texuvlines 37
        /// </summary>
        public Vector4 TexUvLines37;

        /// <summary>
        ///     The texuvlines 38
        /// </summary>
        public Vector4 TexUvLines38;

        /// <summary>
        ///     The texuvlines 39
        /// </summary>
        public Vector4 TexUvLines39;

        /// <summary>
        ///     The texuvlines 40
        /// </summary>
        public Vector4 TexUvLines40;

        /// <summary>
        ///     The texuvlines 41
        /// </summary>
        public Vector4 TexUvLines41;

        /// <summary>
        ///     The texuvlines 42
        /// </summary>
        public Vector4 TexUvLines42;

        /// <summary>
        ///     The texuvlines 43
        /// </summary>
        public Vector4 TexUvLines43;

        /// <summary>
        ///     The texuvlines 44
        /// </summary>
        public Vector4 TexUvLines44;

        /// <summary>
        ///     The texuvlines 45
        /// </summary>
        public Vector4 TexUvLines45;

        /// <summary>
        ///     The texuvlines 46
        /// </summary>
        public Vector4 TexUvLines46;

        /// <summary>
        ///     The texuvlines 47
        /// </summary>
        public Vector4 TexUvLines47;

        /// <summary>
        ///     The texuvlines 48
        /// </summary>
        public Vector4 TexUvLines48;

        /// <summary>
        ///     The texuvlines 49
        /// </summary>
        public Vector4 TexUvLines49;

        /// <summary>
        ///     The texuvlines 50
        /// </summary>
        public Vector4 TexUvLines50;

        /// <summary>
        ///     The texuvlines 51
        /// </summary>
        public Vector4 TexUvLines51;

        /// <summary>
        ///     The texuvlines 52
        /// </summary>
        public Vector4 TexUvLines52;

        /// <summary>
        ///     The texuvlines 53
        /// </summary>
        public Vector4 TexUvLines53;

        /// <summary>
        ///     The texuvlines 54
        /// </summary>
        public Vector4 TexUvLines54;

        /// <summary>
        ///     The texuvlines 55
        /// </summary>
        public Vector4 TexUvLines55;

        /// <summary>
        ///     The texuvlines 56
        /// </summary>
        public Vector4 TexUvLines56;

        /// <summary>
        ///     The texuvlines 57
        /// </summary>
        public Vector4 TexUvLines57;

        /// <summary>
        ///     The texuvlines 58
        /// </summary>
        public Vector4 TexUvLines58;

        /// <summary>
        ///     The texuvlines 59
        /// </summary>
        public Vector4 TexUvLines59;

        /// <summary>
        ///     The texuvlines 60
        /// </summary>
        public Vector4 TexUvLines60;

        /// <summary>
        ///     The texuvlines 61
        /// </summary>
        public Vector4 TexUvLines61;

        /// <summary>
        ///     The texuvlines 62
        /// </summary>
        public Vector4 TexUvLines62;

        /// <summary>
        ///     The texuvlines 63
        /// </summary>
        public Vector4 TexUvLines63;

        /// <summary>
        ///     The font builder io
        /// </summary>
        public IntPtr* FontBuilderIo;

        /// <summary>
        ///     The font builder flags
        /// </summary>
        public uint FontBuilderFlags;

        /// <summary>
        ///     The pack id mouse cursors
        /// </summary>
        public int PackIdMouseCursors;

        /// <summary>
        ///     The pack id lines
        /// </summary>
        public int PackIdLines;
    }
}