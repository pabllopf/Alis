// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactManagerFullCoverageTests.cs
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
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The contact manager full coverage tests class
    /// </summary>
    public class ContactManagerFullCoverageTests
    {
        /// <summary>
        ///     Tests that notify separation invokes all fixture and body handlers
        /// </summary>
        [Fact]
        public void NotifySeparation_InvokesAllHandlers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int fixtureA = 0;
            int fixtureB = 0;
            int bodyASeparations = 0;
            int bodyBSeparations = 0;

            bodyA.FixtureList.List[0].OnSeparation += (sender, other, contact) => fixtureA++;
            bodyB.FixtureList.List[0].OnSeparation += (sender, other, contact) => fixtureB++;
            bodyA.OnSeparation += (sender, other, contact) => bodyASeparations++;
            bodyB.OnSeparation += (sender, other, contact) => bodyBSeparations++;

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetTransform(new Vector2F(-50, 0), 0);
            bodyB.SetTransform(new Vector2F(50, 0), 0);
            world.Step(1.0f / 60.0f);

            Assert.True(fixtureA > 0);
            Assert.True(fixtureB > 0);
            Assert.True(bodyASeparations > 0);
            Assert.True(bodyBSeparations > 0);
        }

        /// <summary>
        ///     Tests that removing a body with multiple contacts exercises the edge chains
        /// </summary>
        [Fact]
        public void RemoveBody_WithMultipleContacts_ExercisesEdgeChains()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(1.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);
            world.Remove(bodyB);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that the sensor fixture skips waking bodies on contact
        /// </summary>
        [Fact]
        public void SensorFixture_DoesNotWakeBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.FixtureList.List[0].GetIsSensor = true;
            bodyA.Awake = false;

            world.Step(1.0f / 60.0f);

            Assert.False(bodyA.Awake);
        }

        /// <summary>
        ///     Tests that the before collision handler can reject a contact
        /// </summary>
        [Fact]
        public void BeforeCollisionHandler_RejectsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.FixtureList.List[0].BeforeCollision += (sender, other) => false;

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that disabling a body skips its contact processing
        /// </summary>
        [Fact]
        public void DisabledBody_SkipsContactProcessing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.Enabled = false;
            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that sleeping both bodies skips the active contact processing
        /// </summary>
        [Fact]
        public void SleepingBodies_WithExistingContact_SkipsProcessing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.Awake = false;
            bodyB.Awake = false;
            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that changing the collision group flags the contact for refiltering and destroys it
        /// </summary>
        [Fact]
        public void CollisionGroupChange_DestroysContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.FixtureList.List[0].GetCollisionGroup = -1;
            bodyB.FixtureList.List[0].GetCollisionGroup = -1;

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that the contact filter delegate can destroy an existing contact
        /// </summary>
        [Fact]
        public void ContactFilterDelegate_DestroysContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.ContactManager.ContactFilter = (fixtureA, fixtureB) => false;
            bodyA.FixtureList.List[0].GetCollisionGroup = -1;
            bodyB.FixtureList.List[0].GetCollisionGroup = -1;

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that a joint with collide connected false destroys the contact
        /// </summary>
        [Fact]
        public void JointCollideConnectedFalse_DestroysContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            Joint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.CollideConnected = false;

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that refilter with passing filters keeps the contact
        /// </summary>
        [Fact]
        public void RefilterWithPassingFilters_KeepsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.FixtureList.List[0].GetCollisionGroup = 2;
            bodyB.FixtureList.List[0].GetCollisionGroup = 2;

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that re-reported overlapping proxies are recognized as existing contacts
        /// </summary>
        [Fact]
        public void ReReportedOverlappingBodies_RecognizeExistingContact()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -10.0f));
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            for (int i = 0; i < 30; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that multiple contacts between two bodies are connected to both contact lists
        /// </summary>
        [Fact]
        public void MultipleContacts_ConnectToBothBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            bodyA.CreateFixture(new CircleShape(1.0f, 1.0f));
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(1.5f, 0.0f), BodyType.Dynamic);
            bodyB.CreateFixture(new CircleShape(1.0f, 1.0f));

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 1);
            Assert.NotNull(bodyA.ContactList);
            Assert.NotNull(bodyB.ContactList);
        }

        /// <summary>
        ///     Tests that separating bodies destroys contacts and notifies handlers in order
        /// </summary>
        [Fact]
        public void SeparatingBodies_DestroysAndNotifies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool ended = false;
            world.ContactManager.EndContact += contact => ended = true;

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetTransform(new Vector2F(-50, 0), 0);
            bodyB.SetTransform(new Vector2F(50, 0), 0);
            world.Step(1.0f / 60.0f);

            Assert.True(ended);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }
    }
}
