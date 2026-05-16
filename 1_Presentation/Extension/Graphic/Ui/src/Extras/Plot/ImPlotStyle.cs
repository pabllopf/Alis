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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Stores all style configuration values for customizing the appearance of ImPlot plots.
    /// </summary>
    public struct ImPlotStyle
    {
        /// <summary>
        ///     Thickness of plot lines in pixels.
        /// </summary>
        public float LineWeight { get; set; }

        /// <summary>
        ///     Marker style index (see ImPlotMarker enum).
        /// </summary>
        public int Marker { get; set; }

        /// <summary>
        ///     Size of markers in pixels.
        /// </summary>
        public float MarkerSize { get; set; }

        /// <summary>
        ///     Thickness of marker outlines in pixels.
        /// </summary>
        public float MarkerWeight { get; set; }

        /// <summary>
        ///     Alpha transparency for filled regions.
        /// </summary>
        public float FillAlpha { get; set; }

        /// <summary>
        ///     Width of error bar cap lines in pixels.
        /// </summary>
        public float ErrorBarSize { get; set; }

        /// <summary>
        ///     Thickness of error bar lines in pixels.
        /// </summary>
        public float ErrorBarWeight { get; set; }

        /// <summary>
        ///     Height of digital signal bits in pixels.
        /// </summary>
        public float DigitalBitHeight { get; set; }

        /// <summary>
        ///     Gap between adjacent digital signal bits in pixels.
        /// </summary>
        public float DigitalBitGap { get; set; }

        /// <summary>
        ///     Thickness of the border drawn around the plot area in pixels.
        /// </summary>
        public float PlotBorderSize { get; set; }

        /// <summary>
        ///     Alpha transparency for minor (non-primary) plot elements.
        /// </summary>
        public float MinorAlpha { get; set; }

        /// <summary>
        ///     Length of major tick marks as a Vector2F (X, Y axes).
        /// </summary>
        public Vector2F MajorTickLen { get; set; }

        /// <summary>
        ///     Length of minor tick marks as a Vector2F (X, Y axes).
        /// </summary>
        public Vector2F MinorTickLen { get; set; }

        /// <summary>
        ///     Thickness of major tick marks as a Vector2F (X, Y axes).
        /// </summary>
        public Vector2F MajorTickSize { get; set; }

        /// <summary>
        ///     Thickness of minor tick marks as a Vector2F (X, Y axes).
        /// </summary>
        public Vector2F MinorTickSize { get; set; }

        /// <summary>
        ///     Thickness of major grid lines as a Vector2F (X, Y axes).
        /// </summary>
        public Vector2F MajorGridSize { get; set; }

        /// <summary>
        ///     Thickness of minor grid lines as a Vector2F (X, Y axes).
        /// </summary>
        public Vector2F MinorGridSize { get; set; }

        /// <summary>
        ///     Padding between the plot area and its containing frame as a Vector2F.
        /// </summary>
        public Vector2F PlotPadding { get; set; }

        /// <summary>
        ///     Padding between axis labels and the plot edge as a Vector2F.
        /// </summary>
        public Vector2F LabelPadding { get; set; }

        /// <summary>
        ///     Padding around the legend box as a Vector2F.
        /// </summary>
        public Vector2F LegendPadding { get; set; }

        /// <summary>
        ///     Inner padding within the legend box as a Vector2F.
        /// </summary>
        public Vector2F LegendInnerPadding { get; set; }

        /// <summary>
        ///     Spacing between adjacent legend entries as a Vector2F.
        /// </summary>
        public Vector2F LegendSpacing { get; set; }

        /// <summary>
        ///     Padding around the mouse position tooltip text as a Vector2F.
        /// </summary>
        public Vector2F MousePosPadding { get; set; }

        /// <summary>
        ///     Padding around annotation labels as a Vector2F.
        /// </summary>
        public Vector2F AnnotationPadding { get; set; }

        /// <summary>
        ///     Padding applied when auto-fitting the axis range to data as a Vector2F.
        /// </summary>
        public Vector2F FitPadding { get; set; }

        /// <summary>
        ///     Default (width, height) size for newly created plots.
        /// </summary>
        public Vector2F PlotDefaultSize { get; set; }

        /// <summary>
        ///     Minimum allowed (width, height) size for plots.
        /// </summary>
        public Vector2F PlotMinSize { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 0 (Line).
        /// </summary>
        public Vector4F Colors0 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 1 (Fill).
        /// </summary>
        public Vector4F Colors1 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 2 (MarkerOutline).
        /// </summary>
        public Vector4F Colors2 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 3 (MarkerFill).
        /// </summary>
        public Vector4F Colors3 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 4 (ErrorBar).
        /// </summary>
        public Vector4F Colors4 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 5 (FrameBg).
        /// </summary>
        public Vector4F Colors5 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 6 (PlotBg).
        /// </summary>
        public Vector4F Colors6 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 7 (PlotBorder).
        /// </summary>
        public Vector4F Colors7 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 8 (LegendBg).
        /// </summary>
        public Vector4F Colors8 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 9 (LegendBorder).
        /// </summary>
        public Vector4F Colors9 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 10 (LegendText).
        /// </summary>
        public Vector4F Colors10 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 11 (TitleText).
        /// </summary>
        public Vector4F Colors11 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 12 (InlayText).
        /// </summary>
        public Vector4F Colors12 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 13 (XAxis).
        /// </summary>
        public Vector4F Colors13 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 14 (XAxisGrid).
        /// </summary>
        public Vector4F Colors14 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 15 (YAxis).
        /// </summary>
        public Vector4F Colors15 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 16 (YAxisGrid).
        /// </summary>
        public Vector4F Colors16 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 17 (YAxis2).
        /// </summary>
        public Vector4F Colors17 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 18 (YAxisGrid2).
        /// </summary>
        public Vector4F Colors18 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 19 (XAxis2).
        /// </summary>
        public Vector4F Colors19 { get; set; }

        /// <summary>
        ///     Color value for ImPlotCol index 20 (XAxisGrid2).
        /// </summary>
        public Vector4F Colors20 { get; set; }

        /// <summary>
        ///     Active colormap used for coloring data series.
        /// </summary>
        public ImPlotColormap Colormap { get; set; }

        /// <summary>
        ///     Whether to display time values in local time (nonzero) or UTC (zero).
        /// </summary>
        public byte UseLocalTime { get; set; }

        /// <summary>
        ///     Whether to display dates in ISO 8601 format (nonzero) or a localized format (zero).
        /// </summary>
        public byte UseIso8601 { get; set; }

        /// <summary>
        ///     Whether to display time in 24-hour clock (nonzero) or 12-hour clock (zero).
        /// </summary>
        public byte Use24HourClock { get; set; }
    }
}