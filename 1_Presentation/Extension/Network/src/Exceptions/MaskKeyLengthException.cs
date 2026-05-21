

using System;

namespace Alis.Extension.Network.Exceptions
{
    /// <summary>
    ///     The mask key length exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public partial class MaskKeyLengthException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaskKeyLengthException" /> class
        /// </summary>
        public MaskKeyLengthException() : base("Mask key length must be 4 bytes.")
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MaskKeyLengthException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public MaskKeyLengthException(string message) : base(message)
        {
        }
    }
}