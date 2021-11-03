// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Test_Update.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Alis.Core.Sfml.Components;
using BenchmarkDotNet.Attributes;

#endregion

namespace Alis.Core.SFML.Benchmark.src
{
    /// <summary>
    ///     The fast array class
    /// </summary>
    public class FastArray<T>
    {
        /// <summary>
        ///     The memory
        /// </summary>
        private readonly Memory<T> memory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastArray" /> class
        /// </summary>
        /// <param name="size">The size</param>
        public FastArray(int size)
        {
            memory = new Memory<T>(new T[size]);
            Length = memory.Span.Length;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FastArray" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public FastArray(T[] value)
        {
            memory = new Memory<T>(value);
            Length = memory.Span.Length;
        }

        /// <summary>
        ///     Gets the value of the length
        /// </summary>
        public int Length { get; }

        /// <summary>
        ///     Gets the value of the span
        /// </summary>
        public Span<T> Span => memory.Span;
    }

    /// <summary>
    ///     The test update class
    /// </summary>
    public class Test_Update
    {
        /// <summary>
        ///     The fast array
        /// </summary>
        private FastArray<Sprite> fastArray;

        /// <summary>
        ///     The num of elements
        /// </summary>
        [Params(128, 1_024, 102_400)] public int numOfElements;

        /// <summary>
        ///     The sprites
        /// </summary>
        private Sprite[] sprites;

        /// <summary>
        ///     The sprites list
        /// </summary>
        private List<Sprite> spritesList;

        /// <summary>
        ///     The sprites memory
        /// </summary>
        private Memory<Sprite> spritesMemory;

        /// <summary>
        ///     Gets the value of the buffer
        /// </summary>
        private Span<Sprite> buffer => sprites.AsSpan();

        /// <summary>
        ///     Sets the up
        /// </summary>
        [GlobalSetup]
        public void SetUp()
        {
            var temp = new Sprite[numOfElements];
            for (var i = 0; i < temp.Length; i++)
                temp[i] = new Sprite(
                    @"C:\\Users\\wwwam\\Documents\\Repos\\Alis\\src\\2_adaptation\\sfml\\alis.core.sfml.example\\assets\\start_button.png");

            spritesList = new List<Sprite>(temp);
            spritesMemory = new Memory<Sprite>(temp);
            sprites = temp;
            fastArray = new FastArray<Sprite>(temp);
        }

        /// <summary>
        ///     Normals the update list
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void NormalUpdateList()
        {
            for (var i = 0; i < spritesList.Count; i++)
                if (spritesList[i] is not null)
                    _ = spritesList[i].Drawable;
        }

        /// <summary>
        ///     Normals the update array
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void NormalUpdateArray()
        {
            for (var i = 0; i < sprites.Length; i++)
                if (sprites[i] is not null)
                    _ = sprites[i].Drawable;
        }

        /// <summary>
        ///     Memmories the update
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void MemmoryUpdate()
        {
            var temp = spritesMemory.Span;
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    _ = temp[i].Drawable;
        }

        /// <summary>
        ///     Arrays the span
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Array_span()
        {
            var buffer = sprites.AsSpan();
            for (var i = 0; i < buffer.Length; i++)
                if (buffer[i] is not null)
                    _ = buffer[i].Drawable;
        }

        /// <summary>
        ///     Arrays the span base 4
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Array_span_base_4()
        {
            for (var i = 0; i < buffer.Length; i += 4)
            {
                _ = buffer[i]?.Drawable;
                _ = buffer[i + 1]?.Drawable;
                _ = buffer[i + 2]?.Drawable;
                _ = buffer[i + 3]?.Drawable;
            }
        }

        /// <summary>
        ///     Fasts the array
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array()
        {
            var temp = fastArray.Span;
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    _ = temp[i].Drawable;
        }

        /// <summary>
        ///     Fasts the array optimize
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize()
        {
            var temp = fastArray.Span;
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    _ = temp[i].Drawable;
        }

        /// <summary>
        ///     Fasts the array optimize base 4
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize_Base_4()
        {
            var temp = fastArray.Span;
            for (var i = 0; i < temp.Length; i += 4)
            {
                if (temp[i] is not null) _ = temp[i].Drawable;
                if (temp[i + 1] is not null) _ = temp[i + 1].Drawable;
                if (temp[i + 2] is not null) _ = temp[i + 2].Drawable;
                if (temp[i + 3] is not null) _ = temp[i + 3].Drawable;
            }
        }

        /// <summary>
        ///     Fasts the array optimize asysnc
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize_Asysnc()
        {
            var process = Environment.ProcessorCount;
            var numPerProcess = fastArray.Span.Length / process;
            var tasks = new List<Task>();

            for (var i = 0; i < process; i++) tasks.Add(UpdateDrawAsync(numPerProcess * i, numPerProcess));

            Task.WaitAll(tasks.ToArray());
        }

        /// <summary>
        ///     Updates the draw using the specified init
        /// </summary>
        /// <param name="init">The init</param>
        /// <param name="end">The end</param>
        public Task UpdateDrawAsync(int init, int end)
        {
            return Task.Run(() =>
            {
                var temp = fastArray.Span.Slice(init, end);
                for (var i = 0; i < temp.Length; i += 4)
                {
                    _ = buffer[i]?.Drawable;
                    _ = buffer[i + 1]?.Drawable;
                    _ = buffer[i + 2]?.Drawable;
                    _ = buffer[i + 3]?.Drawable;
                }
            });
        }

        /*
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize_Async()
        {
            Task.WaitAll(
                UpdateDrawAsync(0, 256),
                UpdateDrawAsync(256, 512),
                UpdateDrawAsync(512, 768),
                UpdateDrawAsync(768, 1024));   
        }

        public async Task UpdateDrawAsync(int init, int end) 
        {
            await Task.Run(()=> 
            {
                Span<Sprite> temp = fastArray.Span.Slice(init, end);
                for (int i = 0; i < temp.Length; i++) 
                {
                    if (temp[i] is not null)
                    {
                        _ = temp[i].Drawable;
                    }
                }
            });
        }*/
    }
}