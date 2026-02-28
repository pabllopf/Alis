// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="GameObject"/> struct which represents an entity reference
    ///     in the ECS system, containing a collection of components of unique types.
    /// </remarks>
    public class GameObjectTest
    {
        /// <summary>
        ///     Tests that game object can be created with default constructor
        /// </summary>
        /// <remarks>
        ///     Verifies that a GameObject can be created using the default constructor.
        /// </remarks>
        [Fact]
        public void GameObject_CanBeCreatedWithDefaultConstructor()
        {
            // Act
            GameObject gameObject = new GameObject();

            // Assert
            Assert.True(gameObject.IsNull);
        }

        /// <summary>
        ///     Tests that default game object is null
        /// </summary>
        /// <remarks>
        ///     Validates that a default GameObject is considered null.
        /// </remarks>
        [Fact]
        public void DefaultGameObject_IsNull()
        {
            // Arrange
            GameObject gameObject = default;

            // Assert
            Assert.True(gameObject.IsNull);
        }

        /// <summary>
        ///     Tests that game object null equals default
        /// </summary>
        /// <remarks>
        ///     Tests that GameObject.Null is equivalent to the default GameObject.
        /// </remarks>
        [Fact]
        public void GameObject_NullEqualsDefault()
        {
            // Arrange
            GameObject nullGameObject = GameObject.Null;
            GameObject defaultGameObject = default;

            // Assert
            Assert.Equal(nullGameObject, defaultGameObject);
        }

        /// <summary>
        ///     Tests that game object created in scene is not null
        /// </summary>
        /// <remarks>
        ///     Validates that a GameObject created in a Scene is not null.
        /// </remarks>
        [Fact]
        public void GameObject_CreatedInScene_IsNotNull()
        {
            // Arrange
            using Scene scene = new Scene();
            TestComponent component = new TestComponent { Value = 42, Name = "Test" };

            // Act
            GameObject gameObject = scene.Create(component);

            // Assert
            Assert.False(gameObject.IsNull);
        }

        /// <summary>
        ///     Tests that game object is alive after creation
        /// </summary>
        /// <remarks>
        ///     Tests that a newly created GameObject is considered alive.
        /// </remarks>
        [Fact]
        public void GameObject_IsAliveAfterCreation()
        {
            // Arrange
            using Scene scene = new Scene();
            TestComponent component = new TestComponent { Value = 10 };

            // Act
            GameObject gameObject = scene.Create(component);

            // Assert
            Assert.True(gameObject.IsAlive);
        }
        

        /// <summary>
        ///     Tests that game object can check if has component
        /// </summary>
        /// <remarks>
        ///     Tests that Has method correctly identifies if a GameObject has a component.
        /// </remarks>
        [Fact]
        public void GameObject_CanCheckIfHasComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 30 });

            // Assert
            Assert.True(gameObject.Has<TestComponent>());
        }

        /// <summary>
        ///     Tests that game object returns false for component it does not have
        /// </summary>
        /// <remarks>
        ///     Validates that Has method returns false for components not present.
        /// </remarks>
        [Fact]
        public void GameObject_ReturnsFalseForComponentItDoesNotHave()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 40 });

            // Assert
            Assert.False(gameObject.Has<AnotherComponent>());
        }

        /// <summary>
        ///     Tests that game object can get component
        /// </summary>
        /// <remarks>
        ///     Tests that Get method retrieves the correct component from a GameObject.
        /// </remarks>
        [Fact]
        public void GameObject_CanGetComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            TestComponent original = new TestComponent { Value = 100, Name = "Original" };
            GameObject gameObject = scene.Create(original);

            // Act
            ref TestComponent retrieved = ref gameObject.Get<TestComponent>();

            // Assert
            Assert.Equal(100, retrieved.Value);
            Assert.Equal("Original", retrieved.Name);
        }

        /// <summary>
        ///     Tests that game object can modify component through reference
        /// </summary>
        /// <remarks>
        ///     Validates that components can be modified through the reference returned by Get.
        /// </remarks>
        [Fact]
        public void GameObject_CanModifyComponentThroughReference()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 50 });

            // Act
            ref TestComponent component = ref gameObject.Get<TestComponent>();
            component.Value = 200;

            // Assert
            Assert.Equal(200, gameObject.Get<TestComponent>().Value);
        }

        /// <summary>
        ///     Tests that game object equals compares correctly
        /// </summary>
        /// <remarks>
        ///     Tests that Equals method correctly compares two GameObject instances.
        /// </remarks>
        [Fact]
        public void GameObject_EqualsComparesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new TestComponent { Value = 1 });
            GameObject entity2 = scene.Create(new TestComponent { Value = 2 });

            // Assert
            Assert.True(entity1.Equals(entity1));
            Assert.False(entity1.Equals(entity2));
        }

        /// <summary>
        ///     Tests that game object equality operator works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that the == operator works correctly for GameObject comparison.
        /// </remarks>
        [Fact]
        public void GameObject_EqualityOperatorWorksCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new TestComponent { Value = 10 });
            GameObject entity2 = entity1;
            GameObject entity3 = scene.Create(new TestComponent { Value = 20 });

            // Assert
            Assert.True(entity1 == entity2);
            Assert.False(entity1 == entity3);
        }

        /// <summary>
        ///     Tests that game object inequality operator works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that the != operator works correctly for GameObject comparison.
        /// </remarks>
        [Fact]
        public void GameObject_InequalityOperatorWorksCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new TestComponent { Value = 15 });
            GameObject entity2 = scene.Create(new TestComponent { Value = 25 });

            // Assert
            Assert.True(entity1 != entity2);
        }

        /// <summary>
        ///     Tests that game object get hash code returns consistent value
        /// </summary>
        /// <remarks>
        ///     Tests that GetHashCode returns the same value for the same GameObject.
        /// </remarks>
        [Fact]
        public void GameObject_GetHashCodeReturnsConsistentValue()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 99 });

            // Act
            int hashCode1 = gameObject.GetHashCode();
            int hashCode2 = gameObject.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        /// <summary>
        ///     Tests that game object equals handles null correctly
        /// </summary>
        /// <remarks>
        ///     Validates that Equals method handles null GameObject correctly.
        /// </remarks>
        [Fact]
        public void GameObject_EqualsHandlesNullCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 5 });
            GameObject nullGameObject = GameObject.Null;

            // Assert
            Assert.False(gameObject.Equals(nullGameObject));
        }

        /// <summary>
        ///     Tests that two null game objects are equal
        /// </summary>
        /// <remarks>
        ///     Tests that two null GameObjects are considered equal.
        /// </remarks>
        [Fact]
        public void TwoNullGameObjects_AreEqual()
        {
            // Arrange
            GameObject null1 = GameObject.Null;
            GameObject null2 = GameObject.Null;

            // Assert
            Assert.True(null1 == null2);
        }

        /// <summary>
        ///     Tests that game object try has returns true when component exists
        /// </summary>
        /// <remarks>
        ///     Tests that TryHas method returns true when the component exists.
        /// </remarks>
        [Fact]
        public void GameObject_TryHasReturnsTrueWhenComponentExists()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 77 });

            // Assert
            Assert.True(gameObject.TryHas<TestComponent>());
        }

        /// <summary>
        ///     Tests that game object try has returns false when component does not exist
        /// </summary>
        /// <remarks>
        ///     Tests that TryHas method returns false when the component doesn't exist.
        /// </remarks>
        [Fact]
        public void GameObject_TryHasReturnsFalseWhenComponentDoesNotExist()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 88 });

            // Assert
            Assert.False(gameObject.TryHas<AnotherComponent>());
        }
        

        /// <summary>
        ///     Tests that game object is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that GameObject is a value type (struct) with value semantics.
        /// </remarks>
        [Fact]
        public void GameObject_IsValueType()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new TestComponent { Value = 1 });
            GameObject entity2 = entity1;

            // Assert - Both should refer to the same entity (value equality)
            Assert.Equal(entity1, entity2);
        }

        /// <summary>
        ///     Tests that game object can be used in collections
        /// </summary>
        /// <remarks>
        ///     Tests that GameObject can be stored and retrieved from collections.
        /// </remarks>
        [Fact]
        public void GameObject_CanBeUsedInCollections()
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new System.Collections.Generic.List<GameObject>();

            // Act
            for (int i = 0; i < 5; i++)
            {
                entities.Add(scene.Create(new TestComponent { Value = i }));
            }

            // Assert
            Assert.Equal(5, entities.Count);
            foreach (var entity in entities)
            {
                Assert.False(entity.IsNull);
            }
        }

        /// <summary>
        ///     Tests that game object equals object handles different types
        /// </summary>
        /// <remarks>
        ///     Tests that Equals(object) correctly handles different object types.
        /// </remarks>
        [Fact]
        public void GameObject_EqualsObjectHandlesDifferentTypes()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 100 });
            object differentType = "not a GameObject";

            // Assert
            Assert.False(gameObject.Equals(differentType));
        }

        /// <summary>
        ///     Tests that game object can add component after creation
        /// </summary>
        /// <remarks>
        ///     Tests that components can be added to a GameObject after its creation.
        /// </remarks>
        [Fact]
        public void GameObject_CanAddComponentAfterCreation()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 50 });

            // Act
            gameObject.Add(new AnotherComponent { X = 1.0f, Y = 2.0f });

            // Assert
            Assert.True(gameObject.Has<TestComponent>());
            Assert.True(gameObject.Has<AnotherComponent>());
        }

        /// <summary>
        ///     Tests that game object can remove component
        /// </summary>
        /// <remarks>
        ///     Tests that components can be removed from a GameObject.
        /// </remarks>
        [Fact]
        public void GameObject_CanRemoveComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent { Value = 60 });

            // Act
            gameObject.Remove<TestComponent>();

            // Assert
            Assert.False(gameObject.Has<TestComponent>());
        }

        /// <summary>
        ///     Tests that game object with multiple components can be queried
        /// </summary>
        /// <remarks>
        ///     Validates that GameObjects with multiple components can be properly queried.
        /// </remarks>
        [Fact]
        public void GameObject_WithMultipleComponents_CanBeQueried()
        {
            // Arrange
            using Scene scene = new Scene();
            TestComponent comp1 = new TestComponent { Value = 123 };
            AnotherComponent comp2 = new AnotherComponent { X = 4.5f, Y = 6.7f };

            // Act
            GameObject gameObject = scene.Create(comp1, comp2);

            // Assert
            Assert.True(gameObject.Has<TestComponent>());
            Assert.True(gameObject.Has<AnotherComponent>());
        }
    }
}

