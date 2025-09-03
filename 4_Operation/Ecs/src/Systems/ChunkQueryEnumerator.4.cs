// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkQueryEnumerator.4.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The chunk query enumerator
    /// </summary>
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4>
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     Initializes a new instance of the  class
        /// </summary>
        /// <param name="query">The query</param>
        private ChunkQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current tuple of component chunks.
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new()
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                    Span2 = cur.GetComponentSpan<T2>(),
                    Span3 = cur.GetComponentSpan<T3>(),
                    Span4 = cur.GetComponentSpan<T4>()
                };
            }
        }

        /// <summary>
        ///     Indicates to the scene that this enumeration is finished; the scene might allow structual changes after this.
        /// </summary>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3, T4> GetEnumerator() => new ChunkQueryEnumerator<T1, T2, T3, T4>(query);
        }
    }
}