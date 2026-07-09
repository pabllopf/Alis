// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterRemainingCoverageTests.cs
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
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Tests covering the remaining uncovered branches and lines in <see cref="AudioWriter" />.
    ///     Uses a fake ffmpeg executable to exercise the full OpenWrite / CloseWrite / Dispose paths
    ///     without requiring a real ffmpeg installation.
    /// </summary>
    public class AudioWriterRemainingCoverageTests : IDisposable
    {
        private readonly string _tempDir;
        private readonly string _fakeFfmpegPath;
        private bool _disposed;

        public AudioWriterRemainingCoverageTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\nwhile [ \"$1\" ]; do shift; done\nexec cat > /dev/null 2>/dev/null");

            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfmpegPath}\"");
            chmod.WaitForExit();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Directory.Exists(_tempDir))
                {
                    try
                    {
                        Directory.Delete(_tempDir, recursive: true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Fact]
        public void OpenWrite_FilenameMode_WithFakeFfmpeg_ShouldBuildCommandAndSetOpenedForWriting()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            File.WriteAllText(testFile, "dummy content to be deleted");

            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);
            Assert.False(File.Exists(testFile));

            writer.CloseWrite();
        }

        [Fact]
        public void OpenWrite_StreamMode_WithFakeFfmpeg_ShouldBuildCommandAndSetState()
        {
            using MemoryStream dest = new();
            using AudioWriter writer = new(dest, 2, 44100, 16, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);
            Assert.NotNull(writer.OutputDataStream);

            writer.CloseWrite();
        }

        [Fact]
        public void OpenWrite_AlreadyOpened_WithFakeFfmpeg_ShouldThrowInvalidOperationException()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            File.WriteAllText(testFile, "dummy");
            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.OpenWrite());

            Assert.Contains("already opened", ex.Message);

            writer.CloseWrite();
        }

        [Fact]
        public void CloseWrite_FilenameMode_WithFakeFfmpeg_ShouldCompleteWriteCycle()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);

            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
        }

        [Fact]
        public void CloseWrite_StreamMode_WithFakeFfmpeg_ShouldDisposeOutputDataStream()
        {
            using MemoryStream dest = new();
            using AudioWriter writer = new(dest, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);
            Stream outputStream = writer.OutputDataStream;
            Assert.NotNull(outputStream);

            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
            Assert.Throws<ObjectDisposedException>(() => outputStream.ReadByte());
        }

        [Fact]
        public void Dispose_WhenOpenedForWriting_FilenameMode_ShouldCallCloseWrite()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            File.WriteAllText(testFile, "dummy");
            AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);

            writer.Dispose();

            Assert.False(writer.OpenedForWriting);
        }

        [Fact]
        public void Dispose_WhenOpenedForWriting_StreamMode_ShouldCloseWriteAndDisposeResources()
        {
            MemoryStream dest = new();
            AudioWriter writer = new(dest, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);

            writer.Dispose();

            Assert.False(writer.OpenedForWriting);
            Assert.Throws<ObjectDisposedException>(() => dest.WriteByte(0));
        }

        [Fact]
        public void OpenWrite_WithShowFfmpegOutputTrue_ShouldNotThrow()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite(showFFmpegOutput: true));

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);

            writer.CloseWrite();
        }

        [Fact]
        public void WriteFrame_WhenOpenedForWriting_ShouldWriteToInputDataStream()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            using AudioFrame frame = new(2, 1024, 16);

            Exception ex = Record.Exception(() => writer.WriteFrame(frame));

            Assert.Null(ex);

            writer.CloseWrite();
        }

        [Fact]
        public void CurrentFFmpegProcess_AfterOpenWrite_ShouldNotBeNull()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();

            Process process = writer.CurrentFFmpegProcess;

            Assert.NotNull(process);
            Assert.False(process.HasExited);

            writer.CloseWrite();
        }

        [Fact]
        public void Dispose_WhenNotOpened_WithCustomEncoderOptions_ShouldSucceed()
        {
            EncoderOptions customOptions = new Mp3Encoder().Create();
            AudioWriter writer = new("output.mp3", 2, 44100, 16, customOptions);

            Exception ex = Record.Exception(() => writer.Dispose());

            Assert.Null(ex);
        }

        [Fact]
        public void Dispose_CalledMultipleTimes_AfterOpenWrite_ShouldNotThrow()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);
            writer.OpenWrite();
            writer.Dispose();

            Exception ex1 = Record.Exception(() => writer.Dispose());
            Exception ex2 = Record.Exception(() => writer.Dispose());

            Assert.Null(ex1);
            Assert.Null(ex2);
        }
    }
}
