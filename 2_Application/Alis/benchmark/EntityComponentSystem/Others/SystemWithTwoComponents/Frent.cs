using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Systems;
using static Alis.Benchmark.EntityComponentSystem.Others.Contexts.FrentBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithTwoComponents
{
    /// <summary>
    /// The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
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
        internal sealed class FrentContext : FrentBaseContext
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FrentContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="padding">The padding</param>
            public FrentContext(int entityCount, int padding)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    World.Create<Component1, Component2>(default, new() { Value = 1 });
                    for (int j = 0; j < padding; j++)
                    {
                        World.Create();
                    }
                }

                Query = World.Query<With<Component1>, With<Component2>>();
            }

            /// <summary>
            /// The query
            /// </summary>
            public Query Query;
        }

        /// <summary>
        /// The sum
        /// </summary>
        internal struct Sum : IAction<FrentBaseContext.Component1, FrentBaseContext.Component2>
        {
            /// <summary>
            /// Runs the t 0
            /// </summary>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            public void Run(ref Component1 t0, ref Component2 t1)
            {
                t0.Value += t1.Value;
            }
        }

        /// <summary>
        /// Frents the query inline
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryInline()
        {
            _frent.Query.Inline<Sum, Component1, Component2>(default);
        }

        /// <summary>
        /// Frents the query delegate
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_QueryDelegate()
        {
            _frent.Query.Delegate((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        /// <summary>
        /// Frents the simd
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Simd()
        {
            foreach ((var s1, var s2) in _frent.Query.EnumerateChunks<Component1, Component2>())
            {
                int len = s1.Length - (s1.Length & 7);

                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(s1.Slice(0, len));
                Span<Vector256<int>> a = MemoryMarshal.Cast<Component2, Vector256<int>>(s2.Slice(0, len))[..ints.Length];

                for (int i = 0; i < ints.Length; i++)
                    ints[i] += a[i];

                for (int i = len; i < s1.Length; i++)
                    s1[i].Value += s2[i].Value;
            }
        }
    }
}
