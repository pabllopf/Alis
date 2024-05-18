// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameCommon.cs
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

namespace Alis.Core.Network.Internal
{
    /// <summary>
    ///     The web socket frame common class
    /// </summary>
    internal static class WebSocketFrameCommon
    {
        /// <summary>
        ///     The mask key length
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
            ValidateMaskKey(maskKey);
            
            byte[] buffer = payload.Array;
            byte[] maskKeyArray = maskKey.Array;
            int payloadOffset = payload.Offset;
            int payloadCountPlusOffset = payload.Count + payloadOffset;
            int maskKeyOffset = maskKey.Offset;
            
            ApplyMaskKey(buffer, maskKeyArray, payloadOffset, payloadCountPlusOffset, maskKeyOffset);
        }
        
        /// <summary>
        /// Validates the mask key using the specified mask key
        /// </summary>
        /// <param name="maskKey">The mask key</param>
        /// <exception cref="MaskKeyLengthException">MaskKey key must be {MaskKeyLength} bytes</exception>
        internal static void ValidateMaskKey(ArraySegment<byte> maskKey)
        {
            if (maskKey.Count != MaskKeyLength)
            {
                throw new MaskKeyLengthException($"MaskKey key must be {MaskKeyLength} bytes");
            }
        }
        
        /// <summary>
        /// Applies the mask key using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="maskKeyArray">The mask key array</param>
        /// <param name="payloadOffset">The payload offset</param>
        /// <param name="payloadCountPlusOffset">The payload count plus offset</param>
        /// <param name="maskKeyOffset">The mask key offset</param>
        internal static void ApplyMaskKey(byte[] buffer, byte[] maskKeyArray, int payloadOffset, int payloadCountPlusOffset, int maskKeyOffset)
        {
            for (int i = payloadOffset; i < payloadCountPlusOffset; i++)
            {
                ApplyMaskKeyAtIndex(buffer, maskKeyArray, i, payloadOffset, maskKeyOffset);
            }
        }
        
        /// <summary>
        /// Applies the mask key at index using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="maskKeyArray">The mask key array</param>
        /// <param name="i">The </param>
        /// <param name="payloadOffset">The payload offset</param>
        /// <param name="maskKeyOffset">The mask key offset</param>
        internal static void ApplyMaskKeyAtIndex(byte[] buffer, byte[] maskKeyArray, int i, int payloadOffset, int maskKeyOffset)
        {
            int payloadIndex = i - payloadOffset; // index should start at zero
            int maskKeyIndex = maskKeyOffset + payloadIndex % MaskKeyLength;
            if (buffer != null && maskKeyArray != null)
            {
                buffer[i] = (byte) (buffer[i] ^ maskKeyArray[maskKeyIndex]);
            }
        }
        
        
    }
}