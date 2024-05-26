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

using Alis.Builder.Core.Ecs.System.Setting.Network;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.System.Setting.Network
{
    /// <summary>
    ///     The network setting class
    /// </summary>
    /// <seealso cref="INetworkSetting" />
    public class NetworkSetting : 
        INetworkSetting,
        IBuilder<NetworkSettingBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSetting"/> class
        /// </summary>
        public NetworkSetting()
        {
            Port = 8080;
            Ip = "127.0.0.1";
            Host = "localhost";
            Protocol = "http";
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSetting"/> class
        /// </summary>
        /// <param name="port">The port</param>
        /// <param name="ip">The ip</param>
        /// <param name="host">The host</param>
        /// <param name="protocol">The protocol</param>
        [JsonConstructor]
        public NetworkSetting(int port, string ip, string host, string protocol)
        {
            Port = port;
            Ip = ip;
            Host = host;
            Protocol = protocol;
        }
        
        /// <summary>
        /// Gets or sets the value of the port
        /// </summary>
        [JsonPropertyName("_Port_")]
        public int Port { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the ip
        /// </summary>
        [JsonPropertyName("_Ip_")]
        public string Ip { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the host
        /// </summary>
        [JsonPropertyName("_Host_")]
        public string Host { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the protocol
        /// </summary>
        [JsonPropertyName("_Protocol_")]
        public string Protocol { get; set; }
        
        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The network setting builder</returns>
        public NetworkSettingBuilder Builder() => new NetworkSettingBuilder();
    }
}