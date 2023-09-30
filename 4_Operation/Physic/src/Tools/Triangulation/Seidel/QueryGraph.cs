// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryGraph.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;

namespace Alis.Core.Physic.Tools.Triangulation.Seidel
{
    // Directed Acyclic graph (DAG)
    // See "Computational Geometry", 3rd edition, by Mark de Berg et al, Chapter 6.2
    /// <summary>
    ///     The query graph class
    /// </summary>
    internal class QueryGraph
    {
        /// <summary>
        ///     The head
        /// </summary>
        private Node head;

        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryGraph" /> class
        /// </summary>
        /// <param name="head">The head</param>
        public QueryGraph(Node head) => this.head = head;

        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The trapezoid</returns>
        private Trapezoid Locate(Edge edge) => head.Locate(edge).Trapezoid;

        /// <summary>
        ///     Follows the edge using the specified edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The trapezoids</returns>
        public List<Trapezoid> FollowEdge(Edge edge)
        {
            List<Trapezoid> trapezoids = new List<Trapezoid>
            {
                Locate(edge)
            };
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
                head = node;
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