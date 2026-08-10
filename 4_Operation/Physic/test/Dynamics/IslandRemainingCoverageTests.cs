// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandRemainingCoverageTests.cs
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
    ///     The island remaining coverage tests class
    /// </summary>
    public class IslandRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that solve velocity constraints with disabled joint skips it
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithDisabledJoint_SkipsIt()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            bodyA.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(0.5f, 1.0f));
            bodyB.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(0.5f, 1.0f));
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
            {
                Enabled = false
            };
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.False(joint.Enabled);
        }

        /// <summary>
        ///     Tests that solve position constraints with disabled joint skips it
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithDisabledJoint_SkipsIt()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            bodyA.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(0.5f, 1.0f));
            bodyB.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(0.5f, 1.0f));
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
            {
                Enabled = false
            };
            world.Add(joint);

            world.Step(1.0f / 60.0f);
            world.Step(1.0f / 60.0f);

            Assert.False(joint.Enabled);
        }

        /// <summary>
        ///     Tests that solve with enabled joint through world step works
        /// </summary>
        [Fact]
        public void Solve_WithEnabledJoint_ThroughWorldStep_Works()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            bodyA.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(0.5f, 1.0f));
            bodyB.CreateFixture(new Alis.Core.Physic.Collisions.Shapes.CircleShape(0.5f, 1.0f));
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.True(joint.Enabled);
        }
    }
}
