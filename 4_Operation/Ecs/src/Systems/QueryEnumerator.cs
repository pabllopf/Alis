// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerator.cs
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
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query enumerator
    /// </summary>
    public ref struct QueryEnumerator<T>
    {
        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     The component index
        /// </summary>
        private int _componentIndex;

        /// <summary>
        ///     The world
        /// </summary>
        private readonly World _world;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T> _currentSpan1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryEnumerator" /> class
        /// </summary>
        /// <param name="query">The query</param>
        private QueryEnumerator(Query query)
        {
            _world = query.World;
            _world.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     Gets the value of the current
        /// </summary>
        public RefTuple<T> Current => new()
        {
            Item1 = new Ref<T>(_currentSpan1, _componentIndex)
        };

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _world.ExitDisallowState();
        }

        /// <summary>
        ///     Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _currentSpan1.Length)
            {
                return true;
            }

            _componentIndex = 0;
            _archetypeIndex++;

            if ((uint) _archetypeIndex < (uint) _archetypes.Length)
            {
                Archetype? cur = _archetypes[_archetypeIndex];
                _currentSpan1 = cur.GetComponentSpan<T>();
                return true;
            }

            return false;
        }

        /// <summary>
        ///     The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator
            /// </summary>
            /// <returns>A query enumerator of t</returns>
            public QueryEnumerator<T> GetEnumerator() => new QueryEnumerator<T>(query);
        }
    }
}