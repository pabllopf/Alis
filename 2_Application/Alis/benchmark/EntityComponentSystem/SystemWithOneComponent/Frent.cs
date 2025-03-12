using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Systems;
using static Alis.Benchmark.EntityComponentSystem.Contexts.FrentBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The frent
        /// </summary>
        [Context]
        private readonly FrentContext _frent;

        /// <summary>
        /// The frent context class
        /// </summary>
        /// <seealso cref="FrentBaseContext"/>
        private sealed class FrentContext : FrentBaseContext
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FrentContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public FrentContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    World.Create<Component1>(default);
                    for (int j = 0; j < entityPadding; j++)
                    {
                        World.Create();
                    }
                }

                Query = World.Query<With<Component1>>();
            }

            /// <summary>
            /// The query
            /// </summary>
            public Query Query;
        }

        /// <summary>
        /// The increment
        /// </summary>
        internal struct Increment : IAction<FrentBaseContext.Component1>
        {
            /// <summary>
            /// Runs the t 0
            /// </summary>
            /// <param name="t0">The </param>
            public void Run(ref Component1 t0)
            {
                t0.Value++;
            }
        }

        /// <summary>
        /// Frents the query inline
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryInline()
        {
            _frent.Query.Inline<Increment, Component1>(default);
        }

        /// <summary>
        /// Frents the query delegate
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryDelegate()
        {
            _frent.Query.Delegate((ref Component1 c) => c.Value++);
        }

        /// <summary>
        /// Frents the simd
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Simd()
        {
            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in _frent.Query.EnumerateChunks<Component1>())
            {
                int len = chunk.Span.Length - (chunk.Span.Length & 7);
                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(chunk.Span.Slice(0, len));
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] += sum;
                }

                for (int i = len; i < chunk.Span.Length; i++)
                {
                    chunk.Span[i].Value++;
                }
            }
        }
    }
}
