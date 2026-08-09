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
