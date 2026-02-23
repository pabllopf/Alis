// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResourceMetricsFactory.cs
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
using Alis.Extension.Profile.Interfaces;
using Alis.Extension.Profile.Models;

namespace Alis.Extension.Profile.Factories
{
    /// <summary>
    ///     Factory class responsible for creating <see cref="ResourceMetrics" /> instances
    ///     by capturing current system resource data from a resource monitor.
    ///     This follows the Factory pattern to encapsulate the creation logic.
    /// </summary>
    public class ResourceMetricsFactory
    {
        /// <summary>
        ///     The resource monitor used to gather system metrics.
        /// </summary>
        private readonly IResourceMonitor resourceMonitor;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourceMetricsFactory" /> class.
        /// </summary>
        /// <param name="resourceMonitor">The resource monitor to use for gathering metrics.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when resourceMonitor is null.
        /// </exception>
        public ResourceMetricsFactory(IResourceMonitor resourceMonitor)
        {
            this.resourceMonitor = resourceMonitor ?? throw new ArgumentNullException(nameof(resourceMonitor));
        }

        /// <summary>
        ///     Creates a new <see cref="ResourceMetrics" /> instance by capturing
        ///     the current system resource state from the configured monitor.
        /// </summary>
        /// <returns>
        ///     A <see cref="ResourceMetrics" /> struct containing current resource data.
        /// </returns>
        public ResourceMetrics CreateSnapshot()
        {
            return new ResourceMetrics(
                cpuUsageMilliseconds: resourceMonitor.GetCpuUsage(),
                memoryUsageBytes: resourceMonitor.GetMemoryUsage(),
                garbageCollectionCount: resourceMonitor.GetGarbageCollectionCount(),
                threadCount: resourceMonitor.GetThreadCount(),
                timestamp: DateTime.Now
            );
        }

        /// <summary>
        ///     Creates a new empty <see cref="ResourceMetrics" /> instance.
        /// </summary>
        /// <returns>
        ///     An empty <see cref="ResourceMetrics" /> struct with default values.
        /// </returns>
        public ResourceMetrics CreateEmpty()
        {
            return ResourceMetrics.Empty;
        }
    }
}

