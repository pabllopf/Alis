// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WebSocketFrame.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Net.WebSockets;

namespace Alis.Core.Multiplayer.Internal
{
    internal class WebSocketFrame
    {
        public WebSocketFrame(bool isFinBitSet, WebSocketOpCode webSocketOpCode, int count, ArraySegment<byte> maskKey)
        {
            IsFinBitSet = isFinBitSet;
            OpCode = webSocketOpCode;
            Count = count;
            MaskKey = maskKey;
        }

        public WebSocketFrame(bool isFinBitSet, WebSocketOpCode webSocketOpCode, int count,
            WebSocketCloseStatus closeStatus, string closeStatusDescription, ArraySegment<byte> maskKey) : this(
            isFinBitSet, webSocketOpCode, count, maskKey)
        {
            CloseStatus = closeStatus;
            CloseStatusDescription = closeStatusDescription;
        }

        public bool IsFinBitSet { get; }

        public WebSocketOpCode OpCode { get; }

        public int Count { get; }

        public WebSocketCloseStatus? CloseStatus { get; }

        public string CloseStatusDescription { get; }

        public ArraySegment<byte> MaskKey { get; }
    }
}