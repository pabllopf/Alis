using System;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    /// The xml fragment exception class
    /// </summary>
    /// <seealso cref="Exception"/>
    internal class XMLFragmentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XMLFragmentException"/> class
        /// </summary>
        /// <param name="message">The message</param>
        public XMLFragmentException(string message)
            : base(message)
        {
        }
    }
}