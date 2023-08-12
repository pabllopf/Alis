namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc dispatch indirect entry
    /// </summary>
    internal struct NoAllocDispatchIndirectEntry
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
        /// Initializes a new instance of the <see cref="NoAllocDispatchIndirectEntry"/> class
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        public NoAllocDispatchIndirectEntry(Tracked<DeviceBuffer> indirectBuffer, uint offset)
        {
            IndirectBuffer = indirectBuffer;
            Offset = offset;
        }
    }
}