namespace Alis.Benchmark
{
    /// <summary>
    /// The class point class
    /// </summary>
    public class ClassPoint
    {
        /// <summary>
        /// Gets the value of the x
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Gets the value of the y
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassPoint"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public ClassPoint(int x, int y) => (X, Y) = (x, y);
    }
}