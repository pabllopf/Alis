using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class WindowsPlayerStubbedTests : IDisposable
    {
        private readonly string _tempFile;
        private WindowsPlayer _player;

        public WindowsPlayerStubbedTests()
        {
            _tempFile = Path.GetTempFileName();
            File.WriteAllText(_tempFile, "test content");
        }

        public void Dispose()
        {
            _player?.Dispose();
            if (File.Exists(_tempFile)) File.Delete(_tempFile);
        }

        private WindowsPlayer CreatePlayer() => new WindowsPlayer();

        [Fact]
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

        [Fact]
        public async Task PlayLoop_WithoutLoop_WithExistingFile_ShouldSetPlayingTrue()
        {
            _player = CreatePlayer();
            await _player.PlayLoop(_tempFile, false);

            Assert.True(_player.Playing);
            Assert.False(_player.Paused);
        }

        [Fact]
        public async Task PlayLoop_WithLoop_WithExistingFile_ShouldSetPlayingTrue()
        {
            _player = CreatePlayer();
            await _player.PlayLoop(_tempFile, true);

            Assert.True(_player.Playing);
            Assert.False(_player.Paused);
        }

        [Fact]
        public async Task Pause_WhenPlaying_ShouldSetPausedTrue()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);
            Assert.True(_player.Playing);

            await _player.Pause();
            Assert.True(_player.Paused);
        }

        [Fact]
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

        [Fact]
        public async Task Stop_WhenPlaying_ShouldSetPlayingFalse()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);
            Assert.True(_player.Playing);

            await _player.Stop();
            Assert.False(_player.Playing);
            Assert.False(_player.Paused);
        }

        [Fact]
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

        [Fact]
        public async Task SetVolume_ShouldNotThrow()
        {
            _player = CreatePlayer();
            await _player.SetVolume(0);
            await _player.SetVolume(50);
            await _player.SetVolume(100);
        }

        [Fact]
        public async Task Play_ThenDispose_ShouldWork()
        {
            _player = CreatePlayer();
            await _player.Play(_tempFile);
            Assert.True(_player.Playing);

            _player.Dispose();
            Assert.NotNull(_player);
        }

        [Fact]
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

        [Fact]
        public async Task PlaybackFinished_ShouldFireWhenTimerElapses()
        {
            _player = CreatePlayer();
            bool eventFired = false;
            _player.PlaybackFinished += (sender, e) => eventFired = true;

            await _player.Play(_tempFile);
            
            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer",
                BindingFlags.NonPublic | BindingFlags.Instance);
            var timer = (System.Timers.Timer)timerField?.GetValue(_player);
            Assert.NotNull(timer);

            MethodInfo handlerMethod = typeof(WindowsPlayer).GetMethod("HandlePlaybackFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            handlerMethod?.Invoke(_player, new object[] { null, null });

            Assert.False(_player.Playing);
            Assert.True(eventFired);
        }

        [Fact]
        public async Task ExecuteMsiCommand_WithStatusCommand_ShouldSetTimerInterval()
        {
            _player = CreatePlayer();
            
            FieldInfo timerField = typeof(WindowsPlayer).GetField("_playbackTimer",
                BindingFlags.NonPublic | BindingFlags.Instance);
            timerField?.SetValue(_player, new System.Timers.Timer(1) { AutoReset = false });

            MethodInfo execMethod = typeof(WindowsPlayer).GetMethod("ExecuteMsiCommand",
                BindingFlags.NonPublic | BindingFlags.Instance);
            execMethod?.Invoke(_player, new object[] { "Status test.wav Length" });

            var timer = (System.Timers.Timer)timerField?.GetValue(_player);
            Assert.Equal(5000, timer?.Interval);
        }

        [Fact]
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

        [Fact]
        public async Task PlayLoop_WithResourceExtraction_ShouldSucceed()
        {
            string entryName = "res_loop_test_for_win.wav";
            byte[] wavBytes = new byte[100];
            wavBytes[0] = (byte)'R'; wavBytes[1] = (byte)'I'; wavBytes[2] = (byte)'F'; wavBytes[3] = (byte)'F';

            byte[] zipBytes;
            using (var zipMs = new MemoryStream())
            {
                using (var archive = new ZipArchive(zipMs, ZipArchiveMode.Create, true))
                {
                    var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                    using (var s = entry.Open()) s.Write(wavBytes, 0, wavBytes.Length);
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

        [Fact]
        public async Task Play_WithResourceExtraction_ShouldSucceed()
        {
            string entryName = "res_test_for_win.wav";
            byte[] wavBytes = new byte[100];
            wavBytes[0] = (byte)'R'; wavBytes[1] = (byte)'I'; wavBytes[2] = (byte)'F'; wavBytes[3] = (byte)'F';

            byte[] zipBytes;
            using (var zipMs = new System.IO.MemoryStream())
            {
                using (var archive = new System.IO.Compression.ZipArchive(zipMs, System.IO.Compression.ZipArchiveMode.Create, true))
                {
                    var entry = archive.CreateEntry(entryName, System.IO.Compression.CompressionLevel.Optimal);
                    using (var s = entry.Open()) s.Write(wavBytes, 0, wavBytes.Length);
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
