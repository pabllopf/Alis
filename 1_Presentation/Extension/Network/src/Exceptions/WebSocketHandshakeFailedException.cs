

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The web socket handshake failed exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class WebSocketHandshakeFailedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketHandshakeFailedException" /> class
        /// </summary>
        public WebSocketHandshakeFailedException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketHandshakeFailedException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public WebSocketHandshakeFailedException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketHandshakeFailedException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public WebSocketHandshakeFailedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}