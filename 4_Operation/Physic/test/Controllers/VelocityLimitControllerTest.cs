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
            VelocityLimitController controller = new VelocityLimitController();
            
            controller.MaxLinearVelocity = 100.0f;
            
            Assert.Equal(100.0f, controller.MaxLinearVelocity);
        }

        /// <summary>
        ///     Tests that max angular velocity property should set and get correctly
        /// </summary>
        [Fact]
        public void MaxAngularVelocityProperty_ShouldSetAndGetCorrectly()
        {
            VelocityLimitController controller = new VelocityLimitController();
            
            controller.MaxAngularVelocity = 20.0f;
            
            Assert.Equal(20.0f, controller.MaxAngularVelocity);
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
        ///     Tests that velocity limit controller should handle negative velocities
        /// </summary>
        [Fact]
        public void VelocityLimitController_ShouldHandleNegativeVelocities()
        {
            VelocityLimitController controller = new VelocityLimitController(-50.0f, -10.0f);
            
            Assert.Equal(-50.0f, controller.MaxLinearVelocity);
            Assert.Equal(-10.0f, controller.MaxAngularVelocity);
        }
    }
}

