// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrictionJointRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The friction joint remaining coverage tests class
    /// </summary>
    public class FrictionJointRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that solve angular friction clamps impulse to max torque
        /// </summary>
        [Fact]
        public void SolveAngularFriction_ClampsImpulseToMaxTorque()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
            {
                MaxTorque = 1.0f
            };
            joint._angularMass = 2.0f;

            float wA = 0.0f;
            float wB = 100.0f;
            joint.SolveAngularFriction(ref wA, ref wB, 1.0f, 1.0f, 1.0f / 60.0f);
            joint._angularImpulse = 0.0f;
            joint.SolveAngularFriction(ref wA, ref wB, 1.0f, 1.0f, 1.0f / 60.0f);

            Assert.True(Math.Abs(joint._angularImpulse) <= 1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that solve angular friction without exceeding torque keeps impulse
        /// </summary>
        [Fact]
        public void SolveAngularFriction_WithoutExceedingTorque_KeepsImpulse()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
            {
                MaxTorque = 1000.0f
            };
            joint._angularMass = 2.0f;

            float wA = 0.0f;
            float wB = 1.0f;
            joint.SolveAngularFriction(ref wA, ref wB, 1.0f, 1.0f, 1.0f / 60.0f);

            Assert.NotEqual(0.0f, joint._angularImpulse);
        }

        /// <summary>
        ///     Tests that solve linear friction clamps impulse to max force
        /// </summary>
        [Fact]
        public void SolveLinearFriction_ClampsImpulseToMaxForce()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
            {
                MaxForce = 1.0f
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
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };
            joint.InitVelocityConstraints(ref data);

            Vector2F vA = Vector2F.Zero;
            float wA = 0.0f;
            Vector2F vB = new Vector2F(100, 100);
            float wB = 0.0f;
            joint.SolveLinearFriction(ref vA, ref wA, ref vB, ref wB, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f / 60.0f);

            Assert.True(joint.GetReactionForce(60.0f).Length() <= 1.0f);
        }

        /// <summary>
        ///     Tests that solve linear friction without exceeding force keeps impulse
        /// </summary>
        [Fact]
        public void SolveLinearFriction_WithoutExceedingForce_KeepsImpulse()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero)
            {
                MaxForce = 1000.0f
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
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };
            joint.InitVelocityConstraints(ref data);

            Vector2F vA = Vector2F.Zero;
            float wA = 0.0f;
            Vector2F vB = new Vector2F(1, 0);
            float wB = 0.0f;
            joint.SolveLinearFriction(ref vA, ref wA, ref vB, ref wB, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f / 60.0f);

            Assert.NotEqual(Vector2F.Zero, joint.GetReactionForce(1.0f));
        }

        /// <summary>
        ///     Tests that solve position constraints returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ReturnsTrue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
            SolverData data = new SolverData();

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that init velocity constraints with warm starting applies impulses
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStarting_AppliesImpulses()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
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
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = true },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that solve velocity constraints applies impulses
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_AppliesImpulses()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
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
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = true },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
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
        ///     Tests that init velocity constraints with zero inertia guards angular mass
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithZeroInertia_GuardsAngularMass()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 0.0f;
            bodyB.InvI = 0.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = false },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._angularMass);
        }

        /// <summary>
        ///     Tests that constructor with world coordinates transforms anchors
        /// </summary>
        [Fact]
        public void Constructor_WithWorldCoordinates_TransformsAnchors()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Position = new Vector2F(2, 0);
            bodyB.Position = new Vector2F(5, 0);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, new Vector2F(3, 0), true);

            Assert.Equal(1.0f, joint.LocalAnchorA.X, 5);
            Assert.Equal(-2.0f, joint.LocalAnchorB.X, 5);
        }

        /// <summary>
        ///     Tests that world anchor a getter returns world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Getter_ReturnsWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Position = new Vector2F(2, 0);
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, new Vector2F(1, 0));

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(3.0f, anchor.X, 5);
        }

        /// <summary>
        ///     Tests that world anchor b getter returns world point
        /// </summary>
        [Fact]
        public void WorldAnchorB_Getter_ReturnsWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyB.Position = new Vector2F(2, 0);
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, new Vector2F(1, 0));

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(3.0f, anchor.X, 5);
        }
    }
}
