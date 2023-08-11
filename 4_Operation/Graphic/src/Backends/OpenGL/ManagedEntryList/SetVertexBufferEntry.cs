namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The set vertex buffer entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class SetVertexBufferEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public uint Index;
        /// <summary>
        /// The buffer
        /// </summary>
        public DeviceBuffer Buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetVertexBufferEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        public SetVertexBufferEntry(uint index, DeviceBuffer buffer)
        {
            Index = index;
            Buffer = buffer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetVertexBufferEntry"/> class
        /// </summary>
        public SetVertexBufferEntry() { }

        /// <summary>
        /// Inits the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <returns>The set vertex buffer entry</returns>
        public SetVertexBufferEntry Init(uint index, DeviceBuffer buffer)
        {
            Index = index;
            Buffer = buffer;
            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
            Buffer = null;
        }
    }
}