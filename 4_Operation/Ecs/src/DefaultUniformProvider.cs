// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DefaultUniformProvider.cs
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
using System.Collections.Generic;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The default uniform provider, using a dictionary.
    /// </summary>
    public class DefaultUniformProvider : IUniformProvider
    {
        /// <summary>
        ///     The uniforms
        /// </summary>
        private readonly Dictionary<Type, object> _uniforms = [];

        /// <summary>
        ///     Gets a uniform from this default uniform provider.
        /// </summary>
        /// <typeparam name="T">The type of uniform to get.</typeparam>
        /// <returns>The uniform instance.</returns>
        /// <exception cref="InvalidOperationException">The uniform of the specified type is not found.</exception>
        public T GetUniform<T>() => _uniforms.TryGetValue(typeof(T), out object? value) ? (T) value : throw new InvalidOperationException($"Uniform of {typeof(T).Name} not found");

        /// <summary>
        ///     Adds a uniform to this uniform provider.
        /// </summary>
        /// <typeparam name="T">The type of uniform to add.</typeparam>
        /// <param name="obj">The object to add as a uniform.</param>
        /// <returns>This instance, for method chaining.</returns>
        public DefaultUniformProvider Add<T>(T obj)
            where T : notnull
        {
            object boxed = obj;
#if (NETSTANDARD || NETCOREAPP || NETFRAMEWORK) && !NET6_0_OR_GREATER
            if (boxed is null)
                throw new ArgumentNullException(nameof(obj));
#else
            ArgumentNullException.ThrowIfNull(boxed);
#endif
            _uniforms[typeof(T)] = boxed;
            return this;
        }

        /// <summary>
        ///     Adds a uniform to this uniform provider.
        /// </summary>
        /// <param name="type">The type of uniform to add as.</param>
        /// <param name="object">The object to add as a uniform.</param>
        /// <returns>This instance, for method chaining.</returns>
        /// <exception cref="ArgumentException"><paramref name="object" /> is not assignable to <paramref name="type" />.</exception>
        public DefaultUniformProvider Add(Type type, object @object)
        {
#if (NETSTANDARD || NETCOREAPP || NETFRAMEWORK) && !NET6_0_OR_GREATER
        if (type is null)
            throw new ArgumentNullException(nameof(type));
#else
            ArgumentNullException.ThrowIfNull(type);
#endif
            if (!type.IsAssignableFrom(@object.GetType()))
                throw new ArgumentException("Object must be assignable to the type!", nameof(@object));
            _uniforms[type] = @object;
            return this;
        }
    }
}