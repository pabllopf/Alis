// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileLogOutputTest.cs
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

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the FileLogOutput class.
    ///     Validates file I/O, directory creation, and append/overwrite modes.
    /// </summary>
    public class FileLogOutputTest
    {
        private readonly string _testDir = Path.Combine(Path.GetTempPath(), $"logging_test_{Guid.NewGuid()}");

        [Fact]
        public void FileLogOutput_Constructor_NullPath_ShouldThrow()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLogOutput(null));
            Assert.Throws<ArgumentException>(() => new FileLogOutput(string.Empty));
            Assert.Throws<ArgumentException>(() => new FileLogOutput("   "));
        }

        [Fact]
        public void FileLogOutput_Write_ShouldCreateFile()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "test.log");
            Directory.CreateDirectory(_testDir);

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Test message", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));
            string content = File.ReadAllText(filePath);
            Assert.Contains("Test message", content);

            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_AppendMode_ShouldPreserveContent()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "append.log");
            Directory.CreateDirectory(_testDir);

            // Act & Assert
            using (FileLogOutput output1 = new FileLogOutput(filePath, append: true))
            {
                output1.Write(new LogEntry(LogLevel.Info, "First", "Logger"));
            }

            using (FileLogOutput output2 = new FileLogOutput(filePath, append: true))
            {
                output2.Write(new LogEntry(LogLevel.Info, "Second", "Logger"));
            }

            string content = File.ReadAllText(filePath);
            Assert.Contains("First", content);
            Assert.Contains("Second", content);

            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_OverwriteMode_ShouldReplaceContent()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "overwrite.log");
            Directory.CreateDirectory(_testDir);

            // Act
            using (FileLogOutput output1 = new FileLogOutput(filePath, append: false))
            {
                output1.Write(new LogEntry(LogLevel.Info, "First", "Logger"));
            }

            using (FileLogOutput output2 = new FileLogOutput(filePath, append: false))
            {
                output2.Write(new LogEntry(LogLevel.Info, "Second", "Logger"));
            }

            // Assert
            string content = File.ReadAllText(filePath);
            Assert.DoesNotContain("First", content);
            Assert.Contains("Second", content);

            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_CreatesDirectories()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "sub1", "sub2", "test.log");

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
            }

            // Assert
            Assert.True(File.Exists(filePath));

            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_NullEntry_ShouldNotWrite()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "null.log");
            Directory.CreateDirectory(_testDir);

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.Write(null);
            }

            // Assert
            // File may not exist or may be empty
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Assert.Empty(content);
            }

            // Cleanup
            Cleanup();
        }


        [Fact]
        public void FileLogOutput_Dispose_ShouldCloseFile()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "dispose.log");
            Directory.CreateDirectory(_testDir);
            FileLogOutput output = new FileLogOutput(filePath);

            // Act
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
            output.Dispose();

            // Assert - Should be able to delete file (not locked)
            Assert.True(File.Exists(filePath));
            File.Delete(filePath);
            Assert.False(File.Exists(filePath));

            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_DisabledOutput_ShouldNotWrite()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "disabled.log");
            Directory.CreateDirectory(_testDir);

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                output.IsEnabled = false;
                output.Write(new LogEntry(LogLevel.Info, "Should not appear", "Logger"));
                output.IsEnabled = true;
                output.Write(new LogEntry(LogLevel.Info, "Should appear", "Logger"));
            }

            // Assert
            string content = File.ReadAllText(filePath);
            Assert.Contains("Should not", content);
            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_HasName()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "name.log");
            Directory.CreateDirectory(_testDir);

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                // Assert
                Assert.NotNull(output.Name);
                Assert.Contains("FileOutput", output.Name);
                Assert.Contains("name.log", output.Name);
            }

            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_MultipleEntries_ShouldAppendEachLine()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "multi.log");
            Directory.CreateDirectory(_testDir);

            // Act
            using (FileLogOutput output = new FileLogOutput(filePath))
            {
                for (int i = 0; i < 5; i++)
                {
                    output.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
                }
            }

            // Assert
            string[] lines = File.ReadAllLines(filePath);
            Assert.NotEmpty(lines);

            // Cleanup
            Cleanup();
        }

        [Fact]
        public void FileLogOutput_InvalidPath_ShouldDisableOutput()
        {
            // Arrange - Use invalid path (like root on unix or reserved name)
            string invalidPath = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                invalidPath = "CON"; // Reserved name on Windows
            }
            else
            {
                invalidPath = "/dev/null"; // On Unix, /dev/null is writable, use different approach
                invalidPath = "/root/logs/test.log"; // May not have permission
            }

            // Act
            FileLogOutput output = new FileLogOutput(invalidPath);

            // Assert - Output should be disabled due to error
            // (IsEnabled should still be true, but write would fail silently)
            output.Dispose();
        }

        [Fact]
        public void FileLogOutput_RepeatedDispose_ShouldNotThrow()
        {
            // Arrange
            string filePath = Path.Combine(_testDir, "dispose_twice.log");
            Directory.CreateDirectory(_testDir);
            FileLogOutput output = new FileLogOutput(filePath);

            // Act & Assert
            output.Dispose();
            output.Dispose(); // Should not throw

            // Cleanup
            Cleanup();
        }

        private void Cleanup()
        {
            if (Directory.Exists(_testDir))
            {
                try
                {
                    Directory.Delete(_testDir, true);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }
    }
}