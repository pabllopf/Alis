// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImAxis.cs
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
    ///     Defines the available axes in an ImPlot plot for positioning data along X and Y dimensions.
    /// </summary>
    public enum ImAxis
    {
        /// <summary>
        ///     Primary X axis (bottom).
        /// </summary>
        X1 = 0,

        /// <summary>
        ///     Secondary X axis (top), enabled with ImPlotAxisFlags.AuxDefault.
        /// </summary>
        X2 = 1,

        /// <summary>
        ///     Tertiary X axis, available for multi-axis plots.
        /// </summary>
        X3 = 2,

        /// <summary>
        ///     Primary Y axis (left).
        /// </summary>
        Y1 = 3,

        /// <summary>
        ///     Secondary Y axis (right), enabled with ImPlotAxisFlags.AuxDefault.
        /// </summary>
        Y2 = 4,

        /// <summary>
        ///     Tertiary Y axis, available for multi-axis plots.
        /// </summary>
        Y3 = 5,

        /// <summary>
        ///     Total number of axis slots defined.
        /// </summary>
        Count = 6
    }
}