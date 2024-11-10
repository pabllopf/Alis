// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedArray.cs
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

/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

/*
 * Farseer Physics Engine:
 * Copyright (c) 2012 Ian Qvist
 *
 * Original source Box2D:
 * Copyright (c) 2006-2011 Erin Catto http://www.box2d.org
 *
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software
 * in a product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    /// The fixed array
    /// </summary>
    public struct FixedArray2<T>
    {
        /// <summary>
        /// The value
        /// </summary>
        private T _value0;
        /// <summary>
        /// The value
        /// </summary>
        private T _value1;

        /// <summary>
        /// The index out of range exception
        /// </summary>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _value0;
                    case 1:
                        return _value1;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _value0 = value;
                        break;
                    case 1:
                        _value1 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }

    /// <summary>
    /// The fixed array
    /// </summary>
    public struct FixedArray3<T>
    {
        /// <summary>
        /// The value
        /// </summary>
        private T _value0;
        /// <summary>
        /// The value
        /// </summary>
        private T _value1;
        /// <summary>
        /// The value
        /// </summary>
        private T _value2;

        /// <summary>
        /// The index out of range exception
        /// </summary>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _value0;
                    case 1:
                        return _value1;
                    case 2:
                        return _value2;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _value0 = value;
                        break;
                    case 1:
                        _value1 = value;
                        break;
                    case 2:
                        _value2 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }

    /// <summary>
    /// The fixed array
    /// </summary>
    public struct FixedArray4<T>
    {
        /// <summary>
        /// The value
        /// </summary>
        private T _value0;
        /// <summary>
        /// The value
        /// </summary>
        private T _value1;
        /// <summary>
        /// The value
        /// </summary>
        private T _value2;
        /// <summary>
        /// The value
        /// </summary>
        private T _value3;

        /// <summary>
        /// The index out of range exception
        /// </summary>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _value0;
                    case 1:
                        return _value1;
                    case 2:
                        return _value2;
                    case 3:
                        return _value3;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _value0 = value;
                        break;
                    case 1:
                        _value1 = value;
                        break;
                    case 2:
                        _value2 = value;
                        break;
                    case 3:
                        _value3 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }

    /// <summary>
    /// The fixed array
    /// </summary>
    public struct FixedArray8<T>
    {
        /// <summary>
        /// The value
        /// </summary>
        private T _value0;
        /// <summary>
        /// The value
        /// </summary>
        private T _value1;
        /// <summary>
        /// The value
        /// </summary>
        private T _value2;
        /// <summary>
        /// The value
        /// </summary>
        private T _value3;
        /// <summary>
        /// The value
        /// </summary>
        private T _value4;
        /// <summary>
        /// The value
        /// </summary>
        private T _value5;
        /// <summary>
        /// The value
        /// </summary>
        private T _value6;
        /// <summary>
        /// The value
        /// </summary>
        private T _value7;

        /// <summary>
        /// The index out of range exception
        /// </summary>
        public T this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return _value0;
                    case 1:
                        return _value1;
                    case 2:
                        return _value2;
                    case 3:
                        return _value3;
                    case 4:
                        return _value4;
                    case 5:
                        return _value5;
                    case 6:
                        return _value6;
                    case 7:
                        return _value7;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        _value0 = value;
                        break;
                    case 1:
                        _value1 = value;
                        break;
                    case 2:
                        _value2 = value;
                        break;
                    case 3:
                        _value3 = value;
                        break;
                    case 4:
                        _value4 = value;
                        break;
                    case 5:
                        _value5 = value;
                        break;
                    case 6:
                        _value6 = value;
                        break;
                    case 7:
                        _value7 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }
}