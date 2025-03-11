using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithTwoComponents
{
    /// <summary>
    /// The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
    {
        /// <summary>
        /// The leopotam ecs lite context class
        /// </summary>
        /// <seealso cref="LeopotamEcsLiteBaseContext"/>
        private sealed class LeopotamEcsLiteContext : LeopotamEcsLiteBaseContext
        {
            /// <summary>
            /// The mono thread run system class
            /// </summary>
            /// <seealso cref="IEcsInitSystem"/>
            /// <seealso cref="IEcsRunSystem"/>
            private sealed class MonoThreadRunSystem : IEcsInitSystem, IEcsRunSystem
            {
                /// <summary>
                /// The filter
                /// </summary>
                private EcsFilter _filter;
                /// <summary>
                /// The 
                /// </summary>
                private EcsPool<Component1> _c1;
                /// <summary>
                /// The 
                /// </summary>
                private EcsPool<Component2> _c2;

                /// <summary>
                /// Inits the systems
                /// </summary>
                /// <param name="systems">The systems</param>
                public void Init(IEcsSystems systems)
                {
                    EcsWorld world = systems.GetWorld();

                    _filter = world.Filter<Component1>().Inc<Component2>().End();
                    _c1 = world.GetPool<Component1>();
                    _c2 = world.GetPool<Component2>();
                }

                /// <summary>
                /// Runs the systems
                /// </summary>
                /// <param name="systems">The systems</param>
                public void Run(IEcsSystems systems)
                {
                    int[] entities = _filter.GetRawEntities();
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _c1.Get(entities[i]).Value += _c2.Get(entities[i]).Value;
                    }
                }
            }

            /// <summary>
            /// Gets the value of the mono thread system
            /// </summary>
            public IEcsSystems MonoThreadSystem { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="LeopotamEcsLiteContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public LeopotamEcsLiteContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem());

                MonoThreadSystem.Init();

                EcsPool<Component1> c1 = World.GetPool<Component1>();
                EcsPool<Component2> c2 = World.GetPool<Component2>();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        int padding = World.NewEntity();
                        switch (j % 2)
                        {
                            case 0:
                                c1.Add(padding);
                                break;

                            case 1:
                                c2.Add(padding);
                                break;
                        }
                    }

                    int entity = World.NewEntity();
                    c1.Add(entity);
                    c2.Add(entity) = new Component2 { Value = 1 };
                }
            }
        }

        /// <summary>
        /// The leopotam ecs lite
        /// </summary>
        [Context]
        private readonly LeopotamEcsLiteContext _leopotamEcsLite;

        /// <summary>
        /// Leopotams the ecs lite
        /// </summary>
        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite() => _leopotamEcsLite.MonoThreadSystem.Run();
    }
}
