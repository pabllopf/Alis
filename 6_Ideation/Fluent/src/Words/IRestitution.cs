// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRestitution.cs
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
    ///     Fluent builder interface that sets the restitution (bounciness) coefficient
    ///     of a physics collider.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The restitution value type, typically <see cref="float"/> (0 = no bounce, 1 = perfect bounce).</typeparam>
    /// <remarks>
    ///     Restitution determines how much kinetic energy is preserved during a collision.
    ///     A value of 0 means completely inelastic (no bounce), 1 means perfectly elastic
    ///     (full energy conservation). Values greater than 1 can create "explosive" bouncing
    ///     effects but may cause instability in the physics simulation.
    /// </remarks>
    public interface IRestitution<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the restitution coefficient on the builder.
        /// </summary>
        /// <param name="value">The restitution coefficient. Range: 0 (no bounce) to 1 (perfect bounce).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Restitution(TArgument value);
    }
}