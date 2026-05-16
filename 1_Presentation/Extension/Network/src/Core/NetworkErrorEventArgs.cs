// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkErrorEventArgs.cs
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

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network error event arguments
    /// </summary>
    public class NetworkErrorEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes error event args
        /// </summary>
        /// <param name="message">Description of the error</param>
        /// <param name="exception">Optional exception associated with the error</param>
        public NetworkErrorEventArgs(string message, Exception exception = null)
        {
            Message = message;
            Exception = exception;
        }

        /// <summary>
        ///     Gets error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Gets exception
        /// </summary>
        public Exception Exception { get; }
    }
}