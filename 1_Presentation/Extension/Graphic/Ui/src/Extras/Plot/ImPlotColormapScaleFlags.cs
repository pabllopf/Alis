// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotColormapScaleFlags.cs
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
    ///     Flags that control the appearance of colormap scale bars in ImPlot.
    /// </summary>
    [Flags]
    public enum ImPlotColormapScaleFlags
    {
        /// <summary>
        ///     Default scale bar appearance with label on the right.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Hide the label on the colormap scale bar.
        /// </summary>
        NoLabel = 1,

        /// <summary>
        ///     Display the scale bar on the opposite side.
        /// </summary>
        Opposite = 2,

        /// <summary>
        ///     Invert the direction of the colormap scale (high to low).
        /// </summary>
        Invert = 4
    }
}