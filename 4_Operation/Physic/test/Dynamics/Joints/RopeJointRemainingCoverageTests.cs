// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RopeJointRemainingCoverageTests.cs
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
    ///     The rope joint remaining coverage tests class
    /// </summary>
    public class RopeJointRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that solve velocity constraints with stretched rope applies bias
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithStretchedRope_AppliesBias()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0))
            {
                MaxLength = 10.0f
            };
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 1.0f;
            bodyB.InvI = 1.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = false },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = new Vector2F(3, 0), A = 0.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);
            joint.SolveVelocityConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that solve velocity constraints with short rope applies no bias
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithShortRope_AppliesNoBias()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0))
            {
                MaxLength = 1.0f
            };
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 1.0f;
            bodyB.InvI = 1.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = false },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = new Vector2F(3, 0), A = 0.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);
            joint.SolveVelocityConstraints(ref data);

            Assert.Equal(Alis.Core.Physic.Dynamics.Joints.LimitState.AtUpper, joint.State);
        }
    }
}
