// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Configuration.Audio;
using Alis.Core.Ecs.System.Configuration.General;
using Alis.Core.Ecs.System.Configuration.Graphic;
using Alis.Core.Ecs.System.Configuration.Input;
using Alis.Core.Ecs.System.Configuration.Network;
using Alis.Core.Ecs.System.Configuration.Physic;
using Alis.Core.Ecs.System.Configuration.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Configuration
{
    /// <summary>
    ///     The settings test class
    /// </summary>
    	  
	 public class SettingTest 
    {
        /// <summary>
        ///     Tests that test settings general
        /// </summary>
        [Fact]
        public void Test_Settings_General()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            GeneralSetting general = setting.General;

            // Assert
            Assert.NotNull(general);
            Assert.IsType<GeneralSetting>(general);
        }

        /// <summary>
        ///     Tests that test settings audio
        /// </summary>
        [Fact]
        public void Test_Settings_Audio()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            IAudioSetting audio = setting.Audio;

            // Assert
            Assert.NotNull(audio);
            Assert.IsType<AudioSetting>(audio);
        }

        /// <summary>
        ///     Tests that test settings graphic
        /// </summary>
        [Fact]
        public void Test_Settings_Graphic()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            GraphicSetting graphic = setting.Graphic;

            // Assert
            Assert.NotNull(graphic);
            Assert.IsType<GraphicSetting>(graphic);
        }

        /// <summary>
        ///     Tests that test settings input
        /// </summary>
        [Fact]
        public void Test_Settings_Input()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            InputSetting input = setting.Input;

            // Assert
            Assert.NotNull(input);
            Assert.IsType<InputSetting>(input);
        }

        /// <summary>
        ///     Tests that test settings network
        /// </summary>
        [Fact]
        public void Test_Settings_Network()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            NetworkSetting network = setting.Network;

            // Assert
            Assert.NotNull(network);
            Assert.IsType<NetworkSetting>(network);
        }

        /// <summary>
        ///     Tests that test settings physic
        /// </summary>
        [Fact]
        public void Test_Settings_Physic()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            PhysicSetting physic = setting.Physic;

            // Assert
            Assert.NotNull(physic);
            Assert.IsType<PhysicSetting>(physic);
        }


        /// <summary>
        ///     Tests that test settings scene
        /// </summary>
        [Fact]
        public void Test_Settings_Scene()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            SceneSetting scene = setting.Scene;

            // Assert
            Assert.NotNull(scene);
            Assert.IsType<SceneSetting>(scene);
        }

        /// <summary>
        ///     Tests that test settings general v 2
        /// </summary>
        [Fact]
        public void Test_Settings_General_v2()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            setting.General = new GeneralSetting();
            GeneralSetting result = setting.General;

            // Assert
            Assert.NotNull(setting);
            Assert.NotNull(result);
            Assert.IsType<GeneralSetting>(result);
        }

        /// <summary>
        ///     Tests that test settings audio v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Audio_v2()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            setting.Audio = new AudioSetting();
            IAudioSetting result = setting.Audio;

            // Assert
            Assert.NotNull(setting);
            Assert.NotNull(result);
            Assert.IsType<AudioSetting>(result);
        }

        /// <summary>
        ///     Tests that test settings graphic v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Graphic_v2()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            setting.Graphic = new GraphicSetting();
            GraphicSetting result = setting.Graphic;

            // Assert
            Assert.NotNull(setting);
            Assert.NotNull(result);
            Assert.IsType<GraphicSetting>(result);
        }

        /// <summary>
        ///     Tests that test settings input v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Input_v2()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            setting.Input = new InputSetting();
            InputSetting result = setting.Input;

            // Assert
            Assert.NotNull(setting);
            Assert.NotNull(result);
            Assert.IsType<InputSetting>(result);
        }

        /// <summary>
        ///     Tests that test settings network v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Network_v2()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            setting.Network = new NetworkSetting();
            NetworkSetting result = setting.Network;

            // Assert
            Assert.NotNull(setting);
            Assert.NotNull(result);
            Assert.IsType<NetworkSetting>(result);
        }

        /// <summary>
        ///     Tests that test settings physic v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Physic_v2()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            setting.Physic = new PhysicSetting();
            PhysicSetting result = setting.Physic;

            // Assert
            Assert.NotNull(setting);
            Assert.NotNull(result);
            Assert.IsType<PhysicSetting>(result);
        }

        /// <summary>
        ///     Tests that test settings scene v 2
        /// </summary>
        [Fact]
        public void Test_Settings_Scene_v2()
        {
            // Arrange
            Setting setting = new Setting();

            // Act
            setting.Scene = new SceneSetting();
            SceneSetting result = setting.Scene;

            // Assert
            Assert.NotNull(setting);
            Assert.NotNull(result);
            Assert.IsType<SceneSetting>(result);
        }
    }
}