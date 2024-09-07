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
    public class ControllerCollection : IEnumerable<Controller>
        , ICollection<Controller>, IList<Controller>
    {
        internal readonly List<Controller> _list = new List<Controller>(32);
        private readonly World _world;
        internal int _generationStamp = 0;

        public ControllerCollection(World world) => _world = world;


        #region IEnumerable<Controller>

        IEnumerator<Controller> IEnumerable<Controller>.GetEnumerator() => new ControllerEnumerator(this, _list);

        #endregion IEnumerable<Controller>


        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() => new ControllerEnumerator(this, _list);

        #endregion IEnumerable

        public ControllerEnumerator GetEnumerator() => new ControllerEnumerator(this, _list);


        public struct ControllerEnumerator : IEnumerator<Controller>
        {
            private ControllerCollection _collection;
            private List<Controller> _list;
            private readonly int _generationStamp;
            private int i;

            public ControllerEnumerator(ControllerCollection collection, List<Controller> list)
            {
                _collection = collection;
                _list = list;
                _generationStamp = collection._generationStamp;
                i = -1;
            }

            public Controller Current
            {
                get
                {
                    if (_generationStamp == _collection._generationStamp)
                        return _list[i];
                    throw new InvalidOperationException("Collection was modified.");
                }
            }

            #region IEnumerator<Controller>

            Controller IEnumerator<Controller>.Current
            {
                get
                {
                    if (_generationStamp == _collection._generationStamp)
                        return _list[i];
                    throw new InvalidOperationException("Collection was modified.");
                }
            }

            #endregion IEnumerator<Controller>

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


        #region IList<Controller>

        public Controller this[int index]
        {
            get => _list[index];
            set => throw new NotSupportedException();
        }

        public int IndexOf(Controller item) => _list.IndexOf(item);

        void IList<Controller>.Insert(int index, Controller item)
        {
            throw new NotSupportedException();
        }

        void IList<Controller>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        #endregion IList<Controller>


        #region ICollection<Controller>

        public bool IsReadOnly => true;

        public int Count => _list.Count;

        void ICollection<Controller>.Add(Controller item)
        {
            throw new NotSupportedException();
        }

        bool ICollection<Controller>.Remove(Controller item) => throw new NotSupportedException();

        void ICollection<Controller>.Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(Controller item) => _list.Contains(item);

        public void CopyTo(Controller[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        #endregion ICollection<Controller>
    }
}