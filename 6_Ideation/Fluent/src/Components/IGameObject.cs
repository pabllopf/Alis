// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGameObject.cs
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

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Represents a game entity that owns components and provides access to them.
    ///     Components are retrieved by type and queried for presence.
    /// </summary>
    public interface IGameObject
    {
        /// <summary>
        ///     Gets a reference to the component of type <c>T</c> owned by this entity.
        /// </summary>
        /// <typeparam name="T">The component type to retrieve. Must be implemented by a component interface.</typeparam>
        /// <returns>A reference to the component instance. Throws if the component is not present.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the entity does not have a component of type <c>T</c>.</exception>
        ref T Get<T>();

        /// <summary>
        ///     Determines whether this entity has a component of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">The component type to check.</typeparam>
        /// <returns><c>true</c> if the entity has a component of type <c>T</c>; otherwise, <c>false</c>.</returns>
        bool Has<T>();

        /// <summary>
        ///     Determines whether this entity has a component of the specified <paramref name="type" />.
        /// </summary>
        /// <param name="type">The component type to check.</param>
        /// <returns><c>true</c> if the entity has a component of the specified type; otherwise, <c>false</c>.</returns>
        bool Has(Type type);

        /// <summary>
        ///     Attempts to determine whether this entity has a component of type <c>T</c> without throwing on miss.
        /// </summary>
        /// <typeparam name="T">The component type to check.</typeparam>
        /// <returns><c>true</c> if the component exists; otherwise, <c>false</c>.</returns>
        bool TryHas<T>();
    }
}