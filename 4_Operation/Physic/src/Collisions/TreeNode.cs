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
    ///     A node in the dynamic tree (AABB tree) used for broad-phase collision detection.
    ///     Leaf nodes store AABBs of collision proxies; internal nodes combine child AABBs.
    ///     The tree is stored as a contiguous array with linked-list free node management.
    /// </summary>
    internal struct TreeNode<TNode>
    {
        /// <summary>
        ///     The fat axis-aligned bounding box for this node, enlarged by the AABB extension factor
        ///     to allow small movements without requiring tree updates.
        /// </summary>
        internal Aabb Aabb;

        /// <summary>
        ///     The index of the first child node. For leaf nodes, this equals <see cref="DynamicTree{TNode}.NullNode"/>.
        /// </summary>
        internal int Child1;

        /// <summary>
        ///     The index of the second child node. For leaf nodes, this equals <see cref="DynamicTree{TNode}.NullNode"/>.
        /// </summary>
        internal int Child2;

        /// <summary>
        ///     The height of the subtree rooted at this node.
        ///     Leaf nodes have height 0, free nodes have height -1.
        /// </summary>
        internal int Height;

        /// <summary>
        ///     The index of the parent node. For the root node, this equals <see cref="DynamicTree{TNode}.NullNode"/>.
        ///     For free nodes, this is repurposed as the next free node index.
        /// </summary>
        internal int Parent;

        /// <summary>
        ///     Gets or sets the next free node index in the free list.
        ///     This property reuses the <see cref="Parent"/> field to reduce struct size,
        ///     since a node cannot be both in-use and free simultaneously.
        /// </summary>
        internal int Next
        {
            get => Parent;
            set => Parent = value;
        }

        /// <summary>
        ///     The user data associated with this node (e.g., a <see cref="FixtureProxy"/> reference).
        /// </summary>
        internal TNode UserData;

        /// <summary>
        ///     Determines whether this node is a leaf node. Leaf nodes have no children
        ///     (Child1 equals <see cref="DynamicTree{TNode}.NullNode"/>).
        /// </summary>
        /// <returns><c>true</c> if this node is a leaf; otherwise, <c>false</c>.</returns>
        internal bool IsLeaf() => Child1 == DynamicTree<TNode>.NullNode;
    }
}