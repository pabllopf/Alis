namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc draw indexed entry
    /// </summary>
    internal struct NoAllocDrawIndexedEntry
    {
        /// <summary>
        /// The index count
        /// </summary>
        public readonly uint IndexCount;
        /// <summary>
        /// The instance count
        /// </summary>
        public readonly uint InstanceCount;
        /// <summary>
        /// The index start
        /// </summary>
        public readonly uint IndexStart;
        /// <summary>
        /// The vertex offset
        /// </summary>
        public readonly int VertexOffset;
        /// <summary>
        /// The instance start
        /// </summary>
        public readonly uint InstanceStart;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocDrawIndexedEntry"/> class
        /// </summary>
        /// <param name="indexCount">The index count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="indexStart">The index start</param>
        /// <param name="vertexOffset">The vertex offset</param>
        /// <param name="instanceStart">The instance start</param>
        public NoAllocDrawIndexedEntry(uint indexCount, uint instanceCount, uint indexStart, int vertexOffset, uint instanceStart)
        {
            IndexCount = indexCount;
            InstanceCount = instanceCount;
            IndexStart = indexStart;
            VertexOffset = vertexOffset;
            InstanceStart = instanceStart;
        }
    }
}