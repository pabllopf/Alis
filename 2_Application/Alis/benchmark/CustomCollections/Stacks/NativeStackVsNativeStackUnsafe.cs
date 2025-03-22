// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeArrayUnsafeVsNativeArraySafe.cs
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

using Alis.Core.Ecs.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Alis.Benchmark.CustomCollections.Stacks
{
    /// <summary>
    /// The native array unsafe vs native array safe class
    /// </summary>
     [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class NativeStackVsNativeStackUnsafe
    {
        /// <summary>
        /// The array size
        /// </summary>
        [Params(5)]
        public int ArraySize;

        /// <summary>
        /// The native array unsafe
        /// </summary>
        private NativeStackUnsafe<int> nativeArrayUnsafe;
        
        /// <summary>
        /// The fastest stack
        /// </summary>
        private FastStack<int> fastStack;
        
        // Inicialización
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            nativeArrayUnsafe = new NativeStackUnsafe<int>(ArraySize);
            fastStack = new FastStack<int>(ArraySize);
        }
        
        /// <summary>
        /// Fastests the stack array iterate
        /// </summary>
        [Benchmark(Description = "Benchmark for Fastest Stack Array Iteration")]
        public void Fastest_Stack_ArrayIterate()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                fastStack[i] = i;
            }
        }
        
        /// <summary>
        /// Benchmarks the native array unsafe
        /// </summary>
        [Benchmark(Description = "Benchmark for Native Array Unsafe Iteration")]
        public void Unsafe_code_Stack_ArrayIterate()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                nativeArrayUnsafe[i] = i;
            }
        }
    }
}