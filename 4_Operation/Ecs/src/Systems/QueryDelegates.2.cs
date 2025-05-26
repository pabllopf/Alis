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
        public delegate void Query<T1, T2>(ref T1 comp1, ref T2 comp2);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}