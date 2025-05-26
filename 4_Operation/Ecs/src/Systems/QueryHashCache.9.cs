namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query hash cache class
    /// </summary>
    internal static class QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider
        where T6 : struct, IRuleProvider
        where T7 : struct, IRuleProvider
        where T8 : struct, IRuleProvider
        where T9 : struct, IRuleProvider

    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .AddRule(default(T4).Rule)
            .AddRule(default(T5).Rule)
            .AddRule(default(T6).Rule)
            .AddRule(default(T7).Rule)
            .AddRule(default(T8).Rule)
            .AddRule(default(T9).Rule)
            .ToHashCode();
    }
}