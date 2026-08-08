using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Core.Audio.Players;
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
        /// Tests that start bash process should start process
        /// </summary>
        [Fact]
        public void StartBashProcess_ShouldStartProcess()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            MethodInfo method = typeof(UnixPlayerBase).GetMethod("StartBashProcess", BindingFlags.NonPublic | BindingFlags.Instance);
            Process process = (Process)method.Invoke(player, new object[] { "sleep 1" });
            Assert.NotNull(process);
            Assert.False(process.HasExited);
            process.Kill();
            process.Dispose();
        }

        /// <summary>
        /// Tests that start bash process with quotes in command should escape
        /// </summary>
        [Fact]
        public void StartBashProcess_WithQuotesInCommand_ShouldEscape()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            MethodInfo method = typeof(UnixPlayerBase).GetMethod("StartBashProcess", BindingFlags.NonPublic | BindingFlags.Instance);
            Process process = (Process)method.Invoke(player, new object[] { "echo \"hello world\"" });
            Assert.NotNull(process);
            process.Kill();
            process.Dispose();
        }

        /// <summary>
        /// Tests that pause when not playing should not set paused
        /// </summary>
        [Fact]
        public void Pause_WhenNotPlaying_ShouldNotSetPaused()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Pause();
            Assert.False(player.Paused);
        }


        /// <summary>
        /// Tests that resume when not playing should not change state
        /// </summary>
        [Fact]
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
        [Fact]
        public void Stop_WhenProcessIsNull_ShouldSetPlayingAndPausedFalse()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Stop();
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }


        /// <summary>
        /// Tests that handle playback finished when not playing should not invoke event
        /// </summary>
        [Fact]
        public void HandlePlaybackFinished_WhenNotPlaying_ShouldNotInvokeEvent()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            MethodInfo method = typeof(UnixPlayerBase).GetMethod("HandlePlaybackFinished", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(player, new object[] { null, EventArgs.Empty });

            Assert.False(eventRaised);
        }

       

        /// <summary>
        /// Tests that pause process command should be formattable
        /// </summary>
        [Fact]
        public void PauseProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.PauseProcessCommand;
            string formatted = string.Format(command, 12345);
            Assert.Equal("kill -STOP 12345", formatted);
        }

        /// <summary>
        /// Tests that resume process command should be formattable
        /// </summary>
        [Fact]
        public void ResumeProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;
            string formatted = string.Format(command, 67890);
            Assert.Equal("kill -CONT 67890", formatted);
        }

        /// <summary>
        /// Tests that get audio duration with non existent file should throw file not found exception
        /// </summary>
        [Fact]
        public void GetAudioDuration_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            MethodInfo method = typeof(UnixPlayerBase).GetMethod("GetAudioDuration", BindingFlags.NonPublic | BindingFlags.Instance);

            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(player, new object[] { "nonexistent_file_12345.wav" }));
            Assert.IsType<FileNotFoundException>(ex.InnerException);
        }
    }
}
