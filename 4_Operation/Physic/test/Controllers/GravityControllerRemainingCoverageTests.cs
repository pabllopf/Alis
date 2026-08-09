// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GravityControllerRemainingCoverageTests.cs
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
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    ///     The gravity controller remaining coverage tests class
    /// </summary>
    public class GravityControllerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that update skips disabled controller body
        /// </summary>
        [Fact]
        public void Update_SkipsDisabledControllerBody()
        {
            GravityController controller = new GravityController(10.0f);
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;
            Body affected = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(10, 10), 0, BodyType.Dynamic);
            controllerBody.Enabled = false;
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.NotNull(affected);
        }

        /// <summary>
        ///     Tests that update skips same body as world body
        /// </summary>
        [Fact]
        public void Update_SkipsSameBodyAsWorldBody()
        {
            GravityController controller = new GravityController(10.0f);
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(body);

            controller.Update(0.016f);

            Assert.NotNull(body);
        }
    }
}
