// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PublicBufferMemoryStream.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;

namespace Alis.Core.Network
{
    /// <summary>
    ///     This memory stream is not instance thread safe (not to be confused with the BufferPool which is instance thread
    ///     safe)
    /// </summary>
    public class PublicBufferMemoryStream : MemoryStream
    {
        /// <summary>
        ///     The buffer pool internal
        /// </summary>
        internal readonly BufferPool _bufferPoolInternal;
        
        /// <summary>
        ///     The buffer
        /// </summary>
        internal byte[] _buffer;
        
        /// <summary>
        ///     The ms
        /// </summary>
        internal MemoryStream _ms;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="PublicBufferMemoryStream" /> class
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferPool">The buffer pool</param>
        public PublicBufferMemoryStream(byte[] buffer, BufferPool bufferPool) : base(new byte[0])
        {
            _bufferPoolInternal = bufferPool;
            _buffer = buffer;
            _ms = new MemoryStream(buffer, 0, buffer.Length, true, true);
        }
        
        /// <summary>
        ///     Gets the value of the can read
        /// </summary>
        public override bool CanRead => _ms.CanRead;
        
        /// <summary>
        ///     Gets the value of the can seek
        /// </summary>
        public override bool CanSeek => _ms.CanSeek;
        
        /// <summary>
        ///     Gets the value of the can timeout
        /// </summary>
        public override bool CanTimeout => _ms.CanTimeout;
        
        /// <summary>
        ///     Gets the value of the can write
        /// </summary>
        public override bool CanWrite => _ms.CanWrite;
        
        /// <summary>
        ///     Gets or sets the value of the capacity
        /// </summary>
        public override int Capacity
        {
            get => _ms.Capacity;
            set => _ms.Capacity = value;
        }
        
        /// <summary>
        ///     Gets or sets the value of the position
        /// </summary>
        public override long Position
        {
            get => _ms.Position;
            set => _ms.Position = value;
        }
        
        /// <summary>
        ///     Gets or sets the value of the read timeout
        /// </summary>
        public override int ReadTimeout
        {
            get => _ms.ReadTimeout;
            set => _ms.ReadTimeout = value;
        }
        
        /// <summary>
        ///     Gets or sets the value of the write timeout
        /// </summary>
        public override int WriteTimeout
        {
            get => _ms.WriteTimeout;
            set => _ms.WriteTimeout = value;
        }
        
        /// <summary>
        ///     Begins the read using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        /// <param name="callback">The callback</param>
        /// <param name="state">The state</param>
        /// <returns>The async result</returns>
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback,
            object state)
            => _ms.BeginRead(buffer, offset, count, callback, state);
        
