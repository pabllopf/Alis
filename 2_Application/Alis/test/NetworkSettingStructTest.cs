// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSettingStructTest.cs
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

using Alis.Core.Ecs.Systems.Configuration.Network;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The network setting struct test class
    /// </summary>
    public class NetworkSettingStructTest
    {
        /// <summary>
        /// Tests that default values should be correct
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            NetworkSetting setting = new NetworkSetting();
            Assert.Equal(8080, setting.Port);
            Assert.Equal("127.0.0.1", setting.Ip);
            Assert.Equal("localhost", setting.Host);
            Assert.Equal("http", setting.Protocol);
        }

        /// <summary>
        /// Tests that custom constructor should store values
        /// </summary>
        [Fact]
        public void CustomConstructor_ShouldStoreValues()
        {
            NetworkSetting setting = new NetworkSetting(3000, "192.168.1.1", "myserver", "https");
            Assert.Equal(3000, setting.Port);
            Assert.Equal("192.168.1.1", setting.Ip);
            Assert.Equal("myserver", setting.Host);
            Assert.Equal("https", setting.Protocol);
        }

        /// <summary>
        /// Tests that should implement i network setting
        /// </summary>
        [Fact]
        public void ShouldImplementINetworkSetting()
        {
            NetworkSetting setting = new NetworkSetting();
            Assert.IsAssignableFrom<INetworkSetting>(setting);
        }
    }
}
