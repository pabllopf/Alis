// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Category.cs
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

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The category enum
    /// </summary>
    [Flags]
    public enum Category
    {
        /// <summary>
        ///     No collision category (all bits clear).
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     Collision category 1 (bit 0).
        /// </summary>
        Cat1 = 0x00000001,

        /// <summary>
        ///     Collision category 2 (bit 1).
        /// </summary>
        Cat2 = 0x00000002,

        /// <summary>
        ///     Collision category 3 (bit 2).
        /// </summary>
        Cat3 = 0x00000004,

        /// <summary>
        ///     Collision category 4 (bit 3).
        /// </summary>
        Cat4 = 0x00000008,

        /// <summary>
        ///     Collision category 5 (bit 4).
        /// </summary>
        Cat5 = 0x00000010,

        /// <summary>
        ///     Collision category 6 (bit 5).
        /// </summary>
        Cat6 = 0x00000020,

        /// <summary>
        ///     Collision category 7 (bit 6).
        /// </summary>
        Cat7 = 0x00000040,

        /// <summary>
        ///     Collision category 8 (bit 7).
        /// </summary>
        Cat8 = 0x00000080,

        /// <summary>
        ///     Collision category 9 (bit 8).
        /// </summary>
        Cat9 = 0x00000100,

        /// <summary>
        ///     Collision category 10 (bit 9).
        /// </summary>
        Cat10 = 0x00000200,

        /// <summary>
        ///     Collision category 11 (bit 10).
        /// </summary>
        Cat11 = 0x00000400,

        /// <summary>
        ///     Collision category 12 (bit 11).
        /// </summary>
        Cat12 = 0x00000800,

        /// <summary>
        ///     Collision category 13 (bit 12).
        /// </summary>
        Cat13 = 0x00001000,

        /// <summary>
        ///     Collision category 14 (bit 13).
        /// </summary>
        Cat14 = 0x00002000,

        /// <summary>
        ///     Collision category 15 (bit 14).
        /// </summary>
        Cat15 = 0x00004000,

        /// <summary>
        ///     Collision category 16 (bit 15).
        /// </summary>
        Cat16 = 0x00008000,

        /// <summary>
        ///     Collision category 17 (bit 16).
        /// </summary>
        Cat17 = 0x00010000,

        /// <summary>
        ///     Collision category 18 (bit 17).
        /// </summary>
        Cat18 = 0x00020000,

        /// <summary>
        ///     Collision category 19 (bit 18).
        /// </summary>
        Cat19 = 0x00040000,

        /// <summary>
        ///     Collision category 20 (bit 19).
        /// </summary>
        Cat20 = 0x00080000,

        /// <summary>
        ///     Collision category 21 (bit 20).
        /// </summary>
        Cat21 = 0x00100000,

        /// <summary>
        ///     Collision category 22 (bit 21).
        /// </summary>
        Cat22 = 0x00200000,

        /// <summary>
        ///     Collision category 23 (bit 22).
        /// </summary>
        Cat23 = 0x00400000,

        /// <summary>
        ///     Collision category 24 (bit 23).
        /// </summary>
        Cat24 = 0x00800000,

        /// <summary>
        ///     Collision category 25 (bit 24).
        /// </summary>
        Cat25 = 0x01000000,

        /// <summary>
        ///     Collision category 26 (bit 25).
        /// </summary>
        Cat26 = 0x02000000,

        /// <summary>
        ///     Collision category 27 (bit 26).
        /// </summary>
        Cat27 = 0x04000000,

        /// <summary>
        ///     Collision category 28 (bit 27).
        /// </summary>
        Cat28 = 0x08000000,

        /// <summary>
        ///     Collision category 29 (bit 28).
        /// </summary>
        Cat29 = 0x10000000,

        /// <summary>
        ///     Collision category 30 (bit 29).
        /// </summary>
        Cat30 = 0x20000000,

        /// <summary>
        ///     Collision category 31 (bit 30).
        /// </summary>
        Cat31 = 0x40000000,

        /// <summary>
        ///     All collision categories (all 31 bits set).
        /// </summary>
        All = int.MaxValue
    }
}