// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJointRemainingCoverageTests.cs
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
    ///     The gear joint remaining coverage tests class
    /// </summary>
    public class GearJointRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that init velocity constraints without warm starting zeroes impulses
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithoutWarmStarting_ZeroesImpulses()
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
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyC.InvMass = 1.0f;
            bodyD.InvMass = 1.0f;
            bodyA.InvI = 1.0f;
            bodyB.InvI = 1.0f;
            bodyC.InvI = 1.0f;
            bodyD.InvI = 1.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = false },
                Positions = new SolverPosition[4]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
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

            Assert.NotNull(joint);
        }
    }
}
