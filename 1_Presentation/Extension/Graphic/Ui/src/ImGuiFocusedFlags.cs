// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiFocusedFlags.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui focused flags enum
    /// </summary>
    [Flags]
    public enum ImGuiFocusedFlags
    {
        /// <summary>
        ///     The none im gui focused flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The child windows im gui focused flags
        /// </summary>
        ChildWindows = 1,

        /// <summary>
        ///     The root window im gui focused flags
        /// </summary>
        RootWindow = 2,

        /// <summary>
        ///     The any window im gui focused flags
        /// </summary>
        AnyWindow = 4,

        /// <summary>
        ///     The no popup hierarchy im gui focused flags
        /// </summary>
        NoPopupHierarchy = 8,

        /// <summary>
        ///     The dock hierarchy im gui focused flags
        /// </summary>
        DockHierarchy = 16,

        /// <summary>
        ///     The root and child windows im gui focused flags
        /// </summary>
        RootAndChildWindows = 3
    }
}