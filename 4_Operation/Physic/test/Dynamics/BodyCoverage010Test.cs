// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyCoverage010Test.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The body coverage 010 test class
    /// </summary>
    public class BodyCoverage010Test
    {
        /// <summary>
        ///     Tests that get body type setter when world locked should throw
        /// </summary>
        [Fact]
        public void GetBodyType_Setter_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    contact.FixtureA.GetBody.GetBodyType = BodyType.Static;
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that enabled setter when world locked should throw
        /// </summary>
        [Fact]
        public void Enabled_Setter_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    contact.FixtureA.GetBody.Enabled = false;
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that local center setter when world locked should throw
        /// </summary>
        [Fact]
        public void LocalCenter_Setter_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    contact.FixtureA.GetBody.LocalCenter = new Vector2F(0.1f, 0.1f);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that mass setter when world locked should throw
        /// </summary>
        [Fact]
        public void Mass_Setter_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    contact.FixtureA.GetBody.Mass = 5.0f;
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that inertia setter when world locked should throw
        /// </summary>
        [Fact]
        public void Inertia_Setter_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    contact.FixtureA.GetBody.Inertia = 5.0f;
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that add fixture when world locked should throw
        /// </summary>
        [Fact]
        public void Add_Fixture_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    contact.FixtureA.GetBody.Add(new Fixture(new CircleShape(0.5f, 1.0f)));
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that remove fixture when world locked should throw
        /// </summary>
        [Fact]
        public void Remove_Fixture_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    contact.FixtureA.GetBody.Remove(contact.FixtureA);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that set transform ignore contacts when world locked should throw
        /// </summary>
        [Fact]
        public void SetTransformIgnoreContacts_WhenWorldLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    Vector2F position = new Vector2F(1.0f, 1.0f);
                    contact.FixtureA.GetBody.SetTransformIgnoreContacts(ref position, 0.0f);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that remove with touching fixtures destroys contacts and fires removed event
        /// </summary>
        [Fact]
        public void Remove_WithTouchingFixtures_DestroysContactsAndFiresRemoved()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            int removedCount = 0;
            world.FixtureRemoved += (sender, body, fixture) => removedCount++;

            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Fixture fixture = bodyA.FixtureList[0];
            bodyA.Remove(fixture);

            Assert.Equal(1, removedCount);
            Assert.Null(fixture.GetBody);
        }

        /// <summary>
        ///     Tests that apply linear impulse at point wakes sleeping body
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_AtPoint_WakesSleepingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.Awake = false;

            Vector2F impulse = new Vector2F(1.0f, 0.0f);
            Vector2F point = new Vector2F(0.5f, 0.0f);
            body.ApplyLinearImpulse(ref impulse, ref point);

            Assert.True(body.Awake);
        }
    }
}
