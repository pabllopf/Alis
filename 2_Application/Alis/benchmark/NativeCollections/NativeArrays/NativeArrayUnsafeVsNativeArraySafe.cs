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

using System;
using Alis.Core.Ecs.Collections;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.NativeCollections.NativeArrays
{
    /// <summary>
    /// The native array unsafe vs native array safe class
    /// </summary>
    [MemoryDiagnoser]
    public class NativeArrayUnsafeVsNativeArraySafe
    {
        /// <summary>
        /// The array size
        /// </summary>
        [Params(5)]
        public int ArraySize;

        /// <summary>
        /// The native array unsafe
        /// </summary>
        private NativeArrayUnsafe<int> nativeArrayUnsafe;

        /// <summary>
        /// The native array
        /// </summary>
        private NativeArray<int> nativeArray;

        // Inicialización
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            nativeArrayUnsafe = new NativeArrayUnsafe<int>(ArraySize);
            nativeArray = new NativeArray<int>(ArraySize);
        }

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        [GlobalCleanup]
        public void Cleanup()
        {
            nativeArrayUnsafe.Dispose();
            nativeArray.Dispose();
        }

        /// <summary>
        /// Benchmarks the native array unsafe
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArrayUnsafe()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                nativeArrayUnsafe[i] = i;
            }
        }

        /// <summary>
        /// Benchmarks the native array
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArray()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                nativeArray[i] = i;
            }
        }

        /// <summary>
        /// Benchmarks the resize native array unsafe
        /// </summary>
        [Benchmark]
        
        public void BenchmarkResizeNativeArrayUnsafe()
        {
            nativeArrayUnsafe.Resize(ArraySize * 2);
        }

        /// <summary>
        /// Benchmarks the resize native array
        /// </summary>
        [Benchmark]
        
        public void BenchmarkResizeNativeArray()
        {
            nativeArray.Resize(ArraySize * 2);
        }


        /// <summary>
        /// Benchmarks the native array unsafe assignment
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArrayUnsafe_Assignment()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                nativeArrayUnsafe[i] = i;
            }
        }

        /// <summary>
        /// Benchmarks the native array assignment
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArray_Assignment()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                nativeArray[i] = i;
            }
        }

        /// <summary>
        /// Benchmarks the native array unsafe sequential access
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArrayUnsafe_SequentialAccess()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeArrayUnsafe[i];
            }
        }

        /// <summary>
        /// Benchmarks the native array sequential access
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArray_SequentialAccess()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeArray[i];
            }
        }

        /// <summary>
        /// Benchmarks the native array unsafe random access
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArrayUnsafe_RandomAccess()
        {
            Random random = new Random();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeArrayUnsafe[random.Next(0, ArraySize)];
            }
        }

        /// <summary>
        /// Benchmarks the native array random access
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArray_RandomAccess()
        {
            Random random = new Random();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeArray[random.Next(0, ArraySize)];
            }
        }

        /// <summary>
        /// Benchmarks the dispose native array unsafe
        /// </summary>
        [Benchmark]
        
        public void BenchmarkDisposeNativeArrayUnsafe()
        {
            nativeArrayUnsafe.Dispose();
        }

        /// <summary>
        /// Benchmarks the dispose native array
        /// </summary>
        [Benchmark]
        
        public void BenchmarkDisposeNativeArray()
        {
            nativeArray.Dispose();
        }

        /// <summary>
        /// Benchmarks the native array unsafe as span
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArrayUnsafe_AsSpan()
        {
            Span<int> span = nativeArrayUnsafe.AsSpan();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = span[i];
            }
        }

        /// <summary>
        /// Benchmarks the native array as span
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArray_AsSpan()
        {
            Span<int> span = nativeArray.AsSpan();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = span[i];
            }
        }
        
        /// <summary>
        /// Benchmarks the native array unsafe as span len
        /// </summary>
        [Benchmark]
        
        public void BenchmarkNativeArrayUnsafe_AsSpanLen()
        {
            Span<int> span = nativeArrayUnsafe.AsSpanLen(ArraySize / 2);
            for (int i = 0; i < ArraySize / 2; i++)
            {
                int value = span[i];
            }
        }

        /// <summary>
        /// Benchmarks the native array as span len
        /// </summary>
        [Benchmark]
        public void BenchmarkNativeArray_AsSpanLen()
        {
            Span<int> span = nativeArray.AsSpanLen(ArraySize / 2);
            for (int i = 0; i < ArraySize / 2; i++)
            {
                int value = span[i];
            }
        }
    }
}