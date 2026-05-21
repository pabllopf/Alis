

using System;
using System.Text;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The advancing front class
    /// </summary>
    internal class AdvancingFront
    {
        /// <summary>
        ///     The head
        /// </summary>
        public AdvancingFrontNode Head;

        /// <summary>
        ///     The search
        /// </summary>
        protected AdvancingFrontNode Search;

        /// <summary>
        ///     The tail
        /// </summary>
        public AdvancingFrontNode Tail;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdvancingFront" /> class
        /// </summary>
        /// <param name="head">The head</param>
        /// <param name="tail">The tail</param>
        public AdvancingFront(AdvancingFrontNode head, AdvancingFrontNode tail)
        {
            Head = head;
            Tail = tail;
            Search = head;
            AddNode(head);
            AddNode(tail);
        }

        /// <summary>
        ///     Adds the node using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        public void AddNode(AdvancingFrontNode node)
        {
        }

        /// <summary>
        ///     Removes the node using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        public void RemoveNode(AdvancingFrontNode node)
        {
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            AdvancingFrontNode node = Head;
            while (node != Tail)
            {
                sb.Append(node.Point.X).Append("->");
                node = node.Next;
            }

            sb.Append(Tail.Point.X);
            return sb.ToString();
        }

        /// <summary>
        ///     MM:  This seems to be used by LocateNode to guess a position in the implicit linked list of AdvancingFrontNodes
        ///     near x
        ///     Removed an overload that depended on this being exact
        /// </summary>
        private AdvancingFrontNode FindSearchNode(double _) =>
            Search;

        /// <summary>
        ///     We use a balancing tree to locate a node smaller or equal to given key value
        /// </summary>
        public AdvancingFrontNode LocateNode(TriangulationPoint point) => LocateNode(point.X);

        /// <summary>
        ///     Locates the node using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The advancing front node</returns>
        private AdvancingFrontNode LocateNode(double x)
        {
            AdvancingFrontNode node = FindSearchNode(x);
            if (x < node.Value)
            {
                while ((node = node.Prev) != null)
                {
                    if (x >= node.Value)
                    {
                        Search = node;
                        return node;
                    }
                }
            }
            else
            {
                while ((node = node.Next) != null)
                {
                    if (x < node.Value)
                    {
                        Search = node.Prev;
                        return node.Prev;
                    }
                }
            }

            return null;
        }

        /// <summary>
        ///     This implementation will use simple node traversal algorithm to find a point on the front
        /// </summary>
        public AdvancingFrontNode LocatePoint(TriangulationPoint point)
        {
            double px = point.X;
            AdvancingFrontNode node = FindSearchNode(px);
            double nx = node.Point.X;

            if (Math.Abs(px - nx) < float.Epsilon)
            {
                if (point != node.Point)
                {
                    if (point == node.Prev.Point)
                    {
                        node = node.Prev;
                    }
                    else if (point == node.Next.Point)
                    {
                        node = node.Next;
                    }
                    else
                    {
                        throw new Exception("Failed to find Node for given afront point");
                    }
                }
            }
            else if (px < nx)
            {
                while ((node = node.Prev) != null)
                {
                    if (point == node.Point)
                    {
                        break;
                    }
                }
            }
            else
            {
                while ((node = node.Next) != null)
                {
                    if (point == node.Point)
                    {
                        break;
                    }
                }
            }

            Search = node;
            return node;
        }
    }
}