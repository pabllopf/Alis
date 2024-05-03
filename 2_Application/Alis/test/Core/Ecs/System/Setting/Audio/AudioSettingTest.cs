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

using Alis.Builder.Core.Ecs.System.Setting.Audio;
using Alis.Core.Ecs.System.Setting.Audio;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Setting.Audio
{
    /// <summary>
    /// The audio setting test class
    /// </summary>
    public class AudioSettingTest
    {
        /// <summary>
        /// Tests that test audio setting volume
        /// </summary>
        [Fact]
        public void Test_AudioSetting_Volume()
        {
            // Arrange
            AudioSetting audioSetting = new AudioSetting();
            
            // Act
            audioSetting.Volume = 80;
            int result = audioSetting.Volume;
            
            // Assert
            Assert.NotNull(audioSetting);
            Assert.Equal(80, result);
        }
        
        /// <summary>
        /// Tests that test audio setting mute
        /// </summary>
        [Fact]
        public void Test_AudioSetting_Mute()
        {
            // Arrange
            AudioSetting audioSetting = new AudioSetting();
            
            // Act
            audioSetting.Mute = true;
            bool result = audioSetting.Mute;
            
            // Assert
            Assert.NotNull(audioSetting);
            Assert.True(result);
        }
        
        
        /// <summary>
        /// Tests that test audio setting builder
        /// </summary>
        [Fact]
        public void Test_AudioSetting_Builder()
        {
            // Arrange
            AudioSetting audioSetting = new AudioSetting();
            
            // Act
            AudioSettingBuilder result = audioSetting.Builder();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<AudioSettingBuilder>(result);
        }
    }
}