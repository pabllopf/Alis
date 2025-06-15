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
using Alis.Benchmark.CustomCollections.Stacks.Elements;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.Stacks
{
    /// <summary>
    ///     The native array unsafe vs native array safe class
    /// </summary>
    [ShortRunJob, MemoryDiagnoser, Config(typeof(CustomConfig))]
    public class StacksBenchmarks : IDisposable
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
        /// The fastest stack
        /// </summary>
        private FastestStack<int> _fastestStack;

        // Inicialización
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            _pooledStack = new PooledStack<int>(ArraySize);
            _fastestStack = new FastestStack<int>(ArraySize);
        }

        /// <summary>
        ///     Pooleds the stack array iterate
        /// </summary>
        [Benchmark(Description = "[PooledStackWithIndex]_Initialize()")]
        public void Pooled_Stack_ArrayIterate()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _pooledStack[i] = i;
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
                _fastestStack[i] = i;
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
        /// Fastests the stack pop fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST] Pop elements")]
        public void Fastest_Stack_Pop_Fastest()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestStack.Push(i);
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _ = _fastestStack.Pop();
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
        /// Fastests the stack push fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST] Push elements")]
        public void Fastest_Stack_Push_Fastest()
        {
            _fastestStack = new FastestStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestStack.Push(i);
            }
        }

      /// <summary>
        ///     Pooleds the stack peek
        /// </summary>
        [Benchmark(Description = "[POOLED] Peek elements")]
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
        ///     Fastests the stack peek
        /// </summary>
        [Benchmark(Description = "[FASTEST] Peek elements")]
        public void Fastest_Stack_Peek_Fastest()
        {
            _fastestStack = new FastestStack<int>(ArraySize); // Reinicia la pila
            for (int i = 0; i < ArraySize; i++)
            {
                _fastestStack.Push(i); // Inicializa la pila
            }
        
            for (int i = 0; i < ArraySize; i++)
            {
                _ = _fastestStack.Peek();
            }
        }

        public void Dispose()
        {
            _pooledStack?.Dispose();
            _fastestStack.Dispose();
        }
    }
}