// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSettingTest.cs
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

using Alis.Builder.Core.Ecs.System.Setting.General;
using Alis.Core.Ecs.System.Setting.General;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Setting.General
{
    /// <summary>
    /// The general setting test class
    /// </summary>
    public class GeneralSettingTest
    {
        /// <summary>
        /// Tests that test general setting debug
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_Debug()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            generalSetting.Debug = true;
            bool result = generalSetting.Debug;
            
            // Assert
            Assert.NotNull(generalSetting);
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that test general setting name
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_Name()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            generalSetting.Name = "Test Name";
            string result = generalSetting.Name;
            
            // Assert
            Assert.NotNull(generalSetting);
            Assert.Equal("Test Name", result);
        }
        
        /// <summary>
        /// Tests that test general setting description
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_Description()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            generalSetting.Description = "Test Description";
            string result = generalSetting.Description;
            
            // Assert
            Assert.NotNull(generalSetting);
            Assert.Equal("Test Description", result);
        }
        
        /// <summary>
        /// Tests that test general setting version
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_Version()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            generalSetting.Version = "1.0.0";
            string result = generalSetting.Version;
            
            // Assert
            Assert.NotNull(generalSetting);
            Assert.Equal("1.0.0", result);
        }
        
        /// <summary>
        /// Tests that test general setting author
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_Author()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            generalSetting.Author = "Test Author";
            string result = generalSetting.Author;
            
            // Assert
            Assert.NotNull(generalSetting);
            Assert.Equal("Test Author", result);
        }
        
        /// <summary>
        /// Tests that test general setting license
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_License()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            generalSetting.License = "Test License";
            string result = generalSetting.License;
            
            // Assert
            Assert.NotNull(generalSetting);
            Assert.Equal("Test License", result);
        }
        
        /// <summary>
        /// Tests that test general setting icon
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_Icon()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            generalSetting.Icon = "Test Icon";
            string result = generalSetting.Icon;
            
            // Assert
            Assert.NotNull(generalSetting);
            Assert.Equal("Test Icon", result);
        }
        
        /// <summary>
        /// Tests that test general setting builder
        /// </summary>
        [Fact]
        public void Test_GeneralSetting_Builder()
        {
            // Arrange
            GeneralSetting generalSetting = new GeneralSetting();
            
            // Act
            GeneralSettingBuilder result = generalSetting.Builder();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<GeneralSettingBuilder>(result);
        }
    }
}