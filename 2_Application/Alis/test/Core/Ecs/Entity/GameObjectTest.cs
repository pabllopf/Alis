// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTest.cs
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

using Alis.Core.Ecs;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;
using Xunit;

namespace Alis.Test.Core.Ecs.Entity
{
    /// <summary>
    /// The game object test class
    /// </summary>
    public class GameObjectTest
    {
        /// <summary>
        /// Tests that test game object on enable
        /// </summary>
        [Fact]
        public void Test_GameObject_OnEnable()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            
            // Act
            gameObject.OnEnable();
            
            // Assert
            Assert.True(gameObject.IsEnable);
        }
        
        /// <summary>
        /// Tests that test game object on disable
        /// </summary>
        [Fact]
        public void Test_GameObject_OnDisable()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            gameObject.OnEnable();
            
            // Act
            gameObject.OnDisable();
            
            // Assert
            Assert.False(gameObject.IsEnable);
        }
        
        /// <summary>
        /// Tests that test game object add remove component
        /// </summary>
        [Fact]
        public void Test_GameObject_Add_Remove_Component()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            Sprite component = new Sprite();
            
            // Act
            gameObject.Add(component);
            bool containsAfterAdd = gameObject.Contains<AComponent>();
            gameObject.Remove(component);
            bool containsAfterRemove = gameObject.Contains<AComponent>();
            
            // Assert
            Assert.True(containsAfterAdd);
            Assert.False(containsAfterRemove);
        }
        
        /// <summary>
        /// Tests that test game object set context
        /// </summary>
        [Fact]
        public void Test_GameObject_SetContext()
        {
            // Arrange
            GameObject gameObject = new GameObject();
            Context context = new Context(new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager()
                ), new Settings());
            
            // Act
            gameObject.SetContext(context);
            
            // Assert
            Assert.NotNull(gameObject.Context);
            Assert.IsType<Context>(gameObject.Context);
        }
        
    }
}