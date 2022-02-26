// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WebSocketFrameCommon.cs
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

namespace Alis.Core.Network.Internal
{
    /// <summary>
    /// The web socket frame common class
    /// </summary>
    internal static class WebSocketFrameCommon
    {
        /// <summary>
        /// The mask key length
        /// </summary>
        public const int MaskKeyLength = 4;

        /// <summary>
        ///     Mutate payload with the mask key
        ///     This is a reversible process
        ///     If you apply this to masked data it will be unmasked and visa versa
        /// </summary>
        /// <param name="maskKey">The 4 byte mask key</param>
        /// <param name="payload">The payload to mutate</param>
        public static void ToggleMask(ArraySegment<byte> maskKey, ArraySegment<byte> payload)
        {
            if (maskKey.Count != MaskKeyLength)
            {
                throw new Exception($"MaskKey key must be {MaskKeyLength} bytes");
            }

            byte[] buffer = payload.Array;
            byte[] maskKeyArray = maskKey.Array;
            int payloadOffset = payload.Offset;
            int payloadCountPlusOffset = payload.Count + payloadOffset;
            int maskKeyOffset = maskKey.Offset;

            // apply the mask key (this is a reversible process so no need to copy the payload)
            // NOTE: this is a hot function
            // TODO: make this faster
            for (int i = payloadOffset; i < payloadCountPlusOffset; i++)
            {
                int payloadIndex = i - payloadOffset; // index should start at zero
                int maskKeyIndex = maskKeyOffset + payloadIndex % MaskKeyLength;
                buffer[i] = (byte) (buffer[i] ^ maskKeyArray[maskKeyIndex]);
            }
        }
    }
}