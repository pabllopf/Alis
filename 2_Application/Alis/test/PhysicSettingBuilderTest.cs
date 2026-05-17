// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicSettingBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Physic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ConfigurationBuilders.Physic
{
    /// <summary>
    ///     Contains unit tests for the <see cref="PhysicSettingBuilder" /> class.
    /// </summary>
    public class PhysicSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            // Arrange & Act
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            // Assert
            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a PhysicSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsPhysicSettingInstance()
        {
            // Arrange & Act
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSetting setting = builder.Build();

            // Assert
            Assert.NotNull(setting);
            Assert.IsType<PhysicSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null PhysicSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullPhysicSetting()
        {
            // Arrange & Act
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSetting setting = builder.Build();

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that PhysicSetting can be configured via the builder.
        /// </summary>
        [Fact]
        public void PhysicSettingCanBeConfiguredViaBuilder()
        {
            // Arrange
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            // Act
            PhysicSetting setting = builder.Gravity(0f, -9.81f).Debug(true);

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder creates a valid PhysicSetting object.
        /// </summary>
        [Fact]
        public void BuilderCreatesValidPhysicSettingObject()
        {
            // Arrange
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            // Act
            PhysicSetting setting = builder.Build();

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            // Arrange & Act
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            // Assert
            Assert.IsAssignableFrom<IBuild<PhysicSetting>>(builder);
            Assert.IsAssignableFrom<IGravity<PhysicSettingBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that gravity can be set via the builder.
        /// </summary>
        [Fact]
        public void GravityCanBeSetViaBuilder()
        {
            // Arrange
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            // Act
            PhysicSetting setting = builder.Gravity(0f, -15f);

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that debug mode can be set via the builder.
        /// </summary>
        [Fact]
        public void DebugCanBeSetViaBuilder()
        {
            // Arrange
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            // Act
            PhysicSetting setting = builder.Debug(true);

            // Assert
            Assert.NotNull(setting);
        }
    }
}
