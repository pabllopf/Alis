

using System.Collections.Concurrent;
using System.IO;

namespace Alis.Extension.Network
{
    /// <summary>
    ///     This buffer pool is instance thread safe
    ///     Use GetBuffer to get a MemoryStream (with a publically accessible buffer)
    ///     Calling Close on this MemoryStream will clear its internal buffer and return the buffer to the pool for reuse
    ///     MemoryStreams can grow larger than the DEFAULT_BUFFER_SIZE (or whatever you passed in)
    ///     and the underlying buffers will be returned to the pool at their larger sizes
    /// </summary>
    public class BufferPool : IBufferPool
    {
        /// <summary>
        ///     The default buffer size
        /// </summary>
        private const int DefaultBufferSize = 16384;

        /// <summary>
        ///     The buffer pool stack
        /// </summary>
        private readonly ConcurrentStack<byte[]> _bufferPoolStack;

        /// <summary>
        ///     The buffer size
        /// </summary>
        private readonly int _bufferSize;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BufferPool" /> class
        /// </summary>
        public BufferPool() : this(DefaultBufferSize)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BufferPool" /> class
        /// </summary>
        /// <param name="bufferSize">The buffer size</param>
        public BufferPool(int bufferSize)
        {
            _bufferSize = bufferSize;
            _bufferPoolStack = new ConcurrentStack<byte[]>();
        }

        /// <summary>
        ///     Gets a MemoryStream built from a buffer plucked from a thread safe pool
        ///     The pool grows automatically.
        ///     Closing the memory stream clears the buffer and returns it to the pool
        /// </summary>
        public MemoryStream GetBuffer()
        {
            if (!_bufferPoolStack.TryPop(out byte[] buffer))
            {
                buffer = new byte[_bufferSize];
            }

            return new PublicBufferMemoryStream(buffer, this);
        }

        /// <summary>
        ///     Returns the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        protected internal void ReturnBuffer(byte[] buffer)
        {
            _bufferPoolStack.Push(buffer);
        }
    }
}