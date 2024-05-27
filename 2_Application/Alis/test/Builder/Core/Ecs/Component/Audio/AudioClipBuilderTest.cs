// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioClipBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Audio;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Component.Audio
{
    /// <summary>
    /// The audio clip builder test class
    /// </summary>
    public class AudioClipBuilderTest
    {
        /// <summary>
        /// Tests that audio clip builder default constructor valid input
        /// </summary>
        [Fact]
        public void AudioClipBuilder_DefaultConstructor_ValidInput()
        {
            AudioClipBuilder audioClipBuilder = new AudioClipBuilder();
            
            Assert.NotNull(audioClipBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            AudioClipBuilder audioClipBuilder = new AudioClipBuilder();
            
            AudioClip audioClip = audioClipBuilder.Build();
            
            Assert.NotNull(audioClip);
        }
        
        /// <summary>
        /// Tests that file path valid input
        /// </summary>
        [Fact]
        public void FilePath_ValidInput()
        {
            AudioClipBuilder audioClipBuilder = new AudioClipBuilder();
            string filePath = "testFilePath";
            
            audioClipBuilder.FilePath(filePath);
            
            Assert.Equal(filePath, audioClipBuilder.Build().NameFile);
        }
        
        /// <summary>
        /// Tests that mute valid input
        /// </summary>
        [Fact]
        public void Mute_ValidInput()
        {
            AudioClipBuilder audioClipBuilder = new AudioClipBuilder();
            bool mute = true;
            
            audioClipBuilder.Mute(mute);
            
            Assert.Equal(mute, audioClipBuilder.Build().IsMute);
        }
        
        /// <summary>
        /// Tests that volume valid input
        /// </summary>
        [Fact]
        public void Volume_ValidInput()
        {
            AudioClipBuilder audioClipBuilder = new AudioClipBuilder();
            float volume = 0.5f;
            
            audioClipBuilder.Volume(volume);
            
            Assert.Equal(volume, audioClipBuilder.Build().Volume);
        }
    }
}