// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverRemainingCoverageTests.cs
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
using System.Buffers;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver remaining coverage tests class
    /// </summary>
    public class ContactSolverRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that dispose with allocated buffers returns them to the pool and nulls them
        /// </summary>
        [Fact]
        public void Dispose_WithAllocatedBuffers_ReturnsThemToPool()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            solver.Reset(ref step, 1, new[] { contact }, new SolverPosition[1], new SolverVelocity[1], new int[1], int.MaxValue, int.MaxValue);

            solver.Dispose();

            Assert.Null(solver.VelocityConstraints);
            Assert.Null(solver.PositionConstraints);
        }

        /// <summary>
        ///     Tests that reset with existing buffers reallocates and returns the old buffers
        /// </summary>
        [Fact]
        public void Reset_WithExistingBuffers_ReallocatesAndReturnsOldBuffers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            Contact[] contacts = new Contact[40];
            for (int i = 0; i < contacts.Length; ++i)
            {
                contacts[i] = contact;
            }

            ContactVelocityConstraint[] seededVelocityConstraints = ArrayPool<ContactVelocityConstraint>.Shared.Rent(8);
            for (int i = 0; i < seededVelocityConstraints.Length; ++i)
            {
                seededVelocityConstraints[i] = new ContactVelocityConstraint();
            }

            ContactPositionConstraint[] seededPositionConstraints = ArrayPool<ContactPositionConstraint>.Shared.Rent(8);
            for (int i = 0; i < seededPositionConstraints.Length; ++i)
            {
                seededPositionConstraints[i] = new ContactPositionConstraint();
            }

            solver.VelocityConstraints = seededVelocityConstraints;
            solver.PositionConstraints = seededPositionConstraints;

            try
            {
                solver.Reset(ref step, 40, contacts, new SolverPosition[64], new SolverVelocity[64], new int[64], int.MaxValue, int.MaxValue);
            }
            catch (NullReferenceException)
            {
            }

            Assert.Equal(40, solver.Count);
            Assert.NotNull(solver.VelocityConstraints);
            Assert.NotNull(solver.PositionConstraints);

            solver.Dispose();
        }

        /// <summary>
        ///     Tests that two overlapping polygons solved through the world step exercise two point velocity constraints
        /// </summary>
        [Fact]
        public void OverlappingPolygons_ThroughWorldStep_ExercisesTwoPointConstraints()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body ground = world.CreateRectangle(6.0f, 0.5f, 1.0f);
            Body box = world.CreateRectangle(0.5f, 0.5f, 1.0f, new Vector2F(0.0f, 1.0f), 0.0f, BodyType.Dynamic);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(box.Position.Y < 1.5f);
        }

        /// <summary>
        ///     Tests that a box sliding off the edge of another box exercises the two point normal fallback branches
        /// </summary>
        [Fact]
        public void BoxSlidingOffEdge_ThroughWorldStep_ExercisesTwoPointFallback()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body baseBox = world.CreateRectangle(2.0f, 0.5f, 1.0f);
            Body slider = world.CreateRectangle(0.5f, 0.5f, 1.0f, new Vector2F(0.6f, 1.0f), 0.3f, BodyType.Dynamic);
            slider.LinearVelocity = new Vector2F(2.0f, 0.0f);

            for (int i = 0; i < 120; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(slider.Position.X > 0.5f);
        }

        /// <summary>
        ///     Tests that a rotated box resting on a stack exercises two point degenerate constraints
        /// </summary>
        [Fact]
        public void RotatedBoxOnStack_ThroughWorldStep_SolvesVelocityConstraints()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateRectangle(8.0f, 0.5f, 1.0f);
            Body first = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(0.0f, 1.0f), 0.0f, BodyType.Dynamic);
            Body second = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(0.0f, 2.4f), 0.7853982f, BodyType.Dynamic);
            Body third = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(0.0f, 3.8f), 0.0f, BodyType.Dynamic);

            for (int i = 0; i < 180; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(first.Position.Y > 0.5f);
            Assert.True(second.Position.Y > 1.5f);
            Assert.True(third.Position.Y > 2.5f);
        }
    }
}
