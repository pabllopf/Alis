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
    ///     Defines 32 collision categories as a bit-flag enum, used for collision filtering.
    ///     Each fixture can belong to one or more categories, and collision occurs only when
    ///     categories match according to the collision mask.
    /// </summary>
    [Flags]
    public enum Category
    {
        /// <summary>No category (collides with nothing by default).</summary>
        None = 0x00000000,

        /// <summary>Category 1 (bit 0).</summary>
        Cat1 = 0x00000001,

        /// <summary>Category 2 (bit 1).</summary>
        Cat2 = 0x00000002,

        /// <summary>Category 3 (bit 2).</summary>
        Cat3 = 0x00000004,

        /// <summary>Category 4 (bit 3).</summary>
        Cat4 = 0x00000008,

        /// <summary>Category 5 (bit 4).</summary>
        Cat5 = 0x00000010,

        /// <summary>Category 6 (bit 5).</summary>
        Cat6 = 0x00000020,

        /// <summary>Category 7 (bit 6).</summary>
        Cat7 = 0x00000040,

        /// <summary>Category 8 (bit 7).</summary>
        Cat8 = 0x00000080,

        /// <summary>Category 9 (bit 8).</summary>
        Cat9 = 0x00000100,

        /// <summary>Category 10 (bit 9).</summary>
        Cat10 = 0x00000200,

        /// <summary>Category 11 (bit 10).</summary>
        Cat11 = 0x00000400,

        /// <summary>Category 12 (bit 11).</summary>
        Cat12 = 0x00000800,

        /// <summary>Category 13 (bit 12).</summary>
        Cat13 = 0x00001000,

        /// <summary>Category 14 (bit 13).</summary>
        Cat14 = 0x00002000,

        /// <summary>Category 15 (bit 14).</summary>
        Cat15 = 0x00004000,

        /// <summary>Category 16 (bit 15).</summary>
        Cat16 = 0x00008000,

        /// <summary>Category 17 (bit 16).</summary>
        Cat17 = 0x00010000,

        /// <summary>Category 18 (bit 17).</summary>
        Cat18 = 0x00020000,

        /// <summary>Category 19 (bit 18).</summary>
        Cat19 = 0x00040000,

        /// <summary>Category 20 (bit 19).</summary>
        Cat20 = 0x00080000,

        /// <summary>Category 21 (bit 20).</summary>
        Cat21 = 0x00100000,

        /// <summary>Category 22 (bit 21).</summary>
        Cat22 = 0x00200000,

        /// <summary>Category 23 (bit 22).</summary>
        Cat23 = 0x00400000,

        /// <summary>Category 24 (bit 23).</summary>
        Cat24 = 0x00800000,

        /// <summary>Category 25 (bit 24).</summary>
        Cat25 = 0x01000000,

        /// <summary>Category 26 (bit 25).</summary>
        Cat26 = 0x02000000,

        /// <summary>Category 27 (bit 26).</summary>
        Cat27 = 0x04000000,

        /// <summary>Category 28 (bit 27).</summary>
        Cat28 = 0x08000000,

        /// <summary>Category 29 (bit 28).</summary>
        Cat29 = 0x10000000,

        /// <summary>Category 30 (bit 29).</summary>
        Cat30 = 0x20000000,

        /// <summary>Category 31 (bit 30).</summary>
        Cat31 = 0x40000000,

        /// <summary>All categories (collides with everything).</summary>
        All = int.MaxValue
    }
}