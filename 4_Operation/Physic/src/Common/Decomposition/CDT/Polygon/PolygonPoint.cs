

//   Documentation!

namespace Alis.Core.Physic.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    ///     The polygon point class
    /// </summary>
    /// <seealso cref="TriangulationPoint" />
    internal class PolygonPoint : TriangulationPoint
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonPoint" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public PolygonPoint(double x, double y) : base(x, y)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the next
        /// </summary>
        public PolygonPoint Next { get; set; }

        /// <summary>
        ///     Gets or sets the value of the previous
        /// </summary>
        public PolygonPoint Previous { get; set; }
    }
}