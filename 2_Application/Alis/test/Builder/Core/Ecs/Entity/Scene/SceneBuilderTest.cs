// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Entity.Scene;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity.Scene
{
    /// <summary>
    /// The scene builder test class
    /// </summary>
    public class SceneBuilderTest
    {
        /// <summary>
        /// Tests that scene builder default constructor valid input
        /// </summary>
        [Fact]
        public void SceneBuilder_DefaultConstructor_ValidInput()
        {
            SceneBuilder sceneBuilder = new SceneBuilder();
            
            Assert.NotNull(sceneBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            SceneBuilder sceneBuilder = new SceneBuilder();
            
            Alis.Core.Ecs.Entity.Scene scene = sceneBuilder.Build();
            
            Assert.NotNull(scene);
        }
        
        /// <summary>
        /// Tests that name valid input
        /// </summary>
        [Fact]
        public void Name_ValidInput()
        {
            SceneBuilder sceneBuilder = new SceneBuilder();
            
            sceneBuilder.Name("Test Name");
            
            Assert.Equal("Test Name", sceneBuilder.Build().Name);
        }
        
        /// <summary>
        /// Tests that add valid input
        /// </summary>
        [Fact]
        public void Add_ValidInput()
        {
            SceneBuilder sceneBuilder = new SceneBuilder();
            
            sceneBuilder.Add<Alis.Core.Ecs.Entity.GameObject>(builder => builder.Name("Test GameObject").Build());
            
            Assert.Single(sceneBuilder.Build().GameObjects);
        }
    }
}