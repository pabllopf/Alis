namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc set vertex buffer entry
    /// </summary>
    internal struct NoAllocSetVertexBufferEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public readonly uint Index;
        /// <summary>
        /// The buffer
        /// </summary>
        public readonly Tracked<DeviceBuffer> Buffer;
        /// <summary>
        /// The offset
        /// </summary>
        public uint Offset;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetVertexBufferEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        public NoAllocSetVertexBufferEntry(uint index, Tracked<DeviceBuffer> buffer, uint offset)
        {
            Index = index;
            Buffer = buffer;
            Offset = offset;
        }
    }
}
