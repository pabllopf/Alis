using Frent.Core;
using Frent.Systems;

using System.Runtime.InteropServices;

namespace Frent;




/// <summary>
/// The world query extensions class
/// </summary>
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
        if (world.QueryCache.TryGetValue(QueryHashCache<T>.Value, out Query value))
        {
            return value;
        }

        value = world.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T).Rule]));
        world.QueryCache[QueryHashCache<T>.Value] = value;
        return value;

    }
}
