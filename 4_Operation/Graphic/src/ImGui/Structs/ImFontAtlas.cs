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
using Alis.Core.Graphic.ImGui.Enums;

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im font atlas
    /// </summary>
    public unsafe struct ImFontAtlas
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public Enums.ImFontAtlas Flag;

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
        ///     The user data
        /// </summary>
        public void* UserData;

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
        public Vector2F TexUvScale;

        /// <summary>
        ///     The tex uv white pixel
        /// </summary>
        public Vector2F TexUvWhitePixel;

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
        public Vector4F TexUvLines0;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines1;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines2;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines3;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines4;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines5;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines6;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines7;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines8;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines9;

        /// <summary>
        ///     The texuvlines 10
        /// </summary>
        public Vector4F TexUvLines10;

        /// <summary>
        ///     The texuvlines 11
        /// </summary>
        public Vector4F TexUvLines11;

        /// <summary>
        ///     The texuvlines 12
        /// </summary>
        public Vector4F TexUvLines12;

        /// <summary>
        ///     The texuvlines 13
        /// </summary>
        public Vector4F TexUvLines13;

        /// <summary>
        ///     The texuvlines 14
        /// </summary>
        public Vector4F TexUvLines14;

        /// <summary>
        ///     The texuvlines 15
        /// </summary>
        public Vector4F TexUvLines15;

        /// <summary>
        ///     The texuvlines 16
        /// </summary>
        public Vector4F TexUvLines16;

        /// <summary>
        ///     The texuvlines 17
        /// </summary>
        public Vector4F TexUvLines17;

        /// <summary>
        ///     The texuvlines 18
        /// </summary>
        public Vector4F TexUvLines18;

        /// <summary>
        ///     The texuvlines 19
        /// </summary>
        public Vector4F TexUvLines19;

        /// <summary>
        ///     The texuvlines 20
        /// </summary>
        public Vector4F TexUvLines20;

        /// <summary>
        ///     The texuvlines 21
        /// </summary>
        public Vector4F TexUvLines21;

        /// <summary>
        ///     The texuvlines 22
        /// </summary>
        public Vector4F TexUvLines22;

        /// <summary>
        ///     The texuvlines 23
        /// </summary>
        public Vector4F TexUvLines23;

        /// <summary>
        ///     The texuvlines 24
        /// </summary>
        public Vector4F TexUvLines24;

        /// <summary>
        ///     The texuvlines 25
        /// </summary>
        public Vector4F TexUvLines25;

        /// <summary>
        ///     The texuvlines 26
        /// </summary>
        public Vector4F TexUvLines26;

        /// <summary>
        ///     The texuvlines 27
        /// </summary>
        public Vector4F TexUvLines27;

        /// <summary>
        ///     The texuvlines 28
        /// </summary>
        public Vector4F TexUvLines28;

        /// <summary>
        ///     The texuvlines 29
        /// </summary>
        public Vector4F TexUvLines29;

        /// <summary>
        ///     The texuvlines 30
        /// </summary>
        public Vector4F TexUvLines30;

        /// <summary>
        ///     The texuvlines 31
        /// </summary>
        public Vector4F TexUvLines31;

        /// <summary>
        ///     The texuvlines 32
        /// </summary>
        public Vector4F TexUvLines32;

        /// <summary>
        ///     The texuvlines 33
        /// </summary>
        public Vector4F TexUvLines33;

        /// <summary>
        ///     The texuvlines 34
        /// </summary>
        public Vector4F TexUvLines34;

        /// <summary>
        ///     The texuvlines 35
        /// </summary>
        public Vector4F TexUvLines35;

        /// <summary>
        ///     The texuvlines 36
        /// </summary>
        public Vector4F TexUvLines36;

        /// <summary>
        ///     The texuvlines 37
        /// </summary>
        public Vector4F TexUvLines37;

        /// <summary>
        ///     The texuvlines 38
        /// </summary>
        public Vector4F TexUvLines38;

        /// <summary>
        ///     The texuvlines 39
        /// </summary>
        public Vector4F TexUvLines39;

        /// <summary>
        ///     The texuvlines 40
        /// </summary>
        public Vector4F TexUvLines40;

        /// <summary>
        ///     The texuvlines 41
        /// </summary>
        public Vector4F TexUvLines41;

        /// <summary>
        ///     The texuvlines 42
        /// </summary>
        public Vector4F TexUvLines42;

        /// <summary>
        ///     The texuvlines 43
        /// </summary>
        public Vector4F TexUvLines43;

        /// <summary>
        ///     The texuvlines 44
        /// </summary>
        public Vector4F TexUvLines44;

        /// <summary>
        ///     The texuvlines 45
        /// </summary>
        public Vector4F TexUvLines45;

        /// <summary>
        ///     The texuvlines 46
        /// </summary>
        public Vector4F TexUvLines46;

        /// <summary>
        ///     The texuvlines 47
        /// </summary>
        public Vector4F TexUvLines47;

        /// <summary>
        ///     The texuvlines 48
        /// </summary>
        public Vector4F TexUvLines48;

        /// <summary>
        ///     The texuvlines 49
        /// </summary>
        public Vector4F TexUvLines49;

        /// <summary>
        ///     The texuvlines 50
        /// </summary>
        public Vector4F TexUvLines50;

        /// <summary>
        ///     The texuvlines 51
        /// </summary>
        public Vector4F TexUvLines51;

        /// <summary>
        ///     The texuvlines 52
        /// </summary>
        public Vector4F TexUvLines52;

        /// <summary>
        ///     The texuvlines 53
        /// </summary>
        public Vector4F TexUvLines53;

        /// <summary>
        ///     The texuvlines 54
        /// </summary>
        public Vector4F TexUvLines54;

        /// <summary>
        ///     The texuvlines 55
        /// </summary>
        public Vector4F TexUvLines55;

        /// <summary>
        ///     The texuvlines 56
        /// </summary>
        public Vector4F TexUvLines56;

        /// <summary>
        ///     The texuvlines 57
        /// </summary>
        public Vector4F TexUvLines57;

        /// <summary>
        ///     The texuvlines 58
        /// </summary>
        public Vector4F TexUvLines58;

        /// <summary>
        ///     The texuvlines 59
        /// </summary>
        public Vector4F TexUvLines59;

        /// <summary>
        ///     The texuvlines 60
        /// </summary>
        public Vector4F TexUvLines60;

        /// <summary>
        ///     The texuvlines 61
        /// </summary>
        public Vector4F TexUvLines61;

        /// <summary>
        ///     The texuvlines 62
        /// </summary>
        public Vector4F TexUvLines62;

        /// <summary>
        ///     The texuvlines 63
        /// </summary>
        public Vector4F TexUvLines63;

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