// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectQueryEnumeratorTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for GameObjectQueryEnumerator&lt;T...&gt; arities 1..8.
    /// </summary>
    public class GameObjectQueryEnumeratorTest
    {
        /// <summary>
        /// Tests that game object query enumerator arity 1 is value type and by ref like
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Arity1_IsValueTypeAndByRefLike()
        {
            Assert.True(typeof(GameObjectQueryEnumerator<Position>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position>).IsByRefLike);
        }

        /// <summary>
        /// Tests that game object query enumerator arity 8 is value type and by ref like
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Arity8_IsValueTypeAndByRefLike()
        {
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsByRefLike);
        }
        
        /// <summary>
        /// Tests that game object query enumerator constructor and dispose toggle structural changes
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_ConstructorAndDispose_ToggleStructuralChanges()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            Query query = scene.Query<With<Position>>();

            Assert.True(scene.AllowStructualChanges);

            Ecs.Systems.GameObjectQueryEnumerator<Position>.QueryEnumerable enumerable = query.EnumerateWithEntities<Position>();
            using Ecs.Systems.GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();

            Assert.False(scene.AllowStructualChanges);
        }

        /// <summary>
        /// Tests that game object query enumerator foreach completes exits disallow state
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_ForeachCompletes_ExitsDisallowState()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 3, VY = 4});
            Query query = scene.Query<With<Position>, With<Velocity>>();

            Assert.True(scene.AllowStructualChanges);

            int count = 0;
            foreach ((GameObject _, Ref<Position> _, Ref<Velocity> _) in query.EnumerateWithEntities<Position, Velocity>())
            {
                count++;
            }

            Assert.Equal(1, count);
            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        /// Tests that game object query enumerator foreach break still exits disallow state
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_ForeachBreak_StillExitsDisallowState()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 1, VY = 1}, new Health {Value = 10});
            scene.Create(new Position {X = 3, Y = 4}, new Velocity {VX = 2, VY = 2}, new Health {Value = 20});
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            int count = 0;
            foreach ((GameObject _, Ref<Position> _, Ref<Velocity> _, Ref<Health> _) in query.EnumerateWithEntities<Position, Velocity, Health>())
            {
                count++;
                break;
            }

            Assert.Equal(1, count);
            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        /// Tests that game object query enumerator move next empty query returns false
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_MoveNext_EmptyQuery_ReturnsFalse()
        {
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>>();
            Ecs.Systems.GameObjectQueryEnumerator<Position>.QueryEnumerable enumerable = query.EnumerateWithEntities<Position>();

            using Ecs.Systems.GameObjectQueryEnumerator<Position> enumerator = enumerable.GetEnumerator();
            bool moved = enumerator.MoveNext();

            Assert.False(moved);
            Assert.False(scene.AllowStructualChanges);
        }
        

        /// <summary>
        /// Tests that game object query enumerator move next and current arity 1 works as expected
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_MoveNextAndCurrent_Arity1_WorksAsExpected()
        {
            using Scene scene = new Scene();
            GameObject created = scene.Create(new Position {X = 42, Y = 84});
            Query query = scene.Query<With<Position>>();
            using Ecs.Systems.GameObjectQueryEnumerator<Position> enumerator = query.EnumerateWithEntities<Position>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Ecs.Systems.GameObjectRefTuple<Position> current = enumerator.Current;
            Assert.True(current.GameObject.IsAlive);
            Assert.Equal(created, current.GameObject);
            Assert.Equal(42, current.Item1.Value.X);
            Assert.Equal(84, current.Item1.Value.Y);
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that game object query enumerator current arity 2 maps entity and refs
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Current_Arity2_MapsEntityAndRefs()
        {
            using Scene scene = new Scene();
            GameObject created = scene.Create(new Position {X = 10, Y = 20}, new Velocity {VX = 30, VY = 40});
            Query query = scene.Query<With<Position>, With<Velocity>>();
            using GameObjectQueryEnumerator<Position, Velocity> enumerator = query.EnumerateWithEntities<Position, Velocity>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            GameObjectRefTuple<Position, Velocity> current = enumerator.Current;
            Assert.Equal(created, current.GameObject);
            Assert.Equal(10, current.Item1.Value.X);
            Assert.Equal(30, current.Item2.Value.VX);
        }

        /// <summary>
        /// Tests that game object query enumerator arity 4 current contains all components
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Arity4_CurrentContainsAllComponents()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();

            foreach ((GameObject entity, Ref<Position> p, Ref<Velocity> v, Ref<Health> h, Ref<Transform> t) in query.EnumerateWithEntities<Position, Velocity, Health, Transform>())
            {
                Assert.True(entity.IsAlive);
                Assert.Equal(1, p.Value.X);
                Assert.Equal(3, v.Value.VX);
                Assert.Equal(5, h.Value.Value);
                Assert.Equal(8, t.Value.Rotation);
            }
        }

        /// <summary>
        /// Tests that game object query enumerator arity 5 can enumerate all components
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Arity5_CanEnumerateAllComponents()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();

            int count = 0;
            foreach ((GameObject _, Ref<Position> _, Ref<Velocity> _, Ref<Health> _, Ref<Transform> _, Ref<TestComponent> test) in query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent>())
            {
                Assert.Equal(9, test.Value.Value);
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        /// Tests that game object query enumerator arity 6 can enumerate all components
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Arity6_CanEnumerateAllComponents()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {X = 10, Y = 11}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            int count = 0;
            foreach ((GameObject _, Ref<Position> _, Ref<Velocity> _, Ref<Health> _, Ref<Transform> _, Ref<TestComponent> _, Ref<AnotherComponent> another) in query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                Assert.Equal(10, another.Value.X);
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        /// Tests that game object query enumerator arity 7 can enumerate all components
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Arity7_CanEnumerateAllComponents()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {X = 10, Y = 11},
                new Damage {Amount = 12}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>>();

            int count = 0;
            foreach ((GameObject _, Ref<Position> _, Ref<Velocity> _, Ref<Health> _, Ref<Transform> _, Ref<TestComponent> _, Ref<AnotherComponent> _, Ref<Damage> damage) in query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>())
            {
                Assert.Equal(12, damage.Value.Amount);
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        /// Tests that game object query enumerator arity 8 can enumerate all components
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_Arity8_CanEnumerateAllComponents()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {X = 10, Y = 11},
                new Damage {Amount = 12},
                new Armor {Defense = 13}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();

            int count = 0;
            foreach ((GameObject _, Ref<Position> _, Ref<Velocity> _, Ref<Health> _, Ref<Transform> _, Ref<TestComponent> _, Ref<AnotherComponent> _, Ref<Damage> _, Ref<Armor> armor) in query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                Assert.Equal(13, armor.Value.Defense);
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        /// Tests that game object query enumerator iterates across multiple archetypes
        /// </summary>
        [Fact]
        public void GameObjectQueryEnumerator_IteratesAcrossMultipleArchetypes()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Position {X = 2, Y = 2}, new Velocity {VX = 3, VY = 3});
            Query query = scene.Query<With<Position>>();

            int count = 0;
            float sumX = 0;
            foreach ((GameObject _, Ref<Position> pos) in query.EnumerateWithEntities<Position>())
            {
                count++;
                sumX += pos.Value.X;
            }

            Assert.Equal(2, count);
            Assert.Equal(3, sumX);
        }
    }
}

