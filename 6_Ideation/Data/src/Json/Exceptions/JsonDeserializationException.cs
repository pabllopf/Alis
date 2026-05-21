// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonDeserializationException.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Aspect.Data.Json.Exceptions
{
    /// <summary>
    ///     Represents errors that occur during JSON deserialization operations.
    ///     Thrown by <see cref="Deserialization.JsonDeserializer" /> when a JSON string cannot be
    ///     successfully converted into the target object type, or when an underlying exception
    ///     (such as a parsing failure) occurs during the deserialization process.
    /// </summary>
    /// <remarks>
    ///     This exception can be triggered by:
    ///     - Invalid or malformed JSON input that cannot be parsed
    ///     - Failures in <see cref="IJsonDesSerializable{T}.CreateFromProperties" /> when
    ///     populating an object from the parsed property dictionary
    ///     - Unexpected exceptions during the deserialization pipeline
    ///     When wrapping an inner exception, the message includes the target type name and
    ///     the inner exception's message to aid in debugging.
    /// </remarks>
    public sealed class JsonDeserializationException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonDeserializationException" /> class
        ///     with a specified error message.
        /// </summary>
        /// <param name="message">The error message that describes the deserialization failure.</param>
        public JsonDeserializationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonDeserializationException" /> class
        ///     with a specified error message and a reference to the inner exception that is the
        ///     cause of this exception.
        /// </summary>
        /// <param name="message">The error message that describes the deserialization failure.</param>
        /// <param name="innerException">The exception that caused the deserialization failure, or null.</param>
        public JsonDeserializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}