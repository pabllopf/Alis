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
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    ///     Represents a set of entities from a world which can have systems applied to
    /// </summary>
    public partial class Query
    {
        /// <summary>
        ///     The rules
        /// </summary>
        private readonly FastImmutableArray<Rule> _rules;

        /// <summary>
        ///     The create
        /// </summary>
        private FastStack<Archetype> _archetypes = FastStack<Archetype>.Create(2);

        /// <summary>
        ///     Initializes a new instance of the <see cref="Query" /> class
        /// </summary>
        /// <param name="scene">The world</param>
        /// <param name="rules">The rules</param>
        internal Query(Scene scene, FastImmutableArray<Rule> rules)
        {
            Scene = scene;
            _rules = rules;
            foreach (Rule rule in rules)
            {
                if (rule == Rule.IncludeDisabledRule)
                {
                    IncludeDisabled = true;
                    break;
                }
            }
        }

        /// <summary>
        ///     Gets or inits the value of the world
        /// </summary>
        internal Scene Scene { get; init; }

        /// <summary>
        ///     Gets or inits the value of the include disabled
        /// </summary>
        internal bool IncludeDisabled { get; init; }

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
            if (!IncludeDisabled && archetype.HasTag<Disable>())
            {
                return;
            }

            if (ArchetypeSatisfiesQuery(archetype.ID))
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
    }


    /// <summary>
    ///     The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        ///     Enumerates this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>A query enumerator of t query enumerable</returns>
        public QueryEnumerator<T>.QueryEnumerable Enumerate<T>() => new(this);

        /// <summary>
        ///     Enumerates the with entities
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>An entity query enumerator of t query enumerable</returns>
        public EntityQueryEnumerator<T>.QueryEnumerable EnumerateWithEntities<T>() => new(this);

        /// <summary>
        ///     Enumerates the chunks
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>A chunk query enumerator of t query enumerable</returns>
        public ChunkQueryEnumerator<T>.QueryEnumerable EnumerateChunks<T>() => new(this);
    }

    /// <summary>
    ///     The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        ///     Enumerates the with entities
        /// </summary>
        /// <returns>The entity query enumerator query enumerable</returns>
        public EntityQueryEnumerator.QueryEnumerable EnumerateWithEntities() => new(this);
    }
}