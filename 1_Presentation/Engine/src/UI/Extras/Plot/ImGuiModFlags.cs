// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiModFlags.cs
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

namespace Alis.App.Engine.UI.Extras.Plot
{
    /// <summary>
    ///     The im gui mod flags enum
    /// </summary>
    [Flags]
    public enum ImGuiModFlags
    {
        /// <summary>
        ///     The none im gui mod flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The ctrl im gui mod flags
        /// </summary>
        Ctrl = 1,

        /// <summary>
        ///     The shift im gui mod flags
        /// </summary>
        Shift = 2,

        /// <summary>
        ///     The alt im gui mod flags
        /// </summary>
        Alt = 4,

        /// <summary>
        ///     The super im gui mod flags
        /// </summary>
        Super = 8
    }
}