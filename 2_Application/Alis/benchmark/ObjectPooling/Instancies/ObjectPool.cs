// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectPool.cs
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

namespace Alis.Benchmark.ObjectPooling.Instancies
{
    /// <summary>
    ///     The object pool class
    /// </summary>
    public class ObjectPool<T> where T : new()
    {
        /// <summary>
        ///     The
        /// </summary>
        private readonly Stack<T> pool = new Stack<T>();

        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <returns>The</returns>
        public T Get() => pool.Count > 0 ? pool.Pop() : new T();

        /// <summary>
        ///     Returns the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        public void Return(T obj)
        {
            pool.Push(obj);
        }
    }
}