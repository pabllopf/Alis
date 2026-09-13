// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapperCoverageGapTests.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     Coverage gap tests for the FFMpegWrapper public surface
    /// </summary>
    public class FFMpegWrapperCoverageGapTests
    {
        /// <summary>
        /// The temporary directory path
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        /// The disposed flag
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="FFMpegWrapperCoverageGapTests"/> class
        /// </summary>
        public FFMpegWrapperCoverageGapTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "FFmpegGapTests_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
        }

        /// <summary>
        /// Gets the value indicating if the current platform is unix
        /// </summary>
        private static bool IsUnix => !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// Creates the executable script using the specified content
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="content">The content</param>
        /// <returns>The path</returns>
        private string CreateExecutableScript(string name, string content)
        {
            string path = Path.Combine(_tempDir, name);
            File.WriteAllText(path, "#!/bin/sh\n" + content + "\n");
            using Process chmod = Process.Start("chmod", $"+x \"{path}\"");
            chmod.WaitForExit();
            return path;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                try
                {
                    Directory.Delete(_tempDir, true);
                }
                catch (IOException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }

        /// <summary>
        /// Tests that get encoders parses video audio and subtitle entries
        /// </summary>
        [RequireFfmpegFact]
        public void GetEncoders_WithCleanFakeFfmpeg_ShouldParseAllMediaTypes()
        {
            string fake = CreateExecutableScript("fake_encoders",
                "printf ' V..... libx264         libx264 H.264 encoder\\n A..... aac            AAC encoder\\n S..... subrip         SubRip subtitle encoder\\n'");

            Dictionary<string, (string Description, MediaType Type)> encoders = FfMpegWrapper.GetEncoders(fake);

            Assert.Equal(3, encoders.Count);
            Assert.Equal(MediaType.Video, encoders["libx264"].Type);
            Assert.Equal(MediaType.Audio, encoders["aac"].Type);
            Assert.Equal(MediaType.Subtitle, encoders["subrip"].Type);
            Assert.Contains("H.264", encoders["libx264"].Description);
        }

        /// <summary>
        /// Tests that get encoders with empty output returns empty dictionary
        /// </summary>
        [RequireFfmpegFact]
        public void GetEncoders_WithEmptyFakeFfmpegOutput_ShouldReturnEmpty()
        {
            string fake = CreateExecutableScript("fake_encoders_empty", "printf ''");

            Dictionary<string, (string Description, MediaType Type)> encoders = FfMpegWrapper.GetEncoders(fake);

            Assert.NotNull(encoders);
            Assert.Empty(encoders);
        }

        /// <summary>
        /// Tests that get decoders parses video audio and subtitle entries
        /// </summary>
        [RequireFfmpegFact]
        public void GetDecoders_WithCleanFakeFfmpeg_ShouldParseAllMediaTypes()
        {
            string fake = CreateExecutableScript("fake_decoders",
                "printf ' V..... h264v4l2m2m     h264 v4l2m2m decoder\\n A..... mp3dec         MP3 decoder\\n S..... srt             SubRip decoder\\n'");

            Dictionary<string, (string Description, MediaType Type)> decoders = FfMpegWrapper.GetDecoders(fake);

            Assert.Equal(3, decoders.Count);
            Assert.Equal(MediaType.Video, decoders["h264v4l2m2m"].Type);
            Assert.Equal(MediaType.Audio, decoders["mp3dec"].Type);
            Assert.Equal(MediaType.Subtitle, decoders["srt"].Type);
            Assert.Contains("MP3", decoders["mp3dec"].Description);
        }

        /// <summary>
        /// Tests that run command captures standard error inside output
        /// </summary>
        [RequireFfmpegFact]
        public void RunCommand_WithStandardErrorOutput_ShouldContainErrorStreamContent()
        {
            string fake = CreateExecutableScript("fake_stderr", "echo 'diag_line' 1>&2");

            (string output, string error) = FfMpegWrapper.RunCommand(fake, "");

            Assert.Contains("diag_line", output);
            Assert.True(output.EndsWith("\n"));
        }

        /// <summary>
        /// Tests that run command without prettify avoids trailing newline
        /// </summary>
        [RequireFfmpegFact]
        public void RunCommand_WithPrettifyFalse_ShouldNotEndWithNewline()
        {
            string fake = CreateExecutableScript("fake_plain", "echo plain_line");

            (string output, string _) = FfMpegWrapper.RunCommand(fake, "", false);

            Assert.Contains("plain_line", output);
            Assert.False(output.EndsWith("\n"));
        }

        /// <summary>
        /// Tests that register progress tracker reports computed progress and clamps over one hundred percent
        /// </summary>
        [Fact]
        public void RegisterProgressTracker_WithDurationTen_ShouldReportTwentyFiveAndClampedHundred()
        {
            if (!IsUnix)
            {
                return;
            }

            string fake = CreateExecutableScript("fake_progress",
                "echo 'frame= 1 fps= 2.0 q=-0.5 size= 256kB time=00:00:02 bitrate= 100.0kbits/s' 1>&2\n" +
                "echo '' 1>&2\n" +
                "echo 'frame= 2 fps= 2.5 q=-0.4 size= 512kB time=00:10:05 bitrate= 100.0kbits/s' 1>&2");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fake,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using Process process = Process.Start(startInfo);
            Assert.NotNull(process);

            List<double> reported = new List<double>();
            CountdownEvent completed = new CountdownEvent(2);
            Progress<double> progress = FfMpegWrapper.RegisterProgressTracker(process, 10.0);
            progress.ProgressChanged += (sender, value) =>
            {
                lock (reported)
                {
                    reported.Add(value);
                }
                completed.Signal();
            };

            process.BeginErrorReadLine();
            Assert.True(completed.Wait(15000), "Progress reports were not delivered in time.");

            process.WaitForExit(15000);

            List<double> snapshot;
            lock (reported)
            {
                snapshot = new List<double>(reported);
            }
            Assert.Equal(2, snapshot.Count);
            Assert.Equal(20.0, snapshot.OrderBy(v => v).First(), 5);            Assert.Equal(100.0, snapshot.OrderBy(v => v).Last(), 5);
        }

        /// <summary>
        /// Tests that register progress tracker tolerates empty standard error stream
        /// </summary>
        [Fact]
        public void RegisterProgressTracker_WithNoErrorLines_ShouldNotReport()
        {
            if (!IsUnix)
            {
                return;
            }

            string fake = CreateExecutableScript("fake_silent_progress", "exit 0");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fake,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using Process process = Process.Start(startInfo);
            Assert.NotNull(process);
            process.BeginErrorReadLine();
            process.WaitForExit(15000);

            Progress<double> progress = FfMpegWrapper.RegisterProgressTracker(process, 10.0);

            Assert.NotNull(progress);
            Assert.Equal(0, process.ExitCode);
        }
    }
}
