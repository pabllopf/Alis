// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Abstractions/ILogOutputTest.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Comprehensive unit tests for the ILogOutput interface contract.
    ///     Validates that implementations properly support all interface methods.
    /// </summary>
    public class ILogOutputTest
    {
        [Fact]
        public void ILogOutput_ImplementationCanBeCreated()
        {
            // Act
            ILogOutput output = new MemoryLogOutput();

            // Assert
            Assert.NotNull(output);
        }

        [Fact]
        public void ILogOutput_HasNameProperty()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Assert
            Assert.NotNull(output.Name);
            Assert.NotEmpty(output.Name);
        }

        [Fact]
        public void ILogOutput_HasIsEnabledProperty()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Act & Assert
            Assert.True(output.IsEnabled);
            output.IsEnabled = false;
            Assert.False(output.IsEnabled);
        }

        [Fact]
        public void ILogOutput_WriteMethod_CanBeCalled()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void ILogOutput_FlushMethod_CanBeCalled()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Act & Assert - Should not throw
            output.Flush();
        }

        [Fact]
        public void ILogOutput_DisposeMethod_CanBeCalled()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
        }

        [Fact]
        public void ILogOutput_MultipleImplementations_ShouldWork()
        {
            // Arrange
            ILogOutput output1 = new MemoryLogOutput();
            ILogOutput output2 = new ConsoleLogOutput();

            // Act & Assert
            Assert.NotNull(output1);
            Assert.NotNull(output2);
            Assert.NotEqual(output1.Name, output2.Name);
        }

        [Fact]
        public void ILogOutput_CanBeDisposableInterface()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Act & Assert
            Assert.IsAssignableFrom<IDisposable>(output);
            output.Dispose();
        }
    }
}

