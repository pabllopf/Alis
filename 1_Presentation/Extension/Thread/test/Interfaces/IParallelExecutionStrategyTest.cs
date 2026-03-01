// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IParallelExecutionStrategyTest.cs
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
using Alis.Extension.Thread.Interfaces;
using Xunit;

namespace Alis.Extension.Thread.Test.Interfaces
{
    /// <summary>
    ///     Mock implementation of parallel execution strategy for testing
    /// </summary>
    internal class MockParallelExecutionStrategy : IParallelExecutionStrategy
    {
        /// <summary>
        /// The batch size
        /// </summary>
        private readonly int batchSize;
        /// <summary>
        /// The return value
        /// </summary>
        private readonly bool returnValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockParallelExecutionStrategy"/> class
        /// </summary>
        /// <param name="returnValue">The return value</param>
        /// <param name="batchSize">The batch size</param>
        public MockParallelExecutionStrategy(bool returnValue = true, int batchSize = 128)
        {
            this.returnValue = returnValue;
            this.batchSize = batchSize;
        }

        /// <summary>
        /// Gets or sets the value of the can execute call count
        /// </summary>
        public int CanExecuteCallCount { get; private set; }
        /// <summary>
        /// Gets or sets the value of the get batch size call count
        /// </summary>
        public int GetBatchSizeCallCount { get; private set; }
        /// <summary>
        /// Gets or sets the value of the last checked type
        /// </summary>
        public Type LastCheckedType { get; private set; }

        /// <summary>
        /// Cans the execute in parallel using the specified component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The return value</returns>
        public bool CanExecuteInParallel(Type componentType)
        {
            CanExecuteCallCount++;
            LastCheckedType = componentType;
            return returnValue;
        }

        /// <summary>
        /// Gets the minimum batch size using the specified component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The batch size</returns>
        public int GetMinimumBatchSize(Type componentType)
        {
            GetBatchSizeCallCount++;
            LastCheckedType = componentType;
            return batchSize;
        }
    }

    /// <summary>
    ///     Always false strategy for testing
    /// </summary>
    internal class AlwaysFalseStrategy : IParallelExecutionStrategy
    {
        /// <summary>
        /// Cans the execute in parallel using the specified component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The bool</returns>
        public bool CanExecuteInParallel(Type componentType) => false;
        /// <summary>
        /// Gets the minimum batch size using the specified component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The int</returns>
        public int GetMinimumBatchSize(Type componentType) => 1;
    }

    /// <summary>
    ///     Always true strategy for testing
    /// </summary>
    internal class AlwaysTrueStrategy : IParallelExecutionStrategy
    {
        /// <summary>
        /// Cans the execute in parallel using the specified component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The bool</returns>
        public bool CanExecuteInParallel(Type componentType) => true;
        /// <summary>
        /// Gets the minimum batch size using the specified component type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The int</returns>
        public int GetMinimumBatchSize(Type componentType) => 256;
    }

