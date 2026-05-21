

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The query graph class
    /// </summary>
    internal class QueryGraph
    {
        /// <summary>
        ///     The head
        /// </summary>
        private Node _head;

        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryGraph" /> class
        /// </summary>
        /// <param name="head">The head</param>
        public QueryGraph(Node head) => _head = head;

        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The trapezoid</returns>
        private Trapezoid Locate(Edge edge) => _head.Locate(edge).Trapezoid;

        /// <summary>
        ///     Follows the edge using the specified edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The trapezoids</returns>
        public List<Trapezoid> FollowEdge(Edge edge)
        {
            List<Trapezoid> trapezoids = new List<Trapezoid>();
            trapezoids.Add(Locate(edge));
            int j = 0;

            while (edge.Q.X > trapezoids[j].RightPoint.X)
            {
                if (edge.IsAbove(trapezoids[j].RightPoint))
                {
                    trapezoids.Add(trapezoids[j].UpperRight);
                }
                else
                {
                    trapezoids.Add(trapezoids[j].LowerRight);
                }

                j += 1;
            }

            return trapezoids;
        }

        /// <summary>
        ///     Replaces the sink
        /// </summary>
        /// <param name="sink">The sink</param>
        /// <param name="node">The node</param>
        private void Replace(Sink sink, Node node)
        {
            if (sink.ParentList.Count == 0)
            {
                _head = node;
            }
            else
            {
                node.Replace(sink);
            }
        }

        /// <summary>
        ///     Cases the 1 using the specified sink
        /// </summary>
        /// <param name="sink">The sink</param>
        /// <param name="edge">The edge</param>
        /// <param name="tList">The list</param>
        public void Case1(Sink sink, Edge edge, Trapezoid[] tList)
        {
            YNode yNode = new YNode(edge, Sink.Isink(tList[1]), Sink.Isink(tList[2]));
            XNode qNode = new XNode(edge.Q, yNode, Sink.Isink(tList[3]));
            XNode pNode = new XNode(edge.P, Sink.Isink(tList[0]), qNode);
            Replace(sink, pNode);
        }

        /// <summary>
        ///     Cases the 2 using the specified sink
        /// </summary>
        /// <param name="sink">The sink</param>
        /// <param name="edge">The edge</param>
        /// <param name="tList">The list</param>
        public void Case2(Sink sink, Edge edge, Trapezoid[] tList)
        {
            YNode yNode = new YNode(edge, Sink.Isink(tList[1]), Sink.Isink(tList[2]));
            XNode pNode = new XNode(edge.P, Sink.Isink(tList[0]), yNode);
            Replace(sink, pNode);
        }

        /// <summary>
        ///     Cases the 3 using the specified sink
        /// </summary>
        /// <param name="sink">The sink</param>
        /// <param name="edge">The edge</param>
        /// <param name="tList">The list</param>
        public void Case3(Sink sink, Edge edge, Trapezoid[] tList)
        {
            YNode yNode = new YNode(edge, Sink.Isink(tList[0]), Sink.Isink(tList[1]));
            Replace(sink, yNode);
        }

        /// <summary>
        ///     Cases the 4 using the specified sink
        /// </summary>
        /// <param name="sink">The sink</param>
        /// <param name="edge">The edge</param>
        /// <param name="tList">The list</param>
        public void Case4(Sink sink, Edge edge, Trapezoid[] tList)
        {
            YNode yNode = new YNode(edge, Sink.Isink(tList[0]), Sink.Isink(tList[1]));
            XNode qNode = new XNode(edge.Q, yNode, Sink.Isink(tList[2]));
            Replace(sink, qNode);
        }
    }
}