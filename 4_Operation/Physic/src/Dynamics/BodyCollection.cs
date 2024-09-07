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
    public class BodyCollection : IEnumerable<Body>
        , ICollection<Body>, IList<Body>
    {
        internal readonly List<Body> _list = new List<Body>(32);
        private readonly World _world;
        internal int _generationStamp = 0;

        public BodyCollection(World world) => _world = world;


        #region IEnumerable<Body>

        IEnumerator<Body> IEnumerable<Body>.GetEnumerator() => new BodyEnumerator(this, _list);

        #endregion IEnumerable<Body>


        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() => new BodyEnumerator(this, _list);

        #endregion IEnumerable

        public BodyEnumerator GetEnumerator() => new BodyEnumerator(this, _list);


        public struct BodyEnumerator : IEnumerator<Body>
        {
            private BodyCollection _collection;
            private List<Body> _list;
            private readonly int _generationStamp;
            private int i;

            public BodyEnumerator(BodyCollection collection, List<Body> list)
            {
                _collection = collection;
                _list = list;
                _generationStamp = collection._generationStamp;
                i = -1;
            }

            public Body Current
            {
                get
                {
                    if (_generationStamp == _collection._generationStamp)
                        return _list[i];
                    throw new InvalidOperationException("Collection was modified.");
                }
            }

            #region IEnumerator<Body>

            Body IEnumerator<Body>.Current
            {
                get
                {
                    if (_generationStamp == _collection._generationStamp)
                        return _list[i];
                    throw new InvalidOperationException("Collection was modified.");
                }
            }

            #endregion IEnumerator<Body>

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


        #region IList<Body>

        public Body this[int index]
        {
            get => _list[index];
            set => throw new NotSupportedException();
        }

        public int IndexOf(Body item) => _list.IndexOf(item);

        void IList<Body>.Insert(int index, Body item)
        {
            throw new NotSupportedException();
        }

        void IList<Body>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        #endregion IList<Body>


        #region ICollection<Body>

        public bool IsReadOnly => true;

        public int Count => _list.Count;

        void ICollection<Body>.Add(Body item)
        {
            throw new NotSupportedException();
        }

        bool ICollection<Body>.Remove(Body item) => throw new NotSupportedException();

        void ICollection<Body>.Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(Body item) => _list.Contains(item);

        public void CopyTo(Body[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        #endregion ICollection<Body>
    }
}