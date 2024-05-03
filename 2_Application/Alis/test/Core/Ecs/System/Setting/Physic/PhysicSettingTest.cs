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

using Alis.Builder.Core.Ecs.System.Setting.Physic;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.System.Setting.Physic;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Setting.Physic
{
    /// <summary>
    /// The physic setting test class
    /// </summary>
    public class PhysicSettingTest
    {
        /// <summary>
        /// Tests that test physic setting debug mode
        /// </summary>
        [Fact]
        public void Test_PhysicSetting_DebugMode()
        {
            // Arrange
            PhysicSetting physicSetting = new PhysicSetting();
            
            // Act
            physicSetting.DebugMode = true;
            bool result = physicSetting.DebugMode;
            
            // Assert
            Assert.NotNull(physicSetting);
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that test physic setting debug color
        /// </summary>
        [Fact]
        public void Test_PhysicSetting_DebugColor()
        {
            // Arrange
            PhysicSetting physicSetting = new PhysicSetting();
            
            // Act
            physicSetting.DebugColor = Color.Red;
            Color result = physicSetting.DebugColor;
            
            // Assert
            Assert.NotNull(physicSetting);
            Assert.Equal(Color.Red, result);
        }
        
        /// <summary>
        /// Tests that test physic setting gravity
        /// </summary>
        [Fact]
        public void Test_PhysicSetting_Gravity()
        {
            // Arrange
            PhysicSetting physicSetting = new PhysicSetting();
            
            // Act
            physicSetting.Gravity = new Vector2(0.0f, -9.8f);
            Vector2 result = physicSetting.Gravity;
            
            // Assert
            Assert.NotNull(physicSetting);
            Assert.Equal(new Vector2(0.0f, -9.8f), result);
        }
        
        /// <summary>
        /// Tests that test physic setting builder
        /// </summary>
        [Fact]
        public void Test_PhysicSetting_Builder()
        {
            // Arrange
            PhysicSetting physicSetting = new PhysicSetting();
            
            // Act
            PhysicSettingBuilder result = physicSetting.Builder();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<PhysicSettingBuilder>(result);
        }
    }
}