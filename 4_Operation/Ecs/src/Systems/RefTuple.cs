// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RefTuple.cs
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
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    // for Item1 fields

    /// <summary>
    ///     A tuple of multiple references.
    /// </summary>
    public ref struct RefTuple<T>
    {
        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T> @ref)
        {
            @ref = Item1;
        }
    }

    /// <summary>
    ///     A tuple of a chunk of entities and their components.
    /// </summary>
    public ref struct ChunkTuple<T>
    {
        /// <summary>
        ///     An enumerator that can be used to enumerate individual <see cref="GameObject" /> instances.
        /// </summary>
        public GameObjectEnumerator.EntityEnumerable Entities;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T> Span;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Span<T> comp1)
        {
            comp1 = Span;
        }
    }
}