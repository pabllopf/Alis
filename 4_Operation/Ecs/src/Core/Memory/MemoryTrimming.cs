// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryTrimming.cs
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

namespace Alis.Core.Ecs.Core.Memory
{
    /// <summary>
    ///     Specifies the level of memory trimming Frent's internal buffers should do
    /// </summary>
    [Obsolete("I may or may not use this in the future.")]
    public enum MemoryTrimming
    {
        /// <summary>
        ///     Always trim buffers when there is memory pressure
        /// </summary>
        Always = 0,

        /// <summary>
        ///     Trim buffers a balanced amount
        /// </summary>
        Normal = 1,

        /// <summary>
        ///     Never trim buffers, even when there is memory pressure
        /// </summary>
        Never = 2
    }
}