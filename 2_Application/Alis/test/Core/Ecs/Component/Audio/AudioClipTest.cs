// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioClipTest.cs
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
    /// The audio clip test class
    /// </summary>
    public class AudioClipTest
    {
        /// <summary>
        /// Tests that audio clip default constructor valid input
        /// </summary>
        [Fact]
        public void AudioClip_DefaultConstructor_ValidInput()
        {
            AudioClip audioClip = new AudioClip();
            
            Assert.NotNull(audioClip);
        }
        
        /// <summary>
        /// Tests that audio clip constructor with full path valid input
        /// </summary>
        [Fact]
        public void AudioClip_ConstructorWithFullPath_ValidInput()
        {
            AudioClip audioClip = new AudioClip("testPath");
            
            Assert.NotNull(audioClip);
            Assert.Equal("testPath", audioClip.FullPathAudioFile);
        }
        
        /// <summary>
        /// Tests that play valid input
        /// </summary>
        [Fact]
        public void Play_ValidInput()
        {
            AudioClip audioClip = new AudioClip();
            
            audioClip.Play();
            
            Assert.False(audioClip.IsPlaying);
        }
        
        /// <summary>
        /// Tests that stop valid input
        /// </summary>
        [Fact]
        public void Stop_ValidInput()
        {
            AudioClip audioClip = new AudioClip();
            
            audioClip.Play();
            audioClip.Stop();
            
            Assert.False(audioClip.IsPlaying);
        }
        
        /// <summary>
        /// Tests that resume valid input
        /// </summary>
        [Fact]
        public void Resume_ValidInput()
        {
            AudioClip audioClip = new AudioClip();
            
            audioClip.Play();
            audioClip.Stop();
            audioClip.Resume();
            
            Assert.False(audioClip.IsPlaying);
        }
        
        /// <summary>
        /// Tests that builder valid input
        /// </summary>
        [Fact]
        public void Builder_ValidInput()
        {
            AudioClipBuilder audioClipBuilder = AudioClip.Builder();
            
            Assert.NotNull(audioClipBuilder);
        }
    }
}