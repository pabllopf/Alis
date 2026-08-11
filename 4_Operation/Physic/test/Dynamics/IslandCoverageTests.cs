// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandCoverageTests.cs
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
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The island coverage tests class
    /// </summary>
    public class IslandCoverageTests
    {
        /// <summary>
        ///     Tests that dispose with contacts and joints returns the rented buffers
        /// </summary>
        [Fact]
        public void Dispose_WithContactsAndJoints_ReturnsRentedBuffers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Island island = world.GetIsland;
            island.Reset(64, 64, 64, world.ContactManager);
            island.Add(bodyA);
            island.Add(bodyB);
            island.Add(contact);
            island.Add(joint);
            island.Dispose();

            Assert.Null(island.Bodies);
        }

        /// <summary>
        ///     Tests that report with null contact manager returns early
        /// </summary>
        [Fact]
        public void Report_WithNullContactManager_ReturnsEarly()
        {
            Island island = new Island();

            island.Report(null);

            Assert.NotNull(island);
        }

        /// <summary>
        ///     Tests that solve toi with a fast bullet clamps translation and rotation
        /// </summary>
        [Fact]
        public void SolveToi_WithFastBullet_ClampsTranslationAndRotation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Static);
            Body bullet = world.CreateCircle(0.5f, 1.0f, new Vector2F(-10.0f, 0.0f), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(500.0f, 0.0f);
            bullet.AngularVelocity = 500.0f;

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(bullet.Position.X < 5.0f);
        }
    }
}
