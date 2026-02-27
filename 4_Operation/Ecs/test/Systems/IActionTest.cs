// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IActionTest.cs
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

using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The i action test class
    /// </summary>
    /// <remarks>
    ///     Tests the IAction interface that defines an arbitrary function with one parameter.
    ///     This interface is used to inline query functions in the ECS for performance optimization.
    /// </remarks>
    public class IActionTest
    {
        /// <summary>
        ///     Tests that IAction can be implemented with int parameter
        /// </summary>
        /// <remarks>
        ///     Validates that IAction can be implemented with a simple value type
        ///     and the Run method executes correctly.
        /// </remarks>
        [Fact]
        public void IAction_WithIntParameter_CanBeImplemented()
        {
            // Arrange
            IntIncrementAction action = new IntIncrementAction();
            int value = 5;

            // Act
            action.Run(ref value);

            // Assert
            Assert.Equal(6, value);
        }

        /// <summary>
        ///     Tests that IAction can be implemented with struct parameter
        /// </summary>
        /// <remarks>
        ///     Validates that IAction works with custom structs as parameters.
        /// </remarks>
        [Fact]
        public void IAction_WithStructParameter_CanBeImplemented()
        {
            // Arrange
            StructModifyAction action = new StructModifyAction();
            TestStruct testStruct = new TestStruct { Value = 10 };

            // Act
            action.Run(ref testStruct);

            // Assert
            Assert.Equal(20, testStruct.Value);
        }

        /// <summary>
        ///     Tests that IAction can modify ref parameter
        /// </summary>
        /// <remarks>
        ///     Validates that the ref parameter allows modifications
        ///     that persist after the method call.
        /// </remarks>
        [Fact]
        public void IAction_WithRefParameter_ModifiesOriginalValue()
        {
            // Arrange
            IntMultiplyAction action = new IntMultiplyAction(3);
            int value = 7;

            // Act
            action.Run(ref value);

            // Assert
            Assert.Equal(21, value);
        }

        /// <summary>
        ///     Tests that IAction can be used in generic methods
        /// </summary>
        /// <remarks>
        ///     Validates that IAction implementations can be used
        ///     in generic contexts.
        /// </remarks>
        [Fact]
        public void IAction_CanBeUsedInGenericMethod()
        {
            // Arrange
            IntIncrementAction action = new IntIncrementAction();
            int value = 100;

            // Act
            ProcessAction(action, ref value);

            // Assert
            Assert.Equal(101, value);
        }

        /// <summary>
        ///     Tests that multiple IAction implementations can coexist
        /// </summary>
        /// <remarks>
        ///     Validates that different IAction implementations can be
        ///     used independently without conflicts.
        /// </remarks>
        [Fact]
        public void IAction_MultipleImplementations_CanCoexist()
        {
            // Arrange
            IntIncrementAction incrementAction = new IntIncrementAction();
            IntMultiplyAction multiplyAction = new IntMultiplyAction(2);
            int value1 = 5;
            int value2 = 5;

            // Act
            incrementAction.Run(ref value1);
            multiplyAction.Run(ref value2);

            // Assert
            Assert.Equal(6, value1);
            Assert.Equal(10, value2);
        }

        /// <summary>
        ///     Tests that IAction can be called multiple times
        /// </summary>
        /// <remarks>
        ///     Validates that IAction implementations can be reused
        ///     across multiple invocations.
        /// </remarks>
        [Fact]
        public void IAction_CanBeCalledMultipleTimes()
        {
            // Arrange
            IntIncrementAction action = new IntIncrementAction();
            int value = 0;

            // Act
            for (int i = 0; i < 10; i++)
            {
                action.Run(ref value);
            }

            // Assert
            Assert.Equal(10, value);
        }

        /// <summary>
        ///     Tests that IAction with stateful implementation works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that IAction implementations can maintain internal state
        ///     across multiple calls.
        /// </remarks>
        [Fact]
        public void IAction_WithStatefulImplementation_MaintainsState()
        {
            // Arrange
            CountingAction action = new CountingAction();
            int dummy = 0;

            // Act
            action.Run(ref dummy);
            action.Run(ref dummy);
            action.Run(ref dummy);

            // Assert
            Assert.Equal(3, action.CallCount);
        }

        /// <summary>
        ///     Tests that IAction can handle complex operations
        /// </summary>
        /// <remarks>
        ///     Validates that IAction can perform complex operations
        ///     beyond simple value modifications.
        /// </remarks>
        [Fact]
        public void IAction_CanHandleComplexOperations()
        {
            // Arrange
            ComplexStructAction action = new ComplexStructAction();
            ComplexStruct complex = new ComplexStruct { A = 5, B = 10, C = 15 };

            // Act
            action.Run(ref complex);

            // Assert
            Assert.Equal(10, complex.A);
            Assert.Equal(20, complex.B);
            Assert.Equal(30, complex.C);
        }

        /// <summary>
        ///     Tests that IAction with lambda-like behavior works
        /// </summary>
        /// <remarks>
        ///     Validates that IAction can capture and use external values
        ///     similar to lambda expressions.
        /// </remarks>
        [Fact]
        public void IAction_WithCapturedValue_WorksCorrectly()
        {
            // Arrange
            int multiplier = 5;
            IntMultiplyAction action = new IntMultiplyAction(multiplier);
            int value = 3;

            // Act
            action.Run(ref value);

            // Assert
            Assert.Equal(15, value);
        }

        /// <summary>
        ///     Tests that IAction can work with zero values
        /// </summary>
        /// <remarks>
        ///     Validates that IAction handles edge case of zero input correctly.
        /// </remarks>
        [Fact]
        public void IAction_WithZeroValue_HandlesCorrectly()
        {
            // Arrange
            IntIncrementAction action = new IntIncrementAction();
            int value = 0;

            // Act
            action.Run(ref value);

            // Assert
            Assert.Equal(1, value);
        }

        /// <summary>
        ///     Tests that IAction can be used with negative values
        /// </summary>
        /// <remarks>
        ///     Validates that IAction works correctly with negative numbers.
        /// </remarks>
        [Fact]
        public void IAction_WithNegativeValue_HandlesCorrectly()
        {
            // Arrange
            IntIncrementAction action = new IntIncrementAction();
            int value = -5;

            // Act
            action.Run(ref value);

            // Assert
            Assert.Equal(-4, value);
        }

        /// <summary>
        ///     Tests that IAction can be used in parallel scenarios
        /// </summary>
        /// <remarks>
        ///     Validates that separate IAction instances can be used
        ///     independently in concurrent scenarios.
        /// </remarks>
        [Fact]
        public void IAction_InParallelScenarios_WorksIndependently()
        {
            // Arrange
            IntIncrementAction action1 = new IntIncrementAction();
            IntIncrementAction action2 = new IntIncrementAction();
            int value1 = 10;
            int value2 = 20;

            // Act
            action1.Run(ref value1);
            action2.Run(ref value2);

            // Assert
            Assert.Equal(11, value1);
            Assert.Equal(21, value2);
        }

        #region Helper Methods

        /// <summary>
        ///     Processes an action
        /// </summary>
        private void ProcessAction<T>(IAction<T> action, ref T value)
        {
            action.Run(ref value);
        }

        #endregion

        #region Test Implementations

        /// <summary>
        ///     Test implementation that increments an integer
        /// </summary>
        private struct IntIncrementAction : IAction<int>
        {
            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref int arg)
            {
                arg++;
            }
        }

        /// <summary>
        ///     Test implementation that multiplies an integer
        /// </summary>
        private struct IntMultiplyAction : IAction<int>
        {
            /// <summary>
            /// The multiplier
            /// </summary>
            private readonly int _multiplier;

            /// <summary>
            /// Initializes a new instance of the <see cref="IntMultiplyAction"/> class
            /// </summary>
            /// <param name="multiplier">The multiplier</param>
            public IntMultiplyAction(int multiplier)
            {
                _multiplier = multiplier;
            }

            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref int arg)
            {
                arg *= _multiplier;
            }
        }

        /// <summary>
        ///     Test implementation that modifies a struct
        /// </summary>
        private struct StructModifyAction : IAction<TestStruct>
        {
            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref TestStruct arg)
            {
                arg.Value *= 2;
            }
        }

        /// <summary>
        ///     Test implementation that counts calls
        /// </summary>
        private class CountingAction : IAction<int>
        {
            /// <summary>
            /// Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref int arg)
            {
                CallCount++;
            }
        }

        /// <summary>
        ///     Test implementation for complex struct operations
        /// </summary>
        private struct ComplexStructAction : IAction<ComplexStruct>
        {
            /// <summary>
            /// Runs the arg
            /// </summary>
            /// <param name="arg">The arg</param>
            public void Run(ref ComplexStruct arg)
            {
                arg.A *= 2;
                arg.B *= 2;
                arg.C *= 2;
            }
        }

        /// <summary>
        ///     Test struct for IAction
        /// </summary>
        private struct TestStruct
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Complex test struct
        /// </summary>
        private struct ComplexStruct
        {
            /// <summary>
            /// The 
            /// </summary>
            public int A;
            /// <summary>
            /// The 
            /// </summary>
            public int B;
            /// <summary>
            /// The 
            /// </summary>
            public int C;
        }

        #endregion
    }
}

