// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameCommonTest.cs
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
using Alis.Core.Network.Exceptions;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The web socket frame common test class
    /// </summary>
    public class WebSocketFrameCommonTest
    {
        /// <summary>
        /// Tests that toggle mask should not throw exception when mask key is valid
        /// </summary>
        [Fact]
        public void ToggleMask_ShouldNotThrowException_WhenMaskKeyIsValid()
        {
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[WebSocketFrameCommon.MaskKeyLength]);
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[10]);
            
            Exception exception = Record.Exception(() => WebSocketFrameCommon.ToggleMask(maskKey, payload));
            
            Assert.Null(exception);
        }
        
        /// <summary>
        /// Tests that toggle mask should throw exception when mask key is invalid
        /// </summary>
        [Fact]
        public void ToggleMask_ShouldThrowException_WhenMaskKeyIsInvalid()
        {
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[WebSocketFrameCommon.MaskKeyLength - 1]);
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[10]);
            
            Assert.Throws<MaskKeyLengthException>(() => WebSocketFrameCommon.ToggleMask(maskKey, payload));
        }
        
        /// <summary>
        /// Tests that toggle mask should change payload when called
        /// </summary>
        [Fact]
        public void ToggleMask_ShouldChangePayload_WhenCalled()
        {
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[WebSocketFrameCommon.MaskKeyLength] {1, 2, 3, 4});
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[4] {1, 2, 3, 4});
            ArraySegment<byte> expectedPayload = new ArraySegment<byte>(new byte[4] {0, 0, 0, 0});
            
            WebSocketFrameCommon.ToggleMask(maskKey, payload);
            
            Assert.Equal(expectedPayload, payload);
        }
    }
}