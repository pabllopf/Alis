namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The dispatch indirect entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class DispatchIndirectEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The indirect buffer
        /// </summary>
        public DeviceBuffer IndirectBuffer;
        /// <summary>
        /// The offset
        /// </summary>
        public uint Offset;

        /// <summary>
        /// Initializes a new instance of the <see cref="DispatchIndirectEntry"/> class
        /// </summary>
        public DispatchIndirectEntry() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DispatchIndirectEntry"/> class
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        public DispatchIndirectEntry(DeviceBuffer indirectBuffer, uint offset)
        {
            IndirectBuffer = indirectBuffer;
            Offset = offset;
        }

        /// <summary>
        /// Inits the indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <returns>The dispatch indirect entry</returns>
        public DispatchIndirectEntry Init(DeviceBuffer indirectBuffer, uint offset)
        {
            IndirectBuffer = indirectBuffer;
            Offset = offset;

            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
            IndirectBuffer = null;
        }
    }
}