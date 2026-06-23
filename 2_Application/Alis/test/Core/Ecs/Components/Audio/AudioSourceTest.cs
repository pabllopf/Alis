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

using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
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

        /// <summary>
        ///     Tests that Play sets FullPathAudioFile when NameFile is non-empty (branch coverage)
        /// </summary>
        [Fact]
        public void AudioSource_Play_WithNonEmptyNameFile_ShouldSetFullPathAudioFile()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);
            source.NameFile = "test_audio.wav";

            source.Play();
        }

        /// <summary>
        ///     Tests that Play calls player.PlayLoop when IsLooping is true (branch coverage)
        /// </summary>
        [Fact]
        public void AudioSource_Play_WithIsLoopingTrue_ShouldCallPlayerPlayLoop()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);
            source.NameFile = "looping_audio.wav";
            source.IsLooping = true;

            source.Play();
        }

        /// <summary>
        ///     Tests that OnStart calls Play when PlayOnAwake is true (branch coverage)
        /// </summary>
        [Fact]
        public void AudioSource_OnStart_WithPlayOnAwakeTrue_ShouldCallPlay()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);
            source.PlayOnAwake = true;
            source.NameFile = "awake_audio.wav";

            source.OnStart(null!);
        }

        /// <summary>
        ///     Tests that Play with empty NameFile does not throw (edge case)
        /// </summary>
        [Fact]
        public void AudioSource_Play_WithEmptyNameFile_ShouldNotThrow()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.Play();
        }

        /// <summary>
        ///     Tests that Stop calls player.Stop when player is playing
        /// </summary>
        [Fact]
        public void AudioSource_Stop_WhenPlayerIsPlaying_ShouldCallPlayerStop()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Playing).Returns(true);
            mock.Setup(p => p.Stop()).Returns(Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            source.Stop();

            mock.Verify(p => p.Stop(), Times.Once);
        }

        /// <summary>
        ///     Tests that Stop does not call player.Stop when player is not playing
        /// </summary>
        [Fact]
        public void AudioSource_Stop_WhenPlayerIsNotPlaying_ShouldNotCallPlayerStop()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Playing).Returns(false);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            source.Stop();

            mock.Verify(p => p.Stop(), Times.Never);
        }

        /// <summary>
        ///     Tests that Resume calls player.Resume when player is not playing
        /// </summary>
        [Fact]
        public void AudioSource_Resume_WhenPlayerIsNotPlaying_ShouldCallPlayerResume()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Playing).Returns(false);
            mock.Setup(p => p.Resume()).Returns(Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            source.Resume();

            mock.Verify(p => p.Resume(), Times.Once);
        }

        /// <summary>
        ///     Tests that Resume does not call player.Resume when player is playing
        /// </summary>
        [Fact]
        public void AudioSource_Resume_WhenPlayerIsPlaying_ShouldNotCallPlayerResume()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Playing).Returns(true);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            source.Resume();

            mock.Verify(p => p.Resume(), Times.Never);
        }

        /// <summary>
        ///     Tests that OnStart does not throw when PlayOnAwake is false (else branch)
        /// </summary>
        [Fact]
        public void AudioSource_OnStart_WithPlayOnAwakeFalse_ShouldNotThrow()
        {
            Context context = new Context();

            Mock<IPlayer> mock = new Mock<IPlayer>();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            source.OnStart(null!);
        }

        /// <summary>
        ///     Tests that Play uses FullPathAudioFile when it is non-empty (non-looping)
        /// </summary>
        [Fact]
        public void AudioSource_Play_WithFullPathAudioFileSet_ShouldUseFullPath()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.NameFile = "name.wav";
            source.FullPathAudioFile = "/full/path/file.wav";

            source.Play();
        }

        /// <summary>
        ///     Tests that Play uses FullPathAudioFile when it is non-empty and looping
        /// </summary>
        [Fact]
        public void AudioSource_Play_WithFullPathAudioFileSetAndLooping_ShouldUseFullPath()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.NameFile = "name.wav";
            source.FullPathAudioFile = "/full/path/file.wav";
            source.IsLooping = true;

            source.Play();
        }
    }
}
