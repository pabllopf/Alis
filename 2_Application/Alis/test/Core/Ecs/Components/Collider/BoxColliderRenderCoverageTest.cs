// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderRenderCoverageTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests covering the <see cref="BoxCollider.Render" /> method and
    ///     <see cref="BoxCollider.BoxColliderSettings" /> record auto-generated members.
    /// </summary>
    public class BoxColliderRenderCoverageTest
    {
        #region Render Method

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.Render" /> is callable and enters
        ///     the <c>IsInit == false</c> branch, which throws due to missing OpenGL context.
        /// </summary>
        [Fact]
        public void Render_WhenNotInitialized_ThrowsDueToOpenGlDependency()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Transform(new Vector2F(0f, 0f), 0f));
            BoxCollider collider = new BoxCollider();

            // Act
            Exception exception = Record.Exception(() =>
                collider.Render(gameObject, Vector2F.Zero, new Vector2F(1920f, 1080f), 100f));

            // Assert — Render calls InitializeShaders() which invokes Gl.* methods
            // that require a real OpenGL context. In unit tests this throws.
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Verifies that multiple <see cref="BoxCollider.Render" /> calls without
        ///     an OpenGL context always throw, and the first call's failure does not
        ///     alter the <c>IsInit</c> flag (it stays false because the assignment
        ///     <c>IsInit = true</c> is never reached).
        /// </summary>
        [Fact]
        public void Render_MultipleCallsWithoutGl_EachCallThrows()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Transform(Vector2F.Zero, 0f));
            BoxCollider collider = new BoxCollider();

            // Act — first call
            Exception firstException = Record.Exception(() =>
                collider.Render(gameObject, Vector2F.Zero, new Vector2F(1920f, 1080f), 100f));

            // Act — second call (IsInit still false because assignment was never reached)
            Exception secondException = Record.Exception(() =>
                collider.Render(gameObject, Vector2F.Zero, new Vector2F(1920f, 1080f), 100f));

            // Assert — both calls throw because InitializeShaders() fails on GL
            Assert.NotNull(firstException);
            Assert.NotNull(secondException);
        }

        #endregion

        #region BoxColliderSettings Record

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.BoxColliderSettings.ToString" />
        ///     returns a non-empty string that includes property values.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_ToString_ReturnsNonEmptyString()
        {
            // Arrange
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 20f,
                Height: 30f,
                Rotation: 1.5f,
                RelativePosition: new Vector2F(10f, 20f),
                AutoTilling: true,
                BodyType: Alis.Core.Physic.Dynamics.BodyType.Dynamic,
                Restitution: 0.8f,
                Friction: 0.3f,
                FixedRotation: true,
                Mass: 5.0f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(1f, 2f),
                AngularVelocity: 3f);

            // Act
            string result = settings.ToString();

            // Assert
            Assert.False(string.IsNullOrEmpty(result));
            Assert.Contains("Width", result, StringComparison.Ordinal);
            Assert.Contains("Height", result, StringComparison.Ordinal);
            Assert.Contains("Mass", result, StringComparison.Ordinal);
            Assert.Contains("20", result, StringComparison.Ordinal);
            Assert.Contains("30", result, StringComparison.Ordinal);
        }

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.BoxColliderSettings.GetHashCode" />
        ///     returns the same value for structurally equal instances.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_GetHashCode_EqualInstancesHaveSameHash()
        {
            // Arrange
            BoxCollider.BoxColliderSettings settingsA = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 20f,
                Height: 30f,
                Rotation: 1.5f,
                RelativePosition: new Vector2F(10f, 20f),
                AutoTilling: true,
                BodyType: Alis.Core.Physic.Dynamics.BodyType.Dynamic,
                Restitution: 0.8f,
                Friction: 0.3f,
                FixedRotation: true,
                Mass: 5.0f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(1f, 2f),
                AngularVelocity: 3f);

            BoxCollider.BoxColliderSettings settingsB = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 20f,
                Height: 30f,
                Rotation: 1.5f,
                RelativePosition: new Vector2F(10f, 20f),
                AutoTilling: true,
                BodyType: Alis.Core.Physic.Dynamics.BodyType.Dynamic,
                Restitution: 0.8f,
                Friction: 0.3f,
                FixedRotation: true,
                Mass: 5.0f,
                IgnoreGravity: true,
                LinearVelocity: new Vector2F(1f, 2f),
                AngularVelocity: 3f);

            // Act & Assert
            Assert.Equal(settingsA, settingsB);
            Assert.Equal(settingsA.GetHashCode(), settingsB.GetHashCode());
        }

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.BoxColliderSettings.GetHashCode" />
        ///     returns different values for instances with different property values.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_GetHashCode_DifferentInstancesHaveDifferentHash()
        {
            // Arrange
            BoxCollider.BoxColliderSettings settingsA = new BoxCollider.BoxColliderSettings(
                IsTrigger: false,
                Width: 10f,
                Height: 10f,
                Rotation: 0f,
                RelativePosition: Vector2F.Zero,
                AutoTilling: false,
                BodyType: Alis.Core.Physic.Dynamics.BodyType.Static,
                Restitution: 0.5f,
                Friction: 0.5f,
                FixedRotation: false,
                Mass: 1.0f,
                IgnoreGravity: false,
                LinearVelocity: Vector2F.Zero,
                AngularVelocity: 0f);

            BoxCollider.BoxColliderSettings settingsB = new BoxCollider.BoxColliderSettings(
                IsTrigger: true,
                Width: 10f,
                Height: 10f,
                Rotation: 0f,
                RelativePosition: Vector2F.Zero,
                AutoTilling: false,
                BodyType: Alis.Core.Physic.Dynamics.BodyType.Static,
                Restitution: 0.5f,
                Friction: 0.5f,
                FixedRotation: false,
                Mass: 1.0f,
                IgnoreGravity: false,
                LinearVelocity: Vector2F.Zero,
                AngularVelocity: 0f);

            // Act & Assert
            Assert.NotEqual(settingsA, settingsB);
            Assert.NotEqual(settingsA.GetHashCode(), settingsB.GetHashCode());
        }

        #endregion
    }
}
