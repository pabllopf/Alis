using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class UnixPlayerBaseAsyncCoverageTests
    {
        /// <summary>
        /// Concrete implementation of UnixPlayerBase for testing which uses a valid command ("true")
        /// so the process exits immediately and successfully.
        /// </summary>
        private class TestPlayerForCoverage : UnixPlayerBase
        {
            public override Task SetVolume(byte percent) => Task.CompletedTask;
            internal override string GetBashCommand(string fileName) => "true";

            public new Process StartBashProcess(string command) => base.StartBashProcess(command);
            public new void HandlePlaybackFinished(object sender, EventArgs e) => base.HandlePlaybackFinished(sender, e);
        }

        [Fact]
        public async Task Play_WithExistingFile_ShouldSetPlayingTrue()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.Play(tempFile);
                Assert.True(player.Playing);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        [Fact]
        public async Task Play_WithCachedFile_ShouldReuseLastExtractedFile()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.Play(tempFile);
                Assert.True(player.Playing);

                FieldInfo lastPlayedField = typeof(UnixPlayerBase).GetField("_lastPlayedFile", BindingFlags.NonPublic | BindingFlags.Instance);
                string lastPlayed = (string)lastPlayedField.GetValue(player);
                Assert.NotNull(lastPlayed);

                await player.Play(tempFile);
                Assert.True(player.Playing);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        [Fact]
        public async Task Play_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            await Assert.ThrowsAsync<FileNotFoundException>(() => player.Play("nonexistent_file_12345.wav"));
            Assert.False(player.Playing);
        }

        [Fact]
        public async Task PlayLoop_WithoutLoop_WithExistingFile_ShouldSetPlayingTrue()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.PlayLoop(tempFile, false);
                Assert.True(player.Playing);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        [Fact]
        public async Task PlayLoop_WithoutLoop_WithNonExistentFile_ShouldThrow()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            await Assert.ThrowsAnyAsync<Exception>(() => player.PlayLoop("nonexistent_file_12345.wav", false));
        }

        [Fact]
        public async Task PlayLoop_WithLoop_WithNonExistentFile_ShouldThrow()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            await Assert.ThrowsAnyAsync<Exception>(() => player.PlayLoop("nonexistent_file_12345.wav", true));
        }

        [Fact]
        public async Task Pause_WhenPlayingWithProcess_ShouldSetPaused()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                Process process = player.StartBashProcess("sleep 2");
                FieldInfo processField = typeof(UnixPlayerBase).GetField("_process", BindingFlags.NonPublic | BindingFlags.Instance);
                processField.SetValue(player, process);
                PropertyInfo playingProp = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
                playingProp.SetValue(player, true, null);

                await player.Pause();
                Assert.True(player.Paused);

                process.Kill();
                process.Dispose();
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        [Fact]
        public async Task Resume_WhenPlayingAndPausedWithProcess_ShouldUnpause()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            Process process = player.StartBashProcess("sleep 5");
            try
            {
                FieldInfo processField = typeof(UnixPlayerBase).GetField("_process", BindingFlags.NonPublic | BindingFlags.Instance);
                processField.SetValue(player, process);
                PropertyInfo playingProp = typeof(UnixPlayerBase).GetProperty("Playing", BindingFlags.Public | BindingFlags.Instance);
                playingProp.SetValue(player, true, null);
                PropertyInfo pausedProp = typeof(UnixPlayerBase).GetProperty("Paused", BindingFlags.Public | BindingFlags.Instance);
                pausedProp.SetValue(player, true, null);

                await player.Resume();
                Assert.False(player.Paused);
            }
            finally
            {
                process.Kill();
                process.Dispose();
            }
        }

        [Fact]
        public async Task Play_AfterStop_ShouldWork()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.Play(tempFile);
                Assert.True(player.Playing);

                await player.Stop();
                Assert.False(player.Playing);

                await player.Play(tempFile);
                Assert.True(player.Playing);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        [Fact]
        public async Task PlayLoop_WithLoopTrue_ShouldStartBackgroundTask()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.PlayLoop(tempFile, true);
                Assert.True(player.Playing);

                await Task.Delay(100);
                await player.Stop();
                Assert.False(player.Playing);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        [Fact]
        public async Task PlayLoop_WithLoopTrue_ThenCachedFile_ShouldUseCache()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.PlayLoop(tempFile, true);
                Assert.True(player.Playing);

                await Task.Delay(50);
                await player.PlayLoop(tempFile, true);
                Assert.True(player.Playing);

                await Task.Delay(50);
                await player.Stop();
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }
    }
}
