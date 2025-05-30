// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrentEcsBenchmark.cs
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
using Alis.Benchmark.CustomEcs.Components;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Core;
using Frent.Systems;

namespace Alis.Benchmark.CustomEcs
{
    /// <summary>
    ///     The alis ecs benchmark class
    /// </summary>
    public partial class AlisEcsBenchmark
    {
        /// <summary>
        ///     The id
        /// </summary>
        private static readonly EntityType _entityFrentType = Entity.EntityTypeOf([Component<Component1>.ID], []);

        /// <summary>
        ///     The query
        /// </summary>
        public Query QueryFrent;

        /// <summary>
        ///     Gets the value of the scene
        /// </summary>
        public World WorldFrent { get; set; }


        /// <summary>
        ///     Setup the alis
        /// </summary>
        private void SetupFrent()
        {
            WorldFrent = new World();
            QueryFrent = WorldFrent.Query<With<Component1>>();
        }

        /// <summary>
        ///     Frents this instance
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_One_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_One_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1> chunks = world.CreateMany<Component1>(EntityCount);

            for (int i = 0; i < chunks.Span.Length; i++)
            {
                chunks.Span[i] = new Component1();
            }
        }

        /// <summary>
        ///     Frents the create with two component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Two_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Two_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2> chunks = world.CreateMany<Component1, Component2>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
            }
        }

        /// <summary>
        ///     Frents the create with three component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Three_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3));
            }
        }

        /// <summary>
        ///     Frents the bulk
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Thre_Component()
        {
            World world = WorldFrent;
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

        /// <summary>
        ///     Frents the create with four component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Four_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4));
            }
        }

        /// <summary>
        ///     Frents the create bulk with four component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Four_Component()
        {
            World world = WorldFrent;
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

        /// <summary>
        ///     Frents the create with five component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Five_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5));
            }
        }

        /// <summary>
        ///     Frents the create bulk with five component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Five_Component()
        {
            World world = WorldFrent;
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

        /// <summary>
        ///     Frents the create with six component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Six_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6));
            }
        }

        /// <summary>
        ///     Frents the create bulk with six component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Six_Component()
        {
            World world = WorldFrent;
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
        ///     Frents the create with seven component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Seven_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7));
            }
        }

        /// <summary>
        ///     Frents the create bulk with seven component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Seven_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
            }
        }

        /// <summary>
        ///     Creates the with eight component
        /// </summary>
        [Benchmark]
        public void Create_With_Eight_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8));
            }
        }

        /// <summary>
        ///     Frents the create bulk with eight component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Eight_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
            }
        }

        /// <summary>
        ///     Frents the create with nine component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Nine_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9));
            }
        }

        /// <summary>
        ///     Frents the create bulk with nine component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Nine_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
            }
        }

        /// <summary>
        ///     Frents the create with ten component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Ten_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10));
            }
        }

        /// <summary>
        ///     Frents the create bulk with ten component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Ten_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            chunks.Span10 = chunks.Span10[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
                chunks.Span10[i] = default(Component10);
            }
        }

        /// <summary>
        ///     Frents the create with eleven component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Eleven_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11));
            }
        }

        /// <summary>
        ///     Frents the create bulk with eleven component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Eleven_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            chunks.Span10 = chunks.Span10[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
                chunks.Span10[i] = default(Component10);
                chunks.Span11[i] = default(Component11);
            }
        }

        /// <summary>
        ///     Frents the create with twelve component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Twelve_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11), default(Component12));
            }
        }

        /// <summary>
        ///     Frents the create bulk with twelve component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Twelve_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            chunks.Span10 = chunks.Span10[..chunks.Span1.Length];
            chunks.Span11 = chunks.Span11[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
                chunks.Span10[i] = default(Component10);
                chunks.Span11[i] = default(Component11);
                chunks.Span12[i] = default(Component12);
            }
        }

        /// <summary>
        ///     Frents the create with thirteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Thirteen_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11), default(Component12), default(Component13));
            }
        }

        /// <summary>
        ///     Frents the create bulk with thirteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Thirteen_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13> chunks = world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            chunks.Span10 = chunks.Span10[..chunks.Span1.Length];
            chunks.Span11 = chunks.Span11[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
                chunks.Span10[i] = default(Component10);
                chunks.Span11[i] = default(Component11);
                chunks.Span12[i] = default(Component12);
                chunks.Span13[i] = default(Component13);
            }
        }

        /// <summary>
        ///     Frents the create with fourteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Fourteen_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11), default(Component12), default(Component13), default(Component14));
            }
        }

        /// <summary>
        ///     Frents the create bulk with fourteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Fourteen_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13, Component14> chunks =
                world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13, Component14>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            chunks.Span10 = chunks.Span10[..chunks.Span1.Length];
            chunks.Span11 = chunks.Span11[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
                chunks.Span10[i] = default(Component10);
                chunks.Span11[i] = default(Component11);
                chunks.Span12[i] = default(Component12);
                chunks.Span13[i] = default(Component13);
                chunks.Span14[i] = default(Component14);
            }
        }

        /// <summary>
        ///     Frents the create with fifteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Fifteen_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11), default(Component12), default(Component13), default(Component14), default(Component15));
            }
        }


        /// <summary>
        ///     Frents the create bulk with fifteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Fifteen_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13, Component14, Component15> chunks =
                world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13, Component14, Component15>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            chunks.Span10 = chunks.Span10[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
                chunks.Span10[i] = default(Component10);
                chunks.Span11[i] = default(Component11);
                chunks.Span12[i] = default(Component12);
                chunks.Span13[i] = default(Component13);
                chunks.Span14[i] = default(Component14);
                chunks.Span15[i] = default(Component15);
            }
        }

        /// <summary>
        ///     Frents the create with sixteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_With_Sixteen_Component()
        {
            World world = WorldFrent;
            world.EnsureCapacity(_entityFrentType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
            {
                world.Create(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5), default(Component6), default(Component7), default(Component8), default(Component9), default(Component10), default(Component11), default(Component12), default(Component13), default(Component14), default(Component15), default(Component16));
            }
        }

        /// <summary>
        ///     Frents the create bulk with sixteen component
        /// </summary>
        [Benchmark]
        public void Frent_Create_Bulk_With_Sixteen_Component()
        {
            World world = WorldFrent;
            ChunkTuple<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13, Component14, Component15, Component16> chunks =
                world.CreateMany<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8, Component9, Component10, Component11, Component12, Component13, Component14, Component15, Component16>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            chunks.Span4 = chunks.Span4[..chunks.Span1.Length];
            chunks.Span5 = chunks.Span5[..chunks.Span1.Length];
            chunks.Span6 = chunks.Span6[..chunks.Span1.Length];
            chunks.Span7 = chunks.Span7[..chunks.Span1.Length];
            chunks.Span8 = chunks.Span8[..chunks.Span1.Length];
            chunks.Span9 = chunks.Span9[..chunks.Span1.Length];
            chunks.Span10 = chunks.Span10[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default(Component1);
                chunks.Span2[i] = default(Component2);
                chunks.Span3[i] = default(Component3);
                chunks.Span4[i] = default(Component4);
                chunks.Span5[i] = default(Component5);
                chunks.Span6[i] = default(Component6);
                chunks.Span7[i] = default(Component7);
                chunks.Span8[i] = default(Component8);
                chunks.Span9[i] = default(Component9);
                chunks.Span10[i] = default(Component10);
                chunks.Span11[i] = default(Component11);
                chunks.Span12[i] = default(Component12);
                chunks.Span13[i] = default(Component13);
                chunks.Span14[i] = default(Component14);
                chunks.Span15[i] = default(Component15);
                chunks.Span16[i] = default(Component16);
            }
        }


        /// <summary>
        ///     Frents the system with one component query inline with padding 0
        /// </summary>
        [Benchmark]
        public void Frent_SystemWithOneComponent_QueryInline_With_Padding_0()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                WorldFrent.Create(default(Component1));
            }

            QueryFrent.Inline<IncrementFrent, Component1>(default(IncrementFrent));
        }


        /// <summary>
        ///     Frents the system with one component query delegate with padding 0
        /// </summary>
        [Benchmark]
        public void Frent_SystemWithOneComponent_QueryDelegate_With_Padding_0()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                WorldFrent.Create(default(Component1));
            }

            QueryFrent.Delegate((ref Component1 c) => c.Value++);
        }

        /// <summary>
        ///     Frents the system with one component simd with padding 0
        /// </summary>
        [Benchmark]
        public void Frent_SystemWithOneComponent_Simd_With_Padding_0()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                WorldFrent.Create(default(Component1));
            }

            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in QueryFrent.EnumerateChunks<Component1>())
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
        ///     Frents the system with one component query inline with padding 10
        /// </summary>
        [Benchmark]
        public void Frent_SystemWithOneComponent_QueryInline_With_Padding_10()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                WorldFrent.Create(default(Component1));
                for (int j = 0; j < 10; j++)
                {
                    WorldFrent.Create();
                }
            }

            QueryFrent.Inline<IncrementFrent, Component1>(default(IncrementFrent));
        }


        /// <summary>
        ///     Frents the system with one component query delegate with padding 10
        /// </summary>
        [Benchmark]
        public void Frent_SystemWithOneComponent_QueryDelegate_With_Padding_10()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                WorldFrent.Create(default(Component1));
                for (int j = 0; j < 10; j++)
                {
                    WorldFrent.Create();
                }
            }

            QueryFrent.Delegate((ref Component1 c) => c.Value++);
        }

        /// <summary>
        ///     Frents the system with one component simd with padding 10
        /// </summary>
        [Benchmark]
        public void Frent_SystemWithOneComponent_Simd_With_Padding_10()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                WorldFrent.Create(default(Component1));
                for (int j = 0; j < 10; j++)
                {
                    WorldFrent.Create();
                }
            }

            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in QueryFrent.EnumerateChunks<Component1>())
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
        ///     The increment alis
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IncrementFrent : IAction<Component1>
        {
            /// <summary>
            ///     Runs the t 0
            /// </summary>
            /// <param name="t0">The </param>
            public void Run(ref Component1 t0)
            {
                t0.Value++;
            }
        }
    }
}