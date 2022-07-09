namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// Color for debug drawing. Each value has the range [0,1].
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// The 
        /// </summary>
        private float r;

        /// <summary>
        /// The 
        /// </summary>
        private float g;

        /// <summary>
        /// The 
        /// </summary>
        private float b;

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        public Color(float r, float g, float b)
        {
            this.r = r; this.g = g; this.b = b;
        }
        /// <summary>
        /// Sets the r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        public void Set(float r, float g, float b)
        {
            this.r = r; 
            this.g = g; 
            this.b = b;
        }
    }
}