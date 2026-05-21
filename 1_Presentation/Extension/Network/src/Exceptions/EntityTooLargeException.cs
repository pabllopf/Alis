

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The entity too large exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class EntityTooLargeException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityTooLargeException" /> class
        /// </summary>
        public EntityTooLargeException()
        {
        }

        /// <summary>
        ///     Http header too large to fit in buffer
        /// </summary>
        public EntityTooLargeException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityTooLargeException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public EntityTooLargeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}