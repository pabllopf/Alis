using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Alis.Core.Sfml.Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Core.SFML.Benchmark.src
{
    public class FastArray<T>
    {
        private readonly Memory<T> memory;

        public FastArray(int size)
        {
            memory = new Memory<T>(new T[size]);
            Length = memory.Span.Length;
        }

        public FastArray(T[] value)
        {
            memory = new Memory<T>(value);
            Length = memory.Span.Length;
        }

        public int Length { get; }

        public Span<T> Span => memory.Span;
    }

    public class Test_Update
    {
        private FastArray<Sprite> fastArray;

        [Params(128, 1_024, 102_400)] public int numOfElements;

        private Sprite[] sprites;

        private List<Sprite> spritesList;

        private Memory<Sprite> spritesMemory;

        private Span<Sprite> buffer => sprites.AsSpan();

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

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void NormalUpdateList()
        {
            for (var i = 0; i < spritesList.Count; i++)
                if (spritesList[i] is not null)
                    _ = spritesList[i].Drawable;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void NormalUpdateArray()
        {
            for (var i = 0; i < sprites.Length; i++)
                if (sprites[i] is not null)
                    _ = sprites[i].Drawable;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void MemmoryUpdate()
        {
            var temp = spritesMemory.Span;
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    _ = temp[i].Drawable;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Array_span()
        {
            var buffer = sprites.AsSpan();
            for (var i = 0; i < buffer.Length; i++)
                if (buffer[i] is not null)
                    _ = buffer[i].Drawable;
        }

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

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array()
        {
            var temp = fastArray.Span;
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    _ = temp[i].Drawable;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize()
        {
            var temp = fastArray.Span;
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    _ = temp[i].Drawable;
        }

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