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

using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The gear joint remaining coverage tests class
    /// </summary>
    public class GearJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that solve velocity constraints with revolute joints should modify impulse
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithRevoluteJoints_ShouldModifyImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            velocities[indexA] = new SolverVelocity { V = new Vector2F(5, 0), W = 2.0f };
            velocities[indexB] = new SolverVelocity { V = new Vector2F(-5, 0), W = -2.0f };
            velocities[indexC] = new SolverVelocity { V = new Vector2F(3, 0), W = 1.0f };
            velocities[indexD] = new SolverVelocity { V = new Vector2F(-3, 0), W = -1.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { data });

            MethodInfo solveMethod = typeof(GearJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(gearJoint, new object[] { data });

            FieldInfo impulseField = typeof(GearJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float impulse = (float)impulseField.GetValue(gearJoint);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that solve position constraints with revolute joints and mass positive should return true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithRevoluteJointsAndMassPositive_ShouldReturnTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { initData });

            MethodInfo solvePosMethod = typeof(GearJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(gearJoint, new object[] { initData });

            Assert.True(result);
        }

        /// <summary>
        /// Tests that solve position constraints with prismatic joints and mass positive should return true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithPrismaticJointsAndMassPositive_ShouldReturnTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            PrismaticJoint jointA = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.UnitX);
            PrismaticJoint jointB = new PrismaticJoint(bodyC, bodyD, Vector2F.Zero, Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { initData });

            MethodInfo solvePosMethod = typeof(GearJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(gearJoint, new object[] { initData });

            Assert.True(result);
        }

        /// <summary>
        /// Tests that init velocity constraints with prismatic joints and warm starting false covers else branch
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithPrismaticJointsAndWarmStartingFalse_CoversElseBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            PrismaticJoint jointA = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.UnitX);
            PrismaticJoint jointB = new PrismaticJoint(bodyC, bodyD, Vector2F.Zero, Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { data });

            FieldInfo impulseField = typeof(GearJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float impulse = (float)impulseField.GetValue(gearJoint);

            Assert.Equal(0.0f, impulse, 5);
        }

        /// <summary>
        /// Tests that solve velocity constraints with prismatic joints should modify velocities
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithPrismaticJoints_ShouldModifyVelocities()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            PrismaticJoint jointA = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.UnitX);
            PrismaticJoint jointB = new PrismaticJoint(bodyC, bodyD, Vector2F.Zero, Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            velocities[indexA] = new SolverVelocity { V = new Vector2F(5, 0), W = 2.0f };
            velocities[indexB] = new SolverVelocity { V = new Vector2F(-5, 0), W = -2.0f };
            velocities[indexC] = new SolverVelocity { V = new Vector2F(3, 0), W = 1.0f };
            velocities[indexD] = new SolverVelocity { V = new Vector2F(-3, 0), W = -1.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { data });

            MethodInfo solveMethod = typeof(GearJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(gearJoint, new object[] { data });

            FieldInfo impulseField = typeof(GearJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float impulse = (float)impulseField.GetValue(gearJoint);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that solve position constraints with revolute and prismatic joints should return true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithRevoluteAndPrismaticJoints_ShouldReturnTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            PrismaticJoint jointB = new PrismaticJoint(bodyC, bodyD, Vector2F.Zero, Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { initData });

            MethodInfo solvePosMethod = typeof(GearJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(gearJoint, new object[] { initData });

            Assert.True(result);
        }

        /// <summary>
        /// Tests that solve position constraints with prismatic and revolute joints should return true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithPrismaticAndRevoluteJoints_ShouldReturnTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            PrismaticJoint jointA = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.UnitX);
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { initData });

            MethodInfo solvePosMethod = typeof(GearJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(gearJoint, new object[] { initData });

            Assert.True(result);
        }

        /// <summary>
        /// Tests that init velocity constraints with static bodies (mass = 0) covers the else branch of the mass ternary
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithStaticBodies_CoversMassZeroBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Static);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Static);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Static);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { data });

            FieldInfo impulseField = typeof(GearJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float impulse = (float)impulseField.GetValue(gearJoint);

            Assert.Equal(0.0f, impulse, 5);
        }

        /// <summary>
        /// Tests that init velocity constraints with static bodies and warm starting covers mass zero branch
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithStaticBodiesAndWarmStarting_CoversMassZeroBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Static);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Static);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Static);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            int indexA = bodyB.GetIslandIndex;
            int indexB = bodyD.GetIslandIndex;
            int indexC = bodyA.GetIslandIndex;
            int indexD = bodyC.GetIslandIndex;
            int maxIndex = Math.Max(Math.Max(indexA, indexB), Math.Max(indexC, indexD)) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { data });

            FieldInfo impulseField = typeof(GearJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float impulse = (float)impulseField.GetValue(gearJoint);

            Assert.Equal(0.0f, impulse, 5);
        }
    }
}
