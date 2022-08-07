// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SimplexCache.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Used to warm start Distance.
    ///     Set count to zero on first call.
    /// </summary>
    public struct SimplexCache
    {
        /// <summary>
        ///     Length or area.
        /// </summary>
        public float Metric;

        /// <summary>
        ///     The count
        /// </summary>
        public ushort Count;

        /// <summary>
        ///     Vertices on shape A.
        /// </summary>
        //public Byte[/*3*/] IndexA;
        public IndexArray IndexA;

        /// <summary>
        ///     Vertices on shape B.
        /// </summary>
        //public Byte[/*3*/] IndexB;
        public IndexArray IndexB;

        //public SimplexCache(byte init)
        //{
        //	Metric = 0;
        //	Count = 0;
        //	IndexA = new Byte[3];
        //	IndexB = new Byte[3];
        //}
    }
}