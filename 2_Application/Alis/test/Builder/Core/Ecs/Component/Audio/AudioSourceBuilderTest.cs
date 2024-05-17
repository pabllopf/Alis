// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSourceBuilderTest.cs
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
using Alis.Builder.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Audio;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Component.Audio
{
    /// <summary>
    /// The audio source builder test class
    /// </summary>
    public class AudioSourceBuilderTest
    {
        /// <summary>
        /// Tests that audio source builder default constructor valid input
        /// </summary>
        [Fact]
        public void AudioSourceBuilder_DefaultConstructor_ValidInput()
        {
            AudioSourceBuilder audioSourceBuilder = new AudioSourceBuilder();
            
            Assert.NotNull(audioSourceBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            AudioSourceBuilder audioSourceBuilder = new AudioSourceBuilder();
            
            AudioSource audioSource = audioSourceBuilder.Build();
            
            Assert.NotNull(audioSource);
        }
        
        /// <summary>
        /// Tests that is active valid input
        /// </summary>
        [Fact]
        public void IsActive_ValidInput()
        {
            AudioSourceBuilder audioSourceBuilder = new AudioSourceBuilder();
            bool isActive = true;
            
            audioSourceBuilder.IsActive(isActive);
            
            Assert.Equal(isActive, audioSourceBuilder.Build().IsEnable);
        }
        
        /// <summary>
        /// Tests that play on awake valid input
        /// </summary>
        [Fact]
        public void PlayOnAwake_ValidInput()
        {
            AudioSourceBuilder audioSourceBuilder = new AudioSourceBuilder();
            bool playOnAwake = true;
            
            audioSourceBuilder.PlayOnAwake(playOnAwake);
            
            Assert.Equal(playOnAwake, audioSourceBuilder.Build().PlayOnAwake);
        }
        
        /// <summary>
        /// Tests that set audio clip valid input
        /// </summary>
        [Fact]
        public void SetAudioClip_ValidInput()
        {
            AudioSourceBuilder audioSourceBuilder = new AudioSourceBuilder();
            Func<AudioClipBuilder, AudioClip> audioClipFunc = acb => acb.Build();
            
            audioSourceBuilder.SetAudioClip(audioClipFunc);
            
            Assert.NotNull(audioSourceBuilder.Build().AudioClip);
        }
    }
}