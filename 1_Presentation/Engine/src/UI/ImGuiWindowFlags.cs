// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiWindowFlags.cs
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

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im gui window flags enum
    /// </summary>
    [Flags]
    public enum ImGuiWindowFlags
    {
        /// <summary>
        ///     The none im gui window flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no title bar im gui window flags
        /// </summary>
        NoTitleBar = 1,

        /// <summary>
        ///     The no resize im gui window flags
        /// </summary>
        NoResize = 2,

        /// <summary>
        ///     The no move im gui window flags
        /// </summary>
        NoMove = 4,

        /// <summary>
        ///     The no scrollbar im gui window flags
        /// </summary>
        NoScrollbar = 8,

        /// <summary>
        ///     The no scroll with mouse im gui window flags
        /// </summary>
        NoScrollWithMouse = 16,

        /// <summary>
        ///     The no collapse im gui window flags
        /// </summary>
        NoCollapse = 32,

        /// <summary>
        ///     The always auto resize im gui window flags
        /// </summary>
        AlwaysAutoResize = 64,

        /// <summary>
        ///     The no background im gui window flags
        /// </summary>
        NoBackground = 128,

        /// <summary>
        ///     The no saved settings im gui window flags
        /// </summary>
        NoSavedSettings = 256,

        /// <summary>
        ///     The no mouse inputs im gui window flags
        /// </summary>
        NoMouseInputs = 512,

        /// <summary>
        ///     The menu bar im gui window flags
        /// </summary>
        MenuBar = 1024,

        /// <summary>
        ///     The horizontal scrollbar im gui window flags
        /// </summary>
        HorizontalScrollbar = 2048,

        /// <summary>
        ///     The no focus on appearing im gui window flags
        /// </summary>
        NoFocusOnAppearing = 4096,

        /// <summary>
        ///     The no bring to front on focus im gui window flags
        /// </summary>
        NoBringToFrontOnFocus = 8192,

        /// <summary>
        ///     The always vertical scrollbar im gui window flags
        /// </summary>
        AlwaysVerticalScrollbar = 16384,

        /// <summary>
        ///     The always horizontal scrollbar im gui window flags
        /// </summary>
        AlwaysHorizontalScrollbar = 32768,

        /// <summary>
        ///     The always use window padding im gui window flags
        /// </summary>
        AlwaysUseWindowPadding = 65536,

        /// <summary>
        ///     The no nav inputs im gui window flags
        /// </summary>
        NoNavInputs = 262144,

        /// <summary>
        ///     The no nav focus im gui window flags
        /// </summary>
        NoNavFocus = 524288,

        /// <summary>
        ///     The unsaved document im gui window flags
        /// </summary>
        UnsavedDocument = 1048576,

        /// <summary>
        ///     The no docking im gui window flags
        /// </summary>
        NoDocking = 2097152,

        /// <summary>
        ///     The no nav im gui window flags
        /// </summary>
        NoNav = 786432,

        /// <summary>
        ///     The no decoration im gui window flags
        /// </summary>
        NoDecoration = 43,

        /// <summary>
        ///     The no inputs im gui window flags
        /// </summary>
        NoInputs = 786944,

        /// <summary>
        ///     The nav flattened im gui window flags
        /// </summary>
        NavFlattened = 8388608,

        /// <summary>
        ///     The child window im gui window flags
        /// </summary>
        ChildWindow = 16777216,

        /// <summary>
        ///     The tooltip im gui window flags
        /// </summary>
        Tooltip = 33554432,

        /// <summary>
        ///     The popup im gui window flags
        /// </summary>
        Popup = 67108864,

        /// <summary>
        ///     The modal im gui window flags
        /// </summary>
        Modal = 134217728,

        /// <summary>
        ///     The child menu im gui window flags
        /// </summary>
        ChildMenu = 268435456,

        /// <summary>
        ///     The dock node host im gui window flags
        /// </summary>
        DockNodeHost = 536870912
    }
}