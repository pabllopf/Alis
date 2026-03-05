using System;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network error event arguments
    /// </summary>
    public class NetworkErrorEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes error event args
        /// </summary>
        public NetworkErrorEventArgs(string message, Exception exception = null)
        {
            Message = message;
            Exception = exception;
        }

        /// <summary>
        ///     Gets error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Gets exception
        /// </summary>
        public Exception Exception { get; }
    }
}