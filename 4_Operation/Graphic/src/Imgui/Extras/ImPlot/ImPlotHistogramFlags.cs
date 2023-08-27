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

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    ///     The im plot histogram flags enum
    /// </summary>
    [Flags]
    public enum ImPlotHistogramFlags
    {
        /// <summary>
        ///     The none im plot histogram flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The horizontal im plot histogram flags
        /// </summary>
        Horizontal = 1024,

        /// <summary>
        ///     The cumulative im plot histogram flags
        /// </summary>
        Cumulative = 2048,

        /// <summary>
        ///     The density im plot histogram flags
        /// </summary>
        Density = 4096,

        /// <summary>
        ///     The no outliers im plot histogram flags
        /// </summary>
        NoOutliers = 8192,

        /// <summary>
        ///     The col major im plot histogram flags
        /// </summary>
        ColMajor = 16384
    }
}