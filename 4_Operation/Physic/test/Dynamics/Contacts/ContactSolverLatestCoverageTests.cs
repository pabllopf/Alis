// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverLatestCoverageTests.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver latest coverage tests class
    /// </summary>
    public class ContactSolverLatestCoverageTests
    {
        /// <summary>
        ///     Tests that reset with warm starting disabled clears the stored impulses
        /// </summary>
        [Fact]
        public void Reset_WithWarmStartingDisabled_ClearsStoredImpulses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);
            Manifold manifold = contact.Manifold;
            manifold.Type = ManifoldType.Circles;
            manifold.PointCount = 1;
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.5f, 0.0f), NormalImpulse = 5.0f, TangentImpulse = 3.0f };
            contact.Manifold = manifold;

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = false };
            solver.Reset(ref step, 1, new[] {contact}, new SolverPosition[1], new SolverVelocity[1], new int[1], int.MaxValue, int.MaxValue);

            Assert.Equal(0.0f, solver.VelocityConstraints[0].Points[0].NormalImpulse);
            Assert.Equal(0.0f, solver.VelocityConstraints[0].Points[0].TangentImpulse);

            solver.Dispose();
        }

        /// <summary>
        ///     Tests that initialize velocity constraints with a fixed rotation two point contact
        ///     reduces the degenerate constraint to a single point
        /// </summary>
        [Fact]
        public void InitializeVelocityConstraints_WithFixedRotationTwoPointContact_ReducesDegenerateConstraint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(1.0f, 1.0f, 1.0f, Vector2F.Zero, 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);
            bodyA.FixedRotation = true;
            bodyB.FixedRotation = true;
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;

            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);
            Manifold manifold = contact.Manifold;
            manifold.Type = ManifoldType.FaceA;
            manifold.PointCount = 2;
            manifold.LocalNormal = new Vector2F(1.0f, 0.0f);
            manifold.LocalPoint = Vector2F.Zero;
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, -0.4f) };
            manifold.Points[1] = new ManifoldPoint { LocalPoint = new Vector2F(0.0f, 0.4f) };
            contact.Manifold = manifold;

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            solver.Reset(ref step, 1, new[] {contact}, new SolverPosition[2], new SolverVelocity[2], new int[2], int.MaxValue, int.MaxValue);

            Assert.Equal(2, solver.VelocityConstraints[0].PointCount);

            solver.InitializeVelocityConstraints();

            Assert.Equal(1, solver.VelocityConstraints[0].PointCount);

            solver.Dispose();
        }

        /// <summary>
        ///     Tests that solve velocity constraints with a zero multithread threshold executes
        ///     the batched callback path and releases all contact locks
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithZeroMultithreadThreshold_ExecutesBatchedCallbackPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            int[] locks = new int[2];
            solver.Reset(ref step, 2, new[] {contact, contact}, new SolverPosition[2], new SolverVelocity[2], locks, 0, 0);

            solver.SolveVelocityConstraints();

            Assert.Equal(0, locks[0]);
            Assert.Equal(0, locks[1]);

            solver.Dispose();
        }

        /// <summary>
        ///     Tests that solve position constraints with a zero multithread threshold executes
        ///     the parallel for path and solves all contacts
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithZeroMultithreadThreshold_ExecutesParallelForPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            int[] locks = new int[2];
            solver.Reset(ref step, 2, new[] {contact, contact}, new SolverPosition[2], new SolverVelocity[2], locks, 0, 0);

            bool result = solver.SolvePositionConstraints();

            Assert.True(result);
            Assert.Equal(0, locks[0]);
            Assert.Equal(0, locks[1]);

            solver.Dispose();
        }

        /// <summary>
        ///     Tests that solve toi position constraints with populated constraints solves
        ///     every contact in the solver
        /// </summary>
        [Fact]
        public void SolveToiPositionConstraints_WithContactConstraints_SolvesEveryContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            Contact contact = Contact.Create(world.ContactManager, bodyA.FixtureList[0], 0, bodyB.FixtureList[0], 0);
            Manifold manifold = contact.Manifold;
            manifold.Type = ManifoldType.Circles;
            manifold.PointCount = 1;
            manifold.LocalPoint = Vector2F.Zero;
            manifold.Points[0] = new ManifoldPoint { LocalPoint = new Vector2F(1.0f, 0.0f) };
            contact.Manifold = manifold;

            ContactSolver solver = new ContactSolver();
            TimeStep step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f, DtRatio = 1.0f, WarmStarting = true };
            solver.Reset(ref step, 1, new[] {contact}, new SolverPosition[2], new SolverVelocity[2], new int[2], int.MaxValue, int.MaxValue);

            bool result = solver.SolveToiPositionConstraints(0, 1);

            Assert.True(result);

            solver.Dispose();
        }
    }
}
