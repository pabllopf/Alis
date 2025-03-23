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

using System.Buffers;
using Alis.Core.Ecs.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Alis.Benchmark.CustomCollections.ArrayPools
{
    /// <summary>
    /// The array pools benchmark class
    /// </summary>
    [MemoryDiagnoser(false)]
    [ShortRunJob]
    public class ArrayPoolsBenchmark
    {
        /// <summary>
        /// The array pool
        /// </summary>
        private ArrayPool<int> _arrayPool;
        
        /// <summary>
        /// The fast stack array pool
        /// </summary>
        private FastStackArrayPool<int> _fastStackArrayPool;
        
        /// <summary>
        /// The component array pool
        /// </summary>
        private ComponentArrayPool<int> _componentArrayPool;
        
        /// <summary>
        /// Gets or sets the value of the array size
        /// </summary>
        [Params(10, 100, 1000)]
        public int ArraySize { get; set; }
        
        /// <summary>
        /// Globals the setup
        /// </summary>
        [GlobalSetup]
        public void GlobalSetup()
        {
            _arrayPool = ArrayPool<int>.Shared;
            _fastStackArrayPool = new FastStackArrayPool<int>();
            _componentArrayPool = new ComponentArrayPool<int>();
        }
        
        /// <summary>
        /// Creates the array with array pool
        /// </summary>
        [Benchmark(Description = "[ArrayPool .net] Create array with FastStackArrayPool")]
        public void CreateArrayWithArrayPool()
        {
            int[] array = _arrayPool.Rent(ArraySize);
            _arrayPool.Return(array);
        }
        
        /// <summary>
        /// Creates the array new array
        /// </summary>
        [Benchmark(Description = "[Array normal .net] Create array with FastStackArrayPool")]
        public void CreateArrayNewArray()
        {
            int[] array = new int[ArraySize];
        }
        
        /// <summary>
        /// Creates the array with fast stack array pool
        /// </summary>
        [Benchmark(Description = "[FastStackArrayPool] Create array with FastStackArrayPool")]
        public void CreateArrayWithFastStackArrayPool()
        {
            int[] array = _fastStackArrayPool.Rent(ArraySize);
            _fastStackArrayPool.Return(array);
        }
        
        /// <summary>
        /// Creates the array with component array pool
        /// </summary>
        [Benchmark(Description = "[ComponentArrayPool] Create array with FastStackArrayPool")]
        public void CreateArrayWithComponentArrayPool()
        {
            int[] array = _componentArrayPool.Rent(ArraySize);
            _componentArrayPool.Return(array);
        }
    }
}