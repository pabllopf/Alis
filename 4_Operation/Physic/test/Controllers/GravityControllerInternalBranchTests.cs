// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GravityControllerInternalBranchTests.cs
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
    ///     Exercises the internal body and point gravity methods directly so that
    ///     every branch of the controller's force computation is reachable.
    ///     These internal methods are visible to the test assembly through
    ///     <c>InternalsVisibleTo</c>.
    /// </summary>
    public class GravityControllerInternalBranchTests
    {
        /// <summary>
        ///     Both the affected body and the gravity source are static. The gravity
        ///     pair must be skipped and no force may accumulate on the body.
        /// </summary>
        [Fact]
        public void ApplyBodyGravity_WhenBothBodiesAreStatic_SkipsPairAndAppliesNoForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(100f, 200f, 1f) { WorldPhysic = world };
            Body worldBody = world.CreateBody(new Vector2F(10f, 0f), 0, BodyType.Static);
            Body controllerBody = world.CreateBody(new Vector2F(0f, 0f), 0, BodyType.Static);
            controller.AddBody(controllerBody);

            controller.ApplyBodyGravity(worldBody);

            Assert.Equal(Vector2F.Zero, worldBody.Force);
        }

        /// <summary>
        ///     The affected body is static while the gravity source is dynamic. The
        ///     static/dynamic static sub-expression is false, so the distance checks
        ///     and the gravity switch are executed. A static body cannot accumulate
        ///     force, so the observable result is still zero.
        /// </summary>
        [Fact]
        public void ApplyBodyGravity_WhenWorldBodyStaticAndSourceDynamic_EvaluatesDistanceAndAppliesNoForceToStaticBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(100f, 200f, 1f) { WorldPhysic = world };
            Body worldBody = world.CreateBody(new Vector2F(10f, 0f), 0, BodyType.Static);
            Body controllerBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.ApplyBodyGravity(worldBody);

            Assert.Equal(Vector2F.Zero, worldBody.Force);
        }

        /// <summary>
        ///     A dynamic affected body and a dynamic source within range must have a
        ///     non-zero force applied by <see cref="GravityController.ApplyBodyGravity"/>.
        /// </summary>
        [Fact]
        public void ApplyBodyGravity_WhenDynamicPairWithinRange_AppliesNonZeroForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(100f, 200f, 1f) { WorldPhysic = world };
            Body worldBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(10f, 0f), BodyType.Dynamic);
            Body controllerBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.ApplyBodyGravity(worldBody);

            Assert.NotEqual(Vector2F.Zero, worldBody.Force);
        }

        /// <summary>
        ///     An unsupported gravity type must fall through the switch without
        ///     applying any force to the affected body.
        /// </summary>
        [Fact]
        public void ApplyBodyGravity_WhenGravityTypeIsUnsupported_AppliesNoForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(100f, 200f, 1f)
            {
                WorldPhysic = world,
                GravityType = (GravityType)999
            };
            Body worldBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(10f, 0f), BodyType.Dynamic);
            Body controllerBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.ApplyBodyGravity(worldBody);

            Assert.Equal(Vector2F.Zero, worldBody.Force);
        }

        /// <summary>
        ///     An unsupported gravity type must fall through the point switch without
        ///     applying any force to the affected body.
        /// </summary>
        [Fact]
        public void ApplyPointGravity_WhenGravityTypeIsUnsupported_AppliesNoForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(100f, 200f, 1f)
            {
                WorldPhysic = world,
                GravityType = (GravityType)999
            };
            Body worldBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(10f, 0f), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0f, 0f));

            controller.ApplyPointGravity(worldBody);

            Assert.Equal(Vector2F.Zero, worldBody.Force);
        }
    }
}
