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
using Alis.Core.Ecs.Arch;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    ///     The query iteration extensions class
    /// </summary>
    public static class QueryIterationExtensions
    {
        /// <summary>
        ///     Delegates the query
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T>(this Query query, QueryDelegates.Query<T> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T c1 = ref archetype.GetComponentDataReference<T>();

                //downcounting is faster
                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1);

                    c1 = ref Unsafe.Add(ref c1, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2>(this Query query, QueryDelegates.Query<T1, T2> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3>(this Query query, QueryDelegates.Query<T1, T2, T3> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4>(this Query query, QueryDelegates.Query<T1, T2, T3, T4> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                }
            }
        }


        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                }
            }
        }

        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                }
            }
        }
        
        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <typeparam name="T14">The 14</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();
                ref T14 c14 = ref archetype.GetComponentDataReference<T14>();
        
                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13, ref c14);
        
                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                    c14 = ref Unsafe.Add(ref c14, 1);
                }
            }
        }
        
        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <typeparam name="T14">The 14</typeparam>
        /// <typeparam name="T15">The 15</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();
                ref T14 c14 = ref archetype.GetComponentDataReference<T14>();
                ref T15 c15 = ref archetype.GetComponentDataReference<T15>();
        
                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13, ref c14, ref c15);
        
                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                    c14 = ref Unsafe.Add(ref c14, 1);
                    c15 = ref Unsafe.Add(ref c15, 1);
                }
            }
        }

        


        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <typeparam name="T14">The 14</typeparam>
        /// <typeparam name="T15">The 15</typeparam>
        /// <typeparam name="T16">The 16</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Query query, QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();
                ref T14 c14 = ref archetype.GetComponentDataReference<T14>();
                ref T15 c15 = ref archetype.GetComponentDataReference<T15>();
                ref T16 c16 = ref archetype.GetComponentDataReference<T16>();

                int size = archetype.EntityCount;
                for (int i = size; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13, ref c14, ref c15, ref c16);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                    c14 = ref Unsafe.Add(ref c14, 1);
                    c15 = ref Unsafe.Add(ref c15, 1);
                    c16 = ref Unsafe.Add(ref c16, 1);
                }
            }
        }

        /// <summary>
        ///     Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T>(this Query query, TAction action)
            where TAction : IAction<T>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T c1 = ref archetype.GetComponentDataReference<T>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1);

                    c1 = ref Unsafe.Add(ref c1, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2>(this Query query, TAction action)
            where TAction : IAction<T1, T2>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <typeparam name="T14">The 14</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();
                ref T14 c14 = ref archetype.GetComponentDataReference<T14>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13, ref c14);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                    c14 = ref Unsafe.Add(ref c14, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <typeparam name="T14">The 14</typeparam>
        /// <typeparam name="T15">The 15</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();
                ref T14 c14 = ref archetype.GetComponentDataReference<T14>();
                ref T15 c15 = ref archetype.GetComponentDataReference<T15>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13, ref c14, ref c15);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                    c14 = ref Unsafe.Add(ref c14, 1);
                    c15 = ref Unsafe.Add(ref c15, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <typeparam name="T9">The </typeparam>
        /// <typeparam name="T10">The 10</typeparam>
        /// <typeparam name="T11">The 11</typeparam>
        /// <typeparam name="T12">The 12</typeparam>
        /// <typeparam name="T13">The 13</typeparam>
        /// <typeparam name="T14">The 14</typeparam>
        /// <typeparam name="T15">The 15</typeparam>
        /// <typeparam name="T16">The 16</typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();
                ref T14 c14 = ref archetype.GetComponentDataReference<T14>();
                ref T15 c15 = ref archetype.GetComponentDataReference<T15>();
                ref T16 c16 = ref archetype.GetComponentDataReference<T16>();

                int size = archetype.EntityCount;
                for (nint i = size - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11, ref c12, ref c13, ref c14, ref c15, ref c16);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                    c14 = ref Unsafe.Add(ref c14, 1);
                    c15 = ref Unsafe.Add(ref c15, 1);
                    c16 = ref Unsafe.Add(ref c16, 1);
                }
            }
        }
    }
}