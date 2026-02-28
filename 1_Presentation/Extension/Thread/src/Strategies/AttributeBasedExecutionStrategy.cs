// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AttributeBasedExecutionStrategy.cs
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
using System.Collections.Concurrent;
using Alis.Extension.Thread.Attributes;
using Alis.Extension.Thread.Interfaces;

namespace Alis.Extension.Thread.Strategies
{
    /// <summary>
    ///     Execution strategy based on attributes and interfaces
    /// </summary>
    public sealed class AttributeBasedExecutionStrategy : IParallelExecutionStrategy
    {
        /// <summary>
        ///     Cache for parallel capability checks
        /// </summary>
        private readonly ConcurrentDictionary<Type, bool> parallelCapabilityCache = new ConcurrentDictionary<Type, bool>();

        /// <summary>
        ///     Cache for minimum batch sizes
        /// </summary>
        private readonly ConcurrentDictionary<Type, int> minBatchSizeCache = new ConcurrentDictionary<Type, int>();

        /// <summary>
        ///     Default minimum batch size
        /// </summary>
        private const int DefaultMinBatchSize = 128;

        /// <summary>
        ///     Determines if the given type can be executed in parallel
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>True if the component can be executed in parallel</returns>
        public bool CanExecuteInParallel(Type componentType)
        {
            if (componentType == null)
            {
                return false;
            }

            return parallelCapabilityCache.GetOrAdd(componentType, type =>
            {
                // Check for ParallelSafe attribute
                if (Attribute.IsDefined(type, typeof(ParallelSafeAttribute)))
                {
                    return true;
                }

                // Check for IParallelCapable interface
                if (typeof(IParallelCapable).IsAssignableFrom(type))
                {
                    return true;
                }

                return false;
            });
        }

        /// <summary>
        ///     Gets the minimum batch size for the given type
        /// </summary>
        /// <param name="componentType">The component type</param>
        /// <returns>The minimum batch size</returns>
        public int GetMinimumBatchSize(Type componentType)
        {
            if (componentType == null)
            {
                return DefaultMinBatchSize;
            }

            return minBatchSizeCache.GetOrAdd(componentType, type =>
            {
                ParallelSafeAttribute attr = (ParallelSafeAttribute)Attribute.GetCustomAttribute(type, typeof(ParallelSafeAttribute));
                return attr?.MinBatchSize ?? DefaultMinBatchSize;
            });
        }

        /// <summary>
        ///     Clears the caches
        /// </summary>
        public void ClearCache()
        {
            parallelCapabilityCache.Clear();
            minBatchSizeCache.Clear();
        }
    }
}

