// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerScopeTest.cs
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
using Alis.Core.Aspect.Logging.Core;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the LoggerScope class.
    ///     Validates scope stack management, disposal behavior,
    ///     and proper cleanup of scope context.
    /// </summary>
    public class LoggerScopeTest
    {
        [Fact]
        public void LoggerScope_Constructor_ShouldPushScopeOntoStack()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();

            // Act
            LoggerScope scope = new LoggerScope("TestScope", stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Equal("TestScope", stack.Peek());
        }

        [Fact]
        public void LoggerScope_Dispose_ShouldPopScopeFromStack()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            stack.Push("ExistingScope");
            LoggerScope scope = new LoggerScope("NewScope", stack, () => { });
            Assert.Equal(2, stack.Count);

            // Act
            scope.Dispose();

            // Assert
            Assert.Single(stack);
            Assert.Equal("ExistingScope", stack.Peek());
        }

        [Fact]
        public void LoggerScope_DisposeTwice_ShouldNotThrow()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("TestScope", stack, () => { });

            // Act & Assert
            scope.Dispose();
            scope.Dispose(); // Should not throw
        }

        [Fact]
        public void LoggerScope_OnDisposeCallback_ShouldBeInvoked()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            bool callbackInvoked = false;

            // Act
            LoggerScope scope = new LoggerScope("TestScope", stack, () => callbackInvoked = true);
            scope.Dispose();

            // Assert
            Assert.True(callbackInvoked);
        }

        [Fact]
        public void LoggerScope_NullStack_ShouldThrowArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LoggerScope("TestScope", null, () => { }));
        }

        [Fact]
        public void LoggerScope_NullCallback_ShouldNotThrow()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();

            // Act & Assert
            LoggerScope scope = new LoggerScope("TestScope", stack, null);
            scope.Dispose(); // Should not throw
        }

        [Fact]
        public void LoggerScope_NestedScopes_ShouldMaintainStackOrder()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();

            // Act
            LoggerScope scope1 = new LoggerScope("Scope1", stack, () => { });
            LoggerScope scope2 = new LoggerScope("Scope2", stack, () => { });
            LoggerScope scope3 = new LoggerScope("Scope3", stack, () => { });

            // Assert
            Assert.Equal(3, stack.Count);
            Assert.Equal("Scope3", stack.Pop());
            Assert.Equal("Scope2", stack.Pop());
            Assert.Equal("Scope1", stack.Pop());

            // Cleanup
            scope3.Dispose();
            scope2.Dispose();
            scope1.Dispose();
        }

        [Fact]
        public void LoggerScope_UsingStatement_ShouldAutomaticallyDispose()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            LoggerScope scope;

            // Act
            using (scope = new LoggerScope("TestScope", stack, () => { }))
            {
                Assert.Single(stack);
            }

            // Assert
            Assert.Empty(stack);
        }

        [Fact]
        public void LoggerScope_MultipleScopes_ShouldPopInLifoOrder()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            LoggerScope scope1 = new LoggerScope("A", stack, () => { });
            LoggerScope scope2 = new LoggerScope("B", stack, () => { });

            // Act
            scope2.Dispose();

            // Assert
            Assert.Single(stack);
            Assert.Equal("A", stack.Pop());
        }

        [Fact]
        public void LoggerScope_DisposeBehavior_ShouldHandleEmptyStack()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("TestScope", stack, () => { });
            stack.Pop(); // Remove the scope manually

            // Act & Assert - Dispose should handle empty stack gracefully
            scope.Dispose(); // Should not throw
        }

        [Fact]
        public void LoggerScope_ScopeWithObject_ShouldStoreObject()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            var scopeObject = new {Id = 123, Name = "TestScope"};

            // Act
            LoggerScope scope = new LoggerScope(scopeObject, stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Equal(scopeObject, stack.Peek());
        }

        [Fact]
        public void LoggerScope_ScopeWithNumber_ShouldStoreNumber()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            int scopeId = 42;

            // Act
            LoggerScope scope = new LoggerScope(scopeId, stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Equal(42, stack.Pop());
        }

        [Fact]
        public void LoggerScope_LongScopeChain_ShouldMaintainOrder()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();
            LoggerScope[] scopes = new LoggerScope[100];

            // Act
            for (int i = 0; i < 100; i++)
            {
                scopes[i] = new LoggerScope($"Scope{i}", stack, () => { });
            }

            // Assert
            Assert.Equal(100, stack.Count);

            // Verify LIFO order
            for (int i = 99; i >= 0; i--)
            {
                scopes[i].Dispose();
                Assert.Equal(i, stack.Count);
            }
        }

        [Fact]
        public void LoggerScope_NullScope_ShouldBeAllowed()
        {
            // Arrange
            Stack<object> stack = new Stack<object>();

            // Act
            LoggerScope scope = new LoggerScope(null, stack, () => { });

            // Assert
            Assert.Single(stack);
            Assert.Null(stack.Peek());
        }
    }
}