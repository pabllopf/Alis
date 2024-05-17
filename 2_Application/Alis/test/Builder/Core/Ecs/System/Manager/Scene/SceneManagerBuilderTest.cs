// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneManagerBuilderTest.cs
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

using System;
using Alis.Builder.Core.Ecs.Entity.Scene;
using Alis.Builder.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Manager.Scene;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Manager.Scene
{
    /// <summary>
    /// The scene manager builder test class
    /// </summary>
    public class SceneManagerBuilderTest
    {
        /// <summary>
        /// Tests that scene manager builder default constructor valid input
        /// </summary>
        [Fact]
        public void SceneManagerBuilder_DefaultConstructor_ValidInput()
        {
            SceneManagerBuilder sceneManagerBuilder = new SceneManagerBuilder();
            
            Assert.NotNull(sceneManagerBuilder);
        }
        
        /// <summary>
        /// Tests that add valid input
        /// </summary>
        [Fact]
        public void Add_ValidInput()
        {
            SceneManagerBuilder sceneManagerBuilder = new SceneManagerBuilder();
            Func<SceneBuilder, Alis.Core.Ecs.Entity.Scene> sceneFunc = sb => sb.Build();
            
            sceneManagerBuilder.Add<SceneManagerBuilder>(sceneFunc);
            
            SceneManager sceneManager = sceneManagerBuilder.Build();
            Assert.Single(sceneManager.Scenes);
            Assert.Equal(sceneManager.Scenes[0], sceneManager.CurrentScene);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            SceneManagerBuilder sceneManagerBuilder = new SceneManagerBuilder();
            
            SceneManager sceneManager = sceneManagerBuilder.Build();
            
            Assert.NotNull(sceneManager);
        }
    }
}