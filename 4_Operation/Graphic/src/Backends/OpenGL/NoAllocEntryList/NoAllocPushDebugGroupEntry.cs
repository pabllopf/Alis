namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc push debug group entry
    /// </summary>
    internal struct NoAllocPushDebugGroupEntry
    {
        /// <summary>
        /// The name
        /// </summary>
        public Tracked<string> Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocPushDebugGroupEntry"/> class
        /// </summary>
        /// <param name="name">The name</param>
        public NoAllocPushDebugGroupEntry(Tracked<string> name)
        {
            Name = name;
        }
    }
}
