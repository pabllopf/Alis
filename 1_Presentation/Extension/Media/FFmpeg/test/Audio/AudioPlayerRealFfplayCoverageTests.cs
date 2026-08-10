using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    /// The audio player real ffplay coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioPlayerRealFfplayCoverageTests : IDisposable
    {
        /// <summary>
        /// The stub ffplay
        /// </summary>
        private const string StubFfplay = "/tmp/ffplay_stub.sh";
        /// <summary>
        /// The player
        /// </summary>
        private AudioPlayer _player;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            try { _player?.Dispose(); } catch { }
        }

        /// <summary>
        /// Tests that play in background with valid executable returns process
        /// </summary>
        [UnixOnly]
        public void PlayInBackground_WithValidExecutable_ReturnsProcess()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            Process p = _player.PlayInBackground();

            Assert.NotNull(p);

            if (!p.HasExited) { p.Kill(); p.WaitForExit(1000); }
            p.Dispose();
        }

        /// <summary>
        /// Tests that play in background with run pure background returns null field
        /// </summary>
        [UnixOnly]
        public void PlayInBackground_WithRunPureBackground_ReturnsNullField()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            Process p = _player.PlayInBackground(runPureBackground: true);

            Assert.Null(p);
        }

        /// <summary>
        /// Tests that play in background with show window and extra params works
        /// </summary>
        [UnixOnly]
        public void PlayInBackground_WithShowWindowAndExtraParams_Works()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            Process p = _player.PlayInBackground("-probesize 32", showWindow: true);

            Assert.NotNull(p);

            if (!p.HasExited) { p.Kill(); p.WaitForExit(1000); }
            p.Dispose();
        }

        /// <summary>
        /// Tests that open write after play in background kills previous process
        /// </summary>
        [UnixOnly]
        public void OpenWrite_AfterPlayInBackground_KillsPreviousProcess()
        {
            AudioPlayer stubPlayer = new AudioPlayer("input.wav", StubFfplay);
            Process proc = stubPlayer.PlayInBackground();
            Assert.NotNull(proc);

            _player = new AudioPlayer(null, "ffplay-not-exists");
            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffplaypField?.SetValue(_player, proc);

            Win32Exception ex = Assert.Throws<Win32Exception>(() =>
                _player.OpenWrite(44100, 2, 16));
            Assert.NotNull(ex);

            stubPlayer.Dispose();
        }

        /// <summary>
        /// Tests that close write when not opened throws invalid operation exception
        /// </summary>
        [UnixOnly]
        public void CloseWrite_WhenNotOpened_ThrowsInvalidOperationException()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            _player.PlayInBackground();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _player.CloseWrite());
            Assert.Contains("not opened", ex.Message);
        }
    }
}
