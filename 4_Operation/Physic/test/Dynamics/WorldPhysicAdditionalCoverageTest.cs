// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicAdditionalCoverageTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The world physic decomposition experiment test class
    /// </summary>
    public class WorldPhysicAdditionalCoverageTest
    {
        /// <summary>
        ///     Tests that a capsule with few edges uses the direct polygon path
        /// </summary>
        [Fact]
        public void CreateCapsule_WithFewEdges_UsesPolygonPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body body = world.CreateCapsule(2.0f, 0.5f, 1, 0.5f, 1, 1.0f, new Vector2F(0, 0), 0, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.True(body.FixtureList.List.Count >= 1);
        }

        /// <summary>
        ///     Tests that removing a null body throws an argument null exception
        /// </summary>
        [Fact]
        public void Remove_WithNullBody_ThrowsArgumentNullException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Assert.Throws<ArgumentNullException>(() => world.Remove((Body) null));
        }

        /// <summary>
        ///     Tests that removing a body while the world is locked during a step throws an invalid operation exception
        /// </summary>
        [Fact]
        public void Remove_WhileWorldLocked_ThrowsInvalidOperationException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.OnCollision += (fixtureA, fixtureB, contact) =>
            {
                world.Remove(bodyB);
                return true;
            };

            Assert.Throws<InvalidOperationException>(() => world.Step(1.0f / 60.0f));
        }
    }
}
