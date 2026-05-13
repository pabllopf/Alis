// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryHashCache.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    internal static class QueryHashCache<T>
        where T : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    internal static class QueryHashCache<T1, T2>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider

    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    internal static class QueryHashCache<T1, T2, T3>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider

    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider

    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(T1).Rule)
            .AddRule(default(T2).Rule)
            .AddRule(default(T3).Rule)
            .AddRule(default(T4).Rule)
            .ToHashCode();
    }

    /// <summary>
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4, T5>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider

    {
        /// <summary>
        ///     The to hash code
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
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="T6">The sixth component type.</typeparam>
    internal static class QueryHashCache<T1, T2, T3, T4, T5, T6>
        where T1 : struct, IRuleProvider
        where T2 : struct, IRuleProvider
        where T3 : struct, IRuleProvider
        where T4 : struct, IRuleProvider
        where T5 : struct, IRuleProvider
        where T6 : struct, IRuleProvider

    {
        /// <summary>
        ///     The to hash code
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
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="T6">The sixth component type.</typeparam>
    /// <typeparam name="T7">The seventh component type.</typeparam>
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
        ///     The to hash code
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
    ///     The query hash cache class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="T6">The sixth component type.</typeparam>
    /// <typeparam name="T7">The seventh component type.</typeparam>
    /// <typeparam name="T8">The eighth component type.</typeparam>
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
        ///     The to hash code
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