using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Extensions to use query the scene.
    /// </summary>
    public static partial class SceneQueryExtensions
    {
        //we could use static abstract methods IF NOT FOR DOTNET6
        /// <summary>
        ///     Gets a query specified by the given rules
        /// </summary>
        /// <returns>The created or cached query.</returns>
        public static Query Query<T>(this Scene scene)
            where T : struct, IRuleProvider
        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        if (scene.QueryCache.TryGetValue(QueryHashCache<T>.Value, out Query value)) return value;

        value = scene.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T).Rule]));
        scene.QueryCache[QueryHashCache<T>.Value] = value;
        return value;
#else
            ref Query cachedValue =
                ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(scene.QueryCache, QueryHashCache<T>.Value, out bool exists);
            if (!exists)
            {
                cachedValue = scene.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T).Rule]));
            }

            return cachedValue!;
#endif
        }
    }
}