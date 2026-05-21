// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILinearVelocity.cs
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
    ///     Fluent builder interface that sets the linear velocity vector
    ///     of a physics rigid body.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The coordinate component type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Linear velocity determines how fast and in which direction a body moves.
    ///     The X component is horizontal velocity; Y is vertical.
    ///     Units are typically in <c>meters/second</c> or <c>pixels/second</c> depending on the engine scale.
    ///     Related interfaces: <see cref="IAngularVelocity"/>.
    /// </remarks>
    public interface ILinearVelocity<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the 2D linear velocity vector on the builder.
        /// </summary>
        /// <param name="x">The horizontal velocity component (X-axis).</param>
        /// <param name="y">The vertical velocity component (Y-axis).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder LinearVelocity(TArgument x, TArgument y);
    }
}