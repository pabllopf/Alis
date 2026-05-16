// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotMarker.cs
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
    ///     Defines the shape of markers used for data points in ImPlot plots.
    /// </summary>
    public enum ImPlotMarker
    {
        /// <summary>
        ///     No marker is drawn.
        /// </summary>
        None = -1,

        /// <summary>
        ///     Circular marker.
        /// </summary>
        Circle = 0,

        /// <summary>
        ///     Square marker.
        /// </summary>
        Square = 1,

        /// <summary>
        ///     Diamond-shaped marker.
        /// </summary>
        Diamond = 2,

        /// <summary>
        ///     Upward-pointing triangle marker.
        /// </summary>
        Up = 3,

        /// <summary>
        ///     Downward-pointing triangle marker.
        /// </summary>
        Down = 4,

        /// <summary>
        ///     Left-pointing triangle marker.
        /// </summary>
        Left = 5,

        /// <summary>
        ///     Right-pointing triangle marker.
        /// </summary>
        Right = 6,

        /// <summary>
        ///     Cross (X) marker.
        /// </summary>
        Cross = 7,

        /// <summary>
        ///     Plus (+) marker.
        /// </summary>
        Plus = 8,

        /// <summary>
        ///     Asterisk (*) marker.
        /// </summary>
        Asterisk = 9
    }
}