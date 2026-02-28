// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelSafeAttribute.cs
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

namespace Alis.Extension.Thread.Attributes
{
    /// <summary>
    ///     Marks a component as safe for parallel execution.
    ///     Components marked with this attribute can be processed simultaneously across multiple threads.
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ParallelSafeAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelSafeAttribute" /> class
        /// </summary>
        public ParallelSafeAttribute()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParallelSafeAttribute" /> class
        /// </summary>
        /// <param name="minBatchSize">The minimum batch size for parallel execution</param>
        public ParallelSafeAttribute(int minBatchSize)
        {
            MinBatchSize = minBatchSize;
        }

        /// <summary>
        ///     Gets the minimum batch size for parallel execution.
        ///     If entity count is below this threshold, sequential execution will be used.
        /// </summary>
        public int MinBatchSize { get; } = 128;
    }
}

