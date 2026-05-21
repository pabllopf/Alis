

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
        public ResourceMetricsFactory(IResourceMonitor resourceMonitor) => this.resourceMonitor = resourceMonitor ?? throw new ArgumentNullException(nameof(resourceMonitor));

        /// <summary>
        ///     Creates a new <see cref="ResourceMetrics" /> instance by capturing
        ///     the current system resource state from the configured monitor.
        /// </summary>
        /// <returns>
        ///     A <see cref="ResourceMetrics" /> struct containing current resource data.
        /// </returns>
        public ResourceMetrics CreateSnapshot() => new ResourceMetrics(
            resourceMonitor.GetCpuUsage(),
            resourceMonitor.GetMemoryUsage(),
            resourceMonitor.GetGarbageCollectionCount(),
            resourceMonitor.GetThreadCount(),
            DateTime.Now
        );

        /// <summary>
        ///     Creates a new empty <see cref="ResourceMetrics" /> instance.
        /// </summary>
        /// <returns>
        ///     An empty <see cref="ResourceMetrics" /> struct with default values.
        /// </returns>
        public static ResourceMetrics CreateEmpty() => ResourceMetrics.Empty;
    }
}