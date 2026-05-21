// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonSerializationException.cs
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