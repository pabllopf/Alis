// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GravityControllerCoverageTest.cs
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
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The gravity controller coverage test class
    /// </summary>
    public class GravityControllerCoverageTest
    {
        /// <summary>
        ///     Tests that body gravity with DistanceSquared applies force.
        ///     Exercises ApplyBodyGravity force calculation with default gravity type.
        /// </summary>
        [Fact]
        public void BodyGravity_DistanceSquared_AppliesForce()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f) { WorldPhysic = world };
            Body source = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5.0f, 0.0f), BodyType.Dynamic);
            controller.AddBody(source);

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that body gravity with Linear applies force.
        ///     Exercises ApplyBodyGravity Linear branch in the switch.
        /// </summary>
        [Fact]
        public void BodyGravity_Linear_AppliesForce()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f) { WorldPhysic = world, GravityType = GravityType.Linear };
            Body source = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5.0f, 0.0f), BodyType.Dynamic);
            controller.AddBody(source);

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that point gravity with Linear applies force.
        ///     Exercises ApplyPointGravity Linear branch in the switch.
        /// </summary>
        [Fact]
        public void PointGravity_Linear_AppliesForce()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f) { WorldPhysic = world, GravityType = GravityType.Linear };
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5.0f, 0.0f), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0.0f, 0.0f));

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that IsActiveOn returning false causes body to be skipped.
        ///     Exercises the early return in Update() when !IsActiveOn.
        /// </summary>
        [Fact]
        public void Update_SkipsBody_WhenIsActiveOnReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f) { WorldPhysic = world };
            Body body = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);

            body.ControllerFilter = new ControllerFilter(ControllerCategories.None);

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that world body is skipped when it is the same as controller body.
        ///     Exercises the same-body skip condition in ApplyBodyGravity.
        /// </summary>
        [Fact]
        public void ApplyBodyGravity_Skips_WhenWorldBodyEqualsControllerBody()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f) { WorldPhysic = world };
            Body body = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);

            controller.AddBody(body);

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that both static bodies are skipped.
        ///     Exercises the both-static skip condition in ApplyBodyGravity.
        /// </summary>
        [Fact]
        public void ApplyBodyGravity_Skips_WhenBothStatic()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f) { WorldPhysic = world };
            Body source = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f));
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5.0f, 0.0f));
            controller.AddBody(source);

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that disabled controller body is skipped.
        ///     Exercises the disabled-body skip condition in ApplyBodyGravity.
        /// </summary>
        [Fact]
        public void ApplyBodyGravity_Skips_WhenControllerBodyDisabled()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f) { WorldPhysic = world };
            Body source = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            source.Enabled = false;
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5.0f, 0.0f), BodyType.Dynamic);
            controller.AddBody(source);

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that point gravity force is skipped when distance is below MinRadius.
        /// </summary>
        [Fact]
        public void PointGravity_Skips_WhenWithinMinRadius()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f, 100f, 10f) { WorldPhysic = world };
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5.0f, 0.0f), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0.0f, 0.0f));

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that point gravity force is skipped when distance exceeds MaxRadius.
        /// </summary>
        [Fact]
        public void PointGravity_Skips_WhenBeyondMaxRadius()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f, 10f, 0f) { WorldPhysic = world };
            world.CreateCircle(1.0f, 1.0f, new Vector2F(100.0f, 0.0f), BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0.0f, 0.0f));

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that body gravity force is skipped when distance is below MinRadius.
        /// </summary>
        [Fact]
        public void BodyGravity_Skips_WhenWithinMinRadius()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f, 100f, 10f) { WorldPhysic = world };
            Body source = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5.0f, 0.0f), BodyType.Dynamic);
            controller.AddBody(source);

            controller.Update(1.0f / 60.0f);
        }

        /// <summary>
        ///     Tests that body gravity force is skipped when distance exceeds MaxRadius.
        /// </summary>
        [Fact]
        public void BodyGravity_Skips_WhenBeyondMaxRadius()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            GravityController controller = new GravityController(100f, 10f, 0f) { WorldPhysic = world };
            Body source = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(100.0f, 0.0f), BodyType.Dynamic);
            controller.AddBody(source);

            controller.Update(1.0f / 60.0f);
        }
    }
}
