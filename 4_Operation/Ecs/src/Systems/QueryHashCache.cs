

namespace Frent.Systems
{
    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<T>
        where T : struct, IRuleProvider
    {
        /// <summary>
        /// The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T).Rule)
            .ToHashCode();
    }
}
