namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The draw indexed entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class DrawIndexedEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The index count
        /// </summary>
        public uint IndexCount;
        /// <summary>
        /// The instance count
        /// </summary>
        public uint InstanceCount;
        /// <summary>
        /// The index start
        /// </summary>
        public uint IndexStart;
        /// <summary>
        /// The vertex offset
        /// </summary>
        public int VertexOffset;
        /// <summary>
        /// The instance start
        /// </summary>
        public uint InstanceStart;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawIndexedEntry"/> class
        /// </summary>
        /// <param name="indexCount">The index count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="indexStart">The index start</param>
        /// <param name="vertexOffset">The vertex offset</param>
        /// <param name="instanceStart">The instance start</param>
        public DrawIndexedEntry(uint indexCount, uint instanceCount, uint indexStart, int vertexOffset, uint instanceStart)
        {
            IndexCount = indexCount;
            InstanceCount = instanceCount;
            IndexStart = indexStart;
            VertexOffset = vertexOffset;
            InstanceStart = instanceStart;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawIndexedEntry"/> class
        /// </summary>
        public DrawIndexedEntry() { }

        /// <summary>
        /// Inits the index count
        /// </summary>
        /// <param name="indexCount">The index count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="indexStart">The index start</param>
        /// <param name="vertexOffset">The vertex offset</param>
        /// <param name="instanceStart">The instance start</param>
        /// <returns>The draw indexed entry</returns>
        public DrawIndexedEntry Init(uint indexCount, uint instanceCount, uint indexStart, int vertexOffset, uint instanceStart)
        {
            IndexCount = indexCount;
            InstanceCount = instanceCount;
            IndexStart = indexStart;
            VertexOffset = vertexOffset;
            InstanceStart = instanceStart;
            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
        }
    }
}