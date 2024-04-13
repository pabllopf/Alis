// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonException.cs
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
using System.Globalization;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     The exception that is thrown when a JSON error occurs.
    /// </summary>
    [Serializable]
    public class JsonException : Exception
    {
        /// <summary>
        ///     The error prefix.
        /// </summary>
        public const string Prefix = "JSO";
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonException" /> class.
        /// </summary>
        public JsonException()
            : base(Prefix + "0001: JSON exception.")
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public JsonException(string message)
            : base(message)
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (
        ///     <see langword="Nothing" /> in Visual Basic) if no inner exception is specified.
        /// </param>
        public JsonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonException" /> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        public JsonException(Exception innerException)
            : base(null, innerException)
        {
        }
        
        /// <summary>
        ///     Gets the error code.
        /// </summary>
        /// <value>
        ///     The error code.
        /// </value>
        public int Code => GetCode(Message);
        
        /// <summary>
        ///     Gets the error code.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The error code.</returns>
        public static int GetCode(string message)
        {
            if (message == null)
            {
                return -1;
            }
            
            if (!message.StartsWith(Prefix, StringComparison.Ordinal))
            {
                return -1;
            }
            
            int pos = message.IndexOf(':', Prefix.Length);
            if (pos < 0)
            {
                return -1;
            }
            
            return int.TryParse(message.Substring(Prefix.Length, pos - Prefix.Length), NumberStyles.None, CultureInfo.InvariantCulture, out int i) ? i : -1;
        }
    }
}