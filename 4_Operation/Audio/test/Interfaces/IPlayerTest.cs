// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPlayerTest.cs
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
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Xunit;

namespace Alis.Core.Audio.Test.Interfaces
{
    /// <summary>
    ///     The i player test class
    /// </summary>
    /// <seealso cref="IPlayer" />
    public class IPlayerTest
    {
        /// <summary>
        ///     Tests that playing property should return boolean value
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReturnBooleanValue()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            
            // Act
            bool playing = player.Playing;
            
            // Assert
            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return boolean value
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReturnBooleanValue()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            
            // Act
            bool paused = player.Paused;
            
            // Assert
            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that play method should accept file name parameter
        /// </summary>
        [Fact]
        public async Task Play_Method_ShouldAcceptFileNameParameter()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            string fileName = "test.wav";
            
            // Act
            await player.Play(fileName);
            
            // Assert
            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play loop method should accept file name and loop parameters
        /// </summary>
        [Fact]
        public async Task PlayLoop_Method_ShouldAcceptFileNameAndLoopParameters()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            string fileName = "test.wav";
            bool loop = true;
            
            // Act
            await player.PlayLoop(fileName, loop);
            
            // Assert
            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that pause method should be callable
        /// </summary>
        [Fact]
        public async Task Pause_Method_ShouldBeCallable()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");
            
            // Act
            await player.Pause();
            
            // Assert
            Assert.True(player.Paused);
        }

        /// <summary>
        ///     Tests that resume method should be callable
        /// </summary>
        [Fact]
        public async Task Resume_Method_ShouldBeCallable()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");
            await player.Pause();
            
            // Act
            await player.Resume();
            
            // Assert
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that stop method should be callable
        /// </summary>
        [Fact]
        public async Task Stop_Method_ShouldBeCallable()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");
            
            // Act
            await player.Stop();
            
            // Assert
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that set volume method should accept byte parameter
        /// </summary>
        [Fact]
        public async Task SetVolume_Method_ShouldAcceptByteParameter()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            byte volume = 50;
            
            // Act
            await player.SetVolume(volume);
            
            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event should be raiseable
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeRaiseable()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;
            
            // Act
            player.RaisePlaybackFinished();
            
            // Assert
            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Tests that playback finished event sender should be player instance
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_SenderShouldBePlayerInstance()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            object eventSender = null;
            player.PlaybackFinished += (sender, e) => eventSender = sender;
            
            // Act
            player.RaisePlaybackFinished();
            
            // Assert
            Assert.Same(player, eventSender);
        }

        /// <summary>
        ///     Tests that set volume with zero should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithZero_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            byte volume = 0;
            
            // Act
            await player.SetVolume(volume);
            
            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with max value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithMaxValue_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            byte volume = 100;
            
            // Act
            await player.SetVolume(volume);
            
            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     The test player class
        /// </summary>
        /// <seealso cref="IPlayer" />
        private class TestPlayer : IPlayer
        {
            /// <summary>
            ///     Gets or sets the value of the playing
            /// </summary>
            public bool Playing { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the paused
            /// </summary>
            public bool Paused { get; private set; }

            /// <summary>
            ///     The playback finished
            /// </summary>
            public event EventHandler PlaybackFinished;

            /// <summary>
            ///     Plays the file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <returns>A task containing the task</returns>
            public Task Play(string fileName)
            {
                Playing = true;
                Paused = false;
                return Task.CompletedTask;
            }

            /// <summary>
            ///     Plays the loop using the specified file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <param name="loop">The loop</param>
            /// <returns>A task containing the task</returns>
            public Task PlayLoop(string fileName, bool loop)
            {
                Playing = true;
                Paused = false;
                return Task.CompletedTask;
            }

            /// <summary>
            ///     Pauses this instance
            /// </summary>
            /// <returns>A task containing the task</returns>
            public Task Pause()
            {
                if (Playing)
                {
                    Paused = true;
                }
                return Task.CompletedTask;
            }

            /// <summary>
            ///     Resumes this instance
            /// </summary>
            /// <returns>A task containing the task</returns>
            public Task Resume()
            {
                if (Playing && Paused)
                {
                    Paused = false;
                }
                return Task.CompletedTask;
            }

            /// <summary>
            ///     Stops this instance
            /// </summary>
            /// <returns>A task containing the task</returns>
            public Task Stop()
            {
                Playing = false;
                Paused = false;
                return Task.CompletedTask;
            }

            /// <summary>
            ///     Sets the volume using the specified percent
            /// </summary>
            /// <param name="percent">The percent</param>
            /// <returns>A task containing the task</returns>
            public Task SetVolume(byte percent)
            {
                return Task.CompletedTask;
            }

            /// <summary>
            ///     Raises the playback finished
            /// </summary>
            public void RaisePlaybackFinished()
            {
                PlaybackFinished?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

