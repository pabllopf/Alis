using System;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.Fennecs_Components;
using BenchmarkDotNet.Attributes;
using fennecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
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
            public Query<Component1> query;

            /// <summary>
            /// Initializes a new instance of the <see cref="FennecsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public FennecsContext(int entityCount, int entityPadding)
            {
                query = World.Query<Component1>().Build();
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World.Spawn().Add<Component1>();
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
            _fennecs.query.For((ref Component1 comp0) => comp0.Value++);
        }

        /// <summary>
        /// Fennecses the job
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Job()
        {
            _fennecs.query.Job(delegate(ref Component1 v) { v.Value++; }, 1024);
        }
        
        /// <summary>
        /// Fennecses the raw
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs_Raw()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> vectors)
            {
                foreach (ref var v in vectors.Span)
                {
                    v.Value++;
                }
            });
        }
    }
}
