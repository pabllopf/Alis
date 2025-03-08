namespace Alis.Benchmark.ClassVsStruct.Instancies
{
    /// <summary>
    /// The struct point
    /// </summary>
    public struct StructPoint
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
        /// Initializes a new instance of the <see cref="StructPoint"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public StructPoint(int x, int y) => (X, Y) = (x, y);
    }
}