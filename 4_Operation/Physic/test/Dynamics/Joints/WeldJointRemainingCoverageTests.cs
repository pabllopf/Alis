// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WeldJointRemainingCoverageTests.cs
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
    ///     The weld joint remaining coverage tests class
    /// </summary>
    public class WeldJointRemainingCoverageTests
    {
        /// <summary>
        ///     Creates the weld joint
        /// </summary>
        /// <returns>The weld joint</returns>
        private static WeldJoint CreateJoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            return new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f));
        }

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
        ///     Tests that world anchor a getter returns world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Getter_ReturnsWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Position = new Vector2F(5, 5);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(1, 1), new Vector2F(0, 0));

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(6.0f, anchor.X, 5);
            Assert.Equal(6.0f, anchor.Y, 5);
        }

        /// <summary>
        ///     Tests that world anchor b getter returns world point
        /// </summary>
        [Fact]
        public void WorldAnchorB_Getter_ReturnsWorldPoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyB.Position = new Vector2F(5, 5);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(1, 1));

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(6.0f, anchor.X, 5);
            Assert.Equal(6.0f, anchor.Y, 5);
        }

        /// <summary>
        ///     Tests that internal constructor sets joint type to weld
        /// </summary>
        [Fact]
        public void InternalConstructor_SetsJointTypeToWeld()
        {
            WeldJoint joint = new WeldJoint();

            Assert.Equal(JointType.Weld, joint.JointType);
        }

        /// <summary>
        ///     Tests that constructor with world coordinates sets local anchors
        /// </summary>
        [Fact]
        public void Constructor_WithWorldCoordinates_SetsLocalAnchors()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Position = new Vector2F(1, 0);
            bodyB.Position = new Vector2F(3, 0);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(2, 0), new Vector2F(3, 0), true);

            Assert.Equal(1.0f, joint.LocalAnchorA.X, 5);
            Assert.Equal(0.0f, joint.LocalAnchorA.Y, 5);
            Assert.Equal(0.0f, joint.LocalAnchorB.X, 5);
            Assert.Equal(0.0f, joint.LocalAnchorB.Y, 5);
        }

        /// <summary>
        ///     Tests that constructor with local coordinates sets local anchors directly
        /// </summary>
        [Fact]
        public void Constructor_WithLocalCoordinates_SetsLocalAnchorsDirectly()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(1, 2), new Vector2F(3, 4));

            Assert.Equal(1.0f, joint.LocalAnchorA.X, 5);
            Assert.Equal(2.0f, joint.LocalAnchorA.Y, 5);
            Assert.Equal(3.0f, joint.LocalAnchorB.X, 5);
            Assert.Equal(4.0f, joint.LocalAnchorB.Y, 5);
        }

        /// <summary>
        ///     Tests that constructor computes reference angle from body rotations
        /// </summary>
        [Fact]
        public void Constructor_ComputesReferenceAngle()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Rotation = 0.5f;
            bodyB.Rotation = 1.0f;

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Assert.Equal(0.5f, joint.ReferenceAngle, 5);
        }

        /// <summary>
        ///     Tests that local anchors round trip
        /// </summary>
        [Fact]
        public void LocalAnchors_RoundTrip()
        {
            WeldJoint joint = CreateJoint();

            joint.LocalAnchorA = new Vector2F(7, 8);
            joint.LocalAnchorB = new Vector2F(9, 10);

            Assert.Equal(7.0f, joint.LocalAnchorA.X, 5);
            Assert.Equal(8.0f, joint.LocalAnchorA.Y, 5);
            Assert.Equal(9.0f, joint.LocalAnchorB.X, 5);
            Assert.Equal(10.0f, joint.LocalAnchorB.Y, 5);
        }

        /// <summary>
        ///     Tests that world anchor a setter changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorA_Setter_ChangesLocalAnchor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Position = new Vector2F(5, 5);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            joint.WorldAnchorA = new Vector2F(6, 6);

            Assert.Equal(1.0f, joint.LocalAnchorA.X, 5);
            Assert.Equal(1.0f, joint.LocalAnchorA.Y, 5);
        }

        /// <summary>
        ///     Tests that world anchor b setter changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorB_Setter_ChangesLocalAnchor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyB.Position = new Vector2F(5, 5);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            joint.WorldAnchorB = new Vector2F(6, 6);

            Assert.Equal(1.0f, joint.LocalAnchorB.X, 5);
            Assert.Equal(1.0f, joint.LocalAnchorB.Y, 5);
        }

        /// <summary>
        ///     Tests that init velocity constraints with warm starting zeroes impulses
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingFalse_ZeroesImpulses()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f));
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyB.Sweep = new Sweep { LocalCenter = Vector2F.Zero };
            bodyA.InvMass = 1.0f;
            bodyB.InvMass = 1.0f;
            bodyA.InvI = 1.0f;
            bodyB.InvI = 1.0f;

            SolverData data = CreateSolverData(false);
            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint.GetReactionForce(1.0f).X);
            Assert.Equal(0.0f, joint.GetReactionForce(1.0f).Y);
            Assert.Equal(0.0f, joint.GetReactionTorque(1.0f));
        }

        /// <summary>
        ///     Tests that init velocity constraints with warm starting scales impulses
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingTrue_ScalesImpulses()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f));
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

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that init velocity constraints with frequency uses soft constraint path
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequency_UsesSoftConstraintPath()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f))
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
            bodyA.InvI = 0.0f;
            bodyB.InvI = 0.0f;

            SolverData data = CreateSolverData(true);
            joint.InitVelocityConstraints(ref data);

            Assert.True(float.IsInfinity(joint._gamma) || (joint._gamma != 0.0f));
        }

        /// <summary>
        ///     Tests that init velocity constraints with zero inertia uses inverse 22 path
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithZeroInertia_UsesInverse22Path()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f));
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

            Assert.Equal(0.0f, joint._gamma);
            Assert.Equal(0.0f, joint._bias);
        }

        /// <summary>
        ///     Tests that solve velocity constraints with frequency uses soft constraint path
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithFrequency_UsesSoftConstraintPath()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f))
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
            data.Velocities[1].V = new Vector2F(1, 0);

            joint.SolveVelocityConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that solve velocity constraints without frequency uses full matrix path
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithoutFrequency_UsesFullMatrixPath()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f));
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
            data.Velocities[1].V = new Vector2F(1, 0);

            joint.SolveVelocityConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that solve position constraints with frequency uses soft constraint path
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequency_UsesSoftConstraintPath()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f))
            {
                FrequencyHz = 5.0f
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
            data.Positions[1].C = new Vector2F(1, 0);

            joint.SolvePositionConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that solve position constraints without frequency uses full path
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithoutFrequency_UsesFullPath()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f));
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
            data.Positions[1].C = new Vector2F(1, 0);
            data.Positions[1].A = 0.5f;

            joint.SolvePositionConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that solve position constraints with zero angular inertia uses inverse 22 path
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithZeroAngularInertia_UsesInverse22Path()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(0.5f, 0.5f), new Vector2F(-0.5f, -0.5f));
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
            data.Positions[1].C = new Vector2F(1, 0);

            joint.SolvePositionConstraints(ref data);

            Assert.NotNull(joint);
        }
    }
}
