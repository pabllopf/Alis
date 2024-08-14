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
        public Vector2 WindowPadding { get; set; }
        
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
        public Vector2 WindowMinSize { get; set; }
        
        /// <summary>
        ///     The window title align
        /// </summary>
        public Vector2 WindowTitleAlign { get; set; }
        
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
        public Vector2 FramePadding { get; set; }
        
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
        public Vector2 ItemSpacing { get; set; }
        
        /// <summary>
        ///     The item inner spacing
        /// </summary>
        public Vector2 ItemInnerSpacing { get; set; }
        
        /// <summary>
        ///     The cell padding
        /// </summary>
        public Vector2 CellPadding { get; set; }
        
        /// <summary>
        ///     The touch extra padding
        /// </summary>
        public Vector2 TouchExtraPadding { get; set; }
        
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
        public Vector2 ButtonTextAlign { get; set; }
        
        /// <summary>
        ///     The selectable text align
        /// </summary>
        public Vector2 SelectableTextAlign { get; set; }
        
        /// <summary>
        ///     The display window padding
        /// </summary>
        public Vector2 DisplayWindowPadding { get; set; }
        
        /// <summary>
        ///     The display safe area padding
        /// </summary>
        public Vector2 DisplaySafeAreaPadding { get; set; }
        
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
        public Vector4 Colors0 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors1 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors2 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors3 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors4 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors5 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors6 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors7 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors8 { get; set; }
        
        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors9 { get; set; }
        
        /// <summary>
        ///     The colors 10
        /// </summary>
        public Vector4 Colors10 { get; set; }
        
        /// <summary>
        ///     The colors 11
        /// </summary>
        public Vector4 Colors11 { get; set; }
        
        /// <summary>
        ///     The colors 12
        /// </summary>
        public Vector4 Colors12 { get; set; }
        
        /// <summary>
        ///     The colors 13
        /// </summary>
        public Vector4 Colors13 { get; set; }
        
        /// <summary>
        ///     The colors 14
        /// </summary>
        public Vector4 Colors14 { get; set; }
        
        /// <summary>
        ///     The colors 15
        /// </summary>
        public Vector4 Colors15 { get; set; }
        
        /// <summary>
        ///     The colors 16
        /// </summary>
        public Vector4 Colors16 { get; set; }
        
        /// <summary>
        ///     The colors 17
        /// </summary>
        public Vector4 Colors17 { get; set; }
        
        /// <summary>
        ///     The colors 18
        /// </summary>
        public Vector4 Colors18 { get; set; }
        
        /// <summary>
        ///     The colors 19
        /// </summary>
        public Vector4 Colors19 { get; set; }
        
        /// <summary>
        ///     The colors 20
        /// </summary>
        public Vector4 Colors20 { get; set; }
        
        /// <summary>
        ///     The colors 21
        /// </summary>
        public Vector4 Colors21 { get; set; }
        
        /// <summary>
        ///     The colors 22
        /// </summary>
        public Vector4 Colors22 { get; set; }
        
        /// <summary>
        ///     The colors 23
        /// </summary>
        public Vector4 Colors23 { get; set; }
        
        /// <summary>
        ///     The colors 24
        /// </summary>
        public Vector4 Colors24 { get; set; }
        
        /// <summary>
        ///     The colors 25
        /// </summary>
        public Vector4 Colors25 { get; set; }
        
        /// <summary>
        ///     The colors 26
        /// </summary>
        public Vector4 Colors26 { get; set; }
        
        /// <summary>
        ///     The colors 27
        /// </summary>
        public Vector4 Colors27 { get; set; }
        
        /// <summary>
        ///     The colors 28
        /// </summary>
        public Vector4 Colors28 { get; set; }
        
        /// <summary>
        ///     The colors 29
        /// </summary>
        public Vector4 Colors29 { get; set; }
        
        /// <summary>
        ///     The colors 30
        /// </summary>
        public Vector4 Colors30 { get; set; }
        
        /// <summary>
        ///     The colors 31
        /// </summary>
        public Vector4 Colors31 { get; set; }
        
        /// <summary>
        ///     The colors 32
        /// </summary>
        public Vector4 Colors32 { get; set; }
        
        /// <summary>
        ///     The colors 33
        /// </summary>
        public Vector4 Colors33 { get; set; }
        
        /// <summary>
        ///     The colors 34
        /// </summary>
        public Vector4 Colors34 { get; set; }
        
        /// <summary>
        ///     The colors 35
        /// </summary>
        public Vector4 Colors35 { get; set; }
        
        /// <summary>
        ///     The colors 36
        /// </summary>
        public Vector4 Colors36 { get; set; }
        
        /// <summary>
        ///     The colors 37
        /// </summary>
        public Vector4 Colors37 { get; set; }
        
        /// <summary>
        ///     The colors 38
        /// </summary>
        public Vector4 Colors38 { get; set; }
        
        /// <summary>
        ///     The colors 39
        /// </summary>
        public Vector4 Colors39 { get; set; }
        
        /// <summary>
        ///     The colors 40
        /// </summary>
        public Vector4 Colors40 { get; set; }
        
        /// <summary>
        ///     The colors 41
        /// </summary>
        public Vector4 Colors41 { get; set; }
        
        /// <summary>
        ///     The colors 42
        /// </summary>
        public Vector4 Colors42 { get; set; }
        
        /// <summary>
        ///     The colors 43
        /// </summary>
        public Vector4 Colors43 { get; set; }
        
        /// <summary>
        ///     The colors 44
        /// </summary>
        public Vector4 Colors44 { get; set; }
        
        /// <summary>
        ///     The colors 45
        /// </summary>
        public Vector4 Colors45 { get; set; }
        
        /// <summary>
        ///     The colors 46
        /// </summary>
        public Vector4 Colors46 { get; set; }
        
        /// <summary>
        ///     The colors 47
        /// </summary>
        public Vector4 Colors47 { get; set; }
        
        /// <summary>
        ///     The colors 48
        /// </summary>
        public Vector4 Colors48 { get; set; }
        
        /// <summary>
        ///     The colors 49
        /// </summary>
        public Vector4 Colors49 { get; set; }
        
        /// <summary>
        ///     The colors 50
        /// </summary>
        public Vector4 Colors50 { get; set; }
        
        /// <summary>
        ///     The colors 51
        /// </summary>
        public Vector4 Colors51 { get; set; }
        
        /// <summary>
        ///     The colors 52
        /// </summary>
        public Vector4 Colors52 { get; set; }
        
        /// <summary>
        ///     The colors 53
        /// </summary>
        public Vector4 Colors53 { get; set; }
        
        /// <summary>
        ///     The colors 54
        /// </summary>
        public Vector4 Colors54 { get; set; }
    }
}