        /// <summary>
        ///     Begins the write using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        /// <param name="callback">The callback</param>
        /// <param name="state">The state</param>
        /// <returns>The async result</returns>
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback,
            object state)
            => _ms.BeginWrite(buffer, offset, count, callback, state);
        
        /// <summary>
        ///     Closes this instance
        /// </summary>
        public override void Close()
        {
            // clear the buffer - we only need to clear up to the number of bytes we have already written
            Array.Clear(_buffer, 0, (int) _ms.Position);
            
            _ms.Close();
            
            // return the buffer to the pool
            _bufferPoolInternal.ReturnBuffer(_buffer);
        }
        
        /// <summary>
        ///     Copies the to using the specified destination
        /// </summary>
        /// <param name="destination">The destination</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken) => _ms.CopyToAsync(destination, bufferSize, cancellationToken);
        
        /// <summary>
        ///     Ends the read using the specified async result
        /// </summary>
        /// <param name="asyncResult">The async result</param>
        /// <returns>The int</returns>
        public override int EndRead(IAsyncResult asyncResult) => _ms.EndRead(asyncResult);
        
        /// <summary>
        ///     Ends the write using the specified async result
        /// </summary>
        /// <param name="asyncResult">The async result</param>
        public override void EndWrite(IAsyncResult asyncResult)
        {
            _ms.EndWrite(asyncResult);
        }
        
        /// <summary>
        ///     Flushes this instance
        /// </summary>
        public override void Flush()
        {
            _ms.Flush();
        }
        
        /// <summary>
        ///     Flushes the cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        public override Task FlushAsync(CancellationToken cancellationToken) => _ms.FlushAsync(cancellationToken);
        
        /// <summary>
        ///     Gets the buffer
        /// </summary>
        /// <returns>The byte array</returns>
        public override byte[] GetBuffer() => _buffer;
        
        /// <summary>
        ///     Reads the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public override int Read(byte[] buffer, int offset, int count) => _ms.Read(buffer, offset, count);
        
        /// <summary>
        ///     Enlarges the buffer if required using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <exception cref="WebSocketBufferOverflowException">
        ///     Tried to create a buffer ({requiredSize:#,##0} bytes) that was
        ///     larger than the max allowed size ({int.MaxValue:#,##0})
        /// </exception>
        internal void EnlargeBufferIfRequired(int count)
        {
            if (IsNewBufferRequired(count))
            {
                CreateNewBuffer(count);
            }
        }
        
        /// <summary>
        /// Describes whether this instance is new buffer required
        /// </summary>
        /// <param name="count">The count</param>
        /// <returns>The bool</returns>
        internal bool IsNewBufferRequired(int count)
        {
            return count > _buffer.Length - _ms.Position;
        }
        
        /// <summary>
        /// Creates the new buffer using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        internal void CreateNewBuffer(int count)
        {
            int position = (int) _ms.Position;
            long newSize = CalculateNewSize(count, position);
            byte[] newBuffer = new byte[newSize];
            Buffer.BlockCopy(_buffer, 0, newBuffer, 0, position);
            _ms = new MemoryStream(newBuffer, 0, newBuffer.Length, true, true)
            {
                Position = position
            };
            _buffer = newBuffer;
        }
        
        /// <summary>
        /// Calculates the new size using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="position">The position</param>
        /// <exception cref="WebSocketBufferOverflowException">Tried to create a buffer ({requiredSize:#,##0} bytes) that was larger than the max allowed size ({int.MaxValue:#,##0})</exception>
        /// <returns>The new size</returns>
        internal long CalculateNewSize(int count, int position)
        {
            long newSize = CalculateInitialNewSize();
            long requiredSize = CalculateRequiredSize(count, position);
            
            ValidateRequiredSize(requiredSize);
            
            if (IsNewSizeLessThanRequiredSize(newSize, requiredSize))
            {
                newSize = ComputeCandidateSize(requiredSize);
            }
            
            return newSize;
        }
        
        /// <summary>
        /// Calculates the initial new size
        /// </summary>
        /// <returns>The long</returns>
        internal long CalculateInitialNewSize()
        {
            return (long) _buffer.Length * 2;
        }
        
        /// <summary>
        /// Calculates the required size using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="position">The position</param>
        /// <returns>The long</returns>
        internal long CalculateRequiredSize(int count, int position)
        {
            return (long) count + _buffer.Length - position;
        }
        
        /// <summary>
        /// Validates the required size using the specified required size
        /// </summary>
        /// <param name="requiredSize">The required size</param>
        /// <exception cref="WebSocketBufferOverflowException">Tried to create a buffer ({requiredSize:#,##0} bytes) that was larger than the max allowed size ({int.MaxValue:#,##0})</exception>
        internal void ValidateRequiredSize(long requiredSize)
        {
            if (requiredSize > int.MaxValue)
            {
                throw new WebSocketBufferOverflowException(
                    $"Tried to create a buffer ({requiredSize:#,##0} bytes) that was larger than the max allowed size ({int.MaxValue:#,##0})");
            }
        }
        
        /// <summary>
        /// Describes whether this instance is new size less than required size
        /// </summary>
        /// <param name="newSize">The new size</param>
        /// <param name="requiredSize">The required size</param>
        /// <returns>The bool</returns>
        internal bool IsNewSizeLessThanRequiredSize(long newSize, long requiredSize)
        {
            return requiredSize > newSize;
        }
        
        /// <summary>
        /// Computes the candidate size using the specified required size
        /// </summary>
        /// <param name="requiredSize">The required size</param>
        /// <returns>The long</returns>
        internal long ComputeCandidateSize(long requiredSize)
        {
            long candidateSize = (long) Math.Pow(2, Math.Ceiling(Math.Log(requiredSize) / Math.Log(2)));
            return candidateSize > int.MaxValue ? requiredSize : candidateSize;
        }
        
        /// <summary>
        ///     Writes the byte using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public override void WriteByte(byte value)
        {
            EnlargeBufferIfRequired(1);
            _ms.WriteByte(value);
        }
        
        /// <summary>
        ///     Writes the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            EnlargeBufferIfRequired(count);
            _ms.Write(buffer, offset, count);
        }
        
        /// <summary>
        ///     Writes the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            EnlargeBufferIfRequired(count);
            return _ms.WriteAsync(buffer, offset, count);
        }
        
        /// <summary>
        ///     Reads the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="count">The count</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the int</returns>
        public override Task<int> ReadAsync(byte[] buffer, int offset, int count,
            CancellationToken cancellationToken)
            => _ms.ReadAsync(buffer, offset, count, cancellationToken);
        
        /// <summary>
        ///     Reads the byte
        /// </summary>
        /// <returns>The int</returns>
        public override int ReadByte() => _ms.ReadByte();
        
        /// <summary>
        ///     Seeks the offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="loc">The loc</param>
        /// <returns>The long</returns>
        public override long Seek(long offset, SeekOrigin loc) => _ms.Seek(offset, loc);
        
        /// <summary>
        ///     Note: This will not make the MemoryStream any smaller, only larger
        /// </summary>
        public override void SetLength(long value)
        {
            EnlargeBufferIfRequired((int) value);
        }
        
        /// <summary>
        ///     Returns the array
        /// </summary>
        /// <returns>The byte array</returns>
        public override byte[] ToArray() =>
            // you should never call this
            _ms.ToArray();
        
        /// <summary>
        ///     Writes the to using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public override void WriteTo(Stream stream)
        {
            _ms.WriteTo(stream);
        }
    }
}