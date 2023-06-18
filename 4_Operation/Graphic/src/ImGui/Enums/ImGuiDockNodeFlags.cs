// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDockNodeFlags.cs
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

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui dock node flags enum
    /// </summary>
    [Flags]
    public enum ImGuiDockNodeFlags
    {
        /// <summary>
        ///     The none im gui dock node flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The keep alive only im gui dock node flags
        /// </summary>
        KeepAliveOnly = 1,

        /// <summary>
        ///     The no docking in central node im gui dock node flags
        /// </summary>
        NoDockingInCentralNode = 4,

        /// <summary>
        ///     The passthru central node im gui dock node flags
        /// </summary>
        PassthruCentralNode = 8,

        /// <summary>
        ///     The no split im gui dock node flags
        /// </summary>
        NoSplit = 16,

        /// <summary>
        ///     The no resize im gui dock node flags
        /// </summary>
        NoResize = 32,

        /// <summary>
        ///     The auto hide tab bar im gui dock node flags
        /// </summary>
        AutoHideTabBar = 64
    }
}