// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityEnumerator.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    ///     The entity enumerator
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1), SkipLocalsInit]
    public ref struct EntityEnumerator
    {
        /// <summary>
        ///     The world
        /// </summary>
        private readonly Scene scene;

        /// <summary>
        ///     The entities
        /// </summary>
        private readonly Span<EntityIdOnly> _entities;

        /// <summary>
        ///     The index
        /// </summary>
        private int _index;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityEnumerator" /> class
        /// </summary>
        /// <param name="scene">The world</param>
        /// <param name="entities">The entities</param>
        internal EntityEnumerator(Scene scene, Span<EntityIdOnly> entities)
        {
            this.scene = scene;
            _entities = entities;
            _index = -1;
        }

        /// <summary>
        ///     Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++_index < _entities.Length;

        /// <summary>
        ///     Gets the value of the current
        /// </summary>
        public GameObject Current => _entities[_index].ToEntity(scene);

        /// <summary>
        ///     The entity enumerable
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public ref struct EntityEnumerable
        {
            /// <summary>
            ///     The world
            /// </summary>
            private readonly Scene scene;

            /// <summary>
            ///     The entities
            /// </summary>
            private readonly Span<EntityIdOnly> _entities;

            /// <summary>
            ///     Initializes a new instance of the <see cref="EntityEnumerable" /> class
            /// </summary>
            /// <param name="scene">The world</param>
            /// <param name="entities">The entities</param>
            internal EntityEnumerable(Scene scene, Span<EntityIdOnly> entities)
            {
                this.scene = scene;
                _entities = entities;
            }

            /// <summary>
            ///     Gets the enumerator
            /// </summary>
            /// <returns>The entity enumerator</returns>
            public EntityEnumerator GetEnumerator() => new EntityEnumerator(scene, _entities);
        }
    }
}