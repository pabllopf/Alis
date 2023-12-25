// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: PongEventArgs.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Network
{
    /// <summary>
    ///     Pong EventArgs
    /// </summary>
    public class PongEventArgs : EventArgs
    {
        /// <summary>
        ///     Initialises a new instance of the PongEventArgs class
        /// </summary>
        /// <param name="payload">The pong payload must be 125 bytes or less (can be zero bytes)</param>
        public PongEventArgs(ArraySegment<byte> payload) => Payload = payload;

        /// <summary>
        ///     The data extracted from a Pong WebSocket frame
        /// </summary>
        public ArraySegment<byte> Payload { get; }
    }
}