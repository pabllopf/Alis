using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The scene query extensions class
    /// </summary>
    public static partial class SceneQueryExtensions
    {
        //we could use static abstract methods IF NOT FOR DOTNET6
        /// <summary>
        ///     Gets a query specified by the given rules
        /// </summary>
        /// <returns>The created or cached query.</returns>
        public static Query Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Scene scene)
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

        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
            if (scene.QueryCache.TryGetValue(QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.Value,
                    out Query value)) return value;

            value = scene.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([
                default(T1).Rule, default(T2).Rule, default(T3).Rule, default(T4).Rule, default(T5).Rule, default(T6).Rule,
                default(T7).Rule, default(T8).Rule, default(T9).Rule, default(T10).Rule, default(T11).Rule
            ]));
            scene.QueryCache[QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.Value] = value;
            return value;
#else
        ref Query cachedValue =
            ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(scene.QueryCache, QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.Value, out bool exists);
        if (!exists)
        {
            cachedValue =
                scene.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule, default(T3).Rule, default(T4).Rule, default(T5).Rule, default(T6).Rule, default(T7).Rule, default(T8).Rule, default(T9).Rule, default(T10).Rule, default(T11).Rule]));
        }

        return cachedValue!;
#endif
        }
    }
}