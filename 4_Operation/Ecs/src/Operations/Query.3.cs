









namespace Alis.Core.Ecs.Operations
{
    partial class Query
    {
        /// <summary>
        /// Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T1, T2, T3>.QueryEnumerable Enumerate<T1, T2, T3>() => new(this);
        /// <summary>
        /// Enumerates component references and <see cref="GameObject"/> instances for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public EntityQueryEnumerator<T1, T2, T3>.QueryEnumerable EnumerateWithEntities<T1, T2, T3>() => new(this);
        /// <summary>
        /// Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T1, T2, T3>.QueryEnumerable EnumerateChunks<T1, T2, T3>() => new(this);
    }
}
