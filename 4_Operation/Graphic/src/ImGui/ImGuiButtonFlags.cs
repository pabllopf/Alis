// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiButtonFlags.cs
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
    ///     The im gui button flags enum
    /// </summary>
    [Flags]
    public enum ImGuiButtonFlags
    {
        /// <summary>
        ///     The none im gui button flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The mouse button left im gui button flags
        /// </summary>
        MouseButtonLeft = 1,

        /// <summary>
        ///     The mouse button right im gui button flags
        /// </summary>
        MouseButtonRight = 2,

        /// <summary>
        ///     The mouse button middle im gui button flags
        /// </summary>
        MouseButtonMiddle = 4,

        /// <summary>
        ///     The mouse button mask im gui button flags
        /// </summary>
        MouseButtonMask = 7,

        /// <summary>
        ///     The mouse button default im gui button flags
        /// </summary>
        MouseButtonDefault = 1
    }
}