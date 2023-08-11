namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc set scissor rect entry
    /// </summary>
    internal struct NoAllocSetScissorRectEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public readonly uint Index;
        /// <summary>
        /// The 
        /// </summary>
        public readonly uint X;
        /// <summary>
        /// The 
        /// </summary>
        public readonly uint Y;
        /// <summary>
        /// The width
        /// </summary>
        public readonly uint Width;
        /// <summary>
        /// The height
        /// </summary>
        public readonly uint Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetScissorRectEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public NoAllocSetScissorRectEntry(uint index, uint x, uint y, uint width, uint height)
        {
            Index = index;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}