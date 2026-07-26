using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    public class TestableVideoPlayer : VideoPlayer
    {
        public TestableVideoPlayer(string input = null, string ffplayExecutable = "ffplay") : base(input, ffplayExecutable)
        {
        }

        public void SetOpenedForWriting(bool value) => OpenedForWriting = value;

        public void SetInputDataStream(Stream value) => InputDataStream = value;
    }

    public class VideoPlayerFullCoverageTests : IDisposable
    {
        private readonly string _tempDir;
        private readonly string _fakeFfplayPath;
        private bool _disposed;

        public VideoPlayerFullCoverageTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfplayPath = Path.Combine(_tempDir, "ffplay");
            File.WriteAllText(_fakeFfplayPath, "#!/bin/bash\nexit 0");
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
        public void Constructor_Default_ShouldCreateInstance()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.NotNull(player);
        }

        [Fact]
        public void Constructor_WithFilename_ShouldSetFilename()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4");
            Assert.Equal("test.mp4", player.Filename);
        }

        [Fact]
        public void Constructor_DefaultFilename_ShouldBeNull()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.Null(player.Filename);
        }

        [Fact]
        public void Constructor_WithCustomFfplay_ShouldCreateInstance()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", "my-ffplay");
            Assert.NotNull(player);
        }

        [Fact]
        public void Dispose_MultipleTimes_ShouldNotThrow()
        {
            VideoPlayer player = new VideoPlayer();
            player.Dispose();
            player.Dispose();
            player.Dispose();
        }

        [Fact]
        public void Dispose_WhenNotOpenedForWriting_ShouldNotThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        [Fact]
        public void Play_WhenOpenedForWriting_ShouldThrow()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());
            Assert.Contains("opened for writing", ex.Message);
        }

        [Fact]
        public void Play_NoFilename_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());
            Assert.Contains("No filename was specified", ex.Message);
        }

        [Fact]
        public void Play_WithFilename_ShouldRunFfplay()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play());
            Assert.Null(ex);
        }

        [Fact]
        public void Play_WithExtraParameters_ShouldRunFfplay()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play("-ss 10"));
            Assert.Null(ex);
        }

        [Fact]
        public void PlayInBackground_WhenOpenedForWriting_ShouldThrow()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("opened for writing", ex.Message);
        }

        [Fact]
        public void PlayInBackground_NullFilename_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("No filename was specified", ex.Message);
        }

        [Fact]
        public void PlayInBackground_EmptyFilename_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer(string.Empty);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("No filename was specified", ex.Message);
        }

        [Fact]
        public void PlayInBackground_WithFilename_ShouldReturnProcess()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground();
            Assert.NotNull(process);
        }

        [Fact]
        public void PlayInBackground_WithPureBackground_ShouldNotThrow()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(runPureBackground: true);
            Assert.Null(process);
        }

        [Fact]
        public void PlayInBackground_WithExtraParameters_ShouldReturnProcess()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(extraInputParameters: "-ss 5");
            Assert.NotNull(process);
        }

        [Fact]
        public void OpenWrite_WhenOpenedForWriting_ShouldThrow()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(640, 480, "30"));
            Assert.Contains("opened for writing", ex.Message);
        }

        [Fact]
        public void OpenWrite_WithFakeFfplay_ShouldSetOpenedForWriting()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30");
            Assert.True(player.OpenedForWriting);
            Assert.NotNull(player.InputDataStream);
            player.CloseWrite();
            Assert.False(player.OpenedForWriting);
        }

        [Fact]
        public void OpenWrite_WithNonExistentFfplay_ShouldThrowWin32Exception()
        {
            using VideoPlayer player = new VideoPlayer(null, "ffplay-nonexistent");
            Win32Exception ex = Assert.Throws<Win32Exception>(
                () => player.OpenWrite(640, 480, "30"));
            Assert.NotNull(ex);
        }

        [Fact]
        public void OpenWrite_WithShowFFplayOutput_ShouldWork()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30", showFFplayOutput: true);
            Assert.True(player.OpenedForWriting);
            Assert.NotNull(player.InputDataStream);
            player.CloseWrite();
        }

        [Fact]
        public void CloseWrite_WhenNotOpened_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
        }

        [Fact]
        public void CloseWrite_WhenOpened_ShouldResetFlag()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30");
            Assert.True(player.OpenedForWriting);
            player.CloseWrite();
            Assert.False(player.OpenedForWriting);
        }

        [Fact]
        public void CloseWrite_WithNoProcess_ShouldResetFlag()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            MemoryStream ms = new MemoryStream();
            player.SetInputDataStream(ms);
            player.SetOpenedForWriting(true);
            Assert.True(player.OpenedForWriting);
            player.CloseWrite();
            Assert.False(player.OpenedForWriting);
        }

        [Fact]
        public void Dispose_WhenOpenedForWriting_ShouldCloseWrite()
        {
            TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30");
            Assert.True(player.OpenedForWriting);
            player.Dispose();
            Assert.False(player.OpenedForWriting);
        }

        [Fact]
        public void GetStreamForWriting_WithNonExistentFfplay_ShouldThrowWin32Exception()
        {
            Win32Exception ex = Assert.Throws<Win32Exception>(() =>
            {
                _ = VideoPlayer.GetStreamForWriting("rawvideo", "-video_size 640x480",
                    out _, false, "ffplay-nonexistent");
            });
            Assert.NotNull(ex);
        }

        [Fact]
        public void VideoPlayer_ShouldImplementIDisposable()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.IsAssignableFrom<IDisposable>(player);
        }

        [Fact]
        public void OpenWrite_WithExistingFfplayp_ShouldKillAndReopen()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30");
            player.SetOpenedForWriting(false);
            player.OpenWrite(320, 240, "15");
            Assert.True(player.OpenedForWriting);
            Assert.NotNull(player.InputDataStream);
            player.CloseWrite();
        }
    }
}
