// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderOnStartOnUpdateOnExitTests.cs
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
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Moq;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Unit tests for <see cref="BoxCollider" /> covering the full execution paths of
    ///     <c>OnUpdate</c> (with Body), and the no-op paths of <c>OnStart</c> and <c>OnExit</c>.
    /// </summary>
    public class BoxColliderOnStartOnUpdateOnExitTests
    {
        #region OnStart — No-Op Paths

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnStart" /> is a no-op when the
        ///     <c>IGameObject</c> does not have a Transform component.
        /// </summary>
        [Fact]
        public void OnStart_WhenGameObjectLacksTransform_DoesNotCreateBody()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act — OnStart without Transform
            collider.OnStart(mockGameObject.Object);

            // Assert — Body remains null because the if-block is skipped
            Assert.Null(collider.Body);
        }

        #endregion

        #region OnUpdate — Full Path (Body Not Null)

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnUpdate" /> syncs the Transform's
        ///     Position and Rotation from the Body when both are present.
        /// </summary>
        [Fact]
        public void OnUpdate_WhenGameObjectHasTransformAndBody_SyncsTransformFromBody()
        {
            // Arrange — create a collider with a real Body
            BoxCollider collider = new BoxCollider();

            Alis.Core.Physic.Dynamics.Body body = new Alis.Core.Physic.Dynamics.Body();
            body.Position = new Vector2F(42f, 99f);
            body.Rotation = 1.57f;
            collider.Body = body;

            // Create a game object with a Transform component
            Transform transform = new Transform(Vector2F.Zero, 0f);
            MockGameObject gameObject = new MockGameObject(transform);

            // Act
            collider.OnUpdate(gameObject);

            // Assert — Read back the Transform from the MockGameObject (not the local struct copy)
            Transform updatedTransform = gameObject.GetStoredTransform();
            Assert.Equal(42f, updatedTransform.Position.X, 5);
            Assert.Equal(99f, updatedTransform.Position.Y, 5);
            Assert.Equal(1.57f, updatedTransform.Rotation, 5);
        }

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnUpdate" /> is a no-op when the
        ///     <c>IGameObject</c> does not have a Transform component.
        /// </summary>
        [Fact]
        public void OnUpdate_WhenGameObjectLacksTransform_DoesNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act — should not throw
            Exception exception = Record.Exception(() => collider.OnUpdate(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnUpdate" /> does not modify the Transform
        ///     when Body is null.
        /// </summary>
        [Fact]
        public void OnUpdate_WhenBodyIsNull_DoesNotModifyTransform()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            Transform transform = new Transform(new Vector2F(7f, 13f), 2.5f);
            MockGameObject gameObject = new MockGameObject(transform);

            // Act
            collider.OnUpdate(gameObject);

            // Assert — Transform unchanged because Body is null (the inner if-block is skipped)
            Transform updatedTransform = gameObject.GetStoredTransform();
            Assert.Equal(7f, updatedTransform.Position.X, 5);
            Assert.Equal(13f, updatedTransform.Position.Y, 5);
            Assert.Equal(2.5f, updatedTransform.Rotation, 5);
        }

        #endregion

        #region OnExit — No-Op Paths

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnExit" /> is a no-op when Body is null.
        /// </summary>
        [Fact]
        public void OnExit_WhenBodyIsNull_DoesNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Body is null, Context is null — both guards should prevent any action.

            // Act
            Exception exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that when Body is not null but Context is null, OnExit throws NullReferenceException.
        /// </summary>
        [Fact]
        public void OnExit_WhenBodyIsNotNullButContextIsNull_ThrowsNullReferenceException()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            Mock<Alis.Core.Physic.Dynamics.Body> mockBody = new Mock<Alis.Core.Physic.Dynamics.Body>();
            collider.Body = mockBody.Object;

            // Context is null — the OnExit method checks `Body != null` first,
            // then accesses Context.PhysicManager.WorldPhysic.Remove(Body). Since Body is not null
            // and Context is null, the code will attempt `Context.PhysicManager.WorldPhysic.Remove(Body)`
            // which throws NullReferenceException.

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Act
            Exception exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            // Assert — the implementation accesses Context.PhysicManager without null-check,
            // so it will throw NullReferenceException when Context is null.
            Assert.IsAssignableFrom<NullReferenceException>(exception);
        }

        #endregion

        #region Helper Classes

        /// <summary>
        ///     A concrete implementation of <see cref="IGameObject" /> that stores a Transform
        ///     and returns it by reference, enabling tests of BoxCollider methods that use
        ///     <c>ref Transform transform = ref self.Get&lt;Transform&gt;()</c>.
        /// </summary>
        internal sealed class MockGameObject : IGameObject
        {
            /// <summary>
            /// The transform
            /// </summary>
            private Transform _transform;

            /// <summary>
            ///     Initializes a new instance of the <see cref="MockGameObject" /> class.
            /// </summary>
            /// <param name="transform">The transform to store and return.</param>
            public MockGameObject(Transform transform) => _transform = transform;

            /// <summary>
            ///     Gets a reference to the stored <see cref="Transform" /> component.
            /// </summary>
            public ref T Get<T>() where T : notnull
            {
                if (typeof(T) == typeof(Transform))
                {
                    return ref Unsafe.As<Transform, T>(ref _transform);
                }

                throw new InvalidOperationException($"Component type {typeof(T).Name} not found.");
            }

            /// <summary>
            ///     Determines whether this entity has a component of type <c>T</c>.
            /// </summary>
            public bool Has<T>() => typeof(T) == typeof(Transform);

            /// <summary>
            ///     Determines whether this entity has a component of the specified type.
            /// </summary>
            public bool Has(Type type) => type == typeof(Transform);

            /// <summary>
            ///     Attempts to determine whether this entity has a component of type <c>T</c>.
            /// </summary>
            public bool TryHas<T>() => typeof(T) == typeof(Transform);

            /// <summary>
            ///     Returns the stored Transform for test assertions (reads current state).
            /// </summary>
            public Transform GetStoredTransform() => _transform;
        }

        #endregion
    }
}
