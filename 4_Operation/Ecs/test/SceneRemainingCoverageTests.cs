// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene remaining coverage tests class
    /// </summary>
    public partial class SceneRemainingCoverageTests
    {
        /// <summary>
        ///     Plain component types without source-generated init delegates. They are
        ///     registered explicitly so the `Component&lt;T&gt;.Initer?.Invoke` null path
        ///     of the Create overloads is exercised.
        /// </summary>
        private struct PlainComponent1
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Second plain component
        /// </summary>
        private struct PlainComponent2
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Third plain component
        /// </summary>
        private struct PlainComponent3
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Fourth plain component
        /// </summary>
        private struct PlainComponent4
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Fifth plain component
        /// </summary>
        private struct PlainComponent5
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Sixth plain component
        /// </summary>
        private struct PlainComponent6
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Component that creates one more entity every time it is updated, so the
        ///     deferred-creation loop keeps finding new work until the guard trips.
        /// </summary>
        private partial struct RecursiveSpawnComponent : IOnUpdate
        {
            /// <summary>
            ///     The spawned flag
            /// </summary>
            public bool Spawned;

            /// <summary>
            ///     Spawns another entity of the same type
            /// </summary>
            /// <param name="self">The owning game object</param>
            public void OnUpdate(IGameObject self)
            {
                if (!Spawned)
                {
                    ((GameObject) self).Scene.Create(new RecursiveSpawnComponent {Spawned = false});
                }
            }
        }

        /// <summary>
        ///     Tests that CreateEntityFromLocation uses a recycled id when one is available.
        /// </summary>
        [Fact]
        public void CreateEntityFromLocation_WithRecycledId_ReusesIt()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position());
                first.Delete();

                GameObject second = scene.CreateFromObjects(new object[] {new Velocity()});

                Assert.Equal(first.EntityID, second.EntityID);
            }
        }

        /// <summary>
        ///     Tests that the arity-3 Create overload consumes a recycled id.
        /// </summary>
        [Fact]
        public void CreateArity3_WithRecycledId_ReusesIt()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position());
                first.Delete();

                GameObject second = scene.Create(new Position(), new Velocity(), new Health());

                Assert.Equal(first.EntityID, second.EntityID);
            }
        }

        /// <summary>
        ///     Tests that the arity-4 Create overload consumes a recycled id.
        /// </summary>
        [Fact]
        public void CreateArity4_WithRecycledId_ReusesIt()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position());
                first.Delete();

                GameObject second = scene.Create(new Position(), new Velocity(), new Health(), new Armor());

                Assert.Equal(first.EntityID, second.EntityID);
            }
        }

        /// <summary>
        ///     Tests that the arity-5 Create overload consumes a recycled id.
        /// </summary>
        [Fact]
        public void CreateArity5_WithRecycledId_ReusesIt()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position());
                first.Delete();

                GameObject second = scene.Create(new Position(), new Velocity(), new Health(), new Armor(), new Damage());

                Assert.Equal(first.EntityID, second.EntityID);
            }
        }

        /// <summary>
        ///     Tests that the arity-6 Create overload consumes a recycled id.
        /// </summary>
        [Fact]
        public void CreateArity6_WithRecycledId_ReusesIt()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position());
                first.Delete();

                GameObject second = scene.Create(new Position(), new Velocity(), new Health(), new Armor(), new Damage(),
                    new Transform());

                Assert.Equal(first.EntityID, second.EntityID);
            }
        }

        /// <summary>
        ///     Tests that the arity-7 Create overload consumes a recycled id.
        /// </summary>
        [Fact]
        public void CreateArity7_WithRecycledId_ReusesIt()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position());
                first.Delete();

                GameObject second = scene.Create(new Position(), new Velocity(), new Health(), new Armor(), new Damage(),
                    new Transform(), new TestComponent());

                Assert.Equal(first.EntityID, second.EntityID);
            }
        }

        /// <summary>
        ///     Tests that the arity-8 Create overload consumes a recycled id.
        /// </summary>
        [Fact]
        public void CreateArity8_WithRecycledId_ReusesIt()
        {
            using (Scene scene = new Scene())
            {
                GameObject first = scene.Create(new Position());
                first.Delete();

                GameObject second = scene.Create(new Position(), new Velocity(), new Health(), new Armor(), new Damage(),
                    new Transform(), new TestComponent(), new AnotherComponent());

                Assert.Equal(first.EntityID, second.EntityID);
            }
        }

        /// <summary>
        ///     Tests that a component without a registered init delegate is skipped.
        /// </summary>
        [Fact]
        public void CreateArity2_WithPlainSecondComponent_SkipsNullIniter()
        {
            Component.RegisterComponent<PlainComponent1>();

            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position(), new PlainComponent1 {Value = 7});

                Assert.Equal(7, entity.Get<PlainComponent1>().Value);
            }
        }

        /// <summary>
        ///     Tests that plain components at positions 2..6 skip their null init delegates.
        /// </summary>
        [Fact]
        public void CreateArity6_WithPlainComponents_SkipsNullIniters()
        {
            Component.RegisterComponent<PlainComponent1>();
            Component.RegisterComponent<PlainComponent2>();
            Component.RegisterComponent<PlainComponent3>();
            Component.RegisterComponent<PlainComponent4>();
            Component.RegisterComponent<PlainComponent5>();

            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position(), new PlainComponent1 {Value = 1},
                    new PlainComponent2 {Value = 2}, new PlainComponent3 {Value = 3},
                    new PlainComponent4 {Value = 4}, new PlainComponent5 {Value = 5});

                Assert.Equal(5, entity.Get<PlainComponent5>().Value);
            }
        }

        /// <summary>
        ///     Tests that plain components at positions 2..7 skip their null init delegates.
        /// </summary>
        [Fact]
        public void CreateArity7_WithPlainComponents_SkipsNullIniters()
        {
            Component.RegisterComponent<PlainComponent1>();
            Component.RegisterComponent<PlainComponent2>();
            Component.RegisterComponent<PlainComponent3>();
            Component.RegisterComponent<PlainComponent4>();
            Component.RegisterComponent<PlainComponent5>();
            Component.RegisterComponent<PlainComponent6>();

            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Position(), new PlainComponent1 {Value = 1},
                    new PlainComponent2 {Value = 2}, new PlainComponent3 {Value = 3},
                    new PlainComponent4 {Value = 4}, new PlainComponent5 {Value = 5},
                    new PlainComponent6 {Value = 6});

                Assert.Equal(6, entity.Get<PlainComponent6>().Value);
            }
        }

        /// <summary>
        ///     Tests the command-buffer playback recursion guard. Each playback creates one
        ///     entity and deletes another; their events enqueue the next playback's pair of
        ///     commands, so the buffer never drains and the guard must trip.
        /// </summary>
        [Fact]
        public void ExitDisallowState_WhenCommandBufferKeepsGrowing_ThrowsRecursionLimit()
        {
            using (Scene scene = new Scene())
            {
                scene.EntityCreated += e => scene.WorldUpdateCommandBuffer.DeleteEntity(e);
                scene.EntityDeleted += _ => scene.WorldUpdateCommandBuffer.Entity().End();
                scene.WorldUpdateCommandBuffer.Entity().End();

                scene.EnterDisallowState();

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => scene.ExitDisallowState(null));

                Assert.Contains("command buffer", ex.Message);
            }
        }

        /// <summary>
        ///     Tests the deferred-creation recursion guard. Each update creates another
        ///     entity with the same component, so the resolution loop never terminates.
        /// </summary>
        [Fact]
        public void ExitDisallowState_WhenDeferredCreationsKeepGrowing_ThrowsRecursionLimit()
        {
            GenerationServices.RegisterType(typeof(RecursiveSpawnComponent),
                new UpdateRunnerFactory<RecursiveSpawnComponent>());

            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                scene.Create(new RecursiveSpawnComponent {Spawned = false});

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => scene.ExitDisallowState(null, true));

                Assert.Contains("creating entities", ex.Message);
            }
        }

        /// <summary>
        ///     Tests that create many with zero count throws argument out of range
        /// </summary>
        [Fact]
        public void CreateMany_WithZeroCount_ThrowsArgumentOutOfRange()
        {
            using (Scene scene = new Scene())
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health>(0));
            }
        }

        /// <summary>
        ///     Tests that create many with negative count throws argument out of range
        /// </summary>
        [Fact]
        public void CreateMany_WithNegativeCount_ThrowsArgumentOutOfRange()
        {
            using (Scene scene = new Scene())
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health>(-1));
            }
        }

        /// <summary>
        ///     Tests that create many with positive count creates entities
        /// </summary>
        [Fact]
        public void CreateMany_WithPositiveCount_CreatesEntities()
        {
            using (Scene scene = new Scene())
            {
                var chunk = scene.CreateMany<Position, Health>(5);

                Assert.Equal(5, chunk.Span1.Length);
            }
        }
    }
}
