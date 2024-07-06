// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedSizePriorityQueue.cs
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

using System;
using System.Collections.Generic;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The fixed size priority queue class
    /// </summary>
    public class FixedSizePriorityQueue<TItem, TPriority> where TPriority : IComparable<TPriority>
    {
        /// <summary>
        ///     The items
        /// </summary>
        private readonly List<(TItem item, TPriority priority)> _items;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FixedSizePriorityQueue" /> class
        /// </summary>
        /// <param name="maxSize">The max size</param>
        public FixedSizePriorityQueue(int maxSize)
        {
            MaxSize = maxSize;
            _items = new List<(TItem, TPriority)>(maxSize);
        }

        /// <summary>
        ///     Gets or sets the value of the max size
        /// </summary>
        public int MaxSize { get; }

        /// <summary>
        ///     Enqueues the item
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="priority">The priority</param>
        /// <exception cref="InvalidOperationException">Queue has reached its maximum size.</exception>
        public void Enqueue(TItem item, TPriority priority)
        {
            if (_items.Count == MaxSize)
                throw new InvalidOperationException("Queue has reached its maximum size.");

            _items.Add((item, priority));
            _items.Sort((x, y) => x.priority.CompareTo(y.priority));
        }

        /// <summary>
        ///     Dequeues this instance
        /// </summary>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        /// <returns>The item</returns>
        public TItem Dequeue()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            TItem item = _items[0].item;
            _items.RemoveAt(0);
            return item;
        }
    }
}