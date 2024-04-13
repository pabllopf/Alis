// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketOpCode.cs
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

namespace Alis.Core.Network.Internal
{
    /// <summary>
    ///     The web socket op code enum
    /// </summary>
    internal enum WebSocketOpCode
    {
        /// <summary>
        ///     The continuation frame web socket op code
        /// </summary>
        ContinuationFrame = 0,
        
        /// <summary>
        ///     The text frame web socket op code
        /// </summary>
        TextFrame = 1,
        
        /// <summary>
        ///     The binary frame web socket op code
        /// </summary>
        BinaryFrame = 2,
        
        /// <summary>
        ///     The connection close web socket op code
        /// </summary>
        ConnectionClose = 8,
        
        /// <summary>
        ///     The ping web socket op code
        /// </summary>
        Ping = 9,
        
        /// <summary>
        ///     The pong web socket op code
        /// </summary>
        Pong = 10
    }
}