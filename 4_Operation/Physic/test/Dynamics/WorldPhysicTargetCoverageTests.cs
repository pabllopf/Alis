// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicTargetCoverageTests.cs
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
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Targeted coverage tests for the remaining TOI and stepping branches of
    ///     <see cref="WorldPhysic" />.
    /// </summary>
    public class WorldPhysicTargetCoverageTests
    {
        /// <summary>
        ///     When the contact has already been flagged for TOI the cached alpha is returned.
        /// </summary>
        [Fact]
        public void CalculateContactAlpha_WhenToiFlagIsSet_ReturnsCachedToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);
            world.Step(1.0f / 60.0f);

            Contact contact = bodyA.ContactList.Contact;
            Assert.NotNull(contact);

            contact.ToiFlag = true;
            contact.Toi = 0.37f;

            float alpha = world.CalculateContactAlpha(contact);

            Assert.Equal(0.37f, alpha);
        }

        /// <summary>
        ///     When the contact is disabled during its update the sweeps are restored and the
        ///     TOI contact is not added to the island.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenContactDisabledAfterUpdate_RestoresSweep()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body other = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);
            world.Step(1.0f / 60.0f);

            ContactEdge edge = body.ContactList;
            Assert.NotNull(edge);
            Contact contact = edge.Contact;

            contact.IsTouching = false;
            contact.IslandFlag = false;
            other.Island = false;

            world.ContactManager.BeginContact = _ => false;
            world.GetIsland.Reset(64, 32, 0, world.ContactManager);

            world.ProcessToiContact(edge, body, 0.5f);

            Assert.False(contact.Enabled);
            Assert.False(contact.IslandFlag);
        }

        /// <summary>
        ///     When either fixture is a sensor the TOI contact is skipped.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenSecondFixtureIsSensor_ReturnsWithoutAdding()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body other = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);
            world.Step(1.0f / 60.0f);

            ContactEdge edge = body.ContactList;
            Assert.NotNull(edge);
            Contact contact = edge.Contact;

            contact.FixtureA.GetIsSensor = false;
            contact.FixtureB.GetIsSensor = true;
            contact.IslandFlag = false;
            other.Island = false;

            world.GetIsland.Reset(64, 32, 0, world.ContactManager);

            world.ProcessToiContact(edge, body, 0.5f);

            Assert.False(contact.IslandFlag);
        }

        /// <summary>
        ///     When the first fixture is a sensor the TOI contact is skipped immediately.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenFirstFixtureIsSensor_ReturnsWithoutAdding()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body other = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);
            world.Step(1.0f / 60.0f);

            ContactEdge edge = body.ContactList;
            Assert.NotNull(edge);
            Contact contact = edge.Contact;

            contact.FixtureA.GetIsSensor = true;
            contact.FixtureB.GetIsSensor = false;
            contact.IslandFlag = false;
            other.Island = false;

            world.GetIsland.Reset(64, 32, 0, world.ContactManager);

            world.ProcessToiContact(edge, body, 0.5f);

            Assert.False(contact.IslandFlag);
        }

        /// <summary>
        ///     When the island body capacity is reached the contact is not processed.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenIslandBodyCapacityReached_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);
            world.Step(1.0f / 60.0f);

            ContactEdge edge = body.ContactList;
            Assert.NotNull(edge);

            world.GetIsland.Reset(64, 32, 0, world.ContactManager);
            world.GetIsland.BodyCount = world.GetIsland.BodyCapacity;

            world.ProcessToiContact(edge, body, 0.5f);

            Assert.Equal(world.GetIsland.BodyCapacity, world.GetIsland.BodyCount);
        }

        /// <summary>
        ///     When the island contact capacity is reached the contact is not processed.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenIslandContactCapacityReached_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);
            world.Step(1.0f / 60.0f);

            ContactEdge edge = body.ContactList;
            Assert.NotNull(edge);

            world.GetIsland.Reset(64, 32, 0, world.ContactManager);
            world.GetIsland.ContactCount = world.GetIsland.ContactCapacity;

            world.ProcessToiContact(edge, body, 0.5f);

            Assert.Equal(world.GetIsland.ContactCapacity, world.GetIsland.ContactCount);
        }

        /// <summary>
        ///     A zero time step still runs the controller update loop but skips the solver and
        ///     continuous physics, leaving the world unlocked.
        /// </summary>
        [Fact]
        public void Step_WhenDeltaTimeIsZero_SkipsSolveAndContinuousPhysics()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            world.Step(0.0f);

            Assert.False(world.GetIsLocked);
            Assert.Equal(Vector2F.Zero, body.LinearVelocity);
        }

        /// <summary>
        ///     A negative time step is treated the same as a zero step.
        /// </summary>
        [Fact]
        public void Step_WhenDeltaTimeIsNegative_LeavesWorldUnlocked()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            world.Step(-1.0f);

            Assert.False(world.GetIsLocked);
        }

        /// <summary>
        ///     A rounded rectangle built with zero segments still contains a full set of
        ///     vertices and produces a valid body.
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_WithZeroSegments_CreatesBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body body = world.CreateRoundedRectangle(2.0f, 1.0f, 0.3f, 0.3f, 0, 1.0f, Vector2F.Zero);

            Assert.NotNull(body);
            Assert.True(body.FixtureList.List.Count > 0);
        }

        /// <summary>
        ///     When a freshly touching TOI contact is rejected by the BeginContact delegate it is
        ///     disabled and the loop restores the sweeps instead of solving the sub-step.
        /// </summary>
        [Fact]
        public void SolveToi_WhenContactDisabledOnBegin_PassesThroughObstacle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 10.0f, 1.0f, new Vector2F(0, 0));
            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(6, 0), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(-60, 0);

            world.ContactManager.BeginContact = _ => false;

            for (int i = 0; i < 120; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(bullet.Position.X < 0);
        }
    }
}
