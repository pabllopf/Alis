// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneQueryExtensions.2.cs
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
        public static Query Query<T1, T2>(this Scene scene)
            where T1 : struct, IRuleProvider
            where T2 : struct, IRuleProvider

        {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
            if (scene.QueryCache.TryGetValue(QueryHashCache<T1, T2>.Value, out Query value))
            {
                return value;
            }

            value = scene.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule]));
            scene.QueryCache[QueryHashCache<T1, T2>.Value] = value;
            return value;
#else
            ref Query cachedValue =
                ref CollectionsMarshal.GetValueRefOrAddDefault(scene.QueryCache, QueryHashCache<T1, T2>.Value, out bool exists);
            if (!exists)
            {
                cachedValue =
                    scene.CreateQuery(MemoryHelpers.ReadOnlySpanToImmutableArray([default(T1).Rule, default(T2).Rule]));
            }

            return cachedValue!;
#endif
        }
    }
}