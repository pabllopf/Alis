using Alis.Core.Sfml;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alis.Core.Benchmark.src
{
    public class Test_StaticArray_vs_for_span
    {
        [Params(10, 1_000, 100_000)]
        public int arraySize;

        private Component[] components;

        [GlobalSetup]
        public void Setup()
        {
            components = new Component[arraySize];
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = new BoxCollider2D();
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Update_With_For_Span()
        {
            Span<Component> temp = components.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] is not null)
                {
                    temp[i].Update();
                }
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Update_Array_Foreach() => Array.ForEach(components, i => i.Update());
    }
}
