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
using System.Collections.Generic;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="GameObject" /> struct which represents an entity reference
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
            GameObject gameObject = default(GameObject);

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
            GameObject defaultGameObject = default(GameObject);

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
            TestComponent component = new TestComponent {Value = 42, Name = "Test"};

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
            TestComponent component = new TestComponent {Value = 10};

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
            GameObject gameObject = scene.Create(new TestComponent {Value = 30});

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
            GameObject gameObject = scene.Create(new TestComponent {Value = 40});

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
            TestComponent original = new TestComponent {Value = 100, Name = "Original"};
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
            GameObject gameObject = scene.Create(new TestComponent {Value = 50});

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
            GameObject entity1 = scene.Create(new TestComponent {Value = 1});
            GameObject entity2 = scene.Create(new TestComponent {Value = 2});

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
            GameObject entity1 = scene.Create(new TestComponent {Value = 10});
            GameObject entity2 = entity1;
            GameObject entity3 = scene.Create(new TestComponent {Value = 20});

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
            GameObject entity1 = scene.Create(new TestComponent {Value = 15});
            GameObject entity2 = scene.Create(new TestComponent {Value = 25});

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
            GameObject gameObject = scene.Create(new TestComponent {Value = 99});

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
            GameObject gameObject = scene.Create(new TestComponent {Value = 5});
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
            GameObject gameObject = scene.Create(new TestComponent {Value = 77});

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
            GameObject gameObject = scene.Create(new TestComponent {Value = 88});

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
            GameObject entity1 = scene.Create(new TestComponent {Value = 1});
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
            List<GameObject> entities = new List<GameObject>();

            // Act
            for (int i = 0; i < 5; i++)
            {
                entities.Add(scene.Create(new TestComponent {Value = i}));
            }

            // Assert
            Assert.Equal(5, entities.Count);
            foreach (GameObject entity in entities)
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
            GameObject gameObject = scene.Create(new TestComponent {Value = 100});
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
        public void GameObject_CanAddAfterCreation()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent {Value = 50});

            // Act
            gameObject.Add(new AnotherComponent {X = 1.0f, Y = 2.0f});

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
            GameObject gameObject = scene.Create(new TestComponent {Value = 60});

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
            TestComponent comp1 = new TestComponent {Value = 123};
            AnotherComponent comp2 = new AnotherComponent {X = 4.5f, Y = 6.7f};

            // Act
            GameObject gameObject = scene.Create(comp1, comp2);

            // Assert
            Assert.True(gameObject.Has<TestComponent>());
            Assert.True(gameObject.Has<AnotherComponent>());
        }

        /// <summary>
        /// Tests that game object has and try has by type and component id work
        /// </summary>
        [Fact]
        public void GameObject_HasAndTryHas_ByTypeAndComponentId_Work()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

            ComponentId posId = Component<Position>.Id;
            ComponentId velId = Component<Velocity>.Id;

            Assert.True(gameObject.Has(typeof(Position)));
            Assert.True(gameObject.Has(posId));
            Assert.True(gameObject.TryHas(typeof(Position)));
            Assert.True(gameObject.TryHas(posId));

            Assert.False(gameObject.Has(typeof(Velocity)));
            Assert.False(gameObject.Has(velId));
            Assert.False(gameObject.TryHas(typeof(Velocity)));
            Assert.False(gameObject.TryHas(velId));
        }

        /// <summary>
        /// Tests that game object get set and try get non generic overloads work
        /// </summary>
        [Fact]
        public void GameObject_GetSetAndTryGet_NonGenericOverloads_Work()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 3, Y = 4});

            object boxed = gameObject.Get(Component<Position>.Id);
            Assert.IsType<Position>(boxed);
            Assert.Equal(3, ((Position) boxed).X);

            gameObject.Set(typeof(Position), new Position {X = 30, Y = 40});
            Assert.Equal(30, gameObject.Get<Position>().X);

            bool found = gameObject.TryGet(typeof(Position), out object value);
            bool notFound = gameObject.TryGet(typeof(Velocity), out object missing);

            Assert.True(found);
            Assert.IsType<Position>(value);
            Assert.False(notFound);
            Assert.Null(missing);
        }

        /// <summary>
        /// Tests that game object add boxed and add as can add components dynamically
        /// </summary>
        [Fact]
        public void GameObject_AddBoxedAndAddAs_CanAddComponentsDynamically()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();

            gameObject.AddBoxed(new Position {X = 7, Y = 8});
            gameObject.AddAs(typeof(TestComponent), new TestComponent {Value = 123});
            gameObject.AddAs(Component<AnotherComponent2>.Id, new AnotherComponent2 {Name = "boxed"});

            Assert.True(gameObject.Has<Position>());
            Assert.True(gameObject.Has<TestComponent>());
            Assert.True(gameObject.Has<AnotherComponent2>());
            Assert.Equal(123, gameObject.Get<TestComponent>().Value);
            Assert.Equal("boxed", gameObject.Get<AnotherComponent2>().Name);
        }

        /// <summary>
        /// Tests that game object remove by type and component id work
        /// </summary>
        [Fact]
        public void GameObject_Remove_ByTypeAndComponentId_Work()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 3, VY = 4});

            gameObject.Remove(typeof(Position));
            Assert.False(gameObject.Has<Position>());

            gameObject.Remove(Component<Velocity>.Id);
            Assert.False(gameObject.Has<Velocity>());
        }

      

        /// <summary>
        /// Tests that game object generic component events are raised with concrete types
        /// </summary>
        [Fact]
        public void GameObject_GenericComponentEvents_AreRaisedWithConcreteTypes()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 5, Y = 6});

            GenericCaptureAction addCapture = new GenericCaptureAction();
            GenericCaptureAction removeCapture = new GenericCaptureAction();

            gameObject.OnComponentAddedGeneric += addCapture;
            gameObject.OnComponentRemovedGeneric += removeCapture;

            gameObject.Add(new Health {Value = 77});
            gameObject.Remove<Position>();

            Assert.Contains(typeof(Health), addCapture.SeenTypes);
            Assert.Contains(typeof(Position), removeCapture.SeenTypes);
        }

        /// <summary>
        /// Tests that game object enumerate components visits all components
        /// </summary>
        [Fact]
        public void GameObject_EnumerateComponents_VisitsAllComponents()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {VX = 2, VY = 2},
                new Health {Value = 3});

            ComponentTypeCaptureAction capture = new ComponentTypeCaptureAction();
            gameObject.EnumerateComponents(capture);

            Assert.Equal(3, capture.Calls);
            Assert.Contains(typeof(Position), capture.SeenTypes);
            Assert.Contains(typeof(Velocity), capture.SeenTypes);
            Assert.Contains(typeof(Health), capture.SeenTypes);
        }

        /// <summary>
        /// Tests that game object metadata properties are consistent
        /// </summary>
        [Fact]
        public void GameObject_MetadataProperties_AreConsistent()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 2, Y = 3});

            Assert.Equal(scene, gameObject.Scene);
            Assert.Equal(GameObject.EntityTypeOf([Component<Position>.Id]), gameObject.Type);
            Assert.Contains(Component<Position>.Id, gameObject.ComponentTypes);
        }

        /// <summary>
        /// Tests that game object try has on deleted entity returns false without throwing
        /// </summary>
        [Fact]
        public void GameObject_TryHas_OnDeletedEntity_ReturnsFalseWithoutThrowing()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 1, Y = 1});
            gameObject.Delete();

            Assert.False(gameObject.TryHas<Position>());
            Assert.False(gameObject.TryHas(typeof(Position)));
            Assert.False(gameObject.TryHas(Component<Position>.Id));
        }

        /// <summary>
        /// The component type capture action class
        /// </summary>
        /// <seealso cref="IGenericAction"/>
        private sealed class ComponentTypeCaptureAction : IGenericAction
        {
            /// <summary>
            /// The calls
            /// </summary>
            internal int Calls;
            /// <summary>
            /// Gets the value of the seen types
            /// </summary>
            internal HashSet<Type> SeenTypes { get; } = new HashSet<Type>();

            /// <summary>
            /// Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type)
            {
                Calls++;
                SeenTypes.Add(typeof(T));
            }
        }

        /// <summary>
        /// The generic capture action class
        /// </summary>
        /// <seealso cref="IGenericAction{GameObject}"/>
        private sealed class GenericCaptureAction : IGenericAction<GameObject>
        {
            /// <summary>
            /// Gets the value of the seen types
            /// </summary>
            internal HashSet<Type> SeenTypes { get; } = new HashSet<Type>();

            /// <summary>
            /// Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
                SeenTypes.Add(typeof(T));
            }
        }
    }
}

