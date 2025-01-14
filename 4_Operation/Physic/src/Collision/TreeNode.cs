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

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     A node in the dynamic tree. The client does not interact with this directly.
    /// </summary>
    internal struct TreeNode<TNode>
    {
        /// <summary>
        ///     Enlarged AABB
        /// </summary>
        internal Aabb Aabb;

        /// <summary>
        ///     The child
        /// </summary>
        internal int Child1;

        /// <summary>
        ///     The child
        /// </summary>
        internal int Child2;

        // leaf = 0, free node = -1
        /// <summary>
        ///     The height
        /// </summary>
        internal int Height;

        /// <summary>
        ///     The parent
        /// </summary>
        internal int Parent;

        // to reduce struct size we use Parent for the Free linked-list
        /// <summary>
        ///     Next free node
        /// </summary>
        internal int Next
        {
            get => Parent;
            set => Parent = value;
        }

        /// <summary>
        ///     The user data
        /// </summary>
        internal TNode UserData;


        /// <summary>
        ///     Describes whether this instance is leaf
        /// </summary>
        /// <returns>The bool</returns>
        internal bool IsLeaf() => Child1 == DynamicTree<TNode>.NullNode;
    }
}