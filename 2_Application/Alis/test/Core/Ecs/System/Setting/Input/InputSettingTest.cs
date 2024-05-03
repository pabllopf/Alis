// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputSettingTest.cs
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

using Alis.Builder.Core.Ecs.System.Setting.Input;
using Alis.Core.Ecs.System.Setting.Input;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Setting.Input
{
    /// <summary>
    /// The input setting test class
    /// </summary>
    public class InputSettingTest
    {
        /// <summary>
        /// Tests that test input setting update mode
        /// </summary>
        [Fact]
        public void Test_InputSetting_UpdateMode()
        {
            // Arrange
            InputSetting inputSetting = new InputSetting();
            
            // Act
            inputSetting.UpdateMode = UpdateMode.DynamicUpdate;
            UpdateMode result = inputSetting.UpdateMode;
            
            // Assert
            Assert.NotNull(inputSetting);
            Assert.Equal(UpdateMode.DynamicUpdate, result);
        }
        
        /// <summary>
        /// Tests that test input setting builder
        /// </summary>
        [Fact]
        public void Test_InputSetting_Builder()
        {
            // Arrange
            InputSetting inputSetting = new InputSetting();
            
            // Act
            InputSettingBuilder result = inputSetting.Builder();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<InputSettingBuilder>(result);
        }
    }
}