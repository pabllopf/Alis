// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderRemainingCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests covering the remaining uncovered code paths in <see cref="BoxCollider" />:
    ///     full OnStart body-creation path with property verification, full OnUpdate
    ///     body-to-transform synchronisation, body replacement mid-lifecycle, and
    ///     <see cref="BoxCollider.BoxColliderSettings" /> record edge cases.
    /// </summary>
    public class BoxColliderRemainingCoverageTests
    {
        #region OnStart — Full Path with Real Context and Body Property Assertions

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnStart" /> creates a physics Body
        ///     with the correct position, rotation and all configured properties.
        /// </summary>
        [Fact]
        public void OnStart_WithDynamicBody_SetsAllBodyProperties()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(10f, 20f), 0.5f, new Vector2F(2f, 3f)));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(5f, 6f),
                Rotation = 1.0f,
                RelativePosition = new Vector2F(1f, -1f),
                BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic,
                Restitution = 0.3f,
                Friction = 0.7f,
                FixedRotation = true,
                Mass = 2.5f,
                IgnoreGravity = true,
                LinearVelocity = new Vector2F(1f, 2f),
                IsTrigger = true
            };

            collider.OnStart(gameObject);

            Alis.Core.Physic.Dynamics.Body createdBody = collider.Body;
            Assert.NotNull(createdBody);

            // Body position from CreateRectangle: transform.Position + RelativePosition
            Assert.Equal(11f, createdBody.Position.X, 5);
            Assert.Equal(19f, createdBody.Position.Y, 5);

            // Body rotation
            Assert.Equal(1.0f, createdBody.Rotation, 5);

            // Properties set after creating rectangle
            Assert.True(createdBody.FixedRotation);
            Assert.True(createdBody.IgnoreGravity);
            Assert.False(createdBody.SleepingAllowed);
            Assert.False(createdBody.IsBullet);
            Assert.True(createdBody.Awake);

            // Mass for dynamic body
            Assert.Equal(2.5f, createdBody.Mass, 5);

            // LinearVelocity for dynamic body
            Assert.Equal(1f, createdBody.LinearVelocity.X, 5);
            Assert.Equal(2f, createdBody.LinearVelocity.Y, 5);

            // Body type
            Assert.Equal(Alis.Core.Physic.Dynamics.BodyType.Dynamic, createdBody.GetBodyType);

            // Tag assigned to the game object (stored as IGameObject)
            Assert.NotNull(createdBody.Tag);
        }

        /// <summary>
        ///     Verifies <see cref="BoxCollider.OnStart" /> correctly creates a static body
        ///     without dynamic properties such as Mass and LinearVelocity being set.
        /// </summary>
        [Fact]
        public void OnStart_WithStaticBody_DoesNotSetDynamicProperties()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(15f, 25f), 0f, new Vector2F(1f, 1f)));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(8f, 8f),
                BodyType = Alis.Core.Physic.Dynamics.BodyType.Static,
                IgnoreGravity = false,
                IsTrigger = false
            };

            collider.OnStart(gameObject);

            Assert.NotNull(collider.Body);
            Assert.Equal(Alis.Core.Physic.Dynamics.BodyType.Static, collider.Body.GetBodyType);
            Assert.NotNull(collider.Body.Tag);
        }

        #endregion

        #region OnUpdate — Full Path with Real Physics Body

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.OnUpdate" /> synchronises the Transform
        ///     position and rotation from the physics <see cref="Body" /> after the body
        ///     has been moved externally.
        /// </summary>
        [Fact]
        public void OnUpdate_AfterOnStart_SyncsTransformFromBody()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(100f, 200f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(10f, 10f),
                BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            // Move the body to a new position and rotation
            collider.Body.Position = new Vector2F(300f, 400f);
            collider.Body.Rotation = 2.5f;

            collider.OnUpdate(gameObject);

            ref Transform transform = ref gameObject.Get<Transform>();
            Assert.Equal(300f, transform.Position.X, 5);
            Assert.Equal(400f, transform.Position.Y, 5);
            Assert.Equal(2.5f, transform.Rotation, 5);
        }

        /// <summary>
        ///     Verifies that multiple <see cref="BoxCollider.OnUpdate" /> calls after
        ///     moving the body repeatedly keep the Transform synchronised.
        /// </summary>
        [Fact]
        public void OnUpdate_MultipleCalls_KeepsSyncing()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(0f, 0f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(10f, 10f),
                BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic
            };

            collider.OnStart(gameObject);

            collider.Body.Position = new Vector2F(50f, 60f);
            collider.Body.Rotation = 1.5f;
            collider.OnUpdate(gameObject);

            ref Transform t1 = ref gameObject.Get<Transform>();
            Assert.Equal(50f, t1.Position.X, 5);
            Assert.Equal(60f, t1.Position.Y, 5);
            Assert.Equal(1.5f, t1.Rotation, 5);

            collider.Body.Position = new Vector2F(70f, 80f);
            collider.Body.Rotation = 3.0f;
            collider.OnUpdate(gameObject);

            ref Transform t2 = ref gameObject.Get<Transform>();
            Assert.Equal(70f, t2.Position.X, 5);
            Assert.Equal(80f, t2.Position.Y, 5);
            Assert.Equal(3.0f, t2.Rotation, 5);
        }

        #endregion

        #region Body Replacement Mid-Lifecycle

        /// <summary>
        ///     Verifies that manually replacing the <see cref="Body" /> after
        ///     <see cref="BoxCollider.OnStart" /> causes <see cref="BoxCollider.OnUpdate" />
        ///     to synchronise from the new body.
        /// </summary>
        [Fact]
        public void OnUpdate_AfterBodyReplacement_SyncsFromNewBody()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(new Vector2F(10f, 10f), 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(10f, 10f),
                BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            // Create a new independent body and assign it
            Alis.Core.Physic.Dynamics.Body newBody = new Alis.Core.Physic.Dynamics.Body
            {
                Position = new Vector2F(999f, 888f),
                Rotation = 4.5f
            };
            collider.Body = newBody;

            collider.OnUpdate(gameObject);

            ref Transform transform = ref gameObject.Get<Transform>();
            Assert.Equal(999f, transform.Position.X, 5);
            Assert.Equal(888f, transform.Position.Y, 5);
            Assert.Equal(4.5f, transform.Rotation, 5);
        }

        /// <summary>
        ///     Verifies that the Body can be nulled and reassigned after
        ///     <see cref="BoxCollider.OnStart" /> without affecting other properties.
        /// </summary>
        [Fact]
        public void Body_ReplacedAfterOnStart_DoesNotAffectContext()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Transform(Vector2F.Zero, 0f));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(10f, 10f),
                BodyType = Alis.Core.Physic.Dynamics.BodyType.Dynamic
            };

            collider.OnStart(gameObject);
            Assert.NotNull(collider.Body);

            collider.Body = null;
            Assert.Null(collider.Body);
            Assert.Same(context, collider.Context);

            collider.Body = new Alis.Core.Physic.Dynamics.Body();
            Assert.NotNull(collider.Body);
        }

        #endregion

        #region BoxColliderSettings Record Edge Cases

        /// <summary>
        ///     Verifies that <see cref="BoxCollider.BoxColliderSettings" /> supports
        ///     the <c>with</c> expression and creates a new instance with only the
        ///     specified properties changed.
        /// </summary>
        [Fact]
        public void BoxColliderSettings_WithExpression_CreatesModifiedCopy()
        {
            BoxCollider.BoxColliderSettings original = new BoxCollider.BoxColliderSettings(
                IsTrigger: false,
                Width: 10f,
                Height: 20f,
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

            BoxCollider.BoxColliderSettings modified = original with
            {
                Width = 99f,
                Height = 55f,
                IsTrigger = true
            };

            // Original unchanged
            Assert.Equal(10f, original.Width, 5);
            Assert.Equal(20f, original.Height, 5);
            Assert.False(original.IsTrigger);

            // Modified has new values
            Assert.Equal(99f, modified.Width, 5);
            Assert.Equal(55f, modified.Height, 5);
            Assert.True(modified.IsTrigger);

            // Unchanged fields match original
            Assert.Equal(original.Rotation, modified.Rotation);
            Assert.Equal(original.BodyType, modified.BodyType);
            Assert.Equal(original.Restitution, modified.Restitution);
            Assert.Equal(original.Friction, modified.Friction);
            Assert.Equal(original.Mass, modified.Mass);
        }

        #endregion

        #region Property Edge Cases

        /// <summary>
        ///     Verifies that toggling <see cref="BoxCollider.AutoTilling" /> does not
        ///     modify <see cref="BoxCollider.Width" /> or <see cref="BoxCollider.Height" />.
        /// </summary>
        [Fact]
        public void AutoTilling_WhenToggled_DoesNotAffectWidthOrHeight()
        {
            BoxCollider collider = new BoxCollider
            {
                Width = 42f,
                Height = 24f
            };

            collider.AutoTilling = true;
            Assert.Equal(42f, collider.Width, 5);
            Assert.Equal(24f, collider.Height, 5);

            collider.AutoTilling = false;
            Assert.Equal(42f, collider.Width, 5);
            Assert.Equal(24f, collider.Height, 5);
        }

        #endregion
    }
}
