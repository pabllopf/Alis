// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotSubplotFlags.cs
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
    ///     Flags that control the layout and behaviour of subplot grids in ImPlot.
    /// </summary>
    [Flags]
    public enum ImPlotSubplotFlags
    {
        /// <summary>
        ///     Default subplot behaviour with titles, legends, menus, and resizing enabled.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Hide titles on subplots.
        /// </summary>
        NoTitle = 1,

        /// <summary>
        ///     Hide legends on subplots.
        /// </summary>
        NoLegend = 2,

        /// <summary>
        ///     Disable context menus on subplots.
        /// </summary>
        NoMenus = 4,

        /// <summary>
        ///     Disable resizing of subplot cells.
        /// </summary>
        NoResize = 8,

        /// <summary>
        ///     Disable automatic alignment of axes across subplots.
        /// </summary>
        NoAlign = 16,

        /// <summary>
        ///     Link the row heights of all subplots in the same row.
        /// </summary>
        LinkRows = 32,

        /// <summary>
        ///     Link the column widths of all subplots in the same column.
        /// </summary>
        LinkCols = 64,

        /// <summary>
        ///     Link the X axis ranges across all subplots.
        /// </summary>
        LinkAllX = 128,

        /// <summary>
        ///     Link the Y axis ranges across all subplots.
        /// </summary>
        LinkAllY = 256,

        /// <summary>
        ///     Draw a colored frame border around each subplot.
        /// </summary>
        ColoredFrame = 512
    }
}