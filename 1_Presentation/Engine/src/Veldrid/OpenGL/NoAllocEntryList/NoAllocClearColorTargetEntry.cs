namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc clear color target entry
    /// </summary>
    internal struct NoAllocClearColorTargetEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public readonly uint Index;
        /// <summary>
        /// The clear color
        /// </summary>
        public readonly RgbaFloat ClearColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocClearColorTargetEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        public NoAllocClearColorTargetEntry(uint index, RgbaFloat clearColor)
        {
            Index = index;
            ClearColor = clearColor;
        }
    }
}