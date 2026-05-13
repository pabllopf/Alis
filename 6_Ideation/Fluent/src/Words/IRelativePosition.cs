// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRelativePosition.cs
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
    ///     Fluent builder interface that offsets the entity's position
    ///     by a relative delta from its current location.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The offset component type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Unlike <see cref="IPosition2D"/>, which sets an absolute position,
    ///     this adds a delta to the current position. Useful for knockback,
    ///     projectile spawning offsets, or gradual movement.
    /// </remarks>
    public interface IRelativePosition<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a relative position offset to the entity.
        /// </summary>
        /// <param name="x">The horizontal offset to add to the current X position.</param>
        /// <param name="y">The vertical offset to add to the current Y position.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder RelativePosition(TArgument x, TArgument y);
    }
}