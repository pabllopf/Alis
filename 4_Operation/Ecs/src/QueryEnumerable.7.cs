// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerable.7.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Proxy type for foreach syntax
    /// </summary>
    /// <param name="query">The query to wrap.</param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct QueryEnumerable<T1, T2, T3, T4, T5, T6, T7>(Query query)
    {
        /// <summary>
        ///     Gets the enumerator over a query.
        /// </summary>
        public GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6, T7> GetEnumerator() => new GameObjectQueryEnumerator<T1, T2, T3, T4, T5, T6, T7>(query);
    }
}