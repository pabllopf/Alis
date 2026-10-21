// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverDisposeCoverageTests.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver dispose coverage tests class
    /// </summary>
    public class ContactSolverDisposeCoverageTests
    {
        /// <summary>
        ///     Tests that dispose releases the countdown event used to synchronize the
        ///     batched velocity constraint solving
        /// </summary>
        [Fact]
        public void Dispose_ReleasesTheVelocityConstraintsWaitLock()
        {
            ContactSolver solver = new ContactSolver();

            Assert.Equal(0, solver.solveVelocityConstraintsWaitLock.CurrentCount);

            solver.Dispose();

            Assert.Throws<ObjectDisposedException>(() => solver.solveVelocityConstraintsWaitLock.Reset(1));
        }

        /// <summary>
        ///     Tests that dispose returns the velocity constraints buffer to the pool even when
        ///     no position constraints buffer has been allocated
        /// </summary>
        [Fact]
        public void Dispose_WithOnlyVelocityConstraints_ReturnsVelocityBufferToThePool()
        {
            ContactSolver solver = new ContactSolver();
            ContactVelocityConstraint[] rented = ArrayPool<ContactVelocityConstraint>.Shared.Rent(8);
            for (int i = 0; i < rented.Length; ++i)
            {
                rented[i] = new ContactVelocityConstraint();
            }

            solver.VelocityConstraints = rented;
            solver.PositionConstraints = null;

            solver.Dispose();

            Assert.Null(solver.VelocityConstraints);
            Assert.Null(solver.PositionConstraints);
            Assert.All(rented, constraint => Assert.Null(constraint));
        }

        /// <summary>
        ///     Tests that dispose returns the position constraints buffer to the pool even when
        ///     no velocity constraints buffer has been allocated
        /// </summary>
        [Fact]
        public void Dispose_WithOnlyPositionConstraints_ReturnsPositionBufferToThePool()
        {
            ContactSolver solver = new ContactSolver();
            ContactPositionConstraint[] rented = ArrayPool<ContactPositionConstraint>.Shared.Rent(8);
            for (int i = 0; i < rented.Length; ++i)
            {
                rented[i] = new ContactPositionConstraint();
            }

            solver.VelocityConstraints = null;
            solver.PositionConstraints = rented;

            solver.Dispose();

            Assert.Null(solver.VelocityConstraints);
            Assert.Null(solver.PositionConstraints);
            Assert.All(rented, constraint => Assert.Null(constraint));
        }

        /// <summary>
        ///     Tests that dispose after a reset clears the rented constraint buffers before
        ///     returning them to the pool
        /// </summary>
        [Fact]
        public void Dispose_AfterReset_ClearsTheRentedConstraintBuffers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            solver.Reset(ref step, 1, new[] { contact }, new SolverPosition[1], new SolverVelocity[1], new int[1], int.MaxValue, int.MaxValue);

            ContactVelocityConstraint[] velocityConstraints = solver.VelocityConstraints;
            ContactPositionConstraint[] positionConstraints = solver.PositionConstraints;

            Assert.NotNull(velocityConstraints[0]);
            Assert.NotNull(positionConstraints[0]);

            solver.Dispose();

            Assert.Null(solver.VelocityConstraints);
            Assert.Null(solver.PositionConstraints);
            Assert.All(velocityConstraints, constraint => Assert.Null(constraint));
            Assert.All(positionConstraints, constraint => Assert.Null(constraint));
        }
    }
}
