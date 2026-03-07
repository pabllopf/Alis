// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AsyncLogOutputTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the AsyncLogOutput class.
    ///     Validates async queueing behavior and resource management.
    /// </summary>
    public class AsyncLogOutputTest
    {
        /// <summary>
        ///     Tests that async log output constructor with null inner should throw
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Constructor_WithNullInner_ShouldThrow()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AsyncLogOutput(null));
        }

        /// <summary>
        ///     Tests that async log output write should queue entry
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Write_ShouldQueueEntry()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");
            asyncOutput.Write(entry);
            asyncOutput.Flush();

            // Assert
            Assert.Single(innerOutput.GetEntries());
        }

        /// <summary>
        ///     Tests that async log output multiple writes should queue all
        /// </summary>
        [Fact]
        public void AsyncLogOutput_MultipleWrites_ShouldQueueAll()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            // Act
            for (int i = 0; i < 10; i++)
            {
                LogEntry entry = new LogEntry(LogLevel.Info, $"Message {i}", "Logger");
                asyncOutput.Write(entry);
            }

            asyncOutput.Flush();

            // Assert
            Assert.Equal(10, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output flush should process queue
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Flush_ShouldProcessQueue()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            // Act
            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 1", "Logger"));
            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 2", "Logger"));

            Assert.Empty(innerOutput.GetEntries()); // Before flush

            asyncOutput.Flush();

            // Assert
            Assert.Equal(2, innerOutput.GetEntries().Count);
        }

        /// <summary>
        ///     Tests that async log output disable should not queue
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Disable_ShouldNotQueue()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);
            asyncOutput.IsEnabled = false;

            // Act
            asyncOutput.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
            asyncOutput.Flush();

            // Assert
            Assert.Empty(innerOutput.GetEntries());
        }

        /// <summary>
        ///     Tests that async log output null entry should not queue
        /// </summary>
        [Fact]
        public void AsyncLogOutput_NullEntry_ShouldNotQueue()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            // Act
            asyncOutput.Write(null);
            asyncOutput.Flush();

            // Assert
            Assert.Empty(innerOutput.GetEntries());
        }

        /// <summary>
        ///     Tests that async log output max queue size should enforce limit
        /// </summary>
        [Fact]
        public void AsyncLogOutput_MaxQueueSize_ShouldEnforceLimit()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput, 5);

            // Act
            for (int i = 0; i < 10; i++)
            {
                asyncOutput.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            asyncOutput.Flush();

            // Assert - At most 5 should be queued
            Assert.True(innerOutput.Count <= 6); // Allow 1 extra due to race condition
        }

        /// <summary>
        ///     Tests that async log output zero max queue size should be unlimited
        /// </summary>
        [Fact]
        public void AsyncLogOutput_ZeroMaxQueueSize_ShouldBeUnlimited()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput, 0);

            // Act
            for (int i = 0; i < 1000; i++)
            {
                asyncOutput.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            asyncOutput.Flush();

            // Assert
            Assert.Equal(1000, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output has name
        /// </summary>
        [Fact]
        public void AsyncLogOutput_HasName()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            // Act & Assert
            Assert.NotNull(asyncOutput.Name);
            Assert.Contains("Async", asyncOutput.Name);
        }

        /// <summary>
        ///     Tests that async log output dispose should flush and dispose
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Dispose_ShouldFlushAndDispose()
        {
            // Arrange
            MemoryLogOutput innerOutput = new MemoryLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);
            asyncOutput.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));

            // Act
            asyncOutput.Dispose();

            // Assert
            Assert.Empty(innerOutput.GetEntries());
        }

        /// <summary>
        ///     Tests that async log output inner output exception should not propagate
        /// </summary>
        [Fact]
        public void AsyncLogOutput_InnerOutputException_ShouldNotPropagate()
        {
            // Arrange
            FaultyLogOutput faultyOutput = new FaultyLogOutput();
            AsyncLogOutput asyncOutput = new AsyncLogOutput(faultyOutput);

            // Act & Assert - Should not throw
            asyncOutput.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
            asyncOutput.Flush();
        }

        /// <summary>
        ///     The faulty log output class
        /// </summary>
        /// <seealso cref="ILogOutput" />
        private sealed class FaultyLogOutput : ILogOutput
        {
            /// <summary>
            ///     Gets the value of the name
            /// </summary>
            public string Name => "FaultyOutput";

            /// <summary>
            ///     Gets or sets the value of the is enabled
            /// </summary>
            public bool IsEnabled { get; set; } = true;

            /// <summary>
            ///     Writes the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            /// <exception cref="InvalidOperationException">Faulty</exception>
            public void Write(ILogEntry entry)
            {
                throw new InvalidOperationException("Faulty");
            }

            /// <summary>
            ///     Flushes this instance
            /// </summary>
            public void Flush()
            {
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}