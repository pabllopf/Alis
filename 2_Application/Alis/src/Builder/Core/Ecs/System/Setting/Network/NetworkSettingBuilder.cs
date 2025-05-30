// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSettingBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Network;

namespace Alis.Builder.Core.Ecs.System.Setting.Network
{
    /// <summary>
    ///     The audio setting builder class
    /// </summary>
    public class NetworkSettingBuilder :
        IBuild<NetworkSetting>
    {
        /// <summary>
        ///     The audio setting
        /// </summary>
        private readonly NetworkSetting networkSetting = new NetworkSetting();

        
        /// <summary>
        /// Ips the ip
        /// </summary>
        /// <param name="ip">The ip</param>
        /// <returns>The network setting builder</returns>
        public NetworkSettingBuilder Ip(string ip)
        {
            return this;
        }
        
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio setting</returns>
        public NetworkSetting Build() => networkSetting;
    }
}