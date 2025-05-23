using System;
using Alis.Core.Ecs.Core.Memory;

namespace Alis.Core.Ecs.Collections
{
    internal struct Chunk<TData>
    {
        internal TData[] Buffer;
        public ref TData this[int i] => ref Buffer.UnsafeArrayIndex(i);

        public Chunk(int len)
        {
            Buffer = MemoryHelpers<TData>.Pool.Rent(len);
        }

        public void Return()
        {
            MemoryHelpers<TData>.Pool.Return(Buffer);
            Buffer = null!;
        }

        public Span<TData> AsSpan()
        {
            return Buffer;
        }


        public Span<TData> AsSpan(int start, int length)
        {
            return Buffer.AsSpan(start, length);
        }


        public static void NextChunk(ref Chunk<TData>[] chunks, int size, int newChunkIndex)
        {
            //these arrays are too small to pool
            if (newChunkIndex == chunks.Length)
                Array.Resize(ref chunks, newChunkIndex << 1);

            var nextChunk = new Chunk<TData>(size);
            chunks[newChunkIndex] = nextChunk;
        }

        public int Length => Buffer.Length;
    }
}