// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RawArrayData.cs
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

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    /// The raw array data class
    /// </summary>
    public sealed class RawArrayData
    {
        /// <summary>
        /// The length
        /// </summary>
        public uint Length;
        
        /// <summary>
        /// The padding
        /// </summary>
        public uint Padding;
        
        /// <summary>
        /// The data
        /// </summary>
        public byte Data;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RawArrayData"/> class
        /// </summary>
        public RawArrayData()
        {
            Length = 0;
            Padding = 0;
            Data = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RawArrayData"/> class
        /// </summary>
        /// <param name="length">The length</param>
        /// <param name="padding">The padding</param>
        /// <param name="data">The data</param>
        public RawArrayData(uint length, uint padding, byte data)
        {
            Length = length;
            Padding = padding;
            Data = data;
        }
    }
}