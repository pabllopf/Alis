// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RefTuples.cs
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
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The ref tuple
    /// </summary>
    public ref struct RefTuple<T>
    {
        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Deconstructs the ref
        /// </summary>
        /// <param name="ref">The ref</param>
        public void Deconstruct(out Ref<T> @ref)
        {
            @ref = Item1;
        }
    }


    /// <summary>
    ///     The entity ref tuple
    /// </summary>
    public ref struct EntityRefTuple<T>
    {
        /// <summary>
        ///     The entity
        /// </summary>
        public Entity Entity;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Deconstructs the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="ref">The ref</param>
        public void Deconstruct(out Entity entity, out Ref<T> @ref)
        {
            entity = Entity;
            @ref = Item1;
        }
    }


    /// <summary>
    ///     The chunk tuple
    /// </summary>
    public ref struct ChunkTuple<T>
    {
        /// <summary>
        ///     The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T> Span;

        /// <summary>
        ///     Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        public void Deconstruct(out Span<T> comp1)
        {
            comp1 = Span;
        }
    }
}