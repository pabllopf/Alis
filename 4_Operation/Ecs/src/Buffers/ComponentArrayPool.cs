// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentArrayPool.cs
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

using System;
using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Marshalling;

namespace Alis.Core.Ecs.Buffers
{
    /// <summary>
    ///     The component array pool class
    /// </summary>
    /// <seealso cref="ArrayPool{T}" />
    public sealed class ComponentArrayPool<T> : ArrayPool<T>
    {
        /// <summary>
        ///     The buckets
        /// </summary>
        private readonly T[][] Buckets;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentArrayPool{T}" /> class
        /// </summary>
        public ComponentArrayPool()
        {
            Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;
            Buckets = new T[27][];
        }

        /// <summary>
        ///     Gets the value of the instance
        /// </summary>
        public static ComponentArrayPool<T> Instance { get; } = new ComponentArrayPool<T>();

        /// <summary>
        ///     Rents the minimum length
        /// </summary>
        /// <param name="minimumLength">The minimum length</param>
        /// <returns>The array</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override T[] Rent(int minimumLength)
        {
            if ((uint) minimumLength < 16u)
            {
                return new T[minimumLength];
            }

            int bucketIndex = BitOperations.Log2((uint) minimumLength) - 4;
            if ((uint) bucketIndex < (uint) Buckets.Length)
            {
                T[] array = Buckets[bucketIndex];
                if (array != null)
                {
                    Buckets[bucketIndex] = null;
                    return array;
                }
            }

            return new T[minimumLength];
        }

        /// <summary>
        ///     Returns the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="clearArray">The clear array</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Return(T[] array, bool clearArray = false)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                array.AsSpan().Clear();
            }

            int bucketIndex = BitOperations.Log2((uint) array.Length) - 4;
            if ((uint) bucketIndex < (uint) Buckets.Length)
            {
                Buckets[bucketIndex] = array;
            }
        }

        /// <summary>
        ///     Resizes the array from pool using the specified arr
        /// </summary>
        /// <param name="arr">The arr</param>
        /// <param name="len">The len</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ResizeArrayFromPool(ref T[] arr, int len)
        {
            T[] newArr = Instance.Rent(len);
            arr.AsSpan().CopyTo(newArr);
            Instance.Return(arr);
            arr = newArr;
        }

        /// <summary>
        ///     Clears the buckets
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ClearBuckets() => Array.Clear(Buckets, 0, Buckets.Length);
    }
}