using System;
using System.Runtime.Intrinsics;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.FrifloEngine_Components;
using BenchmarkDotNet.Attributes;
using Friflo.Engine.ECS;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// The friflo engine ecs context class
        /// </summary>
        /// <seealso cref="FrifloEngineEcsBaseContext"/>
        internal sealed class FrifloEngineEcsContext : FrifloEngineEcsBaseContext
        {
            private record struct Padding1 : IComponent { }

            private record struct Padding2 : IComponent { }

            private record struct Padding3 : IComponent { }

            private record struct Padding4 : IComponent { }

            /// <summary>
            /// Initializes a new instance of the <see cref="FrifloEngineEcsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public FrifloEngineEcsContext(int entityCount)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = EntityStore.CreateEntity();
                    entity.AddComponent<Component1>();
                    entity.AddComponent(new Component2 { Value = 1 });

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
            }
            
            /// <summary>
            /// Fors the each using the specified component 1
            /// </summary>
            /// <param name="component1">The component</param>
            /// <param name="component2">The component</param>
            /// <param name="entities">The entities</param>
            internal static void ForEach(Chunk<Component1> component1, Chunk<Component2> component2, ChunkEntities entities)
            {
                Span<Component1> component1Span = component1.Span;
                Span<Component2> component2Span = component2.Span;
                for (int n = 0; n < component1Span.Length; n++)
                {
                    Update(ref component1Span[n], ref component2Span[n]);
                }
            }
        }

        /// <summary>
        /// The friflo engine ecs
        /// </summary>
        [Context]
        private readonly FrifloEngineEcsContext _frifloEngineEcs;

        /// <summary>
        /// Frifloes the engine ecs mono thread
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_MonoThread()
        {
            foreach ((Chunk<Component1> component1, Chunk<Component2> component2, ChunkEntities _)
                     in _frifloEngineEcs.queryTwo.Chunks)
            {
                Span<Component1> component1Span = component1.Span;
                Span<Component2> component2Span = component2.Span;
                for (int n = 0; n < component1Span.Length; n++)
                {
                    Update(ref component1Span[n], ref component2Span[n]);
                }
            }
        }
        
        /// <summary>
        /// Frifloes the engine ecs multi thread
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_MultiThread()
        {
            _frifloEngineEcs.jobTwoWithComposition.RunParallel();
        }

        /// <summary>
        /// Updates the c 1
        /// </summary>
        /// <param name="c1">The </param>
        /// <param name="c2">The </param>
        private static void Update(ref Component1 c1, ref Component2 c2)
        {
            c1.Value += c2.Value;
        }

        /// <summary>
        /// Frifloes the engine ecs simd mono thread
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_SIMD_MonoThread()
        {
            foreach ((Chunk<Component1> component1, Chunk<Component2> component2, ChunkEntities _)
                     in _frifloEngineEcs.queryTwo.Chunks)
            {
                Span<int> component1Span = component1.AsSpan256<int>();     // Length - multiple of 8
                Span<int> component2Span = component2.AsSpan256<int>();     // Length - multiple of 8
                int step = component1.StepSpan256;                          // step = 8
                for (int n = 0; n < component1Span.Length; n += step)
                {
                    Span<int> component1Slice = component1Span.Slice(n, step);
                    Vector256<int> value1 = Vector256.Create<int>(component1Slice);
                    Vector256<int> value2 = Vector256.Create<int>(component2Span.Slice(n, step));
                    Vector256<int> result = Vector256.Add(value1, value2);  // execute 8 add instructions at once
                    result.CopyTo(component1Slice);
                }
            }
        }
    }
}
