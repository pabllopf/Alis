// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryIterationExtensions.cs
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

using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query iteration extensions class
    /// </summary>
    public static partial class QueryIterationExtensions
    {
        /// <summary>
        ///     Executes a delegate for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The behavior to execute on every component set.</param>
        public static void Delegate<T>(this Query query, QueryDelegates.Query<T> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T c1 = ref archetype.GetComponentDataReference<T>();

                //downcounting is faster
                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action(ref c1);

                    c1 = ref Unsafe.Add(ref c1, 1);
                }
            }
        }

        /// <summary>
        ///     Executes a inlinable struct instance method for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The struct behavior to execute on every component set.</param>
        public static void Inline<TAction, T>(this Query query, TAction action)
            where TAction : IAction<T>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T c1 = ref archetype.GetComponentDataReference<T>();

                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action.Run(ref c1);

                    c1 = ref Unsafe.Add(ref c1, 1);
                }
            }
        }
    }
}