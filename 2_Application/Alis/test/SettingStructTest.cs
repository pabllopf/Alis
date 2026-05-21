// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingStructTest.cs
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


using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for all setting structs: default values, custom constructors, and interface implementations
    /// </summary>
    public class SettingStructTest
    {
        /// <summary>
        ///     Tests that AudioSetting default values are correct
        /// </summary>
        [Fact]
        public void AudioSetting_DefaultValues_ShouldBeCorrect()
        {
            AudioSetting setting = new AudioSetting();

            Assert.Equal(100, setting.Volume);
            Assert.False(setting.Mute);
        }

        /// <summary>
        ///     Tests that AudioSetting custom constructor stores values
        /// </summary>
        [Fact]
        public void AudioSetting_CustomConstructor_ShouldStoreValues()
        {
            AudioSetting setting = new AudioSetting(50, true);

            Assert.Equal(50, setting.Volume);
            Assert.True(setting.Mute);
        }

        /// <summary>
        ///     Tests that AudioSetting implements IAudioSetting
        /// </summary>
        [Fact]
        public void AudioSetting_ShouldImplementIAudioSetting()
        {
            AudioSetting setting = new AudioSetting();

            Assert.IsAssignableFrom<IAudioSetting>(setting);
        }

        /// <summary>
        ///     Tests that GraphicSetting default values are correct
        /// </summary>
        [Fact]
        public void GraphicSetting_DefaultValues_ShouldBeCorrect()
        {
            GraphicSetting setting = new GraphicSetting();

            Assert.Equal(60.0, setting.TargetFrames);
            Assert.Equal("OpenGL", setting.Target);
            Assert.False(setting.PreviewMode);
            Assert.False(setting.HasGrid);
            Assert.Equal(new Vector2F(800, 600), setting.WindowSize);
            Assert.True(setting.IsResizable);
        }

        /// <summary>
        ///     Tests that GraphicSetting custom constructor stores values
        /// </summary>
        [Fact]
        public void GraphicSetting_CustomConstructor_ShouldStoreValues()
        {
            GraphicSetting setting = new GraphicSetting(
                120.0,
                "Vulkan",
                true,
                Color.White,
                true,
                Color.Black,
                new Vector2F(1920, 1080),
                false);

            Assert.Equal(120.0, setting.TargetFrames);
            Assert.Equal("Vulkan", setting.Target);
            Assert.True(setting.PreviewMode);
            Assert.True(setting.HasGrid);
            Assert.Equal(Color.White, setting.GridColor);
            Assert.Equal(Color.Black, setting.BackgroundColor);
            Assert.Equal(new Vector2F(1920, 1080), setting.WindowSize);
            Assert.False(setting.IsResizable);
        }

        /// <summary>
        ///     Tests that GraphicSetting implements IGraphicSetting
        /// </summary>
        [Fact]
        public void GraphicSetting_ShouldImplementIGraphicSetting()
        {
            GraphicSetting setting = new GraphicSetting();

            Assert.IsAssignableFrom<IGraphicSetting>(setting);
        }

        /// <summary>
        ///     Tests that InputSetting default values are correct
        /// </summary>
        [Fact]
        public void InputSetting_DefaultValues_ShouldBeCorrect()
        {
            InputSetting setting = new InputSetting();

            Assert.Equal(0.1f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that InputSetting custom constructor stores values
        /// </summary>
        [Fact]
        public void InputSetting_CustomConstructor_ShouldStoreValues()
        {
            InputSetting setting = new InputSetting(2.5f);

            Assert.Equal(2.5f, setting.MouseSensitivity);
        }

        /// <summary>
        ///     Tests that InputSetting implements IInputSetting
        /// </summary>
        [Fact]
        public void InputSetting_ShouldImplementIInputSetting()
        {
            InputSetting setting = new InputSetting();

            Assert.IsAssignableFrom<IInputSetting>(setting);
        }

        /// <summary>
        ///     Tests that PhysicSetting default values are correct
        /// </summary>
        [Fact]
        public void PhysicSetting_DefaultValues_ShouldBeCorrect()
        {
            PhysicSetting setting = new PhysicSetting();

            Assert.Equal(new Vector2F(0, -9.81f), setting.Gravity);
            Assert.False(setting.Debug);
            Assert.Equal(new Color(0, 0, 0, 1), setting.DebugColor);
        }

        /// <summary>
        ///     Tests that PhysicSetting custom constructor stores values
        /// </summary>
        [Fact]
        public void PhysicSetting_CustomConstructor_ShouldStoreValues()
        {
            Vector2F customGravity = new Vector2F(0, -5.0f);
            Color customColor = Color.Blue;

            PhysicSetting setting = new PhysicSetting(customGravity, true, customColor);

            Assert.Equal(customGravity, setting.Gravity);
            Assert.True(setting.Debug);
            Assert.Equal(customColor, setting.DebugColor);
        }

        /// <summary>
        ///     Tests that PhysicSetting implements IPhysicSetting
        /// </summary>
        [Fact]
        public void PhysicSetting_ShouldImplementIPhysicSetting()
        {
            PhysicSetting setting = new PhysicSetting();

            Assert.IsAssignableFrom<IPhysicSetting>(setting);
        }

        /// <summary>
        ///     Tests that Setting default constructor creates all nested settings
        /// </summary>
        [Fact]
        public void Setting_DefaultConstructor_ShouldCreateAllNestedSettings()
        {
            Setting setting = new Setting();

            Assert.NotNull(setting.General);
            Assert.NotNull(setting.Audio);
            Assert.NotNull(setting.Graphic);
            Assert.NotNull(setting.Input);
            Assert.NotNull(setting.Network);
            Assert.NotNull(setting.Physic);
        }

        /// <summary>
        ///     Tests that Setting implements ISetting
        /// </summary>
        [Fact]
        public void Setting_ShouldImplementISetting()
        {
            Setting setting = new Setting();

            Assert.IsAssignableFrom<ISetting>(setting);
        }
    }
}
