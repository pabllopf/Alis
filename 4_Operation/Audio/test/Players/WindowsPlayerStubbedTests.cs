using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The windows player stubbed tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class WindowsPlayerStubbedTests : IDisposable
    {
        /// <summary>
        /// The temp file
        /// </summary>
        internal readonly string _tempFile;
        /// <summary>
        /// The player
        /// </summary>
        private WindowsPlayer _player;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsPlayerStubbedTests"/> class
        /// </summary>
        public WindowsPlayerStubbedTests()
        {
            _tempFile = Path.GetTempFileName();
            File.WriteAllText(_tempFile, "test content");
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _player?.Dispose();
            if (File.Exists(_tempFile)) File.Delete(_tempFile);
        }

        /// <summary>
        /// Creates the player
        /// </summary>
        /// <returns>The windows player</returns>
        private WindowsPlayer CreatePlayer() => new WindowsPlayer();

        /// <summary>
        /// Plays the with existing file should set playing true
        /// </summary>
        [WindowsOnly]
        public async Task Play_WithExistingFile_ShouldSetPlayingTrue()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);

            Assert.True(_player.Playing);
            Assert.False(_player.Paused);

            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(timerField?.GetValue(_player));
        }

        /// <summary>
        /// Plays the loop without loop with existing file should set playing true
        /// </summary>
        [WindowsOnly]
        public async Task PlayLoop_WithoutLoop_WithExistingFile_ShouldSetPlayingTrue()
        {
            _player = CreatePlayer();
            await _player.PlayLoop(_tempFile, false);

            Assert.True(_player.Playing);
            Assert.False(_player.Paused);
        }

        /// <summary>
        /// Plays the loop with loop with existing file should set playing true
        /// </summary>
        [WindowsOnly]
        public async Task PlayLoop_WithLoop_WithExistingFile_ShouldSetPlayingTrue()
        {
            _player = CreatePlayer();
            await _player.PlayLoop(_tempFile, true);

            Assert.True(_player.Playing);
            Assert.False(_player.Paused);
        }

        /// <summary>
        /// Pauses the when playing should set paused true
        /// </summary>
        [WindowsOnly]
        public async Task Pause_WhenPlaying_ShouldSetPausedTrue()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);
            Assert.True(_player.Playing);

            await _player.Pause();
            Assert.True(_player.Paused);
        }

        /// <summary>
        /// Resumes the when paused should set paused false
        /// </summary>
        [WindowsOnly]
        public async Task Resume_WhenPaused_ShouldSetPausedFalse()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);
            await _player.Pause();
            Assert.True(_player.Paused);

            await _player.Resume();
            Assert.False(_player.Paused);
            Assert.True(_player.Playing);
        }

        /// <summary>
        /// Stops the when playing should set playing false
        /// </summary>
        [WindowsOnly]
        public async Task Stop_WhenPlaying_ShouldSetPlayingFalse()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);
            Assert.True(_player.Playing);

            await _player.Stop();
            Assert.False(_player.Playing);
            Assert.False(_player.Paused);
        }

        /// <summary>
        /// Plays the pause resume stop sequence should work
        /// </summary>
        [WindowsOnly]
        public async Task Play_Pause_Resume_Stop_Sequence_ShouldWork()
        {
            _player = CreatePlayer();

            await _player.Play(_tempFile);
            Assert.True(_player.Playing);

            await _player.Pause();
            Assert.True(_player.Paused);

            await _player.Resume();
            Assert.False(_player.Paused);
            Assert.True(_player.Playing);

            await _player.Stop();
            Assert.False(_player.Playing);
            Assert.False(_player.Paused);
        }

        /// <summary>
        /// Sets the volume should not throw
        /// </summary>
        [WindowsOnly]
        public async Task SetVolume_ShouldNotThrow()
        {
            _player = CreatePlayer();
            await _player.SetVolume(0);
            await _player.SetVolume(50);
            await _player.SetVolume(100);
        }

        /// <summary>
        /// Plays the then dispose should work
        /// </summary>
        [WindowsOnly]
        public async Task Play_ThenDispose_ShouldWork()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);
            Assert.True(_player.Playing);

            _player.Dispose();
            Assert.NotNull(_player);
        }

        /// <summary>
        /// Multiples the pause resume should work
        /// </summary>
        [WindowsOnly]
        public async Task MultiplePauseResume_ShouldWork()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);

            for (int i = 0; i < 3; i++)
            {
                await _player.Pause();
                Assert.True(_player.Paused);
                await _player.Resume();
                Assert.False(_player.Paused);
                Assert.True(_player.Playing);
            }
        }

        /// <summary>
        /// Playbacks the finished should fire when timer elapses
        /// </summary>
        [WindowsOnly]
        public async Task PlaybackFinished_ShouldFireWhenTimerElapses()
        {
            _player = CreatePlayer();
            bool eventFired = false;
            _player.PlaybackFinished += (sender, e) => eventFired = true;

            await _player.Play(_tempFile);
            
            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Timer timer = (System.Timers.Timer)timerField?.GetValue(_player);
            Assert.NotNull(timer);

            MethodInfo handlerMethod = typeof(WindowsPlayer).GetMethod("HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            handlerMethod?.Invoke(_player, new object[] { null, null });

            Assert.False(_player.Playing);
            Assert.True(eventFired);
        }

        /// <summary>
        /// Executes the msi command with status command should set timer interval
        /// </summary>
        [WindowsOnly]
        public async Task ExecuteMsiCommand_WithStatusCommand_ShouldSetTimerInterval()
        {
            _player = CreatePlayer();
            
            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer",
                BindingFlags.NonPublic | BindingFlags.Instance);
            timerField?.SetValue(_player, new System.Timers.Timer(1) { AutoReset = false });

            MethodInfo execMethod = typeof(WindowsPlayer).GetMethod("ExecuteMsiCommand",
                BindingFlags.NonPublic | BindingFlags.Instance);
            execMethod?.Invoke(_player, new object[] { "Status test.wav Length" });

            Timer timer = (System.Timers.Timer)timerField?.GetValue(_player);
            Assert.Equal(5000, timer?.Interval);
        }

        /// <summary>
        /// Executes the msi command with error response should throw invalid operation exception
        /// </summary>
        [WindowsOnly]
        public void ExecuteMsiCommand_WithErrorResponse_ShouldThrowInvalidOperationException()
        {
            _player = CreatePlayer();

            MethodInfo execMethod = typeof(WindowsPlayer).GetMethod("ExecuteMsiCommand",
                BindingFlags.NonPublic | BindingFlags.Instance);
            if (execMethod != null)
            {
                InvalidOperationException ex = Assert.Throws<TargetInvocationException>(() =>
                    execMethod.Invoke(_player, new object[] { "FAIL test.wav" })
                ).GetBaseException() as InvalidOperationException;

                Assert.NotNull(ex);
                Assert.Contains("Error executing MCI command", ex.Message);
            }
        }

        /// <summary>
        /// Plays the loop with resource extraction should succeed
        /// </summary>
        [WindowsOnly]
        public async Task PlayLoop_WithResourceExtraction_ShouldSucceed()
        {
            string entryName = "res_loop_test_for_win.wav";
            byte[] wavBytes = new byte[100];
            wavBytes[0] = (byte)'R'; wavBytes[1] = (byte)'I'; wavBytes[2] = (byte)'F'; wavBytes[3] = (byte)'F';

            byte[] zipBytes;
            using (MemoryStream zipMs = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipMs, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                    using (Stream s = entry.Open()) s.Write(wavBytes, 0, wavBytes.Length);
                }
                zipBytes = zipMs.ToArray();
            }

            string assemblyName = "WinPlayerLoopResTest_" + Guid.NewGuid().ToString("N");
            string prevActive = AssetRegistryTestHelper.SaveAndSetActive(null);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
            AssetRegistryTestHelper.SaveAndSetActive(assemblyName);

            try
            {
                _player = CreatePlayer();
                await _player.PlayLoop(entryName, false);
                Assert.True(_player.Playing);
            }
            finally
            {
                AssetRegistryTestHelper.RestoreActive(prevActive);
            }
        }

        /// <summary>
        /// Plays the with resource extraction should succeed
        /// </summary>
        [WindowsOnly]
        public async Task Play_WithResourceExtraction_ShouldSucceed()
        {
            string entryName = "res_test_for_win.wav";
            byte[] wavBytes = new byte[100];
            wavBytes[0] = (byte)'R'; wavBytes[1] = (byte)'I'; wavBytes[2] = (byte)'F'; wavBytes[3] = (byte)'F';

            byte[] zipBytes;
            using (MemoryStream zipMs = new System.IO.MemoryStream())
            {
                using (ZipArchive archive = new System.IO.Compression.ZipArchive(zipMs, System.IO.Compression.ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry(entryName, System.IO.Compression.CompressionLevel.Optimal);
                    using (Stream s = entry.Open()) s.Write(wavBytes, 0, wavBytes.Length);
                }
                zipBytes = zipMs.ToArray();
            }

            string assemblyName = "WinPlayerResTest_" + Guid.NewGuid().ToString("N");
            string prevActive = AssetRegistryTestHelper.SaveAndSetActive(null);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
            AssetRegistryTestHelper.SaveAndSetActive(assemblyName);

            try
            {
                _player = CreatePlayer();
                await _player.Play(entryName);
                Assert.True(_player.Playing);
            }
            finally
            {
                AssetRegistryTestHelper.RestoreActive(prevActive);
            }
        }
    }
}
