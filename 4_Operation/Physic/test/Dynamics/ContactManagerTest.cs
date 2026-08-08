// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactManagerTest.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The contact manager test class
    /// </summary>
    public class ContactManagerTest
    {
        /// <summary>
        /// Tests that begin contact callback should be raised when new contact appears
        /// </summary>
        [Fact]
        public void BeginContactCallback_ShouldBeRaised_WhenNewContactAppears()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            int beginCount = 0;
            world.ContactManager.BeginContact = contact =>
            {
                beginCount++;
                return false;
            };

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(beginCount > 0);
        }

        /// <summary>
        /// Tests that contact filter should be able to block contact creation
        /// </summary>
        [Fact]
        public void ContactFilter_ShouldBeAbleToBlockContactCreation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.ContactManager.ContactFilter = (_, _) => false;

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }
        

        /// <summary>
        /// Tests that collide with no contacts does not throw
        /// </summary>
        [Fact]
        public void Collide_WithNoContacts_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

       

        /// <summary>
        /// Tests that destroy contact with multiple overlapping bodies does not throw
        /// </summary>
        [Fact]
        public void DestroyContact_WithMultipleOverlappingBodies_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(-0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }
    }
}

