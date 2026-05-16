// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLineFlags.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Flags that control the appearance and rendering of line plots in ImPlot.
    /// </summary>
    [Flags]
    public enum ImPlotLineFlags
    {
        /// <summary>
        ///     Default continuous line with clipping and fitting enabled.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Disable segment-level rendering (draw line as a single strip).
        /// </summary>
        NoSegments = 1,

        /// <summary>
        ///     Exclude this line from automatic axis fitting.
        /// </summary>
        NoFit = 2,

        /// <summary>
        ///     Render the line as a stepped (stair-step) plot.
        /// </summary>
        Stepped = 4,

        /// <summary>
        ///     Connect the last point back to the first, forming a closed loop.
        /// </summary>
        Loop = 8,

        /// <summary>
        ///     Skip NaN values when drawing the line, creating gaps.
        /// </summary>
        SkipNaN = 16,

        /// <summary>
        ///     Disable clipping of the line to the plot area boundaries.
        /// </summary>
        NoClip = 32,

        /// <summary>
        ///     Do not draw a baseline (zero-line fill) for this line.
        /// </summary>
        NoBaseline = 64,

        /// <summary>
        ///     Interpret Y values as X and vice versa, drawing horizontal lines.
        /// </summary>
        Horizontal = 1024
    }
}