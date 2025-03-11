using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// The leopotam ecs context class
        /// </summary>
        /// <seealso cref="LeopotamEcsBaseContext"/>
        private sealed class LeopotamEcsContext : LeopotamEcsBaseContext
        {
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();

            /// <summary>
            /// The mono thread run system class
            /// </summary>
            /// <seealso cref="IEcsRunSystem"/>
            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                /// <summary>
                /// The filter
                /// </summary>
                private readonly EcsFilter<Component1, Component2> _filter;

                /// <summary>
                /// Runs this instance
                /// </summary>
                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _filter.Get1(i).Value += _filter.Get2(i).Value;
                    }
                }
            }

            /// <summary>
            /// Gets the value of the mono thread system
            /// </summary>
            public EcsSystems MonoThreadSystem { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="LeopotamEcsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public LeopotamEcsContext(int entityCount)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem()).ProcessInjects();

                MonoThreadSystem.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    EcsEntity entity = World
                        .NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 { Value = 1 });

                    switch (i % 4)
                    {
                        case 0:
                            entity.Replace(new Padding1());
                            break;

                        case 1:
                            entity.Replace(new Padding2());
                            break;

                        case 2:
                            entity.Replace(new Padding3());
                            break;

                        case 3:
                            entity.Replace(new Padding4());
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// The leopotam ecs
        /// </summary>
        [Context]
        private readonly LeopotamEcsContext _leopotamEcs;

        /// <summary>
        /// Leopotams the ecs
        /// </summary>
        [BenchmarkCategory(Categories.LeopotamEcs)]
        [Benchmark]
        public void LeopotamEcs() => _leopotamEcs.MonoThreadSystem.Run();
    }
}
