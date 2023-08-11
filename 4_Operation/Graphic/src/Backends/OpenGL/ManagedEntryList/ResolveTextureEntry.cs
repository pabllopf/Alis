namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The resolve texture entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class ResolveTextureEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The source
        /// </summary>
        public Texture Source;
        /// <summary>
        /// The destination
        /// </summary>
        public Texture Destination;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResolveTextureEntry"/> class
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="destination">The destination</param>
        public ResolveTextureEntry(Texture source, Texture destination)
        {
            Source = source;
            Destination = destination;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResolveTextureEntry"/> class
        /// </summary>
        public ResolveTextureEntry() { }

        /// <summary>
        /// Inits the source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="destination">The destination</param>
        /// <returns>The resolve texture entry</returns>
        public ResolveTextureEntry Init(Texture source, Texture destination)
        {
            Source = source;
            Destination = destination;
            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
            Source = null;
            Destination = null;
        }
    }
}