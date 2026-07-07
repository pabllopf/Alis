// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderRuntimeCoverageTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests runtime coverage for <see cref="BoxCollider" /> using real ECS and physics objects.
    /// </summary>
    public class BoxColliderRuntimeCoverageTest
    {
        /// <summary>
        ///     Verifies that the settings-based constructor copies every value to the collider.
        /// </summary>
        [Fact]
        public void BoxCollider_BoxColliderSettings_Constructor_ShouldCopyAllValues()
        {
            BoxCollider.BoxColliderSettings settings = new BoxCollider.BoxColliderSettings(
                true,
                12f,
                24f,
                0.75f,
                new Vector2F(1f, -3f),
                true,
                BodyType.Dynamic,
                0.2f,
                0.4f,
                true,
                9f,
                true,
                new Vector2F(5f, 6f),
                7f);

            BoxCollider collider = new BoxCollider(settings);

            Assert.True(collider.IsTrigger);
            Assert.Equal(12f, collider.Width);
            Assert.Equal(24f, collider.Height);
            Assert.Equal(0.75f, collider.Rotation);
            Assert.Equal(new Vector2F(1f, -3f), collider.RelativePosition);
            Assert.True(collider.AutoTilling);
            Assert.Equal(BodyType.Dynamic, collider.BodyType);
            Assert.Equal(0.2f, collider.Restitution);
            Assert.Equal(0.4f, collider.Friction);
            Assert.True(collider.FixedRotation);
            Assert.Equal(9f, collider.Mass);
            Assert.True(collider.IgnoreGravity);
            Assert.Equal(new Vector2F(5f, 6f), collider.LinearVelocity);
            Assert.Equal(7f, collider.AngularVelocity);
        }

        /// <summary>
        ///     Verifies that OnStart creates a body from a real transform and OnUpdate syncs the transform from the body.
        /// </summary>
        [Fact]
        public void BoxCollider_OnStart_And_OnUpdate_WithRealGameObject_ShouldSyncTransform()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Transform(
                    new Vector2F(3f, 4f),
                    0.5f,
                    new Vector2F(2f, 3f)));

            Context context = new Context();
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(5f, 6f),
                Rotation = 1.25f,
                RelativePosition = new Vector2F(1f, -2f),
                BodyType = BodyType.Dynamic,
                Restitution = 0.3f,
                Friction = 0.7f,
                FixedRotation = true,
                Mass = 4f,
                IgnoreGravity = true,
                LinearVelocity = new Vector2F(8f, 9f),
                IsTrigger = true
            };

            collider.OnStart(gameObject);

            Assert.NotNull(collider.Body);
            Assert.Equal(gameObject, (GameObject) collider.Body.Tag);
            Assert.Equal(4f, collider.Body.Position.X);
            Assert.Equal(2f, collider.Body.Position.Y);
            Assert.Equal(1.25f, collider.Body.Rotation);
            Assert.Equal(BodyType.Dynamic, collider.Body.GetBodyType);
            Assert.False(collider.Body.SleepingAllowed);
            Assert.True(collider.Body.IgnoreGravity);
            Assert.Equal(8f, collider.Body.LinearVelocity.X);
            Assert.Equal(9f, collider.Body.LinearVelocity.Y);

            collider.Body.Position = new Vector2F(10f, 11f);
            collider.Body.Rotation = 2.5f;
            collider.OnUpdate(gameObject);

            ref Transform transform = ref gameObject.Get<Transform>();

            Assert.Equal(10f, transform.Position.X);
            Assert.Equal(11f, transform.Position.Y);
            Assert.Equal(2.5f, transform.Rotation);
        }
    }
}
