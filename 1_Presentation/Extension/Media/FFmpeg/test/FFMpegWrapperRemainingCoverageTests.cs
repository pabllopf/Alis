// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapperRemainingCoverageTests.cs
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

using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    /// The ff mpeg wrapper remaining coverage tests class
    /// </summary>
    public class FFMpegWrapperRemainingCoverageTests
    {
        /// <summary>
        /// Tests that run command hide banner false should execute
        /// </summary>
        [RequireFfmpegFact]
        public void RunCommand_HideBannerFalse_ShouldExecute()
        {
            Verbosity originalLog = FfMpegWrapper.LogLevel;
            bool originalBanner = FfMpegWrapper.HideFFmpegBanner;
            try
            {
                FfMpegWrapper.HideFFmpegBanner = false;
                string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "echo" : "/bin/echo";
                (string output, string _) = FfMpegWrapper.RunCommand(echoPath, "test_hide_banner_false");
                Assert.NotNull(output);
            }
            finally
            {
                FfMpegWrapper.HideFFmpegBanner = originalBanner;
                FfMpegWrapper.LogLevel = originalLog;
            }
        }

        /// <summary>
        /// Tests that execute command hide banner false should return process
        /// </summary>
        [RequireFfmpegFact]
        public void ExecuteCommand_HideBannerFalse_ShouldReturnProcess()
        {
            bool originalBanner = FfMpegWrapper.HideFFmpegBanner;
            try
            {
                FfMpegWrapper.HideFFmpegBanner = false;
                string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";
                Process process = FfMpegWrapper.ExecuteCommand(echoPath, "", true);
                Assert.NotNull(process);
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            finally
            {
                FfMpegWrapper.HideFFmpegBanner = originalBanner;
            }
        }

        /// <summary>
        /// Tests that open output hide banner false should return stream
        /// </summary>
        [RequireFfmpegFact]
        public void OpenOutput_HideBannerFalse_ShouldReturnStream()
        {
            bool originalBanner = FfMpegWrapper.HideFFmpegBanner;
            try
            {
                FfMpegWrapper.HideFFmpegBanner = false;
                string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";
                Stream stream = FfMpegWrapper.OpenOutput(echoPath, "", out Process process);
                Assert.NotNull(stream);
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            finally
            {
                FfMpegWrapper.HideFFmpegBanner = originalBanner;
            }
        }

        /// <summary>
        /// Tests that open input hide banner false should return stream
        /// </summary>
        [RequireFfmpegFact]
        public void OpenInput_HideBannerFalse_ShouldReturnStream()
        {
            bool originalBanner = FfMpegWrapper.HideFFmpegBanner;
            try
            {
                FfMpegWrapper.HideFFmpegBanner = false;
                string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";
                Stream stream = FfMpegWrapper.OpenInput(echoPath, "", out Process process);
                Assert.NotNull(stream);
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            finally
            {
                FfMpegWrapper.HideFFmpegBanner = originalBanner;
            }
        }

        /// <summary>
        /// Tests that open hide banner false should return streams
        /// </summary>
        [RequireFfmpegFact]
        public void Open_HideBannerFalse_ShouldReturnStreams()
        {
            bool originalBanner = FfMpegWrapper.HideFFmpegBanner;
            try
            {
                FfMpegWrapper.HideFFmpegBanner = false;
                string echoPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo";
                (Stream input, Stream output) = FfMpegWrapper.Open(echoPath, "", out Process process);
                Assert.NotNull(input);
                Assert.NotNull(output);
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            finally
            {
                FfMpegWrapper.HideFFmpegBanner = originalBanner;
            }
        }
    }
}
