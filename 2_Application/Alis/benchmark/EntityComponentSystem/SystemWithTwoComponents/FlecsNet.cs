using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Arch_Components;
using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    /// The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
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
                        Entity padding = World.Entity();
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

                    World.Entity().Add<Component1>()
                        .Set(new Component2
                        {
                            Value = 1
                        });
                }
                query = World.QueryBuilder().With<Component1>().With<Component2>().Build();
            }
        }

        /// <summary>
        /// Flecses the net each
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet_Each()
        {
            _flecs.query.Each((ref Component1 c1, ref Component2 c2) =>
            {
                c1.Value += c2.Value;
            });
        }

        /// <summary>
        /// Flecses the net iter
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet_Iter()
        {
            _flecs.query.Iter((Iter it, Column<Component1> c1, Column<Component2> c2) =>
            {
                foreach (int i in it)
                {
                    c1[i].Value += c2[i].Value;
                }
            });
        }
    }
}
