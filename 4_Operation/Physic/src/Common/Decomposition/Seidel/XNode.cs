

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The node class
    /// </summary>
    /// <seealso cref="Node" />
    internal class XNode : Node
    {
        /// <summary>
        ///     The point
        /// </summary>
        private readonly Point _point;

        /// <summary>
        ///     Initializes a new instance of the <see cref="XNode" /> class
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="lChild">The child</param>
        /// <param name="rChild">The child</param>
        public XNode(Point point, Node lChild, Node rChild)
            : base(lChild, rChild)
            => _point = point;

        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The sink</returns>
        public override Sink Locate(Edge s)
        {
            if (s.P.X >= _point.X)
            {
                return RightChild.Locate(s); // Move to the right in the graph
            }

            return LeftChild.Locate(s); // Move to the left in the graph
        }
    }
}