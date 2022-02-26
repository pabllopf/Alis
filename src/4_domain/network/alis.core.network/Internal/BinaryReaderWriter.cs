// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BinaryReaderWriter.cs
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
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Network.Internal
{
    /// <summary>
    /// The binary reader writer class
    /// </summary>
    internal class BinaryReaderWriter
    {
        /// <summary>
        /// Reads the exactly using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <param name="stream">The stream</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="EndOfStreamException"></exception>
        /// <exception cref="InternalBufferOverflowException">Unable to read {length} bytes into buffer (offset: {buffer.Offset} size: {buffer.Count}). Use a larger read buffer</exception>
        public static async Task ReadExactly(int length, Stream stream, ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            if (length == 0)
            {
                return;
            }

            if (buffer.Count < length)
            {
                // This will happen if the calling function supplied a buffer that was too small to fit the payload of the websocket frame.
                // Note that this can happen on the close handshake where the message size can be larger than the regular payload
                throw new InternalBufferOverflowException(
                    $"Unable to read {length} bytes into buffer (offset: {buffer.Offset} size: {buffer.Count}). Use a larger read buffer");
            }

            int offset = 0;
            do
            {
                int bytesRead = await stream.ReadAsync(buffer.Array, buffer.Offset + offset, length - offset,
                    cancellationToken);
                if (bytesRead == 0)
                {
                    throw new EndOfStreamException(string.Format(
                        "Unexpected end of stream encountered whilst attempting to read {0:#,##0} bytes", length));
                }

                offset += bytesRead;
            } while (offset < length);
        }

        /// <summary>
        /// Reads the u short exactly using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="isLittleEndian">The is little endian</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the ushort</returns>
        public static async Task<ushort> ReadUShortExactly(Stream stream, bool isLittleEndian,
            ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            await ReadExactly(2, stream, buffer, cancellationToken);

            if (!isLittleEndian)
            {
                Array.Reverse(buffer.Array, buffer.Offset, 2); // big endian
            }

            return BitConverter.ToUInt16(buffer.Array, buffer.Offset);
        }

        /// <summary>
        /// Reads the u long exactly using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="isLittleEndian">The is little endian</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the ulong</returns>
        public static async Task<ulong> ReadULongExactly(Stream stream, bool isLittleEndian, ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            await ReadExactly(8, stream, buffer, cancellationToken);

            if (!isLittleEndian)
            {
                Array.Reverse(buffer.Array, buffer.Offset, 8); // big endian
            }

            return BitConverter.ToUInt64(buffer.Array, buffer.Offset);
        }

        /// <summary>
        /// Reads the long exactly using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="isLittleEndian">The is little endian</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the long</returns>
        public static async Task<long> ReadLongExactly(Stream stream, bool isLittleEndian, ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            await ReadExactly(8, stream, buffer, cancellationToken);

            if (!isLittleEndian)
            {
                Array.Reverse(buffer.Array, buffer.Offset, 8); // big endian
            }

            return BitConverter.ToInt64(buffer.Array, buffer.Offset);
        }

        /// <summary>
        /// Writes the int using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="stream">The stream</param>
        /// <param name="isLittleEndian">The is little endian</param>
        public static void WriteInt(int value, Stream stream, bool isLittleEndian)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian && !isLittleEndian)
            {
                Array.Reverse(buffer);
            }

            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Writes the u long using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="stream">The stream</param>
        /// <param name="isLittleEndian">The is little endian</param>
        public static void WriteULong(ulong value, Stream stream, bool isLittleEndian)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian && !isLittleEndian)
            {
                Array.Reverse(buffer);
            }

            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Writes the long using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="stream">The stream</param>
        /// <param name="isLittleEndian">The is little endian</param>
        public static void WriteLong(long value, Stream stream, bool isLittleEndian)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian && !isLittleEndian)
            {
                Array.Reverse(buffer);
            }

            stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Writes the u short using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="stream">The stream</param>
        /// <param name="isLittleEndian">The is little endian</param>
        public static void WriteUShort(ushort value, Stream stream, bool isLittleEndian)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian && !isLittleEndian)
            {
                Array.Reverse(buffer);
            }

            stream.Write(buffer, 0, buffer.Length);
        }
    }
}