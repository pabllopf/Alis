// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListFlags.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im draw list flags enum
    /// </summary>
    [Flags]
    public enum ImDrawListFlags
    {
        /// <summary>
        ///     The none im draw list flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The anti aliased lines im draw list flags
        /// </summary>
        AntiAliasedLines = 1,

        /// <summary>
        ///     The anti aliased lines use tex im draw list flags
        /// </summary>
        AntiAliasedLinesUseTex = 2,

        /// <summary>
        ///     The anti aliased fill im draw list flags
        /// </summary>
        AntiAliasedFill = 4,

        /// <summary>
        ///     The allow vtx offset im draw list flags
        /// </summary>
        AllowVtxOffset = 8
    }
}