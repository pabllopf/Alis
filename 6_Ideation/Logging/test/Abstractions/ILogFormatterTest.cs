// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Abstractions/ILogFormatterTest.cs
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

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Comprehensive unit tests for the ILogFormatter interface contract.
    ///     Validates that implementations properly support all interface methods.
    /// </summary>
    public class ILogFormatterTest
    {
        [Fact]
        public void ILogFormatter_ImplementationCanBeCreated()
        {
            // Act
            ILogFormatter formatter = new SimpleLogFormatter();

            // Assert
            Assert.NotNull(formatter);
        }

        [Fact]
        public void ILogFormatter_HasNameProperty()
        {
            // Arrange
            ILogFormatter formatter = new SimpleLogFormatter();

            // Assert
            Assert.NotNull(formatter.Name);
            Assert.NotEmpty(formatter.Name);
        }

        [Fact]
        public void ILogFormatter_FormatMethod_CanBeCalled()
        {
            // Arrange
            ILogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            string result = formatter.Format(entry);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void ILogFormatter_FormatReturnsString()
        {
            // Arrange
            ILogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            string result = formatter.Format(entry);

            // Assert
            Assert.IsType<string>(result);
        }

        [Fact]
        public void ILogFormatter_MultipleImplementations_ShouldWork()
        {
            // Arrange
            ILogFormatter formatter1 = new SimpleLogFormatter();
            ILogFormatter formatter2 = new CompactLogFormatter();
            ILogFormatter formatter3 = new JsonLogFormatter();

            // Act & Assert
            Assert.NotNull(formatter1);
            Assert.NotNull(formatter2);
            Assert.NotNull(formatter3);
            Assert.NotEqual(formatter1.Name, formatter2.Name);
            Assert.NotEqual(formatter2.Name, formatter3.Name);
        }

        [Fact]
        public void ILogFormatter_DifferentImplementations_ProduceDifferentOutput()
        {
            // Arrange
            ILogFormatter[] formatters = new ILogFormatter[]
            {
                new SimpleLogFormatter(),
                new CompactLogFormatter(),
                new JsonLogFormatter()
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            // Act
            string[] results = new string[3];
            for (int i = 0; i < formatters.Length; i++)
            {
                results[i] = formatters[i].Format(entry);
            }

            // Assert - All should produce different output
            Assert.NotEqual(results[0], results[1]);
            Assert.NotEqual(results[1], results[2]);
            Assert.NotEqual(results[0], results[2]);
        }
    }
}

