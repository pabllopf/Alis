// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastStackArrayPool.cs
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
using Alis.Core.Ecs.Memory;

namespace Alis.Benchmark.CustomCollections.ArrayPools
{
    /// <summary>
    ///     The fast stack array pool class
    /// </summary>
    /// <seealso cref="ArrayPool{T}" />
    public class FastStackArrayPool<T> : ArrayPool<T>
    {
        /// <summary>
        ///     The buckets
        /// </summary>
        private readonly T[][] Buckets;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastStackArrayPool{T}" /> class
        /// </summary>
        public FastStackArrayPool()
        {
            //16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 
            Gen2GcCallback.Gen2CollectionOccured += ClearBuckets;

            Buckets = new T[27][];
        }

        /// <summary>
        ///     Gets the value of the instance
        /// </summary>
        public static FastStackArrayPool<T> Instance { get; } = new FastStackArrayPool<T>();

        /// <summary>
        ///     Resizes the array from pool using the specified arr
        /// </summary>
        /// <param name="arr">The arr</param>
        /// <param name="len">The len</param>
        public static void ResizeArrayFromPool(ref T[] arr, int len)
        {
            T[] finalArr = Instance.Rent(len);
            arr.AsSpan().CopyTo(finalArr);
            Instance.Return(arr);
            arr = finalArr;
        }

        /// <summary>
        ///     Rents the minimum length
        /// </summary>
        /// <param name="minimumLength">The minimum length</param>
        /// <returns>The array</returns>
        public override T[] Rent(int minimumLength)
        {
            if (minimumLength < 16)
            {
                return new T[minimumLength];
            }

            int bucketIndex = BitOperations.Log2((uint) minimumLength) - 4;

            if ((uint) bucketIndex < (uint) Buckets.Length)
            {
                ref T[] item = ref Buckets[bucketIndex];

                if (item is not null)
                {
                    T[] loc = item;
                    item = null!;
                    return loc;
                }
            }

            return new T[minimumLength];
        }

        /// <summary>
        ///     Returns the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="clearArray">The clear array</param>
        public override void Return(T[] array, bool clearArray = false)
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                array.AsSpan().Clear();
            }

            int bucketIndex = BitOperations.Log2((uint) array.Length) - 5;
            if ((uint) bucketIndex < (uint) Buckets.Length)
            {
                Buckets[bucketIndex] = array;
            }
        }

        /// <summary>
        ///     Clears the buckets
        /// </summary>
        private void ClearBuckets()
        {
            Buckets.AsSpan().Clear();
        }
    }
}