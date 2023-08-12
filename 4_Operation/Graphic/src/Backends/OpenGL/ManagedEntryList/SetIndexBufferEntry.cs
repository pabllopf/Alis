namespace Alis.Core.Graphic.Backends.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The set index buffer entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class SetIndexBufferEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The buffer
        /// </summary>
        public DeviceBuffer Buffer;
        /// <summary>
        /// The format
        /// </summary>
        public IndexFormat Format;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetIndexBufferEntry"/> class
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        public SetIndexBufferEntry(DeviceBuffer buffer, IndexFormat format)
        {
            Buffer = buffer;
            Format = format;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetIndexBufferEntry"/> class
        /// </summary>
        public SetIndexBufferEntry() { }

        /// <summary>
        /// Inits the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        /// <returns>The set index buffer entry</returns>
        public SetIndexBufferEntry Init(DeviceBuffer buffer, IndexFormat format)
        {
            Buffer = buffer;
            Format = format;
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