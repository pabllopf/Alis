









namespace Alis.Core.Ecs.Operations
{
    partial class Query
    {
        /// <summary>
        /// Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.QueryEnumerable Enumerate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>() => new(this);
        /// <summary>
        /// Enumerates component references and <see cref="GameObject"/> instances for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public EntityQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.QueryEnumerable EnumerateWithEntities<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>() => new(this);
        /// <summary>
        /// Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.QueryEnumerable EnumerateChunks<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>() => new(this);
    }
}
