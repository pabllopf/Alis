// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureCollection.cs
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
    ///     The fixture collection class
    /// </summary>
    /// <seealso cref="IEnumerable{Fixture}" />
    /// <seealso cref="ICollection{Fixture}" />
    /// <seealso cref="IList{Fixture}" />
    public class FixtureCollection : IEnumerable<Fixture>
        , ICollection<Fixture>, IList<Fixture>
    {
        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body _body;

        /// <summary>
        ///     The fixture
        /// </summary>
        internal readonly List<Fixture> List = new List<Fixture>(32);

        /// <summary>
        ///     The generation stamp
        /// </summary>
        internal int GenerationStamp = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FixtureCollection" /> class
        /// </summary>
        /// <param name="body">The body</param>
        public FixtureCollection(Body body) => _body = body;


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
        void ICollection<Fixture>.Add(Fixture item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance remove
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        bool ICollection<Fixture>.Remove(Fixture item) => throw new NotSupportedException();

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        void ICollection<Fixture>.Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Contains(Fixture item) => List.Contains(item);

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        public void CopyTo(Fixture[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of fixture</returns>
        IEnumerator<Fixture> IEnumerable<Fixture>.GetEnumerator() => new FixtureEnumerator(this, List);


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => new FixtureEnumerator(this, List);


        /// <summary>
        ///     The not supported exception
        /// </summary>
        public Fixture this[int index]
        {
            get => List[index];
            set => throw new NotSupportedException();
        }

        /// <summary>
        ///     Indexes the of using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The int</returns>
        public int IndexOf(Fixture item) => List.IndexOf(item);

        /// <summary>
        ///     Inserts the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="item">The item</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Fixture>.Insert(int index, Fixture item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Fixture>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }


        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The fixture enumerator</returns>
        public FixtureEnumerator GetEnumerator() => new FixtureEnumerator(this, List);


        /// <summary>
        ///     The fixture enumerator
        /// </summary>
        public struct FixtureEnumerator : IEnumerator<Fixture>
        {
            /// <summary>
            ///     The collection
            /// </summary>
            private FixtureCollection _collection;

            /// <summary>
            ///     The list
            /// </summary>
            private List<Fixture> _list;

            /// <summary>
            ///     The generation stamp
            /// </summary>
            private readonly int _generationStamp;

            /// <summary>
            ///     The
            /// </summary>
            private int i;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FixtureEnumerator" /> class
            /// </summary>
            /// <param name="collection">The collection</param>
            /// <param name="list">The list</param>
            public FixtureEnumerator(FixtureCollection collection, List<Fixture> list)
            {
                _collection = collection;
                _list = list;
                _generationStamp = collection.GenerationStamp;
                i = -1;
            }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            public Fixture Current
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
            Fixture IEnumerator<Fixture>.Current
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