// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotAxisFlags.cs
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
    ///     Flags that control the appearance and behaviour of plot axes in ImPlot.
    /// </summary>
    [Flags]
    public enum ImPlotAxisFlags
    {
        /// <summary>
        ///     Default axis behaviour with all standard decorations shown.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Hide the axis label.
        /// </summary>
        NoLabel = 1,

        /// <summary>
        ///     Hide the grid lines for this axis.
        /// </summary>
        NoGridLines = 2,

        /// <summary>
        ///     Hide the tick marks on this axis.
        /// </summary>
        NoTickMarks = 4,

        /// <summary>
        ///     Hide the tick label text on this axis.
        /// </summary>
        NoTickLabels = 8,

        /// <summary>
        ///     Do not apply an initial fit to the data range when the plot opens.
        /// </summary>
        NoInitialFit = 16,

        /// <summary>
        ///     Disable the context menu for this axis.
        /// </summary>
        NoMenus = 32,

        /// <summary>
        ///     Prevent the user from switching the axis side via the context menu.
        /// </summary>
        NoSideSwitch = 64,

        /// <summary>
        ///     Disable highlighting of the axis when hovered.
        /// </summary>
        NoHighlight = 128,

        /// <summary>
        ///     Render this axis on the opposite side (e.g. right for Y, top for X).
        /// </summary>
        Opposite = 256,

        /// <summary>
        ///     Render axis grid lines and ticks in the foreground, above plot data.
        /// </summary>
        Foreground = 512,

        /// <summary>
        ///     Invert the axis direction (descending values).
        /// </summary>
        Invert = 1024,

        /// <summary>
        ///     Automatically fit the axis range to visible data at every frame.
        /// </summary>
        AutoFit = 2048,

        /// <summary>
        ///     Fit the axis range only when data within the range changes.
        /// </summary>
        RangeFit = 4096,

        /// <summary>
        ///     Allow the axis to stretch during pan operations.
        /// </summary>
        PanStretch = 8192,

        /// <summary>
        ///     Lock the minimum value of the axis range.
        /// </summary>
        LockMin = 16384,

        /// <summary>
        ///     Lock the maximum value of the axis range.
        /// </summary>
        LockMax = 32768,

        /// <summary>
        ///     Lock both the minimum and maximum values of the axis range (LockMin | LockMax).
        /// </summary>
        Lock = 49152,

        /// <summary>
        ///     Shorthand for NoLabel | NoGridLines | NoTickMarks | NoTickLabels, removing all axis decorations.
        /// </summary>
        NoDecorations = 15,

        /// <summary>
        ///     Default flags for auxiliary axes: Opposite + Foreground.
        /// </summary>
        AuxDefault = 258
    }
}