namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The cg point
    /// </summary>
    public struct CGPoint
    {
        /// <summary>
        /// The 
        /// </summary>
        public CGFloat x;
        /// <summary>
        /// The 
        /// </summary>
        public CGFloat y;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGPoint"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public CGPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => string.Format("({0},{1})", x, y);
    }
}