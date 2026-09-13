// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoPlayerCoverageGapTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video player coverage gap tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoPlayerCoverageGapTests : IDisposable
    {
        /// <summary>
        ///     The temp dir
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The exit ffplay path
        /// </summary>
        private readonly string _exitFfplayPath;

        /// <summary>
        ///     The sleep ffplay path
        /// </summary>
        private readonly string _sleepFfplayPath;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoPlayerCoverageGapTests"/> class
        /// </summary>
        public VideoPlayerCoverageGapTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _exitFfplayPath = Path.Combine(_tempDir, "ffplay-exit");
            File.WriteAllText(_exitFfplayPath, "#!/bin/bash\nexit 0");
            using Process chmodExit = Process.Start("chmod", $"+x \"{_exitFfplayPath}\"");
            chmodExit.WaitForExit();

            _sleepFfplayPath = Path.Combine(_tempDir, "ffplay-sleep");
            File.WriteAllText(_sleepFfplayPath, "#!/bin/bash\nexec sleep 30");
            using Process chmodSleep = Process.Start("chmod", $"+x \"{_sleepFfplayPath}\"");
            chmodSleep.WaitForExit();
        }

        /// <summary>
        ///     Disposes this instance
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
        ///     Stops the process using the specified process
        /// </summary>
        /// <param name="process">The process</param>
        private static void StopProcess(Process process)
        {
            if (process == null)
            {
                return;
            }

            try
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    process.WaitForExit(5000);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        ///     Tests that play with filename runs the ffplay command and completes
        /// </summary>
        [UnixOnly]
        public void Play_WithFilename_RunsCommandAndCompletes()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _exitFfplayPath);

            Exception ex = Record.Exception(() => player.Play());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that play with extra input parameters runs the ffplay command and completes
        /// </summary>
        [UnixOnly]
        public void Play_WithExtraInputParameters_RunsCommandAndCompletes()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _exitFfplayPath);

            Exception ex = Record.Exception(() => player.Play("-ss 10"));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that play when opened for writing throws invalid operation exception
        /// </summary>
        [Fact]
        public void Play_WhenOpenedForWriting_ThrowsInvalidOperationException()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());

            Assert.Contains("already opened for writing", ex.Message);
        }

        /// <summary>
        ///     Tests that play with empty filename throws invalid operation exception
        /// </summary>
        [Fact]
        public void Play_WithEmptyFilename_ThrowsInvalidOperationException()
        {
            using VideoPlayer player = new VideoPlayer(string.Empty);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());

            Assert.Contains("No filename was specified", ex.Message);
        }

        /// <summary>
        ///     Tests that play in background with filename returns a running process
        /// </summary>
        [UnixOnly]
        public void PlayInBackground_WithFilename_ReturnsRunningProcess()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _sleepFfplayPath);
            Process process = null;
            try
            {
                process = player.PlayInBackground();

                Assert.NotNull(process);
                Assert.False(process.HasExited);
            }
            finally
            {
                StopProcess(process);
                player.Dispose();
            }
        }

        /// <summary>
        ///     Tests that play in background with pure background returns null and does not track the process
        /// </summary>
        [UnixOnly]
        public void PlayInBackground_WithPureBackground_ReturnsNullWithoutTracking()
        {
            using VideoPlayer player = new VideoPlayer("test.mp4", _exitFfplayPath);

            Process process = player.PlayInBackground(runPureBackground: true);

            Assert.Null(process);
        }

        /// <summary>
        ///     Tests that play in background with pure background skips the opened for writing guard
        /// </summary>
        [UnixOnly]
        public void PlayInBackground_WithPureBackground_SkipsOpenedForWritingGuard()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4", _exitFfplayPath);
            player.SetOpenedForWriting(true);

            Process process = player.PlayInBackground(runPureBackground: true);

            Assert.Null(process);
        }

        /// <summary>
        ///     Tests that play in background with extra input parameters returns a running process
        /// </summary>
        [UnixOnly]
        public void PlayInBackground_WithExtraInputParameters_ReturnsRunningProcess()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _sleepFfplayPath);
            Process process = null;
            try
            {
                process = player.PlayInBackground(extraInputParameters: "-ss 5");

                Assert.NotNull(process);
            }
            finally
            {
                StopProcess(process);
                player.Dispose();
            }
        }

        /// <summary>
        ///     Tests that open write with fake ffplay opens the input stream and sets the flag
        /// </summary>
        [UnixOnly]
        public void OpenWrite_WithFakeFfplay_OpensStreamAndSetsFlag()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _sleepFfplayPath);
            try
            {
                player.OpenWrite(640, 480, "30");

                Assert.True(player.OpenedForWriting);
                Assert.NotNull(player.InputDataStream);
                Assert.True(player.InputDataStream.CanWrite);
            }
            finally
            {
                if (player.OpenedForWriting)
                {
                    player.CloseWrite();
                }
            }
        }

        /// <summary>
        ///     Tests that open write with extra input parameters opens the input stream
        /// </summary>
        [UnixOnly]
        public void OpenWrite_WithExtraInputParameters_OpensStream()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _sleepFfplayPath);
            try
            {
                player.OpenWrite(320, 240, "15", "-loglevel quiet");

                Assert.True(player.OpenedForWriting);
                Assert.NotNull(player.InputDataStream);
            }
            finally
            {
                if (player.OpenedForWriting)
                {
                    player.CloseWrite();
                }
            }
        }

        /// <summary>
        ///     Tests that open write when opened for writing throws invalid operation exception
        /// </summary>
        [Fact]
        public void OpenWrite_WhenOpenedForWriting_ThrowsInvalidOperationException()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer("test.mp4");
            player.SetOpenedForWriting(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => player.OpenWrite(640, 480, "30"));

            Assert.Contains("already opened for writing", ex.Message);
        }

        /// <summary>
        ///     Tests that close write kills the running process and resets the flag
        /// </summary>
        [UnixOnly]
        public void CloseWrite_WithRunningProcess_KillsProcessAndResetsFlag()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _sleepFfplayPath);
            player.OpenWrite(8, 8, "30");

            Exception ex = Record.Exception(() => player.CloseWrite());

            Assert.Null(ex);
            Assert.False(player.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that close write disposes the input data stream
        /// </summary>
        [UnixOnly]
        public void CloseWrite_AfterOpen_DisposesInputDataStream()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _sleepFfplayPath);
            player.OpenWrite(8, 8, "30");
            Stream stream = player.InputDataStream;
            Assert.NotNull(stream);

            player.CloseWrite();

            Exception writeEx = Record.Exception(() => stream.Write(new byte[1], 0, 1));

            Assert.NotNull(writeEx);
        }

        /// <summary>
        ///     Tests that close write twice throws on the second call
        /// </summary>
        [UnixOnly]
        public void CloseWrite_SecondCall_ThrowsInvalidOperationException()
        {
            using TestableVideoPlayer player = new TestableVideoPlayer(null, _sleepFfplayPath);
            player.OpenWrite(8, 8, "30");
            player.CloseWrite();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.CloseWrite());

            Assert.Contains("not opened for writing", ex.Message);
        }

        /// <summary>
        ///     Tests that dispose when opened for writing closes the write and resets the flag
        /// </summary>
        [UnixOnly]
        public void Dispose_WhenOpenedForWriting_ClosesWriteAndResetsFlag()
        {
            TestableVideoPlayer player = new TestableVideoPlayer(null, _sleepFfplayPath);
            player.OpenWrite(8, 8, "30");
            Assert.True(player.OpenedForWriting);

            player.Dispose();

            Assert.False(player.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that dispose kills the tracked background process
        /// </summary>
        [UnixOnly]
        public void Dispose_WithTrackedBackgroundProcess_KillsProcess()
        {
            VideoPlayer player = new VideoPlayer("test.mp4", _sleepFfplayPath);
            Process process = player.PlayInBackground();
            Assert.NotNull(process);

            player.Dispose();

            Assert.True(process.WaitForExit(5000));
            Assert.True(process.HasExited);
        }

        /// <summary>
        ///     Tests that get stream for writing returns a writable stream with a fake ffplay
        /// </summary>
        [UnixOnly]
        public void GetStreamForWriting_WithFakeFfplay_ReturnsWritableStream()
        {
            Stream stream = null;
            Process process = null;
            try
            {
                stream = VideoPlayer.GetStreamForWriting("rawvideo", "-video_size 4x4", out process, false, _sleepFfplayPath);

                Assert.NotNull(stream);
                Assert.NotNull(process);
                Assert.True(stream.CanWrite);
            }
            finally
            {
                StopProcess(process);
                stream?.Dispose();
            }
        }

        /// <summary>
        ///     Tests that write frame when not opened for writing throws invalid operation exception
        /// </summary>
        [Fact]
        public void WriteFrame_WhenNotOpenedForWriting_ThrowsInvalidOperationException()
        {
            using VideoPlayer player = new VideoPlayer();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => player.WriteFrame(new VideoFrame(1, 1)));

            Assert.Contains("prepared for writing", ex.Message);
        }
    }
}
