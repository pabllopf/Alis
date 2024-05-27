// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextTest.cs
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

using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;
using Xunit;

namespace Alis.Test.Core.Ecs.System
{
    /// <summary>
    /// The context test class
    /// </summary>
    public class ContextTest
    {
        /// <summary>
        /// Tests that test context constructor
        /// </summary>
        [Fact]
        public void Test_Context_Constructor()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            Context context = new Context(settings);
            
            // Assert
            Assert.NotNull(context);
        }
        
        /// <summary>
        /// Tests that test context audio manager
        /// </summary>
        [Fact]
        public void Test_Context_AudioManager()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            AudioManager audioManager = context.AudioManager;
            
            // Assert
            Assert.NotNull(audioManager);
        }
        
        /// <summary>
        /// Tests that test context exit
        /// </summary>
        [Fact]
        public void Test_Context_Exit()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            context.Exit();
        }
        
        
        /// <summary>
        /// Tests that test context graphic manager
        /// </summary>
        [Fact]
        public void Test_Context_GraphicManager()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            GraphicManager result = context.GraphicManager;
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<GraphicManager>(result);
        }
        
        /// <summary>
        /// Tests that test context input manager
        /// </summary>
        [Fact]
        public void Test_Context_InputManager()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            InputManager result = context.InputManager;
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<InputManager>(result);
        }
        
        /// <summary>
        /// Tests that test context network manager
        /// </summary>
        [Fact]
        public void Test_Context_NetworkManager()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            NetworkManager result = context.NetworkManager;
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkManager>(result);
        }
        
        /// <summary>
        /// Tests that test context physic manager
        /// </summary>
        [Fact]
        public void Test_Context_PhysicManager()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            PhysicManager result = context.PhysicManager;
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<PhysicManager>(result);
        }
        
        /// <summary>
        /// Tests that test context time manager
        /// </summary>
        [Fact]
        public void Test_Context_TimeManager()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            TimeManager result = context.TimeManager;
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<TimeManager>(result);
        }
        
        /// <summary>
        /// Tests that test context scene manager
        /// </summary>
        [Fact]
        public void Test_Context_SceneManager()
        {
            // Arrange
            Settings settings = new Settings();
            Context context = new Context(settings);
            
            // Act
            SceneManager result = context.SceneManager;
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<SceneManager>(result);
        }
    }
}