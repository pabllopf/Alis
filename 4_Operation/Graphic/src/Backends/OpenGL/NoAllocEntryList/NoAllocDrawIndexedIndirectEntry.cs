namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc draw indexed indirect entry
    /// </summary>
    internal struct NoAllocDrawIndexedIndirectEntry
    {
        /// <summary>
        /// The indirect buffer
        /// </summary>
        public Tracked<DeviceBuffer> IndirectBuffer;
        /// <summary>
        /// The offset
        /// </summary>
        public uint Offset;
        /// <summary>
        /// The draw count
        /// </summary>
        public uint DrawCount;
        /// <summary>
        /// The stride
        /// </summary>
        public uint Stride;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocDrawIndexedIndirectEntry"/> class
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        public NoAllocDrawIndexedIndirectEntry(Tracked<DeviceBuffer> indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            IndirectBuffer = indirectBuffer;
            Offset = offset;
            DrawCount = drawCount;
            Stride = stride;
        }
    }
}