namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc set index buffer entry
    /// </summary>
    internal struct NoAllocSetIndexBufferEntry
    {
        /// <summary>
        /// The buffer
        /// </summary>
        public readonly Tracked<DeviceBuffer> Buffer;
        /// <summary>
        /// The format
        /// </summary>
        public IndexFormat Format;
        /// <summary>
        /// The offset
        /// </summary>
        public uint Offset;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetIndexBufferEntry"/> class
        /// </summary>
        /// <param name="ib">The ib</param>
        /// <param name="format">The format</param>
        /// <param name="offset">The offset</param>
        public NoAllocSetIndexBufferEntry(Tracked<DeviceBuffer> ib, IndexFormat format, uint offset)
        {
            Buffer = ib;
            Format = format;
            Offset = offset;
        }
    }
}
