// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The world physic remaining coverage tests class
    /// </summary>
    public class WorldPhysicRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that test point returns fixture when point inside
        /// </summary>
        [Fact]
        public void TestPoint_WithPointInside_ReturnsFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 1.0f));

            Fixture result = world.TestPoint(new Vector2F(0.5f, 0));

            Assert.Same(fixture, result);
        }

        /// <summary>
        ///     Tests that test point with point outside returns null
        /// </summary>
        [Fact]
        public void TestPoint_WithPointOutside_ReturnsNull()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);
            body.CreateFixture(new CircleShape(1.0f, 1.0f));

            Fixture result = world.TestPoint(new Vector2F(50, 50));

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that query aabb invokes callback for overlapping fixture
        /// </summary>
        [Fact]
        public void QueryAabb_WithOverlappingFixture_InvokesCallback()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);
            body.CreateFixture(new CircleShape(1.0f, 1.0f));

            bool called = false;
            world.QueryAabb(fixture =>
            {
                called = true;
                return true;
            }, new Aabb(new Vector2F(-2, -2), new Vector2F(2, 2)));

            Assert.True(called);
        }
    }
}
