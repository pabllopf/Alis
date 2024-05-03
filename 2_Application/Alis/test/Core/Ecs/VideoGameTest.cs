// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGameTest.cs
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
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;
using Alis.Test.Sample;
using Xunit;

namespace Alis.Test.Core.Ecs
{
    /// <summary>
    ///     The video game test class
    /// </summary>
    public class VideoGameTest
    {
        /// <summary>
        /// Tests that test add manager
        /// </summary>
        [Fact]
        public void Test_Add_Manager()
        {
            // Arrange
            Settings settings = new Settings();
            AudioManager audioManager = new AudioManager();
            GraphicManager graphicManager = new GraphicManager();
            InputManager inputManager = new InputManager();
            NetworkManager networkManager = new NetworkManager();
            PhysicManager physicManager = new PhysicManager();
            SceneManager sceneManager = new SceneManager();
            VideoGame videoGame = new VideoGame(settings, audioManager, graphicManager, inputManager, networkManager, physicManager, sceneManager);
            
            CustomManager newManager = new CustomManager(); // Assuming CustomManager is a type of Manager
            
            // Act
            videoGame.Add(newManager);
            
            // Assert
            Assert.True(videoGame.Contains<CustomManager>());
        }
        
        /// <summary>
        /// Tests that test remove manager
        /// </summary>
        [Fact]
        public void Test_Remove_Manager()
        {
            // Arrange
            Settings settings = new Settings();
            AudioManager audioManager = new AudioManager();
            GraphicManager graphicManager = new GraphicManager();
            InputManager inputManager = new InputManager();
            NetworkManager networkManager = new NetworkManager();
            PhysicManager physicManager = new PhysicManager();
            SceneManager sceneManager = new SceneManager();
            VideoGame videoGame = new VideoGame(settings, audioManager, graphicManager, inputManager, networkManager, physicManager, sceneManager);
            
            // Act
            videoGame.Remove(audioManager);
            
            // Assert
            Assert.False(videoGame.Contains<AudioManager>());
        }
        
        /// <summary>
        /// Tests that test get manager
        /// </summary>
        [Fact]
        public void Test_Get_Manager()
        {
            // Arrange
            Settings settings = new Settings();
            AudioManager audioManager = new AudioManager();
            GraphicManager graphicManager = new GraphicManager();
            InputManager inputManager = new InputManager();
            NetworkManager networkManager = new NetworkManager();
            PhysicManager physicManager = new PhysicManager();
            SceneManager sceneManager = new SceneManager();
            VideoGame videoGame = new VideoGame(settings, audioManager, graphicManager, inputManager, networkManager, physicManager, sceneManager);
            
            // Act
            AudioManager retrievedManager = videoGame.Get<AudioManager>();
            
            // Assert
            Assert.Equal(audioManager, retrievedManager);
        }
        
        /// <summary>
        /// Tests that test is running property
        /// </summary>
        [Fact]
        public void Test_IsRunning_Property()
        {
            // Arrange
            Settings settings = new Settings();
            AudioManager audioManager = new AudioManager();
            GraphicManager graphicManager = new GraphicManager();
            InputManager inputManager = new InputManager();
            NetworkManager networkManager = new NetworkManager();
            PhysicManager physicManager = new PhysicManager();
            SceneManager sceneManager = new SceneManager();
            VideoGame videoGame = new VideoGame(settings, audioManager, graphicManager, inputManager, networkManager, physicManager, sceneManager);
            
            // Act
            videoGame.IsRunning = false;
            
            // Assert
            Assert.False(videoGame.IsRunning);
        }
    }
}