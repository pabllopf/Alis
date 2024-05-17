// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingsBuilderTest.cs
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
using Alis.Builder.Core.Ecs.System.Setting;
using Alis.Builder.Core.Ecs.System.Setting.Audio;
using Alis.Builder.Core.Ecs.System.Setting.General;
using Alis.Builder.Core.Ecs.System.Setting.Graphic;
using Alis.Builder.Core.Ecs.System.Setting.Input;
using Alis.Builder.Core.Ecs.System.Setting.Network;
using Alis.Builder.Core.Ecs.System.Setting.Physic;
using Alis.Builder.Core.Ecs.System.Setting.Scene;
using Alis.Core.Ecs.System.Setting;
using Alis.Core.Ecs.System.Setting.Audio;
using Alis.Core.Ecs.System.Setting.General;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Ecs.System.Setting.Input;
using Alis.Core.Ecs.System.Setting.Network;
using Alis.Core.Ecs.System.Setting.Physic;
using Alis.Core.Ecs.System.Setting.Scene;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.Setting
{
    /// <summary>
    /// The settings builder test class
    /// </summary>
    public class SettingsBuilderTest
    {
        /// <summary>
        /// Tests that settings builder default constructor valid input
        /// </summary>
        [Fact]
        public void SettingsBuilder_DefaultConstructor_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            
            Assert.NotNull(settingsBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            
            Settings settings = settingsBuilder.Build();
            
            Assert.NotNull(settings);
        }
        
        /// <summary>
        /// Tests that audio valid input
        /// </summary>
        [Fact]
        public void Audio_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            Func<AudioSettingBuilder, AudioSetting> audioSettingFunc = asb => asb.Build();
            
            settingsBuilder.Audio(audioSettingFunc);
            
            Assert.NotNull(settingsBuilder.Build().Audio);
        }
        
        /// <summary>
        /// Tests that general valid input
        /// </summary>
        [Fact]
        public void General_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            Func<GeneralSettingBuilder, GeneralSetting> generalSettingFunc = gsb => gsb.Build();
            
            settingsBuilder.General(generalSettingFunc);
            
            Assert.NotNull(settingsBuilder.Build().General);
        }
        
        /// <summary>
        /// Tests that graphic valid input
        /// </summary>
        [Fact]
        public void Graphic_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            Func<GraphicSettingBuilder, GraphicSetting> graphicSettingFunc = gsb => gsb.Build();
            
            settingsBuilder.Graphic(graphicSettingFunc);
            
            Assert.NotNull(settingsBuilder.Build().Graphic);
        }
        
        /// <summary>
        /// Tests that input valid input
        /// </summary>
        [Fact]
        public void Input_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            Func<InputSettingBuilder, InputSetting> inputSettingFunc = isb => isb.Build();
            
            settingsBuilder.Input(inputSettingFunc);
            
            Assert.NotNull(settingsBuilder.Build().Input);
        }
        
        /// <summary>
        /// Tests that network valid input
        /// </summary>
        [Fact]
        public void Network_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            Func<NetworkSettingBuilder, NetworkSetting> networkSettingFunc = nsb => nsb.Build();
            
            settingsBuilder.Network(networkSettingFunc);
            
            Assert.NotNull(settingsBuilder.Build().Network);
        }
        
        /// <summary>
        /// Tests that physic valid input
        /// </summary>
        [Fact]
        public void Physic_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            Func<PhysicSettingBuilder, PhysicSetting> physicSettingFunc = psb => psb.Build();
            
            settingsBuilder.Physic(physicSettingFunc);
            
            Assert.NotNull(settingsBuilder.Build().Physic);
        }
        
        /// <summary>
        /// Tests that scene valid input
        /// </summary>
        [Fact]
        public void Scene_ValidInput()
        {
            SettingsBuilder settingsBuilder = new SettingsBuilder();
            Func<SceneSettingBuilder, SceneSetting> sceneSettingFunc = ssb => ssb.Build();
            
            settingsBuilder.Scene(sceneSettingFunc);
            
            Assert.NotNull(settingsBuilder.Build().Scene);
        }
    }
}