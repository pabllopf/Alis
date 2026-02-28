// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILoggerTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Comprehensive unit tests for the ILogger interface contract.
    ///     Validates that implementations properly support all interface methods.
    /// </summary>
    public class ILoggerTest
    {
        [Fact]
        public void ILogger_Implementation_ShouldHaveNameProperty()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act & Assert
                Assert.NotNull(logger.Name);
                Assert.Equal("TestLogger", logger.Name);
            }
        }

        [Fact]
        public void ILogger_AllLoggingMethods_ShouldBeDefined()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act & Assert - All methods should exist and be callable
                logger.LogTrace("Trace");
                logger.LogDebug("Debug");
                logger.LogInfo("Info");
                logger.LogWarning("Warning");
                logger.LogError("Error");
                logger.LogCritical("Critical");

                InvalidOperationException exception = new InvalidOperationException();
                logger.LogError("Error", exception);
                logger.LogCritical("Critical", exception);

                logger.Log(LogLevel.Info, "Generic");
                logger.Log(LogLevel.Info, "Generic with exception", exception);

                Dictionary<string, object> properties = new Dictionary<string, object> {{"key", "value"}};
                logger.LogStructured(LogLevel.Info, "Structured", properties);

                Assert.True(memoryOutput.Count >= 11);
            }
        }

        [Fact]
        public void ILogger_CorrelationIdMethods_ShouldExist()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.SetCorrelationId("TEST-ID");
                string retrieved = logger.GetCorrelationId();

                // Assert
                Assert.Equal("TEST-ID", retrieved);
            }
        }

        [Fact]
        public void ILogger_ScopeMethods_ShouldExist()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act & Assert
                IDisposable scope = logger.BeginScope("TestScope");
                Assert.NotNull(scope);
                scope.Dispose();
            }
        }

        [Fact]
        public void ILogger_IsEnabledMethod_ShouldExist()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act & Assert
                Assert.True(logger.IsEnabled(LogLevel.Info));
            }
        }

        [Fact]
        public void ILogger_ImplementationCanBeStored()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act & Assert
                Assert.NotNull(logger);
                Assert.IsAssignableFrom<ILogger>(logger);
            }
        }

        [Fact]
        public void ILogger_MultipleImplementations_ShouldCoexist()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger1 = factory.CreateLogger("Logger1");
                ILogger logger2 = factory.CreateLogger("Logger2");

                // Act & Assert
                Assert.NotSame(logger1, logger2);
                logger1.LogInfo("Message 1");
                logger2.LogInfo("Message 2");
            }
        }
    }
}