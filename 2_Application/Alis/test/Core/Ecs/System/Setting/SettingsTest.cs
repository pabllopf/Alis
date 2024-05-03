// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingsTest.cs
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

using Alis.Core.Ecs.System.Setting;
using Alis.Core.Ecs.System.Setting.Audio;
using Alis.Core.Ecs.System.Setting.General;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Ecs.System.Setting.Input;
using Alis.Core.Ecs.System.Setting.Network;
using Alis.Core.Ecs.System.Setting.Physic;
using Alis.Core.Ecs.System.Setting.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Setting
{
    /// <summary>
    /// The settings test class
    /// </summary>
    public class SettingsTest
    {
        /// <summary>
        /// Tests that test settings general
        /// </summary>
        [Fact]
        public void Test_Settings_General()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            GeneralSetting general = settings.General;
            
            // Assert
            Assert.NotNull(general);
            Assert.IsType<GeneralSetting>(general);
        }
        
        /// <summary>
        /// Tests that test settings audio
        /// </summary>
        [Fact]
        public void Test_Settings_Audio()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            IAudioSetting audio = settings.Audio;
            
            // Assert
            Assert.NotNull(audio);
            Assert.IsType<AudioSetting>(audio);
        }
        
        /// <summary>
        /// Tests that test settings graphic
        /// </summary>
        [Fact]
        public void Test_Settings_Graphic()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            GraphicSetting graphic = settings.Graphic;
            
            // Assert
            Assert.NotNull(graphic);
            Assert.IsType<GraphicSetting>(graphic);
        }
        
        /// <summary>
        /// Tests that test settings input
        /// </summary>
        [Fact]
        public void Test_Settings_Input()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            InputSetting input = settings.Input;
            
            // Assert
            Assert.NotNull(input);
            Assert.IsType<InputSetting>(input);
        }
        
        /// <summary>
        /// Tests that test settings network
        /// </summary>
        [Fact]
        public void Test_Settings_Network()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            NetworkSetting network = settings.Network;
            
            // Assert
            Assert.NotNull(network);
            Assert.IsType<NetworkSetting>(network);
        }
        
        /// <summary>
        /// Tests that test settings physic
        /// </summary>
        [Fact]
        public void Test_Settings_Physic()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            PhysicSetting physic = settings.Physic;
            
            // Assert
            Assert.NotNull(physic);
            Assert.IsType<PhysicSetting>(physic);
        }
        
        
        /// <summary>
        /// Tests that test settings scene
        /// </summary>
        [Fact]
        public void Test_Settings_Scene()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            SceneSetting scene = settings.Scene;
            
            // Assert
            Assert.NotNull(scene);
            Assert.IsType<SceneSetting>(scene);
        }
        
        /// <summary>
        /// Tests that test settings general v 2
        /// </summary>
        [Fact]
        public void Test_Settings_General_v2()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            settings.General = new GeneralSetting();
            GeneralSetting result = settings.General;
            
            // Assert
            Assert.NotNull(settings);
            Assert.NotNull(result);
            Assert.IsType<GeneralSetting>(result);
        }
        
        /// <summary>
        /// Tests that test settings audio v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Audio_v2()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            settings.Audio = new AudioSetting();
            IAudioSetting result = settings.Audio;
            
            // Assert
            Assert.NotNull(settings);
            Assert.NotNull(result);
            Assert.IsType<AudioSetting>(result);
        }
        
        /// <summary>
        /// Tests that test settings graphic v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Graphic_v2()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            settings.Graphic = new GraphicSetting();
            GraphicSetting result = settings.Graphic;
            
            // Assert
            Assert.NotNull(settings);
            Assert.NotNull(result);
            Assert.IsType<GraphicSetting>(result);
        }
        
        /// <summary>
        /// Tests that test settings input v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Input_v2()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            settings.Input = new InputSetting();
            InputSetting result = settings.Input;
            
            // Assert
            Assert.NotNull(settings);
            Assert.NotNull(result);
            Assert.IsType<InputSetting>(result);
        }
        
        /// <summary>
        /// Tests that test settings network v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Network_v2()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            settings.Network = new NetworkSetting();
            NetworkSetting result = settings.Network;
            
            // Assert
            Assert.NotNull(settings);
            Assert.NotNull(result);
            Assert.IsType<NetworkSetting>(result);
        }
        
        /// <summary>
        /// Tests that test settings physic v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Physic_v2()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            settings.Physic = new PhysicSetting();
            PhysicSetting result = settings.Physic;
            
            // Assert
            Assert.NotNull(settings);
            Assert.NotNull(result);
            Assert.IsType<PhysicSetting>(result);
        }
        
        /// <summary>
        /// Tests that test settings scene v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Scene_v2()
        {
            // Arrange
            Settings settings = new Settings();
            
            // Act
            settings.Scene = new SceneSetting();
            SceneSetting result = settings.Scene;
            
            // Assert
            Assert.NotNull(settings);
            Assert.NotNull(result);
            Assert.IsType<SceneSetting>(result);
        }
    }
}