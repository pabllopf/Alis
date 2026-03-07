// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileLogOutputPlatformTest.cs
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
using System.IO;
using System.Threading.Tasks;
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
        /// <summary>
        ///     Files the log output windows long path name
        /// </summary>
        [WindowsOnly]
        public void FileLogOutput_Windows_LongPathName()
        {
            // Arrange
            string basePath = Path.Combine(Path.GetTempPath(), $"logging_windows_{Guid.NewGuid()}");
            string longPath = Path.Combine(basePath, "Very", "Deep", "Nested", "Directory", "Structure");
            string filePath = Path.Combine(longPath, "test.log");

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Windows long path test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));

            // Cleanup
            Cleanup(basePath);
        }

        /// <summary>
        ///     Files the log output windows file encoding
        /// </summary>
        [WindowsOnly]
        public void FileLogOutput_Windows_FileEncoding()
        {
            // Arrange
            string tempFile = Path.Combine(Path.GetTempPath(), $"log_{Guid.NewGuid()}.txt");
            string message = "Testing Windows file encoding with special chars: ñ, ü, ö";

            // Act
            using (FileLogOutput output = new FileLogOutput(tempFile))
            {
                output.Write(new LogEntry(LogLevel.Info, message, "Logger"));
            }

            // Assert
            Assert.True(File.Exists(tempFile));
            string content = File.ReadAllText(tempFile);
            Assert.Contains(message, content);

            // Cleanup
            File.Delete(tempFile);
        }

        /// <summary>
        ///     Files the log output linux unix permissions
        /// </summary>
        [LinuxOnly]
        public void FileLogOutput_Linux_UnixPermissions()
        {
            // Arrange
            string tempDir = Path.Combine(Path.GetTempPath(), $"logging_linux_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempDir);
            string filePath = Path.Combine(tempDir, "test.log");

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Linux test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));

            // Cleanup
            Cleanup(tempDir);
        }

        /// <summary>
        ///     Files the log output linux home directory path
        /// </summary>
        [LinuxOnly]
        public void FileLogOutput_Linux_HomeDirectoryPath()
        {
            // Arrange
            string homeDir = Environment.GetEnvironmentVariable("HOME");
            if (string.IsNullOrEmpty(homeDir))
            {
                homeDir = "/tmp";
            }

            string tempDir = Path.Combine(homeDir, $".test_logging_{Guid.NewGuid()}");
            string filePath = Path.Combine(tempDir, "test.log");

            // Act
            Directory.CreateDirectory(tempDir);
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Home directory test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));

            // Cleanup
            Cleanup(tempDir);
        }

        /// <summary>
        ///     Tests that file log output relative path should work across platforms
        /// </summary>
        [Fact]
        public void FileLogOutput_RelativePath_ShouldWorkAcrossPlatforms()
        {
            // Arrange
            string relativePath = Path.Combine(".", "test_logs", "app.log");
            string fullPath = Path.GetFullPath(relativePath);
            string dir = Path.GetDirectoryName(fullPath);

            // Act
            using (FileLogOutput output = new FileLogOutput(relativePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Relative path test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(fullPath));

            // Cleanup
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
        }

        /// <summary>
        ///     Files the log output windows drive letter
        /// </summary>
        [WindowsOnly]
        public void FileLogOutput_Windows_DriveLetter()
        {
            // Arrange
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            if (driveInfo.Length == 0)
            {
                return; // Skip if no drives
            }

            DriveInfo drive = driveInfo[0];
            string tempDir = Path.Combine(drive.Name, "Temp", $"logging_{Guid.NewGuid()}");
            string filePath = Path.Combine(tempDir, "test.log");

            try
            {
                // Act
                Directory.CreateDirectory(tempDir);
                using (FileLogOutput output = new FileLogOutput(filePath))
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

        /// <summary>
        ///     Tests that file log output concurrent access across platforms
        /// </summary>
        [Fact]
        public void FileLogOutput_ConcurrentAccessAcrossPlatforms()
        {
            // Arrange
            string tempDir = Path.Combine(Path.GetTempPath(), $"concurrent_{Guid.NewGuid()}");
            string filePath = Path.Combine(tempDir, "concurrent.log");
            Directory.CreateDirectory(tempDir);

            // Act
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                Task task = Task.Run(() =>
                {
                    using (FileLogOutput output = new FileLogOutput(filePath, append: true))
                    {
                        output.Write(new LogEntry(LogLevel.Info, "Concurrent test", "Logger"));
                    }
                });
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            // Assert
            Assert.True(File.Exists(filePath));
            string content = File.ReadAllText(filePath);
            Assert.NotEmpty(content);

            // Cleanup
            Cleanup(tempDir);
        }

        /// <summary>
        ///     Cleanups the path
        /// </summary>
        /// <param name="path">The path</param>
        private void Cleanup(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
    }
}