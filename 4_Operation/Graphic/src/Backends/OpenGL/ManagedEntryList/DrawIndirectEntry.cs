namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The draw indirect entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class DrawIndirectEntry : OpenGLCommandEntry
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
        /// The draw count
        /// </summary>
        public uint DrawCount;
        /// <summary>
        /// The stride
        /// </summary>
        public uint Stride;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawIndirectEntry"/> class
        /// </summary>
        public DrawIndirectEntry() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawIndirectEntry"/> class
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        public DrawIndirectEntry(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            IndirectBuffer = indirectBuffer;
            Offset = offset;
            DrawCount = drawCount;
            Stride = stride;
        }

        /// <summary>
        /// Inits the indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        /// <returns>The draw indirect entry</returns>
        public DrawIndirectEntry Init(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            IndirectBuffer = indirectBuffer;
            Offset = offset;
            DrawCount = drawCount;
            Stride = stride;

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