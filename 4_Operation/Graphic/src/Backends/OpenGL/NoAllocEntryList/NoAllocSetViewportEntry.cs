namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc set viewport entry
    /// </summary>
    internal struct NoAllocSetViewportEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public readonly uint Index;
        /// <summary>
        /// The viewport
        /// </summary>
        public Viewport Viewport;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetViewportEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        public NoAllocSetViewportEntry(uint index, ref Viewport viewport)
        {
            Index = index;
            Viewport = viewport;
        }
    }
}