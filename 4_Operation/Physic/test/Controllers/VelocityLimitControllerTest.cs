// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VelocityLimitControllerTest.cs
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
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    ///     The velocity limit controller test class
    /// </summary>
    public class VelocityLimitControllerTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default limits
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultLimits()
        {
            VelocityLimitController controller = new VelocityLimitController();

            Assert.True(controller.MaxLinearVelocity > 0);
            Assert.True(controller.MaxAngularVelocity > 0);
            Assert.True(controller.LimitLinearVelocity);
            Assert.True(controller.LimitAngularVelocity);
        }

        /// <summary>
        ///     Tests that constructor with parameters should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithParameters_ShouldInitializeCorrectly()
        {
            float maxLinear = 50.0f;
            float maxAngular = 10.0f;

            VelocityLimitController controller = new VelocityLimitController(maxLinear, maxAngular);

            Assert.Equal(maxLinear, controller.MaxLinearVelocity);
            Assert.Equal(maxAngular, controller.MaxAngularVelocity);
        }

        /// <summary>
        ///     Tests that constructor with zero linear velocity should disable linear limit
        /// </summary>
        [Fact]
        public void ConstructorWithZeroLinearVelocity_ShouldDisableLinearLimit()
        {
            VelocityLimitController controller = new VelocityLimitController(0.0f, 10.0f);

            Assert.False(controller.LimitLinearVelocity);
        }

        /// <summary>
        ///     Tests that constructor with zero angular velocity should disable angular limit
        /// </summary>
        [Fact]
        public void ConstructorWithZeroAngularVelocity_ShouldDisableAngularLimit()
        {
            VelocityLimitController controller = new VelocityLimitController(50.0f, 0.0f);

            Assert.False(controller.LimitAngularVelocity);
        }

        /// <summary>
        ///     Tests that constructor with max float values should disable limits
        /// </summary>
        [Fact]
        public void ConstructorWithMaxFloatValues_ShouldDisableLimits()
        {
            VelocityLimitController controller = new VelocityLimitController(float.MaxValue, float.MaxValue);

            Assert.False(controller.LimitLinearVelocity);
            Assert.False(controller.LimitAngularVelocity);
        }

        /// <summary>
        ///     Tests that max linear velocity property should set and get correctly
        /// </summary>
        [Fact]
        public void MaxLinearVelocityProperty_ShouldSetAndGetCorrectly()
        {
            VelocityLimitController controller = new VelocityLimitController
                {
                    MaxLinearVelocity = 100.0f
                };

            Assert.Equal(100.0f, controller.MaxLinearVelocity, 5);
        }

        /// <summary>
        ///     Tests that max angular velocity property should set and get correctly
        /// </summary>
        [Fact]
        public void MaxAngularVelocityProperty_ShouldSetAndGetCorrectly()
        {
            VelocityLimitController controller = new VelocityLimitController
                {
                    MaxAngularVelocity = 20.0f
                };

            Assert.Equal(20.0f, controller.MaxAngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that update should execute without errors
        /// </summary>
        [Fact]
        public void Update_ShouldExecuteWithoutErrors()
        {
            VelocityLimitController controller = new VelocityLimitController();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;

            controller.Update(0.016f);

            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that velocity limit controller should inherit from controller
        /// </summary>
        [Fact]
        public void VelocityLimitController_ShouldInheritFromController()
        {
            VelocityLimitController controller = new VelocityLimitController();

            Assert.IsAssignableFrom<Controller>(controller);
        }

        /// <summary>
        /// Tests that velocity limit controller should handle negative velocities
        /// </summary>
        [Fact]
        public void VelocityLimitController_ShouldHandleNegativeVelocities()
        {
            VelocityLimitController controller = new VelocityLimitController(-50.0f, -10.0f);

            Assert.Equal(-50.0f, controller.MaxLinearVelocity, 5);
            Assert.Equal(-10.0f, controller.MaxAngularVelocity, 5);
        }

        /// <summary>
        /// Tests that add body adds to internal list
        /// </summary>
        [Fact]
        public void AddBody_ShouldAddBody()
        {
            VelocityLimitController controller = new VelocityLimitController();
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody();

            controller.AddBody(body);

            controller.Update(0.016f);
            Assert.True(true);
        }

        /// <summary>
        /// Tests that remove body removes from internal list
        /// </summary>
        [Fact]
        public void RemoveBody_ShouldRemoveBody()
        {
            VelocityLimitController controller = new VelocityLimitController();
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody();
            controller.AddBody(body);

            controller.RemoveBody(body);

            controller.Update(0.016f);
            Assert.True(true);
        }

        /// <summary>
        /// Tests that update clamps linear velocity when exceeding max
        /// </summary>
        [Fact]
        public void Update_ShouldClampLinearVelocity_WhenExceedingMax()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(5.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.LinearVelocityInternal = new Vector2F(100f, 0f);
            controller.Update(0.016f);

            float displacement = 0.016f * body.LinearVelocityInternal.Length();
            Assert.True(displacement <= 5.0f + 0.0001f);
        }

        /// <summary>
        /// Tests that update does not clamp linear velocity when within limits
        /// </summary>
        [Fact]
        public void Update_ShouldNotClampLinearVelocity_WhenWithinLimits()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.LinearVelocityInternal = new Vector2F(5.0f, 0f);
            controller.Update(0.016f);

            Assert.Equal(5.0f, body.LinearVelocityInternal.X, 5);
        }

        /// <summary>
        /// Tests that update with linear limit disabled does not clamp
        /// </summary>
        [Fact]
        public void Update_WithLinearLimitDisabled_ShouldNotClamp()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(0.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.LinearVelocityInternal = new Vector2F(500f, 0f);
            controller.Update(0.016f);

            Assert.Equal(500f, body.LinearVelocityInternal.X, 5);
        }

        /// <summary>
        ///     Tests that Update clamps angular velocity when exceeding max
        /// </summary>
        [Fact]
        public void Update_ShouldClampAngularVelocity_WhenExceedingMax()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 2.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.AngularVelocity = 100f;
            controller.Update(0.016f);

            float rotation = 0.016f * Math.Abs(body.AngularVelocity);
            Assert.True(rotation <= 2.0f + 0.0001f);
        }

        /// <summary>
        ///     Tests that Update does not clamp angular velocity when within limits
        /// </summary>
        [Fact]
        public void Update_ShouldNotClampAngularVelocity_WhenWithinLimits()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.AngularVelocity = 5.0f;
            controller.Update(0.016f);

            Assert.Equal(5.0f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that Update with angular limit disabled does not clamp
        /// </summary>
        [Fact]
        public void Update_WithAngularLimitDisabled_ShouldNotClamp()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 0.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.AngularVelocity = 500f;
            controller.Update(0.016f);

            Assert.Equal(500f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that Update skips body when IsActiveOn returns false
        /// </summary>
        [Fact]
        public void Update_WithFilteredBody_ShouldNotClamp()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(5.0f, 5.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);
            body.ControllerFilter.IgnoreController(controller.ControllerCategories);

            body.LinearVelocityInternal = new Vector2F(500f, 0f);
            controller.Update(0.016f);

            Assert.Equal(500f, body.LinearVelocityInternal.X, 5);
        }

        /// <summary>
        ///     Tests that angular clamping actually triggers with high enough velocity
        /// </summary>
        [Fact]
        public void Update_WithAngularVelocityHighEnough_ShouldClamp()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, Vector2F.Zero, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 2.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.AngularVelocity = 200f;
            controller.Update(0.1f);

            float rotation = 0.1f * Math.Abs(body.AngularVelocity);
            Assert.True(rotation <= 2.0f + 0.0001f);
        }

        /// <summary>
        ///     Tests that Update with zero dt does not throw
        /// </summary>
        [Fact]
        public void Update_WithZeroDt_ShouldNotThrow()
        {
            VelocityLimitController controller = new VelocityLimitController();
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            controller.WorldPhysic = world;

            controller.Update(0f);

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that Update with multiple bodies applies limits to all
        /// </summary>
        [Fact]
        public void Update_WithMultipleBodies_ShouldClampAll()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateCircle(1f, 1f, new Vector2F(0, 0), BodyType.Dynamic);
            Body body2 = world.CreateCircle(1f, 1f, new Vector2F(10, 0), BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(5.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body1);
            controller.AddBody(body2);

            body1.LinearVelocityInternal = new Vector2F(100f, 0f);
            body2.LinearVelocityInternal = new Vector2F(200f, 0f);
            controller.Update(0.016f);

            float displacement1 = 0.016f * body1.LinearVelocityInternal.Length();
            float displacement2 = 0.016f * body2.LinearVelocityInternal.Length();
            Assert.True(displacement1 <= 5.0f + 0.0001f);
            Assert.True(displacement2 <= 5.0f + 0.0001f);
        }

        /// <summary>
        ///     Tests that changing MaxLinearVelocity after construction is reflected
        /// </summary>
        [Fact]
        public void MaxLinearVelocityProperty_ChangeAfterConstruction_ShouldAffectClamping()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, Vector2F.Zero, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            controller.MaxLinearVelocity = 5.0f;
            body.LinearVelocityInternal = new Vector2F(100f, 0f);
            controller.Update(0.016f);

            float displacement = 0.016f * body.LinearVelocityInternal.Length();
            Assert.True(displacement <= 5.0f + 0.0001f);
        }

        /// <summary>
        ///     Tests that changing MaxAngularVelocity after construction is reflected
        /// </summary>
        [Fact]
        public void MaxAngularVelocityProperty_ChangeAfterConstruction_ShouldAffectClamping()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, Vector2F.Zero, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            controller.MaxAngularVelocity = 2.0f;
            body.AngularVelocity = 200f;
            controller.Update(0.1f);

            float rotation = 0.1f * Math.Abs(body.AngularVelocity);
            Assert.True(rotation <= 2.0f + 0.0001f);
        }

        /// <summary>
        ///     Tests that RemoveBody with body not in list does not throw
        /// </summary>
        [Fact]
        public void RemoveBody_WithNonExistentBody_ShouldNotThrow()
        {
            VelocityLimitController controller = new VelocityLimitController();
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            controller.WorldPhysic = world;
            Body body = world.CreateBody();

            controller.RemoveBody(body);

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that Update with both linear and angular clamping disabled does nothing
        /// </summary>
        [Fact]
        public void Update_WithBothLimitsDisabled_ShouldNotClamp()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(0.0f, 0.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.LinearVelocityInternal = new Vector2F(500f, 0f);
            body.AngularVelocity = 500f;
            controller.Update(0.016f);

            Assert.Equal(500f, body.LinearVelocityInternal.X, 5);
            Assert.Equal(500f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that Update with both linear and angular limits active clamps both
        /// </summary>
        [Fact]
        public void Update_WithBothLimitsActive_ShouldClampLinear()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, Vector2F.Zero, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(5.0f, 100.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.LinearVelocityInternal = new Vector2F(100f, 0f);
            controller.Update(0.1f);

            float displacement = 0.1f * body.LinearVelocityInternal.Length();
            Assert.True(displacement <= 5.0f + 0.0001f);
        }

        /// <summary>
        ///     Tests that Update with disabled body does not clamp
        /// </summary>
        [Fact]
        public void Update_WithDisabledBody_ShouldNotClamp()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, Vector2F.Zero, BodyType.Dynamic);
            body.Enabled = false;
            VelocityLimitController controller = new VelocityLimitController(5.0f, 5.0f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.LinearVelocityInternal = new Vector2F(500f, 0f);
            controller.Update(0.016f);

            Assert.Equal(500f, body.LinearVelocityInternal.X, 5);
        }

        /// <summary>
        ///     Tests that angular clamp works by checking dt is small and av is large
        /// </summary>
        [Fact]
        public void Update_WithAngularClamp_ShouldReduceVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, Vector2F.Zero, BodyType.Dynamic);
            VelocityLimitController controller = new VelocityLimitController(100.0f, 0.5f)
                {
                    WorldPhysic = world
                };
            controller.AddBody(body);

            body.AngularVelocity = 100f;
            controller.Update(1.0f);

            float rotation = 1.0f * Math.Abs(body.AngularVelocity);
            Assert.True(rotation <= 0.5f + 0.0001f);
        }
    }
}