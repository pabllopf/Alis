// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerCollection.cs
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
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Physic.Controllers;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The controller collection class
    /// </summary>
    /// <seealso cref="IEnumerable{Controller}" />
    /// <seealso cref="ICollection{Controller}" />
    /// <seealso cref="IList{Controller}" />
    public class ControllerCollection : IEnumerable<Controller>
        , ICollection<Controller>, IList<Controller>
    {
        /// <summary>
        ///     The controller
        /// </summary>
        internal readonly List<Controller> List = new List<Controller>(32);

        /// <summary>
        ///     The world
        /// </summary>
        private readonly World _world;

        /// <summary>
        ///     The generation stamp
        /// </summary>
        internal int GenerationStamp = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ControllerCollection" /> class
        /// </summary>
        /// <param name="world">The world</param>
        public ControllerCollection(World world) => _world = world;

        
        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of controller</returns>
        IEnumerator<Controller> IEnumerable<Controller>.GetEnumerator() => new ControllerEnumerator(this, List);
        
        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => new ControllerEnumerator(this, List);
        
        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The controller enumerator</returns>
        public ControllerEnumerator GetEnumerator() => new ControllerEnumerator(this, List);

        
        /// <summary>
        ///     The not supported exception
        /// </summary>
        public Controller this[int index]
        {
            get => List[index];
            set => throw new NotSupportedException();
        }

        /// <summary>
        ///     Indexes the of using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The int</returns>
        public int IndexOf(Controller item) => List.IndexOf(item);

        /// <summary>
        ///     Inserts the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="item">The item</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Controller>.Insert(int index, Controller item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Controller>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }
        
        /// <summary>
        ///     Gets the value of the is read only
        /// </summary>
        public bool IsReadOnly => true;

        /// <summary>
        ///     Gets the value of the count
        /// </summary>
        public int Count => List.Count;

        /// <summary>
        ///     Adds the item
        /// </summary>
        /// <param name="item">The item</param>
        /// <exception cref="NotSupportedException"></exception>
        void ICollection<Controller>.Add(Controller item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance remove
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        bool ICollection<Controller>.Remove(Controller item) => throw new NotSupportedException();

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        void ICollection<Controller>.Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Contains(Controller item) => List.Contains(item);

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        public void CopyTo(Controller[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }
    }
}