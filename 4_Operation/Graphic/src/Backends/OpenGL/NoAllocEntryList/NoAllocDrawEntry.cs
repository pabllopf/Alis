namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc draw entry
    /// </summary>
    internal struct NoAllocDrawEntry
    {
        /// <summary>
        /// The vertex count
        /// </summary>
        public uint VertexCount;
        /// <summary>
        /// The instance count
        /// </summary>
        public uint InstanceCount;
        /// <summary>
        /// The vertex start
        /// </summary>
        public uint VertexStart;
        /// <summary>
        /// The instance start
        /// </summary>
        public uint InstanceStart;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocDrawEntry"/> class
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="instanceStart">The instance start</param>
        public NoAllocDrawEntry(uint vertexCount, uint instanceCount, uint vertexStart, uint instanceStart)
        {
            VertexCount = vertexCount;
            InstanceCount = instanceCount;
            VertexStart = vertexStart;
            InstanceStart = instanceStart;
        }
    }
}