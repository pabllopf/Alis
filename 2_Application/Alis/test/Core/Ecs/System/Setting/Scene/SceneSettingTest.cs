// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneSettingTest.cs
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

using Alis.Builder.Core.Ecs.System.Setting.Scene;
using Alis.Core.Ecs.System.Setting.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Setting.Scene
{
    /// <summary>
    /// The scene setting test class
    /// </summary>
    public class SceneSettingTest
    {
        /// <summary>
        /// Tests that test scene setting max number of scenes
        /// </summary>
        [Fact]
        public void Test_SceneSetting_MaxNumberOfScenes()
        {
            // Arrange
            SceneSetting sceneSetting = new SceneSetting();
            
            // Act
            sceneSetting.MaxNumberOfScenes = 500;
            int result = sceneSetting.MaxNumberOfScenes;
            
            // Assert
            Assert.NotNull(sceneSetting);
            Assert.Equal(500, result);
        }
        
        /// <summary>
        /// Tests that test scene setting builder
        /// </summary>
        [Fact]
        public void Test_SceneSetting_Builder()
        {
            // Arrange
            SceneSetting sceneSetting = new SceneSetting();
            
            // Act
            SceneSettingBuilder result = sceneSetting.Builder();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<SceneSettingBuilder>(result);
        }
    }
}