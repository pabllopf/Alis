using Alis.Core.Sfml;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Alis.Core.SFML.Benchmark.src
{
    public class FastArray<T>
    {
        private readonly Memory<T> memory;

        private readonly int length;

        public FastArray(int size)
        {
            memory = new Memory<T>(new T[size]);
            length = memory.Span.Length;
        }

        public FastArray(T[] value)
        {
            memory = new Memory<T>(value);
            length = memory.Span.Length;
        }

        public int Length => length;

        public Span<T> Span => memory.Span;
    }

    public class Test_Update
    {
        [Params(128, 1_024, 102_400)]
        public int numOfElements;

        private List<Sprite> spritesList;

        private Memory<Sprite> spritesMemory;

        private Sprite[] sprites;

        private Span<Sprite> buffer => sprites.AsSpan();

        private FastArray<Sprite> fastArray;

        [GlobalSetup]
        public void SetUp() 
        {
            var temp = new Sprite[numOfElements];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new Sprite(@"C:\\Users\\wwwam\\Documents\\Repos\\Alis\\src\\2_adaptation\\sfml\\alis.core.sfml.example\\assets\\start_button.png");
            }

            spritesList = new List<Sprite>(temp);
            spritesMemory = new Memory<Sprite>(temp);
            sprites = temp;
            fastArray = new FastArray<Sprite>(temp);
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void NormalUpdateList() 
        {
            for (int i = 0; i < spritesList.Count; i++) 
            {
                if (spritesList[i] is not null)
                {
                    _ = spritesList[i].Drawable;
                }                
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void NormalUpdateArray()
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if (sprites[i] is not null)
                {
                    _ = sprites[i].Drawable;
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void MemmoryUpdate() 
        {
            Span<Sprite> temp = spritesMemory.Span;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    _ = temp[i].Drawable;
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Array_span()
        {
            Span<Sprite> buffer = sprites.AsSpan();
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] is not null)
                {
                    _ = buffer[i].Drawable;
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Array_span_base_4()
        {
            for (int i = 0; i < buffer.Length; i += 4)
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
            Span<Sprite> temp = fastArray.Span;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null) 
                {
                    _ = temp[i].Drawable;
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize()
        {
            Span<Sprite> temp = fastArray.Span;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    _ = temp[i].Drawable;
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize_Base_4()
        {
            Span<Sprite> temp = fastArray.Span;
            for (int i = 0; i < temp.Length; i += 4)
            {
                if (temp[i] is not null)
                {
                    _ = temp[i].Drawable;
                }
                if (temp[i + 1] is not null)
                {
                    _ = temp[i + 1].Drawable;
                }
                if (temp[i + 2] is not null)
                {
                    _ = temp[i + 2].Drawable;
                }
                if (temp[i + 3] is not null)
                {
                    _ = temp[i + 3].Drawable;
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Fast_Array_Optimize_Asysnc()
        {
            int process = Environment.ProcessorCount;
            int numPerProcess = fastArray.Span.Length / process;
            List<Task> tasks = new List<Task>();
            
            for (int i =0; i < process; i++) 
            {
                tasks.Add(UpdateDrawAsync(numPerProcess * i, numPerProcess));
            }
            
            Task.WaitAll(tasks.ToArray());
        }

        public Task UpdateDrawAsync(int init, int end)
        {
            return Task.Run(() =>
            {
                Span<Sprite> temp = fastArray.Span.Slice(init, end);
                for (int i = 0; i < temp.Length; i += 4)
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
