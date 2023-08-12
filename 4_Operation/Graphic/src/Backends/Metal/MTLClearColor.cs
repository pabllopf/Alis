using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl clear color
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLClearColor
    {
        /// <summary>
        /// The red
        /// </summary>
        public double red;
        /// <summary>
        /// The green
        /// </summary>
        public double green;
        /// <summary>
        /// The blue
        /// </summary>
        public double blue;
        /// <summary>
        /// The alpha
        /// </summary>
        public double alpha;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLClearColor"/> class
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        public MTLClearColor(double r, double g, double b, double a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }
    }
}