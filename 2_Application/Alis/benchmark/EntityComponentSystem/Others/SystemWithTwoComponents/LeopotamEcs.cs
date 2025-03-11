using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithTwoComponents
{
    /// <summary>
    /// The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
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
                        switch (j % 2)
                        {
                            case 0:
                                padding.Replace(new Component1());
                                break;

                            case 1:
                                padding.Replace(new Component2());
                                break;
                        }
                    }

                    World.NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 { Value = 1 });
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
