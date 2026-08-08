// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterRemainingCoverageTests.cs
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
using System.Threading;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="AudioVideoWriter" /> targeting
    ///     the still-uncovered code paths: Dispose(bool) with OpenedForWriting = true,
    ///     CloseWrite with non-null <see cref="Process" />, and constructor full
    ///     initialization with non-null <see cref="EncoderOptions" />.
    /// </summary>
    public class AudioVideoWriterRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The test file
        /// </summary>
        internal readonly string _testFile;
        /// <summary>
        /// The test stream
        /// </summary>
        internal readonly MemoryStream _testStream;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioVideoWriterRemainingCoverageTests" /> class.
        /// </summary>
        public AudioVideoWriterRemainingCoverageTests()
        {
            _testFile = Path.GetTempFileName();
            _testStream = new MemoryStream();
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_testFile) && File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }

            _testStream?.Dispose();
        }

        /// <summary>
        ///     Creates a <see cref="Process" /> that has already exited, suitable for
        ///     setting as <c>Ffmpegp</c> via reflection.
        /// </summary>
        private static Process CreateExitedProcess()
        {
            Process process = new Process();
            process.StartInfo.FileName = "dotnet";
            process.StartInfo.Arguments = "--version";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
            return process;
        }

        #region Constructor Full Initialization

        /// <summary>
        ///     Tests that the filename constructor assigns non-null <see cref="EncoderOptions" />
        ///     for both video and audio, ensuring the property assignment paths are exercised.
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_Filename_WithNonNullEncoderOptions_ShouldAssignProperties()
        {
            EncoderOptions videoOptions = new EncoderOptions { Format = "mp4", EncoderName = "libx264", EncoderArguments = "-preset fast" };
            EncoderOptions audioOptions = new EncoderOptions { Format = "aac", EncoderName = "aac", EncoderArguments = "-b:a 128k" };

            using AudioVideoWriter writer = new AudioVideoWriter(_testFile, 640, 480, 30.0, 2, 44100, 16, videoOptions, audioOptions);

            Assert.Equal(videoOptions, writer.VideoEncoderOptions);
            Assert.Equal(audioOptions, writer.AudioEncoderOptions);
            Assert.Equal(640, writer.VideoWidth);
            Assert.Equal(44100, writer.AudioSampleRate);
            Assert.True(writer.UseFilename);
            Assert.Equal(16, writer.AudioBitDepth);
        }

        /// <summary>
        ///     Tests that the stream constructor assigns non-null <see cref="EncoderOptions" />
        ///     for both video and audio, and correctly sets <c>UseFilename</c> to false.
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_Stream_WithNonNullEncoderOptions_ShouldAssignProperties()
        {
            EncoderOptions videoOptions = new EncoderOptions { Format = "mp4", EncoderName = "libx264" };
            EncoderOptions audioOptions = new EncoderOptions { Format = "aac", EncoderName = "aac" };

            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, videoOptions, audioOptions);

            Assert.Equal(videoOptions, writer.VideoEncoderOptions);
            Assert.Equal(audioOptions, writer.AudioEncoderOptions);
            Assert.False(writer.UseFilename);
            Assert.Same(_testStream, writer.DestinationStream);
        }

        /// <summary>
        ///     Tests that the stream constructor assigns null <see cref="EncoderOptions" />
        ///     correctly (regression check).
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_Stream_WithNullEncoderOptions_ShouldAssignNull()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            Assert.Null(writer.VideoEncoderOptions);
            Assert.Null(writer.AudioEncoderOptions);
        }

        #endregion

        #region CloseWrite With NonNull Process

        /// <summary>
        ///     Tests that <see cref="AudioVideoWriter.CloseWrite" /> succeeds when
        ///     <c>Ffmpegp</c> is a non-null, already-exited process in filename mode.
        ///     This covers:<br />
        ///     - <c>Ffmpegp.WaitForExit()</c> on a live process (line 370)<br />
        ///     - <c>Ffmpegp?.HasExited == false</c> evaluating to false (line 380, Kill skipped)<br />
        ///     - <c>!UseFilename</c> evaluating to false (line 373, OutputDataStream skipped)<br />
        ///     - The finally block setting <c>OpenedForWriting = false</c> (line 395)
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithExitedProcessAndFilenameMode_ShouldCompleteSuccessfully()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testFile, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Process process = CreateExitedProcess();
            FieldInfo processField = typeof(AudioVideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(writer, process);

            Exception exception = Record.Exception(() => writer.CloseWrite());

            Assert.Null(exception);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that <see cref="AudioVideoWriter.CloseWrite" /> succeeds when
        ///     <c>Ffmpegp</c> is a non-null, already-exited process in stream mode with
        ///     <c>OutputDataStream</c> set. This covers:<br />
        ///     - <c>!UseFilename</c> evaluating to true (line 373)<br />
        ///     - <c>OutputDataStream?.Dispose()</c> (line 375)
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithExitedProcessAndStreamMode_ShouldDisposeOutputDataStream()
        {
            using MemoryStream outputStream = new MemoryStream();
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Process process = CreateExitedProcess();
            FieldInfo processField = typeof(AudioVideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(writer, process);

            FieldInfo outputDataField = typeof(AudioVideoWriter).GetField("<OutputDataStream>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            outputDataField.SetValue(writer, outputStream);

            Exception exception = Record.Exception(() => writer.CloseWrite());

            Assert.Null(exception);
            Assert.False(writer.OpenedForWriting);
        }

        #endregion

        #region Dispose Full Path

        /// <summary>
        ///     Tests that <see cref="AudioVideoWriter.Dispose()" /> calls
        ///     <see cref="AudioVideoWriter.Dispose(bool)" /> with <c>disposing = true</c>,
        ///     enters the <c>OpenedForWriting</c> branch, successfully calls
        ///     <see cref="AudioVideoWriter.CloseWrite" /> (with non-null Ffmpegp), and
        ///     then disposes <c>DestinationStream</c> and <c>csc</c>.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithOpenedForWritingAndExitedProcess_ShouldCompleteSuccessfully()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Process process = CreateExitedProcess();
            FieldInfo processField = typeof(AudioVideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(writer, process);

            Exception exception = Record.Exception(() => writer.Dispose());

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that <see cref="AudioVideoWriter.Dispose()" /> with
        ///     <c>OpenedForWriting = true</c>, a non-null Ffmpegp, and a non-null
        ///     <c>csc</c> completes without exception, covering the
        ///     <c>csc?.Dispose()</c> branch (line 290).
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithOpenedForWritingNonNullCsc_ShouldDisposeCsc()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Process process = CreateExitedProcess();
            FieldInfo processField = typeof(AudioVideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(writer, process);

            FieldInfo cscField = typeof(AudioVideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);
            cscField.SetValue(writer, new CancellationTokenSource());

            Exception exception = Record.Exception(() => writer.Dispose());

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that <see cref="AudioVideoWriter.Dispose()" /> calls
        ///     <see cref="AudioVideoWriter.CloseWrite" /> via the
        ///     <c>OpenedForWriting = true</c> branch even in filename mode with a
        ///     non-null Ffmpegp.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithOpenedForWritingFilenameMode_ShouldCloseWriteSuccessfully()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testFile, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Process process = CreateExitedProcess();
            FieldInfo processField = typeof(AudioVideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(writer, process);

            Exception exception = Record.Exception(() => writer.Dispose());

            Assert.Null(exception);
        }

        #endregion
    }
}
