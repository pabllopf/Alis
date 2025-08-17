// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSetting.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems.Configuration.Network
{
    /// <summary>
    /// The network setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NetworkSetting(
        int port = 8080,
        string ip = "127.0.0.1",
        string host = "localhost",
        string protocol = "http") : INetworkSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSetting"/> class
        /// </summary>
        public NetworkSetting() : this(port: 8080, ip: "127.0.0.1", host: "localhost", protocol: "http")
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the port
        /// </summary>
        public int Port { get; set; } = port;
        /// <summary>
        /// Gets or sets the value of the ip
        /// </summary>
        public string Ip { get; set; } = ip;
        /// <summary>
        /// Gets or sets the value of the host
        /// </summary>
        public string Host { get; set; } = host;
        /// <summary>
        /// Gets or sets the value of the protocol
        /// </summary>
        public string Protocol { get; set; } = protocol;
    }
}