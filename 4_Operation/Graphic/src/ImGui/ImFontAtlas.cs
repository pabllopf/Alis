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
using System.Numerics;

namespace Alis.Core.Graphic.ImGui
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
        public IntPtr TexID;

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
        public uint* TexPixelsRGBA32;

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
        public Vector4 TexUvLines_0;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_1;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_2;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_3;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_4;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_5;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_6;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_7;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_8;

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines_9;

        /// <summary>
        ///     The texuvlines 10
        /// </summary>
        public Vector4 TexUvLines_10;

        /// <summary>
        ///     The texuvlines 11
        /// </summary>
        public Vector4 TexUvLines_11;

        /// <summary>
        ///     The texuvlines 12
        /// </summary>
        public Vector4 TexUvLines_12;

        /// <summary>
        ///     The texuvlines 13
        /// </summary>
        public Vector4 TexUvLines_13;

        /// <summary>
        ///     The texuvlines 14
        /// </summary>
        public Vector4 TexUvLines_14;

        /// <summary>
        ///     The texuvlines 15
        /// </summary>
        public Vector4 TexUvLines_15;

        /// <summary>
        ///     The texuvlines 16
        /// </summary>
        public Vector4 TexUvLines_16;

        /// <summary>
        ///     The texuvlines 17
        /// </summary>
        public Vector4 TexUvLines_17;

        /// <summary>
        ///     The texuvlines 18
        /// </summary>
        public Vector4 TexUvLines_18;

        /// <summary>
        ///     The texuvlines 19
        /// </summary>
        public Vector4 TexUvLines_19;

        /// <summary>
        ///     The texuvlines 20
        /// </summary>
        public Vector4 TexUvLines_20;

        /// <summary>
        ///     The texuvlines 21
        /// </summary>
        public Vector4 TexUvLines_21;

        /// <summary>
        ///     The texuvlines 22
        /// </summary>
        public Vector4 TexUvLines_22;

        /// <summary>
        ///     The texuvlines 23
        /// </summary>
        public Vector4 TexUvLines_23;

        /// <summary>
        ///     The texuvlines 24
        /// </summary>
        public Vector4 TexUvLines_24;

        /// <summary>
        ///     The texuvlines 25
        /// </summary>
        public Vector4 TexUvLines_25;

        /// <summary>
        ///     The texuvlines 26
        /// </summary>
        public Vector4 TexUvLines_26;

        /// <summary>
        ///     The texuvlines 27
        /// </summary>
        public Vector4 TexUvLines_27;

        /// <summary>
        ///     The texuvlines 28
        /// </summary>
        public Vector4 TexUvLines_28;

        /// <summary>
        ///     The texuvlines 29
        /// </summary>
        public Vector4 TexUvLines_29;

        /// <summary>
        ///     The texuvlines 30
        /// </summary>
        public Vector4 TexUvLines_30;

        /// <summary>
        ///     The texuvlines 31
        /// </summary>
        public Vector4 TexUvLines_31;

        /// <summary>
        ///     The texuvlines 32
        /// </summary>
        public Vector4 TexUvLines_32;

        /// <summary>
        ///     The texuvlines 33
        /// </summary>
        public Vector4 TexUvLines_33;

        /// <summary>
        ///     The texuvlines 34
        /// </summary>
        public Vector4 TexUvLines_34;

        /// <summary>
        ///     The texuvlines 35
        /// </summary>
        public Vector4 TexUvLines_35;

        /// <summary>
        ///     The texuvlines 36
        /// </summary>
        public Vector4 TexUvLines_36;

        /// <summary>
        ///     The texuvlines 37
        /// </summary>
        public Vector4 TexUvLines_37;

        /// <summary>
        ///     The texuvlines 38
        /// </summary>
        public Vector4 TexUvLines_38;

        /// <summary>
        ///     The texuvlines 39
        /// </summary>
        public Vector4 TexUvLines_39;

        /// <summary>
        ///     The texuvlines 40
        /// </summary>
        public Vector4 TexUvLines_40;

        /// <summary>
        ///     The texuvlines 41
        /// </summary>
        public Vector4 TexUvLines_41;

        /// <summary>
        ///     The texuvlines 42
        /// </summary>
        public Vector4 TexUvLines_42;

        /// <summary>
        ///     The texuvlines 43
        /// </summary>
        public Vector4 TexUvLines_43;

        /// <summary>
        ///     The texuvlines 44
        /// </summary>
        public Vector4 TexUvLines_44;

        /// <summary>
        ///     The texuvlines 45
        /// </summary>
        public Vector4 TexUvLines_45;

        /// <summary>
        ///     The texuvlines 46
        /// </summary>
        public Vector4 TexUvLines_46;

        /// <summary>
        ///     The texuvlines 47
        /// </summary>
        public Vector4 TexUvLines_47;

        /// <summary>
        ///     The texuvlines 48
        /// </summary>
        public Vector4 TexUvLines_48;

        /// <summary>
        ///     The texuvlines 49
        /// </summary>
        public Vector4 TexUvLines_49;

        /// <summary>
        ///     The texuvlines 50
        /// </summary>
        public Vector4 TexUvLines_50;

        /// <summary>
        ///     The texuvlines 51
        /// </summary>
        public Vector4 TexUvLines_51;

        /// <summary>
        ///     The texuvlines 52
        /// </summary>
        public Vector4 TexUvLines_52;

        /// <summary>
        ///     The texuvlines 53
        /// </summary>
        public Vector4 TexUvLines_53;

        /// <summary>
        ///     The texuvlines 54
        /// </summary>
        public Vector4 TexUvLines_54;

        /// <summary>
        ///     The texuvlines 55
        /// </summary>
        public Vector4 TexUvLines_55;

        /// <summary>
        ///     The texuvlines 56
        /// </summary>
        public Vector4 TexUvLines_56;

        /// <summary>
        ///     The texuvlines 57
        /// </summary>
        public Vector4 TexUvLines_57;

        /// <summary>
        ///     The texuvlines 58
        /// </summary>
        public Vector4 TexUvLines_58;

        /// <summary>
        ///     The texuvlines 59
        /// </summary>
        public Vector4 TexUvLines_59;

        /// <summary>
        ///     The texuvlines 60
        /// </summary>
        public Vector4 TexUvLines_60;

        /// <summary>
        ///     The texuvlines 61
        /// </summary>
        public Vector4 TexUvLines_61;

        /// <summary>
        ///     The texuvlines 62
        /// </summary>
        public Vector4 TexUvLines_62;

        /// <summary>
        ///     The texuvlines 63
        /// </summary>
        public Vector4 TexUvLines_63;

        /// <summary>
        ///     The font builder io
        /// </summary>
        public IntPtr* FontBuilderIO;

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