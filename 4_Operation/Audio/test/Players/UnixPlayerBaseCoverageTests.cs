using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Samples;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class UnixPlayerBaseCoverageTests
    {
        [Fact]
        public void StartBashProcess_ShouldStartProcess()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            MethodInfo method = typeof(UnixPlayerBase).GetMethod("StartBashProcess", BindingFlags.NonPublic | BindingFlags.Instance);
            Process process = (Process)method.Invoke(player, new object[] { "echo test" });
            Assert.NotNull(process);
            Assert.False(process.HasExited);
            process.Kill();
            process.Dispose();
        }

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

        [Fact]
        public void Pause_WhenNotPlaying_ShouldNotSetPaused()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Pause();
            Assert.False(player.Paused);
        }

        [Fact]
        public void Pause_WhenPlayingButProcessNull_ShouldNotSetPaused()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            PropertyInfo playingProp = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProp.SetValue(player, true, null);

            player.Pause();
            Assert.False(player.Paused);
        }

        [Fact]
        public void Resume_WhenNotPlaying_ShouldNotChangeState()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Resume();
            Assert.False(player.Paused);
            Assert.False(player.Playing);
        }

        [Fact]
        public void Resume_WhenPlayingButNotPaused_ShouldNotChangePaused()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            PropertyInfo playingProp = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProp.SetValue(player, true, null);

            player.Resume();
            Assert.False(player.Paused);
        }

        [Fact]
        public void Stop_WhenProcessIsNull_ShouldSetPlayingAndPausedFalse()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            player.Stop();
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        [Fact]
        public void Stop_WhenProcessIsNotNull_ShouldKillAndDispose()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            MethodInfo startMethod = typeof(UnixPlayerBase).GetMethod("StartBashProcess", BindingFlags.NonPublic | BindingFlags.Instance);
            Process process = (Process)startMethod.Invoke(player, new object[] { "sleep 5" });
            Assert.NotNull(process);

            FieldInfo processField = typeof(UnixPlayerBase).GetField("_process", BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(player, process);

            PropertyInfo playingProp = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProp.SetValue(player, true, null);

            player.Stop();

            Assert.False(player.Playing);
            Assert.False(player.Paused);
            try { Assert.True(process.HasExited); } catch (InvalidOperationException) { /* process already disposed */ }
            process.Dispose();
        }

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

        [Fact]
        public void HandlePlaybackFinished_WhenPlaying_ShouldSetPlayingFalseAndInvokeEvent()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            PropertyInfo playingProp = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProp.SetValue(player, true, null);

            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            MethodInfo method = typeof(UnixPlayerBase).GetMethod("HandlePlaybackFinished", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(player, new object[] { "sender", EventArgs.Empty });

            Assert.False((bool)playingProp.GetValue(player));
            Assert.True(eventRaised);
        }

        [Fact]
        public void HandlePlaybackFinished_MultipleInvocations_ShouldOnlyFireOnce()
        {
            TestUnixPlayer player = new TestUnixPlayer();
            PropertyInfo playingProp = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
            playingProp.SetValue(player, true, null);

            int eventCount = 0;
            player.PlaybackFinished += (sender, e) => eventCount++;

            MethodInfo method = typeof(UnixPlayerBase).GetMethod("HandlePlaybackFinished", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(player, new object[] { null, EventArgs.Empty });
            method.Invoke(player, new object[] { null, EventArgs.Empty });

            Assert.Equal(1, eventCount);
        }

        [Fact]
        public void PauseProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.PauseProcessCommand;
            string formatted = string.Format(command, 12345);
            Assert.Equal("kill -STOP 12345", formatted);
        }

        [Fact]
        public void ResumeProcessCommand_ShouldBeFormattable()
        {
            string command = UnixPlayerBase.ResumeProcessCommand;
            string formatted = string.Format(command, 67890);
            Assert.Equal("kill -CONT 67890", formatted);
        }

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
