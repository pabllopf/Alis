namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc insert debug marker entry
    /// </summary>
    internal struct NoAllocInsertDebugMarkerEntry
    {
        /// <summary>
        /// The name
        /// </summary>
        public Tracked<string> Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocInsertDebugMarkerEntry"/> class
        /// </summary>
        /// <param name="name">The name</param>
        public NoAllocInsertDebugMarkerEntry(Tracked<string> name)
        {
            Name = name;
        }
    }
}
