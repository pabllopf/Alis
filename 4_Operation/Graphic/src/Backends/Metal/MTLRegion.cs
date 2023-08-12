namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl region
    /// </summary>
    public struct MTLRegion
    {
        /// <summary>
        /// The origin
        /// </summary>
        public MTLOrigin origin;
        /// <summary>
        /// The size
        /// </summary>
        public MTLSize size;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLRegion"/> class
        /// </summary>
        /// <param name="origin">The origin</param>
        /// <param name="size">The size</param>
        public MTLRegion(MTLOrigin origin, MTLSize size)
        {
            this.origin = origin;
            this.size = size;
        }
    }
}