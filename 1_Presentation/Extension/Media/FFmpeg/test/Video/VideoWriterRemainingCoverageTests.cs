// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriterRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="VideoWriter"/> class targeting uncovered branches and methods.
    /// </summary>
    public class VideoWriterRemainingCoverageTests : IDisposable
    {
        /// <summary>
        ///     The test file path
        /// </summary>
        internal readonly string _testFile;

        /// <summary>
        ///     The test stream
        /// </summary>
        internal readonly MemoryStream _testStream;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoWriterRemainingCoverageTests"/> class
        /// </summary>
        public VideoWriterRemainingCoverageTests()
        {
            _testFile = Path.GetTempFileName();
            _testStream = new MemoryStream();
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_testFile) && File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }

            _testStream?.Dispose();
        }

        #region File Constructor Coverage

        /// <summary>
        ///     Tests that file constructor sets UseFilename to true.
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_ShouldSetUseFilenameToTrue()
        {
            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            Assert.True(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that file constructor sets Filename property.
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_ShouldSetFilename()
        {
            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            Assert.Equal(_testFile, writer.Filename);
        }

        /// <summary>
        ///     Tests that file constructor sets DestinationStream to null.
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_ShouldSetDestinationStreamToNull()
        {
            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            Assert.Null(writer.DestinationStream);
        }

        /// <summary>
        ///     Tests that file constructor with custom encoder options uses provided options.
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_WithCustomEncoderOptions_ShouldUseProvidedOptions()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "matroska",
                EncoderName = "libx265",
                EncoderArguments = "-preset fast"
            };

            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30, options);

            Assert.Equal("matroska", writer.EncoderOptions.Format);
            Assert.Equal("libx265", writer.EncoderOptions.EncoderName);
            Assert.Equal("-preset fast", writer.EncoderOptions.EncoderArguments);
        }

        /// <summary>
        ///     Tests that file constructor with custom ffmpeg executable sets private ffmpeg field.
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_WithCustomFfmpeg_ShouldSetFfmpegField()
        {
            VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30, null, "custom-ffmpeg");

            FieldInfo ffmpegField = typeof(VideoWriter).GetField("ffmpeg",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(ffmpegField);
            Assert.Equal("custom-ffmpeg", ffmpegField.GetValue(writer));
            writer.Dispose();
        }

        #endregion

        #region Stream Constructor Coverage

        /// <summary>
        ///     Tests that stream constructor sets UseFilename to false.
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_ShouldSetUseFilenameToFalse()
        {
            using VideoWriter writer = new VideoWriter(_testStream, 640, 480, 30);

            Assert.False(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that stream constructor with custom encoder options uses provided options.
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_WithCustomEncoderOptions_ShouldUseProvidedOptions()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            using VideoWriter writer = new VideoWriter(_testStream, 640, 480, 30, options);

            Assert.Equal("flv", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
            Assert.Equal("-crf 23", writer.EncoderOptions.EncoderArguments);
        }

        /// <summary>
        ///     Tests that stream constructor with custom ffmpeg executable sets private ffmpeg field.
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_WithCustomFfmpeg_ShouldSetFfmpegField()
        {
            VideoWriter writer = new VideoWriter(_testStream, 640, 480, 30, null, "my-ffmpeg");

            FieldInfo ffmpegField = typeof(VideoWriter).GetField("ffmpeg",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(ffmpegField);
            Assert.Equal("my-ffmpeg", ffmpegField.GetValue(writer));
            writer.Dispose();
        }

        /// <summary>
        ///     Tests that stream constructor sets DestinationStream to the provided stream.
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_ShouldSetDestinationStream()
        {
            using VideoWriter writer = new VideoWriter(_testStream, 640, 480, 30);

            Assert.Equal(_testStream, writer.DestinationStream);
        }

        #endregion

        #region Property Coverage

        /// <summary>
        ///     Tests that CurrentFFmpegProcess returns the Ffmpegp field (null before OpenWrite).
        /// </summary>
        [RequireFfmpegFact]
        public void CurrentFFmpegProcess_ShouldReturnFfmpegpValue()
        {
            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            Assert.Null(writer.CurrentFFmpegProcess);
        }

        /// <summary>
        ///     Tests that OutputDataStream is null initially.
        /// </summary>
        [RequireFfmpegFact]
        public void OutputDataStream_ShouldBeNullInitially()
        {
            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            Assert.Null(writer.OutputDataStream);
        }

        #endregion

        /// <summary>
        ///     Tests that Dispose() completes without exception.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_ShouldNotThrow()
        {
            VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            Exception exception = Record.Exception(() => writer.Dispose());

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Dispose(bool) with disposing=false does not release resources.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingFalse_ShouldNotThrow()
        {
            VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Exception exception = Record.Exception(() =>
                disposeMethod.Invoke(writer, new object[] { false }));

            Assert.Null(exception);
            writer.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose(bool) with disposing=true completes without exception.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingTrue_ShouldNotThrow()
        {
            VideoWriter writer = new VideoWriter(_testStream, 640, 480, 30);

            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Exception exception = Record.Exception(() =>
                disposeMethod.Invoke(writer, new object[] { true }));

            Assert.Null(exception);
            writer.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose(bool) with disposing=true disposes csc (CancellationTokenSource).
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingTrue_ShouldDisposeCsc()
        {
            VideoWriter writer = new VideoWriter(_testStream, 640, 480, 30);

            FieldInfo cscField = typeof(VideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);
            cscField.SetValue(writer, new CancellationTokenSource());

            MethodInfo disposeMethod = typeof(VideoWriter).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Exception exception = Record.Exception(() =>
                disposeMethod.Invoke(writer, new object[] { true }));

            Assert.Null(exception);
            writer.Dispose();
        }

        #region Internal Field Coverage

        /// <summary>
        ///     Tests that csc field is null initially.
        /// </summary>
        [RequireFfmpegFact]
        public void Csc_Field_ShouldBeNullInitially()
        {
            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            FieldInfo cscField = typeof(VideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Null(cscField.GetValue(writer));
        }

        /// <summary>
        ///     Tests that Ffmpegp field is null initially.
        /// </summary>
        [RequireFfmpegFact]
        public void Ffmpegp_Field_ShouldBeNullInitially()
        {
            using VideoWriter writer = new VideoWriter(_testFile, 640, 480, 30);

            FieldInfo ffmpegpField = typeof(VideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Null(ffmpegpField.GetValue(writer));
        }

        #endregion
    }
}
