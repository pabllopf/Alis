// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Node.cs
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
    /// <summary>
    ///     The node class
    /// </summary>
    internal abstract class Node
    {
        /// <summary>
        ///     The parent list
        /// </summary>
        public readonly List<Node> ParentList;

        /// <summary>
        ///     The left child
        /// </summary>
        protected Node LeftChild;

        /// <summary>
        ///     The right child
        /// </summary>
        protected Node RightChild;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Node" /> class
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        protected Node(Node left, Node right)
        {
            ParentList = new List<Node>();
            LeftChild = left;
            RightChild = right;

            if (left != null)
            {
                left.ParentList.Add(this);
            }

            if (right != null)
            {
                right.ParentList.Add(this);
            }
        }

        /// <summary>
        ///     Locates the s
        /// </summary>
        /// <param name="edge">The </param>
        /// <returns>The sink</returns>
        public abstract Sink Locate(Edge edge);

        /// <summary>
        ///     Replaces the node
        /// </summary>
        /// <param name="node">The node</param>
        public void Replace(Node node)
        {
            foreach (Node parent in node.ParentList)
            {
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = this;
                }
                else
                {
                    parent.RightChild = this;
                }
            }

            ParentList.AddRange(node.ParentList);
        }
    }
}