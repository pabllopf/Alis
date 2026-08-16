// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJointLatestCoverageTests.cs
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
    ///     The gear joint latest coverage tests class
    /// </summary>
    public class GearJointLatestCoverageTests
    {
        /// <summary>
        ///     Tests that init velocity constraints with zero mass bodies keeps the mass at zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithZeroMassBodies_ShouldKeepMassZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Body bodyC = new Body();
            Body bodyD = new Body();
            RevoluteJoint revoluteA = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            RevoluteJoint revoluteB = new RevoluteJoint(bodyC, bodyD, Vector2F.Zero);
            GearJoint joint = new GearJoint(bodyA, bodyC, revoluteA, revoluteB);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyC.GetIslandIndex = 2;
            bodyD.GetIslandIndex = 3;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyC.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyD.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 0.0f;
            bodyB.InvMass = 0.0f;
            bodyC.InvMass = 0.0f;
            bodyD.InvMass = 0.0f;
            bodyA.InvI = 0.0f;
            bodyB.InvI = 0.0f;
            bodyC.InvI = 0.0f;
            bodyD.InvI = 0.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = true },
                Positions = new SolverPosition[4]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[4]
                {
                    new SolverVelocity { V = new Vector2F(1.0f, 0.0f), W = 1.0f },
                    new SolverVelocity { V = new Vector2F(1.0f, 0.0f), W = 1.0f },
                    new SolverVelocity { V = new Vector2F(1.0f, 0.0f), W = 1.0f },
                    new SolverVelocity { V = new Vector2F(1.0f, 0.0f), W = 1.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._mass, 5);
            Assert.Equal(1.0f, data.Velocities[0].V.X, 5);
            Assert.Equal(1.0f, data.Velocities[1].V.X, 5);
            Assert.Equal(1.0f, data.Velocities[2].V.X, 5);
            Assert.Equal(1.0f, data.Velocities[3].V.X, 5);
        }

        /// <summary>
        ///     Tests that solve position constraints with zero mass bodies returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithZeroMassBodies_ShouldReturnTrue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            Body bodyC = new Body();
            Body bodyD = new Body();
            RevoluteJoint revoluteA = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);
            RevoluteJoint revoluteB = new RevoluteJoint(bodyC, bodyD, Vector2F.Zero);
            GearJoint joint = new GearJoint(bodyA, bodyC, revoluteA, revoluteB);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyC.GetIslandIndex = 2;
            bodyD.GetIslandIndex = 3;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyC.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyD.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 0.0f;
            bodyB.InvMass = 0.0f;
            bodyC.InvMass = 0.0f;
            bodyD.InvMass = 0.0f;
            bodyA.InvI = 0.0f;
            bodyB.InvI = 0.0f;
            bodyC.InvI = 0.0f;
            bodyD.InvI = 0.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = true },
                Positions = new SolverPosition[4]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.1f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.2f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.3f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.4f }
                },
                Velocities = new SolverVelocity[4]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.True(joint.SolvePositionConstraints(ref data));
        }
    }
}