    /// <summary>
    ///     The i parallel execution strategy test class
    /// </summary>
    public class IParallelExecutionStrategyTest
    {
        /// <summary>
        ///     Tests that interface has can execute in parallel method
        /// </summary>
        [Fact]
        public void Interface_HasCanExecuteInParallelMethod()
        {
            // Arrange
            Type interfaceType = typeof(IParallelExecutionStrategy);

            // Act
            var method = interfaceType.GetMethod(nameof(IParallelExecutionStrategy.CanExecuteInParallel));

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
            var parameters = method.GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(Type), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that interface has get minimum batch size method
        /// </summary>
        [Fact]
        public void Interface_HasGetMinimumBatchSizeMethod()
        {
            // Arrange
            Type interfaceType = typeof(IParallelExecutionStrategy);

            // Act
            var method = interfaceType.GetMethod(nameof(IParallelExecutionStrategy.GetMinimumBatchSize));

            // Assert
            Assert.NotNull(method);
            Assert.Equal(typeof(int), method.ReturnType);
            var parameters = method.GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(Type), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that mock strategy can execute in parallel works
        /// </summary>
        [Fact]
        public void MockStrategy_CanExecuteInParallel_Works()
        {
            // Arrange
            IParallelExecutionStrategy strategy = new MockParallelExecutionStrategy();

            // Act
            bool result = strategy.CanExecuteInParallel(typeof(int));

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that mock strategy get minimum batch size works
        /// </summary>
        [Fact]
        public void MockStrategy_GetMinimumBatchSize_Works()
        {
            // Arrange
            IParallelExecutionStrategy strategy = new MockParallelExecutionStrategy(true, 512);

            // Act
            int batchSize = strategy.GetMinimumBatchSize(typeof(int));

            // Assert
            Assert.Equal(512, batchSize);
        }

        /// <summary>
        ///     Tests that mock strategy tracks method calls
        /// </summary>
        [Fact]
        public void MockStrategy_TracksMethodCalls()
        {
            // Arrange
            MockParallelExecutionStrategy strategy = new MockParallelExecutionStrategy();

            // Act
            strategy.CanExecuteInParallel(typeof(string));
            strategy.CanExecuteInParallel(typeof(int));
            strategy.GetMinimumBatchSize(typeof(double));

            // Assert
            Assert.Equal(2, strategy.CanExecuteCallCount);
            Assert.Equal(1, strategy.GetBatchSizeCallCount);
            Assert.Equal(typeof(double), strategy.LastCheckedType);
        }

        /// <summary>
        ///     Tests that always false strategy returns false
        /// </summary>
        [Fact]
        public void AlwaysFalseStrategy_ReturnsFlase()
        {
            // Arrange
            IParallelExecutionStrategy strategy = new AlwaysFalseStrategy();

            // Act
            bool result1 = strategy.CanExecuteInParallel(typeof(int));
            bool result2 = strategy.CanExecuteInParallel(typeof(string));

            // Assert
            Assert.False(result1);
            Assert.False(result2);
        }

        /// <summary>
        ///     Tests that always true strategy returns true
        /// </summary>
        [Fact]
        public void AlwaysTrueStrategy_ReturnsTrue()
        {
            // Arrange
            IParallelExecutionStrategy strategy = new AlwaysTrueStrategy();

            // Act
            bool result1 = strategy.CanExecuteInParallel(typeof(int));
            bool result2 = strategy.CanExecuteInParallel(typeof(string));

            // Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        /// <summary>
        ///     Tests that strategies can return different batch sizes
        /// </summary>
        [Fact]
        public void Strategies_CanReturnDifferentBatchSizes()
        {
            // Arrange
            IParallelExecutionStrategy strategy1 = new AlwaysFalseStrategy();
            IParallelExecutionStrategy strategy2 = new AlwaysTrueStrategy();

            // Act
            int size1 = strategy1.GetMinimumBatchSize(typeof(int));
            int size2 = strategy2.GetMinimumBatchSize(typeof(int));

            // Assert
            Assert.Equal(1, size1);
            Assert.Equal(256, size2);
        }

        /// <summary>
        ///     Tests that interface is public
        /// </summary>
        [Fact]
        public void Interface_IsPublic()
        {
            // Act
            bool isPublic = typeof(IParallelExecutionStrategy).IsPublic;

            // Assert
            Assert.True(isPublic);
        }

        /// <summary>
        ///     Tests that interface is interface type
        /// </summary>
        [Fact]
        public void Interface_IsInterfaceType()
        {
            // Act
            bool isInterface = typeof(IParallelExecutionStrategy).IsInterface;

            // Assert
            Assert.True(isInterface);
        }

        /// <summary>
        ///     Tests that interface namespace is correct
        /// </summary>
        [Fact]
        public void Interface_NamespaceIsCorrect()
        {
            // Act
            string namespaceName = typeof(IParallelExecutionStrategy).Namespace;

            // Assert
            Assert.Equal("Alis.Extension.Thread.Interfaces", namespaceName);
        }

        /// <summary>
        ///     Tests that interface name is correct
        /// </summary>
        [Fact]
        public void Interface_NameIsCorrect()
        {
            // Act
            string name = typeof(IParallelExecutionStrategy).Name;

            // Assert
            Assert.Equal("IParallelExecutionStrategy", name);
        }

        /// <summary>
        ///     Tests that interface has exactly two methods
        /// </summary>
        [Fact]
        public void Interface_HasExactlyTwoMethods()
        {
            // Act
            var methods = typeof(IParallelExecutionStrategy).GetMethods();

            // Assert
            Assert.Equal(2, methods.Length);
        }

        /// <summary>
        ///     Tests that strategy can handle null type
        /// </summary>
        [Fact]
        public void Strategy_CanHandleNullType()
        {
            // Arrange
            MockParallelExecutionStrategy strategy = new MockParallelExecutionStrategy();

            // Act
            bool result = strategy.CanExecuteInParallel(null);
            int batchSize = strategy.GetMinimumBatchSize(null);

            // Assert - should not throw
            Assert.True(result);
            Assert.Equal(128, batchSize);
            Assert.Null(strategy.LastCheckedType);
        }

        /// <summary>
        ///     Tests that strategy can be used polymorphically
        /// </summary>
        [Fact]
        public void Strategy_CanBeUsedPolymorphically()
        {
            // Arrange
            IParallelExecutionStrategy[] strategies = new IParallelExecutionStrategy[]
            {
                new AlwaysTrueStrategy(),
                new AlwaysFalseStrategy(),
                new MockParallelExecutionStrategy()
            };

            // Act & Assert
            foreach (var strategy in strategies)
            {
                bool canExecute = strategy.CanExecuteInParallel(typeof(int));
                int batchSize = strategy.GetMinimumBatchSize(typeof(int));

                Assert.True(canExecute is true or false);
                Assert.True(batchSize > 0);
            }
        }

        /// <summary>
        ///     Tests that multiple strategy instances are independent
        /// </summary>
        [Fact]
        public void MultipleStrategyInstances_AreIndependent()
        {
            // Arrange
            MockParallelExecutionStrategy strategy1 = new MockParallelExecutionStrategy(true, 64);
            MockParallelExecutionStrategy strategy2 = new MockParallelExecutionStrategy(false, 256);

            // Act
            bool result1 = strategy1.CanExecuteInParallel(typeof(int));
            bool result2 = strategy2.CanExecuteInParallel(typeof(string));
            int size1 = strategy1.GetMinimumBatchSize(typeof(int));
            int size2 = strategy2.GetMinimumBatchSize(typeof(string));

            // Assert
            Assert.True(result1);
            Assert.False(result2);
            Assert.Equal(64, size1);
            Assert.Equal(256, size2);
            Assert.Equal(1, strategy1.CanExecuteCallCount);
            Assert.Equal(1, strategy2.CanExecuteCallCount);
        }
    }
}