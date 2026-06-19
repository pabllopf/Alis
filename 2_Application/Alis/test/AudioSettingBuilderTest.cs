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
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The audio setting builder test class
    /// </summary>
    public class AudioSettingBuilderTest
    {
        /// <summary>
        /// Tests that constructor no args creates builder
        /// </summary>
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns audio setting instance
        /// </summary>
        [Fact]
        public void Build_ReturnsAudioSettingInstance()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSetting result = builder.Build();
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that volume sets volume returns builder
        /// </summary>
        [Fact]
        public void Volume_SetsVolume_ReturnsBuilder()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSettingBuilder result = builder.Volume(75);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that is mute sets mute returns builder
        /// </summary>
        [Fact]
        public void IsMute_SetsMute_ReturnsBuilder()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSettingBuilder result = builder.IsMute(true);
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that chaining all properties creates audio setting
        /// </summary>
        [Fact]
        public void ChainingAllProperties_CreatesAudioSetting()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSetting result = builder.Volume(50).IsMute(false).Build();
            Assert.NotNull(result);
        }
    }
}
