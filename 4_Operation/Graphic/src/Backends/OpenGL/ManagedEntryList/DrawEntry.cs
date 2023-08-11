namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The draw entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class DrawEntry : OpenGLCommandEntry
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
        /// Initializes a new instance of the <see cref="DrawEntry"/> class
        /// </summary>
        public DrawEntry() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawEntry"/> class
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="instanceStart">The instance start</param>
        public DrawEntry(uint vertexCount, uint instanceCount, uint vertexStart, uint instanceStart)
        {
            VertexCount = vertexCount;
            InstanceCount = instanceCount;
            VertexStart = vertexStart;
            InstanceStart = instanceStart;
        }

        /// <summary>
        /// Inits the vertex count
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="instanceStart">The instance start</param>
        /// <returns>The draw entry</returns>
        public DrawEntry Init(uint vertexCount, uint instanceCount, uint vertexStart, uint instanceStart)
        {
            VertexCount = vertexCount;
            InstanceCount = instanceCount;
            VertexStart = vertexStart;
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