using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The testable video player class
    /// </summary>
    /// <seealso cref="VideoPlayer"/>
    public class TestableVideoPlayer : VideoPlayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestableVideoPlayer"/> class
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="ffplayExecutable">The ffplay executable</param>
        public TestableVideoPlayer(string input = null, string ffplayExecutable = "ffplay") : base(input, ffplayExecutable)
        {
        }

        /// <summary>
        /// Sets the opened for writing using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetOpenedForWriting(bool value) => OpenedForWriting = value;

        /// <summary>
        /// Sets the input data stream using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetInputDataStream(Stream value) => InputDataStream = value;
    }

    /// <summary>
    /// The video player full coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoPlayerFullCoverageTests : IDisposable
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
        /// Initializes a new instance of the <see cref="VideoPlayerFullCoverageTests"/> class
        /// </summary>
        public VideoPlayerFullCoverageTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfplayPath = Path.Combine(_tempDir, "ffplay");
            File.WriteAllText(_fakeFfplayPath, "#!/bin/bash\nexit 0");
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
        /// Tests that constructor default should create instance
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_Default_ShouldCreateInstance()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that constructor with filename should set filename
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithFilename_ShouldSetFilename()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4");
            Assert.Equal("test.mp4", player.Filename);
        }

        /// <summary>
        /// Tests that constructor default filename should be null
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_DefaultFilename_ShouldBeNull()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.Null(player.Filename);
        }

        /// <summary>
        /// Tests that constructor with custom ffplay should create instance
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithCustomFfplay_ShouldCreateInstance()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", "my-ffplay");
            Assert.NotNull(player);
        }

        /// <summary>
        /// Tests that dispose multiple times should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_MultipleTimes_ShouldNotThrow()
        {
            VideoPlayer player = new VideoPlayer();
            player.Dispose();
            player.Dispose();
            player.Dispose();
        }

        /// <summary>
        /// Tests that dispose when not opened for writing should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenNotOpenedForWriting_ShouldNotThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that play when opened for writing should throw
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WhenOpenedForWriting_ShouldThrow()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());
            Assert.Contains("opened for writing", ex.Message);
        }

        /// <summary>
        /// Tests that play no filename should throw
        /// </summary>
        [RequireFfmpegFact]
        public void Play_NoFilename_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());
            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        /// Tests that play with filename should run ffplay
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WithFilename_ShouldRunFfplay()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that play with extra parameters should run ffplay
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WithExtraParameters_ShouldRunFfplay()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play("-ss 10"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that play in background when opened for writing should throw
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WhenOpenedForWriting_ShouldThrow()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("opened for writing", ex.Message);
        }

        /// <summary>
        /// Tests that play in background null filename should throw
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_NullFilename_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        /// Tests that play in background empty filename should throw
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_EmptyFilename_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer(string.Empty);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        /// Tests that play in background with filename should return process
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithFilename_ShouldReturnProcess()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground();
            Assert.NotNull(process);
        }

        /// <summary>
        /// Tests that play in background with pure background should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithPureBackground_ShouldNotThrow()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(runPureBackground: true);
            Assert.Null(process);
        }

        /// <summary>
        /// Tests that play in background with extra parameters should return process
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithExtraParameters_ShouldReturnProcess()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(extraInputParameters: "-ss 5");
            Assert.NotNull(process);
        }

        /// <summary>
        /// Tests that open write when opened for writing should throw
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WhenOpenedForWriting_ShouldThrow()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(640, 480, "30"));
            Assert.Contains("opened for writing", ex.Message);
        }

        /// <summary>
        /// Tests that open write with fake ffplay should set opened for writing
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithFakeFfplay_ShouldSetOpenedForWriting()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30");
            Assert.True(player.OpenedForWriting);
            Assert.NotNull(player.InputDataStream);
            player.CloseWrite();
            Assert.False(player.OpenedForWriting);
        }

        /// <summary>
        /// Tests that open write with non existent ffplay should throw win 32 exception
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithNonExistentFfplay_ShouldThrowWin32Exception()
        {
            using VideoPlayer player = new VideoPlayer(null, "ffplay-nonexistent");
            Win32Exception ex = Assert.Throws<Win32Exception>(
                () => player.OpenWrite(640, 480, "30"));
            Assert.NotNull(ex);
        }

        /// <summary>
        /// Tests that open write with show f fplay output should work
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithShowFFplayOutput_ShouldWork()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30", showFFplayOutput: true);
            Assert.True(player.OpenedForWriting);
            Assert.NotNull(player.InputDataStream);
            player.CloseWrite();
        }

        /// <summary>
        /// Tests that close write when not opened should throw
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WhenNotOpened_ShouldThrow()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
        }

        /// <summary>
        /// Tests that close write when opened should reset flag
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WhenOpened_ShouldResetFlag()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30");
            Assert.True(player.OpenedForWriting);
            player.CloseWrite();
            Assert.False(player.OpenedForWriting);
        }

        /// <summary>
        /// Tests that close write with no process should reset flag
        /// </summary>
        [RequireFfmpegFact]
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

        /// <summary>
        /// Tests that dispose when opened for writing should close write
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenOpenedForWriting_ShouldCloseWrite()
        {
            TestableVideoPlayer player = new TestableVideoPlayer(null, _fakeFfplayPath);
            player.OpenWrite(640, 480, "30");
            Assert.True(player.OpenedForWriting);
            player.Dispose();
            Assert.False(player.OpenedForWriting);
        }

        /// <summary>
        /// Tests that get stream for writing with non existent ffplay should throw win 32 exception
        /// </summary>
        [RequireFfmpegFact]
        public void GetStreamForWriting_WithNonExistentFfplay_ShouldThrowWin32Exception()
        {
            Win32Exception ex = Assert.Throws<Win32Exception>(() =>
            {
                _ = VideoPlayer.GetStreamForWriting("rawvideo", "-video_size 640x480",
                    out _, false, "ffplay-nonexistent");
            });
            Assert.NotNull(ex);
        }

        /// <summary>
        /// Tests that video player should implement i disposable
        /// </summary>
        [RequireFfmpegFact]
        public void VideoPlayer_ShouldImplementIDisposable()
        {
            using VideoPlayer player = new VideoPlayer();
            Assert.IsAssignableFrom<IDisposable>(player);
        }

        /// <summary>
        /// Tests that open write with existing ffplayp should kill and reopen
        /// </summary>
        [RequireFfmpegFact]
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
