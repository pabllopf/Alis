namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Delegates for executing a functions on a <see cref="Query" />
    /// </summary>
    public static partial class QueryDelegates
    {
        // Missing XML comment for publicly visible type or member
        /// <summary>
        ///     The query
        /// </summary>
        public delegate void Query<T>(ref T comp1);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}