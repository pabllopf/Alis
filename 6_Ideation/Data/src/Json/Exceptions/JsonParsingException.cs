// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonParsingException.cs
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
    ///     Represents errors that occur during JSON parsing operations.
    ///     Thrown by <see cref="Parsing.JsonParser" /> when the input JSON string is malformed,
    ///     contains unexpected characters, or has structural issues such as unterminated strings
    ///     or missing delimiters.
    /// </summary>
    /// <remarks>
    ///     Common scenarios that trigger this exception include:
    ///     - Unterminated JSON strings (missing closing quote)
    ///     - Unterminated JSON structures (unclosed objects or arrays)
    ///     - Missing expected delimiters such as ':' between key and value
    ///     - Invalid escape sequences
    ///     When wrapping a non-parsing exception, the original exception message is included
    ///     in the error message to aid in debugging.
    /// </remarks>
    public sealed class JsonParsingException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonParsingException" /> class
        ///     with a specified error message.
        /// </summary>
        /// <param name="message">The error message that describes the parsing failure and its location.</param>
        public JsonParsingException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonParsingException" /> class
        ///     with a specified error message and a reference to the inner exception that is the
        ///     cause of this exception.
        /// </summary>
        /// <param name="message">The error message that describes the parsing failure.</param>
        /// <param name="innerException">The exception that caused the parsing failure, or null.</param>
        public JsonParsingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}