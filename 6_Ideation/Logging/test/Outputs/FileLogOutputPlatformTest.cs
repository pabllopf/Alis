// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Outputs/FileLogOutputPlatformTest.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Alis.Core.Aspect.Logging.Test.Attributes;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Outputs
{
    /// <summary>
    ///     Platform-specific tests for FileLogOutput.
    ///     Tests Windows and Unix/Linux specific file operations.
    /// </summary>
    public class FileLogOutputPlatformTest
    {
        [WindowsOnly]
        public void FileLogOutput_Windows_LongPathName()
        {
            // Arrange
            var basePath = Path.Combine(Path.GetTempPath(), $"logging_windows_{Guid.NewGuid()}");
            var longPath = Path.Combine(basePath, "Very", "Deep", "Nested", "Directory", "Structure");
            var filePath = Path.Combine(longPath, "test.log");

            // Act
            using (var output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Windows long path test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));

            // Cleanup
            Cleanup(basePath);
        }

        [WindowsOnly]
        public void FileLogOutput_Windows_FileEncoding()
        {
            // Arrange
            var tempFile = Path.Combine(Path.GetTempPath(), $"log_{Guid.NewGuid()}.txt");
            var message = "Testing Windows file encoding with special chars: ñ, ü, ö";

            // Act
            using (var output = new FileLogOutput(tempFile))
            {
                output.Write(new LogEntry(LogLevel.Info, message, "Logger"));
            }

            // Assert
            Assert.True(File.Exists(tempFile));
            var content = File.ReadAllText(tempFile);
            Assert.Contains(message, content);

            // Cleanup
            File.Delete(tempFile);
        }

        [LinuxOnly]
        public void FileLogOutput_Linux_UnixPermissions()
        {
            // Arrange
            var tempDir = Path.Combine(Path.GetTempPath(), $"logging_linux_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempDir);
            var filePath = Path.Combine(tempDir, "test.log");

            // Act
            using (var output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Linux test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));

            // Cleanup
            Cleanup(tempDir);
        }

        [LinuxOnly]
        public void FileLogOutput_Linux_HomeDirectoryPath()
        {
            // Arrange
            var homeDir = Environment.GetEnvironmentVariable("HOME");
            if (string.IsNullOrEmpty(homeDir))
            {
                homeDir = "/tmp";
            }

            var tempDir = Path.Combine(homeDir, $".test_logging_{Guid.NewGuid()}");
            var filePath = Path.Combine(tempDir, "test.log");

            // Act
            Directory.CreateDirectory(tempDir);
            using (var output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Home directory test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));

            // Cleanup
            Cleanup(tempDir);
        }

        [Fact]
        public void FileLogOutput_RelativePath_ShouldWorkAcrossPlatforms()
        {
            // Arrange
            var relativePath = Path.Combine(".", "test_logs", "app.log");
            var fullPath = Path.GetFullPath(relativePath);
            var dir = Path.GetDirectoryName(fullPath);

            // Act
            using (var output = new FileLogOutput(relativePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Relative path test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(fullPath));

            // Cleanup
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        [WindowsOnly]
        public void FileLogOutput_Windows_DriveLetter()
        {
            // Arrange
            var driveInfo = DriveInfo.GetDrives();
            if (driveInfo.Length == 0)
            {
                return; // Skip if no drives
            }

            var drive = driveInfo[0];
            var tempDir = Path.Combine(drive.Name, "Temp", $"logging_{Guid.NewGuid()}");
            var filePath = Path.Combine(tempDir, "test.log");

            try
            {
                // Act
                Directory.CreateDirectory(tempDir);
                using (var output = new FileLogOutput(filePath))
                {
                    output.Write(new LogEntry(LogLevel.Info, "Drive letter test", "Logger"));
                }

                // Assert
                Assert.True(File.Exists(filePath));

                // Cleanup
                Cleanup(tempDir);
            }
            catch (UnauthorizedAccessException)
            {
                // Skip if no permission
            }
        }

        [Fact]
        public void FileLogOutput_ConcurrentAccessAcrossPlatforms()
        {
            // Arrange
            var tempDir = Path.Combine(Path.GetTempPath(), $"concurrent_{Guid.NewGuid()}");
            var filePath = Path.Combine(tempDir, "concurrent.log");
            Directory.CreateDirectory(tempDir);

            // Act
            var tasks = new System.Collections.Generic.List<System.Threading.Tasks.Task>();
            for (int i = 0; i < 5; i++)
            {
                var task = System.Threading.Tasks.Task.Run(() =>
                {
                    using (var output = new FileLogOutput(filePath, append: true))
                    {
                        output.Write(new LogEntry(LogLevel.Info, "Concurrent test", "Logger"));
                    }
                });
                tasks.Add(task);
            }

            System.Threading.Tasks.Task.WaitAll(tasks.ToArray());

            // Assert
            Assert.True(File.Exists(filePath));
            var content = File.ReadAllText(filePath);
            Assert.NotEmpty(content);

            // Cleanup
            Cleanup(tempDir);
        }

        private void Cleanup(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, recursive: true);
                }
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
    }
}

