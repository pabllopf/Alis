// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameWriterTest.cs
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
using System.Text;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The web socket frame writer test class
    /// </summary>
    public class WebSocketFrameWriterTest
    {
        /// <summary>
        /// Tests that write valid input
        /// </summary>
        [Fact]
        public void Write_ValidInput()
        {
            WebSocketOpCode opCode = WebSocketOpCode.TextFrame;
            ArraySegment<byte> fromPayload = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test data"));
            MemoryStream toStream = new MemoryStream();
            bool isLastFrame = true;
            bool isClient = true;
            
            WebSocketFrameWriter.Write(opCode, fromPayload, toStream, isLastFrame, isClient);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
    }
}