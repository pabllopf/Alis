// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotDragToolFlags.cs
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
    ///     Flags controlling the behaviour of draggable annotation points in ImPlot.
    /// </summary>
    [Flags]
    public enum ImPlotDragToolFlags
    {
        /// <summary>
        ///     Default drag behaviour with cursor changes and fit support.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Disable cursor changes when hovering the drag tool.
        /// </summary>
        NoCursors = 1,

        /// <summary>
        ///     Exclude the drag tool from automatic fit-to-data calculations.
        /// </summary>
        NoFit = 2,

        /// <summary>
        ///     Disable mouse/keyboard input for the drag tool entirely.
        /// </summary>
        NoInputs = 4,

        /// <summary>
        ///     Delay the drag update until the mouse button is released.
        /// </summary>
        Delayed = 8
    }
}