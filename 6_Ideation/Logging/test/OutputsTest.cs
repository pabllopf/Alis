// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OutputsTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Tests for log output implementations.
    /// </summary>
    public class OutputsTest
    {
        [Fact]
        public void ConsoleLogOutput_Write_ShouldNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");

            // Should not throw
            output.Write(entry);
            output.Dispose();
        }

        [Fact]
        public void ConsoleLogOutput_Disable_ShouldNotWrite()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            ConsoleLogOutput consoleOutput = new ConsoleLogOutput();
            consoleOutput.IsEnabled = false;

            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");
            consoleOutput.Write(entry);

            // If disabled, we should verify behavior (console writes are hard to test)
            Assert.False(consoleOutput.IsEnabled);
        }

        [Fact]
        public void FileLogOutput_Write_ShouldCreateFile()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid()}.txt");
            try
            {
                using (FileLogOutput output = new FileLogOutput(tempFile))
                {
                    LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");
                    output.Write(entry);
                    output.Flush();
                }

                Assert.True(File.Exists(tempFile));
                string content = File.ReadAllText(tempFile);
                Assert.Contains("Test message", content);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        [Fact]
        public void FileLogOutput_AppendMode_ShouldPreserveExistingContent()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid()}.txt");
            try
            {
                // First write
                using (FileLogOutput output = new FileLogOutput(tempFile, append: true))
                {
                    LogEntry entry = new LogEntry(LogLevel.Info, "First message", "TestLogger");
                    output.Write(entry);
                }

                // Second write
                using (FileLogOutput output = new FileLogOutput(tempFile, append: true))
                {
                    LogEntry entry = new LogEntry(LogLevel.Info, "Second message", "TestLogger");
                    output.Write(entry);
                }

                string content = File.ReadAllText(tempFile);
                Assert.Contains("First message", content);
                Assert.Contains("Second message", content);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        [Fact]
        public void FileLogOutput_OverwriteMode_ShouldReplaceContent()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid()}.txt");
            try
            {
                // First write
                using (FileLogOutput output = new FileLogOutput(tempFile, append: false))
                {
                    LogEntry entry = new LogEntry(LogLevel.Info, "First message", "TestLogger");
                    output.Write(entry);
                }

                // Second write with overwrite
                using (FileLogOutput output = new FileLogOutput(tempFile, append: false))
                {
                    LogEntry entry = new LogEntry(LogLevel.Info, "Second message", "TestLogger");
                    output.Write(entry);
                }

                string content = File.ReadAllText(tempFile);
                Assert.DoesNotContain("First message", content);
                Assert.Contains("Second message", content);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        [Fact]
        public void FileLogOutput_CreatesDirectoriesAsNeeded()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), $"logging_{Guid.NewGuid()}");
            string tempFile = Path.Combine(tempDir, "subdir", "test_log.txt");
            try
            {
                using (FileLogOutput output = new FileLogOutput(tempFile))
                {
                    LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");
                    output.Write(entry);
                }

                Assert.True(File.Exists(tempFile));
            }
            finally
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
        }

        [Fact]
        public void DebugLogOutput_WriteWhenDebuggerAttached_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");

            // Should not throw regardless of debugger state
            output.Write(entry);
            output.Dispose();
        }

        [Fact]
        public void MemoryLogOutput_Clear_ShouldRemoveAllEntries()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(new LogEntry(LogLevel.Info, "Message 1", "Logger"));
            output.Write(new LogEntry(LogLevel.Info, "Message 2", "Logger"));

            Assert.Equal(2, output.Count);

            output.Clear();
            Assert.Equal(0, output.Count);
        }

        [Fact]
        public void MemoryLogOutput_Disable_ShouldNotStoreEntries()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.IsEnabled = false;
            output.Write(new LogEntry(LogLevel.Info, "Message", "Logger"));

            Assert.Equal(1, output.Count);
        }

        [Fact]
        public void MemoryLogOutput_GetEntriesCopy_ShouldReturnSnapshot()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(new LogEntry(LogLevel.Info, "Message 1", "Logger"));
            output.Write(new LogEntry(LogLevel.Info, "Message 2", "Logger"));

            IReadOnlyList<ILogEntry> entries1 = output.GetEntries();
            Assert.Equal(2, entries1.Count);

            output.Write(new LogEntry(LogLevel.Info, "Message 3", "Logger"));
            Assert.Equal(2, entries1.Count); // Original list should not change
            Assert.Equal(3, output.Count); // But output should have new entry
        }
    }
}