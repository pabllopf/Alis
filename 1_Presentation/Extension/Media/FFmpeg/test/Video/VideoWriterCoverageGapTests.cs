// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriterCoverageGapTests.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     Unix process fact attribute class that skips on platforms without a POSIX shell and chmod helper binary.
    /// </summary>
    /// <seealso cref="FactAttribute" />
    public class UnixProcessFactAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnixProcessFactAttribute"/> class
        /// </summary>
        public UnixProcessFactAttribute()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Skip = "Test skipped because it requires a POSIX shell";
            }
        }
    }

    /// <summary>
    ///     Coverage gap tests for <see cref="VideoWriter"/> exercising OpenWrite and CloseWrite with a stub
    ///     ffmpeg executable so no real FFmpeg or avformat library is needed.
    /// </summary>
    public class VideoWriterCoverageGapTests : IDisposable
    {
        /// <summary>
        ///     The temp dir
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The lingering stub ffmpeg path
        /// </summary>
        private readonly string _lingeringStubPath;

        /// <summary>
        ///     The instant exit stub ffmpeg path
        /// </summary>
        private readonly string _instantExitStubPath;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoWriterCoverageGapTests"/> class
        /// </summary>
        public VideoWriterCoverageGapTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _lingeringStubPath = Path.Combine(_tempDir, "ffmpeg-linger");
            File.WriteAllText(_lingeringStubPath, "#!/bin/sh\nexec sleep 60");
            ChmodExecutable(_lingeringStubPath);

            _instantExitStubPath = Path.Combine(_tempDir, "ffmpeg-exit");
            File.WriteAllText(_instantExitStubPath, "#!/bin/sh\nexit 0");
            ChmodExecutable(_instantExitStubPath);
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
                    try
                    {
                        Directory.Delete(_tempDir, recursive: true);
                    }
                    catch (IOException)
                    {
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Marks the stub executable with executable permission bits using chmod
        /// </summary>
        /// <param name="path">The stub path</param>
        private static void ChmodExecutable(string path)
        {
            using Process chmod = Process.Start("chmod", $"+x \"{path}\"");
            chmod.WaitForExit(5000);
        }

        /// <summary>
        /// Tests that open write file mode with a stub ffmpeg opens for writing and creates the process
        /// </summary>
        [UnixProcessFact]
        public void OpenWrite_FileMode_LingeringStub_SetsOpenedForWriting()
        {
            string outFile = Path.Combine(_tempDir, "out1.mp4");
            using VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _lingeringStubPath);

            writer.OpenWrite();

            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);
            Assert.Null(writer.OutputDataStream);

            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that open write file mode deletes an existing output file before opening
        /// </summary>
        [UnixProcessFact]
        public void OpenWrite_FileMode_ExistingFile_IsDeleted()
        {
            string outFile = Path.Combine(_tempDir, "out2.mp4");
            File.WriteAllText(outFile, "dummy");
            using VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _instantExitStubPath);

            writer.OpenWrite();

            Assert.False(File.Exists(outFile));

            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that open write twice throws an invalid operation exception with the already opened message
        /// </summary>
        [UnixProcessFact]
        public void OpenWrite_Twice_ThrowsInvalidOperationException()
        {
            string outFile = Path.Combine(_tempDir, "out3.mp4");
            using VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _instantExitStubPath);

            writer.OpenWrite();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.OpenWrite());
            Assert.Contains("already opened for writing", ex.Message);

            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that open write stream mode sets the output data stream
        /// </summary>
        [UnixProcessFact]
        public void OpenWrite_StreamMode_LingeringStub_SetsStreams()
        {
            using MemoryStream destinationStream = new MemoryStream();
            using VideoWriter writer = new VideoWriter(destinationStream, 64, 48, 30.0, null, _lingeringStubPath);

            writer.OpenWrite();

            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.InputDataStream);
            Assert.NotNull(writer.OutputDataStream);

            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that close write with a self exiting process completes and resets the flag
        /// </summary>
        [UnixProcessFact]
        public void CloseWrite_FileMode_SelfExitingProcess_ResetsFlag()
        {
            string outFile = Path.Combine(_tempDir, "out4.mp4");
            using VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _instantExitStubPath);

            writer.OpenWrite();
            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
            Assert.True(writer.CurrentFFmpegProcess.HasExited);
        }

        /// <summary>
        /// Tests that close write kills a still running process and disposes the output data stream in stream mode
        /// </summary>
        [UnixProcessFact]
        public void CloseWrite_StreamMode_LingeringProcess_KillsAndDisposesOutput()
        {
            using MemoryStream destinationStream = new MemoryStream();
            using VideoWriter writer = new VideoWriter(destinationStream, 64, 48, 30.0, null, _lingeringStubPath);

            writer.OpenWrite();
            Stream outputStream = writer.OutputDataStream;
            Assert.NotNull(outputStream);

            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
            Assert.True(writer.CurrentFFmpegProcess.HasExited);
            Assert.Throws<ObjectDisposedException>(() => outputStream.ReadByte());
        }

        /// <summary>
        /// Tests that close write in file mode does not dispose the output data stream
        /// </summary>
        [UnixProcessFact]
        public void CloseWrite_FileMode_LingeringProcess_KillsAndKeepsOutputStreamNull()
        {
            string outFile = Path.Combine(_tempDir, "out5.mp4");
            using VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _lingeringStubPath);

            writer.OpenWrite();
            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
            Assert.Null(writer.OutputDataStream);
        }

        /// <summary>
        /// Tests that close write while an input pending write is open closes the input data stream
        /// </summary>
        [UnixProcessFact]
        public void CloseWrite_AfterWritingFrames_ClosesInputStream()
        {
            string outFile = Path.Combine(_tempDir, "out6.mp4");
            using VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _lingeringStubPath);

            writer.OpenWrite();
            Stream inputStream = writer.InputDataStream;
            Assert.NotNull(inputStream);

            writer.CloseWrite();

            Assert.Throws<ObjectDisposedException>(() => inputStream.WriteByte(0));
        }

        /// <summary>
        /// Tests that dispose while opened for writing closes the writer
        /// </summary>
        [UnixProcessFact]
        public void Dispose_FileMode_WhileOpen_CallsCloseWrite()
        {
            string outFile = Path.Combine(_tempDir, "out7.mp4");
            VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _instantExitStubPath);

            writer.OpenWrite();
            writer.Dispose();

            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that dispose in stream mode while open kills the process and closes the writer
        /// </summary>
        [UnixProcessFact]
        public void Dispose_StreamMode_WhileOpen_CallsCloseWrite()
        {
            using MemoryStream destinationStream = new MemoryStream();
            VideoWriter writer = new VideoWriter(destinationStream, 64, 48, 30.0, null, _lingeringStubPath);

            writer.OpenWrite();
            writer.Dispose();

            Assert.False(writer.OpenedForWriting);
            Assert.True(writer.CurrentFFmpegProcess.HasExited);
        }

        /// <summary>
        /// Tests that open write with show ffmpeg output flag succeeds in stream mode
        /// </summary>
        [UnixProcessFact]
        public void OpenWrite_StreamMode_WithShowOutput_SetsStreams()
        {
            using MemoryStream destinationStream = new MemoryStream();
            using VideoWriter writer = new VideoWriter(destinationStream, 64, 48, 30.0, null, _instantExitStubPath);

            writer.OpenWrite(showFFmpegOutput: true);

            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);

            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that close write after the process already exited completes without exceptions
        /// </summary>
        [UnixProcessFact]
        public void CloseWrite_FileMode_ProcessAlreadyExited_DoesNotThrow()
        {
            string outFile = Path.Combine(_tempDir, "out8.mp4");
            using VideoWriter writer = new VideoWriter(outFile, 64, 48, 30.0, null, _instantExitStubPath);

            writer.OpenWrite();
            writer.CurrentFFmpegProcess.WaitForExit(5000);

            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
        }
    }
}
