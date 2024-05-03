// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneTest.cs
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
    /// The scene test class
    /// </summary>
    public class SceneTest
    {
        /// <summary>
        /// Tests that test scene on enable
        /// </summary>
        [Fact]
        public void Test_Scene_OnEnable()
        {
            // Arrange
            Scene scene = new Scene();
            
            // Act
            scene.OnEnable();
            
            // Assert
            Assert.True(scene.IsEnable);
        }
        
        /// <summary>
        /// Tests that test scene on disable
        /// </summary>
        [Fact]
        public void Test_Scene_OnDisable()
        {
            // Arrange
            Scene scene = new Scene();
            scene.OnEnable();
            
            // Act
            scene.OnDisable();
            
            // Assert
            Assert.False(scene.IsEnable);
        }
        
        /// <summary>
        /// Tests that test context constructor
        /// </summary>
        [Fact]
        public void Test_Context_Constructor()
        {
            // Arrange
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            Settings settings = new Settings();
            
            // Act
            Context context = new Context(videoGame, settings);
            
            // Assert
            Assert.NotNull(context);
            Assert.Equal(settings, context.Settings);
        }
        
        /// <summary>
        /// Tests that test context audio manager
        /// </summary>
        [Fact]
        public void Test_Context_AudioManager()
        {
            // Arrange
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            Settings settings = new Settings();
            Context context = new Context(videoGame, settings);
            
            // Act
            AudioManager audioManager = context.AudioManager;
            
            // Assert
            Assert.NotNull(audioManager);
            Assert.IsType<AudioManager>(audioManager);
        }
        
        /// <summary>
        /// Tests that test scene on enable v 2
        /// </summary>
        [Fact]
        public void Test_Scene_OnEnable_v2()
        {
            // Arrange
            Scene scene = new Scene();
            
            // Act
            scene.OnEnable();
            
            // Assert
            Assert.True(scene.IsEnable);
        }
        
        /// <summary>
        /// Tests that test scene on disable v 2
        /// </summary>
        [Fact]
        public void Test_Scene_OnDisable_v2()
        {
            // Arrange
            Scene scene = new Scene();
            scene.OnEnable();
            
            // Act
            scene.OnDisable();
            
            // Assert
            Assert.False(scene.IsEnable);
        }
        
        /// <summary>
        /// Tests that test scene add remove
        /// </summary>
        [Fact]
        public void Test_Scene_Add_Remove()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject gameObject = new GameObject();
            
            // Act
            scene.Add(gameObject);
            bool containsAfterAdd = scene.Contains<GameObject>();
            scene.Remove(gameObject);
            bool containsAfterRemove = scene.Contains<GameObject>();
            
            // Assert
            Assert.True(containsAfterAdd);
            Assert.False(containsAfterRemove);
        }
    }
}