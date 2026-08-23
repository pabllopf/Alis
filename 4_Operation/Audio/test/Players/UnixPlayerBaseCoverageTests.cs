using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Alis.Core.Audio.Test.Players.Samples;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The unix player base coverage tests class
    /// </summary>
    public class UnixPlayerBaseCoverageTests
    {

        /// <summary>
        /// Tests that pause when not playing should not set paused
        /// </summary>
        [UnixOnly]
        public void Pause_WhenNotPlaying_ShouldNotSetPaused()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Pause();
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that resume when not playing should not change state
        /// </summary>
        [UnixOnly]
        public void Resume_WhenNotPlaying_ShouldNotChangeState()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Resume();
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        /// <summary>
        /// Tests that stop when process is null should set playing and paused false
        /// </summary>
        [UnixOnly]
        public void Stop_WhenProcessIsNull_ShouldSetPlayingAndPausedFalse()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Stop();
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        /// Tests that pause process command should be formattable
        /// </summary>
        [UnixOnly]
        public void PauseProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.PauseProcessCommand;
            string formatted = string.Format(command, 12345);
            Assert.Equal("kill -STOP 12345", formatted);
        }

        /// <summary>
        /// Tests that resume process command should be formattable
        /// </summary>
        [UnixOnly]
        public void ResumeProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;
            string formatted = string.Format(command, 67890);
            Assert.Equal("kill -CONT 67890", formatted);
        }

    }
}
