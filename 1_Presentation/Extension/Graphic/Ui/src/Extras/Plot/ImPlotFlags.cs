// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotFlags.cs
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
    ///     Flags that control the overall appearance and behaviour of an ImPlot plot.
    /// </summary>
    [Flags]
    public enum ImPlotFlags
    {
        /// <summary>
        ///     Default plot appearance with title, legend, frame, mouse text, and inputs enabled.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Hide the plot title.
        /// </summary>
        NoTitle = 1,

        /// <summary>
        ///     Hide the plot legend.
        /// </summary>
        NoLegend = 2,

        /// <summary>
        ///     Hide the mouse position tooltip text.
        /// </summary>
        NoMouseText = 4,

        /// <summary>
        ///     Disable all mouse and keyboard input interaction with the plot.
        /// </summary>
        NoInputs = 8,

        /// <summary>
        ///     Disable the plot's context menu.
        /// </summary>
        NoMenus = 16,

        /// <summary>
        ///     Disable box-select functionality (drag to zoom).
        /// </summary>
        NoBoxSelect = 32,

        /// <summary>
        ///     Do not create a child window for the plot.
        /// </summary>
        NoChild = 64,

        /// <summary>
        ///     Remove the frame (border) drawn around the plot area.
        /// </summary>
        NoFrame = 128,

        /// <summary>
        ///     Force equal aspect ratio for X and Y axes.
        /// </summary>
        Equal = 256,

        /// <summary>
        ///     Draw crosshairs cursor lines on the plot.
        /// </summary>
        Crosshairs = 512,

        /// <summary>
        ///     Shorthand for NoTitle | NoLegend | NoMouseText | NoInputs | NoMenus | NoBoxSelect | NoChild | NoFrame.
        /// </summary>
        CanvasOnly = 200
    }
}