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
    public class JointCollection : IEnumerable<Joint>
        , ICollection<Joint>, IList<Joint>
    {
        internal readonly List<Joint> _list = new List<Joint>(32);
        private readonly World _world;
        internal int _generationStamp = 0;

        public JointCollection(World world) => _world = world;


        #region IEnumerable<Joint>

        IEnumerator<Joint> IEnumerable<Joint>.GetEnumerator() => new JointEnumerator(this, _list);

        #endregion IEnumerable<Joint>


        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() => new JointEnumerator(this, _list);

        #endregion IEnumerable

        public JointEnumerator GetEnumerator() => new JointEnumerator(this, _list);


        public struct JointEnumerator : IEnumerator<Joint>
        {
            private JointCollection _collection;
            private List<Joint> _list;
            private readonly int _generationStamp;
            private int i;

            public JointEnumerator(JointCollection collection, List<Joint> list)
            {
                _collection = collection;
                _list = list;
                _generationStamp = collection._generationStamp;
                i = -1;
            }

            public Joint Current
            {
                get
                {
                    if (_generationStamp == _collection._generationStamp)
                        return _list[i];
                    throw new InvalidOperationException("Collection was modified.");
                }
            }

            #region IEnumerator<Joint>

            Joint IEnumerator<Joint>.Current
            {
                get
                {
                    if (_generationStamp == _collection._generationStamp)
                        return _list[i];
                    throw new InvalidOperationException("Collection was modified.");
                }
            }

            #endregion IEnumerator<Joint>

            #region IEnumerator

            public bool MoveNext()
            {
                if (_generationStamp != _collection._generationStamp)
                    throw new InvalidOperationException("Collection was modified.");

                return ++i < _list.Count;
            }


            object IEnumerator.Current
            {
                get
                {
                    if (_generationStamp == _collection._generationStamp)
                        return _list[i];
                    throw new InvalidOperationException();
                }
            }

            void IDisposable.Dispose()
            {
                _collection = null;
                _list = null;
                i = -1;
            }

            void IEnumerator.Reset()
            {
                i = -1;
            }

            #endregion IEnumerator
        }


        #region IList<Joint>

        public Joint this[int index]
        {
            get => _list[index];
            set => throw new NotSupportedException();
        }

        public int IndexOf(Joint item) => _list.IndexOf(item);

        void IList<Joint>.Insert(int index, Joint item)
        {
            throw new NotSupportedException();
        }

        void IList<Joint>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        #endregion IList<Joint>


        #region ICollection<Joint>

        public bool IsReadOnly => true;

        public int Count => _list.Count;

        void ICollection<Joint>.Add(Joint item)
        {
            throw new NotSupportedException();
        }

        bool ICollection<Joint>.Remove(Joint item) => throw new NotSupportedException();

        void ICollection<Joint>.Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(Joint item) => _list.Contains(item);

        public void CopyTo(Joint[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        #endregion ICollection<Joint>
    }
}