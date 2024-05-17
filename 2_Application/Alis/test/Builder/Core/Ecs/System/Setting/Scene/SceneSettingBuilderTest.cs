// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneSettingBuilderTest.cs
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

namespace Alis.Test.Builder.Core.Ecs.System.Setting.Scene
{
    /// <summary>
    /// The scene setting builder test class
    /// </summary>
    public class SceneSettingBuilderTest
    {
        /// <summary>
        /// Tests that scene setting builder default constructor valid input
        /// </summary>
        [Fact]
        public void SceneSettingBuilder_DefaultConstructor_ValidInput()
        {
            SceneSettingBuilder sceneSettingBuilder = new SceneSettingBuilder();
            
            Assert.NotNull(sceneSettingBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            SceneSettingBuilder sceneSettingBuilder = new SceneSettingBuilder();
            
            SceneSetting sceneSetting = sceneSettingBuilder.Build();
            
            Assert.NotNull(sceneSetting);
        }
    }
}