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

/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    // Node for a Directed Acyclic graph (DAG)
    internal abstract class Node
    {
        protected Node LeftChild;
        public List<Node> ParentList;
        protected Node RightChild;

        protected Node(Node left, Node right)
        {
            ParentList = new List<Node>();
            LeftChild = left;
            RightChild = right;

            if (left != null)
                left.ParentList.Add(this);
            if (right != null)
                right.ParentList.Add(this);
        }

        public abstract Sink Locate(Edge s);

        // Replace a node in the graph with this node
        // Make sure parent pointers are updated
        public void Replace(Node node)
        {
            foreach (Node parent in node.ParentList)
            {
                // Select the correct node to replace (left or right child)
                if (parent.LeftChild == node)
                    parent.LeftChild = this;
                else
                    parent.RightChild = this;
            }

            ParentList.AddRange(node.ParentList);
        }
    }
}