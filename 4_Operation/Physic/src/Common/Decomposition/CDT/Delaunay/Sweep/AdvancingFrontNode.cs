

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The advancing front node class
    /// </summary>
    internal class AdvancingFrontNode
    {
        /// <summary>
        ///     The point
        /// </summary>
        public readonly TriangulationPoint Point;

        /// <summary>
        ///     The value
        /// </summary>
        public readonly double Value;

        /// <summary>
        ///     The next
        /// </summary>
        public AdvancingFrontNode Next;

        /// <summary>
        ///     The prev
        /// </summary>
        public AdvancingFrontNode Prev;

        /// <summary>
        ///     The triangle
        /// </summary>
        public DelaunayTriangle Triangle;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdvancingFrontNode" /> class
        /// </summary>
        /// <param name="point">The point</param>
        public AdvancingFrontNode(TriangulationPoint point)
        {
            Point = point;
            Value = point.X;
        }

        /// <summary>
        ///     Gets the value of the has next
        /// </summary>
        public bool HasNext => Next != null;

        /// <summary>
        ///     Gets the value of the has prev
        /// </summary>
        public bool HasPrev => Prev != null;
    }
}