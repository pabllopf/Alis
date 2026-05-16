// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClientDisconnectionEventArgs.cs
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
    ///     Client disconnection event arguments
    /// </summary>
    public class ClientDisconnectionEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes client disconnection event args
        /// </summary>
        /// <param name="clientId">The unique identifier of the disconnected client</param>
        /// <param name="reason">Optional reason for the disconnection</param>
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