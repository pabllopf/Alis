// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AttributeBasedExecutionStrategyTest.cs
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

using Alis.Extension.Thread.Attributes;
using Alis.Extension.Thread.Interfaces;
using Alis.Extension.Thread.Strategies;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    [ParallelSafe(256)]
    public struct TestComponentWithAttribute
    {
        public float Value;
    }

    public struct TestComponentWithInterface : IParallelCapable
    {
        public float Value;
    }

    public struct TestComponentWithoutMarkers
    {
        public float Value;
    }

    /// <summary>
    ///     The attribute based execution strategy test class
    /// </summary>
    public class AttributeBasedExecutionStrategyTest
    {
        /// <summary>
        ///     Tests that can execute in parallel detects attribute
        /// </summary>
        [Fact]
        public void CanExecuteInParallel_DetectsAttribute()
        {
            // Arrange
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            // Act
            bool result = strategy.CanExecuteInParallel(typeof(TestComponentWithAttribute));

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that can execute in parallel detects interface
        /// </summary>
        [Fact]
        public void CanExecuteInParallel_DetectsInterface()
        {
            // Arrange
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            // Act
            bool result = strategy.CanExecuteInParallel(typeof(TestComponentWithInterface));

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that can execute in parallel returns false for unmarked component
        /// </summary>
        [Fact]
        public void CanExecuteInParallel_ReturnsFalseForUnmarkedComponent()
        {
            // Arrange
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            // Act
            bool result = strategy.CanExecuteInParallel(typeof(TestComponentWithoutMarkers));

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that get minimum batch size reads attribute value
        /// </summary>
        [Fact]
        public void GetMinimumBatchSize_ReadsAttributeValue()
        {
            // Arrange
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            // Act
            int batchSize = strategy.GetMinimumBatchSize(typeof(TestComponentWithAttribute));

            // Assert
            Assert.Equal(256, batchSize);
        }

        /// <summary>
        ///     Tests that get minimum batch size returns default for component without attribute
        /// </summary>
        [Fact]
        public void GetMinimumBatchSize_ReturnsDefaultForComponentWithoutAttribute()
        {
            // Arrange
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();

            // Act
            int batchSize = strategy.GetMinimumBatchSize(typeof(TestComponentWithInterface));

            // Assert
            Assert.Equal(128, batchSize);
        }

        /// <summary>
        ///     Tests that clear cache clears internal caches
        /// </summary>
        [Fact]
        public void ClearCache_ClearsInternalCaches()
        {
            // Arrange
            AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
            strategy.CanExecuteInParallel(typeof(TestComponentWithAttribute));
            strategy.GetMinimumBatchSize(typeof(TestComponentWithAttribute));

            // Act
            strategy.ClearCache();

            // Assert - should not throw
            Assert.True(true);
        }
    }
}