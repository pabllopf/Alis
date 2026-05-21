// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IFixedRotation.cs
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
    ///     Fluent builder interface that enables or configures fixed rotation
    ///     for a physics body, preventing angular velocity from affecting the entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The fixed rotation configuration — typically a boolean to enable/disable, or a rotation value.</typeparam>
    /// <remarks>
    ///     When enabled, the physics engine will not apply torque or angular velocity
    ///     to the body. Useful for objects that should remain upright (e.g., characters, vehicles).
    ///     Related interfaces: <see cref="IRotation"/>.
    /// </remarks>
    public interface IFixedRotation<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Enables fixed rotation on the builder.
        /// </summary>
        /// <param name="value">If <see langword="true"/>, rotation is locked; if <see langword="false"/>, rotation is free.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder FixedRotation(TArgument value);
    }
}