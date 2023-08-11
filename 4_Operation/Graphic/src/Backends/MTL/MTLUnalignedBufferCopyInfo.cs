namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl unaligned buffer copy info
    /// </summary>
    internal struct MTLUnalignedBufferCopyInfo
    {
        /// <summary>
        /// The source offset
        /// </summary>
        public uint SourceOffset;
        /// <summary>
        /// The destination offset
        /// </summary>
        public uint DestinationOffset;
        /// <summary>
        /// The copy size
        /// </summary>
        public uint CopySize;
    }
}