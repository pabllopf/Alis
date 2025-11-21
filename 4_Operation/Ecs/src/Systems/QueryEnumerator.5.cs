// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerator.5.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query enumerator
    /// </summary>
    public ref struct QueryEnumerator<T1, T2, T3, T4, T5>
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
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T1> _currentSpan1;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T2> _currentSpan2;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T3> _currentSpan3;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T4> _currentSpan4;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T5> _currentSpan5;

        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="query">The query</param>
        private QueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current tuple of component references.
        /// </summary>
        public RefTuple<T1, T2, T3, T4, T5> Current => new()
        {
            Item1 = new Ref<T1>(_currentSpan1, _componentIndex),
            Item2 = new Ref<T2>(_currentSpan2, _componentIndex),
            Item3 = new Ref<T3>(_currentSpan3, _componentIndex),
            Item4 = new Ref<T4>(_currentSpan4, _componentIndex),
            Item5 = new Ref<T5>(_currentSpan5, _componentIndex)
        };

        /// <summary>
        ///     Indicates to the scene that this enumeration is finished; the scene might allow structual changes after this.
        /// </summary>
        /// <remarks>This MUST be called when finished with the enumerator!</remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next gameObject set of gameObject references.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _currentSpan1.Length)
            {
                return true;
            }

            _componentIndex = 0;
            _archetypeIndex++;

            while ((uint) _archetypeIndex < (uint) _archetypes.Length)
            {
                Archetype cur = _archetypes[_archetypeIndex];
                _currentSpan1 = cur.GetComponentSpan<T1>();
                _currentSpan2 = cur.GetComponentSpan<T2>();
                _currentSpan3 = cur.GetComponentSpan<T3>();
                _currentSpan4 = cur.GetComponentSpan<T4>();
                _currentSpan5 = cur.GetComponentSpan<T5>();


                if (!_currentSpan1.IsEmpty)
                {
                    return true;
                }

                _archetypeIndex++;
            }

            return false;
        }

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query"></param>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public QueryEnumerator<T1, T2, T3, T4, T5> GetEnumerator() => new QueryEnumerator<T1, T2, T3, T4, T5>(query);
        }
    }
}