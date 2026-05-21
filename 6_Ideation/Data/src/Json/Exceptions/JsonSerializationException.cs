

using System;

namespace Alis.Core.Aspect.Data.Json.Exceptions
{
    /// <summary>
    ///     Represents errors that occur during JSON serialization operations.
    ///     Thrown by the <see cref="Serialization.JsonSerializer" /> when an object cannot be
    ///     successfully converted to its JSON string representation, or when an underlying
    ///     exception is caught during the serialization process.
    /// </summary>
    /// <remarks>
    ///     This exception wraps both direct serialization failures and unexpected exceptions
    ///     that occur during property enumeration or string building. When wrapping an inner
    ///     exception, the message includes the type name of the object being serialized and
    ///     the inner exception's message to aid in debugging.
    /// </remarks>
    public sealed class JsonSerializationException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonSerializationException" /> class
        ///     with a specified error message.
        /// </summary>
        /// <param name="message">The error message that describes the serialization failure.</param>
        public JsonSerializationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonSerializationException" /> class
        ///     with a specified error message and a reference to the inner exception that is the
        ///     cause of this exception.
        /// </summary>
        /// <param name="message">The error message that describes the serialization failure.</param>
        /// <param name="innerException">The exception that caused the serialization failure, or null.</param>
        public JsonSerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}