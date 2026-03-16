// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensionsDeconstructExtendedTest.cs
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
    ///     The game object extensions deconstruct extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for the deconstruction functionality of GameObjectExtensions,
    ///     validating component reference access patterns.
    /// </remarks>
    public class GameObjectExtensionsDeconstructExtendedTest
    {
        /// <summary>
        ///     Tests that single component deconstruction works
        /// </summary>
        /// <remarks>
        ///     Validates that a single component can be deconstructed from a GameObject.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_SingleComponentWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            Position originalPos = new Position {X = 42, Y = 84};
            GameObject entity = scene.Create(originalPos);

            // Act
            entity.Deconstruct(out Ref<Position> pos);

            // Assert
            Assert.Equal(42, pos.Value.X);
            Assert.Equal(84, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that deconstruction throws on missing component
        /// </summary>
        /// <remarks>
        ///     Validates that deconstruction throws an exception if the required component is missing.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_ThrowsOnMissingComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => { entity.Deconstruct(out Ref<Position> pos); });
        }

        /// <summary>
        ///     Tests that deconstructed reference can be modified
        /// </summary>
        /// <remarks>
        ///     Validates that deconstructed component references can be modified.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_DeconstructedReferenceCanBeModified()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10, Y = 20});

            // Act
            entity.Deconstruct(out Ref<Position> pos);
            pos.Value.X = 42;
            pos.Value.Y = 84;

            // Assert
            Assert.True(entity.TryGet(out Ref<Position> modifiedPos));
            Assert.Equal(42, modifiedPos.Value.X);
            Assert.Equal(84, modifiedPos.Value.Y);
        }

        /// <summary>
        ///     Tests that deconstruction works with dead entity
        /// </summary>
        /// <remarks>
        ///     Validates that deconstruction on a dead entity throws an exception.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_ThrowsOnDeadEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => { entity.Deconstruct(out Ref<Position> pos); });
        }

        /// <summary>
        ///     Tests that multiple entities can be deconstructed independently
        /// </summary>
        /// <remarks>
        ///     Validates that deconstruction works independently for different entities.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_MultipleEntitiesCanBeDeconstructed()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});

            // Act
            entity1.Deconstruct(out Ref<Position> pos1);
            entity2.Deconstruct(out Ref<Position> pos2);

            // Assert
            Assert.Equal(1, pos1.Value.X);
            Assert.Equal(3, pos2.Value.X);
        }

        /// <summary>
        ///     Tests that deconstruction provides read-write access
        /// </summary>
        /// <remarks>
        ///     Validates that deconstructed references provide full read-write access.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_ProvidesReadWriteAccess()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 0, Y = 0});

            // Act
            entity.Deconstruct(out Ref<Position> pos);
            int originalX = (int) pos.Value.X;
            pos.Value.X = 100;
            int newX = (int) pos.Value.X;

            // Assert
            Assert.Equal(0, originalX);
            Assert.Equal(100, newX);
            Assert.True(entity.TryGet(out Ref<Position> stored));
            Assert.Equal(100, stored.Value.X);
        }

        /// <summary>
        ///     Tests that deconstruction works in loops
        /// </summary>
        /// <remarks>
        ///     Validates that deconstruction can be used in loop patterns.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_WorksInLoops()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[5];
            for (int i = 0; i < 5; i++)
            {
                entities[i] = scene.Create(new Position {X = i, Y = i * 2});
            }

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                entities[i].Deconstruct(out Ref<Position> pos);
                Assert.Equal(i, pos.Value.X);
                Assert.Equal(i * 2, pos.Value.Y);
            }
        }

        /// <summary>
        ///     Tests that deconstruction works with modified components
        /// </summary>
        /// <remarks>
        ///     Validates that deconstruction reflects any modifications to the component.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_WorksWithModifiedComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            Position originalPos = new Position {X = 10, Y = 20};
            GameObject entity = scene.Create(originalPos);

            // Act
            if (entity.TryGet(out Ref<Position> getPos))
            {
                getPos.Value.X = 50;
            }

            entity.Deconstruct(out Ref<Position> deconstructPos);

            // Assert
            Assert.Equal(50, deconstructPos.Value.X);
        }

        /// <summary>
        ///     Tests that deconstruction provides stable reference
        /// </summary>
        /// <remarks>
        ///     Validates that the deconstructed reference points to the same entity component.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_ProvidesStableReference()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 42, Y = 84});

            // Act
            entity.Deconstruct(out Ref<Position> pos1);
            entity.Deconstruct(out Ref<Position> pos2);

            // Assert
            Assert.Equal(pos1.Value.X, pos2.Value.X);
            Assert.Equal(pos1.Value.Y, pos2.Value.Y);
        }

        /// <summary>
        ///     Tests that deconstruction with null entity throws
        /// </summary>
        /// <remarks>
        ///     Validates that deconstruction on a null entity throws appropriately.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_ThrowsOnNullEntity()
        {
            // Arrange
            GameObject nullEntity = GameObject.Null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => { nullEntity.Deconstruct(out Ref<Position> pos); });
        }

        /// <summary>
        ///     Tests that deconstruction works after component addition
        /// </summary>
        /// <remarks>
        ///     Validates that newly added components can be deconstructed.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_WorksAfterComponentAddition()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add(new Position {X = 99, Y = 100});
            entity.Deconstruct(out Ref<Position> pos);

            // Assert
            Assert.Equal(99, pos.Value.X);
            Assert.Equal(100, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that deconstruction fails after component removal
        /// </summary>
        /// <remarks>
        ///     Validates that removed components cannot be deconstructed.
        /// </remarks>
        [Fact]
        public void GameObjectExtensionsDeconstruct_FailsAfterComponentRemoval()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            // Act
            entity.Remove<Position>();

            // Assert
            Assert.Throws<NullReferenceException>(() => { entity.Deconstruct(out Ref<Position> pos); });
        }

        /// <summary>
        ///     Tests that game object extensions deconstruct two components works
        /// </summary>
        [Fact]
        public void GameObjectExtensionsDeconstruct_TwoComponents_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            entity.Deconstruct(out Ref<Position> pos, out Ref<Velocity> vel);

            Assert.Equal(1, pos.Value.X);
            Assert.Equal(4, vel.Value.Y);
            vel.Value.X = 9;
            Assert.Equal(9, entity.Get<Velocity>().X);
        }

        /// <summary>
        ///     Tests that game object extensions deconstruct three components works
        /// </summary>
        [Fact]
        public void GameObjectExtensionsDeconstruct_ThreeComponents_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5});

            entity.Deconstruct(out Ref<Position> pos, out Ref<Velocity> vel, out Ref<Health> hp);

            Assert.Equal(2, pos.Value.Y);
            Assert.Equal(3, vel.Value.X);
            Assert.Equal(5, hp.Value.Value);
        }

        /// <summary>
        ///     Tests that game object extensions deconstruct four components works
        /// </summary>
        [Fact]
        public void GameObjectExtensionsDeconstruct_FourComponents_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8});

            entity.Deconstruct(out Ref<Position> pos, out Ref<Velocity> vel, out Ref<Health> hp, out Ref<Transform> tr);

            Assert.Equal(1, pos.Value.X);
            Assert.Equal(4, vel.Value.Y);
            Assert.Equal(5, hp.Value.Value);
            Assert.Equal(8, tr.Value.Rotation);
        }

        /// <summary>
        ///     Tests that game object extensions deconstruct five components works
        /// </summary>
        [Fact]
        public void GameObjectExtensionsDeconstruct_FiveComponents_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "a"});

            entity.Deconstruct(
                out Ref<Position> pos,
                out Ref<Velocity> vel,
                out Ref<Health> hp,
                out Ref<Transform> tr,
                out Ref<TestComponent> tc);

            Assert.Equal(1, pos.Value.X);
            Assert.Equal(3, vel.Value.X);
            Assert.Equal(5, hp.Value.Value);
            Assert.Equal(6, tr.Value.X);
            Assert.Equal(9, tc.Value.Value);
        }

        /// <summary>
        ///     Tests that game object extensions deconstruct six components works
        /// </summary>
        [Fact]
        public void GameObjectExtensionsDeconstruct_SixComponents_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "a"},
                new AnotherComponent {Data = 10, Y = 11, Name = "b"});

            entity.Deconstruct(
                out Ref<Position> pos,
                out Ref<Velocity> vel,
                out Ref<Health> hp,
                out Ref<Transform> tr,
                out Ref<TestComponent> tc,
                out Ref<AnotherComponent> ac);

            Assert.Equal(2, pos.Value.Y);
            Assert.Equal(4, vel.Value.Y);
            Assert.Equal(5, hp.Value.Value);
            Assert.Equal(8, tr.Value.Rotation);
            Assert.Equal("a", tc.Value.Name);
            Assert.Equal(10, ac.Value.Data);
        }

        /// <summary>
        ///     Tests that game object extensions deconstruct seven components works
        /// </summary>
        [Fact]
        public void GameObjectExtensionsDeconstruct_SevenComponents_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "a"},
                new AnotherComponent {Data = 10, Y = 11, Name = "b"},
                new Damage {Value = 12});

            entity.Deconstruct(
                out Ref<Position> pos,
                out Ref<Velocity> vel,
                out Ref<Health> hp,
                out Ref<Transform> tr,
                out Ref<TestComponent> tc,
                out Ref<AnotherComponent> ac,
                out Ref<Damage> dmg);

            Assert.Equal(1, pos.Value.X);
            Assert.Equal(3, vel.Value.X);
            Assert.Equal(5, hp.Value.Value);
            Assert.Equal(8, tr.Value.Rotation);
            Assert.Equal(9, tc.Value.Value);
            Assert.Equal(11, ac.Value.Y);
            Assert.Equal(12, dmg.Value.Value);
        }

        /// <summary>
        ///     Tests that game object extensions deconstruct eight components works
        /// </summary>
        [Fact]
        public void GameObjectExtensionsDeconstruct_EightComponents_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "a"},
                new AnotherComponent {Data = 10, Y = 11, Name = "b"},
                new Damage {Value = 12},
                new Armor {Value = 13});

            entity.Deconstruct(
                out Ref<Position> pos,
                out Ref<Velocity> vel,
                out Ref<Health> hp,
                out Ref<Transform> tr,
                out Ref<TestComponent> tc,
                out Ref<AnotherComponent> ac,
                out Ref<Damage> dmg,
                out Ref<Armor> armor);

            Assert.Equal(2, pos.Value.Y);
            Assert.Equal(4, vel.Value.Y);
            Assert.Equal(5, hp.Value.Value);
            Assert.Equal(7, tr.Value.Y);
            Assert.Equal("a", tc.Value.Name);
            Assert.Equal("b", ac.Value.Name);
            Assert.Equal(12, dmg.Value.Value);
            Assert.Equal(13, armor.Value.Value);
        }
    }
}