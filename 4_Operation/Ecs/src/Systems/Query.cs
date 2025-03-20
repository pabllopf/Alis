using System;
using System.Collections.Immutable;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// Represents a set of entities from a world which can have systems applied to
    /// </summary>
    public partial class Query
    {
        /// <summary>
        /// Converts the span
        /// </summary>
        /// <returns>A span of archetype</returns>
        internal Span<Archetype> AsSpan() => _archetypes.AsSpan();

        /// <summary>
        /// The create
        /// </summary>
        private FastStack<Archetype> _archetypes = FastStack<Archetype>.Create(2);
        /// <summary>
        /// The rules
        /// </summary>
        private ImmutableArray<Rule> _rules;
        /// <summary>
        /// Gets or inits the value of the world
        /// </summary>
        internal World World { get; init; }
        /// <summary>
        /// Gets or inits the value of the include disabled
        /// </summary>
        internal bool IncludeDisabled { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="rules">The rules</param>
        internal Query(World world, ImmutableArray<Rule> rules)
        {
            World = world;
            _rules = rules;
            foreach (Rule rule in rules)
                if (rule == Rule.IncludeDisabledRule)
                {
                    IncludeDisabled = true;
                    break;
                }
        }

        /// <summary>
        /// Tries the attach archetype using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        internal void TryAttachArchetype(Archetype archetype)
        {
            if (!IncludeDisabled && archetype.HasTag<Disable>())
                return;

            if (ArchetypeSatisfiesQuery(archetype.ID))
                _archetypes.Push(archetype);
        }

        /// <summary>
        /// Archetypes the satisfies query using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
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


    /// <summary>
    /// The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        /// Enumerates this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>A query enumerator of t query enumerable</returns>
        public QueryEnumerator<T>.QueryEnumerable Enumerate<T>() => new(this);
        /// <summary>
        /// Enumerates the with entities
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>An entity query enumerator of t query enumerable</returns>
        public EntityQueryEnumerator<T>.QueryEnumerable EnumerateWithEntities<T>() => new(this);
        /// <summary>
        /// Enumerates the chunks
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>A chunk query enumerator of t query enumerable</returns>
        public ChunkQueryEnumerator<T>.QueryEnumerable EnumerateChunks<T>() => new(this);
    }

    /// <summary>
    /// The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        /// Enumerates the with entities
        /// </summary>
        /// <returns>The entity query enumerator query enumerable</returns>
        public EntityQueryEnumerator.QueryEnumerable EnumerateWithEntities() => new(this);
    }
}