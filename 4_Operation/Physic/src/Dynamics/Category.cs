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

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The category enum
    /// </summary>
    [Flags]
    public enum Category
    {
        /// <summary>
        /// The none category
        /// </summary>
        None = 0x00000000,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat1 = 0x00000001,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat2 = 0x00000002,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat3 = 0x00000004,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat4 = 0x00000008,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat5 = 0x00000010,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat6 = 0x00000020,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat7 = 0x00000040,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat8 = 0x00000080,
        /// <summary>
        /// The cat category
        /// </summary>
        Cat9 = 0x00000100,
        /// <summary>
        /// The cat 10 category
        /// </summary>
        Cat10 = 0x00000200,
        /// <summary>
        /// The cat 11 category
        /// </summary>
        Cat11 = 0x00000400,
        /// <summary>
        /// The cat 12 category
        /// </summary>
        Cat12 = 0x00000800,
        /// <summary>
        /// The cat 13 category
        /// </summary>
        Cat13 = 0x00001000,
        /// <summary>
        /// The cat 14 category
        /// </summary>
        Cat14 = 0x00002000,
        /// <summary>
        /// The cat 15 category
        /// </summary>
        Cat15 = 0x00004000,
        /// <summary>
        /// The cat 16 category
        /// </summary>
        Cat16 = 0x00008000,
        /// <summary>
        /// The cat 17 category
        /// </summary>
        Cat17 = 0x00010000,
        /// <summary>
        /// The cat 18 category
        /// </summary>
        Cat18 = 0x00020000,
        /// <summary>
        /// The cat 19 category
        /// </summary>
        Cat19 = 0x00040000,
        /// <summary>
        /// The cat 20 category
        /// </summary>
        Cat20 = 0x00080000,
        /// <summary>
        /// The cat 21 category
        /// </summary>
        Cat21 = 0x00100000,
        /// <summary>
        /// The cat 22 category
        /// </summary>
        Cat22 = 0x00200000,
        /// <summary>
        /// The cat 23 category
        /// </summary>
        Cat23 = 0x00400000,
        /// <summary>
        /// The cat 24 category
        /// </summary>
        Cat24 = 0x00800000,
        /// <summary>
        /// The cat 25 category
        /// </summary>
        Cat25 = 0x01000000,
        /// <summary>
        /// The cat 26 category
        /// </summary>
        Cat26 = 0x02000000,
        /// <summary>
        /// The cat 27 category
        /// </summary>
        Cat27 = 0x04000000,
        /// <summary>
        /// The cat 28 category
        /// </summary>
        Cat28 = 0x08000000,
        /// <summary>
        /// The cat 29 category
        /// </summary>
        Cat29 = 0x10000000,
        /// <summary>
        /// The cat 30 category
        /// </summary>
        Cat30 = 0x20000000,
        /// <summary>
        /// The cat 31 category
        /// </summary>
        Cat31 = 0x40000000,
        /// <summary>
        /// The all category
        /// </summary>
        All = int.MaxValue
    }
}