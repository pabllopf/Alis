using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
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
                /// The components
                /// </summary>
                private EcsPool<Component1> _components;

                /// <summary>
                /// Inits the systems
                /// </summary>
                /// <param name="systems">The systems</param>
                public void Init(IEcsSystems systems)
                {
                    EcsWorld world = systems.GetWorld();

                    _filter = world.Filter<Component1>().End();
                    _components = world.GetPool<Component1>();
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
                        ++_components.Get(entities[i]).Value;
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
                        // LeopotamEcsLite does not support empty entities
                        c2.Add(World.NewEntity());
                    }

                    int entity = World.NewEntity();
                    c1.Add(entity);
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
