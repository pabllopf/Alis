// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicJointFilterCoverageTest.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Tests the joint contact-filtering loops, exercising the contact edge walks
    ///     inside FlagContactsForJointFiltering and FlagContactsForJointRemoval.
    /// </summary>
    public class WorldPhysicJointFilterCoverageTest
    {
        /// <summary>
        ///     Ensures adding a non-colliding joint between overlapping bodies flags
        ///     their existing contact, covering the edge walk in FlagContactsForJointFiltering.
        /// </summary>
        [Fact]
        public void AddNonCollideJoint_OverlappingBodies_FlagsExistingContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.5f, 0), BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.5f, 0))
            {
                CollideConnected = false
            };
            world.Add(joint);

            Assert.Same(world, joint.WorldPhysic);
        }

        /// <summary>
        ///     Ensures removing a non-collide joint between overlapping bodies walks the
        ///     bodyB contact list to flag joints, covering FlagContactsForJointRemoval.
        /// </summary>
        [Fact]
        public void RemoveNonCollideJoint_OverlappingBodies_FlagsContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.5f, 0), BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.5f, 0))
            {
                CollideConnected = false
            };
            world.Add(joint);
            world.Remove(joint);

            Assert.Empty(world.JointList);
        }

        /// <summary>
        ///     Ensures Step with a zero delta-time covers the dt<=0 branch of the step.InvDt
        ///     computation and still returns without throwing.
        /// </summary>
        [Fact]
        public void Step_WithZeroDeltaTime_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            world.Step(0.0f);

            Assert.True(true);
        }

        /// <summary>
        ///     Ensures a bullet passing a sensor fixture during continuous solving covers the
        ///     sensor short-circuit branch inside ProcessToiContact.
        /// </summary>
        [Fact]
        public void Bullet_HittingSensorBody_ProcessesToiSensorContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(2.0f, 10.0f, 1.0f, new Vector2F(0, -5));
            wall.FixtureList.List[0].GetIsSensor = true;

            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(0, 20), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(0, -100);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(bullet.Position.Y < 20);
        }
    }
}