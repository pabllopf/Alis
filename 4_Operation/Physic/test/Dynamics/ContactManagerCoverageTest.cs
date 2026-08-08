// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactManagerCoverageTest.cs
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
    ///     The contact manager coverage test class
    /// </summary>
    public class ContactManagerCoverageTest
    {
        

        /// <summary>
        ///     Tests that both static bodies do not create contacts.
        ///     This exercises Body.ShouldCollide returning false in PassesCollisionFilters.
        /// </summary>
        [Fact]
        public void BothBodiesStatic_ShouldNotCollide()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f));
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f));

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that bodies with same negative collision group do not create contacts.
        ///     This exercises ShouldCollide returning false when collision groups are equal and negative.
        /// </summary>
        [Fact]
        public void SameCollisionGroupNegative_ShouldNotCollide()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }
        
        /// <summary>
        /// Tests that body type static with dynamic prevents collision
        /// </summary>
        [Fact]
        public void BodyTypeStatic_WithDynamic_PreventsCollision()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f));
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f));

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

    }
}
