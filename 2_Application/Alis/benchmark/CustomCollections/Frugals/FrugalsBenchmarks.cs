// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StacksBenchmarks.cs
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
using Alis.Benchmark.CustomCollections.Frugals.Elements;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.Frugals
{
    /// <summary>
    ///     The native array unsafe vs native array safe class
    /// </summary>
    [ShortRunJob, MemoryDiagnoser, Config(typeof(CustomConfig))]
    public class FrugalsBenchmarks : IDisposable
    {
        /// <summary>
        ///     The array size
        /// </summary>
        [Params(10)] public int ArraySize;
        
        /// <summary>
        ///     The pooled stack
        /// </summary>
        private PooledStack<int> _pooledStack;
        
        /// <summary>
        /// The frugal stack
        /// </summary>
        private FrugalStack<int> _frugalStack;
        
        /// <summary>
        /// The fastest frugal stack
        /// </summary>
        private FastestFrugalStack<int> _fastestFrugalStack;

        // Inicialización
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            _pooledStack = new PooledStack<int>(ArraySize);
            _frugalStack = new FrugalStack<int>(ArraySize);
            _fastestFrugalStack = new FastestFrugalStack<int>(ArraySize);
        }

        /// <summary>
        ///     Pooleds the stack array iterate
        /// </summary>
        [Benchmark(Description = "[PooledStack]_Initialize()")]
        public void Pooled_Stack_ArrayIterate()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _pooledStack[i] = i;
            }
        }
        
        /// <summary>
        /// Frugals the stack array iterate
        /// </summary>
        [Benchmark(Description = "[FrugalStack]_Initialize()")]
        public void Frugal_Stack_ArrayIterate()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _frugalStack[i] = i;
            }
        }
        
        /// <summary>
        /// Fastests the stack array iterate fastest
        /// </summary>
        [Benchmark(Description = "[FastestStack]_Initialize()")]
        public void Fastest_Stack_ArrayIterate_Fastest()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestFrugalStack[i] = i;
            }
        }
        
        /// <summary>
        ///     Pooleds the stack pop
        /// </summary>
        [Benchmark(Description = "[POOLED] Pop elements")]
        public void Pooled_Stack_Pop()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _pooledStack.Push(i);
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _ = _pooledStack.Pop();
            }
        }
        
        /// <summary>
        /// Frugals the stack pop
        /// </summary>
        [Benchmark(Description = "[FRUGAL] Pop elements")]
        public void Frugal_Stack_Pop()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _frugalStack.Push(i);
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _ = _frugalStack.Pop();
            }
        }
        
        /// <summary>
        /// Fastests the stack pop fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST] Pop elements")]
        public void Fastest_Stack_Pop_Fastest()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestFrugalStack.Push(i);
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _ = _fastestFrugalStack.Pop();
            }
        }
        
       /// <summary>
        ///     Pooleds the stack push
        /// </summary>
        [Benchmark(Description = "[POOLED] Push elements")]
        public void Pooled_Stack_Push()
        {
            _pooledStack = new PooledStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _pooledStack.Push(i);
            }
        }
       
       /// <summary>
       /// Frugals the stack push
       /// </summary>
       [Benchmark(Description = "[FRUGAL] Push elements")]
       public void Frugal_Stack_Push()
        {
            _frugalStack = new FrugalStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _frugalStack.Push(i);
            }
        }
        
        /// <summary>
        /// Fastests the stack push fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST] Push elements")]
        public void Fastest_Stack_Push_Fastest()
        {
            _fastestFrugalStack = new FastestFrugalStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestFrugalStack.Push(i);
            }
        }
        
        /// <summary>
        /// Pooleds the stack peek
        /// </summary>
        [Benchmark(Description = "[POOLED]Remove elements")]
        public void Pooled_Stack_Peek()
        {
            _pooledStack = new PooledStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _pooledStack.Push(i); // Inicializa la pila
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _ = _pooledStack.Peek();
            }
        }
        
        /// <summary>
        /// Frugals the stack peek
        /// </summary>
        [Benchmark(Description = "[FRUGAL]Remove elements")]
        public void Frugal_Stack_Peek()
        {
            _frugalStack = new FrugalStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _frugalStack.Push(i); // Inicializa la pila
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _frugalStack.Remove(i);
            }
        }

        /// <summary>
        ///     Fastests the stack peek
        /// </summary>
        [Benchmark(Description = "[FASTEST]Remove elements")]
        public void Fastest_Stack_Peek_Fastest()
        {
            _fastestFrugalStack = new FastestFrugalStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestFrugalStack.Push(i); // Inicializa la pila
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestFrugalStack.Remove(i);
            }
        }
        
        /// <summary>
        /// Pooleds the stack as span
        /// </summary>
        [Benchmark(Description = "[POOLED]ASSPAN")]
        public void Pooled_Stack_AsSpan()
        {
            Span<int> span = _pooledStack.AsSpan();
        }
        
        /// <summary>
        /// Frugals the stack as span
        /// </summary>
        [Benchmark(Description = "[FRUGAL]ASSPAN")]
        public void Frugal_Stack_AsSpan()
        {
            Span<int> span = _frugalStack.AsSpan();
        }
        
        /// <summary>
        /// Fastests the stack as span fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST]ASSPAN")]
        public void Fastest_Stack_AsSpan_Fastest()
        {
            Span<int> span = _fastestFrugalStack.AsSpan();
        }

        public void Dispose()
        {
            _pooledStack?.Dispose();
        }
    }
}