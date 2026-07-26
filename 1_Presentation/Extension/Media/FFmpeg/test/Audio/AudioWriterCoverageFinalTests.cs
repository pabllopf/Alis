// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterCoverageFinalTests.cs
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
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    public class AudioWriterCoverageFinalTests : IDisposable
    {
        private readonly string _tempDir;
        private readonly string _fakeFfmpegPath;
        private bool _disposed;

        public AudioWriterCoverageFinalTests()
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

        [RequireFfmpegFact]
        public void WriteFrame_WhenNotOpened_ShouldThrowInvalidOperationException()
        {
            using AudioWriter writer = new("output.mp3", 2, 44100);
            using AudioFrame frame = new(2, 1024, 16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.WriteFrame(frame));
            Assert.Contains("prepared for writing", ex.Message);
        }

        [RequireFfmpegFact]
        public void OpenWrite_FilenameMode_WhenFileDoesNotExist_ShouldSucceed()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");

            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);

            writer.CloseWrite();
        }

        [RequireFfmpegFact]
        public void Dispose_WhenOpenedForWritingFilenameMode_ShouldCloseWriteAndDispose()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);

            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);

            writer.Dispose();

            Assert.False(writer.OpenedForWriting);
        }

        [RequireFfmpegFact]
        public void Dispose_WhenOpenedForWritingStreamMode_ShouldCloseWriteAndDisposeDestination()
        {
            MemoryStream dest = new();
            AudioWriter writer = new(dest, 2, 44100, 16, null, _fakeFfmpegPath);

            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);

            writer.Dispose();

            Assert.False(writer.OpenedForWriting);
            Assert.Throws<ObjectDisposedException>(() => dest.WriteByte(0));
        }

        [RequireFfmpegFact]
        public void CloseWrite_WhenFfmpegpProcessExitsQuickly_ShouldNotKill()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new(testFile, 2, 44100, 16, null, _fakeFfmpegPath);

            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);

            Exception ex = Record.Exception(() => writer.CloseWrite());

            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
        }

        [RequireFfmpegFact]
        public void CloseWrite_WhenFfmpegpStillRunning_ShouldKillAndSucceed()
        {
            string sleepFfmpeg = Path.Combine(_tempDir, "ffmpeg_sleep");
            File.WriteAllText(sleepFfmpeg,
                "#!/bin/bash\nwhile [ \"$1\" ]; do shift; done\nexec sleep 10");
            using Process chmod2 = Process.Start("chmod", $"+x \"{sleepFfmpeg}\"");
            chmod2.WaitForExit();

            string testFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp3");
            using AudioWriter writer = new(testFile, 2, 44100, 16, null, sleepFfmpeg);

            writer.OpenWrite();
            Process process = writer.CurrentFFmpegProcess;
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            writer.CloseWrite();

            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
        }

        [RequireFfmpegFact]
        public void OpenWrite_StreamMode_WithShowFFmpegOutputTrue_ShouldSucceed()
        {
            using MemoryStream dest = new();
            using AudioWriter writer = new(dest, 2, 44100, 16, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite(showFFmpegOutput: true));

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.InputDataStream);
            Assert.NotNull(writer.OutputDataStream);

            writer.CloseWrite();
        }
    }
}
