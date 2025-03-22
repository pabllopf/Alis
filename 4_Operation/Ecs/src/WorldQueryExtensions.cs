﻿using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs
{
    public static partial class WorldQueryExtensions
    {
        //we could use static abstract methods IF NOT FOR DOTNET6
        /// <summary>
        /// Gets a query specified by the given rules
        /// </summary>
        /// <returns>The created or cached query.</returns>
        public static Query Query<T>(this World world)
            where T : struct, IRuleProvider
        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
        if (world.QueryCache.TryGetValue(QueryHashCache<T>.Value, out Query value))
        {
            return value;
        }

        value = world.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T).Rule]));
        world.QueryCache[QueryHashCache<T>.Value] = value;
        return value;
#else
            ref Query? cachedValue = ref CollectionsMarshal.GetValueRefOrAddDefault(world.QueryCache, QueryHashCache<T>.Value, out bool exists);
            if (!exists)
            {
                cachedValue = world.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T).Rule]));
            }
            return cachedValue!;
#endif
        }
    }
}
