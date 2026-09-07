// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateArity9CoverageTests.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests the arity-9 Update runner (Update&lt;TComp, TArg1..TArg8&gt;)
    ///     and the corresponding UpdateLoop.Run&lt;TComp, TArg1..TArg8&gt; loop body.
    /// </summary>
    public class UpdateArity9CoverageTests
    {
        /// <summary>
        ///     Tests that the arity-9 non-range Run method processes all entities
        ///     via scene.Update and invokes the component update.
        /// </summary>
        [Fact]
        public void Update_Arity9_SceneUpdate_ProcessesAllEntities()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity1 = scene.Create(
                    new Update8Component {CallCount = 0},
                    new Position {X = 1, Y = 2},
                    new Velocity {X = 10, Y = 20},
                    new Health {Value = 100},
                    new Armor {Value = 50},
                    new Damage {Value = 5},
                    new Transform {X = 0, Y = 0, Rotation = 0},
                    new TestComponent {Value = 42}
                );
                entity1.Add(new AnotherComponent {Data = 7, Y = 3});

                GameObject entity2 = scene.Create(
                    new Update8Component {CallCount = 0},
                    new Position {X = 3, Y = 4},
                    new Velocity {X = 1, Y = 2},
                    new Health {Value = 80},
                    new Armor {Value = 30},
                    new Damage {Value = 10},
                    new Transform {X = 0, Y = 0, Rotation = 0},
                    new TestComponent {Value = 9}
                );
                entity2.Add(new AnotherComponent {Data = 2, Y = 1});

                scene.Update();

                Assert.Equal(1, entity1.Get<Update8Component>().CallCount);
                Assert.Equal(1, entity2.Get<Update8Component>().CallCount);
                Assert.Equal(11, entity1.Get<Position>().X);
                Assert.Equal(22, entity1.Get<Position>().Y);
                Assert.Equal(4, entity2.Get<Position>().X);
                Assert.Equal(6, entity2.Get<Position>().Y);
            }
        }

        /// <summary>
        ///     Tests that the arity-9 non-range Run mutates all 8 argument components
        ///     including AnotherComponent (the 9th component added via Add).
        /// </summary>
        [Fact]
        public void Update_Arity9_SceneUpdate_MutatesAllArgs()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new Update8Component {CallCount = 0},
                    new Position {X = 0, Y = 0},
                    new Velocity {X = 5, Y = 10},
                    new Health {Value = 100},
                    new Armor {Value = 20},
                    new Damage {Value = 10},
                    new Transform {X = 0, Y = 0, Rotation = 0},
                    new TestComponent {Value = 1}
                );
                entity.Add(new AnotherComponent {Data = 0, Y = 0});

                scene.Update();

                Assert.Equal(1, entity.Get<Update8Component>().CallCount);
                Assert.Equal(5, entity.Get<Position>().X);
                Assert.Equal(10, entity.Get<Position>().Y);
                Assert.Equal(99, entity.Get<Health>().Value);
                Assert.Equal(22, entity.Get<Armor>().Value);
                Assert.Equal(11, entity.Get<Damage>().Value);
                Assert.Equal(2, entity.Get<Transform>().Rotation);
                Assert.Equal(2, entity.Get<TestComponent>().Value);
                Assert.Equal(1, entity.Get<AnotherComponent>().Data);
                Assert.Equal(1, entity.Get<AnotherComponent>().Y);
            }
        }

        /// <summary>
        ///     Tests that the arity-9 Update runs across two frames, verifying the loop body iterates correctly.
        /// </summary>
        [Fact]
        public void Update_Arity9_TwoFrames_AccumulatesChanges()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(
                    new Update8Component {CallCount = 0},
                    new Position {X = 0, Y = 0},
                    new Velocity {X = 3, Y = 7},
                    new Health {Value = 50},
                    new Armor {Value = 10},
                    new Damage {Value = 2},
                    new Transform {X = 0, Y = 0, Rotation = 0},
                    new TestComponent {Value = 1}
                );
                entity.Add(new AnotherComponent {Data = 0, Y = 0});

                scene.Update();
                scene.Update();

                Assert.Equal(2, entity.Get<Update8Component>().CallCount);
                Assert.Equal(6, entity.Get<Position>().X);
                Assert.Equal(14, entity.Get<Position>().Y);
                Assert.Equal(48, entity.Get<Health>().Value);
                Assert.Equal(14, entity.Get<Armor>().Value);
                Assert.Equal(4, entity.Get<Damage>().Value);
                Assert.Equal(4, entity.Get<Transform>().Rotation);
                Assert.Equal(4, entity.Get<TestComponent>().Value);
                Assert.Equal(2, entity.Get<AnotherComponent>().Data);
                Assert.Equal(2, entity.Get<AnotherComponent>().Y);
            }
        }
    }
}
