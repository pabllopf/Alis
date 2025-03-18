using System;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Fennecs_Components;
using BenchmarkDotNet.Attributes;
using fennecs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    /// The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
    {
        /// <summary>
        /// The fennecs
        /// </summary>
        [Context] private readonly FennecsContext _fennecs;

        /// <summary>
        /// The fennecs context class
        /// </summary>
        /// <seealso cref="FennecsBaseContext"/>
        private sealed class FennecsContext : FennecsBaseContext
        {
            /// <summary>
            /// The query
            /// </summary>
            public Query<Component1, Component2> query;

            /// <summary>
            /// Initializes a new instance of the <see cref="FennecsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public FennecsContext(int entityCount, int entityPadding)
            {
                query = World.Query<Component1, Component2>().Build();
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.Spawn();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Add<Component1>();
                                break;

                            case 1:
                                padding.Add<Component2>();
                                break;
                        }
                    }

                    World.Spawn().Add<Component1>().Add(new Component2 { Value = 1 });
                }
            }
        }

        /// <summary>
        /// Fennecses the for each
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_ForEach()
        {
            _fennecs.query.For((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        /// <summary>
        /// Fennecses the job
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Job()
        {
            _fennecs.query.Job(delegate(ref Component1 c1, ref Component2 c2) { c1.Value += c2.Value; }, 1024);
        }

        /// <summary>
        /// Fennecses the raw
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Raw()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> c1v, Memory<Component2> c2v)
            {
                Span<Component1> c1vs = c1v.Span;
                Span<Component2> c2vs = c2v.Span;
                for (int i = 0; i < c1vs.Length; ++i)
                {
                    ref Component1 c1 = ref c1vs[i];
                    c1.Value += c2vs[i].Value;
                }
            });
        }
    }
}
