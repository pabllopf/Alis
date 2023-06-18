// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawFlags.cs
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
    ///     The im draw flags enum
    /// </summary>
    [Flags]
    public enum ImDrawFlags
    {
        /// <summary>
        ///     The none im draw flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The closed im draw flags
        /// </summary>
        Closed = 1,

        /// <summary>
        ///     The round corners top left im draw flags
        /// </summary>
        RoundCornersTopLeft = 16,

        /// <summary>
        ///     The round corners top right im draw flags
        /// </summary>
        RoundCornersTopRight = 32,

        /// <summary>
        ///     The round corners bottom left im draw flags
        /// </summary>
        RoundCornersBottomLeft = 64,

        /// <summary>
        ///     The round corners bottom right im draw flags
        /// </summary>
        RoundCornersBottomRight = 128,

        /// <summary>
        ///     The round corners none im draw flags
        /// </summary>
        RoundCornersNone = 256,

        /// <summary>
        ///     The round corners top im draw flags
        /// </summary>
        RoundCornersTop = 48,

        /// <summary>
        ///     The round corners bottom im draw flags
        /// </summary>
        RoundCornersBottom = 192,

        /// <summary>
        ///     The round corners left im draw flags
        /// </summary>
        RoundCornersLeft = 80,

        /// <summary>
        ///     The round corners right im draw flags
        /// </summary>
        RoundCornersRight = 160,

        /// <summary>
        ///     The round corners all im draw flags
        /// </summary>
        RoundCornersAll = 240,

        /// <summary>
        ///     The round corners default im draw flags
        /// </summary>
        RoundCornersDefault = 240,

        /// <summary>
        ///     The round corners mask im draw flags
        /// </summary>
        RoundCornersMask = 496
    }
}