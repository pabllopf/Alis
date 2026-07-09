// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSourceCoverageTest.cs
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
    ///     Coverage tests for AudioSource struct edge cases
    /// </summary>
    public class AudioSourceCoverageTest
    {
        /// <summary>
        ///     Tests that OnUpdate is callable
        /// </summary>
        [Fact]
        public void OnUpdate_ShouldBeCallable()
        {
            Context context = new Context();
            AudioSource source = new AudioSource(context);

            source.OnUpdate(null!);
        }

        /// <summary>
        ///     Tests that Play calls player.Play for non-looping audio with a NameFile set
        /// </summary>
        [Fact]
        public void Play_WithMockPlayer_ShouldCallPlay()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Play(It.IsAny<string>())).Returns(Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;
            source.NameFile = "test.wav";

            source.Play();

            mock.Verify(p => p.Play("test.wav"), Times.Once);
        }

        /// <summary>
        ///     Tests that Play calls player.PlayLoop for looping audio with a NameFile set
        /// </summary>
        [Fact]
        public void Play_WithMockPlayerAndLooping_ShouldCallPlayLoop()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.PlayLoop(It.IsAny<string>(), It.IsAny<bool>())).Returns(Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;
            source.NameFile = "loop.wav";
            source.IsLooping = true;

            source.Play();

            mock.Verify(p => p.PlayLoop("loop.wav", true), Times.Once);
        }

        /// <summary>
        ///     Tests that Play uses FullPathAudioFile when set, via mock verification
        /// </summary>
        [Fact]
        public void Play_WithMockPlayerAndFullPath_ShouldUseFullPath()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Play(It.IsAny<string>())).Returns(Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;
            source.FullPathAudioFile = "/full/path/file.wav";

            source.Play();

            mock.Verify(p => p.Play("/full/path/file.wav"), Times.Once);
        }

        /// <summary>
        ///     Tests that Play with empty NameFile and no FullPath calls Play with empty string
        /// </summary>
        [Fact]
        public void Play_WithMockPlayerAndEmptyName_ShouldCallPlayWithEmpty()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.Play(It.IsAny<string>())).Returns(Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;

            source.Play();

            mock.Verify(p => p.Play(""), Times.Once);
        }

        /// <summary>
        ///     Tests that Play with FullPath and looping calls PlayLoop with full path
        /// </summary>
        [Fact]
        public void Play_WithMockPlayerAndFullPathAndLooping_ShouldCallPlayLoopWithFullPath()
        {
            Mock<IPlayer> mock = new Mock<IPlayer>();
            mock.Setup(p => p.PlayLoop(It.IsAny<string>(), It.IsAny<bool>())).Returns(Task.CompletedTask);

            Context context = new Context();
            AudioSource source = new AudioSource(context);
            source.PlayerForTest = mock.Object;
            source.FullPathAudioFile = "/full/path/loop.wav";
            source.IsLooping = true;

            source.Play();

            mock.Verify(p => p.PlayLoop("/full/path/loop.wav", true), Times.Once);
        }
    }
}
