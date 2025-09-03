// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryHashCache.7.cs
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
}