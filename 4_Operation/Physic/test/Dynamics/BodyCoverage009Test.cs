// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyCoverage009Test.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Tests targeting remaining uncovered branches in Body.cs:
    ///     velocity-setter wake, ShouldCollide edge cases, Remove contact
    ///     fixtureB path, and non-dynamic guard early returns.
    /// </summary>
    public class BodyCoverage009Test
    {
        /// <summary>
        ///     Tests that setting a non-zero LinearVelocity on a sleeping
        ///     dynamic body wakes it. Covers the true branch of the
        ///     Vector2F.Dot check in the LinearVelocity setter.
        /// </summary>
        [Fact]
        public void LinearVelocity_NonZero_WakesSleepingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Awake = false;
            Assert.False(body.Awake);

            body.LinearVelocity = new Vector2F(3.0f, 0.0f);

            Assert.True(body.Awake);
            Assert.Equal(3.0f, body.LinearVelocity.X);
        }

        /// <summary>
        ///     Tests that setting a non-zero AngularVelocity on a sleeping
        ///     dynamic body wakes it. Covers the true branch of the
        ///     value^2 check in the AngularVelocity setter.
        /// </summary>
        [Fact]
        public void AngularVelocity_NonZero_WakesSleepingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Awake = false;
            Assert.False(body.Awake);

            body.AngularVelocity = 2.5f;

            Assert.True(body.Awake);
            Assert.Equal(2.5f, body.AngularVelocity);
        }

        /// <summary>
        ///     Tests that ShouldCollide returns false when both bodies
        ///     are Kinematic. Covers the both-non-dynamic path where
        ///     the first body is Kinematic.
        /// </summary>
        [Fact]
        public void ShouldCollide_BothKinematic_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Kinematic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Kinematic);

            Assert.False(bodyA.ShouldCollide(bodyB));
        }

        /// <summary>
        ///     Tests that ShouldCollide returns false when one body is
        ///     Kinematic and the other is Static. Covers the
        ///     both-non-dynamic path where neither is Dynamic.
        /// </summary>
        [Fact]
        public void ShouldCollide_KinematicAndStatic_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Kinematic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Static);

            Assert.False(bodyA.ShouldCollide(bodyB));
        }

        /// <summary>
        ///     Tests that ShouldCollide returns true when one body is
        ///     Kinematic and the other is Dynamic. Covers the
        ///     one-dynamic path.
        /// </summary>
        [Fact]
        public void ShouldCollide_KinematicAndDynamic_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Kinematic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.True(bodyA.ShouldCollide(bodyB));
        }

        /// <summary>
        ///     Tests that ShouldCollide returns false when a joint with
        ///     CollideConnected=false connects two bodies. Covers the
        ///     joint-loop early-return in ShouldCollide.
        /// </summary>
        [Fact]
        public void ShouldCollide_JointPreventsCollision_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            bodyA.CreateCircle(0.5f, 1.0f);
            bodyB.CreateCircle(0.5f, 1.0f);

            DistanceJoint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            joint.CollideConnected = false;

            Assert.False(bodyA.ShouldCollide(bodyB));
        }

        /// <summary>
        ///     Tests that ShouldCollide returns true when a joint with
        ///     CollideConnected=true connects two bodies. Covers the
        ///     joint-loop continue when CollideConnected is true.
        /// </summary>
        [Fact]
        public void ShouldCollide_JointAllowsCollision_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            bodyA.CreateCircle(0.5f, 1.0f);
            bodyB.CreateCircle(0.5f, 1.0f);

            DistanceJoint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            joint.CollideConnected = true;

            Assert.True(bodyA.ShouldCollide(bodyB));
        }

        /// <summary>
        ///     Tests that setting Mass on a non-Dynamic body is ignored.
        ///     Covers the early-return when _bodyType is not Dynamic.
        /// </summary>
        [Fact]
        public void Mass_Setter_OnStaticBody_DoesNothing()
        {
            Body body = new Body();
            body.GetBodyType = BodyType.Static;

            body.Mass = 5.0f;

            Assert.Equal(0.0f, body.Mass);
        }

        /// <summary>
        ///     Tests that setting Inertia on a non-Dynamic body is ignored.
        ///     Covers the early-return when _bodyType is not Dynamic.
        /// </summary>
        [Fact]
        public void Inertia_Setter_OnStaticBody_DoesNothing()
        {
            Body body = new Body();
            body.GetBodyType = BodyType.Static;

            body.Inertia = 5.0f;

            Assert.Equal(0.0f, body.Inertia);
        }

        /// <summary>
        ///     Tests that setting Enabled to true on a body with no world
        ///     does not throw. Covers the GetWorldPhysic == null path
        ///     in the true branch of Enabled setter.
        /// </summary>
        [Fact]
        public void Enabled_True_WithoutWorld_DoesNotThrow()
        {
            Body body = new Body();
            body.Enabled = false;
            Assert.False(body.Enabled);

            body.Enabled = true;

            Assert.True(body.Enabled);
        }

        /// <summary>
        ///     Tests that setting Enabled to false on a body with no world
        ///     does not throw. Covers the GetWorldPhysic == null path
        ///     in the false branch of Enabled setter.
        /// </summary>
        [Fact]
        public void Enabled_False_WithoutWorld_DoesNotThrow()
        {
            Body body = new Body();
            body.Enabled = false;

            Assert.False(body.Enabled);
        }
    }
}
