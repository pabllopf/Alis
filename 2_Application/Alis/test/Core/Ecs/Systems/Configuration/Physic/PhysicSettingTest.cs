// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicSettingTest.cs
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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration.Physic
{
    /// <summary>
    ///     Tests for the PhysicSetting struct
    /// </summary>
    public class PhysicSettingTest
    {
        /// <summary>
        ///     Tests that default constructor sets expected values
        /// </summary>
        [Fact]
        public void PhysicSetting_DefaultConstructor_ShouldSetDefaultValues()
        {
            PhysicSetting setting = new PhysicSetting();

            Assert.Equal(-9.81f, setting.Gravity.Y);
            Assert.Equal(0f, setting.Gravity.X);
            Assert.False(setting.Debug);
            Assert.Equal(0, setting.DebugColor.R);
            Assert.Equal(0, setting.DebugColor.G);
            Assert.Equal(0, setting.DebugColor.B);
            Assert.Equal(1, setting.DebugColor.A);
        }

        /// <summary>
        ///     Tests that parameterized constructor sets all values
        /// </summary>
        [Fact]
        public void PhysicSetting_ParameterizedConstructor_ShouldSetValues()
        {
            Vector2F gravity = new Vector2F(0, -5f);
            Color debugColor = new Color(255, 0, 0, 255);
            PhysicSetting setting = new PhysicSetting(gravity, true, debugColor);

            Assert.Equal(-5f, setting.Gravity.Y);
            Assert.True(setting.Debug);
            Assert.Equal(255, setting.DebugColor.R);
            Assert.Equal(255, setting.DebugColor.A);
        }

        /// <summary>
        ///     Tests that properties can be modified after construction
        /// </summary>
        [Fact]
        public void PhysicSetting_Properties_ShouldBeModifiable()
        {
            PhysicSetting setting = new PhysicSetting();

            setting.Gravity = new Vector2F(1, 1);
            Assert.Equal(1f, setting.Gravity.X);
            Assert.Equal(1f, setting.Gravity.Y);

            setting.Debug = true;
            Assert.True(setting.Debug);

            setting.DebugColor = new Color(128, 128, 128, 255);
            Assert.Equal(128, setting.DebugColor.R);
        }

        /// <summary>
        ///     Tests that PhysicSetting implements IPhysicSetting interface
        /// </summary>
        [Fact]
        public void PhysicSetting_ShouldImplementIPhysicSetting()
        {
            PhysicSetting setting = new PhysicSetting();
            Assert.IsAssignableFrom<IPhysicSetting>(setting);
        }
    }
}
