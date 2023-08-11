namespace Veldrid.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc set framebuffer entry
    /// </summary>
    internal struct NoAllocSetFramebufferEntry
    {
        /// <summary>
        /// The framebuffer
        /// </summary>
        public readonly Tracked<Framebuffer> Framebuffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocSetFramebufferEntry"/> class
        /// </summary>
        /// <param name="fb">The fb</param>
        public NoAllocSetFramebufferEntry(Tracked<Framebuffer> fb)
        {
            Framebuffer = fb;
        }
    }
}