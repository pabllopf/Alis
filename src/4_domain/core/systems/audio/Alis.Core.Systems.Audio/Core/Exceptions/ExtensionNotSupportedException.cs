// 

using System;

namespace Alis.Core.Systems.Audio.Core.Exceptions
{
    /// <summary>
    ///     Represents exceptions related to API extensions.
    /// </summary>
    public class ExtensionNotSupportedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExtensionNotSupportedException" /> class.
        /// </summary>
        /// <param name="extension">The name of the extension.</param>
        public ExtensionNotSupportedException(string extension) => Extension = extension;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExtensionNotSupportedException" /> class.
        /// </summary>
        /// <param name="message">The error message of the ExtensionNotSupportedException.</param>
        /// <param name="extension">The name of the extension.</param>
        public ExtensionNotSupportedException(string message, string extension)
            : base(message) =>
            Extension = extension;

        /// <summary>
        ///     Gets the name of the extension.
        /// </summary>
        public string Extension { get; }
    }
}