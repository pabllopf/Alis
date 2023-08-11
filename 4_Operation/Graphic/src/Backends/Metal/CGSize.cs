namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The cg size
    /// </summary>
    public struct CGSize
    {
        /// <summary>
        /// The width
        /// </summary>
        public double width;
        /// <summary>
        /// The height
        /// </summary>
        public double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGSize"/> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public CGSize(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => string.Format("{0} x {1}", width, height);
    }
}