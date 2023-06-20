// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportFlag.cs
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
    ///     The im gui viewport flags enum
    /// </summary>
    [Flags]
    public enum ImGuiViewportFlag
    {
        /// <summary>
        ///     The none im gui viewport flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The is platform window im gui viewport flags
        /// </summary>
        IsPlatformWindow = 1,

        /// <summary>
        ///     The is platform monitor im gui viewport flags
        /// </summary>
        IsPlatformMonitor = 2,

        /// <summary>
        ///     The owned by app im gui viewport flags
        /// </summary>
        OwnedByApp = 4,

        /// <summary>
        ///     The no decoration im gui viewport flags
        /// </summary>
        NoDecoration = 8,

        /// <summary>
        ///     The no task bar icon im gui viewport flags
        /// </summary>
        NoTaskBarIcon = 16,

        /// <summary>
        ///     The no focus on appearing im gui viewport flags
        /// </summary>
        NoFocusOnAppearing = 32,

        /// <summary>
        ///     The no focus on click im gui viewport flags
        /// </summary>
        NoFocusOnClick = 64,

        /// <summary>
        ///     The no inputs im gui viewport flags
        /// </summary>
        NoInputs = 128,

        /// <summary>
        ///     The no renderer clear im gui viewport flags
        /// </summary>
        NoRendererClear = 256,

        /// <summary>
        ///     The no auto merge im gui viewport flags
        /// </summary>
        NoAutoMerge = 512,

        /// <summary>
        ///     The top most im gui viewport flags
        /// </summary>
        TopMost = 1024,

        /// <summary>
        ///     The can host other windows im gui viewport flags
        /// </summary>
        CanHostOtherWindows = 2048,

        /// <summary>
        ///     The is minimized im gui viewport flags
        /// </summary>
        IsMinimized = 4096,

        /// <summary>
        ///     The is focused im gui viewport flags
        /// </summary>
        IsFocused = 8192
    }
}