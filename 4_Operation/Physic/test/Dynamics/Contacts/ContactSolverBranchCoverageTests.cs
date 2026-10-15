// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolverBranchCoverageTests.cs
// 
//  --------------------------------------------------------------------------

using System.Threading;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     Exercises the remaining branch and lock-contention paths of the contact solver
    ///     that are not reached through ordinary world stepping.
    /// </summary>
    public class ContactSolverBranchCoverageTests
    {
        /// <summary>
        ///     Reaches the final fallback branch of the two-point normal solver with a negative
        ///     normal velocity, which prevents the block impulse from being applied.
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WhenTwoPointFallbackHasNegativeNormalVelocity_SkipsBlockImpulse()
        {
            ContactSolver solver = new ContactSolver
            {
                Count = 1,
                Locks = new int[2],
                Velocities = new SolverVelocity[2],
                Positions = new SolverPosition[2],
                VelocityConstraints = new ContactVelocityConstraint[1],
                PositionConstraints = new ContactPositionConstraint[1]
            };

            ContactVelocityConstraint vc = new ContactVelocityConstraint
            {
                PointCount = 2,
                IndexA = 0,
                IndexB = 1,
                Friction = 0.0f,
                TangentSpeed = 0.0f,
                Normal = new Vector2F(0.0f, 1.0f),
                K = new Mat22(1.0f, -10.0f, -10.0f, 1.0f),
                NormalMass = new Mat22(1.0f, 0.0f, 0.0f, 1.0f)
            };
            vc.Points[0].NormalMass = 1.0f;
            vc.Points[1].NormalMass = 1.0f;
            vc.Points[1].VelocityBias = -3.0f;
            solver.VelocityConstraints[0] = vc;

            solver.Velocities[0].V = Vector2F.Zero;
            solver.Velocities[1].V = new Vector2F(0.0f, -1.0f);

            solver.SolveVelocityConstraints(0, 1);

            Assert.Equal(Vector2F.Zero, solver.Velocities[0].V);
            Assert.Equal(new Vector2F(0.0f, -1.0f), solver.Velocities[1].V);
            Assert.Equal(0.0f, vc.Points[0].NormalImpulse);
            Assert.Equal(0.0f, vc.Points[1].NormalImpulse);
            Assert.Equal(0, solver.Locks[0]);
            Assert.Equal(0, solver.Locks[1]);
        }

        /// <summary>
        ///     A body lock already held by another thread forces the first compare-exchange to
        ///     fail, so the solver spins until the lock is released.
        /// </summary>
        [Fact]
        public void LockBodies_WhenFirstLockContended_SpinsUntilReleased()
        {
            ContactSolver solver = new ContactSolver();
            int[] locks = new int[2];
            locks[0] = 1;
            solver.Locks = locks;

            Thread releaser = new Thread(() =>
            {
                Thread.Sleep(100);
                Interlocked.Exchange(ref locks[0], 0);
            });
            releaser.Start();

            solver.LockBodies(0, 1);

            releaser.Join();
            Assert.Equal(1, locks[0]);
            Assert.Equal(1, locks[1]);
        }

        /// <summary>
        ///     A contended second body lock forces the solver to roll the first lock back and
        ///     retry until both bodies can be locked together.
        /// </summary>
        [Fact]
        public void LockBodies_WhenSecondLockContended_RollsBackFirstLockAndRetries()
        {
            ContactSolver solver = new ContactSolver();
            int[] locks = new int[2];
            locks[1] = 1;
            solver.Locks = locks;

            Thread releaser = new Thread(() =>
            {
                Thread.Sleep(100);
                Interlocked.Exchange(ref locks[1], 0);
            });
            releaser.Start();

            solver.LockBodies(0, 1);

            releaser.Join();
            Assert.Equal(1, locks[0]);
            Assert.Equal(1, locks[1]);
        }
    }
}
