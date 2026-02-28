// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorkItemPool.cs
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

using System.Collections.Concurrent;

namespace Alis.Extension.Thread.Core
{
    /// <summary>
    ///     Object pool for WorkItem instances to reduce allocations
    /// </summary>
    internal sealed class WorkItemPool
    {
        /// <summary>
        ///     The pool of work items
        /// </summary>
        private readonly ConcurrentBag<WorkItem> pool = new ConcurrentBag<WorkItem>();

        /// <summary>
        ///     Rents a work item from the pool
        /// </summary>
        /// <returns>A work item instance</returns>
        public WorkItem Rent()
        {
            if (pool.TryTake(out WorkItem item))
            {
                return item;
            }

            return new WorkItem();
        }

        /// <summary>
        ///     Returns a work item to the pool
        /// </summary>
        /// <param name="item">The work item to return</param>
        public void Return(WorkItem item)
        {
            item.Reset();
            pool.Add(item);
        }

        /// <summary>
        ///     Clears the pool
        /// </summary>
        public void Clear()
        {
            while (pool.TryTake(out _))
            {
                // Clear all items
            }
        }
    }
}

