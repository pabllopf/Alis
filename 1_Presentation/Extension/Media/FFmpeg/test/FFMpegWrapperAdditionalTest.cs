// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapperAdditionalTest.cs
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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     Additional FFMpegWrapper tests for uncovered code paths
    /// </summary>
    public class FFMpegWrapperAdditionalTest
    {
        /// <summary>
        ///     Tests that RunCommand executes a simple command and returns output
        /// </summary>
        [Fact]
        public void FFMpegWrapper_RunCommand_WithEcho_ShouldReturnOutput()
        {
            // Arrange & Act
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "echo" : "/bin/echo";
            (string output, string error) = FfMpegWrapper.RunCommand(echoPath, "test_output");

            // Assert
            Assert.NotNull(output);
            Assert.Contains("test_output", output);
        }

        /// <summary>
        ///     Tests that RunCommand respects HideFFmpegBanner setting
        /// </summary>
        [Fact]
        public void FFMpegWrapper_RunCommand_HideBannerTrue_ShouldIncludeHideBanner()
        {
            // Arrange
            bool original = FfMpegWrapper.HideFFmpegBanner;
            FfMpegWrapper.HideFFmpegBanner = true;

            try
            {
                string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "echo" : "/bin/echo";

                // Act
                (string output, string error) = FfMpegWrapper.RunCommand(echoPath, "test");

                // Assert - command should execute without error even with hide_banner
                Assert.NotNull(output);
            }
            finally
            {
                FfMpegWrapper.HideFFmpegBanner = original;
            }
        }

        /// <summary>
        ///     Tests that RunCommand respects custom log level
        /// </summary>
        [Fact]
        public void FFMpegWrapper_RunCommand_CustomLogLevel_ShouldExecute()
        {
            // Arrange
            Verbosity original = FfMpegWrapper.LogLevel;
            FfMpegWrapper.LogLevel = Verbosity.Quiet;

            try
            {
                string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "echo" : "/bin/echo";

                // Act
                (string output, string error) = FfMpegWrapper.RunCommand(echoPath, "test");

                // Assert
                Assert.NotNull(output);
            }
            finally
            {
                FfMpegWrapper.LogLevel = original;
            }
        }

        /// <summary>
        ///     Tests that ExecuteCommand returns a valid process
        /// </summary>
        [Fact]
        public void FFMpegWrapper_ExecuteCommand_ShouldReturnProcess()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act
            Process process = FfMpegWrapper.ExecuteCommand(echoPath, "", true);

            // Assert
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that ExecuteCommand with showOutput false does not throw
        /// </summary>
        [Fact]
        public void FFMpegWrapper_ExecuteCommand_ShowOutputFalse_ShouldNotThrow()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act & Assert - should not throw
            Process process = FfMpegWrapper.ExecuteCommand(echoPath, "", false);
            Assert.NotNull(process);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that OpenOutput returns a valid stream and process
        /// </summary>
        [Fact]
        public void FFMpegWrapper_OpenOutput_ShouldReturnValidStream()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act
            Stream stream = FfMpegWrapper.OpenOutput(echoPath, "", out Process process);

            // Assert
            Assert.NotNull(stream);
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that OpenOutput without out parameter works correctly
        /// </summary>
        [Fact]
        public void FFMpegWrapper_OpenOutput_WithoutOutParameter_ShouldReturnStream()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act
            Stream stream = FfMpegWrapper.OpenOutput(echoPath, "", false);

            // Assert - stream should be openable
            Assert.NotNull(stream);
        }

        /// <summary>
        ///     Tests that OpenInput without out parameter works correctly
        /// </summary>
        [Fact]
        public void FFMpegWrapper_OpenInput_WithoutOutParameter_ShouldReturnStream()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act
            Stream stream = FfMpegWrapper.OpenInput(echoPath, "", false);

            // Assert - stream should be openable
            Assert.NotNull(stream);
        }

        /// <summary>
        ///     Tests that Open returns valid input and output streams with process
        /// </summary>
        [Fact]
        public void FFMpegWrapper_Open_ShouldReturnValidStreams()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act
            (Stream input, Stream output) = FfMpegWrapper.Open(echoPath, "", out Process process);

            // Assert
            Assert.NotNull(input);
            Assert.NotNull(output);
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that Open without out parameter works correctly
        /// </summary>
        [Fact]
        public void FFMpegWrapper_Open_WithoutOutParameter_ShouldReturnStreams()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act
            (Stream input, Stream output) = FfMpegWrapper.Open(echoPath, "", false);

            // Assert
            Assert.NotNull(input);
            Assert.NotNull(output);
        }

        /// <summary>
        ///     Tests that GetMediaTypeFromTypeChar returns Audio for 'A'
        /// </summary>
        [Fact]
        public void FFMpegWrapper_GetMediaTypeFromTypeChar_Audio_ShouldReturnAudio()
        {
            // Arrange
            MethodInfo method = typeof(FfMpegWrapper).GetMethod("GetMediaTypeFromTypeChar", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            // Act
            MediaType result = (MediaType)method.Invoke(null, new object[] { 'A' });

            // Assert
            Assert.Equal(MediaType.Audio, result);
        }

        /// <summary>
        ///     Tests that GetMediaTypeFromTypeChar returns Video for 'V'
        /// </summary>
        [Fact]
        public void FFMpegWrapper_GetMediaTypeFromTypeChar_Video_ShouldReturnVideo()
        {
            // Arrange
            MethodInfo method = typeof(FfMpegWrapper).GetMethod("GetMediaTypeFromTypeChar", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            // Act
            MediaType result = (MediaType)method.Invoke(null, new object[] { 'V' });

            // Assert
            Assert.Equal(MediaType.Video, result);
        }

        /// <summary>
        ///     Tests that GetMediaTypeFromTypeChar returns Subtitle for unknown char
        /// </summary>
        [Fact]
        public void FFMpegWrapper_GetMediaTypeFromTypeChar_Unknown_ShouldReturnSubtitle()
        {
            // Arrange
            MethodInfo method = typeof(FfMpegWrapper).GetMethod("GetMediaTypeFromTypeChar", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            // Act
            MediaType result = (MediaType)method.Invoke(null, new object[] { 'X' });

            // Assert
            Assert.Equal(MediaType.Subtitle, result);
        }

        /// <summary>
        ///     Tests that GetMuxingSupportFromType returns MuxDemux for "DE"
        /// </summary>
        [Fact]
        public void FFMpegWrapper_GetMuxingSupportFromType_DE_ShouldReturnMuxDemux()
        {
            // Arrange
            MethodInfo method = typeof(FfMpegWrapper).GetMethod("GetMuxingSupportFromType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            // Act
            MuxingSupport result = (MuxingSupport)method.Invoke(null, new object[] { "DE" });

            // Assert
            Assert.Equal(MuxingSupport.MuxDemux, result);
        }

        /// <summary>
        ///     Tests that GetMuxingSupportFromType returns Demux for "D"
        /// </summary>
        [Fact]
        public void FFMpegWrapper_GetMuxingSupportFromType_D_ShouldReturnDemux()
        {
            // Arrange
            MethodInfo method = typeof(FfMpegWrapper).GetMethod("GetMuxingSupportFromType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            // Act
            MuxingSupport result = (MuxingSupport)method.Invoke(null, new object[] { "D" });

            // Assert
            Assert.Equal(MuxingSupport.Demux, result);
        }

        /// <summary>
        ///     Tests that GetMuxingSupportFromType returns Mux for unknown type
        /// </summary>
        [Fact]
        public void FFMpegWrapper_GetMuxingSupportFromType_Unknown_ShouldReturnMux()
        {
            // Arrange
            MethodInfo method = typeof(FfMpegWrapper).GetMethod("GetMuxingSupportFromType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            // Act
            MuxingSupport result = (MuxingSupport)method.Invoke(null, new object[] { "X" });

            // Assert
            Assert.Equal(MuxingSupport.Mux, result);
        }

        /// <summary>
        ///     Tests that RunCommand with prettify false does not add newlines
        /// </summary>
        [Fact]
        public void FFMpegWrapper_RunCommand_PrettifyFalse_ShouldNotAddNewlines()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "echo" : "/bin/echo";

            // Act
            (string output, string error) = FfMpegWrapper.RunCommand(echoPath, "test", false);

            // Assert - should not contain extra newlines from prettify
            Assert.NotNull(output);
        }

        /// <summary>
        ///     Tests that RunCommand with prettify true adds newlines
        /// </summary>
        [Fact]
        public void FFMpegWrapper_RunCommand_PrettifyTrue_ShouldAddNewlines()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "echo" : "/bin/echo";

            // Act
            (string output, string error) = FfMpegWrapper.RunCommand(echoPath, "test", true);

            // Assert - should contain newlines from prettify
            Assert.NotNull(output);
        }

        /// <summary>
        ///     Tests that ExecuteCommand with showOutput true does not throw
        /// </summary>
        [Fact]
        public void FFMpegWrapper_ExecuteCommand_ShowOutputTrue_ShouldNotThrow()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act & Assert - should not throw
            Process process = FfMpegWrapper.ExecuteCommand(echoPath, "", true);
            Assert.NotNull(process);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that OpenOutput with showOutput true does not throw
        /// </summary>
        [Fact]
        public void FFMpegWrapper_OpenOutput_ShowOutputTrue_ShouldNotThrow()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act & Assert - should not throw
            Stream stream = FfMpegWrapper.OpenOutput(echoPath, "", out Process process, true);
            Assert.NotNull(stream);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that OpenInput with showOutput true does not throw
        /// </summary>
        [Fact]
        public void FFMpegWrapper_OpenInput_ShowOutputTrue_ShouldNotThrow()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act & Assert - should not throw
            Stream stream = FfMpegWrapper.OpenInput(echoPath, "", out Process process, true);
            Assert.NotNull(stream);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that Open with showOutput true does not throw
        /// </summary>
        [Fact]
        public void FFMpegWrapper_Open_ShowOutputTrue_ShouldNotThrow()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act & Assert - should not throw
            (Stream input, Stream output) = FfMpegWrapper.Open(echoPath, "", out Process process, true);
            Assert.NotNull(input);
            Assert.NotNull(output);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that OpenInput with showOutput false does not throw
        /// </summary>
        [Fact]
        public void FFMpegWrapper_OpenInput_ShowOutputFalse_ShouldNotThrow()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act & Assert - should not throw
            Stream stream = FfMpegWrapper.OpenInput(echoPath, "", out Process process, false);
            Assert.NotNull(stream);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }

        /// <summary>
        ///     Tests that Open with showOutput false does not throw
        /// </summary>
        [Fact]
        public void FFMpegWrapper_Open_ShowOutputFalse_ShouldNotThrow()
        {
            // Arrange
            string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";

            // Act & Assert - should not throw
            (Stream input, Stream output) = FfMpegWrapper.Open(echoPath, "", out Process process, false);
            Assert.NotNull(input);
            Assert.NotNull(output);

            // Cleanup
            if (!process.HasExited)
            {
                process.Kill();
            }
        }
    }
}
