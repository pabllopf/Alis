// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   IndexArray.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Aspect.Logging;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The index array
    /// </summary>
    public struct IndexArray
    {
        /// <summary>
        ///     The
        /// </summary>
        private byte i0;

        /// <summary>
        ///     The
        /// </summary>
        private byte i1;

        /// <summary>
        ///     The
        /// </summary>
        private byte i2;

        /// <summary>
        ///     The value
        /// </summary>
        public byte this[int index]
        {
            get
            {
#if DEBUG
                Box2DxDebug.Assert(index >= 0 && index < 3);
#endif
                if (index == 0)
                {
                    return i0;
                }

                if (index == 1)
                {
                    return i1;
                }

                return i2;
            }
            set
            {
#if DEBUG
                Box2DxDebug.Assert(index >= 0 && index < 3);
#endif
                if (index == 0)
                {
                    i0 = value;
                }
                else if (index == 1)
                {
                    i1 = value;
                }
                else
                {
                    i2 = value;
                }
            }
        }
    }
}