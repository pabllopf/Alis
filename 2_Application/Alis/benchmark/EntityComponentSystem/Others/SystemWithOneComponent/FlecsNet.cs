using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.Arch_Components;
using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The flecs
        /// </summary>
        [Context]
        private readonly FlecsContext _flecs;

        /// <summary>
        /// The flecs context class
        /// </summary>
        /// <seealso cref="FlecsNetBaseContext"/>
        private sealed class FlecsContext : FlecsNetBaseContext
        {
            /// <summary>
            /// The query
            /// </summary>
            public Query query;

            /// <summary>
            /// Initializes a new instance of the <see cref="FlecsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public FlecsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Entity();
                    }

                    World.Entity().Add<Component1>();

                }
                query = World.QueryBuilder().With<Component1>().Build();
            }
        }

        /// <summary>
        /// Flecses the net each
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet_Each()
        {
            _flecs.query.Each((ref Component1 c1) =>
            {
                c1.Value += 1;
            });
        }

        /// <summary>
        /// Flecses the net iter
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet_Iter()
        {
            _flecs.query.Iter((Iter it, Column<Component1> c1) =>
            {
                foreach (int i in it)
                {
                    c1[i].Value += 1;
                }
            });
        }
    }
}
