// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsTest.cs
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
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The events test class
    /// </summary>
    public class EventsTest
    {
        /// <summary>
        /// Tests that client connecting to ip address valid input
        /// </summary>
        [Fact]
        public void ClientConnectingToIpAddress_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string ipAddress = "127.0.0.1";
            int port = 8080;
            
            Events.Log.ClientConnectingToIpAddress(guid, ipAddress, port);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that client connecting to host valid input
        /// </summary>
        [Fact]
        public void ClientConnectingToHost_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            string host = "localhost";
            int port = 8080;
            
            Events.Log.ClientConnectingToHost(guid, host, port);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that attemting to secure ssl connection valid input
        /// </summary>
        [Fact]
        public void AttemtingToSecureSslConnection_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.AttemtingToSecureSslConnection(guid);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that connection secured valid input
        /// </summary>
        [Fact]
        public void ConnectionSecured_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionSecured(guid);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that connection not secure valid input
        /// </summary>
        [Fact]
        public void ConnectionNotSecure_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            
            Events.Log.ConnectionNotSecure(guid);
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
    }
}