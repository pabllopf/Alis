// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectMultiArityAddRemoveTests.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Coverage tests for the multi-arity <see cref="GameObject" /> add and remove overloads.
    ///     Exercises the direct storage path and the deferred path applied while the scene disallows
    ///     structural changes.
    /// </summary>
    public class GameObjectMultiArityAddRemoveTests
    {
        /// <summary>
        ///     Tests that adding two components stores both and makes them retrievable.
        /// </summary>
        [Fact]
        public void Add_Arity2_StoresBothComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(2f, entity.Get<Position>().Y);
                Assert.Equal(3f, entity.Get<Velocity>().X);
                Assert.Equal(4f, entity.Get<Velocity>().Y);
            }
        }

        /// <summary>
        ///     Tests that removing two components makes both no longer present.
        /// </summary>
        [Fact]
        public void Remove_Arity2_RemovesBothComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

                entity.Remove<Position, Velocity>();

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.TryHas<Position>());
                Assert.False(entity.TryHas<Velocity>());
            }
        }

        /// <summary>
        ///     Tests that adding two components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Add_Arity2_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                scene.EnterDisallowState();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                scene.ExitDisallowState(null, false);

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(3f, entity.Get<Velocity>().X);
            }
        }

        /// <summary>
        ///     Tests that removing two components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Remove_Arity2_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

                scene.EnterDisallowState();
                entity.Remove<Position, Velocity>();
                scene.ExitDisallowState(null, false);

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
            }
        }

        /// <summary>
        ///     Tests that adding three components stores all of them.
        /// </summary>
        [Fact]
        public void Add_Arity3_StoresAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(3f, entity.Get<Velocity>().X);
                Assert.Equal(5, entity.Get<Health>().Value);
            }
        }

        /// <summary>
        ///     Tests that removing three components makes all of them no longer present.
        /// </summary>
        [Fact]
        public void Remove_Arity3_RemovesAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

                entity.Remove<Position, Velocity, Health>();

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
            }
        }

        /// <summary>
        ///     Tests that adding three components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Add_Arity3_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                scene.EnterDisallowState();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
                scene.ExitDisallowState(null, false);

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
            }
        }

        /// <summary>
        ///     Tests that removing three components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Remove_Arity3_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

                scene.EnterDisallowState();
                entity.Remove<Position, Velocity, Health>();
                scene.ExitDisallowState(null, false);

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
            }
        }

        /// <summary>
        ///     Tests that adding four components stores all of them.
        /// </summary>
        [Fact]
        public void Add_Arity4_StoresAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(3f, entity.Get<Velocity>().X);
                Assert.Equal(5, entity.Get<Health>().Value);
                Assert.Equal(6, entity.Get<Armor>().Value);
            }
        }

        /// <summary>
        ///     Tests that removing four components makes all of them no longer present.
        /// </summary>
        [Fact]
        public void Remove_Arity4_RemovesAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});

                entity.Remove<Position, Velocity, Health, Armor>();

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
            }
        }

        /// <summary>
        ///     Tests that adding four components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Add_Arity4_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                scene.EnterDisallowState();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});
                scene.ExitDisallowState(null, false);

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
            }
        }

        /// <summary>
        ///     Tests that removing four components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Remove_Arity4_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});

                scene.EnterDisallowState();
                entity.Remove<Position, Velocity, Health, Armor>();
                scene.ExitDisallowState(null, false);

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
            }
        }

        /// <summary>
        ///     Tests that adding five components stores all of them.
        /// </summary>
        [Fact]
        public void Add_Arity5_StoresAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7});

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(3f, entity.Get<Velocity>().X);
                Assert.Equal(5, entity.Get<Health>().Value);
                Assert.Equal(6, entity.Get<Armor>().Value);
                Assert.Equal(7, entity.Get<Damage>().Value);
            }
        }

        /// <summary>
        ///     Tests that removing five components makes all of them no longer present.
        /// </summary>
        [Fact]
        public void Remove_Arity5_RemovesAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7});

                entity.Remove<Position, Velocity, Health, Armor, Damage>();

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
            }
        }

        /// <summary>
        ///     Tests that adding five components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Add_Arity5_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                scene.EnterDisallowState();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7});
                scene.ExitDisallowState(null, false);

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
            }
        }

        /// <summary>
        ///     Tests that removing five components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Remove_Arity5_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7});

                scene.EnterDisallowState();
                entity.Remove<Position, Velocity, Health, Armor, Damage>();
                scene.ExitDisallowState(null, false);

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
            }
        }

        /// <summary>
        ///     Tests that adding six components stores all of them.
        /// </summary>
        [Fact]
        public void Add_Arity6_StoresAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"});

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
                Assert.True(entity.Has<TestComponent>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(3f, entity.Get<Velocity>().X);
                Assert.Equal(5, entity.Get<Health>().Value);
                Assert.Equal(6, entity.Get<Armor>().Value);
                Assert.Equal(7, entity.Get<Damage>().Value);
                Assert.Equal(8, entity.Get<TestComponent>().Value);
            }
        }

        /// <summary>
        ///     Tests that removing six components makes all of them no longer present.
        /// </summary>
        [Fact]
        public void Remove_Arity6_RemovesAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"});

                entity.Remove<Position, Velocity, Health, Armor, Damage, TestComponent>();

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<TestComponent>());
            }
        }

        /// <summary>
        ///     Tests that adding six components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Add_Arity6_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                scene.EnterDisallowState();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"});
                scene.ExitDisallowState(null, false);

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
                Assert.True(entity.Has<TestComponent>());
            }
        }

        /// <summary>
        ///     Tests that removing six components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Remove_Arity6_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"});

                scene.EnterDisallowState();
                entity.Remove<Position, Velocity, Health, Armor, Damage, TestComponent>();
                scene.ExitDisallowState(null, false);

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<TestComponent>());
            }
        }

        /// <summary>
        ///     Tests that adding seven components stores all of them.
        /// </summary>
        [Fact]
        public void Add_Arity7_StoresAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9});

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
                Assert.True(entity.Has<TestComponent>());
                Assert.True(entity.Has<TestComponent2>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(3f, entity.Get<Velocity>().X);
                Assert.Equal(5, entity.Get<Health>().Value);
                Assert.Equal(6, entity.Get<Armor>().Value);
                Assert.Equal(7, entity.Get<Damage>().Value);
                Assert.Equal(8, entity.Get<TestComponent>().Value);
                Assert.Equal(9, entity.Get<TestComponent2>().Value);
            }
        }

        /// <summary>
        ///     Tests that removing seven components makes all of them no longer present.
        /// </summary>
        [Fact]
        public void Remove_Arity7_RemovesAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9});

                entity.Remove<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2>();

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<TestComponent>());
                Assert.False(entity.Has<TestComponent2>());
            }
        }

        /// <summary>
        ///     Tests that adding seven components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Add_Arity7_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                scene.EnterDisallowState();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9});
                scene.ExitDisallowState(null, false);

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
                Assert.True(entity.Has<TestComponent>());
                Assert.True(entity.Has<TestComponent2>());
            }
        }

        /// <summary>
        ///     Tests that removing seven components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Remove_Arity7_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9});

                scene.EnterDisallowState();
                entity.Remove<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2>();
                scene.ExitDisallowState(null, false);

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<TestComponent>());
                Assert.False(entity.Has<TestComponent2>());
            }
        }

        /// <summary>
        ///     Tests that adding eight components stores all of them.
        /// </summary>
        [Fact]
        public void Add_Arity8_StoresAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9},
                    new Alis.Core.Ecs.Test.Models.Transform {X = 10, Y = 11, Rotation = 12});

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
                Assert.True(entity.Has<TestComponent>());
                Assert.True(entity.Has<TestComponent2>());
                Assert.True(entity.Has<Alis.Core.Ecs.Test.Models.Transform>());
                Assert.Equal(1f, entity.Get<Position>().X);
                Assert.Equal(3f, entity.Get<Velocity>().X);
                Assert.Equal(5, entity.Get<Health>().Value);
                Assert.Equal(6, entity.Get<Armor>().Value);
                Assert.Equal(7, entity.Get<Damage>().Value);
                Assert.Equal(8, entity.Get<TestComponent>().Value);
                Assert.Equal(9, entity.Get<TestComponent2>().Value);
                Assert.Equal(10f, entity.Get<Alis.Core.Ecs.Test.Models.Transform>().X);
            }
        }

        /// <summary>
        ///     Tests that removing eight components makes all of them no longer present.
        /// </summary>
        [Fact]
        public void Remove_Arity8_RemovesAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9},
                    new Alis.Core.Ecs.Test.Models.Transform {X = 10, Y = 11, Rotation = 12});

                entity.Remove<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2,
                    Alis.Core.Ecs.Test.Models.Transform>();

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<TestComponent>());
                Assert.False(entity.Has<TestComponent2>());
                Assert.False(entity.Has<Alis.Core.Ecs.Test.Models.Transform>());
            }
        }

        /// <summary>
        ///     Tests that adding eight components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Add_Arity8_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                scene.EnterDisallowState();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9},
                    new Alis.Core.Ecs.Test.Models.Transform {X = 10, Y = 11, Rotation = 12});
                scene.ExitDisallowState(null, false);

                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Armor>());
                Assert.True(entity.Has<Damage>());
                Assert.True(entity.Has<TestComponent>());
                Assert.True(entity.Has<TestComponent2>());
                Assert.True(entity.Has<Alis.Core.Ecs.Test.Models.Transform>());
            }
        }

        /// <summary>
        ///     Tests that removing eight components while structural changes are disallowed applies on exit.
        /// </summary>
        [Fact]
        public void Remove_Arity8_WhileStructuralChangesDisallowed_AppliesOnExit()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Add(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6},
                    new Damage {Value = 7}, new TestComponent {Value = 8, Name = "tc"}, new TestComponent2 {Value = 9},
                    new Alis.Core.Ecs.Test.Models.Transform {X = 10, Y = 11, Rotation = 12});

                scene.EnterDisallowState();
                entity.Remove<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2,
                    Alis.Core.Ecs.Test.Models.Transform>();
                scene.ExitDisallowState(null, false);

                Assert.False(entity.Has<Position>());
                Assert.False(entity.Has<Velocity>());
                Assert.False(entity.Has<Health>());
                Assert.False(entity.Has<Armor>());
                Assert.False(entity.Has<Damage>());
                Assert.False(entity.Has<TestComponent>());
                Assert.False(entity.Has<TestComponent2>());
                Assert.False(entity.Has<Alis.Core.Ecs.Test.Models.Transform>());
            }
        }
    }
}