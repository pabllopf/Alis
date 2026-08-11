// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicFullCoverageTests.cs
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
    ///     The world physic full coverage tests class
    /// </summary>
    public class WorldPhysicFullCoverageTests
    {
        /// <summary>
        ///     Tests that the body added and fixture added delegates fire on creation
        /// </summary>
        [Fact]
        public void BodyAndFixtureAdded_DelegatesFire()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            bool bodyAdded = false;
            bool fixtureAdded = false;
            world.BodyAdded += (sender, body) => bodyAdded = true;
            world.FixtureAdded += (sender, body, fixture) => fixtureAdded = true;

            world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0));

            Assert.True(bodyAdded);
            Assert.True(fixtureAdded);
        }

        /// <summary>
        ///     Tests that step with the world disabled returns immediately
        /// </summary>
        [Fact]
        public void Step_WithDisabledWorld_Returns()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0));

            world.GetEnabled = false;

            world.Step(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that test point finds a fixture inside the queried area
        /// </summary>
        [Fact]
        public void TestPoint_WithHit_FindsFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0));

            Fixture fixture = world.TestPoint(new Vector2F(0, 0));

            Assert.NotNull(fixture);
        }

        /// <summary>
        ///     Tests that the capsule with enough vertices decomposes into a compound body
        /// </summary>
        [Fact]
        public void CreateCapsule_WithManyVertices_Decomposes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body body = world.CreateCapsule(6.0f, 1.0f, 6, 1.0f, 6, 1.0f, new Vector2F(0, 0));

            Assert.NotNull(body);
            Assert.True(body.FixtureList.List.Count > 1);
        }

        /// <summary>
        ///     Tests that the rounded rectangle with many segments decomposes into a compound body
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_WithManySegments_Decomposes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body body = world.CreateRoundedRectangle(4.0f, 2.0f, 0.5f, 0.5f, 8, 1.0f, new Vector2F(0, 0));

            Assert.NotNull(body);
            Assert.True(body.FixtureList.List.Count > 1);
        }

        /// <summary>
        ///     Tests that removing a body with multiple joints exercises the joint edge chains
        /// </summary>
        [Fact]
        public void RemoveBody_WithMultipleJoints_ExercisesEdgeChains()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(3, 0), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(1.0f, 1.0f, new Vector2F(-3, 0), BodyType.Dynamic);

            JointFactory.CreateDistanceJoint(world, bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            JointFactory.CreateDistanceJoint(world, bodyA, bodyC, Vector2F.Zero, Vector2F.Zero);

            world.Remove(bodyA);

            Assert.Null(bodyA.GetWorldPhysic);
        }

        /// <summary>
        ///     Tests that removing a joint flags contacts for removal when not collide connected
        /// </summary>
        [Fact]
        public void RemoveJoint_WithCollideConnectedFalse_FlagsContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            DistanceJoint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.CollideConnected = false;

            world.Step(1.0f / 60.0f);
            Assert.Equal(0, world.ContactManager.ContactCount);

            world.Remove(joint);
            world.Step(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that a fast bullet body triggers the TOI solving path
        /// </summary>
        [Fact]
        public void FastBullet_TriggersToiPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(1.0f, 10.0f, 1.0f, new Vector2F(10, 0));
            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(0, 0), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(200, 0);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(bullet.Position.X > 0);
        }

        /// <summary>
        ///     Tests that two fast bullets moving toward each other trigger the multi-body TOI island path
        /// </summary>
        [Fact]
        public void FastBullets_TowardEachOther_TriggerToiIsland()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bulletA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-5, 0), BodyType.Dynamic);
            Body bulletB = world.CreateCircle(0.5f, 1.0f, new Vector2F(5, 0), BodyType.Dynamic);
            bulletA.IsBullet = true;
            bulletB.IsBullet = true;
            bulletA.LinearVelocity = new Vector2F(100, 0);
            bulletB.LinearVelocity = new Vector2F(-100, 0);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }
        }

        /// <summary>
        ///     Tests that a bullet hitting a static body triggers the process toi contact path
        /// </summary>
        [Fact]
        public void Bullet_HittingStaticBody_ProcessesToiContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(2.0f, 10.0f, 1.0f, new Vector2F(0, -5));
            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(0, 20), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(0, -100);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }
    }
}
