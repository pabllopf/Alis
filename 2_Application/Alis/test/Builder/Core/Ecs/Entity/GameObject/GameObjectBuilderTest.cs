// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Entity.GameObject;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity.GameObject
{
    /// <summary>
    /// The game object builder test class
    /// </summary>
    public class GameObjectBuilderTest
    {
        /// <summary>
        /// Tests that game object builder default constructor valid input
        /// </summary>
        [Fact]
        public void GameObjectBuilder_DefaultConstructor_ValidInput()
        {
            GameObjectBuilder gameObjectBuilder = new GameObjectBuilder();
            
            Assert.NotNull(gameObjectBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            GameObjectBuilder gameObjectBuilder = new GameObjectBuilder();
            
            Alis.Core.Ecs.Entity.GameObject gameObject = gameObjectBuilder.Build();
            
            Assert.NotNull(gameObject);
        }
        
        /// <summary>
        /// Tests that name valid input
        /// </summary>
        [Fact]
        public void Name_ValidInput()
        {
            GameObjectBuilder gameObjectBuilder = new GameObjectBuilder();
            
            gameObjectBuilder.Name("Test Name");
            
            Assert.Equal("Test Name", gameObjectBuilder.Build().Name);
        }
        
        /// <summary>
        /// Tests that transform valid input
        /// </summary>
        [Fact]
        public void Transform_ValidInput()
        {
            GameObjectBuilder gameObjectBuilder = new GameObjectBuilder();
            
            gameObjectBuilder.Transform(builder => builder.Position(1.0f, 2.0f).Rotation(45.0f).Scale(3.0f, 4.0f).Build());
        }
        
        /// <summary>
        /// Tests that with tag valid input
        /// </summary>
        [Fact]
        public void WithTag_ValidInput()
        {
            GameObjectBuilder gameObjectBuilder = new GameObjectBuilder();
            
            gameObjectBuilder.WithTag("Test Tag");
            
            Assert.Equal("Test Tag", gameObjectBuilder.Build().Tag);
        }
        
        /// <summary>
        /// Tests that add component valid input
        /// </summary>
        [Fact]
        public void AddComponent_ValidInput()
        {
            GameObjectBuilder gameObjectBuilder = new GameObjectBuilder();
            
            gameObjectBuilder.AddComponent(new TestComponent());
            
            Assert.Single(gameObjectBuilder.Build().Components);
        }
    }
}