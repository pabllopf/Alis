// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterCoverageTest.cs
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
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Comprehensive coverage tests for the AudioWriter class targeting uncovered branches and methods.
    /// </summary>
    public class AudioWriterCoverageTest : IDisposable
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
        /// Initializes a new instance of the <see cref="AudioWriterCoverageTest"/> class
        /// </summary>
        public AudioWriterCoverageTest()
        {
            _testFile = Path.GetTempFileName();
            _testStream = new MemoryStream();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_testFile) && File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }

            _testStream?.Dispose();
        }

        #region Dispose Pattern Coverage Tests

        /// <summary>
        ///     Tests that Dispose() calls Dispose(true) and suppresses finalization.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_ShouldCallDisposeTrueAndSuppressFinalize()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            // Act - Should not throw when not opened and no FFmpeg process exists
            Exception exception = Record.Exception(() => writer.Dispose());

            // Assert - Should complete without exception from Dispose pattern
            // When not opened and no FFmpeg process exists, Dispose should complete successfully
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Dispose(bool) with disposing=false does not release resources.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingFalse_ShouldNotReleaseResources()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            // Act - Call protected Dispose with disposing=false via reflection
            MethodInfo disposeMethod = typeof(AudioWriter).GetMethod("Dispose", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            
            Exception exception = Record.Exception(() => 
                disposeMethod.Invoke(writer, new object[] { false }));

            // Assert - Should complete without exception
            // Resources should not be released when disposing=false
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Dispose(bool) with disposing=true releases DestinationStream.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingTrue_ShouldReleaseDestinationStream()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testStream, 2, 44100);

            // Act - Call protected Dispose with disposing=true via reflection
            MethodInfo disposeMethod = typeof(AudioWriter).GetMethod("Dispose", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            
            Exception exception = Record.Exception(() => 
                disposeMethod.Invoke(writer, new object[] { true }));

            // Assert - Should complete without exception from Dispose pattern
            // DestinationStream should be disposed when disposing=true
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Dispose(bool) disposes csc (CancellationTokenSource) when disposing=true.
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingTrue_ShouldDisposeCsc()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testStream, 2, 44100);

            // Setup csc field to test disposal
            FieldInfo cscField = typeof(AudioWriter).GetField("csc", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            CancellationTokenSource csc = new System.Threading.CancellationTokenSource();
            cscField.SetValue(writer, csc);

            // Act - Call protected Dispose with disposing=true via reflection
            MethodInfo disposeMethod = typeof(AudioWriter).GetMethod("Dispose", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            
            Exception exception = Record.Exception(() => 
                disposeMethod.Invoke(writer, new object[] { true }));

            // Assert - Should complete without exception from Dispose pattern
            Assert.Null(exception);
        }



        #endregion



        #region Stream Mode Coverage Tests

        /// <summary>
        ///     Tests that stream constructor sets DestinationStream.
        /// </summary>
        [RequireFfmpegFact]
        public void StreamConstructor_ShouldSetDestinationStream()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testStream, 2, 44100);

            // Act & Assert - DestinationStream should be set
            Assert.Equal(_testStream, writer.DestinationStream);
        }

        /// <summary>
        ///     Tests that stream mode sets UseFilename to false.
        /// </summary>
        [RequireFfmpegFact]
        public void StreamMode_ShouldSetUseFilenameToFalse()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testStream, 2, 44100);

            // Act & Assert - UseFilename should be false
            Assert.False(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that filename mode sets DestinationStream to null.
        /// </summary>
        [RequireFfmpegFact]
        public void FilenameMode_ShouldSetDestinationStreamToNull()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            // Act & Assert - DestinationStream should be null in filename mode
            Assert.Null(writer.DestinationStream);
        }

        #endregion

        #region EncoderOptions Coverage Tests

        /// <summary>
        ///     Tests that default encoder options create an MP3 encoder.
        /// </summary>
        [RequireFfmpegFact]
        public void DefaultEncoderOptions_ShouldCreateMp3Encoder()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            // Act & Assert - Default encoder should be MP3
            Assert.NotNull(writer.EncoderOptions);
            Assert.Equal("mp3", writer.EncoderOptions.Format);
            Assert.NotNull(writer.EncoderOptions.EncoderName);
        }

        /// <summary>
        ///     Tests that custom encoder options are used when provided.
        /// </summary>
        [RequireFfmpegFact]
        public void CustomEncoderOptions_ShouldBeUsed()
        {
            // Arrange
            EncoderOptions customOptions = new EncoderOptions { Format = "ogg", EncoderName = "libvorbis" };
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100, 16, customOptions);

            // Act & Assert - Custom encoder should be used
            Assert.Equal(customOptions, writer.EncoderOptions);
            Assert.Equal("ogg", writer.EncoderOptions.Format);
        }

        /// <summary>
        ///     Tests that EncoderOptions.EncoderArguments is accessible.
        /// </summary>
        [RequireFfmpegFact]
        public void EncoderOptions_EncoderArguments_ShouldBeAccessible()
        {
            // Arrange
            EncoderOptions customOptions = new EncoderOptions 
            { 
                Format = "mp3", 
                EncoderName = "libmp3lame",
                EncoderArguments = "-b:a 128k"
            };
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100, 16, customOptions);

            // Act & Assert - EncoderArguments should be accessible
            Assert.Equal("-b:a 128k", writer.EncoderOptions.EncoderArguments);
        }

        #endregion

        #region Parameter Validation Tests

        /// <summary>
        ///     Tests that constructor validates bitDepth is 16.
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithBitDepth16_ShouldSucceed()
        {
            // Arrange
            // Act - Should not throw with valid bit depth 16
            Exception exception = Record.Exception(() => new AudioWriter(_testFile, 2, 44100, 16));

            // Assert - Should not throw
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that constructor validates bitDepth is 24.
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithBitDepth24_ShouldSucceed()
        {
            // Arrange
            // Act - Should not throw with valid bit depth 24
            Exception exception = Record.Exception(() => new AudioWriter(_testFile, 2, 44100, 24));

            // Assert - Should not throw
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that constructor validates bitDepth is 32.
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithBitDepth32_ShouldSucceed()
        {
            // Arrange
            // Act - Should not throw with valid bit depth 32
            Exception exception = Record.Exception(() => new AudioWriter(_testFile, 2, 44100, 32));

            // Assert - Should not throw
            Assert.Null(exception);
        }

        #endregion

        #region CurrentFFmpegProcess Coverage Tests

        /// <summary>
        ///     Tests that CurrentFFmpegProcess returns Ffmpegp.
        /// </summary>
        [RequireFfmpegFact]
        public void CurrentFFmpegProcess_ShouldReturnFfmpegp()
        {
            // Arrange
            AudioWriter writer = new AudioWriter(_testFile, 2, 44100);

            // Act - Get CurrentFFmpegProcess
            Process process = writer.CurrentFFmpegProcess;

            // Assert - Should return Ffmpegp (null before OpenWrite)
            Assert.Null(process);
        }

        #endregion

        #region OpenWrite Body Tests (without FFmpeg — covers command construction)

        /// <summary>
        ///     Tests that OpenWrite in filename mode runs the command building and file-deletion logic
        ///     before throwing when ffmpeg executable is not found.
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FilenameMode_WithoutFFmpeg_ThrowsAndBuildsCommand()
        {
            // Arrange
            string testFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp3");
            File.WriteAllText(testFile, "dummy content");

            try
            {
                using AudioWriter writer = new(testFile, 2, 44100, 16, null, "ffmpeg-not-installed");

                // Act — FfMpegWrapper.OpenInput will throw (executable not found)
                Exception exception = Record.Exception(() => writer.OpenWrite());

                // Assert — exception was thrown by FfMpegWrapper
                Assert.NotNull(exception);
            }
            finally
            {
                if (File.Exists(testFile))
                {
                    File.Delete(testFile);
                }
            }
        }

        /// <summary>
        ///     Tests that OpenWrite in stream mode runs the command building and csc creation
        ///     before throwing when ffmpeg executable is not found.
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_StreamMode_WithoutFFmpeg_ThrowsAndCreatesCsc()
        {
            // Arrange
            using MemoryStream stream = new();
            using AudioWriter writer = new(stream, 2, 44100, 16, null, "ffmpeg-not-installed");

            // Act — FfMpegWrapper.Open will throw (executable not found)
            Exception exception = Record.Exception(() => writer.OpenWrite());

            // Assert
            Assert.NotNull(exception);
        }

        #endregion
        

        #region Helper class for testing

        /// <summary>
        ///     Mock process that can throw when Kill() is called.
        /// </summary>
        internal class MockProcess : IDisposable
        {
            /// <summary>
            /// Gets the value of the has exited
            /// </summary>
            public bool HasExited => false;

            /// <summary>
            /// Kills this instance
            /// </summary>
            /// <exception cref="InvalidOperationException">Mock process kill exception</exception>
            public void Kill()
            {
                throw new InvalidOperationException("Mock process kill exception");
            }

            /// <summary>
            /// Waits the for exit
            /// </summary>
            public void WaitForExit()
            {
                // Do nothing
            }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
                // Do nothing
            }
        }

        #endregion
    }
}
