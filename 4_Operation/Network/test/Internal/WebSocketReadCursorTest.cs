// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketReadCursorTest.cs
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
    /// The web socket read cursor test class
    /// </summary>
    public class WebSocketReadCursorTest
    {
        /// <summary>
        /// Tests that web socket read cursor constructor valid input
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Constructor_ValidInput()
        {
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);
            int numBytesRead = 5;
            int numBytesLeftToRead = 5;
            
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, numBytesRead, numBytesLeftToRead);
            
            Assert.Equal(frame, cursor.WebSocketFrame);
            Assert.Equal(numBytesRead, cursor.NumBytesRead);
            Assert.Equal(numBytesLeftToRead, cursor.NumBytesLeftToRead);
        }
    }
}