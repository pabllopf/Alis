namespace Alis.Core.Graphic.Backends.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The update buffer entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class UpdateBufferEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The buffer
        /// </summary>
        public DeviceBuffer Buffer;
        /// <summary>
        /// The buffer offset in bytes
        /// </summary>
        public uint BufferOffsetInBytes;
        /// <summary>
        /// The staging block
        /// </summary>
        public StagingBlock StagingBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBufferEntry"/> class
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="stagingBlock">The staging block</param>
        public UpdateBufferEntry(DeviceBuffer buffer, uint bufferOffsetInBytes, StagingBlock stagingBlock)
        {
            Buffer = buffer;
            BufferOffsetInBytes = bufferOffsetInBytes;
            StagingBlock = stagingBlock;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBufferEntry"/> class
        /// </summary>
        public UpdateBufferEntry() { }

        /// <summary>
        /// Inits the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="stagingBlock">The staging block</param>
        /// <returns>The update buffer entry</returns>
        public UpdateBufferEntry Init(DeviceBuffer buffer, uint bufferOffsetInBytes, StagingBlock stagingBlock)
        {
            Buffer = buffer;
            BufferOffsetInBytes = bufferOffsetInBytes;
            StagingBlock = stagingBlock;
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