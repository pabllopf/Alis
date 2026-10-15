// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WeldJointBranchCoverageTests.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     Covers the remaining branch paths of the <see cref="WeldJoint" /> soft/full constraint solver.
    /// </summary>
    public class WeldJointBranchCoverageTests
    {
        /// <summary>
        ///     Creates the solver data
        /// </summary>
        /// <returns>The solver data</returns>
        private static SolverData CreateSolverData(bool warmStarting)
        {
            return new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = warmStarting },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                },
                Locks = new int[2]
            };
        }

        /// <summary>
        ///     With a frequency and non-zero angular inertia, the angular mass inverse is finite
        ///     and set to zero, so the angular velocities must remain untouched when solving.
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithFrequencyAndNonZeroInertia_KeepsAngularVelocityUnchanged()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
            {
                FrequencyHz = 5.0f,
                DampingRatio = 0.5f
            };
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 1.0f;
            bodyB.InvI = 1.0f;

            SolverData data = CreateSolverData(true);
            joint.InitVelocityConstraints(ref data);

            data.Velocities[0].W = 1.0f;
            data.Velocities[1].W = -1.0f;

            joint.SolveVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._gamma, 5);
            Assert.Equal(1.0f, data.Velocities[0].W, 5);
            Assert.Equal(-1.0f, data.Velocities[1].W, 5);
        }

        /// <summary>
        ///     With zero angular inertia and a frequency large enough to overflow the angular
        ///     frequency to infinity, the soft-constraint arithmetic produces NaN. The resulting
        ///     inverse mass stays at zero, exercising the finite-mass-inverse branch, and the
        ///     angular velocity becomes NaN when solved.
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WhenFrequencyOverflows_SetsZeroInverseMass()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
            {
                FrequencyHz = float.MaxValue,
                DampingRatio = 0.5f
            };
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 0.0f;
            bodyB.InvI = 0.0f;

            SolverData data = CreateSolverData(true);
            joint.InitVelocityConstraints(ref data);

            data.Velocities[0].W = 1.0f;
            data.Velocities[1].W = -1.0f;

            joint.SolveVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._gamma, 5);
            Assert.True(float.IsNaN(data.Velocities[0].W));
            Assert.True(float.IsNaN(data.Velocities[1].W));
        }

        /// <summary>
        ///     A perfectly satisfied weld (zero linear error) makes the position solver evaluate the
        ///     angular slop branch and report the constraints as satisfied.
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WhenPositionErrorIsZero_ReturnsTrue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 1.0f;
            bodyB.InvI = 1.0f;

            SolverData data = CreateSolverData(true);
            joint.InitVelocityConstraints(ref data);

            data.Positions[0].C = Vector2F.Zero;
            data.Positions[0].A = 0.0f;
            data.Positions[1].C = Vector2F.Zero;
            data.Positions[1].A = 0.0f;

            bool satisfied = joint.SolvePositionConstraints(ref data);

            Assert.True(satisfied);
            Assert.Equal(0.0f, data.Positions[0].C.X, 5);
            Assert.Equal(0.0f, data.Positions[0].C.Y, 5);
            Assert.Equal(0.0f, data.Positions[1].C.X, 5);
            Assert.Equal(0.0f, data.Positions[1].C.Y, 5);
        }
    }
}
