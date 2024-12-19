// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStyle.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The imgui style
    /// </summary>
    public struct ImGuiStyle
    {
        /// <summary>
        ///     The alpha
        /// </summary>
        public float Alpha { get; set; }

        /// <summary>
        ///     The disabled alpha
        /// </summary>
        public float DisabledAlpha { get; set; }

        /// <summary>
        ///     The window padding
        /// </summary>
        public Vector2F WindowPadding { get; set; }

        /// <summary>
        ///     The window rounding
        /// </summary>
        public float WindowRounding { get; set; }

        /// <summary>
        ///     The window border size
        /// </summary>
        public float WindowBorderSize { get; set; }

        /// <summary>
        ///     The window min size
        /// </summary>
        public Vector2F WindowMinSize { get; set; }

        /// <summary>
        ///     The window title align
        /// </summary>
        public Vector2F WindowTitleAlign { get; set; }

        /// <summary>
        ///     The window menu button position
        /// </summary>
        public ImGuiDir WindowMenuButtonPosition { get; set; }

        /// <summary>
        ///     The child rounding
        /// </summary>
        public float ChildRounding { get; set; }

        /// <summary>
        ///     The child border size
        /// </summary>
        public float ChildBorderSize { get; set; }

        /// <summary>
        ///     The popup rounding
        /// </summary>
        public float PopupRounding { get; set; }

        /// <summary>
        ///     The popup border size
        /// </summary>
        public float PopupBorderSize { get; set; }

        /// <summary>
        ///     The frame padding
        /// </summary>
        public Vector2F FramePadding { get; set; }

        /// <summary>
        ///     The frame rounding
        /// </summary>
        public float FrameRounding { get; set; }

        /// <summary>
        ///     The frame border size
        /// </summary>
        public float FrameBorderSize { get; set; }

        /// <summary>
        ///     The item spacing
        /// </summary>
        public Vector2F ItemSpacing { get; set; }

        /// <summary>
        ///     The item inner spacing
        /// </summary>
        public Vector2F ItemInnerSpacing { get; set; }

        /// <summary>
        ///     The cell padding
        /// </summary>
        public Vector2F CellPadding { get; set; }

        /// <summary>
        ///     The touch extra padding
        /// </summary>
        public Vector2F TouchExtraPadding { get; set; }

        /// <summary>
        ///     The indent spacing
        /// </summary>
        public float IndentSpacing { get; set; }

        /// <summary>
        ///     The columns min spacing
        /// </summary>
        public float ColumnsMinSpacing { get; set; }

        /// <summary>
        ///     The scrollbar size
        /// </summary>
        public float ScrollbarSize { get; set; }

        /// <summary>
        ///     The scrollbar rounding
        /// </summary>
        public float ScrollbarRounding { get; set; }

        /// <summary>
        ///     The grab min size
        /// </summary>
        public float GrabMinSize { get; set; }

        /// <summary>
        ///     The grab rounding
        /// </summary>
        public float GrabRounding { get; set; }

        /// <summary>
        ///     The log slider deadzone
        /// </summary>
        public float LogSliderDeadzone { get; set; }

        /// <summary>
        ///     The tab rounding
        /// </summary>
        public float TabRounding { get; set; }

        /// <summary>
        ///     The tab border size
        /// </summary>
        public float TabBorderSize { get; set; }

        /// <summary>
        ///     The tab min width for close button
        /// </summary>
        public float TabMinWidthForCloseButton { get; set; }

        /// <summary>
        ///     The color button position
        /// </summary>
        public ImGuiDir ColorButtonPosition { get; set; }

        /// <summary>
        ///     The button text align
        /// </summary>
        public Vector2F ButtonTextAlign { get; set; }

        /// <summary>
        ///     The selectable text align
        /// </summary>
        public Vector2F SelectableTextAlign { get; set; }

        /// <summary>
        ///     The display window padding
        /// </summary>
        public Vector2F DisplayWindowPadding { get; set; }

        /// <summary>
        ///     The display safe area padding
        /// </summary>
        public Vector2F DisplaySafeAreaPadding { get; set; }

        /// <summary>
        ///     The mouse cursor scale
        /// </summary>
        public float MouseCursorScale { get; set; }

        /// <summary>
        ///     The anti aliased lines
        /// </summary>
        public byte AntiAliasedLines { get; set; }

        /// <summary>
        ///     The anti aliased lines use tex
        /// </summary>
        public byte AntiAliasedLinesUseTex { get; set; }

        /// <summary>
        ///     The anti aliased fill
        /// </summary>
        public byte AntiAliasedFill { get; set; }

        /// <summary>
        ///     The curve tessellation tol
        /// </summary>
        public float CurveTessellationTol { get; set; }

        /// <summary>
        ///     The circle tessellation max error
        /// </summary>
        public float CircleTessellationMaxError { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors0 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors1 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors2 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors3 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors4 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors5 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors6 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors7 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors8 { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4F Colors9 { get; set; }

        /// <summary>
        ///     The colors 10
        /// </summary>
        public Vector4F Colors10 { get; set; }

        /// <summary>
        ///     The colors 11
        /// </summary>
        public Vector4F Colors11 { get; set; }

        /// <summary>
        ///     The colors 12
        /// </summary>
        public Vector4F Colors12 { get; set; }

        /// <summary>
        ///     The colors 13
        /// </summary>
        public Vector4F Colors13 { get; set; }

        /// <summary>
        ///     The colors 14
        /// </summary>
        public Vector4F Colors14 { get; set; }

        /// <summary>
        ///     The colors 15
        /// </summary>
        public Vector4F Colors15 { get; set; }

        /// <summary>
        ///     The colors 16
        /// </summary>
        public Vector4F Colors16 { get; set; }

        /// <summary>
        ///     The colors 17
        /// </summary>
        public Vector4F Colors17 { get; set; }

        /// <summary>
        ///     The colors 18
        /// </summary>
        public Vector4F Colors18 { get; set; }

        /// <summary>
        ///     The colors 19
        /// </summary>
        public Vector4F Colors19 { get; set; }

        /// <summary>
        ///     The colors 20
        /// </summary>
        public Vector4F Colors20 { get; set; }

        /// <summary>
        ///     The colors 21
        /// </summary>
        public Vector4F Colors21 { get; set; }

        /// <summary>
        ///     The colors 22
        /// </summary>
        public Vector4F Colors22 { get; set; }

        /// <summary>
        ///     The colors 23
        /// </summary>
        public Vector4F Colors23 { get; set; }

        /// <summary>
        ///     The colors 24
        /// </summary>
        public Vector4F Colors24 { get; set; }

        /// <summary>
        ///     The colors 25
        /// </summary>
        public Vector4F Colors25 { get; set; }

        /// <summary>
        ///     The colors 26
        /// </summary>
        public Vector4F Colors26 { get; set; }

        /// <summary>
        ///     The colors 27
        /// </summary>
        public Vector4F Colors27 { get; set; }

        /// <summary>
        ///     The colors 28
        /// </summary>
        public Vector4F Colors28 { get; set; }

        /// <summary>
        ///     The colors 29
        /// </summary>
        public Vector4F Colors29 { get; set; }

        /// <summary>
        ///     The colors 30
        /// </summary>
        public Vector4F Colors30 { get; set; }

        /// <summary>
        ///     The colors 31
        /// </summary>
        public Vector4F Colors31 { get; set; }

        /// <summary>
        ///     The colors 32
        /// </summary>
        public Vector4F Colors32 { get; set; }

        /// <summary>
        ///     The colors 33
        /// </summary>
        public Vector4F Colors33 { get; set; }

        /// <summary>
        ///     The colors 34
        /// </summary>
        public Vector4F Colors34 { get; set; }

        /// <summary>
        ///     The colors 35
        /// </summary>
        public Vector4F Colors35 { get; set; }

        /// <summary>
        ///     The colors 36
        /// </summary>
        public Vector4F Colors36 { get; set; }

        /// <summary>
        ///     The colors 37
        /// </summary>
        public Vector4F Colors37 { get; set; }

        /// <summary>
        ///     The colors 38
        /// </summary>
        public Vector4F Colors38 { get; set; }

        /// <summary>
        ///     The colors 39
        /// </summary>
        public Vector4F Colors39 { get; set; }

        /// <summary>
        ///     The colors 40
        /// </summary>
        public Vector4F Colors40 { get; set; }

        /// <summary>
        ///     The colors 41
        /// </summary>
        public Vector4F Colors41 { get; set; }

        /// <summary>
        ///     The colors 42
        /// </summary>
        public Vector4F Colors42 { get; set; }

        /// <summary>
        ///     The colors 43
        /// </summary>
        public Vector4F Colors43 { get; set; }

        /// <summary>
        ///     The colors 44
        /// </summary>
        public Vector4F Colors44 { get; set; }

        /// <summary>
        ///     The colors 45
        /// </summary>
        public Vector4F Colors45 { get; set; }

        /// <summary>
        ///     The colors 46
        /// </summary>
        public Vector4F Colors46 { get; set; }

        /// <summary>
        ///     The colors 47
        /// </summary>
        public Vector4F Colors47 { get; set; }

        /// <summary>
        ///     The colors 48
        /// </summary>
        public Vector4F Colors48 { get; set; }

        /// <summary>
        ///     The colors 49
        /// </summary>
        public Vector4F Colors49 { get; set; }

        /// <summary>
        ///     The colors 50
        /// </summary>
        public Vector4F Colors50 { get; set; }

        /// <summary>
        ///     The colors 51
        /// </summary>
        public Vector4F Colors51 { get; set; }

        /// <summary>
        ///     The colors 52
        /// </summary>
        public Vector4F Colors52 { get; set; }

        /// <summary>
        ///     The colors 53
        /// </summary>
        public Vector4F Colors53 { get; set; }

        /// <summary>
        ///     The colors 54
        /// </summary>
        public Vector4F Colors54 { get; set; }

        /// <summary>
        /// The index out of range exception
        /// </summary>
        public Vector4F this[int index]
        {
            get
            {
                if (index < 0 || index >= 55)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                return index switch
                {
                    0 => Colors0,
                    1 => Colors1,
                    2 => Colors2,
                    3 => Colors3,
                    4 => Colors4,
                    5 => Colors5,
                    6 => Colors6,
                    7 => Colors7,
                    8 => Colors8,
                    9 => Colors9,
                    10 => Colors10,
                    11 => Colors11,
                    12 => Colors12,
                    13 => Colors13,
                    14 => Colors14,
                    15 => Colors15,
                    16 => Colors16,
                    17 => Colors17,
                    18 => Colors18,
                    19 => Colors19,
                    20 => Colors20,
                    21 => Colors21,
                    22 => Colors22,
                    23 => Colors23,
                    24 => Colors24,
                    25 => Colors25,
                    26 => Colors26,
                    27 => Colors27,
                    28 => Colors28,
                    29 => Colors29,
                    30 => Colors30,
                    31 => Colors31,
                    32 => Colors32,
                    33 => Colors33,
                    34 => Colors34,
                    35 => Colors35,
                    36 => Colors36,
                    37 => Colors37,
                    38 => Colors38,
                    39 => Colors39,
                    40 => Colors40,
                    41 => Colors41,
                    42 => Colors42,
                    43 => Colors43,
                    44 => Colors44,
                    45 => Colors45,
                    46 => Colors46,
                    47 => Colors47,
                    48 => Colors48,
                    49 => Colors49,
                    50 => Colors50,
                    51 => Colors51,
                    52 => Colors52,
                    53 => Colors53,
                    54 => Colors54,
                    _ => throw new IndexOutOfRangeException("Index out of range")
                };
            }
            set
            {
                if (index < 0 || index >= 55)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                switch (index)
                {
                    case 0: Colors0 = value; break;
                    case 1: Colors1 = value; break;
                    case 2: Colors2 = value; break;
                    case 3: Colors3 = value; break;
                    case 4: Colors4 = value; break;
                    case 5: Colors5 = value; break;
                    case 6: Colors6 = value; break;
                    case 7: Colors7 = value; break;
                    case 8: Colors8 = value; break;
                    case 9: Colors9 = value; break;
                    case 10: Colors10 = value; break;
                    case 11: Colors11 = value; break;
                    case 12: Colors12 = value; break;
                    case 13: Colors13 = value; break;
                    case 14: Colors14 = value; break;
                    case 15: Colors15 = value; break;
                    case 16: Colors16 = value; break;
                    case 17: Colors17 = value; break;
                    case 18: Colors18 = value; break;
                    case 19: Colors19 = value; break;
                    case 20: Colors20 = value; break;
                    case 21: Colors21 = value; break;
                    case 22: Colors22 = value; break;
                    case 23: Colors23 = value; break;
                    case 24: Colors24 = value; break;
                    case 25: Colors25 = value; break;
                    case 26: Colors26 = value; break;
                    case 27: Colors27 = value; break;
                    case 28: Colors28 = value; break;
                    case 29: Colors29 = value; break;
                    case 30: Colors30 = value; break;
                    case 31: Colors31 = value; break;
                    case 32: Colors32 = value; break;
                    case 33: Colors33 = value; break;
                    case 34: Colors34 = value; break;
                    case 35: Colors35 = value; break;
                    case 36: Colors36 = value; break;
                    case 37: Colors37 = value; break;
                    case 38: Colors38 = value; break;
                    case 39: Colors39 = value; break;
                    case 40: Colors40 = value; break;
                    case 41: Colors41 = value; break;
                    case 42: Colors42 = value; break;
                    case 43: Colors43 = value; break;
                    case 44: Colors44 = value; break;
                    case 45: Colors45 = value; break;
                    case 46: Colors46 = value; break;
                    case 47: Colors47 = value; break;
                    case 48: Colors48 = value; break;
                    case 49: Colors49 = value; break;
                    case 50: Colors50 = value; break;
                    case 51: Colors51 = value; break;
                    case 52: Colors52 = value; break;
                    case 53: Colors53 = value; break;
                    case 54: Colors54 = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }
    }
}