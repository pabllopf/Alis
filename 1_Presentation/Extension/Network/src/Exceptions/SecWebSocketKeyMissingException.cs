

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The sec web socket key missing exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class SecWebSocketKeyMissingException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SecWebSocketKeyMissingException" /> class
        /// </summary>
        public SecWebSocketKeyMissingException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecWebSocketKeyMissingException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public SecWebSocketKeyMissingException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SecWebSocketKeyMissingException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public SecWebSocketKeyMissingException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}