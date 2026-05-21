

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The web socket version not supported exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class WebSocketVersionNotSupportedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketVersionNotSupportedException" /> class
        /// </summary>
        public WebSocketVersionNotSupportedException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketVersionNotSupportedException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public WebSocketVersionNotSupportedException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketVersionNotSupportedException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public WebSocketVersionNotSupportedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}