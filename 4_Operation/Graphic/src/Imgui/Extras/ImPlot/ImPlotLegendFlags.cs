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

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    ///     The im plot legend flags enum
    /// </summary>
    [Flags]
    public enum ImPlotLegendFlags
    {
        /// <summary>
        ///     The none im plot legend flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no buttons im plot legend flags
        /// </summary>
        NoButtons = 1,

        /// <summary>
        ///     The no highlight item im plot legend flags
        /// </summary>
        NoHighlightItem = 2,

        /// <summary>
        ///     The no highlight axis im plot legend flags
        /// </summary>
        NoHighlightAxis = 4,

        /// <summary>
        ///     The no menus im plot legend flags
        /// </summary>
        NoMenus = 8,

        /// <summary>
        ///     The outside im plot legend flags
        /// </summary>
        Outside = 16,

        /// <summary>
        ///     The horizontal im plot legend flags
        /// </summary>
        Horizontal = 32,

        /// <summary>
        ///     The sort im plot legend flags
        /// </summary>
        Sort = 64
    }
}