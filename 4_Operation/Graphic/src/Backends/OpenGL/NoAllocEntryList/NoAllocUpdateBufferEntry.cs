namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc update buffer entry
    /// </summary>
    internal struct NoAllocUpdateBufferEntry
    {
        /// <summary>
        /// The buffer
        /// </summary>
        public readonly Tracked<DeviceBuffer> Buffer;
        /// <summary>
        /// The buffer offset in bytes
        /// </summary>
        public readonly uint BufferOffsetInBytes;
        /// <summary>
        /// The staging block
        /// </summary>
        public readonly StagingBlock StagingBlock;
        /// <summary>
        /// The staging block size
        /// </summary>
        public readonly uint StagingBlockSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocUpdateBufferEntry"/> class
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="stagingBlock">The staging block</param>
        /// <param name="stagingBlockSize">The staging block size</param>
        public NoAllocUpdateBufferEntry(Tracked<DeviceBuffer> buffer, uint bufferOffsetInBytes, StagingBlock stagingBlock, uint stagingBlockSize)
        {
            Buffer = buffer;
            BufferOffsetInBytes = bufferOffsetInBytes;
            StagingBlock = stagingBlock;
            StagingBlockSize = stagingBlockSize;
        }
    }
}