// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:BoxColliderOnExitCoverageTest.cs
//
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
//
//  Copyright (c) 2021 GNU General Public License v3.0
//
//  This program is free software: you can redistribute it and/or modify
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
using Moq;
using Xunit;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests for BoxCollider.OnExit covering the Body != null branch.
    ///     These tests exercise the path where OnExit removes a body from the physics world,
    ///     which is the primary uncovered code path in BoxCollider (27.6% coverage, 192 uncovered lines).
    /// </summary>
    public class BoxColliderOnExitCoverageTest
    {
        /// <summary>
        ///     Tests that OnExit removes a non-null Body from the physics world when Context is set.
        ///     This covers the primary uncovered branch: Body != null -> WorldPhysic.Remove(Body) -> Body = null.
        /// </summary>
        [Fact]
        public void BoxCollider_OnExit_WhenBodyIsNotNull_AndContextIsSet_ShouldRemoveBodyFromWorld()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            Context context = new Context();
            global::Alis.Core.Physic.Dynamics.WorldPhysic world = context.PhysicManager.WorldPhysic;

            // Create a real body in the physics world using WorldPhysic.CreateRectangle
            global::Alis.Core.Physic.Dynamics.Body body = world.CreateRectangle(
                width: 10f,
                height: 10f,
                density: 1.0f,
                position: new Vector2F(0, 0),
                rotation: 0,
                bodyType: global::Alis.Core.Physic.Dynamics.BodyType.Static);

            // Set the collider's Body and Context properties
            collider.Body = body;
            collider.Context = context;

            // Verify preconditions: Body is not null and Context is set
            Assert.NotNull(collider.Body);
            Assert.Same(body, collider.Body);
            Assert.NotNull(collider.Context);

            // Mock IGameObject — OnExit's Body != null branch does not use
            // the IGameObject parameter, so a Moq-created stub suffices.
            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Act — Call OnExit, which should enter the Body != null branch,
            // call WorldPhysic.Remove(Body), and set Body = null.
            Exception exception = null;
            try
            {
                collider.OnExit(mockGameObject.Object);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert — OnExit should complete without throwing,
            // and the Body should be set to null after removal.
            Assert.Null(exception);
            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Tests that OnExit with Body != null sets the Body property to null.
        /// </summary>
        [Fact]
        public void BoxCollider_OnExit_WhenBodyIsNotNull_ShouldSetBodyToNull()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            Context context = new Context();
            global::Alis.Core.Physic.Dynamics.WorldPhysic world = context.PhysicManager.WorldPhysic;

            // Create a real body in the physics world
            global::Alis.Core.Physic.Dynamics.Body body = world.CreateRectangle(
                width: 5f,
                height: 5f,
                density: 1.0f,
                position: new Vector2F(10, 20),
                rotation: 45,
                bodyType: global::Alis.Core.Physic.Dynamics.BodyType.Dynamic);

            collider.Body = body;
            collider.Context = context;

            // Mock IGameObject — OnExit's Body != null branch does not use
            // the IGameObject parameter.
            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Act — Call OnExit which should remove the body and set Body = null
            Exception exception = null;
            try
            {
                collider.OnExit(mockGameObject.Object);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert — The collider's Body should be null after exit
            Assert.Null(exception);
            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Tests that OnExit handles multiple bodies correctly — each OnExit call
        ///     removes only the collider's current body.
        /// </summary>
        [Fact]
        public void BoxCollider_OnExit_MultipleBodies_ShouldRemoveOnlyOwnBody()
        {
            // Arrange
            BoxCollider collider1 = new BoxCollider();
            BoxCollider collider2 = new BoxCollider();
            Context context = new Context();
            global::Alis.Core.Physic.Dynamics.WorldPhysic world = context.PhysicManager.WorldPhysic;

            // Create two distinct bodies in the physics world
            global::Alis.Core.Physic.Dynamics.Body body1 = world.CreateRectangle(
                width: 10f, height: 10f, density: 1.0f,
                position: new Vector2F(0, 0),
                bodyType: global::Alis.Core.Physic.Dynamics.BodyType.Static);

            global::Alis.Core.Physic.Dynamics.Body body2 = world.CreateRectangle(
                width: 5f, height: 5f, density: 1.0f,
                position: new Vector2F(20, 20),
                bodyType: global::Alis.Core.Physic.Dynamics.BodyType.Dynamic);

            collider1.Body = body1;
            collider1.Context = context;

            collider2.Body = body2;
            collider2.Context = context;

            // Mock IGameObject — OnExit's Body != null branch does not use
            // the IGameObject parameter.
            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Act — Exit only collider1
            Exception exception1 = null;
            try
            {
                collider1.OnExit(mockGameObject.Object);
            }
            catch (Exception ex)
            {
                exception1 = ex;
            }

            // Assert — body1's collider should have null body, collider2 unchanged
            Assert.Null(exception1);
            Assert.Null(collider1.Body);
            Assert.NotNull(collider2.Body);
            Assert.Same(body2, collider2.Body);
        }

        /// <summary>
        ///     Tests that OnExit can be called multiple times without throwing after Body is null.
        /// </summary>
        [Fact]
        public void BoxCollider_OnExit_AfterBodyRemoved_ShouldHandleSubsequentCalls()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            Context context = new Context();
            global::Alis.Core.Physic.Dynamics.WorldPhysic world = context.PhysicManager.WorldPhysic;

            global::Alis.Core.Physic.Dynamics.Body body = world.CreateRectangle(
                width: 10f, height: 10f, density: 1.0f,
                position: new Vector2F(0, 0));

            collider.Body = body;
            collider.Context = context;

            Mock<IGameObject> mockGameObject = new Mock<IGameObject>();

            // Act — First OnExit removes the body
            Exception firstException = null;
            try
            {
                collider.OnExit(mockGameObject.Object);
            }
            catch (Exception ex)
            {
                firstException = ex;
            }

            // Assert — Body should be null now
            Assert.Null(firstException);
            Assert.Null(collider.Body);

            // Act — Second OnExit call with Body still null should not enter the if block
            Exception secondException = null;
            try
            {
                collider.OnExit(mockGameObject.Object);
            }
            catch (Exception ex)
            {
                secondException = ex;
            }

            // Assert — Should not throw on subsequent calls
            Assert.Null(secondException);
            Assert.Null(collider.Body);
        }
    }
}
