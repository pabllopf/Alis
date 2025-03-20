

namespace Alis.Core.Ecs.Systems
{
    internal static class QueryHashCache<T>
        where T : struct, IRuleProvider
    {
        public static readonly int Value = new QueryHash()
            .AddRule(default(T).Rule)
            .ToHashCode();
    }
}
