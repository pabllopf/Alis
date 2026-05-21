

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1> GetEnumerator() => new GameObjectQueryEnumerator<T1>(query);
    }

    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2>(query);
    }

    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2, T3>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2, T3> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2, T3>(query);
    }

    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2, T3, T4>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2, T3, T4> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2, T3, T4>(query);
    }

    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2, T3, T4, T5>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2, T3, T4, T5> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2, T3, T4, T5>(query);
    }

    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2, T3, T4, T5, T6>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6>(query);
    }

    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2, T3, T4, T5, T6, T7>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6, T7> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>(query);
    }

    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    /// <remarks>
    ///     Memory layout optimized: Query reference (8 bytes) captured in primary constructor
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2, T3, T4, T5, T6, T7, T8>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>(query);
    }
}