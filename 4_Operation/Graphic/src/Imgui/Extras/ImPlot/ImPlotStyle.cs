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

using System.Numerics;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    ///     The im plot style
    /// </summary>
    public struct ImPlotStyle
    {
        /// <summary>
        ///     The line weight
        /// </summary>
        public float LineWeight;

        /// <summary>
        ///     The marker
        /// </summary>
        public int Marker;

        /// <summary>
        ///     The marker size
        /// </summary>
        public float MarkerSize;

        /// <summary>
        ///     The marker weight
        /// </summary>
        public float MarkerWeight;

        /// <summary>
        ///     The fill alpha
        /// </summary>
        public float FillAlpha;

        /// <summary>
        ///     The error bar size
        /// </summary>
        public float ErrorBarSize;

        /// <summary>
        ///     The error bar weight
        /// </summary>
        public float ErrorBarWeight;

        /// <summary>
        ///     The digital bit height
        /// </summary>
        public float DigitalBitHeight;

        /// <summary>
        ///     The digital bit gap
        /// </summary>
        public float DigitalBitGap;

        /// <summary>
        ///     The plot border size
        /// </summary>
        public float PlotBorderSize;

        /// <summary>
        ///     The minor alpha
        /// </summary>
        public float MinorAlpha;

        /// <summary>
        ///     The major tick len
        /// </summary>
        public Vector2 MajorTickLen;

        /// <summary>
        ///     The minor tick len
        /// </summary>
        public Vector2 MinorTickLen;

        /// <summary>
        ///     The major tick size
        /// </summary>
        public Vector2 MajorTickSize;

        /// <summary>
        ///     The minor tick size
        /// </summary>
        public Vector2 MinorTickSize;

        /// <summary>
        ///     The major grid size
        /// </summary>
        public Vector2 MajorGridSize;

        /// <summary>
        ///     The minor grid size
        /// </summary>
        public Vector2 MinorGridSize;

        /// <summary>
        ///     The plot padding
        /// </summary>
        public Vector2 PlotPadding;

        /// <summary>
        ///     The label padding
        /// </summary>
        public Vector2 LabelPadding;

        /// <summary>
        ///     The legend padding
        /// </summary>
        public Vector2 LegendPadding;

        /// <summary>
        ///     The legend inner padding
        /// </summary>
        public Vector2 LegendInnerPadding;

        /// <summary>
        ///     The legend spacing
        /// </summary>
        public Vector2 LegendSpacing;

        /// <summary>
        ///     The mouse pos padding
        /// </summary>
        public Vector2 MousePosPadding;

        /// <summary>
        ///     The annotation padding
        /// </summary>
        public Vector2 AnnotationPadding;

        /// <summary>
        ///     The fit padding
        /// </summary>
        public Vector2 FitPadding;

        /// <summary>
        ///     The plot default size
        /// </summary>
        public Vector2 PlotDefaultSize;

        /// <summary>
        ///     The plot min size
        /// </summary>
        public Vector2 PlotMinSize;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors0;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors1;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors2;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors3;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors4;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors5;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors6;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors7;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors8;

        /// <summary>
        ///     The colors
        /// </summary>
        public Vector4 Colors9;

        /// <summary>
        ///     The colors 10
        /// </summary>
        public Vector4 Colors10;

        /// <summary>
        ///     The colors 11
        /// </summary>
        public Vector4 Colors11;

        /// <summary>
        ///     The colors 12
        /// </summary>
        public Vector4 Colors12;

        /// <summary>
        ///     The colors 13
        /// </summary>
        public Vector4 Colors13;

        /// <summary>
        ///     The colors 14
        /// </summary>
        public Vector4 Colors14;

        /// <summary>
        ///     The colors 15
        /// </summary>
        public Vector4 Colors15;

        /// <summary>
        ///     The colors 16
        /// </summary>
        public Vector4 Colors16;

        /// <summary>
        ///     The colors 17
        /// </summary>
        public Vector4 Colors17;

        /// <summary>
        ///     The colors 18
        /// </summary>
        public Vector4 Colors18;

        /// <summary>
        ///     The colors 19
        /// </summary>
        public Vector4 Colors19;

        /// <summary>
        ///     The colors 20
        /// </summary>
        public Vector4 Colors20;

        /// <summary>
        ///     The colormap
        /// </summary>
        public ImPlotColormap Colormap;

        /// <summary>
        ///     The use local time
        /// </summary>
        public byte UseLocalTime;

        /// <summary>
        ///     The use iso 8601
        /// </summary>
        public byte UseIso8601;

        /// <summary>
        ///     The use 24 hour clock
        /// </summary>
        public byte Use24HourClock;
    }
}