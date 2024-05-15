// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketServerFactoryTest.cs
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
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The web socket server factory test class
    /// </summary>
    public class WebSocketServerFactoryTest
    {
        /// <summary>
        /// Tests that web socket server factory read http header from stream
        /// </summary>
        [Fact]
        public async Task WebSocketServerFactory_ReadHttpHeaderFromStreamAsync()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("GET / HTTP/1.1\r\nUpgrade: websocket\r\n\r\n"));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);
            Assert.NotNull(context);
            Assert.True(context.IsWebSocketRequest);
        }
    }
}