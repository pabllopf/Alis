// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterCoverageGapTests.cs
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
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     Coverage gap tests for <see cref="AudioVideoWriter" /> targeting the
    ///     process kill path in <see cref="AudioVideoWriter.CloseWrite" />, the
    ///     <see cref="AudioVideoWriter.WriteFrame(AudioFrame)" /> happy path, the
    ///     pre-existing file deletion branch of <see cref="AudioVideoWriter.OpenWrite" />,
    ///     the <c>showFFmpegOutput</c> and <c>threadQueueSize</c> argument building,
    ///     and <see cref="AudioVideoWriter.Dispose" /> while a live process is running.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class AudioVideoWriterCoverageGapTests : IDisposable
    {
        /// <summary>
        ///     The temp dir
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The fake ffmpeg path
        /// </summary>
        private readonly string _fakeFfmpegPath;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioVideoWriterCoverageGapTests" /> class
        /// </summary>
        public AudioVideoWriterCoverageGapTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\n" +
                "port=$(printf '%s\\n' \"$@\" | sed -n 's/.*tcp:\\/\\/127\\.0\\.0\\.1:\\([0-9]*\\).*/\\1/p')\n" +
                "if [ -n \"$port\" ]; then\n" +
                "  exec 3<>/dev/tcp/127.0.0.1/$port\n" +
                "fi\n" +
                "exec sleep 30");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfmpegPath}\"");
            chmod.WaitForExit();
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
        ///     Creates the video options
        /// </summary>
        /// <returns>The options</returns>
        private static EncoderOptions CreateVideoOptions() => new EncoderOptions { Format = "matroska", EncoderName = "libx264", EncoderArguments = "-preset ultrafast" };

        /// <summary>
        ///     Creates the audio options
        /// </summary>
        /// <returns>The options</returns>
        private static EncoderOptions CreateAudioOptions() => new EncoderOptions { Format = "opus", EncoderName = "libopus", EncoderArguments = "-b:a 64k" };

        /// <summary>
        ///     Tests that OpenWrite in stream mode accepts both audio and video frames and CloseWrite kills the running process
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_StreamMode_WriteAudioAndVideoFrames_ShouldSucceedAndKillProcessOnClose()
        {
            using MemoryStream destination = new MemoryStream();
            using AudioVideoWriter writer = new AudioVideoWriter(destination, 16, 16, 30.0, 2, 44100, 16, CreateVideoOptions(), CreateAudioOptions(), _fakeFfmpegPath);

            writer.OpenWrite();

            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStreamVideo);
            Assert.NotNull(writer.InputDataStreamAudio);
            Assert.NotNull(writer.OutputDataStream);
            Process process = writer.CurrentFFmpegProcess;
            Assert.False(process.HasExited);

            using VideoFrame videoFrame = new VideoFrame(16, 16);
            writer.WriteFrame(videoFrame);

            using AudioFrame audioFrame = new AudioFrame(2, 1024, 16);
            writer.WriteFrame(audioFrame);

            writer.CloseWrite();

            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that OpenWrite in file mode deletes a pre-existing output file, accepts both frames and kills the running process on close
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_WithPreExistingFile_ShouldDeleteFileAndKillProcessOnClose()
        {
            string outFile = Path.Combine(_tempDir, Guid.NewGuid().ToString() + ".mp4");
            File.WriteAllBytes(outFile, new byte[] { 1, 2, 3 });

            using AudioVideoWriter writer = new AudioVideoWriter(outFile, 16, 16, 30.0, 2, 44100, 16, CreateVideoOptions(), CreateAudioOptions(), _fakeFfmpegPath);

            writer.OpenWrite();

            Assert.True(writer.OpenedForWriting);
            Assert.False(File.Exists(outFile));
            Assert.Null(writer.OutputDataStream);
            Assert.NotNull(writer.InputDataStreamAudio);
            Process process = writer.CurrentFFmpegProcess;
            Assert.False(process.HasExited);

            using VideoFrame videoFrame = new VideoFrame(16, 16);
            writer.WriteFrame(videoFrame);

            using AudioFrame audioFrame = new AudioFrame(2, 1024, 16);
            writer.WriteFrame(audioFrame);

            writer.CloseWrite();

            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
            Assert.False(File.Exists(outFile));
        }

        /// <summary>
        ///     Tests that OpenWrite with showFFmpegOutput and a custom thread queue size opens and closes correctly with 32 bit audio
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_StreamMode_WithShowOutputAndCustomQueueSize_ShouldOpenAndClose()
        {
            using MemoryStream destination = new MemoryStream();
            using AudioVideoWriter writer = new AudioVideoWriter(destination, 16, 16, 24.0, 1, 48000, 32, CreateVideoOptions(), CreateAudioOptions(), _fakeFfmpegPath);

            writer.OpenWrite(true, 8192);

            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Process process = writer.CurrentFFmpegProcess;

            writer.CloseWrite();

            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that Dispose while the writer is open closes the write and kills the running ffmpeg process
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhileOpen_StreamMode_ShouldCloseWriteAndKillProcess()
        {
            MemoryStream destination = new MemoryStream();
            AudioVideoWriter writer = new AudioVideoWriter(destination, 16, 16, 30.0, 2, 44100, 32, CreateVideoOptions(), CreateAudioOptions(), _fakeFfmpegPath);

            writer.OpenWrite();
            Process process = writer.CurrentFFmpegProcess;
            Assert.NotNull(process);
            Assert.True(writer.OpenedForWriting);

            writer.Dispose();

            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that WriteFrame in stream mode can be called repeatedly with alternating audio and video frames while open
        /// </summary>
        [RequireFfmpegFact]
        public void WriteFrame_StreamMode_MultipleAlternatingFrames_ShouldNotThrow()
        {
            using MemoryStream destination = new MemoryStream();
            using AudioVideoWriter writer = new AudioVideoWriter(destination, 16, 16, 30.0, 2, 44100, 24, CreateVideoOptions(), CreateAudioOptions(), _fakeFfmpegPath);

            writer.OpenWrite();
            Assert.True(writer.OpenedForWriting);

            using AudioFrame audioFrame = new AudioFrame(2, 1024, 24);
            writer.WriteFrame(audioFrame);

            using VideoFrame videoFrame = new VideoFrame(16, 16);
            writer.WriteFrame(videoFrame);
            writer.WriteFrame(videoFrame);
            writer.WriteFrame(audioFrame);

            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
            Assert.True(writer.CurrentFFmpegProcess.WaitForExit(5000));
        }
    }
}
