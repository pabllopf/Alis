

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The node class
    /// </summary>
    /// <seealso cref="Node" />
    internal class YNode : Node
    {
        /// <summary>
        ///     The edge
        /// </summary>
        private readonly Edge _edge;

        /// <summary>
        ///     Initializes a new instance of the <see cref="YNode" /> class
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <param name="lChild">The child</param>
        /// <param name="rChild">The child</param>
        public YNode(Edge edge, Node lChild, Node rChild)
            : base(lChild, rChild)
            => _edge = edge;

        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The sink</returns>
        public override Sink Locate(Edge s)
        {
            if (_edge.IsAbove(s.P))
            {
                return RightChild.Locate(s); // Move down the graph
            }

            if (_edge.IsBelow(s.P))
            {
                return LeftChild.Locate(s); // Move up the graph
            }

            if (s.Slope < _edge.Slope)
            {
                return RightChild.Locate(s); // Move down the graph
            }

            return LeftChild.Locate(s);
        }
    }
}