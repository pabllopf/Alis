// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SlotAttribute.cs
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

using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Audio.D2.Core.Native
{
    /// <summary>
    ///     Defines the slot index for a wrapper function.
    ///     This type supports OpenTK and should not be
    ///     used in user code.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class SlotAttribute : Attribute
    {
        /// <summary>
        ///     Defines the slot index for a wrapper function.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private",
            Justification =
                "This field is used in legacy internal rewriting logic. We don't want to change visibility just yet.")]
        internal int Slot;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SlotAttribute" /> class.
        /// </summary>
        /// <param name="index">The slot index for a wrapper function.</param>
        public SlotAttribute(int index)
        {
            Slot = index;
        }
    }
}