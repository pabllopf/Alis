// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSourceTest.cs
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

namespace Alis.Test.Core.Ecs.Component.Audio
{
    /// <summary>
    /// The audio source test class
    /// </summary>
    public class AudioSourceTest
    {
        /// <summary>
        /// Tests that audio source default constructor valid input
        /// </summary>
        [Fact]
        public void AudioSource_DefaultConstructor_ValidInput()
        {
            AudioSource audioSource = new AudioSource();
            
            Assert.NotNull(audioSource);
            Assert.NotNull(audioSource.AudioClip);
        }
        
        /// <summary>
        /// Tests that audio source constructor with audio clip valid input
        /// </summary>
        [Fact]
        public void AudioSource_ConstructorWithAudioClip_ValidInput()
        {
            AudioClip audioClip = new AudioClip();
            AudioSource audioSource = new AudioSource(audioClip);
            
            Assert.NotNull(audioSource);
            Assert.Equal(audioClip, audioSource.AudioClip);
        }
        
        /// <summary>
        /// Tests that play valid input
        /// </summary>
        [Fact]
        public void Play_ValidInput()
        {
            AudioSource audioSource = new AudioSource();
            
            audioSource.Play();
            
            Assert.False(audioSource.IsPlaying);
        }
        
        /// <summary>
        /// Tests that stop valid input
        /// </summary>
        [Fact]
        public void Stop_ValidInput()
        {
            AudioSource audioSource = new AudioSource();
            
            audioSource.Play();
            audioSource.Stop();
            
            Assert.False(audioSource.IsPlaying);
        }
        
        /// <summary>
        /// Tests that resume valid input
        /// </summary>
        [Fact]
        public void Resume_ValidInput()
        {
            AudioSource audioSource = new AudioSource();
            
            audioSource.Play();
            audioSource.Stop();
            audioSource.Resume();
            
            Assert.False(audioSource.IsPlaying);
        }
        
        /// <summary>
        /// Tests that builder valid input
        /// </summary>
        [Fact]
        public void Builder_ValidInput()
        {
            AudioSourceBuilder audioSourceBuilder = new AudioSource().Builder();
            
            Assert.NotNull(audioSourceBuilder);
        }
    }
}