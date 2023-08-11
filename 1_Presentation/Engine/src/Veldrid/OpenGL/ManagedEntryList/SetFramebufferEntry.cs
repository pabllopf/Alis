namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The set framebuffer entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class SetFramebufferEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The framebuffer
        /// </summary>
        public Framebuffer Framebuffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetFramebufferEntry"/> class
        /// </summary>
        /// <param name="fb">The fb</param>
        public SetFramebufferEntry(Framebuffer fb)
        {
            Framebuffer = fb;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetFramebufferEntry"/> class
        /// </summary>
        public SetFramebufferEntry() { }

        /// <summary>
        /// Inits the fb
        /// </summary>
        /// <param name="fb">The fb</param>
        /// <returns>The set framebuffer entry</returns>
        public SetFramebufferEntry Init(Framebuffer fb)
        {
            Framebuffer = fb;
            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
            Framebuffer = null;
        }
    }
}