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

namespace Alis.Extension.Graphic.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot subplot flags enum
    /// </summary>
    [Flags]
    public enum ImPlotSubplotFlags
    {
        /// <summary>
        ///     The none im plot subplot flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no title im plot subplot flags
        /// </summary>
        NoTitle = 1,

        /// <summary>
        ///     The no legend im plot subplot flags
        /// </summary>
        NoLegend = 2,

        /// <summary>
        ///     The no menus im plot subplot flags
        /// </summary>
        NoMenus = 4,

        /// <summary>
        ///     The no resize im plot subplot flags
        /// </summary>
        NoResize = 8,

        /// <summary>
        ///     The no align im plot subplot flags
        /// </summary>
        NoAlign = 16,

        /// <summary>
        ///     The share items im plot subplot flags
        /// </summary>
        ShareItems = 32,

        /// <summary>
        ///     The link rows im plot subplot flags
        /// </summary>
        LinkRows = 64,

        /// <summary>
        ///     The link cols im plot subplot flags
        /// </summary>
        LinkCols = 128,

        /// <summary>
        ///     The link all im plot subplot flags
        /// </summary>
        LinkAllX = 256,

        /// <summary>
        ///     The link all im plot subplot flags
        /// </summary>
        LinkAllY = 512,

        /// <summary>
        ///     The col major im plot subplot flags
        /// </summary>
        ColMajor = 1024
    }
}