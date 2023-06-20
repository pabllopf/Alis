// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTabItemFlag.cs
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
    ///     The im gui tab item flags enum
    /// </summary>
    [Flags]
    public enum ImGuiTabItemFlag
    {
        /// <summary>
        ///     The none im gui tab item flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The unsaved document im gui tab item flags
        /// </summary>
        UnsavedDocument = 1,

        /// <summary>
        ///     The set selected im gui tab item flags
        /// </summary>
        SetSelected = 2,

        /// <summary>
        ///     The no close with middle mouse button im gui tab item flags
        /// </summary>
        NoCloseWithMiddleMouseButton = 4,

        /// <summary>
        ///     The no push id im gui tab item flags
        /// </summary>
        NoPushId = 8,

        /// <summary>
        ///     The no tooltip im gui tab item flags
        /// </summary>
        NoTooltip = 16,

        /// <summary>
        ///     The no reorder im gui tab item flags
        /// </summary>
        NoReorder = 32,

        /// <summary>
        ///     The leading im gui tab item flags
        /// </summary>
        Leading = 64,

        /// <summary>
        ///     The trailing im gui tab item flags
        /// </summary>
        Trailing = 128
    }
}