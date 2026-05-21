// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyCollection.cs
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

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The body collection class
    /// </summary>
    /// <seealso cref="IEnumerable{Body}" />
    /// <seealso cref="ICollection{Body}" />
    /// <seealso cref="IList{Body}" />
    public class BodyCollection : IEnumerable<Body>
        , ICollection<Body>, IList<Body>
    {
        /// <summary>
        ///     The body
        /// </summary>
        internal readonly List<Body> List = new List<Body>(32);

        /// <summary>
        ///     The world
        /// </summary>
        private readonly WorldPhysic worldPhysic;

        /// <summary>
        ///     The generation stamp
        /// </summary>
        internal int GenerationStamp = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BodyCollection" /> class
        /// </summary>
        /// <param name="worldPhysic">The world</param>
        public BodyCollection(WorldPhysic worldPhysic) => this.worldPhysic = worldPhysic;


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
        void ICollection<Body>.Add(Body item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance remove
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        bool ICollection<Body>.Remove(Body item) => throw new NotSupportedException();

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        void ICollection<Body>.Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Contains(Body item) => List.Contains(item);

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        public void CopyTo(Body[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of body</returns>
        IEnumerator<Body> IEnumerable<Body>.GetEnumerator() => new BodyEnumerator(this, List);


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => new BodyEnumerator(this, List);


        /// <summary>
        ///     The not supported exception
        /// </summary>
        public Body this[int index]
        {
            get => List[index];
            set => throw new NotSupportedException();
        }

        /// <summary>
        ///     Indexes the of using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The int</returns>
        public int IndexOf(Body item) => List.IndexOf(item);

        /// <summary>
        ///     Inserts the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="item">The item</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Body>.Insert(int index, Body item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Body>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The body enumerator</returns>
        public BodyEnumerator GetEnumerator() => new BodyEnumerator(this, List);


        /// <summary>
        ///     The body enumerator
        /// </summary>
        public struct BodyEnumerator : IEnumerator<Body>
        {
            /// <summary>
            ///     The collection
            /// </summary>
            private BodyCollection _collection;

            /// <summary>
            ///     The list
            /// </summary>
            private List<Body> _list;

            /// <summary>
            ///     The generation stamp
            /// </summary>
            private readonly int _generationStamp;

            /// <summary>
            ///     The
            /// </summary>
            private int i;

            /// <summary>
            ///     Initializes a new instance of the <see cref="BodyEnumerator" /> class
            /// </summary>
            /// <param name="collection">The collection</param>
            /// <param name="list">The list</param>
            public BodyEnumerator(BodyCollection collection, List<Body> list)
            {
                _collection = collection;
                _list = list;
                _generationStamp = collection.GenerationStamp;
                i = -1;
            }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            public Body Current
            {
                get
                {
                    if (_generationStamp == _collection.GenerationStamp)
                    {
                        return _list[i];
                    }

                    throw new InvalidOperationException("Collection was modified.");
                }
            }


            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            Body IEnumerator<Body>.Current
            {
                get
                {
                    if (_generationStamp == _collection.GenerationStamp)
                    {
                        return _list[i];
                    }

                    throw new InvalidOperationException("Collection was modified.");
                }
            }


            /// <summary>
            ///     Describes whether this instance move next
            /// </summary>
            /// <exception cref="InvalidOperationException">Collection was modified.</exception>
            /// <returns>The bool</returns>
            public bool MoveNext()
            {
                if (_generationStamp != _collection.GenerationStamp)
                {
                    throw new InvalidOperationException("Collection was modified.");
                }

                return ++i < _list.Count;
            }


            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    if (_generationStamp == _collection.GenerationStamp)
                    {
                        return _list[i];
                    }

                    throw new InvalidOperationException();
                }
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            void IDisposable.Dispose()
            {
                _collection = null;
                _list = null;
                i = -1;
            }

            /// <summary>
            ///     Resets this instance
            /// </summary>
            void IEnumerator.Reset()
            {
                i = -1;
            }
        }
    }
}