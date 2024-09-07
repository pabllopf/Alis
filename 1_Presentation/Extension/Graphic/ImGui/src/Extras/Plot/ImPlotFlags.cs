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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot flags enum
    /// </summary>
    [Flags]
    public enum ImPlotFlags
    {
        /// <summary>
        ///     The none im plot flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no title im plot flags
        /// </summary>
        NoTitle = 1,

        /// <summary>
        ///     The no legend im plot flags
        /// </summary>
        NoLegend = 2,

        /// <summary>
        ///     The no mouse text im plot flags
        /// </summary>
        NoMouseText = 4,

        /// <summary>
        ///     The no inputs im plot flags
        /// </summary>
        NoInputs = 8,

        /// <summary>
        ///     The no menus im plot flags
        /// </summary>
        NoMenus = 16,

        /// <summary>
        ///     The no box select im plot flags
        /// </summary>
        NoBoxSelect = 32,

        /// <summary>
        ///     The no child im plot flags
        /// </summary>
        NoChild = 64,

        /// <summary>
        ///     The no frame im plot flags
        /// </summary>
        NoFrame = 128,

        /// <summary>
        ///     The equal im plot flags
        /// </summary>
        Equal = 256,

        /// <summary>
        ///     The crosshairs im plot flags
        /// </summary>
        Crosshairs = 512,

        /// <summary>
        ///     The canvas only im plot flags
        /// </summary>
        CanvasOnly = 55
    }
}