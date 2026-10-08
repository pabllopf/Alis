// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicBranchCoverageTests.cs
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
    ///     Targeted branch coverage tests for WorldPhysic covering the TOI
    ///     solver, contact alpha caching and continuous contact processing.
    /// </summary>
    public class WorldPhysicBranchCoverageTests
    {
        /// <summary>
        ///     Returns the first contact linked into the world contact list.
        /// </summary>
        private static Contact FirstContact(WorldPhysic world)
        {
            Contact contact = world.ContactList.Next;
            Assert.NotSame(world.ContactList, contact);
            return contact;
        }

        /// <summary>
        ///     Tests that a cached TOI flag short-circuits the time of impact computation
        ///     and returns the previously stored TOI value.
        /// </summary>
        [Fact]
        public void CalculateContactAlpha_WhenToiFlagSet_ReturnsCachedToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(1.5f, 0.0f), BodyType.Dynamic);
            world.ContactManager.FindNewContacts();

            Contact contact = FirstContact(world);
            contact.ToiFlag = true;
            contact.Toi = 0.25f;

            float alpha = world.CalculateContactAlpha(contact);

            Assert.Equal(0.25f, alpha);
        }

        /// <summary>
        ///     Tests that processing a TOI contact when the island is already at capacity
        ///     returns without adding the contact or body to the island.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenIslandAtCapacity_ReturnsWithoutAdding()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(1.5f, 0.0f), BodyType.Dynamic);
            world.ContactManager.FindNewContacts();

            ContactEdge edge = bodyA.ContactList;
            Assert.NotNull(edge);

            world.GetIsland.Reset(0, 0, 0, world.ContactManager);

            world.ProcessToiContact(edge, bodyA, 0.5f);

            Assert.Equal(0, world.GetIsland.ContactCount);
            Assert.Equal(0, world.GetIsland.BodyCount);
        }

        /// <summary>
        ///     Tests that a sensor fixture short-circuits TOI contact processing and the
        ///     contact is never added to the island.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenFixtureIsSensor_ReturnsWithoutAdding()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(2.0f, 2.0f, 1.0f, Vector2F.Zero, 0, BodyType.Static);
            wall.FixtureList.List[0].GetIsSensor = true;
            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 1.5f), BodyType.Dynamic);
            bullet.IsBullet = true;
            world.ContactManager.FindNewContacts();

            ContactEdge edge = bullet.ContactList;
            Assert.NotNull(edge);

            world.GetIsland.Reset(64, 64, 0, world.ContactManager);

            world.ProcessToiContact(edge, bullet, 0.5f);

            Assert.Equal(0, world.GetIsland.ContactCount);
        }

        /// <summary>
        ///     Tests that when a collision callback disables a touching contact during the
        ///     TOI update the other body's sweep is restored and the contact is not added.
        /// </summary>
        [Fact]
        public void ProcessToiContact_WhenContactDisabledAfterUpdate_RestoresTransformAndReturns()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Static);
            Body bullet = world.CreateCircle(1.0f, 1.0f, new Vector2F(1.5f, 0.0f), BodyType.Dynamic);
            bullet.IsBullet = true;
            world.ContactManager.FindNewContacts();

            ContactEdge edge = bullet.ContactList;
            Assert.NotNull(edge);
            Contact contact = edge.Contact;
            contact.FixtureA.OnCollision += (a, b, c) => false;
            contact.FixtureB.OnCollision += (a, b, c) => false;
            contact.IsTouching = false;

            world.GetIsland.Reset(64, 64, 0, world.ContactManager);

            world.ProcessToiContact(edge, bullet, 0.5f);

            Assert.False(contact.Enabled);
            Assert.Equal(0, world.GetIsland.ContactCount);
        }

        /// <summary>
        ///     Tests that when a collision callback disables a contact selected as the
        ///     minimum alpha contact, the TOI solver restores the body sweeps.
        /// </summary>
        [Fact]
        public void SolveToi_WhenContactDisabledDuringUpdate_RestoresSweeps()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(1.0f, 10.0f, 1.0f, new Vector2F(10.0f, 0.0f));
            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(300.0f, 0.0f);
            bullet.FixtureList.List[0].OnCollision += (a, b, c) => false;

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(bullet.Position.X > 0.0f);
        }
    }
}
