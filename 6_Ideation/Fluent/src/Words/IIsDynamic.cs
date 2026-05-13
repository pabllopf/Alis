// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IIsDynamic.cs
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
    ///     Fluent builder interface that toggles whether a physics body
    ///     responds to forces, collisions, and simulation.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The dynamic state — use <see langword="true"/> for dynamic, <see langword="false"/> for kinematic.</typeparam>
    /// <remarks>
    ///     A dynamic body participates fully in physics simulation (gravity, forces, collisions).
    ///     A kinematic body can be moved programmatically but is not affected by forces.
    ///     This is a convenience method equivalent to setting <see cref="IBodyType"/> to
    ///     dynamic or kinematic.
    /// </remarks>
    public interface IIsDynamic<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets whether the physics body is dynamic (affected by simulation).
        /// </summary>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        /// <remarks>
        ///     Calling this method with <see langword="true"/> is equivalent to setting
        ///     <see cref="IBodyType{out TBuilder, in TArgument}"/> to <c>Dynamic</c>.
        /// </remarks>
        TBuilder IsDynamic();
    }
}