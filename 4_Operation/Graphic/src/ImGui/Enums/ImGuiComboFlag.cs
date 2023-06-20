// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiComboFlags.cs
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
    ///     The im gui combo flags enum
    /// </summary>
    [Flags]
    public enum ImGuiComboFlag
    {
        /// <summary>
        ///     The none im gui combo flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The popup align left im gui combo flags
        /// </summary>
        PopupAlignLeft = 1,

        /// <summary>
        ///     The height small im gui combo flags
        /// </summary>
        HeightSmall = 2,

        /// <summary>
        ///     The height regular im gui combo flags
        /// </summary>
        HeightRegular = 4,

        /// <summary>
        ///     The height large im gui combo flags
        /// </summary>
        HeightLarge = 8,

        /// <summary>
        ///     The height largest im gui combo flags
        /// </summary>
        HeightLargest = 16,

        /// <summary>
        ///     The no arrow button im gui combo flags
        /// </summary>
        NoArrowButton = 32,

        /// <summary>
        ///     The no preview im gui combo flags
        /// </summary>
        NoPreview = 64,

        /// <summary>
        ///     The height mask im gui combo flags
        /// </summary>
        HeightMask = 30
    }
}