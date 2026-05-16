// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLegendFlags.cs
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
    ///     Flags that control the appearance and interaction behaviour of the plot legend in ImPlot.
    /// </summary>
    [Flags]
    public enum ImPlotLegendFlags
    {
        /// <summary>
        ///     Default legend with show/hide buttons and item highlighting enabled.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Hide the show/hide buttons next to legend entries.
        /// </summary>
        NoButtons = 1,

        /// <summary>
        ///     Disable highlighting of plot items when hovering legend entries.
        /// </summary>
        NoHighlightItem = 2,

        /// <summary>
        ///     Disable highlighting of axes when hovering legend axis labels.
        /// </summary>
        NoHighlightAxis = 4,

        /// <summary>
        ///     Disable the legend's context menu.
        /// </summary>
        NoMenus = 8,

        /// <summary>
        ///     Arrange legend entries horizontally instead of vertically.
        /// </summary>
        Horizontal = 1024,

        /// <summary>
        ///     Position the legend outside the plot area.
        /// </summary>
        Outside = 2048,

        /// <summary>
        ///     Sort legend entries alphabetically.
        /// </summary>
        Sort = 4096
    }
}