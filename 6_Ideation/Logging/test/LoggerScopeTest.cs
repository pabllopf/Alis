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
        /// <summary>
        ///     Tests that logger scope constructor should push scope onto stack
        /// </summary>
        [Fact]
        public void LoggerScope_Constructor_ShouldPushScopeOntoStack()
        {
            Stack<object> stack = new Stack<object>();

            LoggerScope scope = new LoggerScope("TestScope", stack, () => { });

            Assert.Single(stack);
            Assert.Equal("TestScope", stack.Peek());
        }

        /// <summary>
        ///     Tests that logger scope dispose should pop scope from stack
        /// </summary>
        [Fact]
        public void LoggerScope_Dispose_ShouldPopScopeFromStack()
        {
            Stack<object> stack = new Stack<object>();
            stack.Push("ExistingScope");
            LoggerScope scope = new LoggerScope("NewScope", stack, () => { });
            Assert.Equal(2, stack.Count);

            scope.Dispose();

            Assert.Single(stack);
            Assert.Equal("ExistingScope", stack.Peek());
        }

        /// <summary>
        ///     Tests that logger scope dispose twice should not throw
        /// </summary>
        [Fact]
        public void LoggerScope_DisposeTwice_ShouldNotThrow()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("TestScope", stack, () => { });

            scope.Dispose();
            scope.Dispose(); // Should not throw
        }

        /// <summary>
        ///     Tests that logger scope on dispose callback should be invoked
        /// </summary>
        [Fact]
        public void LoggerScope_OnDisposeCallback_ShouldBeInvoked()
        {
            Stack<object> stack = new Stack<object>();
            bool callbackInvoked = false;

            LoggerScope scope = new LoggerScope("TestScope", stack, () => callbackInvoked = true);
            scope.Dispose();

            Assert.True(callbackInvoked);
        }

        /// <summary>
        ///     Tests that logger scope null stack should throw argument null exception
        /// </summary>
        [Fact]
        public void LoggerScope_NullStack_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LoggerScope("TestScope", null, () => { }));
        }

        /// <summary>
        ///     Tests that logger scope null callback should not throw
        /// </summary>
        [Fact]
        public void LoggerScope_NullCallback_ShouldNotThrow()
        {
            Stack<object> stack = new Stack<object>();

            LoggerScope scope = new LoggerScope("TestScope", stack, null);
            scope.Dispose(); // Should not throw
        }

        /// <summary>
        ///     Tests that logger scope nested scopes should maintain stack order
        /// </summary>
        [Fact]
        public void LoggerScope_NestedScopes_ShouldMaintainStackOrder()
        {
            Stack<object> stack = new Stack<object>();

            LoggerScope scope1 = new LoggerScope("Scope1", stack, () => { });
            LoggerScope scope2 = new LoggerScope("Scope2", stack, () => { });
            LoggerScope scope3 = new LoggerScope("Scope3", stack, () => { });

            Assert.Equal(3, stack.Count);
            Assert.Equal("Scope3", stack.Pop());
            Assert.Equal("Scope2", stack.Pop());
            Assert.Equal("Scope1", stack.Pop());

            scope3.Dispose();
            scope2.Dispose();
            scope1.Dispose();
        }

        /// <summary>
        ///     Tests that logger scope using statement should automatically dispose
        /// </summary>
        [Fact]
        public void LoggerScope_UsingStatement_ShouldAutomaticallyDispose()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope scope;

            using (scope = new LoggerScope("TestScope", stack, () => { }))
            {
                Assert.Single(stack);
            }

            Assert.Empty(stack);
        }

        /// <summary>
        ///     Tests that logger scope multiple scopes should pop in lifo order
        /// </summary>
        [Fact]
        public void LoggerScope_MultipleScopes_ShouldPopInLifoOrder()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope scope1 = new LoggerScope("A", stack, () => { });
            LoggerScope scope2 = new LoggerScope("B", stack, () => { });

            scope2.Dispose();

            Assert.Single(stack);
            Assert.Equal("A", stack.Pop());
        }

        /// <summary>
        ///     Tests that logger scope dispose behavior should handle empty stack
        /// </summary>
        [Fact]
        public void LoggerScope_DisposeBehavior_ShouldHandleEmptyStack()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("TestScope", stack, () => { });
            stack.Pop(); // Remove the scope manually

            scope.Dispose(); // Should not throw
        }

        /// <summary>
        ///     Tests that logger scope scope with object should store object
        /// </summary>
        [Fact]
        public void LoggerScope_ScopeWithObject_ShouldStoreObject()
        {
            Stack<object> stack = new Stack<object>();
            var scopeObject = new {Id = 123, Name = "TestScope"};

            LoggerScope scope = new LoggerScope(scopeObject, stack, () => { });

            Assert.Single(stack);
            Assert.Equal(scopeObject, stack.Peek());
        }

        /// <summary>
        ///     Tests that logger scope scope with number should store number
        /// </summary>
        [Fact]
        public void LoggerScope_ScopeWithNumber_ShouldStoreNumber()
        {
            Stack<object> stack = new Stack<object>();
            int scopeId = 42;

            LoggerScope scope = new LoggerScope(scopeId, stack, () => { });

            Assert.Single(stack);
            Assert.Equal(42, stack.Pop());
        }

        /// <summary>
        ///     Tests that logger scope long scope chain should maintain order
        /// </summary>
        [Fact]
        public void LoggerScope_LongScopeChain_ShouldMaintainOrder()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope[] scopes = new LoggerScope[100];

            for (int i = 0; i < 100; i++)
            {
                scopes[i] = new LoggerScope($"Scope{i}", stack, () => { });
            }

            Assert.Equal(100, stack.Count);

            for (int i = 99; i >= 0; i--)
            {
                scopes[i].Dispose();
                Assert.Equal(i, stack.Count);
            }
        }

        /// <summary>
        ///     Tests that logger scope null scope should be allowed
        /// </summary>
        [Fact]
        public void LoggerScope_NullScope_ShouldBeAllowed()
        {
            Stack<object> stack = new Stack<object>();

            LoggerScope scope = new LoggerScope(null, stack, () => { });

            Assert.Single(stack);
            Assert.Null(stack.Peek());
        }
    }
}