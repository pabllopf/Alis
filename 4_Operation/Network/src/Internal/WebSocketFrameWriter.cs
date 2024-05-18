// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameWriter.cs
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
using System.Security.Cryptography;

namespace Alis.Core.Network.Internal
{
    // see http://tools.ietf.org/html/rfc6455 for specification
    // see fragmentation section for sending multi part messages
    // EXAMPLE: For a text message sent as three fragments, 
    //   the first fragment would have an opcode of TextFrame and isLastFrame false,
    //   the second fragment would have an opcode of ContinuationFrame and isLastFrame false,
    //   the third fragment would have an opcode of ContinuationFrame and isLastFrame true.
    /// <summary>
    ///     The web socket frame writer class
    /// </summary>
    internal static class WebSocketFrameWriter
    {
        /// <summary>
        ///     No async await stuff here because we are dealing with a memory stream
        /// </summary>
        /// <param name="opCode">The web socket opcode</param>
        /// <param name="fromPayload">Array segment to get payload data from</param>
        /// <param name="toStream">Stream to write to</param>
        /// <param name="isLastFrame">True is this is the last frame in this message (usually true)</param>
        /// <param name="isClient"></param>
        public static void Write(WebSocketOpCode opCode, ArraySegment<byte> fromPayload, MemoryStream toStream,
            bool isLastFrame, bool isClient)
        {
            byte finBitSetAsByte = isLastFrame ? (byte) 0x80 : (byte) 0x00;
            byte byte1 = (byte) (finBitSetAsByte | (byte) opCode);
            toStream.WriteByte(byte1);
            
            WritePayloadLength(fromPayload, toStream, isClient);
            
            if (isClient)
            {
                WriteMaskedPayload(fromPayload, toStream);
            }
            else
            {
                toStream.Write(fromPayload.Array, fromPayload.Offset, fromPayload.Count);
            }
        }
        
        /// <summary>
        /// Writes the payload length using the specified from payload
        /// </summary>
        /// <param name="fromPayload">The from payload</param>
        /// <param name="toStream">The to stream</param>
        /// <param name="isClient">The is client</param>
       internal static void WritePayloadLength(ArraySegment<byte> fromPayload, MemoryStream toStream, bool isClient)
        {
            byte maskBitSetAsByte = isClient ? (byte)0x80 : (byte)0x00;

            if (fromPayload.Count < 126)
            {
                WriteByteWithPayloadCount(maskBitSetAsByte, fromPayload.Count, toStream);
            }
            else
            {
                WriteByteWithPayloadCount(maskBitSetAsByte, DeterminePayloadCount(fromPayload), toStream);
                WritePayloadData(fromPayload, toStream);
            }
        }

        /// <summary>
        /// Determines the payload count using the specified from payload
        /// </summary>
        /// <param name="fromPayload">The from payload</param>
        /// <returns>The int</returns>
        internal static int DeterminePayloadCount(ArraySegment<byte> fromPayload)
        {
            if (fromPayload.Count <= ushort.MaxValue)
            {
                return 126;
            }
            else
            {
                return 127;
            }
        }

        /// <summary>
        /// Writes the payload data using the specified from payload
        /// </summary>
        /// <param name="fromPayload">The from payload</param>
        /// <param name="toStream">The to stream</param>
        internal static void WritePayloadData(ArraySegment<byte> fromPayload, MemoryStream toStream)
        {
            if (fromPayload.Count <= ushort.MaxValue)
            {
                BinaryReaderWriter.WriteUShort((ushort)fromPayload.Count, toStream, false);
            }
            else
            {
                BinaryReaderWriter.WriteULong((ulong)fromPayload.Count, toStream, false);
            }
        }

        /// <summary>
        /// Writes the byte with payload count using the specified mask bit set as byte
        /// </summary>
        /// <param name="maskBitSetAsByte">The mask bit set as byte</param>
        /// <param name="payloadCount">The payload count</param>
        /// <param name="toStream">The to stream</param>
        internal static void WriteByteWithPayloadCount(byte maskBitSetAsByte, int payloadCount, MemoryStream toStream)
        {
            byte byte2 = (byte)(maskBitSetAsByte | payloadCount);
            toStream.WriteByte(byte2);
        }
        
        /// <summary>
        /// Writes the masked payload using the specified from payload
        /// </summary>
        /// <param name="fromPayload">The from payload</param>
        /// <param name="toStream">The to stream</param>
        internal static void WriteMaskedPayload(ArraySegment<byte> fromPayload, MemoryStream toStream)
        {
            byte[] maskKey = new byte[WebSocketFrameCommon.MaskKeyLength];
            RandomNumberGenerator rand = RandomNumberGenerator.Create();
            rand.GetBytes(maskKey);
            toStream.Write(maskKey, 0, maskKey.Length);
            
            ArraySegment<byte> maskKeyArraySegment = new ArraySegment<byte>(maskKey, 0, maskKey.Length);
            WebSocketFrameCommon.ToggleMask(maskKeyArraySegment, fromPayload);
            
            toStream.Write(fromPayload.Array, fromPayload.Offset, fromPayload.Count);
        }
    }
}