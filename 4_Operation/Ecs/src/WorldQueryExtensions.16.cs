




using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Systems;
using Alis.Variadic.Generator;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs;
    public static partial class WorldQueryExtensions
    {
        //we could use static abstract methods IF NOT FOR DOTNET6
        /// <summary>
        /// Gets a query specified by the given rules
        /// </summary>
        /// <returns>The created or cached query.</returns>
        public static Query Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this World world)
            where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider
        where T6 : struct, IRuleProvider
        where T7 : struct, IRuleProvider
        where T8 : struct, IRuleProvider
        where T9 : struct, IRuleProvider
        where T10 : struct, IRuleProvider
        where T11 : struct, IRuleProvider
        where T12 : struct, IRuleProvider
        where T13 : struct, IRuleProvider
        where T14 : struct, IRuleProvider
        where T15 : struct, IRuleProvider
        where T16 : struct, IRuleProvider

        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        if (world.QueryCache.TryGetValue(QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Value, out Query value))
        {
            return value;
        }

        value = world.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule, default(T3).Rule, default(T4).Rule, default(T5).Rule, default(T6).Rule, default(T7).Rule, default(T8).Rule, default(T9).Rule, default(T10).Rule, default(T11).Rule, default(T12).Rule, default(T13).Rule, default(T14).Rule, default(T15).Rule, default(T16).Rule]));
        world.QueryCache[QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Value] = value;
        return value;
#else
            ref Query? cachedValue = ref CollectionsMarshal.GetValueRefOrAddDefault(world.QueryCache, QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Value, out bool exists);
            if (!exists)
            {
                cachedValue = world.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule, default(T3).Rule, default(T4).Rule, default(T5).Rule, default(T6).Rule, default(T7).Rule, default(T8).Rule, default(T9).Rule, default(T10).Rule, default(T11).Rule, default(T12).Rule, default(T13).Rule, default(T14).Rule, default(T15).Rule, default(T16).Rule]));
            }
            return cachedValue!;
#endif
        }
    }
