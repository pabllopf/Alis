// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiSelectableFlags.cs
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
    ///     The im gui selectable flags enum
    /// </summary>
    [Flags]
    public enum ImGuiSelectableFlags
    {
        /// <summary>
        ///     The none im gui selectable flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The dont close popups im gui selectable flags
        /// </summary>
        DontClosePopups = 1,

        /// <summary>
        ///     The span all columns im gui selectable flags
        /// </summary>
        SpanAllColumns = 2,

        /// <summary>
        ///     The allow double click im gui selectable flags
        /// </summary>
        AllowDoubleClick = 4,

        /// <summary>
        ///     The disabled im gui selectable flags
        /// </summary>
        Disabled = 8,

        /// <summary>
        ///     The allow item overlap im gui selectable flags
        /// </summary>
        AllowItemOverlap = 16
    }
}