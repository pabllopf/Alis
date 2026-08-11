// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The fixture coverage tests class
    /// </summary>
    public class FixtureCoverageTests
    {
        /// <summary>
        ///     Tests that refilter without a world returns early
        /// </summary>
        [Fact]
        public void Refilter_WithoutWorld_ReturnsEarly()
        {
            Body body = new Body();
            Fixture fixture = body.CreateFixture(new CircleShape(0.5f, 1.0f));

            fixture.Refilter();

            Assert.NotNull(fixture);
        }

        /// <summary>
        ///     Tests that create proxies when already created should throw
        /// </summary>
        [Fact]
        public void CreateProxies_WhenAlreadyCreated_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Fixture fixture = body.FixtureList[0];

            Assert.Throws<InvalidOperationException>(() => fixture.CreateProxies(world.ContactManager.BroadPhase, ref body.Xf));
        }
    }
}
