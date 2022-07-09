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
        private byte I0;

        /// <summary>
        ///     The
        /// </summary>
        private byte I1;

        /// <summary>
        ///     The
        /// </summary>
        private byte I2;

        /// <summary>
        ///     The value
        /// </summary>
        public byte this[int index]
        {
            get
            {
#if DEBUG
                Box2DXDebug.Assert(index >= 0 && index < 3);
#endif
                if (index == 0) return I0;
                if (index == 1) return I1;
                return I2;
            }
            set
            {
#if DEBUG
                Box2DXDebug.Assert(index >= 0 && index < 3);
#endif
                if (index == 0) I0 = value;
                else if (index == 1) I1 = value;
                else I2 = value;
            }
        }
    }
}