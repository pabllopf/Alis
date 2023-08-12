namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc generate mipmaps entry
    /// </summary>
    internal struct NoAllocGenerateMipmapsEntry
    {
        /// <summary>
        /// The texture
        /// </summary>
        public readonly Tracked<Texture> Texture;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocGenerateMipmapsEntry"/> class
        /// </summary>
        /// <param name="texture">The texture</param>
        public NoAllocGenerateMipmapsEntry(Tracked<Texture> texture)
        {
            Texture = texture;
        }
    }
}