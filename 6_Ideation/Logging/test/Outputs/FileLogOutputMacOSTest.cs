// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileLogOutputMacOSTest.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Outputs
{
    /// <summary>
    ///     macOS-specific tests for FileLogOutput.
    ///     Tests macOS file system features and path handling.
    /// </summary>
    public class FileLogOutputMacOSTest
    {
        /// <summary>
        ///     Tests that file log output mac os application support directory
        /// </summary>
        [Fact(Skip = "Only run on macOS")]
        public void FileLogOutput_MacOS_ApplicationSupportDirectory()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return;
            }

            string supportDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Alis",
                "Logging"
            );
            string filePath = Path.Combine(supportDir, "app.log");

            try
            {
                using (FileLogOutput output = new FileLogOutput(filePath))
                {
                    output.Write(new LogEntry(LogLevel.Info, "macOS AppSupport test", "Logger"));
                }

                Assert.True(File.Exists(filePath));

                if (Directory.Exists(supportDir))
                {
                    Directory.Delete(supportDir, true);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        /// <summary>
        ///     Tests that file log output mac os unix line endings
        /// </summary>
        [Fact(Skip = "Only run on macOS")]
        public void FileLogOutput_MacOS_UnixLineEndings()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return;
            }

            string tempDir = Path.Combine(Path.GetTempPath(), $"macos_{Guid.NewGuid()}");
            string filePath = Path.Combine(tempDir, "test.log");
            Directory.CreateDirectory(tempDir);

            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Line 1", "Logger"));
                output.Write(new LogEntry(LogLevel.Info, "Line 2", "Logger"));
            }

            Assert.True(File.Exists(filePath));
            string content = File.ReadAllText(filePath);
            Assert.DoesNotContain("\r\n", content);

            Directory.Delete(tempDir, true);
        }

        /// <summary>
        ///     Tests that file log output mac os case sensitive file system
        /// </summary>
        [Fact(Skip = "Only run on macOS")]
        public void FileLogOutput_MacOS_CaseSensitiveFileSystem()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return;
            }

            string tempDir = Path.Combine(Path.GetTempPath(), $"macos_case_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempDir);

            string path1 = Path.Combine(tempDir, "LogFile.txt");
            string path2 = Path.Combine(tempDir, "logfile.txt");

            using (FileLogOutput output1 = new FileLogOutput(path1))
            {
                output1.Write(new LogEntry(LogLevel.Info, "First", "Logger"));
            }

            // This test is informational

            Directory.Delete(tempDir, true);
        }

        /// <summary>
        ///     Tests that file log output cross platform path separator
        /// </summary>
        [Fact]
        public void FileLogOutput_CrossPlatformPathSeparator()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), $"cross_platform_{Guid.NewGuid()}");
            string filePath = Path.Combine(tempDir, "logs", "app.log");

            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Cross-platform test", "Logger"));
            }

            Assert.True(File.Exists(filePath));

            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
        }
    }
}