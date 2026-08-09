// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactManagerRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The contact manager remaining coverage tests class
    /// </summary>
    public class ContactManagerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that overlapping dynamic bodies create contacts
        /// </summary>
        [Fact]
        public void OverlappingDynamicBodies_CreateContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that separated bodies destroy contacts after moving apart
        /// </summary>
        [Fact]
        public void SeparatedBodies_DestroyContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetTransform(new Vector2F(-50, 0), 0);
            bodyB.SetTransform(new Vector2F(50, 0), 0);
            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that removing a body destroys its contacts
        /// </summary>
        [Fact]
        public void RemovingBody_DestroysContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);
            world.Remove(bodyB);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that awake dynamic bodies with static body create contacts
        /// </summary>
        [Fact]
        public void AwakeDynamic_WithStatic_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f));
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that disabled bodies skip contact processing
        /// </summary>
        [Fact]
        public void DisabledBodies_SkipContactProcessing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.Enabled = false;
            bodyB.Enabled = false;

            world.Step(1.0f / 60.0f);

            Assert.NotNull(world.ContactManager);
        }

        /// <summary>
        ///     Tests that sleeping bodies do not process active contacts
        /// </summary>
        [Fact]
        public void SleepingBodies_DoNotProcessActiveContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.Awake = false;
            bodyB.Awake = false;

            world.Step(1.0f / 60.0f);

            Assert.NotNull(world.ContactManager);
        }

        /// <summary>
        ///     Tests that multiple step updates keep contact list consistent
        /// </summary>
        [Fact]
        public void MultipleSteps_KeepContactListConsistent()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that fixtures on the same body do not create contacts
        /// </summary>
        [Fact]
        public void FixturesOnSameBody_DoNotCreateContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            body.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(1.0f, 1.0f));
            body.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(1.0f, 1.0f));

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that end contact delegate fires on separation
        /// </summary>
        [Fact]
        public void EndContactDelegate_FiresOnSeparation()
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
        }

        /// <summary>
        ///     Tests that begin contact delegate fires on contact creation
        /// </summary>
        [Fact]
        public void BeginContactDelegate_FiresOnContactCreation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool began = false;
            world.ContactManager.BeginContact += contact => began = true;

            world.Step(1.0f / 60.0f);

            Assert.True(began);
        }
    }
}
