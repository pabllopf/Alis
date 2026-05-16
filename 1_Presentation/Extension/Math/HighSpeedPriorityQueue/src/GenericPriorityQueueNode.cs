// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueueNode.cs
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

namespace Alis.Extension.Math.HighSpeedPriorityQueue
{
    /// <summary>
    ///     The generic priority queue node class
    /// </summary>
    public class GenericPriorityQueueNode<TPriority>
    {
        /// <summary>
        ///     The priority value used to determine the node's position in the queue.
        ///     Lower values indicate higher priority. Cannot be set directly — use <c>Enqueue</c> or <c>UpdatePriority</c> instead.
        /// </summary>
        public TPriority Priority { get; protected internal set; }

        /// <summary>
        ///     Current index of this node in the internal heap array.
        ///     Managed internally by the queue; should not be modified externally.
        /// </summary>
        public int QueueIndex { get; internal set; }

        /// <summary>
        ///     Monotonically increasing insertion order counter.
        ///     Used to break priority ties by first-in-first-out order.
        /// </summary>
        public long InsertionIndex { get; internal set; }
    }
}