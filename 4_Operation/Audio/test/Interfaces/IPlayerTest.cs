

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
            TestPlayer player = new TestPlayer();

            bool playing = player.Playing;

            Assert.False(playing);
        }

        /// <summary>
        ///     Tests that paused property should return boolean value
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReturnBooleanValue()
        {
            TestPlayer player = new TestPlayer();

            bool paused = player.Paused;

            Assert.False(paused);
        }

        /// <summary>
        ///     Tests that play method should accept file name parameter
        /// </summary>
        [Fact]
        public async Task Play_Method_ShouldAcceptFileNameParameter()
        {
            TestPlayer player = new TestPlayer();
            string fileName = "test.wav";

            await player.Play(fileName);

            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play loop method should accept file name and loop parameters
        /// </summary>
        [Fact]
        public async Task PlayLoop_Method_ShouldAcceptFileNameAndLoopParameters()
        {
            TestPlayer player = new TestPlayer();
            string fileName = "test.wav";
            bool loop = true;

            await player.PlayLoop(fileName, loop);

            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that pause method should be callable
        /// </summary>
        [Fact]
        public async Task Pause_Method_ShouldBeCallable()
        {
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");

            await player.Pause();

            Assert.True(player.Paused);
        }

        /// <summary>
        ///     Tests that resume method should be callable
        /// </summary>
        [Fact]
        public async Task Resume_Method_ShouldBeCallable()
        {
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");
            await player.Pause();

            await player.Resume();

            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that stop method should be callable
        /// </summary>
        [Fact]
        public async Task Stop_Method_ShouldBeCallable()
        {
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");

            await player.Stop();

            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that set volume method should accept byte parameter
        /// </summary>
        [Fact]
        public async Task SetVolume_Method_ShouldAcceptByteParameter()
        {
            TestPlayer player = new TestPlayer();
            byte volume = 50;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event should be raiseable
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeRaiseable()
        {
            TestPlayer player = new TestPlayer();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            player.RaisePlaybackFinished();

            Assert.True(eventRaised);
        }

        /// <summary>
        ///     Tests that playback finished event sender should be player instance
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_SenderShouldBePlayerInstance()
        {
            TestPlayer player = new TestPlayer();
            object eventSender = null;
            player.PlaybackFinished += (sender, e) => eventSender = sender;

            player.RaisePlaybackFinished();

            Assert.Same(player, eventSender);
        }

        /// <summary>
        ///     Tests that set volume with zero should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithZero_ShouldWork()
        {
            TestPlayer player = new TestPlayer();
            byte volume = 0;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with max value should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithMaxValue_ShouldWork()
        {
            TestPlayer player = new TestPlayer();
            byte volume = 100;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play loop with false should work
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithFalse_ShouldWork()
        {
            TestPlayer player = new TestPlayer();
            string fileName = "test.wav";
            bool loop = false;

            await player.PlayLoop(fileName, loop);

            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that pause without playing should not set paused
        /// </summary>
        [Fact]
        public async Task Pause_WithoutPlaying_ShouldNotSetPaused()
        {
            TestPlayer player = new TestPlayer();

            await player.Pause();

            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that resume without pause should not change state
        /// </summary>
        [Fact]
        public async Task Resume_WithoutPause_ShouldNotChangeState()
        {
            TestPlayer player = new TestPlayer();
            await player.Play("test.wav");

            await player.Resume();

            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple play calls should work
        /// </summary>
        [Fact]
        public async Task Play_MultipleCalls_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

            await player.Play("test1.wav");
            await player.Play("test2.wav");
            await player.Play("test3.wav");

            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play stop play sequence should work
        /// </summary>
        [Fact]
        public async Task Play_Stop_Play_Sequence_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

            await player.Play("test1.wav");
            await player.Stop();
            await player.Play("test2.wav");

            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play pause resume sequence should work
        /// </summary>
        [Fact]
        public async Task Play_Pause_Resume_Sequence_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

            await player.Play("test.wav");
            await player.Pause();
            await player.Resume();

            Assert.True(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that play pause stop sequence should work
        /// </summary>
        [Fact]
        public async Task Play_Pause_Stop_Sequence_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

            await player.Play("test.wav");
            await player.Pause();
            await player.Stop();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that set volume multiple times should work
        /// </summary>
        [Fact]
        public async Task SetVolume_MultipleTimes_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

            await player.SetVolume(0);
            await player.SetVolume(50);
            await player.SetVolume(100);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that playback finished event can be subscribed multiple times
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_CanBeSubscribedMultipleTimes()
        {
            TestPlayer player = new TestPlayer();
            int handler1Count = 0;
            int handler2Count = 0;

            player.PlaybackFinished += (sender, e) => handler1Count++;
            player.PlaybackFinished += (sender, e) => handler2Count++;

            player.RaisePlaybackFinished();

            Assert.Equal(1, handler1Count);
            Assert.Equal(1, handler2Count);
        }

        /// <summary>
        ///     Tests that playback finished event can be unsubscribed
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_CanBeUnsubscribed()
        {
            TestPlayer player = new TestPlayer();
            int eventCount = 0;
            EventHandler handler = (sender, e) => eventCount++;

            player.PlaybackFinished += handler;
            player.RaisePlaybackFinished();

            player.PlaybackFinished -= handler;
            player.RaisePlaybackFinished();

            Assert.Equal(1, eventCount);
        }

        /// <summary>
        ///     Tests that playback finished event without subscribers should not throw
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_WithoutSubscribers_ShouldNotThrow()
        {
            TestPlayer player = new TestPlayer();

            player.RaisePlaybackFinished();

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that play with null file name should accept parameter
        /// </summary>
        [Fact]
        public async Task Play_WithNullFileName_ShouldAcceptParameter()
        {
            TestPlayer player = new TestPlayer();

            await player.Play(null);

            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that play with empty file name should accept parameter
        /// </summary>
        [Fact]
        public async Task Play_WithEmptyFileName_ShouldAcceptParameter()
        {
            TestPlayer player = new TestPlayer();

            await player.Play(string.Empty);

            Assert.True(player.Playing);
        }

        /// <summary>
        ///     Tests that set volume with byte max should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMax_ShouldWork()
        {
            TestPlayer player = new TestPlayer();
            byte volume = byte.MaxValue;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that set volume with byte min should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithByteMin_ShouldWork()
        {
            TestPlayer player = new TestPlayer();
            byte volume = byte.MinValue;

            await player.SetVolume(volume);

            Assert.NotNull(player);
        }

        /// <summary>
        ///     Tests that multiple pause without play should not throw
        /// </summary>
        [Fact]
        public async Task Pause_MultipleWithoutPlay_ShouldNotThrow()
        {
            TestPlayer player = new TestPlayer();

            await player.Pause();
            await player.Pause();
            await player.Pause();

            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Tests that multiple resume without play should not throw
        /// </summary>
        [Fact]
        public async Task Resume_MultipleWithoutPlay_ShouldNotThrow()
        {
            TestPlayer player = new TestPlayer();

            await player.Resume();
            await player.Resume();
            await player.Resume();

            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that multiple stop calls should work
        /// </summary>
        [Fact]
        public async Task Stop_MultipleCalls_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

            await player.Stop();
            await player.Stop();
            await player.Stop();

            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that play loop then stop should work
        /// </summary>
        [Fact]
        public async Task PlayLoop_ThenStop_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

            await player.PlayLoop("test.wav", true);
            await player.Stop();

            Assert.False(player.Playing);
        }

        /// <summary>
        ///     Tests that playback finished event should be invoked multiple times
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldBeInvokedMultipleTimes()
        {
            TestPlayer player = new TestPlayer();
            int eventCount = 0;
            player.PlaybackFinished += (sender, e) => eventCount++;

            player.RaisePlaybackFinished();
            player.RaisePlaybackFinished();
            player.RaisePlaybackFinished();

            Assert.Equal(3, eventCount);
        }

        /// <summary>
        ///     Tests that set volume with various values should work
        /// </summary>
        [Fact]
        public async Task SetVolume_WithVariousValues_ShouldWork()
        {
            TestPlayer player = new TestPlayer();

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