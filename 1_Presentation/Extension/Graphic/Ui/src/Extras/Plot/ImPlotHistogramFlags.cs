// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotHistogramFlags.cs
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
    ///     Flags that control the appearance and computation of histograms in ImPlot.
    /// </summary>
    [Flags]
    public enum ImPlotHistogramFlags
    {
        /// <summary>
        ///     Default vertical histogram.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Draw bars horizontally instead of vertically.
        /// </summary>
        Horizontal = 1024,

        /// <summary>
        ///     Display cumulative distribution (running total) instead of raw counts.
        /// </summary>
        Cumulative = 2048,

        /// <summary>
        ///     Normalize bin counts to produce a probability density function.
        /// </summary>
        Density = 4096,

        /// <summary>
        ///     Exclude outlier bins from the displayed range.
        /// </summary>
        NoOutliers = 8192,

        /// <summary>
        ///     Interpret input data as column-major instead of row-major.
        /// </summary>
        ColMajor = 16384
    }
}