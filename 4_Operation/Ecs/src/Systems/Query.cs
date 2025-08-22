using System;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Represents a set of entities from a scene which can have systems applied to
    /// </summary>
    public partial class Query
    {
        /// <summary>
        ///     The create
        /// </summary>
        private FastestStack<Archetype> _archetypes = FastestStack<Archetype>.Create(2);

        /// <summary>
        ///     The rules
        /// </summary>
        private FastImmutableArray<Rule> _rules;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Query" /> class
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="rules">The rules</param>
        internal Query(Scene scene, FastImmutableArray<Rule> rules)
        {
            Scene = scene;
            _rules = rules;
            foreach (Rule rule in rules)
                if (rule == Rule.IncludeDisabledRule)
                {
                    IncludeDisabled = true;
                    break;
                }
        }

        /// <summary>
        ///     Gets or inits the value of the scene
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
        internal Span<Archetype> AsSpan()
        {
            return _archetypes.AsSpan();
        }

        /// <summary>
        ///     Tries the attach archetype using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        internal void TryAttachArchetype(Archetype archetype)
        {
            if (!IncludeDisabled && archetype.HasTag<Disable>())
                return;

            if (ArchetypeSatisfiesQuery(archetype.Id))
                _archetypes.Push(archetype);
        }

        /// <summary>
        ///     Archetypes the satisfies query using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
        private bool ArchetypeSatisfiesQuery(GameObjectType id)
        {
            foreach (Rule rule in _rules)
                if (!rule.RuleApplies(id))
                    return false;

            return true;
        }
    }

    /// <summary>
    ///     The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T>.QueryEnumerable Enumerate<T>()
        {
            return new QueryEnumerator<T>.QueryEnumerable(this);
        }

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended for
        ///     use in foreach loops.
        /// </summary>
        public GameObjectQueryEnumerator<T>.QueryEnumerable EnumerateWithEntities<T>()
        {
            return new GameObjectQueryEnumerator<T>.QueryEnumerable(this);
        }

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T>.QueryEnumerable EnumerateChunks<T>()
        {
            return new ChunkQueryEnumerator<T>.QueryEnumerable(this);
        }
    }

    /// <summary>
    ///     The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        ///     Enumerates <see cref="GameObject" /> instances for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public GameObjectQueryEnumerator.QueryEnumerable EnumerateWithEntities()
        {
            return new GameObjectQueryEnumerator.QueryEnumerable(this);
        }
    }
}