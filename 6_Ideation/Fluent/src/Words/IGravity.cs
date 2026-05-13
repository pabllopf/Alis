// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGravity.cs
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

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the gravity vector applied
    ///     to physics bodies in the game world or a specific scene.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The gravity magnitude type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Gravity is a global physics setting that affects all dynamic bodies.
    ///     Common values: Earth-like gravity ≈ 9.81, zero-gravity = 0, platformer ≈ 15–30.
    ///     For per-entity gravity, use <see cref="IGravityScale"/> instead.
    /// </remarks>
    public interface IGravity<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the global gravity magnitude.
        /// </summary>
        /// <param name="x">The horizontal gravity component (typically 0 for standard platformers).</param>
        /// <param name="y">The vertical gravity component (negative values pull downward).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Gravity(TArgument x, TArgument y);
    }
}