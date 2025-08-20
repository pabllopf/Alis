// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArrayPoolsBenchmark.cs
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
using Alis.Benchmark.CustomCollections.ArrayPools.Elements;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Collections;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.ArrayPools
{
    /// <summary>
    ///     The array pools benchmark class
    /// </summary>
    [ShortRunJob, MemoryDiagnoser, Config(typeof(CustomConfig))]
    public class ArrayPoolsBenchmark
    {
        /// <summary>
        ///     The array pool
        /// </summary>
        private ArrayPool<int> _arrayPool;

        /// <summary>
        ///     The component array pool
        /// </summary>
        private ComponentArrayPool<int> _componentArrayPool;

        /// <summary>
        ///     The fast stack array pool
        /// </summary>
        private FastArrayPool<int> _fastArrayPool;
        
        /// <summary>
        /// The fastest array pool
        /// </summary>
        private FastestArrayPool<int> _fastestArrayPool;

        /// <summary>
        ///     Gets or sets the value of the array size
        /// </summary>
        [Params(16)]
        public int ArraySize { get; set; }

        /// <summary>
        ///     Globals the setup
        /// </summary>
        [GlobalSetup]
        public void GlobalSetup()
        {
            _arrayPool = ArrayPool<int>.Shared;
            _fastArrayPool = new FastArrayPool<int>();
            _componentArrayPool = new ComponentArrayPool<int>();
            _fastestArrayPool = new FastestArrayPool<int>();
        }
        
        /// <summary>
        ///     Creates the array with array pool
        /// </summary>
        [Benchmark(Description = "[ArrayPool]_Create()")]
        public void CreateArrayWithArrayPool()
        {
            int[] array = _arrayPool.Rent(ArraySize);
            _arrayPool.Return(array);
        }

        /// <summary>
        ///     Creates the array with fast stack array pool
        /// </summary>
        [Benchmark(Description = "[FastArrayPool]_Create()")]
        public void CreateArrayWithFastStackArrayPool()
        {
            int[] array = _fastArrayPool.Rent(ArraySize);
            _fastArrayPool.Return(array);
        }

        /// <summary>
        ///     Creates the array with component array pool
        /// </summary>
        [Benchmark(Description = "[ComponentArrayPool]_Create()")]
        public void CreateArrayWithComponentArrayPool()
        {
            int[] array = _componentArrayPool.Rent(ArraySize);
            _componentArrayPool.Return(array);
        }
        
        /// <summary>
        /// Creates the array with fastest array pool
        /// </summary>
        [Benchmark(Description = "[FastestArrayPool]_Create()")]
        public void CreateArrayWithFastestArrayPool()
        {
            int[] array = _fastestArrayPool.Rent(ArraySize);
            _fastestArrayPool.Return(array);
        }
        
            
        /// <summary>
        /// Resizes the array from pool with array pool custom
        /// </summary>
        [Benchmark(Description = "[ArrayPool]_ResizeArrayFromPoolWithArrayPool()")]
        public void ResizeArrayFromPoolWithArrayPool_custom()
        {
            int[] array = new int[ArraySize];
            ResizeArrayFromPoolWithArrayPool(ref array, ArraySize);
        }

        /// <summary>
        /// Resizes the array from pool with array pool using the specified arr
        /// </summary>
        /// <param name="arr">The arr</param>
        /// <param name="len">The len</param>
        private void ResizeArrayFromPoolWithArrayPool(ref int[] arr, int len)
        {
            int[] array = ArrayPool<int>.Shared.Rent(len);
            try
            {
                // Redimensionar el arreglo
                int[] resizedArray = ArrayPool<int>.Shared.Rent(len * 2);
                arr.AsSpan(0, arr.Length).CopyTo(resizedArray);
                ArrayPool<int>.Shared.Return(arr);
                arr = resizedArray;
            }
            finally
            {
                // Asegurarse de devolver el arreglo al pool
                ArrayPool<int>.Shared.Return(arr);
            }
        }
        
        /// <summary>
        /// Resizes the array from pool with fast stack array pool
        /// </summary>
        [Benchmark(Description = "[FastArrayPool]_ResizeArrayFromPoolWithArrayPool()")]
        public void ResizeArrayFromPoolWithFastStackArrayPool()
        {
            int[] array = new int[ArraySize];
            FastArrayPool<int>.ResizeArrayFromPool(ref array, ArraySize);
            FastArrayPool<int>.Instance.Return(array);
        }
        
        /// <summary>
        /// Resizes the array from pool with component array pool
        /// </summary>
        [Benchmark(Description = "[ComponentArrayPool]_ResizeArrayFromPoolWithArrayPool()")]
        public void ResizeArrayFromPoolWithComponentArrayPool()
        {
            int[] array = new int[ArraySize];
            ComponentArrayPool<int>.ResizeArrayFromPool(ref array, ArraySize);
            ComponentArrayPool<int>.Instance.Return(array);
        }

        /// <summary>
        /// Resizes the array from pool with fastest array pool
        /// </summary>
        [Benchmark(Description = "[FastestArrayPool]_ResizeArrayFromPoolWithArrayPool()")]
        public void ResizeArrayFromPoolWithFastestArrayPool()
        {
            int[] array = new int[ArraySize];
            FastestArrayPool<int>.ResizeArrayFromPool(ref array, ArraySize);
            FastestArrayPool<int>.Instance.Return(array);
        }
    }
}