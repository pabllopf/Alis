// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPosition2D.cs
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
    ///     Fluent builder interface that sets the 2D position (X, Y coordinates)
    ///     of a game entity in world or local space.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The coordinate component type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Sets the entity's position in the 2D plane. For world-space positioning,
    ///     coordinates are relative to the scene origin. For pixel-based games,
    ///     values are typically in pixel units.
    /// </remarks>
    public interface IPosition2D<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the 2D world-space position of the entity.
        /// </summary>
        /// <param name="x">The X-coordinate (horizontal position).</param>
        /// <param name="y">The Y-coordinate (vertical position).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Position(TArgument x, TArgument y);
    }
}