using System;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Myriad_Components;
using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Collections;
using Myriad.ECS.Command;
using Myriad.ECS.Queries;
using Myriad.ECS.Worlds;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithThreeComponents
{
    /// <summary>
    /// The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
    {
        /// <summary>
        /// The myriad for each
        /// </summary>
        private struct MyriadForEach3
            : IQuery<Component1, Component2, Component3>, IChunkQuery<Component1, Component2, Component3>
        {
            /// <summary>
            /// Executes the entity
            /// </summary>
            /// <param name="entity">The entity</param>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            /// <param name="t2">The </param>
            public void Execute(Entity entity, ref Component1 t0, ref Component2 t1, ref Component3 t2)
            {
                t0.Value += t1.Value + t2.Value;
            }

            /// <summary>
            /// Executes the chunk
            /// </summary>
            /// <param name="chunk">The chunk</param>
            /// <param name="e">The </param>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            /// <param name="t2">The </param>
            public void Execute(ChunkHandle chunk, ReadOnlySpan<Entity> e, Span<Component1> t0, Span<Component2> t1, Span<Component3> t2)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i].Value += t1[i].Value + t2[i].Value;
                }
            }
        }

        /// <summary>
        /// The myriad context class
        /// </summary>
        /// <seealso cref="MyriadBaseContext"/>
        private sealed class MyriadContext : MyriadBaseContext
        {
            // Myriad stores components as arrays of structs, so all structs of the same type are 
            // always sequential in memory no matter what else is attached to the entity. So no need to respect
            // the padding input
            /// <summary>
            /// Initializes a new instance of the <see cref="MyriadContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="_">The </param>
            public MyriadContext(int entityCount, int _)
                : base()
            {
                CommandBuffer cmd = new CommandBuffer(World);
                for (int i = 0; i < entityCount; i++)
                {
                    CommandBuffer.BufferedEntity e = cmd.Create().Set(new Component1()).Set(new Component2()).Set(new Component3());
                }
                cmd.Playback().Dispose();
            }
        }

        /// <summary>
        /// The myriad
        /// </summary>
        [Context]
        private readonly MyriadContext _myriad;

        /// <summary>
        /// Myriads the single thread
        /// </summary>
        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThread()
        {
            World world = _myriad.World;
            world.Execute<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        /// <summary>
        /// Myriads the multi thread
        /// </summary>
        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThread()
        {
            World world = _myriad.World;
            world.ExecuteParallel<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        /// <summary>
        /// Myriads the single thread chunk
        /// </summary>
        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_SingleThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunk<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        /// <summary>
        /// Myriads the multi thread chunk
        /// </summary>
        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_MultiThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunkParallel<MyriadForEach3, Component1, Component2, Component3>(new MyriadForEach3());
        }

        /// <summary>
        /// Myriads the enumerable
        /// </summary>
        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Enumerable()
        {
            World world = _myriad.World;

            foreach ((Entity _, RefT<Component1> c1, RefT<Component2> c2, RefT<Component3> c3) in world.Query<Component1, Component2, Component3>())
            {
                c1.Ref.Value += c2.Ref.Value + c3.Ref.Value;
            }
        }

        /// <summary>
        /// Myriads the delegate
        /// </summary>
        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad_Delegate()
        {
            World world = _myriad.World;

            world.Query((ref Component1 c1, ref Component1 c2, ref Component1 c3) =>
            {
                c1.Value += c2.Value + c3.Value;
            });
        }
    }
}
