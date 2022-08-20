// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectBase.cs
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

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     The ObjectBase class is an abstract base for every
    ///     SFML object. It's meant for internal use only
    /// </summary>
    ////////////////////////////////////////////////////////////
    public abstract class ObjectBase : IDisposable
    {
        /// <summary>
        ///     The zero
        /// </summary>
        private IntPtr myCPointer = IntPtr.Zero;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the object from a pointer to the C library object
        /// </summary>
        /// <param name="cPointer">Internal pointer to the object in the C libraries</param>
        ////////////////////////////////////////////////////////////
        public ObjectBase(IntPtr cPointer) => myCPointer = cPointer;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Access to the internal pointer of the object.
        ///     For internal use only
        /// </summary>
        ////////////////////////////////////////////////////////////
        public IntPtr CPointer
        {
            get => myCPointer;
            protected set => myCPointer = value;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Explicitly dispose the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Dispose the object
        /// </summary>
        ////////////////////////////////////////////////////////////
        ~ObjectBase()
        {
            Dispose(false);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Destroy the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
        ////////////////////////////////////////////////////////////
        private void Dispose(bool disposing)
        {
            if (myCPointer != IntPtr.Zero)
            {
                Destroy(disposing);
                myCPointer = IntPtr.Zero;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Destroy the object (implementation is left to each derived class)
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
        ////////////////////////////////////////////////////////////
        protected abstract void Destroy(bool disposing);
    }
}