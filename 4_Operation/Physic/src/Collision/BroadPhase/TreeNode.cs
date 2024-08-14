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

using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision.BroadPhase
{
    /// <summary>A node in the dynamic tree. The client does not interact with this directly.</summary>
    internal class TreeNode<T>
    {
        /// <summary>Enlarged AABB</summary>
        internal Aabb Aabb;
        
        /// <summary>
        ///     The child
        /// </summary>
        internal int Child1 { get; set; }
        
        /// <summary>
        ///     The child
        /// </summary>
        internal int Child2 { get; set; }
        
        /// <summary>
        ///     The height
        /// </summary>
        internal int Height { get; set; }
        
        /// <summary>
        ///     The moved
        /// </summary>
        internal bool Moved { get; set; }
        
        /// <summary>
        ///     The parent or next
        /// </summary>
        internal int ParentOrNext { get; set; }
        
        /// <summary>
        ///     The user data
        /// </summary>
        internal T UserData { get; set; }
        
        /// <summary>
        ///     Describes whether this instance is leaf
        /// </summary>
        /// <returns>The bool</returns>
        internal bool IsLeaf() => Child1 == DynamicTree<T>.NullNode;
    }
}