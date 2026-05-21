// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDensity.cs
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
    ///     Fluent builder interface that sets the density property
    ///     of a physics collider or material.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The density value type, typically <see cref="float"/> (kg/m²).</typeparam>
    /// <remarks>
    ///     Density affects the mass calculation of a physics body. Higher density
    ///     results in greater mass for the same volume, influencing how the body
    ///     responds to forces and collisions. Used with <see cref="IBodyType"/>
    ///     and <see cref="IShape"/> to define physical properties.
    /// </remarks>
    public interface IDensity<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the density value on the builder.
        /// </summary>
        /// <param name="value">The density value in kg/m². Typical range: 0 (massless) to ~1000 (very dense).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Density(TArgument value);
    }
}