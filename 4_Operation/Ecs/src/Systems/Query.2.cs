




using System;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core;
using Alis.Variadic.Generator;
using System.Collections.Immutable;

namespace Alis.Core.Ecs.Systems;
    partial class Query
    {
        /// <summary>
        /// Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T1, T2>.QueryEnumerable Enumerate<T1, T2>() => new(this);
        /// <summary>
        /// Enumerates component references and <see cref="Entity"/> instances for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public EntityQueryEnumerator<T1, T2>.QueryEnumerable EnumerateWithEntities<T1, T2>() => new(this);
        /// <summary>
        /// Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T1, T2>.QueryEnumerable EnumerateChunks<T1, T2>() => new(this);
    }
