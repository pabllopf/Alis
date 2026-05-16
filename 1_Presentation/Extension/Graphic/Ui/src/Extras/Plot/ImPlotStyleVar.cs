// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStyleVar.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Style variables that can be pushed/popped to customize the look of ImPlot elements.
    /// </summary>
    public enum ImPlotStyleVar
    {
        /// <summary>
        ///     Thickness (weight) of plot lines, in pixels.
        /// </summary>
        LineWeight = 0,

        /// <summary>
        ///     Marker type used for data points.
        /// </summary>
        Marker = 1,

        /// <summary>
        ///     Size of markers, in pixels.
        /// </summary>
        MarkerSize = 2,

        /// <summary>
        ///     Thickness (weight) of marker outlines, in pixels.
        /// </summary>
        MarkerWeight = 3,

        /// <summary>
        ///     Alpha transparency of filled regions.
        /// </summary>
        FillAlpha = 4,

        /// <summary>
        ///     Width of error bar caps, in pixels.
        /// </summary>
        ErrorBarSize = 5,

        /// <summary>
        ///     Thickness (weight) of error bar lines, in pixels.
        /// </summary>
        ErrorBarWeight = 6,

        /// <summary>
        ///     Height of digital signal bits, in pixels.
        /// </summary>
        DigitalBitHeight = 7,

        /// <summary>
        ///     Gap between adjacent digital signal bits, in pixels.
        /// </summary>
        DigitalBitGap = 8,

        /// <summary>
        ///     Thickness of the plot border, in pixels.
        /// </summary>
        PlotBorderSize = 9,

        /// <summary>
        ///     Alpha transparency of minor (non-primary) plot elements.
        /// </summary>
        MinorAlpha = 10,

        /// <summary>
        ///     Length of major tick marks, in pixels.
        /// </summary>
        MajorTickLen = 11,

        /// <summary>
        ///     Length of minor tick marks, in pixels.
        /// </summary>
        MinorTickLen = 12,

        /// <summary>
        ///     Thickness of major tick marks, in pixels.
        /// </summary>
        MajorTickSize = 13,

        /// <summary>
        ///     Thickness of minor tick marks, in pixels.
        /// </summary>
        MinorTickSize = 14,

        /// <summary>
        ///     Thickness of major grid lines, in pixels.
        /// </summary>
        MajorGridSize = 15,

        /// <summary>
        ///     Thickness of minor grid lines, in pixels.
        /// </summary>
        MinorGridSize = 16,

        /// <summary>
        ///     Padding between the plot area and its frame, in pixels.
        /// </summary>
        PlotPadding = 17,

        /// <summary>
        ///     Padding between axis labels and the plot edge, in pixels.
        /// </summary>
        LabelPadding = 18,

        /// <summary>
        ///     Padding around the legend box, in pixels.
        /// </summary>
        LegendPadding = 19,

        /// <summary>
        ///     Inner padding within the legend box, in pixels.
        /// </summary>
        LegendInnerPadding = 20,

        /// <summary>
        ///     Spacing between legend entries, in pixels.
        /// </summary>
        LegendSpacing = 21,

        /// <summary>
        ///     Padding around the mouse position tooltip text, in pixels.
        /// </summary>
        MousePosPadding = 22,

        /// <summary>
        ///     Padding around annotation labels, in pixels.
        /// </summary>
        AnnotationPadding = 23,

        /// <summary>
        ///     Padding applied when auto-fitting the axis range to data.
        /// </summary>
        FitPadding = 24,

        /// <summary>
        ///     Default size of newly created plots (width, height).
        /// </summary>
        PlotDefaultSize = 25,

        /// <summary>
        ///     Minimum size allowed for a plot (width, height).
        /// </summary>
        PlotMinSize = 26,

        /// <summary>
        ///     Total number of style variables defined.
        /// </summary>
        Count = 27
    }
}