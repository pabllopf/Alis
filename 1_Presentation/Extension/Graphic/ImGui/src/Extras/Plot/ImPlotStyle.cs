// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStyle.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot style
    /// </summary>
    public struct ImPlotStyle
    {
        /// <summary>
        ///     The line weight
        /// </summary>
        public float LineWeight { get; set; }

        /// <summary>
        ///     The marker
        /// </summary>
        public int Marker { get; set; }

        /// <summary>
        ///     The marker size
        /// </summary>
        public float MarkerSize { get; set; }

        /// <summary>
        ///     The marker weight
        /// </summary>
        public float MarkerWeight { get; set; }

        /// <summary>
        ///     The fill alpha
        /// </summary>
        public float FillAlpha { get; set; }

        /// <summary>
        ///     The error bar size
        /// </summary>
        public float ErrorBarSize { get; set; }

        /// <summary>
        ///     The error bar weight
        /// </summary>
        public float ErrorBarWeight { get; set; }

        /// <summary>
        ///     The digital bit height
        /// </summary>
        public float DigitalBitHeight { get; set; }

        /// <summary>
        ///     The digital bit gap
        /// </summary>
        public float DigitalBitGap { get; set; }

        /// <summary>
        ///     The plot border size
        /// </summary>
        public float PlotBorderSize { get; set; }

        /// <summary>
        ///     The minor alpha
        /// </summary>
        public float MinorAlpha { get; set; }

        /// <summary>
        ///     The major tick len
        /// </summary>
        public Vector2 MajorTickLen { get; set; }

        /// <summary>
        ///     The minor tick len
        /// </summary>
        public Vector2 MinorTickLen { get; set; }

        /// <summary>
        ///     The major tick size
        /// </summary>
        public Vector2 MajorTickSize { get; set; }

        /// <summary>
        ///     The minor tick size
        /// </summary>
        public Vector2 MinorTickSize { get; set; }

        /// <summary>
        ///     The major grid size
        /// </summary>
        public Vector2 MajorGridSize { get; set; }

        /// <summary>
        ///     The minor grid size
        /// </summary>
        public Vector2 MinorGridSize { get; set; }

        /// <summary>
        ///     The plot padding
        /// </summary>
        public Vector2 PlotPadding { get; set; }

        /// <summary>
        ///     The label padding
        /// </summary>
        public Vector2 LabelPadding { get; set; }

        /// <summary>
        ///     The legend padding
        /// </summary>
        public Vector2 LegendPadding { get; set; }

        /// <summary>
        ///     The legend inner padding
        /// </summary>
        public Vector2 LegendInnerPadding { get; set; }

        /// <summary>
        ///     The legend spacing
        /// </summary>
        public Vector2 LegendSpacing { get; set; }

        /// <summary>
        ///     The mouse pos padding
        /// </summary>
        public Vector2 MousePosPadding { get; set; }

        /// <summary>
        ///     The annotation padding
        /// </summary>
        public Vector2 AnnotationPadding { get; set; }

        /// <summary>
        ///     The fit padding
        /// </summary>
        public Vector2 FitPadding { get; set; }

        /// <summary>
        ///     The plot default size
        /// </summary>
        public Vector2 PlotDefaultSize { get; set; }

        /// <summary>
        ///     The plot min size
        /// </summary>
        public Vector2 PlotMinSize { get; set; }

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
        ///     The colormap
        /// </summary>
        public ImPlotColormap Colormap { get; set; }

        /// <summary>
        ///     The use local time
        /// </summary>
        public byte UseLocalTime { get; set; }

        /// <summary>
        ///     The use iso 8601
        /// </summary>
        public byte UseIso8601 { get; set; }

        /// <summary>
        ///     The use 24 hour clock
        /// </summary>
        public byte Use24HourClock { get; set; }
    }
}