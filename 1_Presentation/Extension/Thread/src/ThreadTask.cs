

using System;
using System.Threading;

namespace Alis.Extension.Thread
{
    /// <summary>
    ///     The thread task class
    /// </summary>
    public class ThreadTask
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadTask" /> class
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="token"></param>
        public ThreadTask(Action<CancellationToken> action, CancellationToken token)
        {
            Action = action;
            Token = token;
        }

        /// <summary>
        ///     Gets or sets the value of the action
        /// </summary>
        private Action<CancellationToken> Action { get; }

        /// <summary>
        ///     Gets or sets the value of the token
        /// </summary>
        private CancellationToken Token { get; }

        /// <summary>
        ///     Executes this instance
        /// </summary>
        public void Execute(CancellationToken token)
        {
            Action(Token);
        }
    }
}