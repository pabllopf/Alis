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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The physic setting builder test class
    /// </summary>
    public class PhysicSettingBuilderTest
    {
        /// <summary>
        /// Tests that constructor no args creates builder
        /// </summary>
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns physic setting instance
        /// </summary>
        [Fact]
        public void Build_ReturnsPhysicSettingInstance()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSetting result = builder.Build();
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that gravity sets gravity returns builder
        /// </summary>
        [Fact]
        public void Gravity_SetsGravity_ReturnsBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSettingBuilder result = builder.Gravity(0f, -9.81f);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that debug sets debug returns builder
        /// </summary>
        [Fact]
        public void Debug_SetsDebug_ReturnsBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSettingBuilder result = builder.Debug(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that debug color sets color returns builder
        /// </summary>
        [Fact]
        public void DebugColor_SetsColor_ReturnsBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSettingBuilder result = builder.DebugColor(Color.Red);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all properties creates physic setting
        /// </summary>
        [Fact]
        public void ChainingAllProperties_CreatesPhysicSetting()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSetting result = builder
                .Gravity(0f, -9.81f)
                .Debug(true)
                .DebugColor(Color.Green)
                .Build();
            Assert.NotNull(result);
        }
    }
}
