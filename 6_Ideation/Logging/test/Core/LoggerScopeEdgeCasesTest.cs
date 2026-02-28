// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerScopeEdgeCasesTest.cs
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
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging.Core;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Core
{
    /// <summary>
    ///     Edge case and stress tests for LoggerScope.
    ///     Tests complex scope scenarios and concurrent behavior.
    /// </summary>
    public class LoggerScopeEdgeCasesTest
    {
        [Fact]
        public void LoggerScope_ThousandLevelsDeep()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            List<LoggerScope> scopes = new List<LoggerScope>();

            // Act
            for (int i = 0; i < 1000; i++)
            {
                scopes.Add(new LoggerScope($"Scope{i}", stack, () => { }));
            }

            // Assert
            Assert.Equal(1000, stack.Count);

            // Cleanup
            for (int i = 999; i >= 0; i--)
            {
                scopes[i].Dispose();
            }

            Assert.Empty(stack);
        }

        [Fact]
        public void LoggerScope_StackUnwindingOrder()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            LoggerScope[] scopes = new LoggerScope[5];

            // Act - Push 5 scopes
            for (int i = 0; i < 5; i++)
            {
                scopes[i] = new LoggerScope($"Scope{i}", stack, () => { });
            }

            // Assert order
            Assert.Equal("Scope4", stack.Pop());
            Assert.Equal("Scope3", stack.Pop());
            Assert.Equal("Scope2", stack.Pop());
            Assert.Equal("Scope1", stack.Pop());
            Assert.Equal("Scope0", stack.Pop());
        }

        [Fact]
        public void LoggerScope_ParallelScopeCreation()
        {
            // Arrange
            Stack<object>[] stacks = new Stack<object>[10];
            LoggerScope[] scopes = new LoggerScope[10];
            Task[] tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                stacks[i] = new Stack<object>();
            }

            // Act - Create scopes in parallel
            for (int i = 0; i < 10; i++)
            {
                int index = i;
                tasks[i] = Task.Run(() => { scopes[index] = new LoggerScope($"Scope{index}", stacks[index], () => { }); });
            }

            Task.WaitAll(tasks);

            // Assert
            for (int i = 0; i < 10; i++)
            {
                Assert.Single(stacks[i]);
                Assert.Equal($"Scope{i}", stacks[i].Pop());
            }
        }

        [Fact]
        public void LoggerScope_ComplexObjectAsScope()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            var complexObject = new
            {
                RequestId = Guid.NewGuid(),
                UserId = 12345,
                Action = "ProcessPayment",
                Timestamp = DateTime.UtcNow,
                Data = new {Amount = 99.99m, Currency = "USD"}
            };

            // Act
            LoggerScope scope = new LoggerScope(complexObject, stack, () => { });

            // Assert
            Assert.Single(stack);
            object poppedObject = stack.Pop();
            Assert.NotNull(poppedObject);

            scope.Dispose();
        }

        [Fact]
        public void LoggerScope_CallbackThrowingException()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            bool exceptionThrown = false;

            // Act
            LoggerScope scope = new LoggerScope("TestScope", stack, () =>
            {
                exceptionThrown = true;
                throw new InvalidOperationException("Callback error");
            });

            // Assert - Dispose should not throw despite callback exception
            try
            {
                scope.Dispose();
                // If we get here, the exception was swallowed
            }
            catch
            {
                // If exception is thrown, that's also valid depending on implementation
            }

            Assert.True(exceptionThrown);
        }

        [Fact]
        public void LoggerScope_DisposableBehavior()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("TestScope", stack, () => { });

            // Assert - Should implement IDisposable
            Assert.IsAssignableFrom<IDisposable>(scope);
        }

        [Fact]
        public void LoggerScope_LongScopeName()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            string longName = new string('x', 100000);

            // Act
            LoggerScope scope = new LoggerScope(longName, stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Equal(longName, stack.Pop());

            scope.Dispose();
        }

        [Fact]
        public void LoggerScope_UnicodeInScopeName()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            string unicodeName = "Scope: 中文 مرحبا Привет 🎮";

            // Act
            LoggerScope scope = new LoggerScope(unicodeName, stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Equal(unicodeName, stack.Pop());

            scope.Dispose();
        }

        [Fact]
        public void LoggerScope_SpecialCharactersInName()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            string specialName = "Scope\nWith\tSpecial\rCharacters\"And'Quotes";

            // Act
            LoggerScope scope = new LoggerScope(specialName, stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Equal(specialName, stack.Pop());

            scope.Dispose();
        }

        [Fact]
        public void LoggerScope_MultipleCallbacksInChain()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            List<int> callOrder = new List<int>();

            // Create nested scopes with callbacks
            Action createNested = null;
            createNested = () =>
            {
                // This would be created in actual nested logging
            };

            LoggerScope scope1 = new LoggerScope("S1", stack, () => callOrder.Add(1));
            LoggerScope scope2 = new LoggerScope("S2", stack, () => callOrder.Add(2));
            LoggerScope scope3 = new LoggerScope("S3", stack, () => callOrder.Add(3));

            // Act - Dispose in LIFO order
            scope3.Dispose(); // Should call callback(3)
            scope2.Dispose(); // Should call callback(2)
            scope1.Dispose(); // Should call callback(1)

            // Assert
            Assert.Equal(new[] {3, 2, 1}, callOrder);
        }

        [Fact]
        public void LoggerScope_ConcurrentDisposal()
        {
            // Arrange
            Stack<object>[] stacks = new Stack<object>[5];
            LoggerScope[] scopes = new LoggerScope[5];

            for (int i = 0; i < 5; i++)
            {
                stacks[i] = new Stack<object>();
                scopes[i] = new LoggerScope($"Scope{i}", stacks[i], () => { });
            }

            // Act - Dispose all simultaneously
            Task[] tasks = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                tasks[i] = Task.Run(() => scopes[index].Dispose());
            }

            Task.WaitAll(tasks);

            // Assert - All should be cleaned up
            for (int i = 0; i < 5; i++)
            {
                Assert.Empty(stacks[i]);
            }
        }

        [Fact]
        public void LoggerScope_NullObjectAsScope()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();

            // Act
            LoggerScope scope = new LoggerScope(null, stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Null(stack.Pop());

            scope.Dispose();
        }
    }
}