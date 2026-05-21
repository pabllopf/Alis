// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAddComponent.cs
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

using System;

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that attaches a typed component to a game entity
    ///     during the entity construction pipeline.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TType">The base type or interface that the component must implement.</typeparam>
    /// <remarks>
    ///     This interface supports two overloads: one that accepts a pre-constructed component
    ///     instance, and another that accepts a factory function for deferred construction.
    ///     The factory overload receives the entity being built as its argument.
    /// </remarks>
    public interface IAddComponent<out TBuilder, in TType>
    {
        /// <summary>
        ///     Adds a component to the builder using a factory function that receives the entity.
        /// </summary>
        /// <typeparam name="T">The specific component type, which must derive from <typeparamref name="TType"/>.</typeparam>
        /// <param name="value">A factory function that receives the entity and returns a component instance of type <typeparamref name="T"/>.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        TBuilder AddComponent<T>(Func<T, TType> value) where T : TType;

        /// <summary>
        ///     Adds a pre-constructed component instance to the builder.
        /// </summary>
        /// <typeparam name="T">The specific component type, which must derive from <typeparamref name="TType"/>.</typeparam>
        /// <param name="value">The component instance to attach. Must not be null for reference types.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AddComponent<T>(T value) where T : TType;
    }
}