// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IFriction.cs
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
    ///     Fluent builder interface that sets the friction coefficient
    ///     of a physics collider or material.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The friction value type, typically <see cref="float"/> (0 = frictionless, 1 = high friction).</typeparam>
    /// <remarks>
    ///     Friction affects how sliding bodies decelerate when in contact with surfaces.
    ///     Combined with <see cref="IRestitution"/>, it defines the physical material
    ///     properties of colliders.
    /// </remarks>
    public interface IFriction<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the friction coefficient on the builder.
        /// </summary>
        /// <param name="value">The friction coefficient. 0 = no friction (ice), 1 = high friction (rough surface).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Friction(TArgument value);
    }
}