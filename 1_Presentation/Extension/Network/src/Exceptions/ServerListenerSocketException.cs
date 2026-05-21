

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The server listener socket exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class ServerListenerSocketException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ServerListenerSocketException" /> class
        /// </summary>
        public ServerListenerSocketException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ServerListenerSocketException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public ServerListenerSocketException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ServerListenerSocketException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public ServerListenerSocketException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}