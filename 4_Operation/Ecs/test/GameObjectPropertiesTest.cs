// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectPropertiesTest.cs
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
    ///     Tests for the public properties of <see cref="GameObject" />:
    ///     <see cref="GameObject.IsAlive" />, <see cref="GameObject.IsNull" />,
    ///     <see cref="GameObject.Scene" />, <see cref="GameObject.ComponentTypes" />
    ///     and <see cref="GameObject.Type" />.
    /// </summary>
    public class GameObjectPropertiesTest
    {
        // ─────────────────────────────────────────────────────────────────────
        // IsAlive
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     IsAlive returns true immediately after the entity is created.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsTrue_ForNewlyCreatedEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 1, Y = 2 });

            // Assert
            Assert.True(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive returns false after the entity has been deleted.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsFalse_AfterDeletion()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 3, Y = 4 });

            // Act
            gameObject.Delete();

            // Assert
            Assert.False(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive returns false for the default (null) GameObject.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsFalse_ForDefaultGameObject()
        {
            // Arrange
            GameObject gameObject = default(GameObject);

            // Assert
            Assert.False(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive returns false for <see cref="GameObject.Null" />.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsFalse_ForGameObjectNull()
        {
            // Arrange
            GameObject gameObject = GameObject.Null;

            // Assert
            Assert.False(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive stays true as long as the entity has not been deleted,
        ///     even after adding and removing components.
        /// </summary>
        [Fact]
        public void IsAlive_RemainsTrue_AfterAddAndRemoveComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            gameObject.Add(new Velocity { X = 1, Y = 1 });
            gameObject.Remove<Velocity>();

            // Assert
            Assert.True(gameObject.IsAlive);
        }

        // ─────────────────────────────────────────────────────────────────────
        // IsNull
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     IsNull returns true for the default-constructed GameObject.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsTrue_ForDefaultConstructor()
        {
            // Arrange
            GameObject gameObject = new GameObject();

            // Assert
            Assert.True(gameObject.IsNull);
        }

        /// <summary>
        ///     IsNull returns true for <c>default(GameObject)</c>.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsTrue_ForDefaultKeyword()
        {
            // Arrange
            GameObject gameObject = default(GameObject);

            // Assert
            Assert.True(gameObject.IsNull);
        }

        /// <summary>
        ///     IsNull returns true for <see cref="GameObject.Null" />.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsTrue_ForStaticNullProperty()
        {
            // Assert
            Assert.True(GameObject.Null.IsNull);
        }

        /// <summary>
        ///     IsNull returns false for a real entity created inside a scene.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsFalse_ForCreatedEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 5 });

            // Assert
            Assert.False(gameObject.IsNull);
        }

        /// <summary>
        ///     IsNull remains false after the entity is deleted (deletion does not
        ///     reset the packed value to zero).
        /// </summary>
        [Fact]
        public void IsNull_ReturnsFalse_EvenAfterDeletion()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 7 });

            // Act
            gameObject.Delete();

            // Assert – IsNull is about the packed bits, not liveness
            Assert.False(gameObject.IsNull);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Scene
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Scene returns the same scene instance that was used to create the entity.
        /// </summary>
        [Fact]
        public void Scene_ReturnsSameSceneInstance_ThatCreatedEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 1, Y = 1 });

            // Assert
            Assert.Equal(scene, gameObject.Scene);
        }

        /// <summary>
        ///     Scene throws <see cref="InvalidOperationException" /> for the null GameObject.
        /// </summary>
        [Fact]
        public void Scene_Throws_ForNullGameObject()
        {
            // Arrange
            GameObject gameObject = GameObject.Null;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => { _ = gameObject.Scene; });
        }

        /// <summary>
        ///     Scene returns a non-null value for a live entity.
        /// </summary>
        [Fact]
        public void Scene_IsNotNull_ForLiveEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Velocity { X = 2, Y = 3 });

            // Assert
            Assert.NotNull(gameObject.Scene);
        }

        // ─────────────────────────────────────────────────────────────────────
        // ComponentTypes
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     ComponentTypes contains exactly the single component type the entity was created with.
        /// </summary>
        [Fact]
        public void ComponentTypes_ContainsSingleComponentType_WhenCreatedWithOneComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            var types = gameObject.ComponentTypes;

            // Assert
            Assert.Contains(Component<Position>.Id, types);
        }

        /// <summary>
        ///     ComponentTypes contains all component types when the entity was created with several.
        /// </summary>
        [Fact]
        public void ComponentTypes_ContainsAllComponentTypes_WhenCreatedWithMultiple()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Position { X = 0, Y = 0 },
                new Velocity { X = 1, Y = 1 },
                new Health { Value = 100 });

            // Act
            var types = gameObject.ComponentTypes;

            // Assert
            Assert.Contains(Component<Position>.Id, types);
            Assert.Contains(Component<Velocity>.Id, types);
            Assert.Contains(Component<Health>.Id, types);
        }

        /// <summary>
        ///     ComponentTypes updates after a new component is added.
        /// </summary>
        [Fact]
        public void ComponentTypes_Updates_AfterComponentAdded()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 5, Y = 5 });

            // Act
            gameObject.Add(new Velocity { X = 1, Y = 1 });

            // Assert
            Assert.Contains(Component<Velocity>.Id, gameObject.ComponentTypes);
        }

        /// <summary>
        ///     ComponentTypes no longer contains a removed component.
        /// </summary>
        [Fact]
        public void ComponentTypes_DoesNotContain_RemovedComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 });

            // Act
            gameObject.Remove<Velocity>();

            // Assert
            Assert.DoesNotContain(Component<Velocity>.Id, gameObject.ComponentTypes);
            Assert.Contains(Component<Position>.Id, gameObject.ComponentTypes);
        }

        /// <summary>
        ///     ComponentTypes throws for a dead (deleted) entity.
        /// </summary>
        [Fact]
        public void ComponentTypes_Throws_ForDeadEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 1, Y = 1 });
            gameObject.Delete();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => { _ = gameObject.ComponentTypes; });
        }

        // ─────────────────────────────────────────────────────────────────────
        // Type
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Type matches <see cref="GameObject.EntityTypeOf" /> for the same component set.
        /// </summary>
        [Fact]
        public void Type_MatchesEntityTypeOf_ForSameComponentSet()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 0, Y = 0 });

            GameObjectType expected = GameObject.EntityTypeOf([Component<Position>.Id]);

            // Assert
            Assert.Equal(expected, gameObject.Type);
        }

        /// <summary>
        ///     Two entities with the same component set share the same <see cref="GameObjectType" />.
        /// </summary>
        [Fact]
        public void Type_IsSame_ForEntitiesWithIdenticalComponentSets()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject a = scene.Create(new Velocity { X = 1, Y = 1 });
            GameObject b = scene.Create(new Velocity { X = 2, Y = 2 });

            // Assert
            Assert.Equal(a.Type, b.Type);
        }

        /// <summary>
        ///     Two entities with different component sets have different <see cref="GameObjectType" />s.
        /// </summary>
        [Fact]
        public void Type_IsDifferent_ForEntitiesWithDifferentComponentSets()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject a = scene.Create(new Position { X = 1, Y = 1 });
            GameObject b = scene.Create(new Velocity { X = 1, Y = 1 });

            // Assert
            Assert.NotEqual(a.Type, b.Type);
        }

        /// <summary>
        ///     Type changes after a component is added.
        /// </summary>
        [Fact]
        public void Type_Changes_AfterComponentAdded()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 0, Y = 0 });
            GameObjectType typeBefore = gameObject.Type;

            // Act
            gameObject.Add(new Velocity { X = 1, Y = 1 });

            // Assert
            Assert.NotEqual(typeBefore, gameObject.Type);
        }

        /// <summary>
        ///     Type changes after a component is removed.
        /// </summary>
        [Fact]
        public void Type_Changes_AfterComponentRemoved()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Position { X = 0, Y = 0 },
                new Velocity { X = 1, Y = 1 });

            GameObjectType typeBefore = gameObject.Type;

            // Act
            gameObject.Remove<Velocity>();

            // Assert
            Assert.NotEqual(typeBefore, gameObject.Type);
        }

        /// <summary>
        ///     Type throws for a dead (deleted) entity.
        /// </summary>
        [Fact]
        public void Type_Throws_ForDeadEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position { X = 1, Y = 1 });
            gameObject.Delete();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => { _ = gameObject.Type; });
        }
    }
}

