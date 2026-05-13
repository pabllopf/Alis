// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Query.cs
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
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Represents a set of entities from a scene which can have systems applied to
    /// </summary>
    public class Query
    {
        /// <summary>
        ///     The rules
        /// </summary>
        private readonly FastImmutableArray<Rule> _rules;

        /// <summary>
        ///     The create
        /// </summary>
        private FastestStack<Archetype> _archetypes = FastestStack<Archetype>.Create(2);

        /// <summary>
        ///     Initializes a new instance of the <see cref="Query" /> class
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="rules">The rules</param>
        internal Query(Scene scene, FastImmutableArray<Rule> rules)
        {
            Scene = scene;
            _rules = rules;
        }

        /// <summary>
        ///     Gets or inits the value of the scene
        /// </summary>
        internal Scene Scene { get; init; }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of archetype</returns>
        internal Span<Archetype> AsSpan() => _archetypes.AsSpan();

        /// <summary>
        ///     Tries the attach archetype using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        internal void TryAttachArchetype(Archetype archetype)
        {
            if (ArchetypeSatisfiesQuery(archetype.Id))
            {
                _archetypes.Push(archetype);
            }
        }

        /// <summary>
        ///     Archetypes the satisfies query using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
        private bool ArchetypeSatisfiesQuery(ArchetypeID id)
        {
            foreach (Rule rule in _rules)
            {
                if (!rule.RuleApplies(id))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T">The component type to enumerate</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over component references</returns>
        public QueryEnumerator<T>.QueryEnumerable Enumerate<T>() => new QueryEnumerator<T>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T">The component type to enumerate</typeparam>
        /// <returns>An enumerable that yields both the gameObject and component reference</returns>
        public GameObjectQueryEnumerator<T>.QueryEnumerable EnumerateWithEntities<T>() => new GameObjectQueryEnumerator<T>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T">The component type to enumerate as chunks</typeparam>
        /// <returns>An enumerable that yields spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T>.QueryEnumerable EnumerateChunks<T>() => new ChunkQueryEnumerator<T>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates <see cref="GameObject" /> instances for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <returns>An enumerable that yields gameObject instances</returns>
        public GameObjectQueryEnumerator.QueryEnumerable EnumerateWithEntities() => new GameObjectQueryEnumerator.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over paired component references</returns>
        public QueryEnumerator<T1, T2>.QueryEnumerable Enumerate<T1, T2>() => new QueryEnumerator<T1, T2>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <returns>An enumerable that yields the gameObject and paired component references</returns>
        public QueryEnumerable<T1, T2> EnumerateWithEntities<T1, T2>() => new QueryEnumerable<T1, T2>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <returns>An enumerable that yields paired spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T1, T2>.QueryEnumerable EnumerateChunks<T1, T2>() => new ChunkQueryEnumerator<T1, T2>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over three component references</returns>
        public QueryEnumerator<T1, T2, T3>.QueryEnumerable Enumerate<T1, T2, T3>() => new QueryEnumerator<T1, T2, T3>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <returns>An enumerable that yields the gameObject and three component references</returns>
        public QueryEnumerable<T1, T2, T3> EnumerateWithEntities<T1, T2, T3>() => new QueryEnumerable<T1, T2, T3>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <returns>An enumerable that yields three spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T1, T2, T3>.QueryEnumerable EnumerateChunks<T1, T2, T3>() => new ChunkQueryEnumerator<T1, T2, T3>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over four component references</returns>
        public QueryEnumerator<T1, T2, T3, T4>.QueryEnumerable Enumerate<T1, T2, T3, T4>() => new QueryEnumerator<T1, T2, T3, T4>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <returns>An enumerable that yields the gameObject and four component references</returns>
        public QueryEnumerable<T1, T2, T3, T4> EnumerateWithEntities<T1, T2, T3, T4>() => new QueryEnumerable<T1, T2, T3, T4>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <returns>An enumerable that yields four spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T1, T2, T3, T4>.QueryEnumerable EnumerateChunks<T1, T2, T3, T4>() => new ChunkQueryEnumerator<T1, T2, T3, T4>.QueryEnumerable(this);


        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over five component references</returns>
        public QueryEnumerator<T1, T2, T3, T4, T5>.QueryEnumerable Enumerate<T1, T2, T3, T4, T5>() => new QueryEnumerator<T1, T2, T3, T4, T5>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <returns>An enumerable that yields the gameObject and five component references</returns>
        public QueryEnumerable<T1, T2, T3, T4, T5> EnumerateWithEntities<T1, T2, T3, T4, T5>() => new QueryEnumerable<T1, T2, T3, T4, T5>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <returns>An enumerable that yields five spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T1, T2, T3, T4, T5>.QueryEnumerable EnumerateChunks<T1, T2, T3, T4, T5>() => new ChunkQueryEnumerator<T1, T2, T3, T4, T5>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over six component references</returns>
        public QueryEnumerator<T1, T2, T3, T4, T5, T6>.QueryEnumerable Enumerate<T1, T2, T3, T4, T5, T6>() => new QueryEnumerator<T1, T2, T3, T4, T5, T6>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <returns>An enumerable that yields the gameObject and six component references</returns>
        public QueryEnumerable<T1, T2, T3, T4, T5, T6> EnumerateWithEntities<T1, T2, T3, T4, T5, T6>() => new QueryEnumerable<T1, T2, T3, T4, T5, T6>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <returns>An enumerable that yields six spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6>.QueryEnumerable EnumerateChunks<T1, T2, T3, T4, T5, T6>() => new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over seven component references</returns>
        public QueryEnumerator<T1, T2, T3, T4, T5, T6, T7>.QueryEnumerable Enumerate<T1, T2, T3, T4, T5, T6, T7>() => new QueryEnumerator<T1, T2, T3, T4, T5, T6, T7>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <returns>An enumerable that yields the gameObject and seven component references</returns>
        public QueryEnumerable<T1, T2, T3, T4, T5, T6, T7> EnumerateWithEntities<T1, T2, T3, T4, T5, T6,
            T7>()
            => new QueryEnumerable<T1, T2, T3, T4, T5, T6, T7>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <returns>An enumerable that yields seven spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>.QueryEnumerable
            EnumerateChunks<T1, T2, T3, T4, T5, T6, T7>()
            => new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <typeparam name="T8">The eighth component type</typeparam>
        /// <returns>An enumerable that can be used in a foreach loop over eight component references</returns>
        public QueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>.QueryEnumerable Enumerate<T1, T2, T3, T4, T5, T6, T7, T8>() => new QueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>.QueryEnumerable(this);

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended
        ///     for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <typeparam name="T8">The eighth component type</typeparam>
        /// <returns>An enumerable that yields the gameObject and eight component references</returns>
        public QueryEnumerable<T1, T2, T3, T4, T5, T6, T7, T8> EnumerateWithEntities<T1, T2, T3, T4,
            T5, T6, T7, T8>()
            => new QueryEnumerable<T1, T2, T3, T4, T5, T6, T7, T8>(this);

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
        /// <typeparam name="T2">The second component type</typeparam>
        /// <typeparam name="T3">The third component type</typeparam>
        /// <typeparam name="T4">The fourth component type</typeparam>
        /// <typeparam name="T5">The fifth component type</typeparam>
        /// <typeparam name="T6">The sixth component type</typeparam>
        /// <typeparam name="T7">The seventh component type</typeparam>
        /// <typeparam name="T8">The eighth component type</typeparam>
        /// <returns>An enumerable that yields eight spans of contiguous component data</returns>
        public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>.QueryEnumerable EnumerateChunks<T1, T2, T3, T4, T5, T6,
            T7, T8>()
            => new ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>.QueryEnumerable(this);
    }
}