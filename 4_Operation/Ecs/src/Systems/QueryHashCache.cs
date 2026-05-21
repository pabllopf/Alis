

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T">The type of the rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T>
        where T : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the single rule of type <typeparamref name="T"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T1">The type of the first rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T2">The type of the second rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T1, T2>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the rules of types <typeparamref name="T1"/> and <typeparamref name="T2"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T1">The type of the first rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T2">The type of the second rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T3">The type of the third rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T1, T2, T3>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the rules of types <typeparamref name="T1"/>,
        ///     <typeparamref name="T2"/>, and <typeparamref name="T3"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T1">The type of the first rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T2">The type of the second rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T3">The type of the third rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T4">The type of the fourth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the rules of types
        ///     <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>, and <typeparamref name="T4"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .AddRule(default(T4).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T1">The type of the first rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T2">The type of the second rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T3">The type of the third rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T4">The type of the fourth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T5">The type of the fifth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4, T5>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the rules of types
        ///     <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>,
        ///     <typeparamref name="T4"/>, and <typeparamref name="T5"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .AddRule(default(T4).Rule)
            .AddRule(default(T5).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T1">The type of the first rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T2">The type of the second rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T3">The type of the third rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T4">The type of the fourth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T5">The type of the fifth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T6">The type of the sixth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4, T5, T6>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider
        where T6 : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the rules of types
        ///     <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>,
        ///     <typeparamref name="T4"/>, <typeparamref name="T5"/>, and <typeparamref name="T6"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .AddRule(default(T4).Rule)
            .AddRule(default(T5).Rule)
            .AddRule(default(T6).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T1">The type of the first rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T2">The type of the second rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T3">The type of the third rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T4">The type of the fourth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T5">The type of the fifth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T6">The type of the sixth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T7">The type of the seventh rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4, T5, T6, T7>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider
        where T6 : struct, IRuleProvider
        where T7 : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the rules of types
        ///     <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>,
        ///     <typeparamref name="T4"/>, <typeparamref name="T5"/>, <typeparamref name="T6"/>, and <typeparamref name="T7"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .AddRule(default(T4).Rule)
            .AddRule(default(T5).Rule)
            .AddRule(default(T6).Rule)
            .AddRule(default(T7).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     Provides cached hash codes for queries based on their component rule types.
    /// </summary>
    /// <remarks>
    ///     Each generic variant pre-computes the hash at static initialization time,
    ///     enabling fast query lookup without recomputation at runtime.
    /// </remarks>
    /// <typeparam name="T1">The type of the first rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T2">The type of the second rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T3">The type of the third rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T4">The type of the fourth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T5">The type of the fifth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T6">The type of the sixth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T7">The type of the seventh rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    /// <typeparam name="T8">The type of the eighth rule, which must be a value type implementing <see cref="IRuleProvider"/>.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4, T5, T6, T7, T8>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider
        where T6 : struct, IRuleProvider
        where T7 : struct, IRuleProvider
        where T8 : struct, IRuleProvider
    {
        /// <summary>
        ///     The pre-computed hash code for a query containing the rules of types
        ///     <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/>,
        ///     <typeparamref name="T4"/>, <typeparamref name="T5"/>, <typeparamref name="T6"/>,
        ///     <typeparamref name="T7"/>, and <typeparamref name="T8"/>.
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .AddRule(default(T4).Rule)
            .AddRule(default(T5).Rule)
            .AddRule(default(T6).Rule)
            .AddRule(default(T7).Rule)
            .AddRule(default(T8).Rule)
            .ToHashCode();
    }
}