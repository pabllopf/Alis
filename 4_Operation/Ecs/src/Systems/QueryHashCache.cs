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
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .ToHashCode();
    }


    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .ToHashCode();
    }


    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
        where TArg10 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .AddRule(default(TArg10).Rule)
            .ToHashCode();
    }


    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
        where TArg10 : struct, IRuleProvider
        where TArg11 : struct, IRuleProvider
    {
        /// <summary>
        ///     The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .AddRule(default(TArg10).Rule)
            .AddRule(default(TArg11).Rule)
            .ToHashCode();
    }



    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
        where TArg10 : struct, IRuleProvider
        where TArg11 : struct, IRuleProvider
        where TArg12 : struct, IRuleProvider
    {
        /// <summary>
        /// The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .AddRule(default(TArg10).Rule)
            .AddRule(default(TArg11).Rule)
            .AddRule(default(TArg12).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
        where TArg10 : struct, IRuleProvider
        where TArg11 : struct, IRuleProvider
        where TArg12 : struct, IRuleProvider
        where TArg13 : struct, IRuleProvider
    {
        /// <summary>
        /// The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .AddRule(default(TArg10).Rule)
            .AddRule(default(TArg11).Rule)
            .AddRule(default(TArg12).Rule)
            .AddRule(default(TArg13).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
        where TArg10 : struct, IRuleProvider
        where TArg11 : struct, IRuleProvider
        where TArg12 : struct, IRuleProvider
        where TArg13 : struct, IRuleProvider
        where TArg14 : struct, IRuleProvider
    {
        /// <summary>
        /// The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .AddRule(default(TArg10).Rule)
            .AddRule(default(TArg11).Rule)
            .AddRule(default(TArg12).Rule)
            .AddRule(default(TArg13).Rule)
            .AddRule(default(TArg14).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
        where TArg10 : struct, IRuleProvider
        where TArg11 : struct, IRuleProvider
        where TArg12 : struct, IRuleProvider
        where TArg13 : struct, IRuleProvider
        where TArg14 : struct, IRuleProvider
        where TArg15 : struct, IRuleProvider
    {
        /// <summary>
        /// The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .AddRule(default(TArg10).Rule)
            .AddRule(default(TArg11).Rule)
            .AddRule(default(TArg12).Rule)
            .AddRule(default(TArg13).Rule)
            .AddRule(default(TArg14).Rule)
            .AddRule(default(TArg15).Rule)
            .ToHashCode();
    }

    /// <summary>
    /// The query hash cache class
    /// </summary>
    internal static class QueryHashCache<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16>
        where TArg1 : struct, IRuleProvider
        where TArg2 : struct, IRuleProvider
        where TArg3 : struct, IRuleProvider
        where TArg4 : struct, IRuleProvider
        where TArg5 : struct, IRuleProvider
        where TArg6 : struct, IRuleProvider
        where TArg7 : struct, IRuleProvider
        where TArg8 : struct, IRuleProvider
        where TArg9 : struct, IRuleProvider
        where TArg10 : struct, IRuleProvider
        where TArg11 : struct, IRuleProvider
        where TArg12 : struct, IRuleProvider
        where TArg13 : struct, IRuleProvider
        where TArg14 : struct, IRuleProvider
        where TArg15 : struct, IRuleProvider
        where TArg16 : struct, IRuleProvider
    {
        /// <summary>
        /// The to hash code
        /// </summary>
        public static readonly int Value = new QueryHash()
            .AddRule(default(TArg1).Rule)
            .AddRule(default(TArg2).Rule)
            .AddRule(default(TArg3).Rule)
            .AddRule(default(TArg4).Rule)
            .AddRule(default(TArg5).Rule)
            .AddRule(default(TArg6).Rule)
            .AddRule(default(TArg7).Rule)
            .AddRule(default(TArg8).Rule)
            .AddRule(default(TArg9).Rule)
            .AddRule(default(TArg10).Rule)
            .AddRule(default(TArg11).Rule)
            .AddRule(default(TArg12).Rule)
            .AddRule(default(TArg13).Rule)
            .AddRule(default(TArg14).Rule)
            .AddRule(default(TArg15).Rule)
            .AddRule(default(TArg16).Rule)
            .ToHashCode();
    }

}