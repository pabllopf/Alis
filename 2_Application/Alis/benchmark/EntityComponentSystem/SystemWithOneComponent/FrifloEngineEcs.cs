using System;
using System.Runtime.Intrinsics;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.FrifloEngine_Components;
using BenchmarkDotNet.Attributes;
using Friflo.Engine.ECS;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The friflo engine ecs context class
        /// </summary>
        /// <seealso cref="FrifloEngineEcsBaseContext"/>
        internal sealed class FrifloEngineEcsContext : FrifloEngineEcsBaseContext
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FrifloEngineEcsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="padding">The padding</param>
            public FrifloEngineEcsContext(int entityCount, int padding)
                : base(entityCount, padding, ComponentTypes.Get<Component1>())
            { }
            
            /// <summary>
            /// Fors the each using the specified component 1
            /// </summary>
            /// <param name="component1">The component</param>
            /// <param name="entities">The entities</param>
            internal static void ForEach(Chunk<Component1> component1, ChunkEntities entities)
            {
                foreach (ref Component1 component in component1.Span)
                {
                    ++component.Value;
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
            foreach ((Chunk<Component1> component1, ChunkEntities _) in _frifloEngineEcs.queryOne.Chunks)
            {
                foreach (ref Component1 component in component1.Span)
                {
                    ++component.Value;
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
            _frifloEngineEcs.jobOne.RunParallel();
        }
        
        /// <summary>
        /// Frifloes the engine ecs simd mono thread
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs_SIMD_MonoThread()
        {
            Vector256<int> add = Vector256.Create<int>(1);              // create int[8] vector - all values = 1

            foreach ((Chunk<Component1> component1, ChunkEntities _) in _frifloEngineEcs.queryOne.Chunks)
            {
                Span<int> component1Span = component1.AsSpan256<int>(); // Length - multiple of 8
                int step = component1.StepSpan256;                      // step = 8
                for (int n = 0; n < component1Span.Length; n += step)
                {
                    Span<int> slice = component1Span.Slice(n, step);
                    Vector256<int> value = Vector256.Create<int>(slice);
                    Vector256<int> result = Vector256.Add(value, add);  // execute 8 add instructions at once
                    result.CopyTo(slice);
                }
            }
        }
    }
}
