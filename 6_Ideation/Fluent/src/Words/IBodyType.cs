// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IBodyType.cs
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
    ///     Fluent builder interface that determines the physics body type
    ///     for a collider or rigid body component.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The body type enumeration or configuration, typically <see cref="BodyType"/>.</typeparam>
    /// <remarks>
    ///     The body type affects how the physics engine treats the entity:
    ///     <list type="bullet">
    ///         <item><description><c>Static</c> — immovable, zero mass, not affected by forces</description></item>
    ///         <item><description><c>Dynamic</c> — fully simulated, affected by forces and collisions</description></item>
    ///         <item><description><c>Kinematic</c> — moved via code, not affected by forces but participates in collisions</description></item>
    ///     </list>
    /// </remarks>
    public interface IBodyType<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the physics body type on the builder.
        /// </summary>
        /// <param name="value">The body type to apply — static, dynamic, or kinematic.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder BodyType(TArgument value);
    }
}