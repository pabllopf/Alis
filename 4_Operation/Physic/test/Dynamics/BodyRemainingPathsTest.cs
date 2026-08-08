// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyRemainingPathsTest.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Tests for Body simulation paths that require WorldPhysic.Step().
    /// </summary>
    public class BodyRemainingPathsTest
    {
        /// <summary>
        ///     Verifies that a body with FixedRotation=true does not rotate when an off-center
        ///     force is applied during Step(). This exercises the FixedRotation check in
        ///     the contact solver and velocity solver.
        /// </summary>
        [Fact]
        public void FixedRotation_PreventsRotation_WhenOffCenterForceApplied()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.FixedRotation = true;

            body.ApplyForce(new Vector2F(100.0f, 0.0f), new Vector2F(0.0f, 1.0f));

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0.0f, body.AngularVelocity, 4);
        }

        /// <summary>
        ///     Verifies that a body with IgnoreGravity=true is not affected by world gravity
        ///     during Step().
        /// </summary>
        [Fact]
        public void IgnoreGravity_PreventsGravity_WhenFalling()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));
            Body normal = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(0.0f, 5.0f), 0.0f, BodyType.Dynamic);
            Body ignores = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(2.0f, 5.0f), 0.0f, BodyType.Dynamic);
            ignores.IgnoreGravity = true;

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.True(ignores.Position.Y > normal.Position.Y, "IgnoreGravity body should fall slower (or not at all) than normal body");
        }

        /// <summary>
        ///     Verifies that a disabled body does not move during Step() even when forces are applied.
        /// </summary>
        [Fact]
        public void EnabledFalse_PreventsMovement_DuringStep()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.Enabled = false;
            body.LinearVelocity = new Vector2F(100.0f, 0.0f);

            Vector2F before = body.Position;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(before.X, body.Position.X, 4);
            Assert.Equal(before.Y, body.Position.Y, 4);
        }

        /// <summary>
        ///     Verifies the sleep/wake cycle: a body with SleepingAllowed=true lands on a static
        ///     ground, comes to rest, falls asleep, then wakes when a force is applied.
        /// </summary>
        [Fact]
        public void SleepWake_Cycle_WorksOverSteps()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));
            world.CreateRectangle(10.0f, 1.0f, 0.0f, new Vector2F(0.0f, -5.0f), 0.0f, BodyType.Static);
            Body body = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 5.0f), BodyType.Dynamic);
            body.SleepingAllowed = true;

            for (int i = 0; i < 500; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.False(body.Awake);

            body.ApplyForce(new Vector2F(0.0f, 200.0f));

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(body.Awake);
        }

        /// <summary>
        ///     Verifies that two bodies connected by a joint with CollideConnected=false
        ///     do NOT push each other apart during Step().
        /// </summary>
        [Fact]
        public void JointCollideConnectedFalse_PreventsCollision_OverlappingBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            DistanceJoint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            joint.CollideConnected = false;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        ///     Verifies that setting Rotation on a body attached to a world updates the transform.
        ///     This exercises the world-attached path in the Rotation setter.
        /// </summary>
        [Fact]
        public void RotationSetter_WithWorld_UpdatesTransform()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            float expected = 1.5f;
            body.Rotation = expected;

            Assert.Equal(expected, body.Rotation, 4);
        }
    }
}
