// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: PlatformSpecificTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Outputs;
using Alis.Core.Aspect.Logging.Test.Attributes;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Platform-specific behavior tests for the logging framework.
    ///     Tests different logging behavior across Windows, Linux, and macOS.
    /// </summary>
    public class PlatformSpecificTest
    {
        [WindowsOnly]
        public void Logging_Windows_PathWithBackslashes()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("Logger");

                var windowsPath = "C:\\Users\\TestUser\\Documents\\file.txt";

                // Act
                logger.LogInfo($"File path: {windowsPath}");

                // Assert
                var entry = memoryOutput.GetEntries()[0];
                Assert.Contains("\\", entry.Message);
            }
        }

        [LinuxOnly]
        public void Logging_Linux_PathWithForwardSlashes()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("Logger");

                var linuxPath = "/home/user/documents/file.txt";

                // Act
                logger.LogInfo($"File path: {linuxPath}");

                // Assert
                var entry = memoryOutput.GetEntries()[0];
                Assert.Contains("/", entry.Message);
            }
        }

        [Fact]
        public void Logging_CurrentPlatform_ShouldBeDetected()
        {
            // Act
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            var isOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            // Assert - Exactly one should be true
            var count = (isWindows ? 1 : 0) + (isLinux ? 1 : 0) + (isOSX ? 1 : 0);
            Assert.Equal(1, count);
        }

        [WindowsOnly]
        public void Logging_Windows_LineEndings()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("Logger");

                // Act
                logger.LogInfo("Line 1\nLine 2");

                // Assert
                var entry = memoryOutput.GetEntries()[0];
                Assert.Contains("\n", entry.Message);
            }
        }

        [LinuxOnly]
        public void Logging_Linux_Environment()
        {
            // Arrange
            var homeDir = Environment.GetEnvironmentVariable("HOME");

            // Assert
            Assert.NotNull(homeDir);
            Assert.True(homeDir.StartsWith("/"));
        }

        [Fact]
        public void Logging_AllPlatforms_DateTime()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("Logger");

                // Act
                logger.LogInfo("Test");
                var entry = memoryOutput.GetEntries()[0];

                // Assert - Timestamp should be valid
                Assert.True(entry.Timestamp.Year >= 2020);
                Assert.True(entry.Timestamp.Kind == DateTimeKind.Utc);
            }
        }

        [WindowsOnly]
        public void Logging_Windows_TempPath()
        {
            // Arrange
            var tempPath = Path.GetTempPath();

            // Assert
            Assert.NotEmpty(tempPath);
            Assert.True(Path.IsPathRooted(tempPath));
        }

        [Fact]
        public void Logging_ThreadInfo_ShouldBeValid()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("Logger");

                // Act
                logger.LogInfo("Test");
                var entry = memoryOutput.GetEntries()[0];

                // Assert
                Assert.True(entry.ThreadId > 0);
            }
        }

        [Fact]
        public void Logging_Unicode_AcrossAllPlatforms()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("Logger");

                var unicodeMessage = "Unicode: 你好 مرحبا Привет 🎮";

                // Act
                logger.LogInfo(unicodeMessage);

                // Assert
                var entry = memoryOutput.GetEntries()[0];
                Assert.Equal(unicodeMessage, entry.Message);
            }
        }

        [Fact]
        public void Logging_ProcessInfo_ShouldBeAvailable()
        {
            // Arrange
            var processId = System.Diagnostics.Process.GetCurrentProcess().Id;

            // Assert
            Assert.True(processId > 0);
        }

        [WindowsOnly]
        public void Logging_Windows_FileSystemCase()
        {
            // Note: Windows file system is case-insensitive

            // Arrange
            var tempDir = Path.GetTempPath();
            var path1 = Path.Combine(tempDir, "TestFile.txt");
            var path2 = Path.Combine(tempDir, "testfile.txt");

            // On Windows, these refer to the same file
            // This is informational - we don't create actual files
            Assert.Equal(path1, path2, StringComparer.OrdinalIgnoreCase);
        }

        [LinuxOnly]
        public void Logging_Linux_FileSystemCase()
        {
            // Note: Linux file system is case-sensitive

            // Arrange
            var tempDir = Path.GetTempPath();
            var path1 = Path.Combine(tempDir, "TestFile.txt");
            var path2 = Path.Combine(tempDir, "testfile.txt");

            // On Linux, these refer to different files
            Assert.NotEqual(path1, path2, StringComparer.Ordinal);
        }
    }
}

