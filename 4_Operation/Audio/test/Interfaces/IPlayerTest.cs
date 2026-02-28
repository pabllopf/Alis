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
        ///     Tests that play loop with false should work
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithFalse_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            string fileName = "test.wav";
            bool loop = false;

            // Act
            await player.PlayLoop(fileName, loop);

            // Assert
            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that pause without playing should not set paused
        /// </summary>
        [Fact]
        public async Task Pause_WithoutPlaying_ShouldNotSetPaused()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Pause();

            // Assert
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that resume without pause should not change state
        /// </summary>
        [Fact]
        public async Task Resume_WithoutPause_ShouldNotChangeState()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");

            // Act
            await player.Resume();

            // Assert
            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple play calls should work
        /// </summary>
        [Fact]
        public async Task Play_MultipleCalls_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Play("test1.wav");
            await player.Play("test2.wav");
            await player.Play("test3.wav");

            // Assert
            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play stop play sequence should work
        /// </summary>
        [Fact]
        public async Task Play_Stop_Play_Sequence_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Play("test1.wav");
            await player.Stop();
            await player.Play("test2.wav");

            // Assert
            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play pause resume sequence should work
        /// </summary>
        [Fact]
        public async Task Play_Pause_Resume_Sequence_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Play("test.wav");
            await player.Pause();
            await player.Resume();

            // Assert
            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that play pause stop sequence should work
        /// </summary>
        [Fact]
        public async Task Play_Pause_Stop_Sequence_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Play("test.wav");
            await player.Pause();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that set volume multiple times should work
        /// </summary>
        [Fact]
        public async Task SetVolume_MultipleTimes_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.SetVolume(0);
            await player.SetVolume(50);
            await player.SetVolume(100);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event can be subscribed multiple times
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_CanBeSubscribedMultipleTimes()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            int handler1Count = 0;
            int handler2Count = 0;

            player.PlaybackFinished += (sender, e) => handler1Count++;
            player.PlaybackFinished += (sender, e) => handler2Count++;

            // Act
            player.RaisePlaybackFinished();

            // Assert
            Assert.Equal(1, handler1Count);
            Assert.Equal(1, handler2Count);
        }

        /// <summary>
        ///     Tests that playback finished event can be unsubscribed
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_CanBeUnsubscribed()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            int eventCount = 0;
            EventHandler handler = (sender, e) => eventCount++;

            player.PlaybackFinished += handler;
            player.RaisePlaybackFinished();

            // Act
            player.PlaybackFinished -= handler;
            player.RaisePlaybackFinished();

            // Assert
            Assert.Equal(1, eventCount);
        }

        /// <summary>
        ///     Tests that playback finished event without subscribers should not throw
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_WithoutSubscribers_ShouldNotThrow()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            player.RaisePlaybackFinished();

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play with null file name should accept parameter
        /// </summary>
        [Fact]
        public async Task Play_WithNullFileName_ShouldAcceptParameter()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Play(null);

            // Assert
            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play with empty file name should accept parameter
        /// </summary>
        [Fact]
        public async Task Play_WithEmptyFileName_ShouldAcceptParameter()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Play(string.Empty);

            // Assert
            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that set volume with byte max should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMax_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            byte volume = byte.MaxValue;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with byte min should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMin_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            byte volume = byte.MinValue;

            // Act
            await player.SetVolume(volume);

            // Assert - No exception thrown
            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple pause without play should not throw
        /// </summary>
        [Fact]
        public async Task Pause_MultipleWithoutPlay_ShouldNotThrow()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Pause();
            await player.Pause();
            await player.Pause();

            // Assert
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple resume without play should not throw
        /// </summary>
        [Fact]
        public async Task Resume_MultipleWithoutPlay_ShouldNotThrow()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Resume();
            await player.Resume();
            await player.Resume();

            // Assert
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that multiple stop calls should work
        /// </summary>
        [Fact]
        public async Task Stop_MultipleCalls_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.Stop();
            await player.Stop();
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that play loop then stop should work
        /// </summary>
        [Fact]
        public async Task PlayLoop_ThenStop_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act
            await player.PlayLoop("test.wav", true);
            await player.Stop();

            // Assert
            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that playback finished event should be invoked multiple times
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeInvokedMultipleTimes()
        {
            // Arrange
            TestPlayer player = new TestPlayer();
            int eventCount = 0;
            player.PlaybackFinished += (sender, e) => eventCount++;

            // Act
            player.RaisePlaybackFinished();
            player.RaisePlaybackFinished();
            player.RaisePlaybackFinished();

            // Assert
            Assert.Equal(3, eventCount);
        }

        /// <summary>
        ///     Tests that set volume with various values should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithVariousValues_ShouldWork()
        {
            // Arrange
            TestPlayer player = new TestPlayer();

            // Act & Assert
            await player.SetVolume(1);
            await player.SetVolume(25);
            await player.SetVolume(50);
            await player.SetVolume(75);
            await player.SetVolume(99);

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
            public Task SetVolume(byte percent) => Task.CompletedTask;

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