// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILogOutputTest.cs
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

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Comprehensive unit tests for the ILogOutput interface contract.
    ///     Validates that implementations properly support all interface methods.
    /// </summary>
    public class ILogOutputTest
    {
        /// <summary>
        /// Tests that i log output implementation can be created
        /// </summary>
        [Fact]
        public void ILogOutput_ImplementationCanBeCreated()
        {
            // Act
            ILogOutput output = new MemoryLogOutput();

            // Assert
            Assert.NotNull(output);
        }

        /// <summary>
        /// Tests that i log output has name property
        /// </summary>
        [Fact]
        public void ILogOutput_HasNameProperty()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Assert
            Assert.NotNull(output.Name);
            Assert.NotEmpty(output.Name);
        }

        /// <summary>
        /// Tests that i log output has is enabled property
        /// </summary>
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

        /// <summary>
        /// Tests that i log output write method can be called
        /// </summary>
        [Fact]
        public void ILogOutput_WriteMethod_CanBeCalled()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        /// <summary>
        /// Tests that i log output flush method can be called
        /// </summary>
        [Fact]
        public void ILogOutput_FlushMethod_CanBeCalled()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Act & Assert - Should not throw
            output.Flush();
        }

        /// <summary>
        /// Tests that i log output dispose method can be called
        /// </summary>
        [Fact]
        public void ILogOutput_DisposeMethod_CanBeCalled()
        {
            // Arrange
            ILogOutput output = new MemoryLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
        }

        /// <summary>
        /// Tests that i log output multiple implementations should work
        /// </summary>
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

        /// <summary>
        /// Tests that i log output can be disposable interface
        /// </summary>
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