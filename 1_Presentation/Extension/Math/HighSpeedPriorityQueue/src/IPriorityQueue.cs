// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPriorityQueue.cs
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

namespace Alis.Extension.Math.HighSpeedPriorityQueue
{
    /// <summary>
    ///     The IPriorityQueue interface.  This is mainly here for purists, and in case I decide to add more implementations
    ///     later.
    ///     For speed purposes, it is actually recommended that you *don't* access the priority queue through this interface,
    ///     since the JIT can
    ///     (theoretically?) optimize method calls from concrete-types slightly better.
    /// </summary>
    public interface IPriorityQueue<TItem, in TPriority> : IEnumerable<TItem>
    {
        /// <summary>
        ///     Returns the head of the queue, without removing it (use Dequeue() for that).
        /// </summary>
        TItem First { get; }
        
        /// <summary>
        ///     Returns the number of nodes in the queue.
        /// </summary>
        int Count { get; }
        
        /// <summary>
        ///     Enqueue a node to the priority queue.  Lower values are placed in front. Ties are broken by first-in-first-out.
        ///     See implementation for how duplicates are handled.
        /// </summary>
        void Enqueue(TItem node, TPriority priority);
        
        /// <summary>
        ///     Removes the head of the queue (node with minimum priority; ties are broken by order of insertion), and returns it.
        /// </summary>
        TItem Dequeue();
        
        /// <summary>
        ///     Removes every node from the queue.
        /// </summary>
        void Clear();
        
        /// <summary>
        ///     Returns whether the given node is in the queue.
        /// </summary>
        bool Contains(TItem item);
        
        /// <summary>
        ///     Removes a node from the queue.  The node does not need to be the head of the queue.
        /// </summary>
        void Remove(TItem item);
        
        /// <summary>
        ///     Call this method to change the priority of a node.
        /// </summary>
        void UpdatePriority(TItem node, TPriority priority);
    }
}