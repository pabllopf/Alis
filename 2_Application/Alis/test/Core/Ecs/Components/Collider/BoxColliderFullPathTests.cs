// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderFullPathTests.cs
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
using Moq;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Additional path coverage tests for BoxCollider focusing on scenarios not covered
    ///     by existing test files. These tests target edge cases and error paths.
    /// </summary>
    public class BoxColliderFullPathTests
    {
        #region OnUpdate Edge Case Tests

        /// <summary>
        ///     Tests that OnUpdate handles the case where Body is set but Has&lt;Transform&gt; returns false.
        ///     This covers the branch where the if condition fails and no action is taken.
        /// </summary>
        [Fact]
        public void BoxCollider_OnUpdate_WhenHasNoTransform_ButBodySet_ShouldNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            var realBody = new Alis.Core.Physic.Dynamics.Body();
            collider.Body = realBody;

            var mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act - Should not throw even though Body is set but Transform is missing
            var exception = Record.Exception(() => collider.OnUpdate(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that OnUpdate with null Body and no Transform component handles both null checks.
        /// </summary>
        [Fact]
        public void BoxCollider_OnUpdate_WhenBothBodyAndTransformMissing_ShouldNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            // Body is null by default

            var mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act - Should not throw
            var exception = Record.Exception(() => collider.OnUpdate(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that OnUpdate can be called multiple times without error when Transform is missing.
        /// </summary>
        [Fact]
        public void BoxCollider_OnUpdate_MultipleCalls_WhenNoTransform_ShouldNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            var mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act - Multiple calls should not throw
            var firstException = Record.Exception(() => collider.OnUpdate(mockGameObject.Object));
            var secondException = Record.Exception(() => collider.OnUpdate(mockGameObject.Object));
            var thirdException = Record.Exception(() => collider.OnUpdate(mockGameObject.Object));

            // Assert
            Assert.Null(firstException);
            Assert.Null(secondException);
            Assert.Null(thirdException);
        }

        #endregion

        #region OnStart Edge Case Tests

        /// <summary>
        ///     Tests that OnStart does not create a body when Transform component is missing.
        /// </summary>
        [Fact]
        public void BoxCollider_OnStart_WhenNoTransform_ShouldNotCreateBody()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            collider.Context = new Context();

            var mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act
            var exception = Record.Exception(() => collider.OnStart(mockGameObject.Object));

            // Assert - Body should remain null since Transform is not present
            Assert.Null(exception);
            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Tests that OnStart with null Context does not throw when Transform is missing.
        /// </summary>
        [Fact]
        public void BoxCollider_OnStart_WhenContextIsNullAndNoTransform_ShouldNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            // Context is null by default

            var mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act - Should not throw since Has&lt;Transform&gt; returns false
            var exception = Record.Exception(() => collider.OnStart(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that OnStart with Context but no Transform does not create a body.
        /// </summary>
        [Fact]
        public void BoxCollider_OnStart_WhenContextSetButNoTransform_ShouldNotCreateBody()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            collider.Context = new Context();

            var mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act
            var exception = Record.Exception(() => collider.OnStart(mockGameObject.Object));

            // Assert - Body should remain null
            Assert.Null(exception);
            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Tests that OnStart with various collider property values executes without error when Transform is missing.
        /// </summary>
        [Fact]
        public void BoxCollider_OnStart_WithVariousProperties_NoTransform_ShouldNotThrow()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            collider.Context = new Context();
            collider.SizeOfTexture = new Vector2F(2, 3);
            collider.Rotation = 1.5f;
            collider.BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic;
            collider.Restitution = 0.7f;
            collider.Friction = 0.4f;
            collider.FixedRotation = true;
            collider.Mass = 2.5f;
            collider.IgnoreGravity = true;

            var mockGameObject = new Mock<IGameObject>();
            mockGameObject.Setup(g => g.Has<Transform>()).Returns(false);

            // Act
            var exception = Record.Exception(() => collider.OnStart(mockGameObject.Object));

            // Assert - Should not throw
            Assert.Null(exception);
        }

        #endregion

        #region OnExit Edge Case Tests

        /// <summary>
        ///     Tests that OnExit with null Body and null Context handles both null checks.
        /// </summary>
        [Fact]
        public void BoxCollider_OnExit_WhenBothBodyAndContextNull_ShouldHandleGracefully()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            // Both Body and Context are null by default

            var mockGameObject = new Mock<IGameObject>();

            // Act - Should not throw
            var exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that OnExit with a real Body instance but null Context handles the null check.
        /// </summary>
        [Fact]
        public void BoxCollider_OnExit_WithRealBodyButNullContext_ShouldHandleGracefully()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            var realBody = new Alis.Core.Physic.Dynamics.Body();
            collider.Body = realBody;
            // Context is null

            var mockGameObject = new Mock<IGameObject>();

            // Act - Body is not null, but Context is null; expects NullReferenceException
            var exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            // Assert - Should throw NullReferenceException due to null Context
            Assert.NotNull(exception);
            Assert.IsType<NullReferenceException>(exception);
        }

        /// <summary>
        ///     Tests that OnExit with null Body but Context set handles the null Body check.
        /// </summary>
        [Fact]
        public void BoxCollider_OnExit_WithNullBodyButContextSet_ShouldHandleGracefully()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            collider.Context = new Context();
            // Body is null by default

            var mockGameObject = new Mock<IGameObject>();

            // Act - Body is null, so the if (Body != null) check should prevent execution
            var exception = Record.Exception(() => collider.OnExit(mockGameObject.Object));

            // Assert - Should not throw since Body is null
            Assert.Null(exception);
            Assert.Null(collider.Body);
        }

        #endregion

        #region Property Interaction Tests

        /// <summary>
        ///     Tests that setting properties in specific order does not cause issues.
        /// </summary>
        [Fact]
        public void BoxCollider_PropertySet_DifferentOrders_ShouldNotCauseIssues()
        {
            // Arrange - Test setting properties in different orders
            var collider1 = new BoxCollider();
            collider1.Width = 20;
            collider1.Height = 30;
            collider1.Rotation = 45;

            var collider2 = new BoxCollider();
            collider2.Rotation = 45;
            collider2.Height = 30;
            collider2.Width = 20;

            var collider3 = new BoxCollider();
            collider3.Height = 30;
            collider3.Width = 20;
            collider3.Rotation = 45;

            // Assert - All should have same values regardless of set order
            Assert.Equal(20, collider1.Width);
            Assert.Equal(30, collider1.Height);
            Assert.Equal(45, collider1.Rotation);

            Assert.Equal(20, collider2.Width);
            Assert.Equal(30, collider2.Height);
            Assert.Equal(45, collider2.Rotation);

            Assert.Equal(20, collider3.Width);
            Assert.Equal(30, collider3.Height);
            Assert.Equal(45, collider3.Rotation);
        }

        /// <summary>
        ///     Tests that Body property can be set to null after being set to a value.
        /// </summary>
        [Fact]
        public void BoxCollider_BodyProperty_CanBeSetToNullAfterValue()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();
            var realBody = new Alis.Core.Physic.Dynamics.Body();

            // Act
            collider.Body = realBody;
            Assert.Same(realBody, collider.Body);

            collider.Body = null;

            // Assert
            Assert.Null(collider.Body);
        }

        /// <summary>
        ///     Tests that Context property can be set and cleared.
        /// </summary>
        [Fact]
        public void BoxCollider_ContextProperty_CanBeSetAndCleared()
        {
            // Arrange
            BoxCollider collider = new BoxCollider();

            // Act - Set context
            collider.Context = new Context();
            Assert.NotNull(collider.Context);

            // Act - Clear context
            collider.Context = null;

            // Assert
            Assert.Null(collider.Context);
        }

        #endregion
    }
}
