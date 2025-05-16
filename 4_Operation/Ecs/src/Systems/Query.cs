﻿using System;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;
using System.Collections.Immutable;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// Represents a set of entities from a world which can have systems applied to
    /// </summary>
    public partial class Query
    {
        internal Span<Archetype> AsSpan() => _archetypes.AsSpan();

        private FastStack<Archetype> _archetypes = FastStack<Archetype>.Create(2);
        private ImmutableArray<Rule> _rules;
        internal World World { get; init; }
        internal bool IncludeDisabled { get; init; }

        internal Query(World world, ImmutableArray<Rule> rules)
        {
            World = world;
            _rules = rules;
            foreach (var rule in rules)
                if (rule == Rule.IncludeDisabledRule)
                {
                    IncludeDisabled = true;
                    break;
                }
        }

        internal void TryAttachArchetype(Archetype archetype)
        {
            if (!IncludeDisabled && archetype.HasTag<Disable>())
                return;

            if (ArchetypeSatisfiesQuery(archetype.ID))
                _archetypes.Push(archetype);
        }

        private bool ArchetypeSatisfiesQuery(ArchetypeID id)
        {
            foreach (var rule in _rules)
            {
                if (!rule.RuleApplies(id))
                {
                    return false;
                }
            }
            return true;
        }
    }

    
    partial class Query
    {
        /// <summary>
        /// Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T>.QueryEnumerable Enumerate<T>() => new(this);
        /// <summary>
        /// Enumerates component references and <see cref="Entity"/> instances for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public EntityQueryEnumerator<T>.QueryEnumerable EnumerateWithEntities<T>() => new(this);
        /// <summary>
        /// Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T>.QueryEnumerable EnumerateChunks<T>() => new(this);
    }

    partial class Query
    {
        /// <summary>
        /// Enumerates <see cref="Entity"/> instances for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public EntityQueryEnumerator.QueryEnumerable EnumerateWithEntities() => new(this);
    }
}