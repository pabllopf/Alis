// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPopupFlags.cs
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

namespace Alis.Core.Graphic.UI
{
    /// <summary>
    ///     The im gui popup flags enum
    /// </summary>
    [Flags]
    public enum ImGuiPopupFlags
    {
        /// <summary>
        ///     The none im gui popup flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The mouse button left im gui popup flags
        /// </summary>
        MouseButtonLeft = 0,

        /// <summary>
        ///     The mouse button right im gui popup flags
        /// </summary>
        MouseButtonRight = 1,

        /// <summary>
        ///     The mouse button middle im gui popup flags
        /// </summary>
        MouseButtonMiddle = 2,

        /// <summary>
        ///     The mouse button mask im gui popup flags
        /// </summary>
        MouseButtonMask = 31,

        /// <summary>
        ///     The mouse button default im gui popup flags
        /// </summary>
        MouseButtonDefault = 1,

        /// <summary>
        ///     The no open over existing popup im gui popup flags
        /// </summary>
        NoOpenOverExistingPopup = 32,

        /// <summary>
        ///     The no open over items im gui popup flags
        /// </summary>
        NoOpenOverItems = 64,

        /// <summary>
        ///     The any popup id im gui popup flags
        /// </summary>
        AnyPopupId = 128,

        /// <summary>
        ///     The any popup level im gui popup flags
        /// </summary>
        AnyPopupLevel = 256,

        /// <summary>
        ///     The any popup im gui popup flags
        /// </summary>
        AnyPopup = 384
    }
}