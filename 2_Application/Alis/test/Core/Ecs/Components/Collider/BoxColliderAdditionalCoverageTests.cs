// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderAdditionalCoverageTests.cs
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
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic.Dynamics;
using Moq;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Additional unit tests for <see cref="BoxCollider" /> covering the remaining uncovered
    ///     execution paths: <c>OnStart</c> with a null Context, and <c>OnExit</c> when both
    ///     Body and Context are present.  These complement the existing test classes that already
    ///     cover constructors, property accessors, no-op paths, and full integration scenarios.
    /// </summary>
    public class BoxColliderAdditionalCoverageTests
    {

       
        #region OnStart — Null Context Path

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnStart" /> throws a
        ///     <see cref="NullReferenceException" /> when the collider has no Context,
        ///     because the implementation accesses <c>Context.PhysicManager</c> without a null guard.
        /// </summary>
        [Fact]
        public void OnStart_WhenContextIsNull_ThrowsNullReferenceException()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            // Context is null by default — no need to set it.

            Transform transform = new Transform(new Vector2F(1f, 2f), 0.5f);
            MockGameObject gameObject = new MockGameObject(transform);

            // Act — OnStart with null Context should throw when accessing Context.PhysicManager.
            Exception exception = Record.Exception(() => collider.OnStart(gameObject));

            // Assert
            Assert.IsAssignableFrom<NullReferenceException>(exception);
        }

        #endregion

        #region OnExit — Full Path (Body and Context Present)

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnExit" /> removes the body from the physics
        ///     world and sets Body to null when both Context and Body are present.  This tests the
        ///     full exit path that is not covered by the no-op tests.
        /// </summary>
        [Fact]
        public void OnExit_WhenBodyAndContextArePresent_RemovesBodyFromWorld()
        {
            // Arrange — create a full scene with a collider that has Context and Body.
            using Scene scene = new Scene();

            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(3f, 4f), 0.5f, new Vector2F(2f, 3f)));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(5f, 6f),
                Rotation = 1.0f,
                RelativePosition = new Vector2F(1f, -1f),
                BodyType = BodyType.Dynamic,
                Restitution = 0.3f,
                Friction = 0.7f,
                FixedRotation = true,
                Mass = 2f,
                IgnoreGravity = false,
                LinearVelocity = new Vector2F(1f, 2f),
                IsTrigger = false
            };

            // Run OnStart to create the body.
            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            // Act — now call OnExit which should remove the body from the world.
            IGameObject mockGameObject = new Mock<IGameObject>().Object;

            // OnExit checks `if (Body != null)` first, then accesses Context.PhysicManager.WorldPhysic.Remove(Body).
            Exception exception = Record.Exception(() => collider.OnExit(mockGameObject));

            // Assert — Body should be set to null after OnExit.
            Assert.Null(collider.Body);

            // Also verify no exception was thrown (the full path executes cleanly).
            Assert.Null(exception);
        }

        /// <summary>
        ///     Verifies that calling <see cref="BoxCollider.OnExit" /> twice in succession is safe:
        ///     the second call is a no-op because Body is already null.
        /// </summary>
        [Fact]
        public void OnExit_CalledTwice_SecondCallIsNoOp()
        {
            // Arrange — create a collider with Context and Body.
            using Scene scene = new Scene();

            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(1f, 1f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(3f, 4f),
                BodyType = BodyType.Static,
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            IGameObject mockGameObject = new Mock<IGameObject>().Object;

            // Act — first OnExit removes the body.
            Exception firstException = Record.Exception(() => collider.OnExit(mockGameObject));
            Assert.Null(firstException);

            // Second OnExit should be a no-op since Body is now null.
            Exception secondException = Record.Exception(() => collider.OnExit(mockGameObject));

            // Assert — Body remains null and no exception on second call.
            Assert.Null(collider.Body);
            Assert.Null(secondException);
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
