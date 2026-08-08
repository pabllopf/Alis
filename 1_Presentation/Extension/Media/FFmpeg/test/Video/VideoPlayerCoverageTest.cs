using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The video player coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoPlayerCoverageTest : IDisposable
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
        /// Initializes a new instance of the <see cref="VideoPlayerCoverageTest"/> class
        /// </summary>
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
        /// Tests that dispose when not opened for writing with ffplayp null should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenNotOpenedForWriting_WithFfplaypNull_ShouldNotThrow()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose when not opened for writing with exited ffplayp should not throw
        /// </summary>
        [RequireFfmpegFact]
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

      
        /// <summary>
        /// Tests that play with filename uses ffplay
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WithFilename_UsesFfplay()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play());
            Assert.Null(ex);
            player.Dispose();
        }

        /// <summary>
        /// Tests that play with extra parameters uses ffplay
        /// </summary>
        [RequireFfmpegFact]
        public void Play_WithExtraParameters_UsesFfplay()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Exception ex = Record.Exception(() => player.Play("-ss 10"));
            Assert.Null(ex);
            player.Dispose();
        }

       

        /// <summary>
        /// Tests that play in background with filename returns process
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithFilename_ReturnsProcess()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground();
            Assert.NotNull(process);
            player.Dispose();
        }

        /// <summary>
        /// Tests that play in background with run pure background does not assign ffplayp
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithRunPureBackground_DoesNotAssignFfplayp()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(runPureBackground: true);

            FieldInfo ffplaypField = typeof(VideoPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Null(ffplaypField.GetValue(player));

            player.Dispose();
        }

        /// <summary>
        /// Tests that play in background with extra parameters returns process
        /// </summary>
        [RequireFfmpegFact]
        public void PlayInBackground_WithExtraParameters_ReturnsProcess()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _fakeFfplayPath);
            Process process = player.PlayInBackground(extraInputParameters: "-ss 5");
            Assert.NotNull(process);
            player.Dispose();
        }

   

        /// <summary>
        /// Tests that open write with fake ffplay throws win 32 exception
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithFakeFfplay_ThrowsWin32Exception()
        {
            VideoPlayer player = new VideoPlayer(null, "ffplay-nonexistent");

            Win32Exception ex = Assert.Throws<Win32Exception>(
                () => player.OpenWrite(640, 480, "30"));

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        /// Tests that open write with show f fplay output throws win 32 exception
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithShowFFplayOutput_ThrowsWin32Exception()
        {
            VideoPlayer player = new VideoPlayer(null, "ffplay-nonexistent");

            Win32Exception ex = Assert.Throws<Win32Exception>(
                () => player.OpenWrite(640, 480, "30", showFFplayOutput: true));

            Assert.NotNull(ex);
            player.Dispose();
        }

        /// <summary>
        /// Tests that close write when not opened for writing should throw
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WhenNotOpenedForWriting_ShouldThrow()
        {
            VideoPlayer player = new VideoPlayer();
            Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
            player.Dispose();
        }

  
        /// <summary>
        /// Tests that get stream for writing with fake ffplay throws win 32 exception
        /// </summary>
        [RequireFfmpegFact]
        public void GetStreamForWriting_WithFakeFfplay_ThrowsWin32Exception()
        {
            Win32Exception ex = Assert.Throws<Win32Exception>(() =>
            {
                _ = VideoPlayer.GetStreamForWriting("rawvideo", "-video_size 640x480",
                    out _, false, "ffplay-nonexistent");
            });
            Assert.NotNull(ex);
        }

        /// <summary>
        /// Tests that constructor with custom ffplay should set field
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithCustomFfplay_ShouldSetField()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", "my-ffplay");
            FieldInfo ffplayField = typeof(VideoPlayer).GetField("ffplay",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Equal("my-ffplay", ffplayField.GetValue(player));
            player.Dispose();
        }

     
    }
}
