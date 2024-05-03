// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSettingTest.cs
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
using Alis.Core.Ecs.System.Setting.Network;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Setting.Network
{
    /// <summary>
    /// The network setting test class
    /// </summary>
    public class NetworkSettingTest
    {
        /// <summary>
        /// Tests that test network setting port
        /// </summary>
        [Fact]
        public void Test_NetworkSetting_Port()
        {
            // Arrange
            NetworkSetting networkSetting = new NetworkSetting();
            
            // Act
            networkSetting.Port = 8080;
            int result = networkSetting.Port;
            
            // Assert
            Assert.NotNull(networkSetting);
            Assert.Equal(8080, result);
        }
        
        /// <summary>
        /// Tests that test network setting ip
        /// </summary>
        [Fact]
        public void Test_NetworkSetting_Ip()
        {
            // Arrange
            NetworkSetting networkSetting = new NetworkSetting();
            
            // Act
            networkSetting.Ip = "192.168.1.1";
            string result = networkSetting.Ip;
            
            // Assert
            Assert.NotNull(networkSetting);
            Assert.Equal("192.168.1.1", result);
        }
        
        /// <summary>
        /// Tests that test network setting host
        /// </summary>
        [Fact]
        public void Test_NetworkSetting_Host()
        {
            // Arrange
            NetworkSetting networkSetting = new NetworkSetting();
            
            // Act
            networkSetting.Host = "localhost";
            string result = networkSetting.Host;
            
            // Assert
            Assert.NotNull(networkSetting);
            Assert.Equal("localhost", result);
        }
        
        /// <summary>
        /// Tests that test network setting protocol
        /// </summary>
        [Fact]
        public void Test_NetworkSetting_Protocol()
        {
            // Arrange
            NetworkSetting networkSetting = new NetworkSetting();
            
            // Act
            networkSetting.Protocol = "TCP";
            string result = networkSetting.Protocol;
            
            // Assert
            Assert.NotNull(networkSetting);
            Assert.Equal("TCP", result);
        }
        
        /// <summary>
        /// Tests that test network setting builder
        /// </summary>
        [Fact]
        public void Test_NetworkSetting_Builder()
        {
            // Arrange
            NetworkSetting networkSetting = new NetworkSetting();
            
            // Act
            NetworkSettingBuilder result = networkSetting.Builder();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkSettingBuilder>(result);
        }
    }
}