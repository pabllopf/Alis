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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font atlas
    /// </summary>
    public struct ImFontAtlas
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public ImFontAtlasFlags Flags { get; set; }

        /// <summary>
        ///     The tex id
        /// </summary>
        public IntPtr TexId { get; set; }

        /// <summary>
        ///     The tex desired width
        /// </summary>
        public int TexDesiredWidth { get; set; }

        /// <summary>
        ///     The tex glyph padding
        /// </summary>
        public int TexGlyphPadding { get; set; }

        /// <summary>
        ///     The locked
        /// </summary>
        public byte Locked { get; set; }

        /// <summary>
        ///     The tex ready
        /// </summary>
        public byte TexReady { get; set; }

        /// <summary>
        ///     The tex pixels use colors
        /// </summary>
        public byte TexPixelsUseColors { get; set; }

        /// <summary>
        ///     The tex pixels alpha
        /// </summary>
        public IntPtr TexPixelsAlpha8 { get; set; }

        /// <summary>
        ///     The tex pixels rgba 32
        /// </summary>
        public IntPtr TexPixelsRgba32 { get; set; }

        /// <summary>
        ///     The tex width
        /// </summary>
        public int TexWidth { get; set; }

        /// <summary>
        ///     The tex height
        /// </summary>
        public int TexHeight { get; set; }

        /// <summary>
        ///     The tex uv scale
        /// </summary>
        public Vector2F TexUvScale { get; set; }

        /// <summary>
        ///     The tex uv white pixel
        /// </summary>
        public Vector2F TexUvWhitePixel { get; set; }

        /// <summary>
        ///     The fonts
        /// </summary>
        public ImVector Fonts { get; set; }

        /// <summary>
        ///     The custom rects
        /// </summary>
        public ImVector CustomRects { get; set; }

        /// <summary>
        ///     The config data
        /// </summary>
        public ImVector ConfigData { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines0 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines1 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines2 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines3 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines4 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines5 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines6 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines7 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines8 { get; set; }

        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4F TexUvLines9 { get; set; }

        /// <summary>
        ///     The texuvlines 10
        /// </summary>
        public Vector4F TexUvLines10 { get; set; }

        /// <summary>
        ///     The texuvlines 11
        /// </summary>
        public Vector4F TexUvLines11 { get; set; }

        /// <summary>
        ///     The texuvlines 12
        /// </summary>
        public Vector4F TexUvLines12 { get; set; }

        /// <summary>
        ///     The texuvlines 13
        /// </summary>
        public Vector4F TexUvLines13 { get; set; }

        /// <summary>
        ///     The texuvlines 14
        /// </summary>
        public Vector4F TexUvLines14 { get; set; }

        /// <summary>
        ///     The texuvlines 15
        /// </summary>
        public Vector4F TexUvLines15 { get; set; }

        /// <summary>
        ///     The texuvlines 16
        /// </summary>
        public Vector4F TexUvLines16 { get; set; }

        /// <summary>
        ///     The texuvlines 17
        /// </summary>
        public Vector4F TexUvLines17 { get; set; }

        /// <summary>
        ///     The texuvlines 18
        /// </summary>
        public Vector4F TexUvLines18 { get; set; }

        /// <summary>
        ///     The texuvlines 19
        /// </summary>
        public Vector4F TexUvLines19 { get; set; }

        /// <summary>
        ///     The texuvlines 20
        /// </summary>
        public Vector4F TexUvLines20 { get; set; }

        /// <summary>
        ///     The texuvlines 21
        /// </summary>
        public Vector4F TexUvLines21 { get; set; }

        /// <summary>
        ///     The texuvlines 22
        /// </summary>
        public Vector4F TexUvLines22 { get; set; }

        /// <summary>
        ///     The texuvlines 23
        /// </summary>
        public Vector4F TexUvLines23 { get; set; }

        /// <summary>
        ///     The texuvlines 24
        /// </summary>
        public Vector4F TexUvLines24 { get; set; }

        /// <summary>
        ///     The texuvlines 25
        /// </summary>
        public Vector4F TexUvLines25 { get; set; }

        /// <summary>
        ///     The texuvlines 26
        /// </summary>
        public Vector4F TexUvLines26 { get; set; }

        /// <summary>
        ///     The texuvlines 27
        /// </summary>
        public Vector4F TexUvLines27 { get; set; }

        /// <summary>
        ///     The texuvlines 28
        /// </summary>
        public Vector4F TexUvLines28 { get; set; }

        /// <summary>
        ///     The texuvlines 29
        /// </summary>
        public Vector4F TexUvLines29 { get; set; }

        /// <summary>
        ///     The texuvlines 30
        /// </summary>
        public Vector4F TexUvLines30 { get; set; }

        /// <summary>
        ///     The texuvlines 31
        /// </summary>
        public Vector4F TexUvLines31 { get; set; }

        /// <summary>
        ///     The texuvlines 32
        /// </summary>
        public Vector4F TexUvLines32 { get; set; }

        /// <summary>
        ///     The texuvlines 33
        /// </summary>
        public Vector4F TexUvLines33 { get; set; }

        /// <summary>
        ///     The texuvlines 34
        /// </summary>
        public Vector4F TexUvLines34 { get; set; }

        /// <summary>
        ///     The texuvlines 35
        /// </summary>
        public Vector4F TexUvLines35 { get; set; }

        /// <summary>
        ///     The texuvlines 36
        /// </summary>
        public Vector4F TexUvLines36 { get; set; }

        /// <summary>
        ///     The texuvlines 37
        /// </summary>
        public Vector4F TexUvLines37 { get; set; }

        /// <summary>
        ///     The texuvlines 38
        /// </summary>
        public Vector4F TexUvLines38 { get; set; }

        /// <summary>
        ///     The texuvlines 39
        /// </summary>
        public Vector4F TexUvLines39 { get; set; }

        /// <summary>
        ///     The texuvlines 40
        /// </summary>
        public Vector4F TexUvLines40 { get; set; }

        /// <summary>
        ///     The texuvlines 41
        /// </summary>
        public Vector4F TexUvLines41 { get; set; }

        /// <summary>
        ///     The texuvlines 42
        /// </summary>
        public Vector4F TexUvLines42 { get; set; }

        /// <summary>
        ///     The texuvlines 43
        /// </summary>
        public Vector4F TexUvLines43 { get; set; }

        /// <summary>
        ///     The texuvlines 44
        /// </summary>
        public Vector4F TexUvLines44 { get; set; }

        /// <summary>
        ///     The texuvlines 45
        /// </summary>
        public Vector4F TexUvLines45 { get; set; }

        /// <summary>
        ///     The texuvlines 46
        /// </summary>
        public Vector4F TexUvLines46 { get; set; }

        /// <summary>
        ///     The texuvlines 47
        /// </summary>
        public Vector4F TexUvLines47 { get; set; }

        /// <summary>
        ///     The texuvlines 48
        /// </summary>
        public Vector4F TexUvLines48 { get; set; }

        /// <summary>
        ///     The texuvlines 49
        /// </summary>
        public Vector4F TexUvLines49 { get; set; }

        /// <summary>
        ///     The texuvlines 50
        /// </summary>
        public Vector4F TexUvLines50 { get; set; }

        /// <summary>
        ///     The texuvlines 51
        /// </summary>
        public Vector4F TexUvLines51 { get; set; }

        /// <summary>
        ///     The texuvlines 52
        /// </summary>
        public Vector4F TexUvLines52 { get; set; }

        /// <summary>
        ///     The texuvlines 53
        /// </summary>
        public Vector4F TexUvLines53 { get; set; }

        /// <summary>
        ///     The texuvlines 54
        /// </summary>
        public Vector4F TexUvLines54 { get; set; }

        /// <summary>
        ///     The texuvlines 55
        /// </summary>
        public Vector4F TexUvLines55 { get; set; }

        /// <summary>
        ///     The texuvlines 56
        /// </summary>
        public Vector4F TexUvLines56 { get; set; }

        /// <summary>
        ///     The texuvlines 57
        /// </summary>
        public Vector4F TexUvLines57 { get; set; }

        /// <summary>
        ///     The texuvlines 58
        /// </summary>
        public Vector4F TexUvLines58 { get; set; }

        /// <summary>
        ///     The texuvlines 59
        /// </summary>
        public Vector4F TexUvLines59 { get; set; }

        /// <summary>
        ///     The texuvlines 60
        /// </summary>
        public Vector4F TexUvLines60 { get; set; }

        /// <summary>
        ///     The texuvlines 61
        /// </summary>
        public Vector4F TexUvLines61 { get; set; }

        /// <summary>
        ///     The texuvlines 62
        /// </summary>
        public Vector4F TexUvLines62 { get; set; }

        /// <summary>
        ///     The texuvlines 63
        /// </summary>
        public Vector4F TexUvLines63 { get; set; }

        /// <summary>
        ///     The font builder io
        /// </summary>
        public IntPtr FontBuilderIo { get; set; }

        /// <summary>
        ///     The font builder flags
        /// </summary>
        public uint FontBuilderFlags { get; set; }

        /// <summary>
        ///     The pack id mouse cursors
        /// </summary>
        public int PackIdMouseCursors { get; set; }

        /// <summary>
        ///     The pack id lines
        /// </summary>
        public int PackIdLines { get; set; }
    }
}