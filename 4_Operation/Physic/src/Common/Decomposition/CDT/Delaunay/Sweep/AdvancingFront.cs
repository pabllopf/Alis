// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancingFront.cs
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
            // No-op: node management is handled by the context's advancing front reference
        }

        /// <summary>
        ///     Removes the node using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        public void RemoveNode(AdvancingFrontNode node)
        {
            // No-op: node removal is handled by the context's advancing front reference
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
        private AdvancingFrontNode FindSearchNode() =>
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
            AdvancingFrontNode node = FindSearchNode();
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
            AdvancingFrontNode node = FindSearchNode();
            double nx = node.Point.X;

            if (Math.Abs(px - nx) < float.Epsilon)
            {
                node = LocateExactPoint(point, node);
            }
            else if (px < nx)
            {
                node = SearchPrevDirection(point, node);
            }
            else
            {
                node = SearchNextDirection(point, node);
            }

            Search = node;
            return node;
        }

        /// <summary>
        /// Locates the exact point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="node">The node</param>
        /// <exception cref="InvalidOperationException">Failed to find Node for given afront point</exception>
        /// <returns>The advancing front node</returns>
        private static AdvancingFrontNode LocateExactPoint(TriangulationPoint point, AdvancingFrontNode node)
        {
            if (point == node.Point)
            {
                return node;
            }

            if (point == node.Prev.Point)
            {
                return node.Prev;
            }

            if (point == node.Next.Point)
            {
                return node.Next;
            }

            throw new InvalidOperationException("Failed to find Node for given afront point");
        }

        /// <summary>
        /// Searches the prev direction using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="node">The node</param>
        /// <returns>The node</returns>
        private static AdvancingFrontNode SearchPrevDirection(TriangulationPoint point, AdvancingFrontNode node)
        {
            while ((node = node.Prev) != null)
            {
                if (point == node.Point)
                {
                    break;
                }
            }

            return node;
        }

        /// <summary>
        /// Searches the next direction using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="node">The node</param>
        /// <returns>The node</returns>
        private static AdvancingFrontNode SearchNextDirection(TriangulationPoint point, AdvancingFrontNode node)
        {
            while ((node = node.Next) != null)
            {
                if (point == node.Point)
                {
                    break;
                }
            }

            return node;
        }
    }
}