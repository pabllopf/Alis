// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointCollection.cs
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
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The joint collection class
    /// </summary>
    /// <seealso cref="IEnumerable{Joint}" />
    /// <seealso cref="ICollection{Joint}" />
    /// <seealso cref="IList{Joint}" />
    public class JointCollection : IEnumerable<Joint>
        , ICollection<Joint>, IList<Joint>
    {
        /// <summary>
        ///     The joint
        /// </summary>
        internal readonly List<Joint> List = new List<Joint>(32);

        /// <summary>
        ///     The world
        /// </summary>
        private readonly World _world;

        /// <summary>
        ///     The generation stamp
        /// </summary>
        internal int GenerationStamp = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JointCollection" /> class
        /// </summary>
        /// <param name="world">The world</param>
        public JointCollection(World world) => _world = world;


        #region IEnumerable<Joint>

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of joint</returns>
        IEnumerator<Joint> IEnumerable<Joint>.GetEnumerator() => new JointEnumerator(this, List);

        #endregion IEnumerable<Joint>


        #region IEnumerable

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => new JointEnumerator(this, List);

        #endregion IEnumerable

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        /// <returns>The joint enumerator</returns>
        public JointEnumerator GetEnumerator() => new JointEnumerator(this, List);


        /// <summary>
        ///     The joint enumerator
        /// </summary>
        public struct JointEnumerator : IEnumerator<Joint>
        {
            /// <summary>
            ///     The collection
            /// </summary>
            private JointCollection _collection;

            /// <summary>
            ///     The list
            /// </summary>
            private List<Joint> _list;

            /// <summary>
            ///     The generation stamp
            /// </summary>
            private readonly int _generationStamp;

            /// <summary>
            ///     The
            /// </summary>
            private int i;

            /// <summary>
            ///     Initializes a new instance of the <see cref="JointEnumerator" /> class
            /// </summary>
            /// <param name="collection">The collection</param>
            /// <param name="list">The list</param>
            public JointEnumerator(JointCollection collection, List<Joint> list)
            {
                _collection = collection;
                _list = list;
                _generationStamp = collection.GenerationStamp;
                i = -1;
            }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            public Joint Current
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

            #region IEnumerator<Joint>

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            Joint IEnumerator<Joint>.Current
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

            #endregion IEnumerator<Joint>

            #region IEnumerator

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

            #endregion IEnumerator
        }


        #region IList<Joint>

        /// <summary>
        ///     The not supported exception
        /// </summary>
        public Joint this[int index]
        {
            get => List[index];
            set => throw new NotSupportedException();
        }

        /// <summary>
        ///     Indexes the of using the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The int</returns>
        public int IndexOf(Joint item) => List.IndexOf(item);

        /// <summary>
        ///     Inserts the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="item">The item</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Joint>.Insert(int index, Joint item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <exception cref="NotSupportedException"></exception>
        void IList<Joint>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        #endregion IList<Joint>


        #region ICollection<Joint>

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
        void ICollection<Joint>.Add(Joint item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance remove
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        bool ICollection<Joint>.Remove(Joint item) => throw new NotSupportedException();

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        void ICollection<Joint>.Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The bool</returns>
        public bool Contains(Joint item) => List.Contains(item);

        /// <summary>
        ///     Copies the to using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The array index</param>
        public void CopyTo(Joint[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        #endregion ICollection<Joint>
    }
}