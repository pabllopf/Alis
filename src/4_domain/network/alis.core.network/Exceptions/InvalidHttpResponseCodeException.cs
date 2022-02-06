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
    [Serializable]
    public class InvalidHttpResponseCodeException : Exception
    {
        public InvalidHttpResponseCodeException()
        {
        }

        public InvalidHttpResponseCodeException(string message) : base(message)
        {
        }

        public InvalidHttpResponseCodeException(string responseCode, string responseDetails, string responseHeader) :
            base(responseCode)
        {
            ResponseCode = responseCode;
            ResponseDetails = responseDetails;
            ResponseHeader = responseHeader;
        }

        public InvalidHttpResponseCodeException(string message, Exception inner) : base(message, inner)
        {
        }

        public string ResponseCode { get; private set; }

        public string ResponseHeader { get; private set; }

        public string ResponseDetails { get; private set; }
    }
}