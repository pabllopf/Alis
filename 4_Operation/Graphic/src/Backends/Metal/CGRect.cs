namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The cg rect
    /// </summary>
    public struct CGRect
    {
        /// <summary>
        /// The origin
        /// </summary>
        public CGPoint origin;
        /// <summary>
        /// The size
        /// </summary>
        public CGSize size;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGRect"/> class
        /// </summary>
        /// <param name="origin">The origin</param>
        /// <param name="size">The size</param>
        public CGRect(CGPoint origin, CGSize size)
        {
            this.origin = origin;
            this.size = size;
        }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => string.Format("{0}, {1}", origin, size);
    }
}