

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The web socket buffer overflow exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class WebSocketBufferOverflowException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketBufferOverflowException" /> class
        /// </summary>
        public WebSocketBufferOverflowException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketBufferOverflowException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public WebSocketBufferOverflowException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketBufferOverflowException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public WebSocketBufferOverflowException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}