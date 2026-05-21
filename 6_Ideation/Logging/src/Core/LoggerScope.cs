

using System;
using System.Collections.Generic;

namespace Alis.Core.Aspect.Logging.Core
{
    /// <summary>
    ///     Manages scope context for a logger instance using a stack-based approach.
    ///     Scopes are used to group related log entries and provide context information.
    ///     Thread-safe: Uses a stack per context value.
    /// </summary>
    internal sealed class LoggerScope : IDisposable
    {
        /// <summary>
        ///     The on dispose
        /// </summary>
        private readonly Action _onDispose;

        /// <summary>
        ///     The scope stack
        /// </summary>
        private readonly Stack<object> _scopeStack;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the LoggerScope class.
        /// </summary>
        /// <param name="scope">The scope to push.</param>
        /// <param name="scopeStack">The shared scope stack.</param>
        /// <param name="onDispose">Action to invoke when disposed.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="scopeStack"/> is null.</exception>
        public LoggerScope(object scope, Stack<object> scopeStack, Action onDispose)
        {
            _scopeStack = scopeStack ?? throw new ArgumentNullException(nameof(scopeStack));
            _onDispose = onDispose;
            _scopeStack.Push(scope);
        }


        /// <summary>
        ///     Pops the scope from the stack and invokes the dispose action.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            if (_scopeStack.Count > 0)
            {
                _scopeStack.Pop();
            }

            _onDispose?.Invoke();
        }
    }
}