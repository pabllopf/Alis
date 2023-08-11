namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc dispatch entry
    /// </summary>
    internal struct NoAllocDispatchEntry
    {
        /// <summary>
        /// The group count
        /// </summary>
        public uint GroupCountX;
        /// <summary>
        /// The group count
        /// </summary>
        public uint GroupCountY;
        /// <summary>
        /// The group count
        /// </summary>
        public uint GroupCountZ;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocDispatchEntry"/> class
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        public NoAllocDispatchEntry(uint groupCountX, uint groupCountY, uint groupCountZ)
        {
            GroupCountX = groupCountX;
            GroupCountY = groupCountY;
            GroupCountZ = groupCountZ;
        }
    }
}