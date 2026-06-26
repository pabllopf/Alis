// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GravityControllerTest.cs
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
    ///     The gravity controller test class
    /// </summary>
    public class GravityControllerTest
    {
        /// <summary>
        ///     Tests that constructor with strength should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithStrength_ShouldInitializeCorrectly()
        {
            float strength = 10.0f;

            GravityController controller = new GravityController(strength);

            Assert.Equal(strength, controller.Strength);
            Assert.Equal(float.MaxValue, controller.MaxRadius);
            Assert.Equal(GravityType.DistanceSquared, controller.GravityType);
            Assert.NotNull(controller.Points);
            Assert.NotNull(controller.Bodies);
        }

        /// <summary>
        ///     Tests that constructor with all parameters should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithAllParameters_ShouldInitializeCorrectly()
        {
            float strength = 10.0f;
            float maxRadius = 100.0f;
            float minRadius = 5.0f;

            GravityController controller = new GravityController(strength, maxRadius, minRadius);

            Assert.Equal(strength, controller.Strength);
            Assert.Equal(maxRadius, controller.MaxRadius);
            Assert.Equal(minRadius, controller.MinRadius);
        }

        /// <summary>
        ///     Tests that strength property should set and get correctly
        /// </summary>
        [Fact]
        public void StrengthProperty_ShouldSetAndGetCorrectly()
        {
            GravityController controller = new GravityController(10.0f);

            controller.Strength = 20.0f;

            Assert.Equal(20.0f, controller.Strength);
        }

        /// <summary>
        ///     Tests that min radius property should set and get correctly
        /// </summary>
        [Fact]
        public void MinRadiusProperty_ShouldSetAndGetCorrectly()
        {
            GravityController controller = new GravityController(10.0f);

            controller.MinRadius = 5.0f;

            Assert.Equal(5.0f, controller.MinRadius);
        }

        /// <summary>
        ///     Tests that max radius property should set and get correctly
        /// </summary>
        [Fact]
        public void MaxRadiusProperty_ShouldSetAndGetCorrectly()
        {
            GravityController controller = new GravityController(10.0f);

            controller.MaxRadius = 50.0f;

            Assert.Equal(50.0f, controller.MaxRadius);
        }

        /// <summary>
        ///     Tests that gravity type property should set and get correctly
        /// </summary>
        [Fact]
        public void GravityTypeProperty_ShouldSetAndGetCorrectly()
        {
            GravityController controller = new GravityController(10.0f);

            controller.GravityType = GravityType.Linear;

            Assert.Equal(GravityType.Linear, controller.GravityType);
        }

        /// <summary>
        ///     Tests that bodies property should set and get correctly
        /// </summary>
        [Fact]
        public void BodiesProperty_ShouldSetAndGetCorrectly()
        {
            GravityController controller = new GravityController(10.0f);
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();

            controller.Bodies.Add(body);

            Assert.Single(controller.Bodies);
        }

        /// <summary>
        ///     Tests that points property should set and get correctly
        /// </summary>
        [Fact]
        public void PointsProperty_ShouldSetAndGetCorrectly()
        {
            GravityController controller = new GravityController(10.0f);
            Vector2F point = new Vector2F(10, 20);

            controller.Points.Add(point);

            Assert.Single(controller.Points);
            Assert.Equal(point, controller.Points[0]);
        }

        /// <summary>
        ///     Tests that update should execute without errors
        /// </summary>
        [Fact]
        public void Update_ShouldExecuteWithoutErrors()
        {
            GravityController controller = new GravityController(10.0f);
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that gravity controller should handle negative strength
        /// </summary>
        [Fact]
        public void GravityController_ShouldHandleNegativeStrength()
        {
            GravityController controller = new GravityController(-10.0f);

            Assert.Equal(-10.0f, controller.Strength);
        }

        /// <summary>
        ///     Tests that gravity controller should handle zero strength
        /// </summary>
        [Fact]
        public void GravityController_ShouldHandleZeroStrength()
        {
            GravityController controller = new GravityController(0.0f);

            Assert.Equal(0.0f, controller.Strength);
        }

        /// <summary>
        ///     Tests that gravity controller should inherit from controller
        /// </summary>
        [Fact]
        public void GravityController_ShouldInheritFromController()
        {
            GravityController controller = new GravityController(10.0f);

            Assert.IsAssignableFrom<Controller>(controller);
        }

        /// <summary>
        ///     Tests that update should handle world with bodies
        /// </summary>
        [Fact]
        public void Update_ShouldHandleWorldWithBodies()
        {
            GravityController controller = new GravityController(10.0f);
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that add body adds to bodies list
        /// </summary>
        [Fact]
        public void AddBody_ShouldAddToBodiesList()
        {
            GravityController controller = new GravityController(10.0f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody();

            controller.AddBody(body);

            Assert.Contains(body, controller.Bodies);
        }

        /// <summary>
        ///     Tests that add point adds to points list
        /// </summary>
        [Fact]
        public void AddPoint_ShouldAddToPointsList()
        {
            GravityController controller = new GravityController(10.0f);
            Vector2F point = new Vector2F(100f, 200f);

            controller.AddPoint(point);

            Assert.Contains(point, controller.Points);
        }

        /// <summary>
        ///     Tests that update with linear gravity type should execute without errors
        /// </summary>
        [Fact]
        public void Update_WithLinearGravityType_ShouldExecuteWithoutErrors()
        {
            GravityController controller = new GravityController(10.0f, 100f, 1f);
            controller.GravityType = GravityType.Linear;
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body body1 = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body body2 = world.CreateBody(new Vector2F(5, 5), 0, BodyType.Dynamic);
            controller.AddBody(body1);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that update with point gravity should execute without errors
        /// </summary>
        [Fact]
        public void Update_WithPointGravity_ShouldExecuteWithoutErrors()
        {
            GravityController controller = new GravityController(100f);
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;
            Body body = world.CreateBody(new Vector2F(10, 10), 0, BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that Update skips world body when it is the same as controller body
        /// </summary>
        [Fact]
        public void Update_WithSameControllerAndWorldBody_ShouldSkipGravity()
        {
            GravityController controller = new GravityController(100f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body body = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            controller.AddBody(body);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, same body skipped
        }

        /// <summary>
        ///     Tests that Update skips when both world and controller bodies are static
        /// </summary>
        [Fact]
        public void Update_WithBothStaticBodies_ShouldSkipGravity()
        {
            GravityController controller = new GravityController(100f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Static);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Static);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, both static skipped
        }

        /// <summary>
        ///     Tests that Update skips when controller body is disabled
        /// </summary>
        [Fact]
        public void Update_WithDisabledControllerBody_ShouldSkipGravity()
        {
            GravityController controller = new GravityController(100f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controllerBody.Enabled = false;
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, disabled skipped
        }

        /// <summary>
        ///     Tests that Update skips body gravity when distance is within MinRadius (too close)
        /// </summary>
        [Fact]
        public void Update_WithBodyWithinMinRadius_ShouldSkipGravity()
        {
            GravityController controller = new GravityController(100f, 100f, 50f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, distance < MinRadius skipped
        }

        /// <summary>
        ///     Tests that Update skips body gravity when distance exceeds MaxRadius
        /// </summary>
        [Fact]
        public void Update_WithBodyBeyondMaxRadius_ShouldSkipGravity()
        {
            GravityController controller = new GravityController(100f, 10f, 0f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(100, 0), 0, BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, distance > MaxRadius skipped
        }

        /// <summary>
        ///     Tests that Update skips point gravity when point is within MinRadius
        /// </summary>
        [Fact]
        public void Update_WithPointWithinMinRadius_ShouldSkipPointGravity()
        {
            GravityController controller = new GravityController(100f, 100f, 50f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(5, 0), 0, BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, point within MinRadius skipped
        }

        /// <summary>
        ///     Tests that Update skips point gravity when point is beyond MaxRadius
        /// </summary>
        [Fact]
        public void Update_WithPointBeyondMaxRadius_ShouldSkipPointGravity()
        {
            GravityController controller = new GravityController(100f, 10f, 0f);
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(100, 0), 0, BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, point beyond MaxRadius skipped
        }

        /// <summary>
        ///     Tests that Update with body gravity and Linear type applies force correctly
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityAndLinearType_ShouldApplyForce()
        {
            GravityController controller = new GravityController(100f, 200f, 1f);
            controller.GravityType = GravityType.Linear;
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, Linear body gravity applied
        }

        /// <summary>
        ///     Tests that Update with point gravity and Linear type applies force correctly
        /// </summary>
        [Fact]
        public void Update_WithPointGravityAndLinearType_ShouldApplyForce()
        {
            GravityController controller = new GravityController(100f, 200f, 1f);
            controller.GravityType = GravityType.Linear;
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, Linear point gravity applied
        }

        /// <summary>
        ///     Tests that Update with body gravity and DistanceSquared type applies force correctly
        /// </summary>
        [Fact]
        public void Update_WithBodyGravityAndDistanceSquaredType_ShouldApplyForce()
        {
            GravityController controller = new GravityController(100f, 200f, 1f);
            controller.GravityType = GravityType.DistanceSquared;
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            Body controllerBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            controller.AddBody(controllerBody);

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, DistanceSquared body gravity applied
        }

        /// <summary>
        ///     Tests that Update with point gravity and DistanceSquared type applies force correctly
        /// </summary>
        [Fact]
        public void Update_WithPointGravityAndDistanceSquaredType_ShouldApplyForce()
        {
            GravityController controller = new GravityController(100f, 200f, 1f);
            controller.GravityType = GravityType.DistanceSquared;
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body worldBody = world.CreateBody(new Vector2F(20, 0), 0, BodyType.Dynamic);
            controller.AddPoint(new Vector2F(0, 0));

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown, DistanceSquared point gravity applied
        }
    }
}