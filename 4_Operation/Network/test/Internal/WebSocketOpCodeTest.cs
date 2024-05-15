// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketOpCodeTest.cs
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

using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The web socket op code test class
    /// </summary>
    public class WebSocketOpCodeTest
    {
        /// <summary>
        /// Tests that web socket op code values
        /// </summary>
        [Fact]
        public void WebSocketOpCode_Values()
        {
            Assert.Equal(0, (int) WebSocketOpCode.ContinuationFrame);
            Assert.Equal(1, (int) WebSocketOpCode.TextFrame);
            Assert.Equal(2, (int) WebSocketOpCode.BinaryFrame);
            Assert.Equal(8, (int) WebSocketOpCode.ConnectionClose);
            Assert.Equal(9, (int) WebSocketOpCode.Ping);
            Assert.Equal(10, (int) WebSocketOpCode.Pong);
        }
    }
}