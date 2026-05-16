// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TreeNode.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     A node in the dynamic AABB tree. Nodes are pooled and accessed by index; clients do not interact with these directly.
    /// </summary>
    internal struct TreeNode<TNode>
    {
        /// <summary>
        ///     The fat AABB for this node, expanded beyond the actual bounds to allow small movements without tree updates.
        /// </summary>
        internal Aabb Aabb;

        /// <summary>
        ///     Index of the first child node. Leaf nodes have this set to <see cref="DynamicTree{TNode}.NullNode"/>.
        /// </summary>
        internal int Child1;

        /// <summary>
        ///     Index of the second child node. Leaf nodes have this set to <see cref="DynamicTree{TNode}.NullNode"/>.
        /// </summary>
        internal int Child2;

        /// <summary>
        ///     Height of the subtree rooted at this node. Leaves have height 0; free nodes have height -1.
        /// </summary>
        internal int Height;

        /// <summary>
        ///     Index of the parent node, or <see cref="DynamicTree{TNode}.NullNode"/> for the root.
        ///     Also reused as the next-free index in the free list when the node is deallocated.
        /// </summary>
        internal int Parent;

        /// <summary>
        ///     Index of the next free node in the pool's linked list. Reuses the <see cref="Parent"/> field storage.
        /// </summary>
        internal int Next
        {
            get => Parent;
            set => Parent = value;
        }

        /// <summary>
        ///     The application-provided data associated with this node.
        /// </summary>
        internal TNode UserData;

        /// <summary>
        ///     Returns <c>true</c> if this node is a leaf (no children).
        /// </summary>
        /// <returns><c>true</c> if this node has no children; otherwise <c>false</c>.</returns>
        internal bool IsLeaf() => Child1 == DynamicTree<TNode>.NullNode;
    }
}