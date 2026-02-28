// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelExtensionConfigurationTest.cs
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
using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Core;
using Alis.Extension.Thread.Strategies;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The parallel extension configuration test class
    /// </summary>
    public class ParallelExtensionConfigurationTest
    {
        /// <summary>
        ///     Tests that default configuration has correct values
        /// </summary>
        [Fact]
        public void DefaultConfiguration_HasCorrectValues()
        {
            // Arrange & Act
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration();

            // Assert
            Assert.True(config.EnableParallelExecution);
            Assert.Null(config.MaxDegreeOfParallelism);
            Assert.Equal(64, config.MinBatchSizePerThread);
            Assert.Equal(128, config.DefaultMinBatchSize);
            Assert.Null(config.ExecutionStrategy);
        }

        /// <summary>
        ///     Tests that create context creates valid context
        /// </summary>
        [Fact]
        public void CreateContext_CreatesValidContext()
        {
            // Arrange
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration
            {
                EnableParallelExecution = true,
                MaxDegreeOfParallelism = 4,
                MinBatchSizePerThread = 32
            };

            // Act
            ParallelExecutionContext context = config.CreateContext();

            // Assert
            Assert.NotNull(context);
            Assert.True(context.EnableParallelExecution);
            Assert.Equal(4, context.MaxDegreeOfParallelism);
            Assert.Equal(32, context.MinBatchSizePerThread);
        }

        /// <summary>
        ///     Tests that create executor creates valid executor
        /// </summary>
        [Fact]
        public void CreateExecutor_CreatesValidExecutor()
        {
            // Arrange
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration();

            // Act
            var executor = config.CreateExecutor();

            // Assert
            Assert.NotNull(executor);
        }

        /// <summary>
        ///     Tests that create executor with custom strategy uses custom strategy
        /// </summary>
        [Fact]
        public void CreateExecutor_WithCustomStrategy_UsesCustomStrategy()
        {
            // Arrange
            ParallelExtensionConfiguration config = new ParallelExtensionConfiguration
            {
                ExecutionStrategy = new AttributeBasedExecutionStrategy()
            };

            // Act
            var executor = config.CreateExecutor();

            // Assert
            Assert.NotNull(executor);
        }
    }

    /// <summary>
    ///     The parallel extension configuration builder test class
    /// </summary>
    public class ParallelExtensionConfigurationBuilderTest
    {
        /// <summary>
        ///     Tests that with parallel execution sets property correctly
        /// </summary>
        [Fact]
        public void WithParallelExecution_SetsPropertyCorrectly()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act
            ParallelExtensionConfiguration config = builder
                .WithParallelExecution(false)
                .Build();

            // Assert
            Assert.False(config.EnableParallelExecution);
        }

        /// <summary>
        ///     Tests that with max degree of parallelism sets property correctly
        /// </summary>
        [Fact]
        public void WithMaxDegreeOfParallelism_SetsPropertyCorrectly()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act
            ParallelExtensionConfiguration config = builder
                .WithMaxDegreeOfParallelism(8)
                .Build();

            // Assert
            Assert.Equal(8, config.MaxDegreeOfParallelism);
        }

        /// <summary>
        ///     Tests that with max degree of parallelism with invalid value throws exception
        /// </summary>
        [Fact]
        public void WithMaxDegreeOfParallelism_WithInvalidValue_ThrowsException()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                builder.WithMaxDegreeOfParallelism(0));
        }

        /// <summary>
        ///     Tests that with min batch size per thread sets property correctly
        /// </summary>
        [Fact]
        public void WithMinBatchSizePerThread_SetsPropertyCorrectly()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act
            ParallelExtensionConfiguration config = builder
                .WithMinBatchSizePerThread(128)
                .Build();

            // Assert
            Assert.Equal(128, config.MinBatchSizePerThread);
        }

        /// <summary>
        ///     Tests that with min batch size per thread with invalid value throws exception
        /// </summary>
        [Fact]
        public void WithMinBatchSizePerThread_WithInvalidValue_ThrowsException()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                builder.WithMinBatchSizePerThread(0));
        }

        /// <summary>
        ///     Tests that with default min batch size sets property correctly
        /// </summary>
        [Fact]
        public void WithDefaultMinBatchSize_SetsPropertyCorrectly()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act
            ParallelExtensionConfiguration config = builder
                .WithDefaultMinBatchSize(256)
                .Build();

            // Assert
            Assert.Equal(256, config.DefaultMinBatchSize);
        }

        /// <summary>
        ///     Tests that with default min batch size with invalid value throws exception
        /// </summary>
        [Fact]
        public void WithDefaultMinBatchSize_WithInvalidValue_ThrowsException()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                builder.WithDefaultMinBatchSize(-1));
        }

        /// <summary>
        ///     Tests that with execution strategy sets property correctly
        /// </summary>
        [Fact]
        public void WithExecutionStrategy_SetsPropertyCorrectly()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            // Act
            ParallelExtensionConfiguration config = builder
                .WithExecutionStrategy(strategy)
                .Build();

            // Assert
            Assert.Same(strategy, config.ExecutionStrategy);
        }

        /// <summary>
        ///     Tests that with execution strategy with null value throws exception
        /// </summary>
        [Fact]
        public void WithExecutionStrategy_WithNullValue_ThrowsException()
        {
            // Arrange
            ParallelExtensionConfigurationBuilder builder = new ParallelExtensionConfigurationBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                builder.WithExecutionStrategy(null));
        }

        /// <summary>
        ///     Tests that fluent interface works correctly
        /// </summary>
        [Fact]
        public void FluentInterface_WorksCorrectly()
        {
            // Arrange & Act
            ParallelExtensionConfiguration config = new ParallelExtensionConfigurationBuilder()
                .WithParallelExecution(true)
                .WithMaxDegreeOfParallelism(4)
                .WithMinBatchSizePerThread(32)
                .WithDefaultMinBatchSize(64)
                .Build();

            // Assert
            Assert.True(config.EnableParallelExecution);
            Assert.Equal(4, config.MaxDegreeOfParallelism);
            Assert.Equal(32, config.MinBatchSizePerThread);
            Assert.Equal(64, config.DefaultMinBatchSize);
        }
    }
}

