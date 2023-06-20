// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiSliderFlag.cs
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
    ///     The im gui slider flags enum
    /// </summary>
    [Flags]
    public enum ImGuiSliderFlag
    {
        /// <summary>
        ///     The none im gui slider flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The always clamp im gui slider flags
        /// </summary>
        AlwaysClamp = 16,

        /// <summary>
        ///     The logarithmic im gui slider flags
        /// </summary>
        Logarithmic = 32,

        /// <summary>
        ///     The no round to format im gui slider flags
        /// </summary>
        NoRoundToFormat = 64,

        /// <summary>
        ///     The no input im gui slider flags
        /// </summary>
        NoInput = 128,

        /// <summary>
        ///     The invalid mask im gui slider flags
        /// </summary>
        InvalidMask = 1879048207
    }
}