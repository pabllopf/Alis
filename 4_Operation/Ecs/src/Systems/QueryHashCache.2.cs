




using Alis.Variadic.Generator;

namespace Alis.Core.Ecs.Systems;
    internal static class QueryHashCache<T1, T2>
        where T1 : struct, IRuleProvider
    where T2 : struct, IRuleProvider

    {
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
        .AddRule(default(T2).Rule)

            .ToHashCode();
    }
