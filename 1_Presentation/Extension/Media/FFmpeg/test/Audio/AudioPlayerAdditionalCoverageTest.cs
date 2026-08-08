using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    /// The audio player additional coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioPlayerAdditionalCoverageTest : IDisposable
    {
        /// <summary>
        /// The temp dir
        /// </summary>
        private readonly string _tempDir;
        /// <summary>
        /// The fake ffplay path
        /// </summary>
        private readonly string _fakeFfplayPath;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioPlayerAdditionalCoverageTest"/> class
        /// </summary>
        public AudioPlayerAdditionalCoverageTest()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfplayPath = Path.Combine(_tempDir, "ffplay");
            File.WriteAllText(_fakeFfplayPath,
                "#!/bin/bash\nwhile [ \"$1\" ]; do shift; done\nexit 0");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfplayPath}\"");
            chmod.WaitForExit();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Directory.Exists(_tempDir))
                {
                    try { Directory.Delete(_tempDir, recursive: true); } catch { }
                }
            }
        }

        /// <summary>
        /// Tests that close write with running ffplayp kills process
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithRunningFfplayp_KillsProcess()
        {
            TestableAudioPlayer player = new TestableAudioPlayer(null, _fakeFfplayPath);
            player.SetOpenedForWriting(true);
            player.SetInputDataStream(new MemoryStream());

            Process process = new Process();
            process.StartInfo.FileName = "/bin/sleep";
            process.StartInfo.Arguments = "60";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffplaypField.SetValue(player, process);

            Assert.False(process.HasExited);

            player.CloseWrite();

            process.WaitForExit(2000);
            Assert.True(process.HasExited);
            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        /// Tests that get stream for writing with fake ffplay returns stream
        /// </summary>
        [RequireFfmpegFact]
        public void GetStreamForWriting_WithFakeFfplay_ReturnsStream()
        {
            Stream stream = AudioPlayer.GetStreamForWriting("s16le", "-channels 2 -sample_rate 44100",
                out Process process, false, _fakeFfplayPath);

            Assert.NotNull(stream);
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            process.Kill();
            process.Dispose();
        }

        /// <summary>
        /// Tests that get stream for writing with show f fplay output returns stream
        /// </summary>
        [RequireFfmpegFact]
        public void GetStreamForWriting_WithShowFFplayOutput_ReturnsStream()
        {
            Stream stream = AudioPlayer.GetStreamForWriting("s16le", "-channels 2 -sample_rate 44100",
                out Process process, true, _fakeFfplayPath);

            Assert.NotNull(stream);
            Assert.NotNull(process);

            process.Kill();
            process.Dispose();
        }

        /// <summary>
        /// Tests that play in background with run pure background does not assign ffplayp
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithRunPureBackground_DoesNotAssignFfplayp()
        {
            AudioPlayer player = new AudioPlayer("input.wav", _fakeFfplayPath);

            player.PlayInBackground(runPureBackground: true);

            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Null(ffplaypField.GetValue(player));

            player.Dispose();
        }

        /// <summary>
        /// Tests that play in background without pure background assigns ffplayp
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithoutPureBackground_AssignsFfplayp()
        {
            AudioPlayer player = new AudioPlayer("input.wav", _fakeFfplayPath);

            Process result = player.PlayInBackground(runPureBackground: false);

            Assert.NotNull(result);

            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(ffplaypField.GetValue(player));

            result.Kill();
            result.Dispose();
            player.Dispose();
        }

        /// <summary>
        /// Tests that play in background with extra params should work
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithExtraParams_ShouldWork()
        {
            AudioPlayer player = new AudioPlayer("input.wav", _fakeFfplayPath);

            Process result = player.PlayInBackground(extraInputParameters: "-probesize 32");

            Assert.NotNull(result);

            result.Kill();
            result.Dispose();
            player.Dispose();
        }

        /// <summary>
        /// Tests that play in background with show window true should work
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithShowWindowTrue_ShouldWork()
        {
            AudioPlayer player = new AudioPlayer("input.wav", _fakeFfplayPath);

            Process result = player.PlayInBackground(showWindow: true);

            Assert.NotNull(result);

            result.Kill();
            result.Dispose();
            player.Dispose();
        }

        /// <summary>
        /// Tests that play with show window true should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WithShowWindowTrue_ShouldNotThrow()
        {
            AudioPlayer player = new AudioPlayer("input.wav", _fakeFfplayPath);

            Exception ex = Record.Exception(() => player.Play(showWindow: true));

            Assert.Null(ex);
            player.Dispose();
        }

        /// <summary>
        /// Tests that play with extra parameters should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WithExtraParameters_ShouldNotThrow()
        {
            AudioPlayer player = new AudioPlayer("input.wav", _fakeFfplayPath);

            Exception ex = Record.Exception(() => player.Play("-probesize 32"));

            Assert.Null(ex);
            player.Dispose();
        }

        /// <summary>
        /// Tests that dispose when not opened for writing with running process kills it
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenNotOpenedForWriting_WithRunningProcess_KillsIt()
        {
            AudioPlayer player = new AudioPlayer(null, _fakeFfplayPath);

            Process process = new Process();
            process.StartInfo.FileName = "/bin/sleep";
            process.StartInfo.Arguments = "60";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffplaypField.SetValue(player, process);

            Assert.False(process.HasExited);
            player.Dispose();

            process.WaitForExit(2000);
            Assert.True(process.HasExited);
        }
    }
}
