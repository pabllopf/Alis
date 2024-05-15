// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameTest.cs
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
using System.Net.WebSockets;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The web socket frame test class
    /// </summary>
    public class WebSocketFrameTest
    {
        /// <summary>
        /// Tests that web socket frame constructor 1 valid input
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor1_ValidInput()
        {
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);
            
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);
            
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(webSocketOpCode, frame.OpCode);
            Assert.Equal(count, frame.Count);
            Assert.Equal(maskKey, frame.MaskKey);
        }
        
        /// <summary>
        /// Tests that web socket frame constructor 2 valid input
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor2_ValidInput()
        {
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
            string closeStatusDescription = "Test description";
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);
            
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, closeStatus, closeStatusDescription, maskKey);
            
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(webSocketOpCode, frame.OpCode);
            Assert.Equal(count, frame.Count);
            Assert.Equal(closeStatus, frame.CloseStatus);
            Assert.Equal(closeStatusDescription, frame.CloseStatusDescription);
            Assert.Equal(maskKey, frame.MaskKey);
        }
    }
}