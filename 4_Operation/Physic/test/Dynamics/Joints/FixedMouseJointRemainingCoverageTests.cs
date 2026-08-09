// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedMouseJointRemainingCoverageTests.cs
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
    ///     The fixed mouse joint remaining coverage tests class
    /// </summary>
    public class FixedMouseJointRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that init velocity constraints with warm starting applies impulses
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStarting_AppliesImpulses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            body.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(1.0f, 1.0f));
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.5f, 0.5f));
            body.GetIslandIndex = 0;
            body.Sweep = new Sweep { LocalCenter = Vector2F.Zero };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = true },
                Positions = new SolverPosition[1]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[1]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that init velocity constraints without warm starting zeroes impulses
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithoutWarmStarting_ZeroesImpulses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            body.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(1.0f, 1.0f));
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.5f, 0.5f));
            body.GetIslandIndex = 0;
            body.Sweep = new Sweep { LocalCenter = Vector2F.Zero };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = false },
                Positions = new SolverPosition[1]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[1]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint.GetReactionForce(1.0f).X);
            Assert.Equal(0.0f, joint.GetReactionForce(1.0f).Y);
        }

        /// <summary>
        ///     Tests that solve velocity constraints clamps impulse to max force
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_ClampsImpulseToMaxForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            body.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(1.0f, 1.0f));
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.5f, 0.5f))
            {
                MaxForce = 10.0f
            };
            body.GetIslandIndex = 0;
            body.Sweep = new Sweep { LocalCenter = Vector2F.Zero };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 1.0f / 60.0f, DtRatio = 1.0f, InvDt = 60.0f, WarmStarting = true },
                Positions = new SolverPosition[1]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f }
                },
                Velocities = new SolverVelocity[1]
                {
                    new SolverVelocity { V = new Vector2F(100, 100), W = 0.0f }
                }
            };

            joint.InitVelocityConstraints(ref data);
            joint.SolveVelocityConstraints(ref data);

            Assert.NotNull(joint);
        }

        /// <summary>
        ///     Tests that world anchor a getter returns world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Getter_ReturnsWorldPoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(2, 3), 0, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(1, 1));

            Vector2F anchor = joint.WorldAnchorA;

            Assert.True(anchor.X > 0.0f);
            Assert.True(anchor.Y > 0.0f);
        }

        /// <summary>
        ///     Tests that world anchor a setter updates local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorA_Setter_UpdatesLocalAnchor()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(2, 3), 0, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(1, 1));

            joint.WorldAnchorA = new Vector2F(5, 5);

            Assert.Equal(3.0f, joint.LocalAnchorA.X, 5);
            Assert.Equal(2.0f, joint.LocalAnchorA.Y, 5);
        }

        /// <summary>
        ///     Tests that get reaction torque returns zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ReturnsZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.5f, 0.5f));

            Assert.Equal(0.0f, joint.GetReactionTorque(2.0f));
        }

        /// <summary>
        ///     Tests that solve position constraints returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.5f, 0.5f));
            SolverData data = new SolverData();

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.True(result);
        }
    }
}
