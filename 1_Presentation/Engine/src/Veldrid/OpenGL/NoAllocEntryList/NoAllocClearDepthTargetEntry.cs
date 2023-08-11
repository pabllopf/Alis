namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc clear depth target entry
    /// </summary>
    internal struct NoAllocClearDepthTargetEntry
    {
        /// <summary>
        /// The depth
        /// </summary>
        public readonly float Depth;
        /// <summary>
        /// The stencil
        /// </summary>
        public readonly byte Stencil;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocClearDepthTargetEntry"/> class
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <param name="stencil">The stencil</param>
        public NoAllocClearDepthTargetEntry(float depth, byte stencil)
        {
            Depth = depth;
            Stencil = stencil;
        }
    }
}