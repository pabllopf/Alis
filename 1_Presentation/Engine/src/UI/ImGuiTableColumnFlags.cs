// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ImGuiTableColumnFlags.cs
// 
//  Author: Pablo Perdomo Falcón
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
    ///     The im gui table column flags enum
    /// </summary>
    [Flags]
    public enum ImGuiTableColumnFlags
    {
        /// <summary>
        ///     The none im gui table column flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The disabled im gui table column flags
        /// </summary>
        Disabled = 1,

        /// <summary>
        ///     The default hide im gui table column flags
        /// </summary>
        DefaultHide = 2,

        /// <summary>
        ///     The default sort im gui table column flags
        /// </summary>
        DefaultSort = 4,

        /// <summary>
        ///     The width stretch im gui table column flags
        /// </summary>
        WidthStretch = 8,

        /// <summary>
        ///     The width fixed im gui table column flags
        /// </summary>
        WidthFixed = 16,

        /// <summary>
        ///     The no resize im gui table column flags
        /// </summary>
        NoResize = 32,

        /// <summary>
        ///     The no reorder im gui table column flags
        /// </summary>
        NoReorder = 64,

        /// <summary>
        ///     The no hide im gui table column flags
        /// </summary>
        NoHide = 128,

        /// <summary>
        ///     The no clip im gui table column flags
        /// </summary>
        NoClip = 256,

        /// <summary>
        ///     The no sort im gui table column flags
        /// </summary>
        NoSort = 512,

        /// <summary>
        ///     The no sort ascending im gui table column flags
        /// </summary>
        NoSortAscending = 1024,

        /// <summary>
        ///     The no sort descending im gui table column flags
        /// </summary>
        NoSortDescending = 2048,

        /// <summary>
        ///     The no header label im gui table column flags
        /// </summary>
        NoHeaderLabel = 4096,

        /// <summary>
        ///     The no header width im gui table column flags
        /// </summary>
        NoHeaderWidth = 8192,

        /// <summary>
        ///     The prefer sort ascending im gui table column flags
        /// </summary>
        PreferSortAscending = 16384,

        /// <summary>
        ///     The prefer sort descending im gui table column flags
        /// </summary>
        PreferSortDescending = 32768,

        /// <summary>
        ///     The indent enable im gui table column flags
        /// </summary>
        IndentEnable = 65536,

        /// <summary>
        ///     The indent disable im gui table column flags
        /// </summary>
        IndentDisable = 131072,

        /// <summary>
        ///     The is enabled im gui table column flags
        /// </summary>
        IsEnabled = 16777216,

        /// <summary>
        ///     The is visible im gui table column flags
        /// </summary>
        IsVisible = 33554432,

        /// <summary>
        ///     The is sorted im gui table column flags
        /// </summary>
        IsSorted = 67108864,

        /// <summary>
        ///     The is hovered im gui table column flags
        /// </summary>
        IsHovered = 134217728,

        /// <summary>
        ///     The width mask im gui table column flags
        /// </summary>
        WidthMask = 24,

        /// <summary>
        ///     The indent mask im gui table column flags
        /// </summary>
        IndentMask = 196608,

        /// <summary>
        ///     The status mask im gui table column flags
        /// </summary>
        StatusMask = 251658240,

        /// <summary>
        ///     The no direct resize im gui table column flags
        /// </summary>
        NoDirectResize = 1073741824
    }
}