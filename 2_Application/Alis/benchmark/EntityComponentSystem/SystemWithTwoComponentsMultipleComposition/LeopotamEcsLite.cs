using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// The leopotam ecs lite context class
        /// </summary>
        /// <seealso cref="LeopotamEcsLiteBaseContext"/>
        private sealed class LeopotamEcsLiteContext : LeopotamEcsLiteBaseContext
        {
            private record struct Padding1();

            private record struct Padding2();

            private record struct Padding3();

            private record struct Padding4();

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
            public LeopotamEcsLiteContext(int entityCount)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem());

                MonoThreadSystem.Init();

                EcsPool<Component1> c1 = World.GetPool<Component1>();
                EcsPool<Component2> c2 = World.GetPool<Component2>();

                EcsPool<Padding1> p1 = World.GetPool<Padding1>();
                EcsPool<Padding2> p2 = World.GetPool<Padding2>();
                EcsPool<Padding3> p3 = World.GetPool<Padding3>();
                EcsPool<Padding4> p4 = World.GetPool<Padding4>();

                for (int i = 0; i < entityCount; ++i)
                {
                    int entity = World.NewEntity();
                    c1.Add(entity);
                    c2.Add(entity) = new Component2 { Value = 1 };

                    switch (i % 4)
                    {
                        case 0:
                            p1.Add(entity);
                            break;

                        case 1:
                            p2.Add(entity);
                            break;

                        case 2:
                            p3.Add(entity);
                            break;

                        case 3:
                            p4.Add(entity);
                            break;
                    }
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
