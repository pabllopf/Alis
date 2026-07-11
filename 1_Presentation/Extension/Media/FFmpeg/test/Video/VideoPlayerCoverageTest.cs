using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    public class VideoPlayerCoverageTest : IDisposable
    {
        private readonly string _tempDir;
        private readonly string _fakeFfplayPath;
        private bool _disposed;

        public VideoPlayerCoverageTest()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfplayPath = Path.Combine(_tempDir, "ffplay");
            File.WriteAllText(_fakeFfplayPath,
                "#!/bin/bash\nexit 0");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfplayPath}\"");
            chmod.WaitForExit();
        }

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

        [Fact]
        public void Dispose_WhenNotOpenedForWriting_WithFfplaypNull_ShouldNotThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        [Fact]
        public void Dispose_WhenNotOpenedForWriting_WithExitedFfplayp_ShouldNotThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);

            Process exitedProcess = new Process();
            exitedProcess.StartInfo.FileName = "/bin/echo";
            exitedProcess.StartInfo.Arguments = "test";
            exitedProcess.StartInfo.UseShellExecute = false;
            exitedProcess.Start();
            exitedProcess.WaitForExit();

            FieldInfo ffplaypField = typeof(VideoPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffplaypField.SetValue(player, exitedProcess);

            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        [Fact]
        public void Play_WhenOpenedForWriting_ShouldThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4");
            PropertyInfo openedProp = typeof(VideoPlayer).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { true });

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());
            Assert.Contains("opened for writing", ex.Message);

            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { false });
            player.Dispose();
        }

        [Fact]
        public void Play_WithFilename_UsesFfplay()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play());
            Assert.Null(ex);
            player.Dispose();
        }

        [Fact]
        public void Play_WithExtraParameters_UsesFfplay()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play("-ss 10"));
            Assert.Null(ex);
            player.Dispose();
        }

        [Fact]
        public void PlayInBackground_WhenOpenedForWriting_ShouldThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4");
            PropertyInfo openedProp = typeof(VideoPlayer).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { true });

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("opened for writing", ex.Message);

            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { false });
            player.Dispose();
        }

        [Fact]
        public void PlayInBackground_WithFilename_ReturnsProcess()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground();
            Assert.NotNull(process);
            player.Dispose();
        }

        [Fact]
        public void PlayInBackground_WithRunPureBackground_DoesNotAssignFfplayp()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(runPureBackground: true);

            FieldInfo ffplaypField = typeof(VideoPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Null(ffplaypField.GetValue(player));

            player.Dispose();
        }

        [Fact]
        public void PlayInBackground_WithExtraParameters_ReturnsProcess()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(extraInputParameters: "-ss 5");
            Assert.NotNull(process);
            player.Dispose();
        }

        [Fact]
        public void OpenWrite_WhenOpenedForWriting_ShouldThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4");
            PropertyInfo openedProp = typeof(VideoPlayer).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { true });

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(640, 480, "30"));
            Assert.Contains("opened for writing", ex.Message);

            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { false });
            player.Dispose();
        }

        [Fact]
        public void OpenWrite_WithFakeFfplay_ThrowsWin32Exception()
        {
            VideoPlayer player = new VideoPlayer(null, "ffplay-nonexistent");

            Win32Exception ex = Assert.Throws<Win32Exception>(
                () => player.OpenWrite(640, 480, "30"));

            Assert.NotNull(ex);
            player.Dispose();
        }

        [Fact]
        public void OpenWrite_WithShowFFplayOutput_ThrowsWin32Exception()
        {
            VideoPlayer player = new VideoPlayer(null, "ffplay-nonexistent");

            Win32Exception ex = Assert.Throws<Win32Exception>(
                () => player.OpenWrite(640, 480, "30", showFFplayOutput: true));

            Assert.NotNull(ex);
            player.Dispose();
        }

        [Fact]
        public void CloseWrite_WhenNotOpenedForWriting_ShouldThrow()
        {
            VideoPlayer player = new VideoPlayer();
            Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
            player.Dispose();
        }

        [Fact]
        public void CloseWrite_WhenOpened_ShouldResetFlag()
        {
            VideoPlayer player = new VideoPlayer(null, _fakeFfplayPath);

            PropertyInfo openedProp = typeof(VideoPlayer).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { true });

            PropertyInfo inputStreamProp = typeof(VideoPlayer).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { new MemoryStream() });

            player.CloseWrite();
            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        [Fact]
        public void GetStreamForWriting_WithFakeFfplay_ThrowsWin32Exception()
        {
            Win32Exception ex = Assert.Throws<Win32Exception>(() =>
            {
                _ = VideoPlayer.GetStreamForWriting("rawvideo", "-video_size 640x480",
                    out _, false, "ffplay-nonexistent");
            });
            Assert.NotNull(ex);
        }

        [Fact]
        public void Constructor_WithCustomFfplay_ShouldSetField()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", "my-ffplay");
            FieldInfo ffplayField = typeof(VideoPlayer).GetField("ffplay",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Equal("my-ffplay", ffplayField.GetValue(player));
            player.Dispose();
        }

        [Fact]
        public void Dispose_WhenOpenedForWriting_ShouldCallCloseWrite()
        {
            VideoPlayer player = new VideoPlayer(null, _fakeFfplayPath);

            PropertyInfo openedProp = typeof(VideoPlayer).GetProperty("OpenedForWriting",
                BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { true });

            PropertyInfo inputStreamProp = typeof(VideoPlayer).GetProperty("InputDataStream",
                BindingFlags.Public | BindingFlags.Instance);
            inputStreamProp.GetSetMethod(nonPublic: true).Invoke(player, new object[] { new MemoryStream() });

            player.Dispose();
            Assert.False(player.OpenedForWriting);
        }
    }
}
