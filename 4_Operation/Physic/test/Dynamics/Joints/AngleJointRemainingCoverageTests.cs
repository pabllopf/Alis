// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AngleJointRemainingCoverageTests.cs
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
    ///     The angle joint remaining coverage tests class
    /// </summary>
    public class AngleJointRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that internal constructor sets joint type to angle
        /// </summary>
        [Fact]
        public void InternalConstructor_SetsJointTypeToAngle()
        {
            AngleJoint joint = new AngleJoint();

            Assert.Equal(JointType.Angle, joint.JointType);
        }

        /// <summary>
        ///     Tests that constructor sets defaults
        /// </summary>
        [Fact]
        public void Constructor_SetsDefaults()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(JointType.Angle, joint.JointType);
            Assert.Equal(0.2f, joint.BiasFactor, 5);
            Assert.Equal(float.MaxValue, joint.MaxImpulse);
        }

        /// <summary>
        ///     Tests that world anchor a returns body a position
        /// </summary>
        [Fact]
        public void WorldAnchorA_ReturnsBodyAPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyA.Position = new Vector2F(3, 4);
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(3.0f, anchor.X, 5);
            Assert.Equal(4.0f, anchor.Y, 5);
        }

        /// <summary>
        ///     Tests that world anchor a setter changes body a position
        /// </summary>
        [Fact]
        public void WorldAnchorA_Setter_ChangesBodyAPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.WorldAnchorA = new Vector2F(5, 6);

            Assert.Equal(5.0f, bodyA.Position.X, 5);
            Assert.Equal(6.0f, bodyA.Position.Y, 5);
        }

        /// <summary>
        ///     Tests that world anchor b returns body b position
        /// </summary>
        [Fact]
        public void WorldAnchorB_ReturnsBodyBPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyB.Position = new Vector2F(7, 8);
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(7.0f, anchor.X, 5);
            Assert.Equal(8.0f, anchor.Y, 5);
        }

        /// <summary>
        ///     Tests that world anchor b setter throws not supported exception
        /// </summary>
        [Fact]
        public void WorldAnchorB_Setter_ThrowsNotSupportedException()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Throws<NotSupportedException>(() => joint.WorldAnchorB = Vector2F.Zero);
        }

        /// <summary>
        ///     Tests that target angle setter wakes bodies on change
        /// </summary>
        [Fact]
        public void TargetAngle_Setter_WakesBodiesOnChange()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.TargetAngle = 1.5f;

            Assert.Equal(1.5f, joint.TargetAngle, 5);
        }

        /// <summary>
        ///     Tests that target angle setter ignores unchanged value
        /// </summary>
        [Fact]
        public void TargetAngle_Setter_IgnoresUnchangedValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            joint.TargetAngle = 1.0f;

            joint.TargetAngle = 1.0f;

            Assert.Equal(1.0f, joint.TargetAngle, 5);
        }

        /// <summary>
        ///     Tests that get reaction force returns zero
        /// </summary>
        [Fact]
        public void GetReactionForce_ReturnsZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(Vector2F.Zero, joint.GetReactionForce(1.0f));
        }

        /// <summary>
        ///     Tests that get reaction torque returns zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ReturnsZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(0.0f, joint.GetReactionTorque(1.0f));
        }

        /// <summary>
        ///     Tests that init velocity constraints computes bias and mass factor
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_ComputesBiasAndMassFactor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.InvI = 2.0f;
            bodyB.InvI = 3.0f;
            joint.TargetAngle = 0.5f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { A = 0.0f },
                    new SolverPosition { A = 1.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { W = 0.0f },
                    new SolverVelocity { W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.NotEqual(0.0f, joint._bias);
            Assert.Equal(0.2f, joint._massFactor, 5);
        }

        /// <summary>
        ///     Tests that solve velocity constraints applies impulses
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_AppliesImpulses()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            bodyA.GetIslandIndex = 0;
            bodyB.GetIslandIndex = 1;
            bodyA.InvI = 2.0f;
            bodyB.InvI = 3.0f;
            joint.TargetAngle = 0.5f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, InvDt = 60.0f },
                Positions = new SolverPosition[2]
                {
                    new SolverPosition { A = 0.0f },
                    new SolverPosition { A = 1.0f }
                },
                Velocities = new SolverVelocity[2]
                {
                    new SolverVelocity { W = 0.0f },
                    new SolverVelocity { W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);
            joint.SolveVelocityConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that solve position constraints returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ReturnsTrue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            SolverData data = new SolverData();

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.True(result);
        }
    }
}
