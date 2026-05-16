// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLocation.cs
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
    ///     Predefined anchor locations for positioning elements such as the legend or annotations within a plot.
    /// </summary>
    public enum ImPlotLocation
    {
        /// <summary>
        ///     Center of the plot area.
        /// </summary>
        Center = 0,

        /// <summary>
        ///     Top-left corner.
        /// </summary>
        NorthWest = 1,

        /// <summary>
        ///     Top-right corner.
        /// </summary>
        NorthEast = 2,

        /// <summary>
        ///     Bottom-left corner.
        /// </summary>
        SouthWest = 3,

        /// <summary>
        ///     Bottom-right corner.
        /// </summary>
        SouthEast = 4,

        /// <summary>
        ///     Top-center edge.
        /// </summary>
        North = 5,

        /// <summary>
        ///     Bottom-center edge.
        /// </summary>
        South = 6,

        /// <summary>
        ///     Middle-left edge.
        /// </summary>
        West = 7,

        /// <summary>
        ///     Middle-right edge.
        /// </summary>
        East = 8
    }
}