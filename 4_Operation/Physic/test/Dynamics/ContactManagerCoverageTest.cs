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

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

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

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that Body.OnSeparation event fires when contact is destroyed.
        ///     This exercises NotifySeparation body handler path.
        /// </summary>
        [Fact]
        public void BodyOnSeparation_Fires_WhenContactDestroyed()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int sepCount = 0;
            bodyA.OnSeparation += (_, _, _) => sepCount++;

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(sepCount > 0);
        }

        /// <summary>
        ///     Tests that Fixture.OnSeparation fires when contact is destroyed.
        ///     This exercises NotifySeparation fixture handler path.
        /// </summary>
        [Fact]
        public void FixtureOnSeparation_Fires_WhenContactDestroyed()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int sepCount = 0;

            world.ContactManager.BeginContact = contact =>
            {
                contact.FixtureA.OnSeparation = (_, _, _) => sepCount++;
                return true;
            };

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(sepCount > 0);
        }

        /// <summary>
        ///     Tests that changing collision group re-filters existing contacts.
        ///     This exercises TryResolveContactFilter when FilterFlag is true.
        /// </summary>
        [Fact]
        public void FilterFlagReCheck_DestroysContact_WhenCollisionGroupChanged()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, iterations: ref iterations);

            int initialCount = world.ContactManager.ContactCount;
            Assert.True(initialCount > 0);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount < initialCount);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that should collide with non matching groups uses category check
        /// </summary>
        [Fact]
        public void ShouldCollide_WithNonMatchingGroups_UsesCategoryCheck()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(1);
            bodyB.SetCollisionGroup(2);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
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

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that step with filter flag set re evaluates contacts
        /// </summary>
        [Fact]
        public void Step_WithFilterFlagSet_ReEvaluatesContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.ContactManager.ContactFilter = (_, _) => false;
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }
    }
}
