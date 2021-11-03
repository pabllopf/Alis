using System;
using System.Runtime.CompilerServices;
using Alis.Core.Entities;
using Alis.Core.Sfml;
using BenchmarkDotNet.Attributes;

namespace Alis.Core.Benchmark.src
{
    /// <summary>
    /// The test staticarray vs for span class
    /// </summary>
    public class Test_StaticArray_vs_for_span
    {
        /// <summary>
        /// The array size
        /// </summary>
        [Params(10, 1_000, 100_000)] public int arraySize;

        /// <summary>
        /// The components
        /// </summary>
        private Component[] components;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            components = new Component[arraySize];
            for (var i = 0; i < components.Length; i++) components[i] = new BoxCollider2D();
        }

        /// <summary>
        /// Updates the with for span
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Update_With_For_Span()
        {
            var temp = components.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is not null)
                    temp[i].Update();
        }

        /// <summary>
        /// Updates the array foreach
        /// </summary>
        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Update_Array_Foreach()
        {
            Array.ForEach(components, i => i.Update());
        }
    }
}