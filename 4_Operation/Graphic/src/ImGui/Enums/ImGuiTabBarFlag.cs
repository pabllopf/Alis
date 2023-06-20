// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTabBarFlag.cs
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

namespace Alis.Core.Graphic.ImGui.Enums
{
    /// <summary>
    ///     The im gui tab bar flags enum
    /// </summary>
    [Flags]
    public enum ImGuiTabBarFlag
    {
        /// <summary>
        ///     The none im gui tab bar flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The reorderable im gui tab bar flags
        /// </summary>
        Reorderable = 1,

        /// <summary>
        ///     The auto select new tabs im gui tab bar flags
        /// </summary>
        AutoSelectNewTabs = 2,

        /// <summary>
        ///     The tab list popup button im gui tab bar flags
        /// </summary>
        TabListPopupButton = 4,

        /// <summary>
        ///     The no close with middle mouse button im gui tab bar flags
        /// </summary>
        NoCloseWithMiddleMouseButton = 8,

        /// <summary>
        ///     The no tab list scrolling buttons im gui tab bar flags
        /// </summary>
        NoTabListScrollingButtons = 16,

        /// <summary>
        ///     The no tooltip im gui tab bar flags
        /// </summary>
        NoTooltip = 32,

        /// <summary>
        ///     The fitting policy resize down im gui tab bar flags
        /// </summary>
        FittingPolicyResizeDown = 64,

        /// <summary>
        ///     The fitting policy scroll im gui tab bar flags
        /// </summary>
        FittingPolicyScroll = 128,

        /// <summary>
        ///     The fitting policy mask im gui tab bar flags
        /// </summary>
        FittingPolicyMask = 192,

        /// <summary>
        ///     The fitting policy default im gui tab bar flags
        /// </summary>
        FittingPolicyDefault = 64
    }
}