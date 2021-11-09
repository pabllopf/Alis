// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Pool.cs
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

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Alis.Core.Systems.Physics2D.Shared
{
    /// <summary>
    ///     The pool class
    /// </summary>
    public class Pool<T>
    {
        /// <summary>
        ///     The object creator
        /// </summary>
        private readonly Func<T> objectCreator;

        /// <summary>
        ///     The object reset
        /// </summary>
        private readonly Action<T> objectReset;

        /// <summary>
        ///     The queue
        /// </summary>
        private readonly Queue<T> queue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Pool" /> class
        /// </summary>
        /// <param name="objectCreator">The object creator</param>
        /// <param name="objectReset">The object reset</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="preCreateInstances">The pre create instances</param>
        public Pool(Func<T> objectCreator, Action<T> objectReset = null, int capacity = 16,
            bool preCreateInstances = true)
        {
            this.objectCreator = objectCreator;
            this.objectReset = objectReset;
            queue = new Queue<T>(capacity);

            if (!preCreateInstances)
            {
                return;
            }

            for (int i = 0; i < capacity; i++)
            {
                T obj = objectCreator();
                queue.Enqueue(obj);
            }
        }

        /// <summary>
        ///     Gets the value of the left in pool
        /// </summary>
        public int LeftInPool => queue.Count;

        /// <summary>
        ///     Gets the from pool using the specified reset
        /// </summary>
        /// <param name="reset">The reset</param>
        /// <returns>The obj</returns>
        public T GetFromPool(bool reset = false)
        {
            if (queue.Count == 0)
            {
                return objectCreator();
            }

            T obj = queue.Dequeue();

            if (reset)
            {
                objectReset?.Invoke(obj);
            }

            return obj;
        }

        /// <summary>
        ///     Gets the many from pool using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <returns>An enumerable of t</returns>
        public IEnumerable<T> GetManyFromPool(int count)
        {
            Debug.Assert(count != 0);

            for (int i = 0; i < count; i++)
            {
                yield return GetFromPool();
            }
        }

        /// <summary>
        ///     Returns the to pool using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="reset">The reset</param>
        public void ReturnToPool(T obj, bool reset = true)
        {
            if (reset)
            {
                objectReset?.Invoke(obj);
            }

            queue.Enqueue(obj);
        }

        /// <summary>
        ///     Returns the to pool using the specified objs
        /// </summary>
        /// <param name="objs">The objs</param>
        /// <param name="reset">The reset</param>
        public void ReturnToPool(IEnumerable<T> objs, bool reset = true)
        {
            foreach (T obj in objs)
            {
                ReturnToPool(obj, reset);
            }
        }
    }
}