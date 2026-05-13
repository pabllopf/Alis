// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Constant.cs
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

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Provides mathematical constants used throughout the physics engine.
    /// </summary>
    /// <remarks>
    ///     These constants are pre-computed as float values for performance in hot paths.
    ///     The names follow common mathematical conventions: Pi (π) and Tau (τ = 2π).
    /// </remarks>
    internal static class Constant
    {
        /// <summary>
        ///     The ratio of a circle's circumference to its diameter (π ≈ 3.14159).
        /// </summary>
        public const float Pi = (float) Math.PI;

        /// <summary>
        ///     The ratio of a circle's circumference to its radius (τ = 2π ≈ 6.28318).
        ///     Also known as "tau", this constant is useful for angle calculations in full circles.
        /// </summary>
        public const float Tau = (float) (Math.PI * 2.0);
    }
}