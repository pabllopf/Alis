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
    ///     Represents a node in the dynamic bounding volume tree (DynamicTree).
    /// </summary>
    /// <typeparam name="TNode">The type of the user data stored in this tree node.</typeparam>
    /// <remarks>
    ///     The client does not interact with this struct directly. It is managed internally by <see cref="DynamicTree{TNode}"/>.
    ///     Leaf nodes have <see cref="Height"/> = 0 and both children set to <see cref="DynamicTree{TNode}.NullNode"/>.
    ///     Free nodes have <see cref="Height"/> = -1 and use <see cref="Parent"/> for a free-list linked list.
    /// </remarks>
    internal struct TreeNode<TNode>
    {
        /// <summary>
        ///     Gets or sets the enlarged axis-aligned bounding box for this node.
        /// </summary>
        /// <value>
        ///     An <see cref="Aabb"/> representing the node's bounding box, expanded for safety margins.
        /// </value>
        internal Aabb Aabb;

        /// <summary>
        ///     Gets or sets the index of the first child node.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the index of the left child, or <see cref="DynamicTree{TNode}.NullNode"/> for leaf nodes.
        /// </value>
        internal int Child1;

        /// <summary>
        ///     Gets or sets the index of the second child node.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the index of the right child, or <see cref="DynamicTree{TNode}.NullNode"/> for leaf nodes.
        /// </value>
        internal int Child2;

        // leaf = 0, free node = -1
        /// <summary>
        ///     Gets or sets the height of this node in the tree.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the distance to the nearest leaf. Zero for leaf nodes, -1 for free nodes.
        /// </value>
        internal int Height;

        /// <summary>
        ///     Gets or sets the index of the parent node.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the index of the parent, or <see cref="DynamicTree{TNode}.NullNode"/> for root nodes.
        /// </value>
        /// <remarks>
        ///     For free nodes, this field is repurposed as the next free node index in a linked list.
        /// </remarks>
        internal int Parent;

        // to reduce struct size we use Parent for the Free linked-list
        /// <summary>
        ///     Gets or sets the next free node index in the free-list.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the index of the next free node, or <see cref="DynamicTree{TNode}.NullNode"/> if this is the last free node.
        /// </value>
        /// <remarks>
        ///     This property provides a named interface to the <see cref="Parent"/> field when the node is free.
        ///     For non-free nodes, this returns/sets the parent index.
        /// </remarks>
        internal int Next
        {
            get => Parent;
            set => Parent = value;
        }

        /// <summary>
        ///     Gets or sets the user data associated with this node.
        /// </summary>
        /// <value>
        ///     The <typeparamref name="TNode"/> user data stored in this tree node.
        /// </value>
        internal TNode UserData;


        /// <summary>
        ///     Determines whether this node is a leaf node.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this node is a leaf (has no children); otherwise, <c>false</c>.
        /// </returns>
        internal bool IsLeaf() => Child1 == DynamicTree<TNode>.NullNode;
    }
}