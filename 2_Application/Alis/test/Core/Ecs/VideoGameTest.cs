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

using System;
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Ecs;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;
using Alis.Test.Core.Ecs.System.Manager.Samples;
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
        
        /// <summary>
        /// Tests that add should add manager to video game
        /// </summary>
        [Fact]
        public void Add_ShouldAddManagerToVideoGame()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            MockManager manager = new MockManager();
            
            videoGame.Add(manager);
            
            Assert.True(videoGame.Contains<MockManager>());
        }
        
        /// <summary>
        /// Tests that remove should remove manager from video game
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveManagerFromVideoGame()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            MockManager manager = new MockManager();
            
            videoGame.Add(manager);
            videoGame.Remove(manager);
            
            Assert.False(videoGame.Contains<MockManager>());
        }
        
        /// <summary>
        /// Tests that get should return manager from video game
        /// </summary>
        [Fact]
        public void Get_ShouldReturnManagerFromVideoGame()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            MockManager manager = new MockManager();
            
            videoGame.Add(manager);
            
            Assert.Equal(manager, videoGame.Get<MockManager>());
        }
        
        /// <summary>
        /// Tests that contains should return true if manager exists in video game
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnTrueIfManagerExistsInVideoGame()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            MockManager manager = new MockManager();
            
            videoGame.Add(manager);
            
            Assert.True(videoGame.Contains<MockManager>());
        }
        
        /// <summary>
        /// Tests that clear should remove all managers from video game
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllManagersFromVideoGame()
        {
            AudioManager manager1 = new AudioManager();
            GraphicManager manager2 = new GraphicManager();
            
            VideoGame videoGame = new VideoGame(
                new Settings(),
                manager1,
                manager2,
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            
            videoGame.Clear<GraphicManager>();
            
            Assert.False(videoGame.Contains<GraphicManager>());
        }
        
        /// <summary>
        /// Tests that set should replace manager in video game
        /// </summary>
        [Fact]
        public void Set_ShouldReplaceManagerInVideoGame()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            MockManager manager1 = new MockManager();
            MockManager manager2 = new MockManager();
            
            videoGame.Add(manager1);
            videoGame.Set(manager2);
            
            Assert.Equal(manager2, videoGame.Get<MockManager>());
        }
        
        /// <summary>
        /// Tests that find should return manager from video game
        /// </summary>
        [Fact]
        public void Find_ShouldReturnManagerFromVideoGame()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            MockManager manager = new MockManager();
            
            videoGame.Add(manager);
            
            Assert.Equal(manager, videoGame.Find<MockManager>());
        }
        
        /// <summary>
        /// Tests that is running set value should change is running
        /// </summary>
        [Fact]
        public void IsRunning_SetValue_ShouldChangeIsRunning()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            
            videoGame.IsRunning = false;
            
            Assert.False(videoGame.IsRunning);
        }
        
        /// <summary>
        /// Tests that builder should return video game builder
        /// </summary>
        [Fact]
        public void Builder_ShouldReturnVideoGameBuilder()
        {
            VideoGameBuilder result = VideoGame.Builder();
            
            Assert.IsType<VideoGameBuilder>(result);
        }
        
        /// <summary>
        /// Tests that set context should set context
        /// </summary>
        [Fact]
        public void SetContext_ShouldSetContext()
        {
            VideoGame videoGame = new VideoGame(
                new Settings(),
                new AudioManager(),
                new GraphicManager(),
                new InputManager(),
                new NetworkManager(),
                new PhysicManager(),
                new SceneManager());
            Context newContext = new Context(videoGame, new Settings());
            
            videoGame.SetContext(newContext);
            
            Assert.Equal(newContext, videoGame.Context);
        }
        
        /// <summary>
        /// Tests that constructor should initialize managers
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeManagers()
        {
            Settings settings = new Settings();
            AudioManager audioManager = new AudioManager();
            GraphicManager graphicManager = new GraphicManager();
            InputManager inputManager = new InputManager();
            NetworkManager networkManager = new NetworkManager();
            PhysicManager physicManager = new PhysicManager();
            SceneManager sceneManager = new SceneManager();
            VideoGame videoGame = new VideoGame(settings, audioManager, graphicManager, inputManager, networkManager, physicManager, sceneManager);
            
            Assert.True(videoGame.Contains<AudioManager>());
            Assert.True(videoGame.Contains<GraphicManager>());
            Assert.True(videoGame.Contains<InputManager>());
            Assert.True(videoGame.Contains<NetworkManager>());
            Assert.True(videoGame.Contains<PhysicManager>());
            Assert.True(videoGame.Contains<SceneManager>());
        }
        
        /// <summary>
        /// Tests that add should add manager to video game v 2
        /// </summary>
        [Fact]
        public void Add_ShouldAddManagerToVideoGame_v2()
        {
            Settings settings = new Settings();
            AudioManager audioManager = new AudioManager();
            GraphicManager graphicManager = new GraphicManager();
            InputManager inputManager = new InputManager();
            NetworkManager networkManager = new NetworkManager();
            PhysicManager physicManager = new PhysicManager();
            SceneManager sceneManager = new SceneManager();
            AManager[] managers = new AManager[] {audioManager, graphicManager, inputManager, networkManager, physicManager, sceneManager};
            
            VideoGame videoGame = new VideoGame(settings, audioManager, graphicManager, inputManager, networkManager, physicManager, sceneManager);
            MockManager newManager = new MockManager();
            
            videoGame.Add(newManager);
            
            Assert.True(videoGame.Contains<NetworkManager>());
        }
    }
}