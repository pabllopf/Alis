// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Chunk.cs
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
using System.Diagnostics;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Buffers
{
    /// <summary>
    ///     The chunk
    /// </summary>
    internal struct Chunk<TData>
    {
        /// <summary>
        ///     The buffer
        /// </summary>
        internal TData[] Buffer;

        /// <summary>
        ///     The
        /// </summary>
        public ref TData this[int i]
        {
            [DebuggerHidden] get => ref Buffer.UnsafeArrayIndex(i);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Chunk" /> class
        /// </summary>
        /// <param name="len">The len</param>
        public Chunk(int len) => Buffer = MemoryHelpers<TData>.Pool.Rent(len);

        /// <summary>
        ///     Returns this instance
        /// </summary>
        public void Return()
        {
            MemoryHelpers<TData>.Pool.Return(Buffer);
            Buffer = null!;
        }

        /// <summary>
        ///     Converts the span
        /// </summary>
        /// <returns>A span of t data</returns>
        public Span<TData> AsSpan() => Buffer;

        /// <summary>
        ///     Converts the span using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        /// <returns>A span of t data</returns>
        [DebuggerHidden]
        public Span<TData> AsSpan(int start, int length) => Buffer.AsSpan(start, length);


        /// <summary>
        ///     Nexts the chunk using the specified chunks
        /// </summary>
        /// <param name="chunks">The chunks</param>
        /// <param name="size">The size</param>
        /// <param name="newChunkIndex">The new chunk index</param>
        public static void NextChunk(ref Chunk<TData>[] chunks, int size, int newChunkIndex)
        {
            //these arrays are too small to pool
            if (newChunkIndex == chunks.Length)
            {
                Array.Resize(ref chunks, newChunkIndex << 1);
            }

            var nextChunk = new Chunk<TData>(size);
            chunks[newChunkIndex] = nextChunk;
        }

        /// <summary>
        ///     Gets the value of the length
        /// </summary>
        public int Length => Buffer.Length;
    }
}