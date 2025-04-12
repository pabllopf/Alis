// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityQueryEnumerator.6.cs
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
using Alis.Core.Ecs.Arch;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    /// The entity query enumerator
    /// </summary>
    public ref struct EntityQueryEnumerator<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// The archetype index
        /// </summary>
        private int _archetypeIndex;
        /// <summary>
        /// The component index
        /// </summary>
        private int _componentIndex;
        /// <summary>
        /// The scene
        /// </summary>
        private readonly Scene scene;
        /// <summary>
        /// The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;
        /// <summary>
        /// The entity ids
        /// </summary>
        private Span<EntityIdOnly> _entityIds;
        /// <summary>
        /// The current span
        /// </summary>
        private Span<T1> _currentSpan1;
        /// <summary>
        /// The current span
        /// </summary>
        private Span<T2> _currentSpan2;
        /// <summary>
        /// The current span
        /// </summary>
        private Span<T3> _currentSpan3;
        /// <summary>
        /// The current span
        /// </summary>
        private Span<T4> _currentSpan4;
        /// <summary>
        /// The current span
        /// </summary>
        private Span<T5> _currentSpan5;
        /// <summary>
        /// The current span
        /// </summary>
        private Span<T6> _currentSpan6;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityQueryEnumerator"/> class
        /// </summary>
        /// <param name="query">The query</param>
        private EntityQueryEnumerator(Query query)
        {
            scene = query.Scene;
            scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current tuple of component references and the <see cref="GameObject" /> instance.
        /// </summary>
        public EntityRefTuple<T1, T2, T3, T4, T5, T6> Current => new()
        {
            GameObject = _entityIds[_componentIndex].ToEntity(scene),
            Item1 = new Ref<T1>(_currentSpan1, _componentIndex),
            Item2 = new Ref<T2>(_currentSpan2, _componentIndex),
            Item3 = new Ref<T3>(_currentSpan3, _componentIndex),
            Item4 = new Ref<T4>(_currentSpan4, _componentIndex),
            Item5 = new Ref<T5>(_currentSpan5, _componentIndex),
            Item6 = new Ref<T6>(_currentSpan6, _componentIndex)
        };

        /// <summary>
        ///     Indicates to the world that this enumeration is finished; the world might allow structual changes after this.
        /// </summary>
        public void Dispose()
        {
            scene.ExitDisallowState();
        }

        /// <summary>
        ///     Moves to the next entity and its components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _currentSpan1.Length)
            {
                return true;
            }

            do
            {
                _componentIndex = 0;
                _archetypeIndex++;

                if ((uint) _archetypeIndex < (uint) _archetypes.Length)
                {
                    var cur = _archetypes[_archetypeIndex];
                    _entityIds = cur.GetEntitySpan();
                    _currentSpan1 = cur.GetComponentSpan<T1>();
                    _currentSpan2 = cur.GetComponentSpan<T2>();
                    _currentSpan3 = cur.GetComponentSpan<T3>();
                    _currentSpan4 = cur.GetComponentSpan<T4>();
                    _currentSpan5 = cur.GetComponentSpan<T5>();
                    _currentSpan6 = cur.GetComponentSpan<T6>();
                }
                else
                {
                    return false;
                }
            } while (!(_componentIndex < _currentSpan1.Length));

            return true;
        }

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public EntityQueryEnumerator<T1, T2, T3, T4, T5, T6> GetEnumerator() => new EntityQueryEnumerator<T1, T2, T3, T4, T5, T6>(query);
        }
    }
}