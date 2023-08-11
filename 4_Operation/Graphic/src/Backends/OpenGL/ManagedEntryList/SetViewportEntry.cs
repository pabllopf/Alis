namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The set viewport entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class SetViewportEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public uint Index;
        /// <summary>
        /// The viewport
        /// </summary>
        public Viewport Viewport;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetViewportEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        public SetViewportEntry(uint index, ref Viewport viewport)
        {
            Index = index;
            Viewport = viewport;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetViewportEntry"/> class
        /// </summary>
        public SetViewportEntry() { }

        /// <summary>
        /// Inits the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        /// <returns>The set viewport entry</returns>
        public SetViewportEntry Init(uint index, ref Viewport viewport)
        {
            Index = index;
            Viewport = viewport;
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