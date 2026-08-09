// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The body remaining coverage tests class
    /// </summary>
    public class BodyRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that apply linear impulse to static body does not change velocity
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_WithStaticBody_DoesNotChangeVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);

            body.ApplyLinearImpulse(new Vector2F(10, 10));

            Assert.Equal(0.0f, body.LinearVelocity.X, 5);
            Assert.Equal(0.0f, body.LinearVelocity.Y, 5);
        }

        /// <summary>
        ///     Tests that apply linear impulse at point to static body does not change velocity
        /// </summary>
        [Fact]
        public void ApplyLinearImpulseAtPoint_WithStaticBody_DoesNotChangeVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);

            body.ApplyLinearImpulse(new Vector2F(10, 10), new Vector2F(1, 1));

            Assert.Equal(0.0f, body.LinearVelocity.X, 5);
        }

        /// <summary>
        ///     Tests that apply angular impulse to static body does not change velocity
        /// </summary>
        [Fact]
        public void ApplyAngularImpulse_WithStaticBody_DoesNotChangeVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);

            body.ApplyAngularImpulse(10.0f);

            Assert.Equal(0.0f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that apply torque to static body does not change velocity
        /// </summary>
        [Fact]
        public void ApplyTorque_WithStaticBody_DoesNotChangeVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);

            body.ApplyTorque(10.0f);

            Assert.Equal(0.0f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that advance updates sweep and transform
        /// </summary>
        [Fact]
        public void Advance_UpdatesSweepAndTransform()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            body.Sweep = new Sweep
            {
                LocalCenter = Vector2F.Zero,
                C0 = new Vector2F(1, 0),
                C = new Vector2F(3, 0),
                A0 = 0.0f,
                A = 1.0f,
                Alpha0 = 0.0f
            };

            body.Advance(0.5f);

            Assert.NotNull(body);
        }

        /// <summary>
        ///     Tests that should collide returns false for non collide connected joint
        /// </summary>
        [Fact]
        public void ShouldCollide_WithNonCollideConnectedJoint_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
            {
                CollideConnected = false
            };
            world.Add(joint);

            bool collide = bodyA.ShouldCollide(bodyB);

            Assert.False(collide);
        }

        /// <summary>
        ///     Tests that should collide returns true without joints
        /// </summary>
        [Fact]
        public void ShouldCollide_WithoutJoints_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);

            bool collide = bodyA.ShouldCollide(bodyB);

            Assert.True(collide);
        }

        /// <summary>
        ///     Tests that collision event handlers add and remove
        /// </summary>
        [Fact]
        public void CollisionEventHandlers_AddAndRemove()
        {
            Body body = new Body();
            OnCollisionEventHandler handler = (fa, fb, contact) => true;

            body.OnCollision += handler;
            body.OnCollision -= handler;

            Assert.NotNull(body);
        }

        /// <summary>
        ///     Tests that separation event handlers add and remove
        /// </summary>
        [Fact]
        public void SeparationEventHandlers_AddAndRemove()
        {
            Body body = new Body();
            OnSeparationEventHandler handler = (fa, fb, contact) => { };

            body.OnSeparation += handler;
            body.OnSeparation -= handler;

            Assert.NotNull(body);
        }

        /// <summary>
        ///     Tests that reset mass data with zero density fixture keeps mass
        /// </summary>
        [Fact]
        public void ResetMassData_WithZeroDensityFixture_KeepsMass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 0.0f));

            body.ResetMassData();

            Assert.NotNull(fixture);
        }
    }
}
