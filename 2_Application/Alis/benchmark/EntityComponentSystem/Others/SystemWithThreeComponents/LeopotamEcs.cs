using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithThreeComponents
{
    /// <summary>
    /// The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
    {
        /// <summary>
        /// The leopotam ecs context class
        /// </summary>
        /// <seealso cref="LeopotamEcsBaseContext"/>
        private sealed class LeopotamEcsContext : LeopotamEcsBaseContext
        {
            /// <summary>
            /// The mono thread run system class
            /// </summary>
            /// <seealso cref="IEcsRunSystem"/>
            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                /// <summary>
                /// The filter
                /// </summary>
                private readonly EcsFilter<Component1, Component2, Component3> _filter;

                /// <summary>
                /// Runs this instance
                /// </summary>
                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _filter.Get1(i).Value += _filter.Get2(i).Value + _filter.Get3(i).Value;
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
            /// <param name="entityPadding">The entity padding</param>
            public LeopotamEcsContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem()).ProcessInjects();

                MonoThreadSystem.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        EcsEntity padding = World.NewEntity();
                        switch (j % 3)
                        {
                            case 0:
                                padding.Replace(new Component1());
                                break;

                            case 1:
                                padding.Replace(new Component2());
                                break;

                            case 2:
                                padding.Replace(new Component3());
                                break;
                        }
                    }

                    World.NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 { Value = 1 })
                        .Replace(new Component3 { Value = 1 });
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
