// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerEnumerator.cs
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
    ///     The controller enumerator
    /// </summary>
    public struct ControllerEnumerator : IEnumerator<Controller>
    {
        /// <summary>
        ///     The collection
        /// </summary>
        private ControllerCollection _collection;

        /// <summary>
        ///     The list
        /// </summary>
        private List<Controller> _list;

        /// <summary>
        ///     The generation stamp
        /// </summary>
        private readonly int _generationStamp;

        /// <summary>
        ///     The
        /// </summary>
        private int i;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ControllerEnumerator" /> class
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="list">The list</param>
        public ControllerEnumerator(ControllerCollection collection, List<Controller> list)
        {
            _collection = collection;
            _list = list;
            _generationStamp = collection.GenerationStamp;
            i = -1;
        }

        /// <summary>
        ///     Gets the value of the current
        /// </summary>
        public Controller Current
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

        #region IEnumerator<Controller>

        /// <summary>
        ///     Gets the value of the current
        /// </summary>
        Controller IEnumerator<Controller>.Current
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

        #endregion IEnumerator<Controller>

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
}