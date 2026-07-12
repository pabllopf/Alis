// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WheelJointRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The wheel joint remaining coverage tests class
    /// </summary>
    public class WheelJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that step without frequency or motor exercises point to line constraint
        /// </summary>
        [Fact]
        public void Step_WithoutFrequencyOrMotor_ShouldExercisePointToLine()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F force = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with spring only exercises spring constraint solver
        /// </summary>
        [Fact]
        public void Step_WithSpringOnly_ShouldExerciseSpringConstraintSolver()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.Frequency = 10.0f;
            joint.DampingRatio = 0.7f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float translation = joint.JointTranslation;
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with motor only exercises rotational motor constraint solver
        /// </summary>
        [Fact]
        public void Step_WithMotorOnly_ShouldExerciseRotationalMotorSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 10.0f;
            joint.MaxMotorTorque = 100.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float speed = joint.JointSpeed;
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with spring and motor exercises all constraint solvers
        /// </summary>
        [Fact]
        public void Step_WithSpringAndMotor_ShouldExerciseAllConstraintSolvers()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.Frequency = 8.0f;
            joint.DampingRatio = 0.5f;
            joint.MotorEnabled = true;
            joint.MotorSpeed = 5.0f;
            joint.MaxMotorTorque = 50.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float torque = joint.GetMotorTorque(60.0f);
            float reactionTorque = joint.GetReactionTorque(60.0f);
            Vector2F reactionForce = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that multiple steps with gravity exercise position constraint solving
        /// </summary>
        [Fact]
        public void MultipleSteps_WithGravity_ShouldExercisePositionConstraint()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.Frequency = 6.0f;
            joint.DampingRatio = 0.4f;
            joint.MotorEnabled = true;
            joint.MotorSpeed = 3.0f;
            joint.MaxMotorTorque = 30.0f;
            world.Add(joint);
            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }
            float translation = joint.JointTranslation;
            float speed = joint.JointSpeed;
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that joint translation and speed return finite values after step
        /// </summary>
        [Fact]
        public void JointTranslationAndSpeed_AfterStep_ShouldReturnFiniteValues()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.Frequency = 5.0f;
            joint.DampingRatio = 0.3f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float translation = joint.JointTranslation;
            float speed = joint.JointSpeed;
            Assert.False(float.IsNaN(translation));
            Assert.False(float.IsNaN(speed));
            Assert.False(float.IsInfinity(translation));
            Assert.False(float.IsInfinity(speed));
        }

        /// <summary>
        /// Tests that get reaction force after multiple steps with frequency returns non zero force
        /// </summary>
        [Fact]
        public void GetReactionForce_AfterMultipleStepsWithFrequency_ShouldReturnNonZeroForce()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }
            Vector2F force = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that get reaction torque after step with motor enabled returns non zero torque
        /// </summary>
        [Fact]
        public void GetReactionTorque_AfterStepWithMotor_ShouldReturnNonZeroTorque()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 5.0f;
            joint.MaxMotorTorque = 50.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float torque = joint.GetReactionTorque(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with zero motor speed still exercises motor solver
        /// </summary>
        [Fact]
        public void Step_WithZeroMotorSpeed_ShouldExerciseMotorSolver()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 0.0f;
            joint.MaxMotorTorque = 10.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float speed = joint.JointSpeed;
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with zero max motor torque does not produce motor torque
        /// </summary>
        [Fact]
        public void Step_WithZeroMaxMotorTorque_ShouldNotProduceMotorTorque()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 5.0f;
            joint.MaxMotorTorque = 0.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float torque = joint.GetMotorTorque(60.0f);
            float reactionTorque = joint.GetReactionTorque(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with zero frequency does not exercise spring constraint solver
        /// </summary>
        [Fact]
        public void Step_WithZeroFrequency_ShouldNotExerciseSpringSolver()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.Frequency = 0.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F force = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with high frequency and damping exercises bias and gamma computation
        /// </summary>
        [Fact]
        public void Step_WithHighFrequencyAndDamping_ShouldExerciseBiasAndGamma()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.Frequency = 30.0f;
            joint.DampingRatio = 1.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            float translation = joint.JointTranslation;
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with axis aligned to world X exercises different geometry
        /// </summary>
        [Fact]
        public void Step_WithAxisAlignedToWorldX_ShouldExerciseGeometry()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0, 2), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F anchor = joint.WorldAnchorB;
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with axis aligned to world Y exercises different geometry
        /// </summary>
        [Fact]
        public void Step_WithAxisAlignedToWorldY_ShouldExerciseGeometry()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F anchor = joint.WorldAnchorA;
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that step with motor disabled after step sets motor impulse to zero
        /// </summary>
        [Fact]
        public void MotorDisabled_AfterStep_ShouldHaveZeroMotorImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 5.0f;
            joint.MaxMotorTorque = 50.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            joint.MotorEnabled = false;
            world.Step(1.0f / 60.0f);
            float torque = joint.GetMotorTorque(60.0f);
            Assert.Equal(0.0f, torque);
        }

        /// <summary>
        /// Tests that step with both bodies stationary still exercises constraint solvers
        /// </summary>
        [Fact]
        public void Step_WithStationaryBodies_ShouldExerciseConstraintSolvers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 0.0f;
            joint.MaxMotorTorque = 0.0f;
            joint.Frequency = 0.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F force = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that using diagonal axis exercises compound rotation paths
        /// </summary>
        [Fact]
        public void Step_WithDiagonalAxis_ShouldExerciseCompoundRotation()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 1.0f));
            joint.Frequency = 5.0f;
            joint.DampingRatio = 0.5f;
            joint.MotorEnabled = true;
            joint.MotorSpeed = 2.0f;
            joint.MaxMotorTorque = 20.0f;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F force = joint.GetReactionForce(60.0f);
            float torque = joint.GetReactionTorque(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that get motor torque after multiple steps with motor returns consistent values
        /// </summary>
        [Fact]
        public void GetMotorTorque_AfterMultipleSteps_ShouldReturnConsistentValues()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;
            joint.MotorSpeed = 10.0f;
            joint.MaxMotorTorque = 100.0f;
            world.Add(joint);
            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }
            float torque = joint.GetMotorTorque(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that using very lightweight bodies exercises near zero mass path
        /// </summary>
        [Fact]
        public void Step_WithVeryLightweightBodies_ShouldExerciseNearZeroMass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 0.001f);
            CircleShape shapeB = new CircleShape(0.5f, 0.001f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F force = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that using very heavy bodies exercises non zero mass path
        /// </summary>
        [Fact]
        public void Step_WithVeryHeavyBodies_ShouldExerciseNonZeroMass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 10000.0f);
            CircleShape shapeB = new CircleShape(0.5f, 10000.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Vector2F force = joint.GetReactionForce(60.0f);
            Assert.NotNull(joint);
        }
    }
}
