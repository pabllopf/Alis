using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The unix player base async coverage tests class
    /// </summary>
    public class UnixPlayerBaseAsyncCoverageTests
    {
        /// <summary>
        /// Concrete implementation of UnixPlayerBase for testing which uses a valid command ("true")
        /// so the process exits immediately and successfully.
        /// </summary>
        private class TestPlayerForCoverage : UnixPlayerBase
        {
            /// <summary>
            /// Sets the volume using the specified percent
            /// </summary>
            /// <param name="percent">The percent</param>
            public override Task SetVolume(byte percent) => Task.CompletedTask;
            /// <summary>
            /// Gets the bash command using the specified file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <returns>The string</returns>
            internal override string GetBashCommand(string fileName) => "true";

            /// <summary>
            /// Starts the bash process using the specified command
            /// </summary>
            /// <param name="command">The command</param>
            /// <returns>The process</returns>
            public new Process StartBashProcess(string command) => base.StartBashProcess(command);
            /// <summary>
            /// Handles the playback finished using the specified sender
            /// </summary>
            /// <param name="sender">The sender</param>
            /// <param name="e">The </param>
            public new void HandlePlaybackFinished(object sender, EventArgs e) => base.HandlePlaybackFinished(sender, e);
        }

        /// <summary>
        /// Tests that play with existing file should set playing true
        /// </summary>
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

        /// <summary>
        /// Tests that play with cached file should reuse last extracted file
        /// </summary>
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

        /// <summary>
        /// Tests that play with non existent file should throw file not found exception
        /// </summary>
        [Fact]
        public async Task Play_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            await Assert.ThrowsAsync<FileNotFoundException>(() => player.Play("nonexistent_file_12345.wav"));
            Assert.False(player.Playing);
        }

        /// <summary>
        /// Tests that play loop without loop with existing file should set playing true
        /// </summary>
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

        /// <summary>
        /// Tests that play loop without loop with non existent file should throw
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithoutLoop_WithNonExistentFile_ShouldThrow()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            await Assert.ThrowsAnyAsync<Exception>(() => player.PlayLoop("nonexistent_file_12345.wav", false));
        }

        /// <summary>
        /// Tests that play loop with loop with non existent file should throw
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithLoop_WithNonExistentFile_ShouldThrow()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            await Assert.ThrowsAnyAsync<Exception>(() => player.PlayLoop("nonexistent_file_12345.wav", true));
        }


        /// <summary>
        /// Tests that play after stop should work
        /// </summary>
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

        /// <summary>
        /// Tests that play loop with loop true should start background task
        /// </summary>
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

        /// <summary>
        /// Tests that play loop with loop true then cached file should use cache
        /// </summary>
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
