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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     Flags representing keyboard modifier keys used in ImGui and ImPlot interactions.
    /// </summary>
    [Flags]
    public enum ImGuiModFlags
    {
        /// <summary>
        ///     No modifier key pressed.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The Control (Ctrl) modifier key.
        /// </summary>
        Ctrl = 1,

        /// <summary>
        ///     The Shift modifier key.
        /// </summary>
        Shift = 2,

        /// <summary>
        ///     The Alt modifier key.
        /// </summary>
        Alt = 4,

        /// <summary>
        ///     The Super (Windows / Command) modifier key.
        /// </summary>
        Super = 8
    }
}