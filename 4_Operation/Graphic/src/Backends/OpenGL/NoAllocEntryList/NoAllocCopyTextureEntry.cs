namespace Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList
{
    /// <summary>
    /// The no alloc copy texture entry
    /// </summary>
    internal struct NoAllocCopyTextureEntry
    {
        /// <summary>
        /// The source
        /// </summary>
        public readonly Tracked<Texture> Source;
        /// <summary>
        /// The src
        /// </summary>
        public readonly uint SrcX;
        /// <summary>
        /// The src
        /// </summary>
        public readonly uint SrcY;
        /// <summary>
        /// The src
        /// </summary>
        public readonly uint SrcZ;
        /// <summary>
        /// The src mip level
        /// </summary>
        public readonly uint SrcMipLevel;
        /// <summary>
        /// The src base array layer
        /// </summary>
        public readonly uint SrcBaseArrayLayer;
        /// <summary>
        /// The destination
        /// </summary>
        public readonly Tracked<Texture> Destination;
        /// <summary>
        /// The dst
        /// </summary>
        public readonly uint DstX;
        /// <summary>
        /// The dst
        /// </summary>
        public readonly uint DstY;
        /// <summary>
        /// The dst
        /// </summary>
        public readonly uint DstZ;
        /// <summary>
        /// The dst mip level
        /// </summary>
        public readonly uint DstMipLevel;
        /// <summary>
        /// The dst base array layer
        /// </summary>
        public readonly uint DstBaseArrayLayer;
        /// <summary>
        /// The width
        /// </summary>
        public readonly uint Width;
        /// <summary>
        /// The height
        /// </summary>
        public readonly uint Height;
        /// <summary>
        /// The depth
        /// </summary>
        public readonly uint Depth;
        /// <summary>
        /// The layer count
        /// </summary>
        public readonly uint LayerCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoAllocCopyTextureEntry"/> class
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="srcX">The src</param>
        /// <param name="srcY">The src</param>
        /// <param name="srcZ">The src</param>
        /// <param name="srcMipLevel">The src mip level</param>
        /// <param name="srcBaseArrayLayer">The src base array layer</param>
        /// <param name="destination">The destination</param>
        /// <param name="dstX">The dst</param>
        /// <param name="dstY">The dst</param>
        /// <param name="dstZ">The dst</param>
        /// <param name="dstMipLevel">The dst mip level</param>
        /// <param name="dstBaseArrayLayer">The dst base array layer</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="layerCount">The layer count</param>
        public NoAllocCopyTextureEntry(
            Tracked<Texture> source,
            uint srcX, uint srcY, uint srcZ,
            uint srcMipLevel,
            uint srcBaseArrayLayer,
            Tracked<Texture> destination,
            uint dstX, uint dstY, uint dstZ,
            uint dstMipLevel,
            uint dstBaseArrayLayer,
            uint width, uint height, uint depth,
            uint layerCount)
        {
            Source = source;
            SrcX = srcX;
            SrcY = srcY;
            SrcZ = srcZ;
            SrcMipLevel = srcMipLevel;
            SrcBaseArrayLayer = srcBaseArrayLayer;
            Destination = destination;
            DstX = dstX;
            DstY = dstY;
            DstZ = dstZ;
            DstMipLevel = dstMipLevel;
            DstBaseArrayLayer = dstBaseArrayLayer;
            Width = width;
            Height = height;
            Depth = depth;
            LayerCount = layerCount;
        }
    }
}