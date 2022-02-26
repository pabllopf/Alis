// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   InvalidHttpResponseCodeException.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Network.Exceptions
{
    /// <summary>
    /// The invalid http response code exception class
    /// </summary>
    /// <seealso cref="Exception"/>
    [Serializable]
    public class InvalidHttpResponseCodeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHttpResponseCodeException"/> class
        /// </summary>
        public InvalidHttpResponseCodeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHttpResponseCodeException"/> class
        /// </summary>
        /// <param name="message">The message</param>
        public InvalidHttpResponseCodeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHttpResponseCodeException"/> class
        /// </summary>
        /// <param name="responseCode">The response code</param>
        /// <param name="responseDetails">The response details</param>
        /// <param name="responseHeader">The response header</param>
        public InvalidHttpResponseCodeException(string responseCode, string responseDetails, string responseHeader) :
            base(responseCode)
        {
            ResponseCode = responseCode;
            ResponseDetails = responseDetails;
            ResponseHeader = responseHeader;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHttpResponseCodeException"/> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public InvalidHttpResponseCodeException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Gets or sets the value of the response code
        /// </summary>
        public string ResponseCode { get; private set; }

        /// <summary>
        /// Gets or sets the value of the response header
        /// </summary>
        public string ResponseHeader { get; private set; }

        /// <summary>
        /// Gets or sets the value of the response details
        /// </summary>
        public string ResponseDetails { get; private set; }
    }
}