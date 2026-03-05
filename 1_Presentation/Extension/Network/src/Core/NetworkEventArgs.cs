// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkEventArgs.cs
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
    ///     Server message event arguments
    /// </summary>
    public class ServerMessageEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes server message event args
        /// </summary>
        public ServerMessageEventArgs(string channel, string message)
        {
            Channel = channel;
            Message = message;
        }

        /// <summary>
        ///     Gets channel
        /// </summary>
        public string Channel { get; }

        /// <summary>
        ///     Gets message
        /// </summary>
        public string Message { get; }
    }

    /// <summary>
    ///     Client connection event arguments
    /// </summary>
    public class ClientConnectionEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes client connection event args
        /// </summary>
        public ClientConnectionEventArgs(string clientId)
        {
            ClientId = clientId;
        }

        /// <summary>
        ///     Gets client ID
        /// </summary>
        public string ClientId { get; }
    }

    /// <summary>
    ///     Client disconnection event arguments
    /// </summary>
    public class ClientDisconnectionEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes client disconnection event args
        /// </summary>
        public ClientDisconnectionEventArgs(string clientId, string reason = null)
        {
            ClientId = clientId;
            Reason = reason;
        }

        /// <summary>
        ///     Gets client ID
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets disconnection reason
        /// </summary>
        public string Reason { get; }
    }
}

