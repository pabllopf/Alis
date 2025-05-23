namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query hash cache class
    /// </summary>
    internal static class QueryHashCache<T1, T2>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider

    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .ToHashCode();
    }
}