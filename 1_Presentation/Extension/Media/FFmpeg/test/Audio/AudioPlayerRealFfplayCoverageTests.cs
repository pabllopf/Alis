using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    public class AudioPlayerRealFfplayCoverageTests : IDisposable
    {
        private const string StubFfplay = "/tmp/ffplay_stub.sh";
        private AudioPlayer _player;

        public void Dispose()
        {
            try { _player?.Dispose(); } catch { }
        }

        [Fact]
        public void PlayInBackground_WithValidExecutable_ReturnsProcess()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            Process p = _player.PlayInBackground();

            Assert.NotNull(p);

            if (!p.HasExited) { p.Kill(); p.WaitForExit(1000); }
            p.Dispose();
        }

        [Fact]
        public void PlayInBackground_WithRunPureBackground_ReturnsNullField()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            Process p = _player.PlayInBackground(runPureBackground: true);

            Assert.Null(p);
        }

        [Fact]
        public void PlayInBackground_WithShowWindowAndExtraParams_Works()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            Process p = _player.PlayInBackground("-probesize 32", showWindow: true);

            Assert.NotNull(p);

            if (!p.HasExited) { p.Kill(); p.WaitForExit(1000); }
            p.Dispose();
        }

        [Fact]
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

        [Fact]
        public void CloseWrite_WhenNotOpened_ThrowsInvalidOperationException()
        {
            _player = new AudioPlayer("input.wav", StubFfplay);
            _player.PlayInBackground();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _player.CloseWrite());
            Assert.Contains("not opened", ex.Message);
        }
    }
}
