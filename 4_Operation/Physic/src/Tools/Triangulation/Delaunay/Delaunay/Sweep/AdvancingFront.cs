// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AdvancingFront.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

// Changes from the Java version
//   Removed BST code, but not all artifacts of it
// Future possibilities
//   Eliminate Add/RemoveNode ?
//   Comments comments and more comments!

using System;
using System.Text;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay.Sweep
{
    /**
     * @author Thomas Åhlen (thahlen@gmail.com)
     */
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
            //_searchTree.put(node.key, node);
        }

        /// <summary>
        ///     Removes the node using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        public void RemoveNode(AdvancingFrontNode node)
        {
            //_searchTree.delete( node.key );
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
        ///     MM:  This seems to be used by LocateNode to guess a position in the implicit linked list of
        ///     AdvancingFrontNodes near x Removed an overload that depended on this being exact
        /// </summary>
        private AdvancingFrontNode FindSearchNode(double x) =>
            // TODO: implement BST index 
            Search;

        /// <summary>We use a balancing tree to locate a node smaller or equal to given key value</summary>
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

        /// <summary>This implementation will use simple node traversal algorithm to find a point on the front</summary>
        public AdvancingFrontNode LocatePoint(TriangulationPoint point)
        {
            double px = point.X;
            AdvancingFrontNode node = FindSearchNode(px);
            double nx = node.Point.X;

            if (px == nx)
            {
                if (point != node.Point)
                {
                    // We might have two nodes with same x value for a short time
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

                        //node = null;
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