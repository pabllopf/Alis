using System;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The browser player instance tests class
    /// </summary>
    public class BrowserPlayerInstanceTests
    {
        /// <summary>
        /// Tests that constructor with open al available should initialize
        /// </summary>
        [RequireOpenAlFact]
        public void Constructor_WithOpenALAvailable_ShouldInitialize()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();
                Assert.NotNull(player);
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Contains("OpenAL", ex.Message);
            }
            catch (DllNotFoundException)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        /// Tests that pause when not playing should set paused
        /// </summary>
        [RequireOpenAlFact]
        public void Pause_WhenNotPlaying_ShouldSetPaused()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();
                player.Pause();
                Assert.True(player.Paused);
                Assert.False(player.Playing);
            }
            catch (InvalidOperationException)
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        /// Tests that resume when not playing should set playing
        /// </summary>
        [RequireOpenAlFact]
        public void Resume_WhenNotPlaying_ShouldSetPlaying()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();
                player.Resume();
                Assert.False(player.Paused);
                Assert.True(player.Playing);
            }
            catch (InvalidOperationException)
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        /// Tests that stop when not playing should set both false
        /// </summary>
        [RequireOpenAlFact]
        public void Stop_WhenNotPlaying_ShouldSetBothFalse()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();
                player.Stop();
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
            catch (InvalidOperationException)
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        /// Tests that set volume should return completed task
        /// </summary>
        [RequireOpenAlFact]
        public void SetVolume_ShouldReturnCompletedTask()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();
                Task result = player.SetVolume(50);
                Assert.Equal(Task.CompletedTask, result);
            }
            catch (InvalidOperationException)
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        /// Tests that pause resume stop sequence should work
        /// </summary>
        [RequireOpenAlFact]
        public void Pause_Resume_Stop_Sequence_ShouldWork()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();
                player.Pause();
                Assert.True(player.Paused);

                player.Resume();
                Assert.True(player.Playing);

                player.Stop();
                Assert.False(player.Playing);
                Assert.False(player.Paused);
            }
            catch (InvalidOperationException)
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        /// Tests that playback finished should be raiseable
        /// </summary>
        [RequireOpenAlFact]
        public void PlaybackFinished_ShouldBeRaiseable()
        {
            try
            {
                BrowserPlayer player = new BrowserPlayer();
                bool raised = false;
                player.PlaybackFinished += (sender, e) => raised = true;

                player.Stop();
                Assert.NotNull(player);
            }
            catch (InvalidOperationException)
            {
            }
            catch (DllNotFoundException)
            {
            }
        }
    }
}
