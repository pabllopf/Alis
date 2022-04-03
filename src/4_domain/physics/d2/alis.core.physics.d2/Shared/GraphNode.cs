// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GraphNode.cs
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

namespace Alis.Core.Systems.Physics2D.Shared
{
    /// <summary>
    ///     The graph node class
    /// </summary>
    public class GraphNode<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphNode{T}" /> class
        /// </summary>
        /// <param name="item">The item</param>
        public GraphNode(T item = default(T)) => Item = item;

        /// <summary>The item.</summary>
        public T Item { get; set; }

        /// <summary>The next item in the list.</summary>
        public GraphNode<T> Next { get; set; }

        /// <summary>The previous item in the list.</summary>
        public GraphNode<T> Prev { get; set; }

        /// <summary>
        ///     Invalidates this instance
        /// </summary>
        internal void Invalidate()
        {
            Next = null;
            Prev = null;
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            Item = default(T);
            Invalidate();
        }
    }
}