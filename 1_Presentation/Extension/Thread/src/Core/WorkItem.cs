// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorkItem.cs
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

namespace Alis.Extension.Thread.Core
{
    /// <summary>
    ///     Represents a unit of work that can be executed in parallel
    /// </summary>
    internal sealed class WorkItem
    {
        /// <summary>
        ///     Gets or sets the action to execute
        /// </summary>
        public Action<int, int> Action { get; set; }

        /// <summary>
        ///     Gets or sets the start index for this work item
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        ///     Gets or sets the length of elements to process
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     Resets the work item for reuse
        /// </summary>
        public void Reset()
        {
            Action = null;
            StartIndex = 0;
            Length = 0;
        }
    }
}

