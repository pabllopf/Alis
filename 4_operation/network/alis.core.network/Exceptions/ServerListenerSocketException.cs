// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ServerListenerSocketException.cs
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
    ///     The server listener socket exception class
    /// </summary>
    /// <seealso cref="Exception" />
    [Serializable]
    public class ServerListenerSocketException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ServerListenerSocketException" /> class
        /// </summary>
        public ServerListenerSocketException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ServerListenerSocketException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public ServerListenerSocketException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ServerListenerSocketException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner</param>
        public ServerListenerSocketException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}