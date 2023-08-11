namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc copy buffer entry
    /// </summary>
    internal struct NoAllocCopyBufferEntry
    {
        /// <summary>
        /// The source
        /// </summary>
        public readonly Tracked<DeviceBuffer> Source;
        /// <summary>
        /// The source offset
        /// </summary>
        public readonly uint SourceOffset;
        /// <summary>
        /// The destination
        /// </summary>
        public readonly Tracked<DeviceBuffer> Destination;
        /// <summary>
        /// The destination offset
        /// </summary>
        public readonly uint DestinationOffset;
        /// <summary>
        /// The size in bytes
        /// </summary>
        public readonly uint SizeInBytes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocCopyBufferEntry"/> class
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="destination">The destination</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        public NoAllocCopyBufferEntry(Tracked<DeviceBuffer> source, uint sourceOffset, Tracked<DeviceBuffer> destination, uint destinationOffset, uint sizeInBytes)
        {
            Source = source;
            SourceOffset = sourceOffset;
            Destination = destination;
            DestinationOffset = destinationOffset;
            SizeInBytes = sizeInBytes;
        }
    }
}