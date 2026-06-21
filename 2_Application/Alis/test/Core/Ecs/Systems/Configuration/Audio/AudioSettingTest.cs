// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSettingTest.cs
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

using Alis.Core.Ecs.Systems.Configuration.Audio;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Configuration.Audio
{
    /// <summary>
    ///     Tests for the AudioSetting struct
    /// </summary>
    public class AudioSettingTest
    {
        /// <summary>
        ///     Tests that default constructor sets expected defaults
        /// </summary>
        [Fact]
        public void AudioSetting_DefaultConstructor_ShouldSetDefaultValues()
        {
            AudioSetting setting = new AudioSetting();

            Assert.Equal(100, setting.Volume);
            Assert.False(setting.Mute);
        }

        /// <summary>
        ///     Tests that parameterized constructor sets all values
        /// </summary>
        [Fact]
        public void AudioSetting_ParameterizedConstructor_ShouldSetValues()
        {
            AudioSetting setting = new AudioSetting(50, true);

            Assert.Equal(50, setting.Volume);
            Assert.True(setting.Mute);
        }

        /// <summary>
        ///     Tests that properties can be modified after construction
        /// </summary>
        [Fact]
        public void AudioSetting_Properties_ShouldBeModifiable()
        {
            AudioSetting setting = new AudioSetting();

            setting.Volume = 75;
            Assert.Equal(75, setting.Volume);

            setting.Mute = true;
            Assert.True(setting.Mute);
        }

        /// <summary>
        ///     Tests that AudioSetting implements IAudioSetting interface
        /// </summary>
        [Fact]
        public void AudioSetting_ShouldImplementIAudioSetting()
        {
            AudioSetting setting = new AudioSetting();
            Assert.IsAssignableFrom<IAudioSetting>(setting);
        }
    }
}
