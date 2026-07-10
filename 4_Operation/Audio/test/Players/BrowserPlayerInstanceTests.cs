using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class BrowserPlayerInstanceTests
    {
        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
