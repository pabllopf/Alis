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

using Alis.Builder.Core.Ecs.System.Setting.Physic;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.System.Setting.Physic;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.Setting.Physic
{
    /// <summary>
    /// The physic setting builder test class
    /// </summary>
    public class PhysicSettingBuilderTest
    {
        /// <summary>
        /// Tests that physic setting builder default constructor valid input
        /// </summary>
        [Fact]
        public void PhysicSettingBuilder_DefaultConstructor_ValidInput()
        {
            PhysicSettingBuilder physicSettingBuilder = new PhysicSettingBuilder();
            
            Assert.NotNull(physicSettingBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            PhysicSettingBuilder physicSettingBuilder = new PhysicSettingBuilder();
            
            PhysicSetting physicSetting = physicSettingBuilder.Build();
            
            Assert.NotNull(physicSetting);
        }
        
        /// <summary>
        /// Tests that debug valid input
        /// </summary>
        [Fact]
        public void Debug_ValidInput()
        {
            PhysicSettingBuilder physicSettingBuilder = new PhysicSettingBuilder();
            
            physicSettingBuilder.Debug(true);
            
            Assert.True(physicSettingBuilder.Build().DebugMode);
        }
        
        /// <summary>
        /// Tests that debug color valid input
        /// </summary>
        [Fact]
        public void DebugColor_ValidInput()
        {
            PhysicSettingBuilder physicSettingBuilder = new PhysicSettingBuilder();
            
            physicSettingBuilder.DebugColor(new Color(255, 255, 255, 255));
            
            Assert.Equal(new Color(255, 255, 255, 255), physicSettingBuilder.Build().DebugColor);
        }
        
        /// <summary>
        /// Tests that gravity valid input
        /// </summary>
        [Fact]
        public void Gravity_ValidInput()
        {
            PhysicSettingBuilder physicSettingBuilder = new PhysicSettingBuilder();
            
            physicSettingBuilder.Gravity(9.8f, -9.8f);
            
            Assert.Equal(new Vector2(9.8f, -9.8f), physicSettingBuilder.Build().Gravity);
        }
    }
}