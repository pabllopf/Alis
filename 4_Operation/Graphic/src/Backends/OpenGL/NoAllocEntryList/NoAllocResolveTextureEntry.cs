namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc resolve texture entry
    /// </summary>
    internal struct NoAllocResolveTextureEntry
    {
        /// <summary>
        /// The source
        /// </summary>
        public readonly Tracked<Texture> Source;
        /// <summary>
        /// The destination
        /// </summary>
        public readonly Tracked<Texture> Destination;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocResolveTextureEntry"/> class
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="destination">The destination</param>
        public NoAllocResolveTextureEntry(Tracked<Texture> source, Tracked<Texture> destination)
        {
            Source = source;
            Destination = destination;
        }
    }
}