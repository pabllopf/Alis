

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Memory;
using Alis.Core.Ecs.Operations;

namespace Alis.Core.Ecs
{
    public static partial class WorldQueryExtensions
    {
        
        /// <summary>
        /// Gets a query specified by the given rules
        /// </summary>
        /// <returns>The created or cached query.</returns>
        public static Query Query<T1, T2, T3, T4>(this World world)
            where T1 : struct, IRuleProvider
            where T2 : struct, IRuleProvider
            where T3 : struct, IRuleProvider
            where T4 : struct, IRuleProvider

        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
        if (world.QueryCache.TryGetValue(QueryHashCache<T1, T2, T3, T4>.Value, out Query value))
        {
            return value;
        }

        value = world.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule, default(T3).Rule, default(T4).Rule]));
        world.QueryCache[QueryHashCache<T1, T2, T3, T4>.Value] = value;
        return value;
#else
            ref Query cachedValue = ref CollectionsMarshal.GetValueRefOrAddDefault(world.QueryCache, QueryHashCache<T1, T2, T3, T4>.Value, out bool exists);
            if (!exists)
            {
                cachedValue = world.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule, default(T3).Rule, default(T4).Rule]));
            }
            return cachedValue!;
#endif
        }
    }
}
