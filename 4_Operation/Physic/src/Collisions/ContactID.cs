// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactID.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Uniquely identifies a contact point between two colliding shapes to facilitate warm starting.
    /// </summary>
    /// <remarks>
    ///     Provides both structured feature data and a fast comparison key for contact persistence.
    ///     The union allows efficient equality checking while maintaining detailed feature information
    ///     needed for accurate collision response across simulation steps.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    public struct ContactId
    {
        /// <summary>
        ///     Gets or sets the structured contact features that define this contact point.
        /// </summary>
        /// <value>The <see cref="ContactFeature"/> describing the geometric intersection.</value>
        [FieldOffset(0)] public ContactFeature Features;

        /// <summary>
        ///     Gets or sets the packed integer key used for fast contact comparison and hashing.
        /// </summary>
        /// <value>A 32-bit unsigned integer representing the contact identity.</value>
        [FieldOffset(0)] public uint Key;
    }
}