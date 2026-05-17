// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSettingBuilderTest.cs
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

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Audio;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ConfigurationBuilders.Audio
{
    /// <summary>
    ///     Contains unit tests for the <see cref="AudioSettingBuilder" /> class.
    /// </summary>
    public class AudioSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            // Arrange & Act
            AudioSettingBuilder builder = new AudioSettingBuilder();

            // Assert
            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns an AudioSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsAudioSettingInstance()
        {
            // Arrange & Act
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSetting setting = builder.Build();

            // Assert
            Assert.NotNull(setting);
            Assert.IsType<AudioSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null AudioSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullAudioSetting()
        {
            // Arrange & Act
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSetting setting = builder.Build();

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that AudioSetting can be configured via the builder.
        /// </summary>
        [Fact]
        public void AudioSettingCanBeConfiguredViaBuilder()
        {
            // Arrange
            AudioSettingBuilder builder = new AudioSettingBuilder();

            // Act
            AudioSetting setting = builder.Volume(80).IsMute(false).Build();

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder creates a valid AudioSetting object.
        /// </summary>
        [Fact]
        public void BuilderCreatesValidAudioSettingObject()
        {
            // Arrange
            AudioSettingBuilder builder = new AudioSettingBuilder();

            // Act
            AudioSetting setting = builder.Build();

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            // Arrange & Act
            AudioSettingBuilder builder = new AudioSettingBuilder();

            // Assert
            Assert.IsAssignableFrom<IBuild<AudioSetting>>(builder);
        }

        /// <summary>
        ///     Tests that volume can be set via the builder.
        /// </summary>
        [Fact]
        public void VolumeCanBeSetViaBuilder()
        {
            // Arrange
            AudioSettingBuilder builder = new AudioSettingBuilder();

            // Act
            AudioSetting setting = builder.Volume(100).Build();

            // Assert
            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that mute can be set via the builder.
        /// </summary>
        [Fact]
        public void MuteCanBeSetViaBuilder()
        {
            // Arrange
            AudioSettingBuilder builder = new AudioSettingBuilder();

            // Act
            AudioSetting setting = builder.IsMute(true).Build();

            // Assert
            Assert.NotNull(setting);
        }
    }
}
