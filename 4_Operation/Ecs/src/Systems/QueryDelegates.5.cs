namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query delegates class
    /// </summary>
    public static partial class QueryDelegates
    {
        // Missing XML comment for publicly visible type or member
        /// <summary>
        ///     The query
        /// </summary>
        public delegate void
            Query<T1, T2, T3, T4, T5>(ref T1 comp1, ref T2 comp2, ref T3 comp3, ref T4 comp4, ref T5 comp5);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}