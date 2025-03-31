// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AlisEcsBenchmark.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Systems;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomEcs
{
    [ShortRunJob, MemoryDiagnoser(false)]
    public class AlisEcsBenchmark
    {
        /// <summary>
        ///     The id
        /// </summary>
        private static readonly EntityType _entityAlisType = Entity.EntityTypeOf([Component<Component1>.ID], []);
        
        /// <summary>
        ///     Gets or sets the value of the entity count
        /// </summary>
        [Params(1_000_000)]
        public int EntityCount { get; set; }
        
            /// <summary>
        ///     Gets the value of the world
        /// </summary>
        public World World { get; set; }
        
        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose() => World.Dispose();

        /// <summary>
        ///     The component
        /// </summary>
        internal struct Component1
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        internal struct Component2
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        internal struct Component3
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        internal struct Component4
        {
            public int Value;
        }
        
        internal struct Component5
        {
            public int Value;
        }
        
        internal struct Component6
        {
            public int Value;
        }
        
        internal struct Component7
        {
            public int Value;
        }
        
        internal struct Component8
        {
            public int Value;
        }
        
        internal struct Component9
        {
            public int Value;
        }
        
        internal struct Component10
        {
            public int Value;
        }
        
        internal struct Component11
        {
            public int Value;
        }
        
        internal struct Component12
        {
            public int Value;
        }
        
        internal struct Component13
        {
            public int Value;
        }
        
        internal struct Component14
        {
            public int Value;
        }
        
        internal struct Component15
        {
            public int Value;
        }
        
        internal struct Component16
        {
            public int Value;
        }
        
        /// <summary>
        /// The increment alis
        /// </summary>
        internal struct IncrementAlis : IAction<Component1>
        {

            /// <summary>
            /// Runs the t 0
            /// </summary>
            /// <param name="t0">The </param>
            public void Run(ref Component1 t0)
            {
                t0.Value++;
            }
        }

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [IterationSetup]
        public void Setup()
        {
            World = new World();
            
            Query = World.Query<With<Component1>>();
        }
        
        /// <summary>
        /// The query
        /// </summary>
        public Query Query;

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        [IterationCleanup]
        public void Cleanup()
        {
            Dispose();
        }

        /// <summary>
        ///     Frents this instance
        /// </summary>
        [Benchmark]
        public void Create_With_One_Component()
        {
            World world = this.World;
            world.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1>(default(Component1));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [Benchmark]
        public void Create_Bulk_With_One_Component()
        {
            World world = this.World;
            ChunkTuple<Component1> chunks = world.CreateMany<Component1>(EntityCount);

            for (int i = 0; i < chunks.Span.Length; i++)
            {
                chunks.Span[i] = new Component1();
            }
        }
        
        [Benchmark]
        public void Create_With_Two_Component()
        {
            World world = this.World;
            world.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1, Component2>(default(Component1), default(Component2));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [Benchmark]
        public void Create_Bulk_With_Two_Component()
        {
            World world = this.World;
            ChunkTuple<Component1, Component2> chunks = world.CreateMany<Component1, Component2>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
            }
        }
        
        [Benchmark]
        public void Create_With_Three_Component()
        {
            World world = this.World;
            world.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1, Component2, Component3>(default(Component1), default(Component2), default(Component3));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [Benchmark]
        public void Create_Bulk_With_Thre_Component()
        {
            World world = this.World;
            ChunkTuple<Component1, Component2, Component3> chunks = world.CreateMany<Component1, Component2, Component3>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
            }
        }
        
        [Benchmark]
        public void Create_With_Four_Component()
        {
            World world = this.World;
            world.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1, Component2, Component3, Component4>(default(Component1), default(Component2), default(Component3), default(Component4));
            }
        }
        
        [Benchmark]
        public void Create_Bulk_With_Four_Component()
        {
            World world = this.World;
            ChunkTuple<Component1, Component2, Component3, Component4> chunks = world.CreateMany<Component1, Component2, Component3, Component4>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
            }
        }

        [Benchmark]
        public void Create_With_Five_Component()
        {
            World world = this.World;
            world.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1, Component2, Component3, Component4, Component5>(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5));
            }
        }
        
        [Benchmark]
        public void Create_Bulk_With_Five_Component()
        {
            World world = this.World;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
            }
        }
        
        [Benchmark]
        public void Create_With_Six_Component()
        {
            World world = this.World;
            world.EnsureCapacity(_entityAlisType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create<Component1, Component2, Component3, Component4, Component5, Component6>(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6));
            }
        }
        
        [Benchmark]
        public void Create_Bulk_With_Six_Component()
        {
            World world = this.World;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
            }
        }
        
        /// <summary>
        /// Alises the query inline
        /// </summary>
        [Benchmark]
        public void SystemWithOneComponent_QueryInline_With_Padding_0()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                World.Create<Component1>(default(Component1));
            }
            
            Query.Inline<IncrementAlis, Component1>(default(IncrementAlis));
        }


        /// <summary>
        /// Alises the query delegate
        /// </summary>
        [Benchmark]
        public void SystemWithOneComponent_QueryDelegate_With_Padding_0()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                World.Create<Component1>(default(Component1));
            }
            
            Query.Delegate((ref Component1 c) => c.Value++);
        }


        /// <summary>
        /// Alises the simd
        /// </summary>
        [Benchmark]
        public void SystemWithOneComponent_Simd_With_Padding_0()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                World.Create<Component1>(default(Component1));
            }
            
            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in Query.EnumerateChunks<Component1>())
            {
                int len = chunk.Span.Length - (chunk.Span.Length & 7);
                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(chunk.Span.Slice(0, len));
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] += sum;
                }

                for (int i = len; i < chunk.Span.Length; i++)
                {
                    chunk.Span[i].Value++;
                }
            }
        }
        
        
        /// <summary>
        /// Alises the query inline
        /// </summary>
        [Benchmark]
        public void SystemWithOneComponent_QueryInline_With_Padding_10()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                World.Create<Component1>(default(Component1));
                for (int j = 0; j < 10; j++)
                {
                    World.Create();
                }
            }
            
            Query.Inline<IncrementAlis, Component1>(default(IncrementAlis));
        }


        /// <summary>
        /// Alises the query delegate
        /// </summary>
        [Benchmark]
        public void SystemWithOneComponent_QueryDelegate_With_Padding_10()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                World.Create<Component1>(default(Component1));
                for (int j = 0; j < 10; j++)
                {
                    World.Create();
                }
            }
            
            Query.Delegate((ref Component1 c) => c.Value++);
        }


        /// <summary>
        /// Alises the simd
        /// </summary>
        [Benchmark]
        public void SystemWithOneComponent_Simd_With_Padding_10()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                World.Create<Component1>(default(Component1));
                for (int j = 0; j < 10; j++)
                {
                    World.Create();
                }
            }
            
            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in Query.EnumerateChunks<Component1>())
            {
                int len = chunk.Span.Length - (chunk.Span.Length & 7);
                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(chunk.Span.Slice(0, len));
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] += sum;
                }

                for (int i = len; i < chunk.Span.Length; i++)
                {
                    chunk.Span[i].Value++;
                }
            }
        }

    
    }
}