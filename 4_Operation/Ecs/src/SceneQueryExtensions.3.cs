using Alis.Core.Ecs.Kernel.Memory;
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
        public static Query Query<T1, T2, T3>(this Scene scene)
            where T1 : struct, IRuleProvider
            where T2 : struct, IRuleProvider
            where T3 : struct, IRuleProvider

        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
            if (scene.QueryCache.TryGetValue(QueryHashCache<T1, T2, T3>.Value, out Query value)) return value;

            value = scene.CreateQuery(
                MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule, default(T3).Rule]));
            scene.QueryCache[QueryHashCache<T1, T2, T3>.Value] = value;
            return value;
#else
        ref Query cachedValue =
            ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(scene.QueryCache, QueryHashCache<T1, T2, T3>.Value, out bool exists);
        if (!exists)
        {
            cachedValue =
                scene.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule, default(T3).Rule]));
        }

        return cachedValue!;
#endif
        }
    }
}