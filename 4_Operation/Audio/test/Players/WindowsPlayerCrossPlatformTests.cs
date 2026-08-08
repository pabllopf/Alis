using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The windows player cross platform tests class
    /// </summary>
    public class WindowsPlayerCrossPlatformTests
    {
        /// <summary>
        /// Ises the winmm stub available
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsWinmmStubAvailable()
        {
            try
            {
                MethodInfo method = typeof(WindowsPlayer).GetMethod("ExecuteMsiCommand",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                if (method == null) return false;
                WindowsPlayer p = new WindowsPlayer();
                method.Invoke(p, new object[] { "Status test.wav Length" });
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tests that set volume should not throw when stub available
        /// </summary>
        [Fact]
        public async Task SetVolume_ShouldNotThrow_WhenStubAvailable()
        {
            if (!IsWinmmStubAvailable()) return;
            WindowsPlayer player = new WindowsPlayer();
            await player.SetVolume(50);
            await player.SetVolume(0);
            await player.SetVolume(100);
        }

        /// <summary>
        /// Tests that play with existing file should set up fields
        /// </summary>
        [Fact]
        public async Task Play_WithExistingFile_ShouldSetUpFields()
        {
            if (!IsWinmmStubAvailable()) return;
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "dummy content");
                WindowsPlayer player = new WindowsPlayer();
                await player.Play(tempFile);

                FieldInfo fileNameField = typeof(WindowsPlayer).GetField("_fileName",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                string storedFile = (string)fileNameField?.GetValue(player);
                Assert.Equal(tempFile, storedFile);

                Assert.True(player.Playing);
                Assert.False(player.Paused);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        /// <summary>
        /// Tests that play loop with existing file should set up fields
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithExistingFile_ShouldSetUpFields()
        {
            if (!IsWinmmStubAvailable()) return;
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "dummy content");
                WindowsPlayer player = new WindowsPlayer();
                await player.PlayLoop(tempFile, false);

                FieldInfo fileNameField = typeof(WindowsPlayer).GetField("_fileName",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                string storedFile = (string)fileNameField?.GetValue(player);
                Assert.Equal(tempFile, storedFile);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

      

        /// <summary>
        /// Tests that execute msi command with status should succeed
        /// </summary>
        [Fact]
        public void ExecuteMsiCommand_WithStatus_ShouldSucceed()
        {
            if (!IsWinmmStubAvailable()) return;
            WindowsPlayer player = new WindowsPlayer();
            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer",
                BindingFlags.NonPublic | BindingFlags.Instance);
            timerField?.SetValue(player, new System.Timers.Timer(1) { AutoReset = false });

            MethodInfo method = typeof(WindowsPlayer).GetMethod("ExecuteMsiCommand",
                BindingFlags.NonPublic | BindingFlags.Instance);
            method?.Invoke(player, new object[] { "Status test.wav Length" });

            Timer timer = (System.Timers.Timer)timerField?.GetValue(player);
            Assert.Equal(5000, timer?.Interval);
        }

        /// <summary>
        /// Tests that handle playback finished should fire event
        /// </summary>
        [Fact]
        public void HandlePlaybackFinished_ShouldFireEvent()
        {
            WindowsPlayer player = new WindowsPlayer();
            bool eventRaised = false;
            player.PlaybackFinished += (sender, e) => eventRaised = true;

            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer",
                BindingFlags.NonPublic | BindingFlags.Instance);
            timerField?.SetValue(player, new System.Timers.Timer(100) { AutoReset = false });

            MethodInfo method = typeof(WindowsPlayer).GetMethod("HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            if (method != null)
            {
                method.Invoke(player, new object[] { null, null });
            }

            Assert.False(player.Playing);
            Assert.True(eventRaised);
        }

        /// <summary>
        /// Tests that play with null file name should throw file not found exception
        /// </summary>
        [Fact]
        public async Task Play_WithNullFileName_ShouldThrowFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            await Assert.ThrowsAsync<FileNotFoundException>(() => player.Play(null));
        }

        /// <summary>
        /// Tests that play loop with null file name should throw file not found exception
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithNullFileName_ShouldThrowFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            await Assert.ThrowsAsync<FileNotFoundException>(() => player.PlayLoop(null, false));
        }
    }
}
