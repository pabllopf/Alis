namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query class
    /// </summary>
    partial class Query
    {
        /// <summary>
        ///     Enumerates component references for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public QueryEnumerator<T1, T2, T3, T4>.QueryEnumerable Enumerate<T1, T2, T3, T4>()
        {
            return new QueryEnumerator<T1, T2, T3, T4>.QueryEnumerable(this);
        }

        /// <summary>
        ///     Enumerates component references and <see cref="GameObject" /> instances for all entities in this query. Intended for
        ///     use in foreach loops.
        /// </summary>
        public QueryEnumerable<T1, T2, T3, T4> EnumerateWithEntities<T1, T2, T3, T4>()
        {
            return new QueryEnumerable<T1, T2, T3, T4>(this);
        }

        /// <summary>
        ///     Enumerates component chunks for all entities in this query. Intended for use in foreach loops.
        /// </summary>
        public ChunkQueryEnumerator<T1, T2, T3, T4>.QueryEnumerable EnumerateChunks<T1, T2, T3, T4>()
        {
            return new ChunkQueryEnumerator<T1, T2, T3, T4>.QueryEnumerable(this);
        }
    }
}