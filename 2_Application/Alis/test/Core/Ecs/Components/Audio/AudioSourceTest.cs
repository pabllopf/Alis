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

using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     Tests for the AudioSource component struct
    /// </summary>
    public class AudioSourceTest
    {
        /// <summary>
        ///     Tests that the constructor creates an AudioSource with default values
        /// </summary>
        [Fact]
        public void AudioSource_Constructor_ShouldCreateWithDefaultValues()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            Assert.Equal(context, source.Context);
            Assert.Equal(string.Empty, source.NameFile);
            Assert.Equal(100f, source.Volume);
            Assert.False(source.IsMute);
            Assert.False(source.PlayOnAwake);
            Assert.False(source.IsLooping);
        }

        /// <summary>
        ///     Tests that AudioSource implements IAudioSource interface
        /// </summary>
        [Fact]
        public void AudioSource_ShouldImplementIAudioSourceInterface()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            Assert.IsAssignableFrom<IAudioSource>(source);
        }

        /// <summary>
        ///     Tests that the Play method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_PlayMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.Play();
        }

        /// <summary>
        ///     Tests that the Stop method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_StopMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.Stop();
        }

        /// <summary>
        ///     Tests that the Resume method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_ResumeMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.Resume();
        }

        /// <summary>
        ///     Tests that the OnStart method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_OnStartMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.OnStart(null!);
        }

        /// <summary>
        ///     Tests that the OnExit method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_OnExitMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.OnExit(null!);
        }

        /// <summary>
        ///     Tests that AudioSource properties are gettable and settable
        /// </summary>
        [Fact]
        public void AudioSource_Properties_ShouldBeGetAndSettable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.NameFile = "test.wav";
            Assert.Equal("test.wav", source.NameFile);

            source.Volume = 50f;
            Assert.Equal(50f, source.Volume);

            source.IsMute = true;
            Assert.True(source.IsMute);

            source.PlayOnAwake = true;
            Assert.True(source.PlayOnAwake);

            source.IsLooping = true;
            Assert.True(source.IsLooping);
        }
    }
}
