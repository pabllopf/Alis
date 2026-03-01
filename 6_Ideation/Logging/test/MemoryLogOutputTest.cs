// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryLogOutputTest.cs
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

using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the MemoryLogOutput class.
    ///     Validates in-memory log storage, retrieval, and thread safety.
    /// </summary>
    public class MemoryLogOutputTest
    {
        /// <summary>
        /// Tests that memory log output constructor default max entries
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Constructor_DefaultMaxEntries()
        {
            // Act
            MemoryLogOutput output = new MemoryLogOutput();

            // Assert
            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output write should store entry
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Write_ShouldStoreEntry()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            output.Write(entry);

            // Assert
            Assert.Single(output.GetEntries());
            Assert.Equal("Test", output.GetEntries()[0].Message);
        }

        /// <summary>
        /// Tests that memory log output multiple writes should store all
        /// </summary>
        [Fact]
        public void MemoryLogOutput_MultipleWrites_ShouldStoreAll()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();

            // Act
            for (int i = 0; i < 100; i++)
            {
                output.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            // Assert
            Assert.Equal(100, output.Count);
        }

        /// <summary>
        /// Tests that memory log output max entries should enforce limit
        /// </summary>
        [Fact]
        public void MemoryLogOutput_MaxEntries_ShouldEnforceLimit()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput(10);

            // Act
            for (int i = 0; i < 20; i++)
            {
                output.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            // Assert
            Assert.Equal(10, output.Count);
            // Oldest entries should be removed, keeping the last 10
            IReadOnlyList<ILogEntry> entries = output.GetEntries();
            Assert.Equal("Message 10", entries[0].Message);
            Assert.Equal("Message 19", entries[9].Message);
        }

        /// <summary>
        /// Tests that memory log output unlimited max entries should allow any
        /// </summary>
        [Fact]
        public void MemoryLogOutput_UnlimitedMaxEntries_ShouldAllowAny()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput(0);

            // Act
            for (int i = 0; i < 1000; i++)
            {
                output.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            // Assert
            Assert.Equal(1000, output.Count);
        }

        /// <summary>
        /// Tests that memory log output get entries should return snapshot
        /// </summary>
        [Fact]
        public void MemoryLogOutput_GetEntries_ShouldReturnSnapshot()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(new LogEntry(LogLevel.Info, "Message 1", "Logger"));
            IReadOnlyList<ILogEntry> entries1 = output.GetEntries();

            // Act
            output.Write(new LogEntry(LogLevel.Info, "Message 2", "Logger"));
            IReadOnlyList<ILogEntry> entries2 = output.GetEntries();

            // Assert
            Assert.Single(entries1);
            Assert.Equal(2, entries2.Count);
        }

        /// <summary>
        /// Tests that memory log output clear should remove all entries
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Clear_ShouldRemoveAllEntries()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(new LogEntry(LogLevel.Info, "Message 1", "Logger"));
            output.Write(new LogEntry(LogLevel.Info, "Message 2", "Logger"));
            Assert.Equal(2, output.Count);

            // Act
            output.Clear();

            // Assert
            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output null entry should not store
        /// </summary>
        [Fact]
        public void MemoryLogOutput_NullEntry_ShouldNotStore()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();

            // Act
            output.Write(null);

            // Assert
            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output disabled output should not store
        /// </summary>
        [Fact]
        public void MemoryLogOutput_DisabledOutput_ShouldNotStore()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            output.IsEnabled = false;

            // Act
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));

            // Assert
            Assert.Equal(1, output.Count);
        }

        /// <summary>
        /// Tests that memory log output flush should not affect entries
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Flush_ShouldNotAffectEntries()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));

            // Act
            output.Flush();

            // Assert
            Assert.Single(output.GetEntries());
        }

        /// <summary>
        /// Tests that memory log output dispose should clear entries
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Dispose_ShouldClearEntries()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));

            // Act
            output.Dispose();

            // Assert
            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output has name
        /// </summary>
        [Fact]
        public void MemoryLogOutput_HasName()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();

            // Act & Assert
            Assert.NotNull(output.Name);
            Assert.Equal("MemoryOutput", output.Name);
        }

        /// <summary>
        /// Tests that memory log output concurrent writes should be thread safe
        /// </summary>
        [Fact]
        public void MemoryLogOutput_ConcurrentWrites_ShouldBeThreadSafe()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput(0);
            Task[] tasks = new Task[10];

            // Act
            for (int t = 0; t < 10; t++)
            {
                int threadNum = t;
                tasks[t] = Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        output.Write(new LogEntry(LogLevel.Info, $"T{threadNum}-M{i}", "Logger"));
                    }
                });
            }

            Task.WaitAll(tasks);

            // Assert
            Assert.Equal(1000, output.Count);
        }

        /// <summary>
        /// Tests that memory log output is enabled can be toggled
        /// </summary>
        [Fact]
        public void MemoryLogOutput_IsEnabled_CanBeToggled()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();

            // Act & Assert
            output.IsEnabled = true;
            output.Write(new LogEntry(LogLevel.Info, "Test 1", "Logger"));

            output.IsEnabled = false;
            output.Write(new LogEntry(LogLevel.Info, "Test 2", "Logger"));

            output.IsEnabled = true;
            output.Write(new LogEntry(LogLevel.Info, "Test 3", "Logger"));
            Assert.Equal(3, output.GetEntries().Count);
        }

        /// <summary>
        /// Tests that memory log output max entries small should maintain fifo
        /// </summary>
        [Fact]
        public void MemoryLogOutput_MaxEntriesSmall_ShouldMaintainFifo()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput(3);

            // Act
            for (int i = 1; i <= 5; i++)
            {
                output.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            // Assert
            IReadOnlyList<ILogEntry> entries = output.GetEntries();
            Assert.Equal(3, entries.Count);
            Assert.Equal("Message 3", entries[0].Message);
            Assert.Equal("Message 4", entries[1].Message);
            Assert.Equal("Message 5", entries[2].Message);
        }

        /// <summary>
        /// Tests that memory log output after dispose should have no entries
        /// </summary>
        [Fact]
        public void MemoryLogOutput_AfterDispose_ShouldHaveNoEntries()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
            Assert.Equal(2, output.Count);

            // Act
            output.Dispose();
            output.Dispose(); // Second dispose should not throw

            // Assert
            Assert.Equal(0, output.Count);
        }
    }
}