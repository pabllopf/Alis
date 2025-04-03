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

using Alis.Core.Ecs.Kernel.Collections;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.Stacks
{
    /// <summary>
    /// The native array unsafe vs native array safe class
    /// </summary>
     [MemoryDiagnoser(false), ShortRunJob]
    public class NativeStackVsNativeStackUnsafe
    {
        /// <summary>
        /// The array size
        /// </summary>
        [Params(10)]
        public int ArraySize;
        
        /// <summary>
        /// The fastest stack
        /// </summary>
        private FastStack<int> fastStack;
        
        /// <summary>
        /// The pooled stack
        /// </summary>
        private PooledStack<int> pooledStack;
        
        // Inicialización
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            fastStack = new FastStack<int>(ArraySize);
            pooledStack = new PooledStack<int>(ArraySize);
        }
        
        /// <summary>
        /// Fastests the stack array iterate
        /// </summary>
        [Benchmark(Description = "[FASTEST] Initialize stack")]
        public void Fastest_Stack_ArrayIterate()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                fastStack[i] = i;
            }
        }
        
        /// <summary>
        /// Pooleds the stack array iterate
        /// </summary>
        [Benchmark(Description = "[POOLED] Initialize stack")]
        public void Pooled_Stack_ArrayIterate()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                pooledStack[i] = i;
            }
        }
        
        /// <summary>
        /// Fastests the stack pop
        /// </summary>
        [Benchmark(Description = "[FASTEST] Pop elements")]
        public void Fastest_Stack_Pop()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _ = fastStack.Pop();
            }
        }
        
        /// <summary>
        /// Pooleds the stack pop
        /// </summary>
        [Benchmark(Description = "[POOLED] Pop elements")]
        public void Pooled_Stack_Pop()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _ = pooledStack.Pop();
            }
        }
        
        
        /// <summary>
        /// Fastests the stack push
        /// </summary>
        [Benchmark(Description = "[FASTEST] Push elements")]
        public void Fastest_Stack_Push()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                fastStack.Push(i);
            }
        }
        
        /// <summary>
        /// Pooleds the stack push
        /// </summary>
        [Benchmark(Description = "[POOLED] Push elements")]
        public void Pooled_Stack_Push()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                pooledStack.Push(i);
            }
        }
        
        /// <summary>
        /// Fastests the stack peek
        /// </summary>
        [Benchmark(Description = "[FASTEST] Peek elements")]
        public void Fastest_Stack_Peek()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _ = fastStack.Peek();
            }
        }
        
        /// <summary>
        /// Pooleds the stack peek
        /// </summary>
        [Benchmark(Description = "[POOLED] Peek elements")]
        public void Pooled_Stack_Peek()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                _ = pooledStack.Peek();
            }
        }
        

        
    }
}