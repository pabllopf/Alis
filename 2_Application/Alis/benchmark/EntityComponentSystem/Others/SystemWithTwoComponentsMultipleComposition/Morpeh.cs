using System;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Scellecs.Morpeh;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// The morpeh context class
        /// </summary>
        /// <seealso cref="MorpehBaseContext"/>
        private sealed class MorpehContext : MorpehBaseContext
        {
            private record struct Padding1() : IComponent;

            private record struct Padding2() : IComponent;

            private record struct Padding3() : IComponent;

            private record struct Padding4() : IComponent;

            /// <summary>
            /// The direct system class
            /// </summary>
            /// <seealso cref="ISystem"/>
            private sealed class DirectSystem : ISystem
            {
                /// <summary>
                /// Gets or sets the value of the world
                /// </summary>
                public World World { get; set; }
                /// <summary>
                /// The filter
                /// </summary>
                private Filter _filter;

                /// <summary>
                /// Ons the awake
                /// </summary>
                public void OnAwake()
                {
                    _filter = World.Filter.With<Component1>().With<Component2>().Build();
                }

                /// <summary>
                /// Ons the update using the specified delta time
                /// </summary>
                /// <param name="deltaTime">The delta time</param>
                public void OnUpdate(float deltaTime)
                {
                    foreach (Entity entity in _filter)
                    {
                        entity.GetComponent<Component1>().Value += entity.GetComponent<Component2>().Value;
                    }
                }

                /// <summary>
                /// Disposes this instance
                /// </summary>
                void IDisposable.Dispose() { }
            }

            /// <summary>
            /// The stash system class
            /// </summary>
            /// <seealso cref="ISystem"/>
            private sealed class StashSystem : ISystem
            {
                /// <summary>
                /// Gets or sets the value of the world
                /// </summary>
                public World World { get; set; }
                /// <summary>
                /// The stash
                /// </summary>
                private Stash<Component1> _stash1;
                /// <summary>
                /// The stash
                /// </summary>
                private Stash<Component2> _stash2;
                /// <summary>
                /// The filter
                /// </summary>
                private Filter _filter;

                /// <summary>
                /// Ons the awake
                /// </summary>
                public void OnAwake()
                {
                    _stash1 = World.GetStash<Component1>();
                    _stash2 = World.GetStash<Component2>();
                    _filter = World.Filter.With<Component1>().With<Component2>().Build();
                }

                /// <summary>
                /// Ons the update using the specified delta time
                /// </summary>
                /// <param name="deltaTime">The delta time</param>
                public void OnUpdate(float deltaTime)
                {
                    foreach (Entity entity in _filter)
                    {
                        _stash1.Get(entity).Value += _stash2.Get(entity).Value;
                    }
                }

                /// <summary>
                /// Disposes this instance
                /// </summary>
                public void Dispose()
                {
                    _stash1.Dispose();
                    _stash2.Dispose();
                }
            }

            /// <summary>
            /// Gets the value of the mono thread direct system
            /// </summary>
            public ISystem MonoThreadDirectSystem { get; }
            /// <summary>
            /// Gets the value of the mono thread stash system
            /// </summary>
            public ISystem MonoThreadStashSystem { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="MorpehContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public MorpehContext(int entityCount)
            {
                MonoThreadDirectSystem = new DirectSystem { World = World };
                MonoThreadDirectSystem.OnAwake();

                MonoThreadStashSystem = new StashSystem { World = World };
                MonoThreadStashSystem.OnAwake();

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.AddComponent<Component1>();
                    entity.SetComponent(new Component2 { Value = 1 });

                    switch (i % 4)
                    {
                        case 0:
                            entity.AddComponent<Padding1>();
                            break;

                        case 1:
                            entity.AddComponent<Padding2>();
                            break;

                        case 2:
                            entity.AddComponent<Padding3>();
                            break;

                        case 3:
                            entity.AddComponent<Padding4>();
                            break;
                    }
                }

                World.Commit();
            }
        }

        /// <summary>
        /// The context
        /// </summary>
        [Context]
        private readonly MorpehContext _context;

        /// <summary>
        /// Morpehs the direct
        /// </summary>
        [BenchmarkCategory(Categories.Morpeh)]
        [Benchmark]
        public void Morpeh_Direct() => _context.MonoThreadDirectSystem.OnUpdate(0f);

        /// <summary>
        /// Morpehs the stash
        /// </summary>
        [BenchmarkCategory(Categories.Morpeh)]
        [Benchmark]
        public void Morpeh_Stash() => _context.MonoThreadStashSystem.OnUpdate(0f);
    }
}
