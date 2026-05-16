// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotCol.cs
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
    ///     Defines the color style indices used by ImPlot for theming plot elements.
    /// </summary>
    public enum ImPlotCol
    {
        /// <summary>
        ///     Color of plot line data.
        /// </summary>
        Line = 0,

        /// <summary>
        ///     Color of filled area under or within plot data.
        /// </summary>
        Fill = 1,

        /// <summary>
        ///     Color of the outline around markers.
        /// </summary>
        MarkerOutline = 2,

        /// <summary>
        ///     Color of the fill inside markers.
        /// </summary>
        MarkerFill = 3,

        /// <summary>
        ///     Color of error bars.
        /// </summary>
        ErrorBar = 4,

        /// <summary>
        ///     Background color of the plot frame area.
        /// </summary>
        FrameBg = 5,

        /// <summary>
        ///     Background color of the plot area (inside axes).
        /// </summary>
        PlotBg = 6,

        /// <summary>
        ///     Border color of the plot area.
        /// </summary>
        PlotBorder = 7,

        /// <summary>
        ///     Background color of the legend box.
        /// </summary>
        LegendBg = 8,

        /// <summary>
        ///     Border color of the legend box.
        /// </summary>
        LegendBorder = 9,

        /// <summary>
        ///     Text color of legend entries.
        /// </summary>
        LegendText = 10,

        /// <summary>
        ///     Text color of the plot title.
        /// </summary>
        TitleText = 11,

        /// <summary>
        ///     Text color of labels and annotations drawn inside the plot area.
        /// </summary>
        InlayText = 12,

        /// <summary>
        ///     Color of the primary X axis line and labels.
        /// </summary>
        XAxis = 13,

        /// <summary>
        ///     Color of the primary X axis grid lines.
        /// </summary>
        XAxisGrid = 14,

        /// <summary>
        ///     Color of the primary Y axis line and labels.
        /// </summary>
        YAxis = 15,

        /// <summary>
        ///     Color of the primary Y axis grid lines.
        /// </summary>
        YAxisGrid = 16,

        /// <summary>
        ///     Color of the secondary Y axis (Y2) line and labels.
        /// </summary>
        YAxis2 = 17,

        /// <summary>
        ///     Color of the secondary Y axis (Y2) grid lines.
        /// </summary>
        YAxisGrid2 = 18,

        /// <summary>
        ///     Color of the secondary X axis (X2) line and labels.
        /// </summary>
        XAxis2 = 19,

        /// <summary>
        ///     Color of the secondary X axis (X2) grid lines.
        /// </summary>
        XAxisGrid2 = 20,

        /// <summary>
        ///     Color of the tertiary Y axis (Y3) line and labels.
        /// </summary>
        YAxis3 = 21,

        /// <summary>
        ///     Color of the tertiary Y axis (Y3) grid lines.
        /// </summary>
        YAxisGrid3 = 22,

        /// <summary>
        ///     Color of the tertiary X axis (X3) line and labels.
        /// </summary>
        XAxis3 = 23,

        /// <summary>
        ///     Color of the tertiary X axis (X3) grid lines.
        /// </summary>
        XAxisGrid3 = 24,

        /// <summary>
        ///     Color of the selection rectangle (drag-select box).
        /// </summary>
        Selection = 25,

        /// <summary>
        ///     Color of the query rectangle (drag-query area).
        /// </summary>
        Query = 26,

        /// <summary>
        ///     Color of the crosshairs cursor lines.
        /// </summary>
        Crosshairs = 27,

        /// <summary>
        ///     Total number of color style elements defined.
        /// </summary>
        Count = 28
    }
}