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
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.Arrays
{
    /// <summary>
    ///     Benchmarks native array implementations: <see cref="NativeArray{T}"/>, <see cref="FastestArray{T}"/>, and <see cref="FastArraySafe{T}"/>.
    /// </summary>
    [Config(typeof(CustomConfig))]
    public class NativeArrayUnsafeVsNativeArraySafe : IDisposable
    {
        /// <summary>
        ///     The array size parameter for benchmark iterations.
        /// </summary>
        [Params(2)] public int ArraySize;

        /// <summary>
        ///     The safe managed array wrapper.
        /// </summary>
        private FastArraySafe<int> fastArraySafe;

        /// <summary>
        ///     The array pool-backed array wrapper.
        /// </summary>
        private FastestArray<int> fastestArray;

        /// <summary>
        ///     The native unmanaged memory array wrapper.
        /// </summary>
        private NativeArray<int> nativeArray;

        /// <summary>
        ///     Releases all allocated resources from the array wrappers.
        /// </summary>
        public void Dispose()
        {
            fastArraySafe.Dispose();
            nativeArray?.Dispose();
        }

        /// <summary>
        ///     Initializes all array wrappers with the benchmark array size.
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            nativeArray = new NativeArray<int>(ArraySize);
            fastestArray = new FastestArray<int>(ArraySize);
            fastArraySafe = new FastArraySafe<int>(ArraySize);
        }

        /// <summary>
        ///     Disposes all array wrappers to release resources.
        /// </summary>
        [GlobalCleanup]
        public void Cleanup()
        {
            nativeArray.Dispose();
            fastestArray.Dispose();
            fastArraySafe.Dispose();
        }

        /// <summary>
        ///     Benchmarks the native array
        /// </summary>
        [Benchmark(Description = "[SAFE] Iteration over NativeArray")]
        public void BenchmarkNativeArray()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                nativeArray[i] = i;
            }
        }

        /// <summary>
        ///     Benchmarks the fastest array
        /// </summary>
        [Benchmark(Description = "[FASTEST] Iteration over FastestArray")]
        public void BenchmarkFastestArray()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                fastestArray[i] = i;
            }
        }
        
        /// <summary>
        ///     Benchmarks sequential write iteration over <see cref="FastArraySafe{T}"/>.
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] Iteration over FastArraySafe")]
        public void BenchmarkFastArraySafe()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                fastArraySafe[i] = i;
            }
        }


        /// <summary>
        ///     Benchmarks the resize native array
        /// </summary>
        [Benchmark(Description = "[SAFE] Resize NativeArray")]
        public void BenchmarkResizeNativeArray()
        {
            nativeArray.Resize(ArraySize * 2);
        }

        /// <summary>
        ///     Benchmarks the resize fastest array
        /// </summary>
        [Benchmark(Description = "[FASTEST] Resize FastestArray")]
        public void BenchmarkResizeFastestArray()
        {
            fastestArray.Resize(ArraySize * 2);
        }

      

        /// <summary>
        ///     Benchmarks resizing <see cref="FastArraySafe{T}"/> to double the array size.
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] Resize FastArraySafe")]
        public void BenchmarkResizeFastArraySafe()
        {
            fastArraySafe.Resize(ArraySize * 2);
        }


        /// <summary>
        ///     Benchmarks the native array assignment
        /// </summary>
        [Benchmark(Description = "[SAFE] Assignment NativeArray")]
        public void BenchmarkNativeArray_Assignment()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                nativeArray[i] = i;
            }
        }

        /// <summary>
        ///     Benchmarks the fastest array assignment
        /// </summary>
        [Benchmark(Description = "[FASTEST] Assignment FastestArray")]
        public void BenchmarkFastestArray_Assignment()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                fastestArray[i] = i;
            }
        }




        /// <summary>
        ///     Benchmarks element assignment over <see cref="FastArraySafe{T}"/>.
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] Assignment FastArraySafe")]
        public void BenchmarkFastArraySafe_Assignment()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                fastArraySafe[i] = i;
            }
        }


        /// <summary>
        ///     Benchmarks the native array sequential access
        /// </summary>
        [Benchmark(Description = "[SAFE] Sequential Access NativeArray")]
        public void BenchmarkNativeArray_SequentialAccess()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeArray[i];
            }
        }

        /// <summary>
        ///     Benchmarks the fastest array sequential access
        /// </summary>
        [Benchmark(Description = "[FASTEST] Sequential Access FastestArray")]
        public void BenchmarkFastestArray_SequentialAccess()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastestArray[i];
            }
        }

        /// <summary>
        ///     Benchmarks sequential read access over <see cref="FastArraySafe{T}"/>.
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] Sequential Access FastArraySafe")]
        public void BenchmarkFastArraySafe_SequentialAccess()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastArraySafe[i];
            }
        }


        /// <summary>
        ///     Benchmarks the native array random access
        /// </summary>
        [Benchmark(Description = "[SAFE] Random Access NativeArray")]
        public void BenchmarkNativeArray_RandomAccess()
        {
            Random random = new Random();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeArray[random.Next(0, ArraySize)];
            }
        }

        /// <summary>
        ///     Benchmarks the fastest array random access
        /// </summary>
        [Benchmark(Description = "[FASTEST] Random Access FastestArray")]
        public void BenchmarkFastestArray_RandomAccess()
        {
            Random random = new Random();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastestArray[random.Next(0, ArraySize)];
            }
        }

    

        /// <summary>
        ///     Benchmarks random read access over <see cref="FastArraySafe{T}"/>.
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] Random Access FastArraySafe")]
        public void BenchmarkFastArraySafe_RandomAccess()
        {
            Random random = new Random();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastArraySafe[random.Next(0, ArraySize)];
            }
        }


        /// <summary>
        ///     Benchmarks the dispose native array
        /// </summary>
        [Benchmark(Description = "[SAFE] Dispose NativeArray")]
        public void BenchmarkDisposeNativeArray()
        {
            nativeArray.Dispose();
        }

        /// <summary>
        ///     Benchmarks the dispose fastest array
        /// </summary>
        [Benchmark(Description = "[FASTEST] Dispose FastestArray")]
        public void BenchmarkDisposeFastestArray()
        {
            fastestArray.Dispose();
        }

   

        /// <summary>
        ///     Benchmarks disposal of <see cref="FastArraySafe{T}"/>.
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] Dispose FastArraySafe")]
        public void BenchmarkDisposeFastArraySafe()
        {
            fastArraySafe.Dispose();
        }


        /// <summary>
        ///     Benchmarks the native array as span
        /// </summary>
        [Benchmark(Description = "[SAFE] AsSpan NativeArray")]
        public void BenchmarkNativeArray_AsSpan()
        {
            Span<int> span = nativeArray.AsSpan();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = span[i];
            }
        }

        /// <summary>
        ///     Benchmarks the fastest array as span
        /// </summary>
        [Benchmark(Description = "[FASTEST] AsSpan FastestArray")]
        public void BenchmarkFastestArray_AsSpan()
        {
            Span<int> span = fastestArray.AsSpan();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = span[i];
            }
        }

        /// <summary>
        ///     Benchmarks the fast array safe as span
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] AsSpan FastArraySafe")]
        public void BenchmarkFastArraySafe_AsSpan()
        {
            Span<int> span = fastArraySafe.AsSpan();
            for (int i = 0; i < ArraySize; i++)
            {
                int value = span[i];
            }
        }


        /// <summary>
        ///     Benchmarks the native array as span len
        /// </summary>
        [Benchmark(Description = "[SAFE] AsSpanLen NativeArray")]
        public void BenchmarkNativeArray_AsSpanLen()
        {
            Span<int> span = nativeArray.AsSpanLen(ArraySize / 2);
            for (int i = 0; i < ArraySize / 2; i++)
            {
                int value = span[i];
            }
        }

        /// <summary>
        ///     Benchmarks the fastest array as span len
        /// </summary>
        [Benchmark(Description = "[FASTEST] AsSpanLen FastestArray")]
        public void BenchmarkFastestArray_AsSpanLen()
        {
            Span<int> span = fastestArray.AsSpanLen(ArraySize / 2);
            for (int i = 0; i < ArraySize / 2; i++)
            {
                int value = span[i];
            }
        }

        /// <summary>
        ///     Benchmarks the fast array safe as span len
        /// </summary>
        [Benchmark(Description = "[FASTEST SAFE] AsSpanLen FastArraySafe")]
        public void BenchmarkFastArraySafe_AsSpanLen()
        {
            Span<int> span = fastArraySafe.AsSpanLen(ArraySize / 2);
            for (int i = 0; i < ArraySize / 2; i++)
            {
                int value = span[i];
            }
        }
    }
}